using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityFramework.Location;
using ApolloTests.Data.EntityFramework.Proxy;
using ApolloTests.Data.EntityFramework.Reference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ApolloTests.Data.EntityFramework.Context
{
    [Binding]
    public class ApolloContext : DbContext
    {
        protected IConfiguration Config { get; }
        public SQLContext SQLContext { get; private set; }
        public CosmosContext CosmosContext { get; private set; }

        public void SetSQLContext(SQLContext ctx) => SQLContext = ctx;
        public void SetCosmosContext(CosmosContext ctx) => CosmosContext = ctx;

        [BeforeScenario]
        public static void Initialize(SQLContext sql, CosmosContext cosmos)
        {
            sql.SetCosmosContext(cosmos);
            sql.SetSQLContext(sql);

            cosmos.SetCosmosContext(cosmos);
            cosmos.SetSQLContext(sql);
        }
        public ApolloContext(IConfiguration config) : base()
        {
            Config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine);

            var extension = optionsBuilder.Options.FindExtension<ProxiesOptionsExtension>()
            ?? new ProxiesOptionsExtension();

            extension = extension.WithLazyLoading(true);

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        }

    }



}

