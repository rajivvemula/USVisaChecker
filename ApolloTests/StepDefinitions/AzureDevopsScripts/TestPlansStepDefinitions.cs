using DocumentFormat.OpenXml.Wordprocessing;
using HitachiQA.Helpers;
using HitachiQA.Source.Helpers.ADOServices;
using HitachiQA.Source.Helpers.ADOServices.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace ApolloTests.StepDefinitions.AzureDevopsScripts
{
    [Binding]
    public class TestPlansStepDefinitions
    {
        private RestAPI RestAPI;
        private SQL SQL;
        private IConfiguration Configuration;
        private TestSuiteService TestSuiteSvc { get; }
        private WorkItemService WorkItemSvc { get; }
        private TestPlanStructure TestPlan { get; set; }
        private List<string> TestFunctionNames = new List<string>();

        private List<TestCase> TestCases = new List<TestCase>();
        

        public TestPlansStepDefinitions(RestAPI restAPI, IConfiguration config, SQL SQL, TestSuiteService testSuiteService, WorkItemService workItemSvc)
        {
            this.RestAPI = restAPI;
            this.SQL = SQL;
            this.Configuration = config;
            this.TestSuiteSvc= testSuiteService;
            this.WorkItemSvc = workItemSvc;
        }

        [Given(@"enforce desired folder structure in test plan '([^']*)' and parent suite '([^']*)'")]
        public void GivenEnforceDesiredFolderStructureInTestPlanAndParentSuite(int planId, int parentSuiteId)
        {
            TestPlan = JsonConvert.DeserializeObject<TestPlanStructure>(new StreamReader(@"StepDefinitions/AzureDevopsScripts/TestPlanSuiteStructure.json").ReadToEnd()) ?? throw new NullReferenceException();
            TestSuiteSvc.UpsertTestPlan(TestPlan, planId, parentSuiteId);
        }
        [Given(@"Test Cases are gathered from current solution")]
        public void GivenTestCasesAreUpsertedIntoADO()
        {
            var TestTypePrefix = new List<string>() {
                "ApolloTests.Features.Forms",
                "ApolloTests.Features.Rating"
            };
            var identifierAttributes = new List<List<string>>()
            {
                new List<string>{ "ratingTests", "CA" },
                new List<string>{ "formsTests", "CA" }
            };
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(it=> TestTypePrefix.Any(prefix=> it.FullName.StartsWith(prefix))).ToList();

            if(types.Any()==false)
            {
                throw new Exception("Types were empty");
            }

            MethodInfo[] methods;

            foreach (var type in types)
            {
                methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                //Log.Info(methods.Select(it=>it.Name));

                var filteredMethods = methods.Where(method =>
                {
                    var customAttributes = method.GetCustomAttributes<TestCategoryAttribute>().ToList();
                    return identifierAttributes.Any(innerList =>
                        innerList.All(attribute =>
                            customAttributes.Any(att => att.TestCategories.Contains(attribute))
                        )
                    );
                }).ToList();

                foreach (var method in filteredMethods)
                {
                    var name = method.GetCustomAttribute<DescriptionAttribute>().Description;
                    var methodName = type.FullName + "." + method.Name;
                    var tags = method.GetCustomAttributes<TestCategoryAttribute>()
                                        .SelectMany(att => att.TestCategories)
                                        .Where(tag => identifierAttributes.Any(innerList => innerList.Contains(tag)))
                                        .ToList();
                    var featureTitle = method.GetCustomAttributes<TestPropertyAttribute>().First(it => it.Name == "FeatureTitle").Value;

                    if (tags.Contains("formsTests"))
                    {
                        var formName = method.GetCustomAttributes<TestPropertyAttribute>().First(it => it.Name == "Parameter:name").Value;
                        var formCode = method.GetCustomAttributes<TestPropertyAttribute>().First(it => it.Name == "Parameter:code").Value;
                        name = $"Form - {formCode} - {formName}";
                    }
                    if (tags.Contains("ratingTests"))
                    {
                        var algorithm = method.GetCustomAttributes<TestPropertyAttribute>().First(it => it.Name == "Parameter:Algorithm or Coverage").Value;
                        if(name.Contains("Variant"))
                        {
                            name = $"{name[..name.IndexOf("Variant")]}{algorithm}";

                        }
                    }

                    TestCases.Add(new TestCase() { Name = name, MethodFullName = methodName, Tags = tags, FeatureTitle=featureTitle });

                }
                
            }
            //Log.Info(TestCases.Select(it=>it.ToString()));

        }

        [Then(@"Test Cases are upserted into ADO")]
        public void ThenTestCasesAreUpsertedIntoADO()
        {
            if(TestCases.Any()==false) {
                throw new InvalidOperationException("TestCases list was null");
            }

            WorkItemSvc.UpsertTestCases(TestCases);
        }


    }


}
