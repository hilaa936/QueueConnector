using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue.connector.Settings
{
    public class QueueStorageSettings
    {
        public const string Key = "QueueStorageSettings";

        public string StorageConnectionString { get; set; }
        public string NotificationQueue { get; set; }
        public string NotificationPoisonQueue { get; set; }
    }
}
