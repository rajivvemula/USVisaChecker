using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloQA.Source.Helpers
{
    public class Cosmos
    {
        
        public static CosmosClient client = new CosmosClient(Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("COSMOS_TARGETURL_SECRETNAME")), 
                                                             Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("COSMOS_APIKEY_SECRETNAME")));


        public static IEnumerable<dynamic> GetQuery(string containerA, string queryA)
        {
            var database = client.GetDatabase("apollo");
            var container = database.GetContainer(containerA);
            List<dynamic> result = new List<dynamic>();
            using (FeedIterator<dynamic> feedIterator = container.GetItemQueryIterator<dynamic>(queryA))
            {
                while (feedIterator.HasMoreResults)
                {
                    FeedResponse<dynamic> response = feedIterator.ReadNextAsync().Result;

                    foreach (var item in response)
                    {
                        yield return item;

                    }
                }
            }


        }

        public static void setProperty(string containerA, string identifierQuery,  string key, dynamic value)
        {
            var database = client.GetDatabase("apollo");
            var container = database.GetContainer(containerA);


            Log.Debug(containerA);

            List<dynamic> recordsToUpdate = GetQuery(containerA, identifierQuery).ToList();

            foreach(var record in recordsToUpdate)
            {
               record[key] = value;
                _ = container.ReplaceItemAsync(record, (string)record.id).Result;

            }



        }





    }
}
