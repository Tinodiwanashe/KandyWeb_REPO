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

namespace KandyWeb.Persistence
{
    public class KandymanAppDBContext: DbContext
    {
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Endpoint = "https://kandyman-720.documents.azure.com:443/";
            var Key = "tJvfN9syiaOTZjBvERSHNHq6wPujg9fwFJfpldBQU3MyoQfzUUI9zW7F8Oa0DfAG4YytH4ZdgMHErGoxsY50Ig==";
            var databaseName = "KandymanDB";

            optionsBuilder.UseCosmos(Endpoint,Key,databaseName)
                                     .EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedBy = "jhnh knjkj gughjhgjb yhhj";//_currentUserService.UserId;
        //                entry.Entity.Created = DateTime.UtcNow;
        //                break;
        //            case EntityState.Modified:
        //                entry.Entity.LastModifiedBy = "sdd";
        //                entry.Entity.LastModified = DateTime.UtcNow;
        //                break;
        //        }
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().ToContainer("UserProfiles");
            modelBuilder.Entity<UserProfile>()
                .OwnsMany(p => p.Resumes)
                .WithOwner(p => p.UserProfile);
                //.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserProfile>().ToContainer("UserProfiles");
            modelBuilder.Entity<UserProfile>()
                .OwnsMany(p => p.Likes)
                .WithOwner(p => p.UserProfile);
                //.OnDelete(DeleteBehavior.NoAction);

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
