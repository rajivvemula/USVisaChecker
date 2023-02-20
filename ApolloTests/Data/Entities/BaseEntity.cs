using BoDi;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities
{
    public class BaseEntity
    {
        protected SQL SQL;
        protected Cosmos Cosmos;
        protected RestAPI RestAPI;
        protected Functions Functions;
        protected ServiceBus ServiceBus;
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





    }
}
