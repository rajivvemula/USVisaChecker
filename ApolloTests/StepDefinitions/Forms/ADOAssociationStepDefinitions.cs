using HitachiQA.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;
using System.Linq;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using NUnit.Framework;
using ApolloTests.Data.Forms;

namespace ApolloTests.StepDefinitions.Forms
{
    [Binding]
    public class ADOAssociationStepDefinitions
    {
        private RestAPI RestAPI;
        private SQL SQL;
        private IConfiguration Configuration;
        public ADOAssociationStepDefinitions(RestAPI restAPI, IConfiguration config, SQL SQL)
        {
            this.RestAPI = restAPI;
            this.SQL = SQL;
            this.Configuration = config;
        }
        List<string>TestFunctionNames=new List<string>();
        JArray ADOQueriedworkitems= new JArray();
        [Given(@"Current Test Function Names are loaded")]
        public void GivenCurrentTestFunctionNamesAreLoaded()
        {
            Type? type = Assembly.GetExecutingAssembly().GetType("ApolloTests.Features.Forms.CommercialAutoLOBFeature");
            type.NullGuard();

            MethodInfo[] methods;
            
            methods= type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            
            //Log.Info(methods.Select(x => x.Name));
            var filterednames = methods.Where(x => x.Name.StartsWith("FormCanBeGeneratedLineId_7_"));
            TestFunctionNames.AddRange( filterednames.Select(x => $"ApolloTests.Features.Forms.CommercialAutoLOBFeature.{x.Name}"));

            var formCodes = TestFunctionNames.Select(x => Regex.Match(x, @"(?<=_)[^_]+$").Value);

            if (formCodes.Distinct().Count() != formCodes.Count())
            {
                var dups = formCodes.ToList();
                foreach (var code in formCodes.Distinct())
                {
                    dups.Remove(code);
                }
                throw new Exception($"these are duplicated in the results: {Log.stringify(dups)}");
            }
        }

        [Given(@"Related Test Cases ID are loaded")]
        public void GivenRelatedTestCasesIDAreLoaded()
        {
            //Log.Info(TestFunctionNames);
            var url = "https://dev.azure.com/biberk/biberk/_apis/wit/wiql/025c51ec-15c2-4607-89e5-f36a0a5aac38?api-version=7.0&$expand=all";
            var headers = new Dictionary<string, string>()
            {
                { "Authorization", "Basic Omx0d2hybm9zN2t6aTI1cXF4YTZrNnliam5ma3JtZHRucHJzanp5bXZjY2ttaHU3YnN0bnE=" }
            };
            var auth = new AuthenticationHeaderValue("Basic", "Omx0d2hybm9zN2t6aTI1cXF4YTZrNnliam5ma3JtZHRucHJzanp5bXZjY2ttaHU3YnN0bnE=");
            var QueryResult = RestAPI.GET(url,null,headers);
            if(QueryResult==null)
            {
                throw new Exception();
            }
            //Log.Info(QueryResult);
            var ids = ((JArray)QueryResult["workItems"]).Select(x => x.Value<int>("id"));
            

            var getworkitemurl = "https://dev.azure.com/biberk/biberk/_apis/wit/workitemsbatch?api-version=7.0";
            

            foreach (var batch in ids.Chunk(199))
            {
                var myObject = new
                {
                    ids = batch,
                    fields = new string[] {
                    "System.Id",
                    "System.Title",
                    "System.WorkItemType",
                    "Microsoft.VSTS.Scheduling.RemainingWork"
                    }
                };
                var response = RestAPI.POST(getworkitemurl, myObject, auth);
                if (response == null)
                {
                    throw new Exception();
                }
                ADOQueriedworkitems.Merge(response["value"]);

            }
            var resultIds = ADOQueriedworkitems.Select(it => it["fields"]?.Value<int>("System.Id"));
            var resultTitles = ADOQueriedworkitems.Select(it => it["fields"]?.Value<string>("System.Title"));

            if (resultIds.Distinct().Count() != ids.Count())
            {
                var dups = ids.ToList();
                foreach (var id in resultIds.Distinct())
                {
                    dups.Remove(id?? throw new NullReferenceException());
                }
                Log.Error($"unique result: {resultIds.Distinct().Count()}; query result: {ids.Count()}; duplicate count: {dups.Count}");
                Log.Error(dups);
                throw new Exception($"there are duplicates coming from ADO");
            }
            if (resultTitles.Distinct().Count() != ids.Count())
            {
                var dups = resultTitles.ToList();
                foreach (var title in resultTitles.Distinct())
                {
                    dups.Remove(title);
                }
                Log.Error($"unique result: {resultTitles.Distinct().Count()}; query result: {ids.Count()}; duplicate count: {dups.Count}");
                Log.Error(dups);
                throw new Exception($"there are duplicates coming from ADO");
            }
            //Log.Info(ADOQueriedworkitems);





        }

