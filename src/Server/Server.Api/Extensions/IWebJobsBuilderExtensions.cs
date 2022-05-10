using KandyWeb.Infrastructure.Contexts;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Server.Api.Extensions
{
    public static class IWebJobsBuilderExtensions
    {
        private static readonly string Endpoint = Environment.GetEnvironmentVariable("Account");
        private static readonly string Key = Environment.GetEnvironmentVariable("Key");
        private static readonly string databaseName = Environment.GetEnvironmentVariable("DatabaseName");

        public static void AddDBContext(this IWebJobsBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseCosmos(Endpoint,
                Key,
                databaseName);
            });
        }
        
    }
}
