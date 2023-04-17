using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityFramework.Location;
using ApolloTests.Data.EntityFramework.Proxy;
using ApolloTests.Data.EntityFramework.Reference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ApolloTests.Data.EntityFramework.Context
{
    public class SQLContext : ApolloContext
    {
        public DbSet<Tether.Tether> Tether { get; set; }
        public DbSet<Tether.TetherApplicationRatableObject> TetherApplicationRatableObject { get; set; }
        public DbSet<Location.Address> Address { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Reference.Line> Line { get; set; }
        public DbSet<Reference.SubLine> SubLine { get; set; }
        public DbSet<Coverage.CoverageType> CoverageType { get; set; }

        public SQLContext(IConfiguration config) : base(config) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetVariable("SQL_CONNECTION_STRING"));
        }

    }



}

