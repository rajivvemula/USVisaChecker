using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApolloQA.Helpers
{
    public class Cosmos
    {
        CosmosClient client;
        Database database;
        Container container;

        public Cosmos(CosmosClient cosmosClient)
        {
            client = cosmosClient;
        }
        public async Task<bool> GetQuery(string containerA, string queryA)
        {
            database = client.GetDatabase("apollo");
            bool returnValue = false;
            container = database.GetContainer(containerA);
            using (FeedIterator<dynamic> feedIterator = container.GetItemQueryIterator<dynamic>(queryA))
            {
                while (feedIterator.HasMoreResults)
                {
                    FeedResponse<dynamic> response = await feedIterator.ReadNextAsync();
                    foreach (var item in response)
                    {
                        //simple check for right now
                        Console.WriteLine(item);
                        returnValue = true;
                        
                    }
                }
            }
            return returnValue;

        }

        public async Task<int> GetLatestPolicyID()
        {
            database = client.GetDatabase("apollo");
            string queryA = "SELECT * FROM c ORDER BY c._ts DESC OFFSET 0 LIMIT 1";
            container = database.GetContainer("Policy");
            int policyID = 1;
            using (FeedIterator<dynamic> feedIterator = container.GetItemQueryIterator<dynamic>(queryA))
            {
                while (feedIterator.HasMoreResults)
                {
                    FeedResponse<dynamic> response = await feedIterator.ReadNextAsync();
                    foreach (var item in response)
                    {
                        //simple check for right now
                        Console.WriteLine(item);
                        policyID = item.Id;
                        

                    }
                }
            }
            return policyID;
        }
    }
}
