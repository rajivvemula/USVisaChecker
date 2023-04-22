using AngleSharp.Dom;
using ApolloTests.Data.Entities.Location;
using ApolloTests.Data.Entities.Proxy;
using ApolloTests.Data.Entities.Reference;
using Microsoft.Azure.Cosmos.Linq;
using ApolloTests.Data.Entities.Risk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApolloTests.Data.Entities.Context
{
    public class CosmosContext : ApolloContext
    {

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<VehicleRisk> Vehicles { get; set; }
        public DbSet<DriverRisk> Drivers { get; set; }
        public DbSet<BuildingRisk> Buildings { get; set; } 
        public DbSet<Risk.LocationRisk> Locations { get; set; }
        public CosmosContext(IConfiguration config) : base(config) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>().ToContainer("Application");
            modelBuilder.Entity<Quote>().HasDiscriminator(it => it.Discriminator).HasValue("ApplicationEntity");

            modelBuilder.Entity<Policy>().ToContainer("RatableObject");
            modelBuilder.Entity<Policy>().HasDiscriminator(it => it.Discriminator).HasValue("RatableObjectEntity");
            
            modelBuilder.Entity<Claim>().ToContainer("Claim");
            modelBuilder.Entity<Claim>().HasDiscriminator(it => it.Discriminator).HasValue("ClaimEntity");

            //modelBuilder.Entity<RiskBase>()
            //    .HasOne(r => r.Vehicle);
            //modelBuilder.Entity<RiskBase>()
            //   .HasOne(r => r.Driver);
            //modelBuilder.Entity<RiskBase>()
            //   .HasOne(r => r.Building);
            //modelBuilder.Entity<RiskBase>()
            //   .HasOne(r => r.Location);

            modelBuilder.Entity<RiskBase>()
                .ToContainer("Tether")
                .HasDiscriminator(it => it.RiskTypeId)
                .HasValue<VehicleRisk>(1)
                .HasValue<DriverRisk>(2)
                .HasValue<BuildingRisk>(3)
                .HasValue<LocationRisk>(4)
                ;
            //modelBuilder.Entity<RiskBase>()
            //    .HasOne(r => r.Driver)
            //    .WithOne()
            //    .HasForeignKey<DriverRisk>(it=> it.Id)
            //    //.IsRequired(false)
            //    ;
            //modelBuilder.Entity<RiskBase>()
            //    .HasOne(r => r.Building)
            //    .WithOne()
            //    .HasForeignKey<BuildingRisk>(it => it.Id)
            //    //.IsRequired(false)
            //    ;
            //modelBuilder.Entity<RiskBase>()
            //    .HasOne(r => r.Vehicle)
            //    .WithOne()
            //    .HasForeignKey<VehicleRisk>(it => it.Id)
            //    //.IsRequired(false)
            //    ;
            //modelBuilder.Entity<RiskBase>()
            //    .HasOne(r => r.Location)
            //    .WithOne()
            //    .HasForeignKey<LocationRisk>(it => it.Id)
                //.IsRequired(false)
                ;
            //modelBuilder.Entity<VehicleRisk>()
            //    .HasBaseType<RiskBase>()
            //    .ToContainer("Tether")
            //    .IgnoreOtherRisks()
            //    .HasDiscriminator(it => it.RiskTypeId).HasValue(1);

            //modelBuilder.Entity<DriverRisk>()
            //    .HasBaseType<RiskBase>()
            //    .ToContainer("Tether")
            //    .IgnoreOtherRisks()
            //    .HasDiscriminator(it => it.RiskTypeId).HasValue(2);

            //modelBuilder.Entity<BuildingRisk>()
            //    .HasBaseType<RiskBase>()
            //    .ToContainer("Tether")
            //    .IgnoreOtherRisks()
            //    .HasDiscriminator(it => it.RiskTypeId).HasValue(3);

            //modelBuilder.Entity<Risk.LocationRisk>()
            //    .HasBaseType<RiskBase>()
            //    .ToContainer("Tether")
            //    .IgnoreOtherRisks()
            //    .HasDiscriminator(it => it.RiskTypeId).HasValue(4);

            base.OnModelCreating(modelBuilder);

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var CosmosUri = Config.GetVariable("COSMOS_URI");
            var primaryKey = Config.GetVariable("COSMOS_API_KEY");
            var databaseName = Config.GetVariable("COSMOS_DATABASE_NAME");
            optionsBuilder.UseCosmos(CosmosUri, primaryKey, databaseName);
        }

    }



}

