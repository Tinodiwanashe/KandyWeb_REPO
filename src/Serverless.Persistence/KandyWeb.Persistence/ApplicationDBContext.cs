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
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Endpoint = "https://localhost:8081";
            var Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

            optionsBuilder.UseCosmos(
                                     Endpoint,
                                     Key,
                                      "CommunityDatabase")
                                     //.UseLoggerFactory(GenerateLoggerFactory())
                                     .EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "jhnh knjkj gughjhgjb yhhj";//_currentUserService.UserId;
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "sdd";
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().ToContainer("UserProfiles");
            modelBuilder.Entity<UserProfile>()
                .OwnsMany(p => p.Resumes)
                .WithOne(p => p.UserProfile);
                //.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserProfile>().ToContainer("UserProfiles");
            modelBuilder.Entity<UserProfile>()
                .OwnsMany(p => p.Likes)
                .WithOne(p => p.UserProfile);
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