        [Then(@"Test Cases are associated to ADO")]
        public void ThenTestCasesAreAssociatedToADO()
        {
            var bulkupdatebody = new JArray();
            var associations = new Dictionary<string, string>();

            Log.Info($"workitem count {ADOQueriedworkitems.Count}");
            Log.Info($"Function Names Count{TestFunctionNames.Count}");
            foreach (var form in this.TestFunctionNames)
            {
                
                var formCode = Regex.Match(form, @"(?<=_)[^_]+$").Value;
                var workitem = ADOQueriedworkitems.FirstOrDefault(x => 
                                        (x["fields"]?.Value<string>("System.Title")??throw new NullReferenceException())
                                        .ToLower()
                                        .Replace("(","")
                                        .Replace(")", "")
                                        .Contains(formCode.ToLower())
                                    );
                if (workitem == null)
                {
                    throw new Exception($"No work item found for form {formCode}");
                }
                var workItemId = (workitem["id"]?.ToString() ?? throw new NullReferenceException());
                if(associations.ContainsKey(workItemId))
                {
                    throw new Exception($"Work item {workItemId} has already been associated with {formCode} @ {form}");
                }
                var updateObj = new
                {
                    method = "PATCH",
                    uri = $"/_apis/wit/workitems/{workItemId}?api-version=7.0",
                    headers = new Dictionary<string, string>
                    {
                        ["Content-Type"] = "application/json-patch+json"
                    },
                    body = new[]
                    {
                    new            {
                        path = "/fields/Microsoft.VSTS.TCM.AutomatedTestName",
                        op = "add",
                        Value = form
                    },
                    new            {
                        path = "/fields/Microsoft.VSTS.TCM.AutomatedTestStorage",
                        op = "add",
                        Value = "ApolloTests.dll"            },
                    new            {
                        path = "/fields/Microsoft.VSTS.TCM.AutomatedTestId",
                        op = "add",
                        Value = Guid.NewGuid().ToString()           },
                    new            {
                        path = "/fields/Microsoft.VSTS.TCM.AutomationStatus",
                        op = "add",
                        Value = "Automated"            }
                }
                };
                bulkupdatebody.Add(JToken.FromObject(updateObj));
                associations.Add(workItemId, form);               
            }

            var bulkupdateurl = "https://dev.azure.com/biberk/_apis/wit/$batch?api-version=7.0";
            var auth = new AuthenticationHeaderValue("Basic", "Omx0d2hybm9zN2t6aTI1cXF4YTZrNnliam5ma3JtZHRucHJzanp5bXZjY2ttaHU3YnN0bnE=");
            var bulkUpdatesRes = new JArray();

            foreach(var batch in bulkupdatebody.Chunk(199)) {

                var res = (JObject?)RestAPI.PATCH(bulkupdateurl, batch, auth);
                res.NullGuard();
                bulkUpdatesRes.Merge(res["value"]?? throw new NullReferenceException());
            }

            Log.Info(bulkUpdatesRes);
        }
    }
    
}


