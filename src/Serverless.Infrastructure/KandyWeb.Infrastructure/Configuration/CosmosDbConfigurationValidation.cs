using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Infrastructure.Configuration
{
    public class CosmosDbConfigurationValidation : IValidateOptions<CosmosDbConfiguration>
    {
        public ValidateOptionsResult Validate(string name, CosmosDbConfiguration options)
        {
            if (string.IsNullOrEmpty(options.ConnectionString))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.ConnectionString)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.ResumeContainerName))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.ResumeContainerName)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.UserProfileContainerName))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.UserProfileContainerName)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.LikeContainerName))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.LikeContainerName)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.DatabaseName))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.DatabaseName)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.ResumePartitionKeyPath))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.ResumePartitionKeyPath)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.UserProfilePartitionKeyPath))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.UserProfilePartitionKeyPath)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.LikePartitionKeyPath))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.LikePartitionKeyPath)} configuration parameter for the Azure Cosmos DB is required");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
