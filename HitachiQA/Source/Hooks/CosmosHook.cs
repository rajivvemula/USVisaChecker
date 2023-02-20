﻿using BoDi;
using HitachiQA.Helpers;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace HitachiQA.Hooks
{
    [Binding]
    public class CosmosHook : HookBase
    {

        public CosmosHook(IObjectContainer oc, FeatureContext fc, IConfiguration config) : base(oc, fc, config)
        {

        }

        [BeforeFeature]
        public static void initialize(IObjectContainer ObjectContainer, IConfiguration Configuration)
        {
            Console.WriteLine("Attempting to load Cosmos Client");
            var CosmosUri = Configuration.GetVariable("COSMOS_URI", true);
            if(Main.IsValid(CosmosUri))
            {
                CosmosUri.NullGuard();
                var client = new Cosmos(CosmosUri, Configuration.GetVariable("COSMOS_API_KEY"), Configuration.GetVariable("COSMOS_DATABASE_NAME"));
                ObjectContainer.RegisterInstanceAs<Cosmos>(client);
                Console.WriteLine("Loaded Cosmos Client");

            }else{ Console.WriteLine("No Cosmos Client Loaded"); }

        }

        [AfterFeature]
        public static void tearDown(IObjectContainer ObjectContainer, IConfiguration Configuration)
        {
            if(ObjectContainer.IsRegistered<Cosmos>())
            {
                ObjectContainer.Resolve<Cosmos>().Dispose();
            }
            
        }

    }
}
