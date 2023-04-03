using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityFramework.Location;
using ApolloTests.Data.EntityFramework.Proxy;
using ApolloTests.Data.EntityFramework.Reference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ApolloTests.Data.EntityFramework
{
    public class ApolloContext : DbContext
    {
        public DbSet<Tether.Tether> Tether { get; set; }
        public DbSet<Tether.TetherApplicationRatableObject> TetherApplicationRatableObject { get; set; }
        public DbSet<Location.Address> Address { get; set; }
        public DbSet<Location.Country> Country { get; set; }
        public DbSet<Reference.Line> Line { get; set; }
        public DbSet<Reference.SubLine> SubLine { get; set; }
        public DbSet<Coverage.CoverageType> CoverageType { get; set; }

        private IConfiguration Config { get; }
        public ApolloContext(IConfiguration config) : base()
        {
            this.Config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetVariable("SQL_CONNECTION_STRING"));

            var extension = optionsBuilder.Options.FindExtension<ProxiesOptionsExtension>()
            ?? new ProxiesOptionsExtension();

            extension = extension.WithLazyLoading(true);

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);
        }





    }
}
