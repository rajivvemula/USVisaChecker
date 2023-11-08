﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ApolloQAAutomation.Features.WorkmansComp.Declined.AutoServicesAndDealers_D
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_CarWashSelfService_DFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_CarWashSelfService_D.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Declined/AutoServicesAndDealers_D", "WC_CarWashSelfService_D", @"Ineligible quote - response to carrier question;
Prior customer relationship N9WC959936, Previous Customer - In Collections based on  Email.
Keyword: Car Wash: Self Service
Employee Option: Yes I have
Number of employees : 6
Business Operation: I Own a Property & Lease to Others
Included Officer: 1
Business started year : Started 1 years ago
Business Structured: Corporation
Payroll: 400000
Email: ironboundtaxes@gmail.com", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_CarWashSelfService_D")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Declined.AutoServicesAndDealers_D.WC_CarWashSelfService_DFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Car Wash Self Service gets declined due to customer\'s email listed in collecti" +
            "ons")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_CarWashSelfService_D")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Auto")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Declined")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("KY")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public void WCCarWashSelfServiceGetsDeclinedDueToCustomersEmailListedInCollections()
        {
            string[] tagsOfScenario = new string[] {
                    "Auto",
                    "WC",
                    "Declined",
                    "KY",
                    "Regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Car Wash Self Service gets declined due to customer\'s email listed in collecti" +
                    "ons", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 15
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1875 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1875.AddRow(new string[] {
                            "Car Wash: Self Service",
                            "6",
                            "I Own a Property & Lease to Others",
                            "Vehicles",
                            "40004",
                            "WC"});
#line 16
 testRunner.Given("user starts a quote with:", ((string)(null)), table1875, "Given ");
#line hidden
#line 19
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1876 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1876.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table1876.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 5 years ago"});
                table1876.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table1876.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "40000"});
                table1876.AddRow(new string[] {
                            "Do any employees only do clerical office tasks and does not write up repair estim" +
                                "ates?",
                            "no"});
                table1876.AddRow(new string[] {
                            "Business",
                            "Credit score linked to SSN refer"});
                table1876.AddRow(new string[] {
                            "Address",
                            "701 SE 71st St;Bardstown"});
                table1876.AddRow(new string[] {
                            "Contact First Name",
                            "TestF"});
                table1876.AddRow(new string[] {
                            "Contact Last Name",
                            "TestL"});
                table1876.AddRow(new string[] {
                            "Email",
                            "ironboundtaxes@gmail.com"});
                table1876.AddRow(new string[] {
                            "Phone",
                            "1231233212"});
#line 20
 testRunner.And("user fills out the WC About You page with these values:", ((string)(null)), table1876, "And ");
#line hidden
#line 33
 testRunner.And("user verifies the Wage Calculator page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.And("user clicks continue from the Wage Calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1877 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1877.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table1877.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "1"});
                table1877.AddRow(new string[] {
                            "Do any included owners/officers only do general office work never writing up repa" +
                                "ir estimates?",
                            "Yes - 1"});
#line 36
 testRunner.And("user handles the WC OO kickoff questions with these values:", ((string)(null)), table1877, "And ");
#line hidden
#line 41
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1878 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1878.AddRow(new string[] {
                            "Do you provide towing or roadside assistance?",
                            "No"});
                table1878.AddRow(new string[] {
                            "Do you engage in the repossession of vehicles?",
                            "no"});
                table1878.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table1878.AddRow(new string[] {
                            "Do you sell or service large commercial vehicles, motorcycles, or recreational ve" +
                                "hicles?",
                            "no"});
                table1878.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table1878.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table1878.AddRow(new string[] {
                            "Social Security Number (SSN)",
                            "832803691"});
#line 42
 testRunner.And("user fills out the WC Your Services page", ((string)(null)), table1878, "And ");
#line hidden
#line 51
 testRunner.Then("user verifies the WC decline page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion