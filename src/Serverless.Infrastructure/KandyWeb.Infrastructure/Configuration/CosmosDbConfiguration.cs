using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KandyWeb.Infrastructure.Configuration.Interfaces;

namespace KandyWeb.Infrastructure.Configuration
{

    public class CosmosDbConfiguration : ICosmosDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ResumeContainerName { get; set; }
        public string ResumePartitionKeyPath { get; set; }
        public string LikeContainerName { get; set; }
        public string LikePartitionKeyPath { get; set; }
        public string UserProfileContainerName { get; set; }
        public string UserProfilePartitionKeyPath { get; set; }
    }

    
}
