using ApolloTests.Data.Entities.Location;
using ApolloTests.Data.Entities.Proxy;
using ApolloTests.Data.Entities.Quesiton;
using ApolloTests.Data.Entities.Reference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ApolloTests.Data.Entities.Context
{
    public class SQLContext : ApolloContext
    {
        public DbSet<Tether.Tether> Tether { get; set; }
        public DbSet<Tether.TetherApplicationRatableObject> TetherApplicationRatableObject { get; set; }
        public DbSet<Location.Address> Address { get; set; }
        public DbSet<Location.StateProvince> StateProvince { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Reference.Line> Line { get; set; }
        public DbSet<Reference.SubLine> SubLine { get; set; }
        public DbSet<Coverage.CoverageType> CoverageType { get; set; }
        public DbSet<Storyboard> Storyboard { get; set; }
        public DbSet<StoryboardSection> StoryboardSection { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<BusinessType> BusinessType { get; set; }
        public DbSet<Coverage.LimitDeductible> LimitDeductible { get; set; }

        public SQLContext(IConfiguration config, IObjectContainer OC) : base(config, OC) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Config.GetVariable("SQL_CONNECTION_STRING"));
        }

    }



}

