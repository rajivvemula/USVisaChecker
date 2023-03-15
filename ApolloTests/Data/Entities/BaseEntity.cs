using BoDi;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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






    }
}
