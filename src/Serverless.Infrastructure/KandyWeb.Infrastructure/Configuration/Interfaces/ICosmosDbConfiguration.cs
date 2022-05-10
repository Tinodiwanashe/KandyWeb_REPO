using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Infrastructure.Configuration.Interfaces
{
    public interface ICosmosDbConfiguration
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ResumeContainerName { get; set; }
        string ResumePartitionKeyPath { get; set; }
        string UserProfileContainerName { get; set; }
        string UserProfilePartitionKeyPath { get; set; }
        string LikeContainerName { get; set; }
        string LikePartitionKeyPath { get; set; }
    }
}
