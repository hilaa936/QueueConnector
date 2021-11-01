
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using queue.connector.Interfaces;
using queue.connector.Model;
using queue.connector.Settings;
using System.Text.Json;
using System.Threading.Tasks;

namespace queue.connector
{
    public class MessageQueueConnector : IMessageConnector<NQMessage>
    {

        private readonly QueueStorageSettings _settings;

        private readonly ILogger<MessageQueueConnector> _logger;
        private readonly QueueClient _messageQueueClient;
        private readonly QueueClient _poisonMessageQueueClient;
        public MessageQueueConnector(ILogger<MessageQueueConnector> logger, IConfiguration configuration, IOptions<QueueStorageSettings> options)
        {

            _logger = logger;
            _settings = options.Value;
            var connectionString = _settings.StorageConnectionString;//configuration.GetConnectionString("StorageConnectionString"); //Environment.GetEnvironmentVariable("STORAGE_CONNECTION");
            var queueOpts = new QueueClientOptions { MessageEncoding = QueueMessageEncoding.Base64 };

            _messageQueueClient = new QueueClient(connectionString, _settings.NotificationQueue, queueOpts);
            _messageQueueClient.CreateIfNotExists();

            _poisonMessageQueueClient = new QueueClient(connectionString, _settings.NotificationPoisonQueue, queueOpts);
            _poisonMessageQueueClient.CreateIfNotExists();

        }
        public async Task AddMessageAsync(NQMessage qmessage)
        {
            await _messageQueueClient.SendMessageAsync(JsonSerializer.Serialize(qmessage));
        }
    }
}
