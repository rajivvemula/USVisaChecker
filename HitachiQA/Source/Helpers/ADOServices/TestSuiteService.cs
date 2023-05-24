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
    public class TestSuiteService
    {
        private Devops Devops { get; }
        private string Org { get; }
        private string Proj { get; } 
        public TestSuiteService(Devops devops)
        {
            Devops= devops;

            //replace to come from config
            Org = "Biberk";
            Proj= "Biberk";
        }

        public JObject CreateTestSuite(TestSuite suite, int planId, int parentSuiteId)
        {
            var msg = new HttpRequestMessage(HttpMethod.Post, $"{Org}/{Proj}/_apis/test/Plans/{planId}/suites/{parentSuiteId}?api-version=5.0");

            if (suite.SuiteType == SuiteTypes.DynamicTestSuite)
            {
                suite.QueryString = this.GetQueryString(suite);
            }

            var res = Devops.Send(msg, suite);
            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                var testSuite = JObject.Parse(jsonStr)["value"][0];
                suite.Id = testSuite.Value<int>("id");
                return (JObject)testSuite;
            }
            catch(Exception ex) {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }


        }

        public void UpdateTestSuite(JToken suiteObj, int planId)
        {
            var msg = new HttpRequestMessage(HttpMethod.Patch, $"{Org}/{Proj}/_apis/test/Plans/{planId}/suites/{suiteObj.Value<int>("id")}?api-version=5.0");
            var res = Devops.Send(msg, suiteObj);
            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                var resObj = JObject.Parse(jsonStr);

            }
            catch (Exception ex)
            {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }
        }

        public void AddConfigurationToTestSuite(JToken config, JToken suite)
        {
            var msg = new HttpRequestMessage(HttpMethod.Post, $"{Org}/{Proj}/_api/_testManagement/AssignConfigurationsToSuite?__v=5");
            var body = new
            {
                configurations = new[] { config.Value<int>("id") },
                suiteId = suite.Value<int>("id")
            };
            var res = Devops.Send(msg, JToken.FromObject(body));
            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                var resObj = JObject.Parse(jsonStr);

            }
            catch (Exception ex)
            {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }

        }
        public void UpsertTestSuite(TestSuite suite, int planId, int parentSuiteId)
        {
            var planSuites = GetAllSuitesInPlan(planId).Value<JArray>("value");

            var suiteObj = planSuites.FirstOrDefault(it => it.Value<string>("name") == suite.Name && it["parent"].Value<int>("id") == parentSuiteId);

            if(suiteObj == null) {
                suiteObj = this.CreateTestSuite(suite, planId, parentSuiteId);
            }
            else
            {
                suite.HydrateFrom(suiteObj);
                if (suite.QueryTags?.Any() ?? false)
                {
                    var isQueryIdentical = GetQueryString(suite) == suiteObj.Value<string>("queryString");
                    if (!isQueryIdentical)
                    {
                        Log.Info(GetQueryString(suite));
                        Log.Info(suiteObj.Value<string>("queryString"));
                        Log.Info(GetQueryString(suite) == suiteObj.Value<string>("queryString"));
                        suiteObj["queryString"] = GetQueryString(suite);
                        UpdateTestSuite(suiteObj, planId);

                    }
                }

               
            }

            if (suite.Configuration != null)
            {
                var configurations = GetAllConfigurations().Value<JArray>("value");
                var configObj = (JObject)configurations.FirstOrDefault(it => it.Value<string>("name") == suite.Configuration);
                var inheritDefaultConfig = suiteObj.Value<bool?>("inheritDefaultConfigurations")??true;
                if (inheritDefaultConfig == true ||  !suiteObj["defaultConfigurations"].Any(it=> it.Value<int>("id")==configObj.Value<int>("id")))
                {
                    AddConfigurationToTestSuite(configObj, suiteObj);
                }
            }

        }

        public void CreateTestPlan(TestPlanStructure structure, int planId, int parentSuiteId)
        {

            foreach(JObject suite in GetAllSuitesInPlan(planId)["value"])
            {
                var id = suite.Value<int>("id");
                if (id!=planId && id!=parentSuiteId && suite["parent"].Value<int>("id")==parentSuiteId)
                {
                    this.DeleteSuite(planId, id );

                }
            }
            foreach(var envName in structure.Environments)
            {
                var envSuite = new TestSuite() { Name = envName, SuiteType= SuiteTypes.StaticTestSuite };
                CreateTestSuite(envSuite, planId, parentSuiteId);

                foreach (var suite in structure.Suites)
                {
                    if (suite.Path?.Any() ?? false)
                    {
                        foreach (var parentName in suite.Path)
                        {
                            var parentId = structure.Suites.Find(it => it.Name == parentName).Id;
                            CreateTestSuite(suite, planId, parentId ?? throw new NullReferenceException());
                        }
                    }
                    else
                    {
                        CreateTestSuite(suite, planId, envSuite.Id?? throw new NullReferenceException());
                    }
                }
            }
            
        }
        public void UpsertTestPlan(TestPlanStructure structure, int planId, int rootSuiteId)
        {
            var existingSuites = GetAllSuitesInPlan(planId).Value<JArray>("value");
            var envSuites = new List<TestSuite>();
            foreach (var envName in structure.Environments)
            {
                TestSuite envSuite = new TestSuite(); ;
                var envSuiteObj = existingSuites.Value<JArray>().FirstOrDefault(it => it.Value<string>("name") == envName);
                if (envSuiteObj == null)
                {
                    envSuite.Name = envName;
                    envSuite.SuiteType = SuiteTypes.StaticTestSuite;
                    CreateTestSuite(envSuite, planId, rootSuiteId);
                }
                else
                {
                    envSuite.HydrateFrom(envSuiteObj);
                }

                UpsertTestSuite(envSuite, planId, rootSuiteId);
                envSuites.Add(envSuite);
            }
            Parallel.ForEach(envSuites, envSuite =>
            {
                var suites = structure.Suites.ToJArray().DeepClone().ToObject<List<TestSuite>>();
                foreach (var suite in suites)
                {

                    if (suite.Path?.Any() ?? false)
                    {
                        var parentId = suites.Find(it => it.Name == suite.Path.Last()).Id;
                        UpsertTestSuite(suite, planId, parentId ?? throw new NullReferenceException());
                    }
                    else
                    {
                        UpsertTestSuite(suite, planId, envSuite.Id ?? throw new NullReferenceException());
                    }
                }
            });

        }
        public JObject GetAllSuitesInPlan(int planId)
        {
            var msg = new HttpRequestMessage(HttpMethod.Get, $"{Org}/{Proj}/_apis/test/Plans/{planId}/suites?api-version=5.0");
            var  res = Devops.Send(msg);
            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                return JObject.Parse(jsonStr);
            }
            catch (Exception ex)

            {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }
        }

        public JObject GetAllConfigurations() {
            var msg = new HttpRequestMessage(HttpMethod.Get, $"{Org}/{Proj}/_apis/test/configurations?api-version=5.0-preview.2");
            var res = Devops.Send(msg);

            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                return JObject.Parse(jsonStr);
            }
            catch (Exception ex)

            {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }
        }

        public void DeleteSuite(int planId, int suiteId)
        {
            var msg = new HttpRequestMessage(HttpMethod.Delete, $"{Org}/{Proj}/_apis/test/Plans/{planId}/suites/{suiteId}?api-version=5.0");

            Devops.Send(msg);

        }

        private string GetQueryString(TestSuite suite)
        {
            suite.QueryTags.NullGuard("Query tags must be provided to query dynamic test suite");
            if (!suite.QueryTags.Any()) { throw new Exception("Query tags must be provided to query dynamic test suite"); }

            return $"select [System.Id], [System.WorkItemType], [System.Title], [Microsoft.VSTS.Common.Priority], [System.AssignedTo], [System.AreaPath] from WorkItems where [System.TeamProject] = @project and [System.WorkItemType] in group 'Microsoft.TestCaseCategory' {(suite.QueryTags != null ? string.Join(" ", suite.QueryTags.Select(tag => $"and [System.Tags] contains '{tag}'")) : string.Empty)} and not [System.State] in ('Closed')";
        }

    }
}
