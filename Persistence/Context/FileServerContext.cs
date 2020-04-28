using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Mappings;
using System.IO;

namespace Persistence.Context
{
    public class FileServerContext : DbContext
    {
        #region 'DbSet<Entities>'
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Domain.Entities.File> Files { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 'EntitiesConfig'
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new FileMap());
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json").Build();

            optionsBuilder
                .UseSqlServer(config.GetConnectionString("FileServerContext"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .EnableSensitiveDataLogging();
        }
    }
}
