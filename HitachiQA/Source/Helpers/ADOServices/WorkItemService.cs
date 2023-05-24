using DocumentFormat.OpenXml.Presentation;
using HitachiQA.Helpers;
using HitachiQA.Source.Helpers.ADOServices.Models;
using Microsoft.Azure.Cosmos.Linq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HitachiQA.Source.Helpers.ADOServices
{
    public class WorkItemService
    {
        private Devops Devops { get; }
        private string Org { get; }
        private string Proj { get; } 
        public WorkItemService(Devops devops)
        {
            Devops= devops;

            //replace to come from config
            Org = "Biberk";
            Proj= "Biberk";
        }

        public void UpsertTestCases(List<TestCase> testCases)
        {
            testCases.ForEach(tc => tc.Tags.Add($"FT_{tc.FeatureTitle}"));
            var groupedTestCases = testCases.GroupBy(tc => tc.FeatureTitle).ToList();
            var fields = testCases[0].AddNewOperations.Select(it => it.Path.Split('/').Last());
            foreach (var featureGroup in groupedTestCases)
            {
                var featureTitle = featureGroup.Key;
                var testCasesList = featureGroup.ToList();
                var testCasesTobeUpdated = new List<TestCase>();

                if (testCasesList.Select(it => string.Join("; ", it.Tags)).Distinct().Count()!=1)
                {
                    throw new Exception($"there were multiple tag groups within the same feature group {testCasesList.Select(it => string.Join("; ", it.Tags))}");
                }

                var res = Query(testCasesList[0].Tags);
                var workItemIds = res["workItems"].Select(it => it.Value<int>("id")).ToList();
                var workItems = new JArray();
                var batchSize = 200;
                var totalItems = workItemIds.Count;
                for (int i = 0; i < totalItems; i += batchSize)
                {
                    var batch = workItemIds.Skip(i).Take(batchSize).ToList();
                    // Process the current batch of work item IDs
                    var batchBody = new JObject(
                        new JProperty("ids", batch.ToJArray()),
                        new JProperty("fields", fields.ToJArray())
                    );
                    var workItemsBatch = GetBatchWorkItems(batchBody);

                    foreach(var workItem in workItemsBatch)
                    {
                        var name = workItem["fields"].Value<string>("System.Title");
                        var testName = workItem["fields"].Value<string>("Microsoft.VSTS.TCM.AutomatedTestName");

                        var existingTC =testCasesList.First(it=> it.Name== name || it.MethodFullName ==testName);
                        existingTC.WorkItem = (JObject)workItem;
                        if(existingTC.CheckIfFieldsMatchWorkItem(workItem))
                        {
                            testCasesTobeUpdated.Add(existingTC);
                        }
                       
                    }   

                    workItems.Merge(workItemsBatch);
                    
                }
               

                Log.Info($"{featureTitle} => {testCasesList[0]}");
                Log.Info(testCasesTobeUpdated);
                Log.Info(testCasesList.Where(it => it.WorkItem == null).Count());

                foreach(var tc in testCasesTobeUpdated)
                {
                    UpdateTestCase(tc);
                }
                foreach (var tc in testCasesList.Where(it=>it.WorkItem==null))
                {

                    CreateTestCase(tc);
                }
            }
        }

        public void CreateTestCase(TestCase testCase)
        {
            var msg = new HttpRequestMessage(HttpMethod.Post, $"/{Org}/{Proj}/_apis/wit/workitems/$Test%20Case?validateOnly=false&api-version=7.0");

            var res = Devops.Send(msg, testCase.AddNewOperations, true);
            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                testCase.WorkItem = JObject.Parse(jsonStr);

            }
            catch (Exception ex)
            {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }

        }
        public void UpdateTestCase(TestCase testCase)
        {
            var msg = new HttpRequestMessage(HttpMethod.Patch, $"/{Org}/{Proj}/_apis/wit/workitems/{testCase.WorkItem.Value<int>("id")}?api-version=7.0");

            var res = Devops.Send(msg, testCase.AddNewOperations, true);
            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                testCase.WorkItem = JObject.Parse(jsonStr);
            }
            catch (Exception ex)
            {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }

        }

        public JArray GetBatchWorkItems(JObject body)
        {
            var msg = new HttpRequestMessage(HttpMethod.Post, $"/{Org}/{Proj}/_apis/wit/workitemsbatch?api-version=7.0");
            var res = Devops.Send(msg, body);
            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                var resObj = JObject.Parse(jsonStr);
                return (JArray)resObj["value"];
            }
            catch (Exception ex)
            {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }
        }

        public JObject Query(List<string> tags)
        {
            var msg = new HttpRequestMessage(HttpMethod.Post, $"/{Org}/{Proj}/_apis/wit/wiql?api-version=7.0");
            var body = new
            {
                query=GetQueryString(tags)
            };
            var res = Devops.Send(msg, body);
            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                var resObj = JObject.Parse(jsonStr);
                return resObj;
            }
            catch (Exception ex)
            {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }
        }

        private string GetQueryString(List<string> tags)
        {
            tags.NullGuard("Query tags must be provided to query dynamic test suite");
            if (!tags.Any()) { throw new Exception("Query tags must be provided to query dynamic test suite"); }

            return $"select [System.Id], [System.WorkItemType], [System.Title], [Microsoft.VSTS.Common.Priority], [System.AssignedTo], [System.AreaPath] from WorkItems where [System.TeamProject] = @project and [System.WorkItemType] in group 'Microsoft.TestCaseCategory' {string.Join(" ", tags.Select(tag => $"and [System.Tags] contains '{tag}'"))} and not [System.State] in ('Closed')";
        }

    }
}
