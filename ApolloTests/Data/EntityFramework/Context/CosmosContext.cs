using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityFramework.Location;
using ApolloTests.Data.EntityFramework.Proxy;
using ApolloTests.Data.EntityFramework.Reference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityFramework.Context
{
    public class CosmosContext : ApolloContext
    {

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Policy> Policies { get; set; }

        public CosmosContext(IConfiguration config) : base(config)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quote>().ToContainer("Application");
            modelBuilder.Entity<Quote>().HasDiscriminator(it => it.Discriminator).HasValue("ApplicationEntity");

            modelBuilder.Entity<Policy>().ToContainer("RatableObject");
            modelBuilder.Entity<Policy>().HasDiscriminator(it => it.Discriminator).HasValue("RatableObjectEntity");


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var CosmosUri = Config.GetVariable("COSMOS_URI");
            var primaryKey = Config.GetVariable("COSMOS_API_KEY");
            var databaseName = Config.GetVariable("COSMOS_DATABASE_NAME");
            optionsBuilder.UseCosmos(CosmosUri, primaryKey, databaseName);

            var extension = optionsBuilder.Options.FindExtension<ProxiesOptionsExtension>()
            ?? new ProxiesOptionsExtension();

            extension = extension.WithLazyLoading(true);

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        }

    }



}

