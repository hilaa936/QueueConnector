
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using queue.connector.Interfaces;
using queue.connector.Model;
using queue.connector.Settings;


namespace queue.connector.Extensions
{
    public static  class QueueConnectorExtensions
    {
        public static IServiceCollection AddQueueConnectorServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.Configure<QueueStorageSettings>(configuration.GetSection(QueueStorageSettings.Key));
            services.AddScoped<IMessageConnector<NQMessage>, MessageQueueConnector>();

            return services;
        }
    }
}
