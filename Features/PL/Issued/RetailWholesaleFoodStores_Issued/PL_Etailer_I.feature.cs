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
namespace ApolloQAAutomation.Features.PL.Issued.RetailWholesaleFoodStores_Issued
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_Etailer_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_Etailer_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Issued/RetailWholesaleFoodStores_Issued", "PL_Etailer_I", "Issuing an Etailer policy", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_Etailer_I")))
            {
                global::ApolloQAAutomation.Features.PL.Issued.RetailWholesaleFoodStores_Issued.PL_Etailer_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Etailer Double bundle Issued policy in PA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_Etailer_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PA")]
        public void PLEtailerDoubleBundleIssuedPolicyInPA()
        {
            string[] tagsOfScenario = new string[] {
                    "PL",
                    "Issued",
                    "Service",
                    "Staging",
                    "Regression",
                    "PA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Etailer Double bundle Issued policy in PA", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1051 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1051.AddRow(new string[] {
                            "Etailer",
                            "0",
                            "I Lease a Space From Others",
                            "",
                            "17404",
                            "PL"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1051, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1052 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table1052.AddRow(new string[] {
                            "Individual/Sole Proprietor",
                            "E tailer",
                            "1060 Church Rd",
                            "Test PL Quote Double Bundle"});
#line 11
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1052, "Then ");
#line hidden
#line 14
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1053 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1053.AddRow(new string[] {
                            "What year was your business started?",
                            "2020"});
                table1053.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "250,000"});
                table1053.AddRow(new string[] {
                            "Do you use a written contract or statement of work (SOW)?",
                            "Always"});
                table1053.AddRow(new string[] {
                            "Who signs off on the terms & conditions for written contracts or statements of wo" +
                                "rk (SOW)?",
                            "Outside"});
#line 15
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1053, "Then ");
#line hidden
#line 21
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1054 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1054.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1054.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table1054.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "I Don\'t Know"});
                table1054.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 22
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1054, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1055 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1055.AddRow(new string[] {
                            "Can users upload content to websites you own or operate?",
                            "No"});
                table1055.AddRow(new string[] {
                            "Do you develop software that provides or assists with medical diagnoses?",
                            "No"});
                table1055.AddRow(new string[] {
                            "Do you develop software that aids architects or engineers in product design?",
                            "No"});
                table1055.AddRow(new string[] {
                            "Do you electronically store private data?",
                            "No"});
                table1055.AddRow(new string[] {
                            "Do you design, integrate, or maintain networks for clients?",
                            "No"});
                table1055.AddRow(new string[] {
                            "Do you provide website hosting or domain registration?",
                            "No"});
                table1055.AddRow(new string[] {
                            "Do you design any hardware?",
                            "No"});
                table1055.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 28
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1055, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1056 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1056.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table1056.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table1056.AddRow(new string[] {
                            "Address",
                            "100 Test Road"});
                table1056.AddRow(new string[] {
                            "Apt/Suite",
                            "3"});
                table1056.AddRow(new string[] {
                            "City",
                            "York"});
                table1056.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1056.AddRow(new string[] {
                            "Email",
                            "Automation@biBERK.com"});
                table1056.AddRow(new string[] {
                            "Business Phone",
                            "1231231321"});
                table1056.AddRow(new string[] {
                            "Ext",
                            "1234"});
#line 38
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1056, "Then ");
#line hidden
#line 49
 testRunner.Then("user verifies the appearance of the PL Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("user verifies that the following coverages are displayed in the details of their " +
                        "PL Plus Quote: PL,Cyber,Copyright Plus", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.Then("user selects their Yearly - Plus Quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 52
 testRunner.Then("user verifies the PL purchase page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1057 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1057.AddRow(new string[] {
                            "Autopay",
                            "Off"});
                table1057.AddRow(new string[] {
                            "CC Name",
                            "TestF TestL"});
                table1057.AddRow(new string[] {
                            "CC Number",
                            "4111 1111 1111 1111"});
                table1057.AddRow(new string[] {
                            "CC Expiration",
                            "03/30"});
                table1057.AddRow(new string[] {
                            "Street Address",
                            "100 Test Road"});
                table1057.AddRow(new string[] {
                            "ZIP Code",
                            "17404"});
                table1057.AddRow(new string[] {
                            "City",
                            "York"});
                table1057.AddRow(new string[] {
                            "Phone",
                            "1231231321"});
                table1057.AddRow(new string[] {
                            "Extension",
                            "1234"});
#line 53
 testRunner.When("user fills out the PL purchase page with these values:", ((string)(null)), table1057, "When ");
#line hidden
#line 64
 testRunner.Then("user verifies the PL how would you rate our service? page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 65
 testRunner.Then("user verifies the PL thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.And("user verifies that the following LOBs are recommended: BOP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion