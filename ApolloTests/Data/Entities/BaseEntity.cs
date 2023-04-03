using BoDi;
using Castle.Components.DictionaryAdapter.Xml;
using Castle.DynamicProxy;
using HitachiQA.Helpers;
using Polly;
using System.Diagnostics;

namespace ApolloTests.Data.Entities
{
    public class BaseEntity 
    {



        public SQL SQL;
        public Cosmos Cosmos;
        public RestAPI RestAPI;
        public Functions Functions;
        public ServiceBus ServiceBus;
        public BaseEntity()
        {
            SQL=GetSQLService();
            Cosmos=GetCosmosService();  
            RestAPI=GetRestAPIService();
            ServiceBus=GetServiceBusService();
            Functions = Main.ObjectContainer.Resolve<Functions>();
        }
        public static SQL GetSQLService()
        {
            return Main.ObjectContainer.Resolve<SQL>();
            
        }
        public static Cosmos GetCosmosService()
        {
            return Main.ObjectContainer.Resolve<Cosmos>(); 
        }
            
        public static RestAPI GetRestAPIService()
        {
            return Main.ObjectContainer.Resolve<RestAPI>();
        }
        public static ServiceBus GetServiceBusService()
        {
            return Main.ObjectContainer.Resolve<ServiceBus>();
        }

        public static void RunRatableObjectManagementFunction(string path)
        {
            var client = GetRestAPIService();
            var url = Main.Configuration.GetVariable("RATABLEOBJECTMANAGEMENTFUNCTION_URL");
            url = Path.Combine(url, path);
            client.POST(url, null);
        }


        public T? GetPropertyValue<T>(string propertyName)
        {
            var prop = this.GetType().GetProperty(propertyName);
            if(prop==null)
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
                typeName = (this as IProxyTargetAccessor).DynProxyGetTarget().GetType().BaseType.FullName?? throw new NullReferenceException();
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
                    return result != value;
                }
                else
                {
                    return result == value;
                }

            });
            sw.Stop();
            Log.Debug($"seconds until {propName} {(waitForValueNotEqual ? "was not" : "was")} {value} value: {sw.Elapsed.TotalSeconds}");

            if (!success)
                throw new TimeoutException($"Timeout waiting for {typeName}.{propName} {(waitForValueNotEqual ? "to be out of" : "to be")} {value} current value: {result}");


        }



    }
}
