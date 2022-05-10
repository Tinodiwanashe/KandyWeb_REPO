﻿using KandyWeb.Application.Interfaces.Repositories;
using KandyWeb.Domain.Entities;
using KandyWeb.Infrastructure.Configuration.Interfaces;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Infrastructure.Repositories
{
    public class ResumeRepository : GenericRepository<Resume>
    {
        public ResumeRepository(ICosmosDbConfiguration cosmosDbConfiguration,
                 CosmosClient client) : base(cosmosDbConfiguration, client)
        {
        }

        public override string ContainerName => _cosmosDbConfiguration.ResumeContainerName;
    }
}
