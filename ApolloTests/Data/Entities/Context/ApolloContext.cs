using ApolloTests.Data.Entities.Risk;
using ApolloTests.Data.Entities.Proxy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using AngleSharp.Dom;
using HitachiQA.Helpers;
using System.Collections;

namespace ApolloTests.Data.Entities.Context
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            CheckForJTokens(modelBuilder);
            //CheckForNullValues(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Trace)
            //.EnableDetailedErrors()
            //.EnableSensitiveDataLogging()
            //;
            
            //optionsBuilder.LogTo(Console.WriteLine);

            var extension = optionsBuilder.Options.FindExtension<ProxiesOptionsExtension>()
            ?? new ProxiesOptionsExtension();

            extension = extension.WithLazyLoading(true);

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        }
        private static void CheckForNullValues(ModelBuilder modelBuilder)
        {
            //broken
            //var client = Main.ObjectContainer.Resolve<Cosmos>();
            //
            // This function will print all types that are Not-Nullable,
            // then you must see in the database if any Not-Nullable is null
            // if it's null or doesn't exist, then the property must be set as nullable
            //
            foreach (var ent in modelBuilder.Model.GetEntityTypes())
            {
                Log.Info("\n\n" + ent.Name);
                foreach (var property in ent.ClrType.Properties())
                {
                    
                    if( property.GetSetMethod() !=null && property.GetCustomAttribute<NotMappedAttribute>() == null)
                    {
                        var type = property.PropertyType;
                        var originalType = Nullable.GetUnderlyingType(type);
                        if (originalType==null &&(type.IsPrimitive || !typeof(IEnumerable).IsAssignableFrom(type)))
                        {
                            Log.Info(type == typeof(Nullable<>) ? $"Nullable: {property.Name}" : $"Not-Nullable: {property.Name} Type: {type} ");
                        }
                    }
                }
                
            }
        }
        private static void CheckForJTokens(ModelBuilder modelBuilder)
        {
            foreach (var ent in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in ent.ClrType.GetRuntimeProperties())
                {
                    var type = property.PropertyType.Name;

                    if (type != null && property.GetCustomAttribute<NotMappedAttribute>() == null)
                    {
                        if (type == typeof(JToken).Name || type == typeof(JArray).Name
                          || type == typeof(JObject).Name || type == typeof(JValue).Name
                          || type == typeof(JProperty).Name
                            )
                        {
                            throw new Exception($"JTokens not compatible: Type: {ent.Name} has member {property.Name} with JToken type, please add [NotMapped] Attribute to it");
                        }
                    }

                }
            }
        }
    }

    public static class ContextExtension
    {
        public static EntityTypeBuilder<TEntity> IgnoreOtherRisks<TEntity>( this EntityTypeBuilder<TEntity> builder) where TEntity : class
        {
            var risks = new List<Type> {
                typeof(VehicleRisk),
                typeof(DriverRisk),
                typeof(BuildingRisk),
                typeof(LocationRisk)
            };

            foreach (var r in risks)
            {
                if( builder.Metadata.ClrType.Name != r.Name)
                {
                    var propName = r.Name.Substring(0, "Risk".Length);
                    Log.Debug("Ignoring: " + propName);
                    builder.Ignore(propName);
                }
            }
            return builder;
        }
    }





}

