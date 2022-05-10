using KandyWeb.Domain.Common;
using KandyWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Infrastructure.Contexts
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().ToContainer("UserProfiles");
            modelBuilder.Entity<UserProfile>()
                .OwnsMany(p => p.Resumes)
                .WithOwner(p => p.UserProfile);

            modelBuilder.Entity<UserProfile>()
                .OwnsMany(p => p.Likes)
                .WithOwner(p => p.UserProfile);

            base.OnModelCreating(modelBuilder);
        }

        //private ILoggerFactory GenerateLoggerFactory()
        //{
        //    var serviceCollection = new ServiceCollection();
        //    serviceCollection.AddLogging(builder => builder.AddConsole().AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Trace));

        //    return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        //}
    }
}
