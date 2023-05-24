using BoDi;
using DocumentFormat.OpenXml.Bibliography;
using HitachiQA.Helpers;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace HitachiQA.Hooks
{
    [Binding]
    public class SQLHook : HookBase
    {

        public SQLHook(IObjectContainer oc, FeatureContext fc, IConfiguration config) : base(oc, fc, config)
        {

        }

        [BeforeFeature]
        public static void initialize(IObjectContainer oc)
        {
            var config = oc.Resolve<IConfiguration>();
            Console.WriteLine("Attempting to load SQL Client");
            var connectionString = config.GetVariable("SQL_CONNECTION_STRING", true);
            if(connectionString != null)
            {
                var client = new SQL(connectionString);
                oc.RegisterInstanceAs<SQL>(client);
                Console.WriteLine("Loaded SQL Client");
            }
            else
            {
                Console.WriteLine("No SQL Client Loaded");
            }

        }

    }
}
