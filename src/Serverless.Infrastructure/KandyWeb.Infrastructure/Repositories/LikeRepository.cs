using KandyWeb.Application.Interfaces.Repositories;
using KandyWeb.Domain.Entities;
using KandyWeb.Infrastructure.Configuration.Interfaces;
using KandyWeb.Infrastructure.Contexts;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Infrastructure.Repositories
{
    public class LikeRepository : GenericRepository<Like>
    {
        public LikeRepository(ICosmosDbConfiguration cosmosDbConfiguration,
                 CosmosClient client) : base(cosmosDbConfiguration, client)
        {
        }

        public override string ContainerName => _cosmosDbConfiguration.LikeContainerName;
    }
}
