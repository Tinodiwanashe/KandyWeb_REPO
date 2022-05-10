using KandyWeb.Domain.Entities;
using KandyWeb.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Serilog;
using System.Net;
using Microsoft.Azure.Cosmos;
using KandyWeb.Infrastructure.Configuration.Interfaces;

namespace KandyWeb.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ICosmosDbConfiguration _cosmosDbConfiguration;
        protected readonly CosmosClient _client;

        public abstract string ContainerName { get; }

        public GenericRepository(ICosmosDbConfiguration cosmosDbConfiguration,
                           CosmosClient client)
        {
            _cosmosDbConfiguration = cosmosDbConfiguration
                    ?? throw new ArgumentNullException(nameof(cosmosDbConfiguration));

            _client = client
                    ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<T> AddAsync(T newEntity)
        {
            try
            {
                var container = GetContainer();
                ItemResponse<T> createResponse = await container.CreateItemAsync(newEntity);
                return createResponse.Resource;
            }
            catch (CosmosException ex)
            {
                Log.Error($"New entity with ID: {newEntity.Id} was not added successfully - error details: {ex.Message}");

                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    throw;
                }

                return null;
            }
        }

        public async Task DeleteAsync(string Id)
        {
            try
            {
                var container = GetContainer();

                await container.DeleteItemAsync<T>(Id, new PartitionKey(Id));
            }
            catch (CosmosException ex)
            {
                Log.Error($"Entity with ID: {Id} was not removed successfully - error details: {ex.Message}");

                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }
            }
        }

        public async Task<T> GetAsync(string Id)
        {
            try
            {
                var container = GetContainer();

                ItemResponse<T> entityResult = await container.ReadItemAsync<T>(Id, new PartitionKey(Id));
                return entityResult.Resource;
            }
            catch (CosmosException ex)
            {
                Log.Error($"Entity with ID: {Id} was not retrieved successfully - error details: {ex.Message}");

                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }

                return null;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var container = GetContainer();

                ItemResponse<T> entityResult = await container.ReadItemAsync<T>(entity.Id.ToString(), new PartitionKey(entity.Id.ToString()));

                if (entityResult != null)
                {
                    await container.ReplaceItemAsync(entity, entity.Id.ToString(), new PartitionKey(entity.Id.ToString()));
                }
                return entity;
            }
            catch (CosmosException ex)
            {
                Log.Error($"Entity with ID: {entity.Id} was not updated successfully - error details: {ex.Message}");

                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }

                return null;
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(string queryString)
        {
            try
            {
                var container = GetContainer();
                var queryResultSetIterator = container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
                var results = new List<T>();
                while (queryResultSetIterator.HasMoreResults)
                {
                    var response = await queryResultSetIterator.ReadNextAsync();
                    results.AddRange(response.ToList());
                }

                return results;

            }
            catch (CosmosException ex)
            {
                Log.Error($"Entities was not retrieved successfully - error details: {ex.Message}");

                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }

                return null;
            }
        }


        protected Container GetContainer()
        {
            var database = _client.GetDatabase(_cosmosDbConfiguration.DatabaseName);
            var container = database.GetContainer(ContainerName);
            return container;
        }
    }
}
