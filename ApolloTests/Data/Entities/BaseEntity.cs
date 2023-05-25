using ApolloTests.Data.Entities.Context;
using ApolloTests.Data.EntityBuilder;
using Castle.DynamicProxy;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities
{
    public abstract class BaseEntity
    {
        [NotMapped]
        [JsonIgnore]
        public IObjectContainer ObjectContainer;

        [NotMapped]
        [JsonIgnore]
        public SQL SQL;

        [NotMapped]
        [JsonIgnore]
        public Cosmos Cosmos;

        [NotMapped]
        [JsonIgnore]
        public RestAPI RestAPI;

        [NotMapped]
        [JsonIgnore]
        public Functions Functions;

        [NotMapped]
        [JsonIgnore]
        public ServiceBus ServiceBus;

        public SQLContext GetContextSQL() => ObjectContainer.Resolve<SQLContext>();
        public CosmosContext GetContextCosmos() => ObjectContainer.Resolve<CosmosContext>();

        //
        // This properties must stay intact in order for EF to provide the Context (No setter)
        //
        [JsonIgnore]
        public CosmosContext ContextCosmos { get; }
        [JsonIgnore]
        public SQLContext ContextSQL { get; }

        [JsonIgnore]
        public ApolloContext Context { get; }

        public BaseEntity(CosmosContext context):this()
        {
            Context = context;
            ContextCosmos = context.CosmosContext;
            ContextSQL = context.SQLContext;
            LoadOC(context.ObjectContainer);
        }
        public BaseEntity(SQLContext context):this()
        {
            Context = context;
            ContextCosmos = context.CosmosContext;
            ContextSQL = context.SQLContext;
            LoadOC(context.ObjectContainer);

        }
        public BaseEntity(QuoteBuilder builder) : this(builder.SQLContext) { }

        public BaseEntity(IObjectContainer OC)
        {
            LoadOC(OC);
        }
        public void LoadOC(IObjectContainer OC)
        {
            ObjectContainer = OC;
            SQL = OC.Resolve<SQL>();
            Cosmos = OC.Resolve<Cosmos>();
            RestAPI = OC.Resolve<RestAPI>();
            ServiceBus = OC.Resolve<ServiceBus>();
            Functions = OC.Resolve<Functions>();

        }


        public BaseEntity()
        {

        }


        public void RunRatableObjectManagementFunction(string path)
        {
            var url = Main.Configuration.GetVariable("RATABLEOBJECTMANAGEMENTFUNCTION_URL");
            url = Path.Combine(url, path);
            RestAPI.POST(url, null);
        }


        public T? GetPropertyValue<T>(string propertyName)
        {
            var prop = this.GetType().GetProperty(propertyName);
            if (prop == null)
            {
                throw new Exception($"Property {propertyName} was not found on {this.GetType().FullName}");
            }
            var getMethod = prop.GetGetMethod();
            getMethod.NullGuard($"Property {propertyName} has no getter method in {this.GetType().FullName}");
            return (T?)getMethod?.Invoke(this, null);
        }
        public void WaitForProperty(string propName, object? value, bool waitForValueNotEqual)
        {
            string typeName;
            if (this is IProxyTargetAccessor)
            {
                typeName = (this as IProxyTargetAccessor).DynProxyGetTarget().GetType().BaseType.FullName ?? throw new NullReferenceException();
            }
            else
                typeName = this.GetType().FullName;

            var sw = Stopwatch.StartNew();

            var wait = Polly.Policy.HandleResult<bool>(false)
                .WaitAndRetry(30, _ => TimeSpan.FromSeconds(1));
            object? result = null;
            var success = wait.Execute(() =>
            {
                result = this.GetPropertyValue<object>(propName);

                if (waitForValueNotEqual)
                {
                    if(value==null)
                    {
                        return result != null;
                    }
                    return !result.Equals(value);
                }
                else
                {
                    if (value == null)
                    {
                        return result == null;
                    }
                    return result.Equals(value);
                }

            });
            sw.Stop();
            Log.Debug($"seconds until {propName} {(waitForValueNotEqual ? "was not" : "was")} {value} value: {sw.Elapsed.TotalSeconds}");

            if (!success)
                throw new TimeoutException($"Timeout waiting for {typeName}.{propName} {(waitForValueNotEqual ? "to be out of" : "to be")} {value} current value: {result}");


        }



    }
}
