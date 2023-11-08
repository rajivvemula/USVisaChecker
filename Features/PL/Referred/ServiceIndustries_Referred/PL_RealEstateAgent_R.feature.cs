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
namespace ApolloQAAutomation.Features.PL.Referred.ServiceIndustries_Referred
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_RealEstateAgent_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_RealEstateAgent_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Referred/ServiceIndustries_Referred", "PL_RealEstateAgent_R", "Real Estate Agent Referral via the \"This policy is specifically for real estate a" +
                    "gent/brokerage services (E&O) and does not cover bodily injury or property damag" +
                    "e claims arising from properties you manage.\" question\r\n134 David Ln, Somerset, " +
                    "PA 15501", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_RealEstateAgent_R")))
            {
                global::ApolloQAAutomation.Features.PL.Referred.ServiceIndustries_Referred.PL_RealEstateAgent_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Real Estate Agent Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_RealEstateAgent_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public void PLRealEstateAgentReferred()
        {
            string[] tagsOfScenario = new string[] {
                    "PL",
                    "Referred",
                    "Service",
                    "Regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Real Estate Agent Referred", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1211 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1211.AddRow(new string[] {
                            "Real Estate Agent",
                            "2",
                            "I Lease a Space From Others",
                            "",
                            "15501",
                            "PL"});
#line 8
 testRunner.Given("user starts a quote with:", ((string)(null)), table1211, "Given ");
#line hidden
#line 11
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1212 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table1212.AddRow(new string[] {
                            "Limited Liability Co LLC",
                            "Real Cheap Real Estate",
                            "258 Beacon St",
                            "RCRE"});
#line 12
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1212, "Then ");
#line hidden
#line 15
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1213 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1213.AddRow(new string[] {
                            "What year was your business started?",
                            "2019"});
                table1213.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "500,000"});
                table1213.AddRow(new string[] {
                            "Do you use a written contract or statement of work (SOW)?",
                            "Always"});
                table1213.AddRow(new string[] {
                            "Who signs off on the terms & conditions for written contracts or statements of wo" +
                                "rk (SOW)?",
                            "Legal"});
#line 16
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1213, "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1214 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1214.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1214.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table1214.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "No"});
                table1214.AddRow(new string[] {
                            "Which option best describes your current Errors & Omissions policy?",
                            "This was my first policy."});
                table1214.AddRow(new string[] {
                            "How many Errors & Omissions claims have you had in the past 3 years, if any?",
                            "0"});
#line 23
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1214, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1215 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1215.AddRow(new string[] {
                            "Do you collect private data?",
                            "No"});
                table1215.AddRow(new string[] {
                            "What percentage of revenue comes from sales of commercial properties or vacant la" +
                                "nd?",
                            "0%"});
                table1215.AddRow(new string[] {
                            "What percentage of revenue comes from short sales?",
                            "0%"});
                table1215.AddRow(new string[] {
                            "Does your business own any properties?",
                            "No"});
                table1215.AddRow(new string[] {
                            "Does your business manage any properties?",
                            "Yes"});
                table1215.AddRow(new string[] {
                            "This policy is specifically for real estate agent/brokerage services (E&O) and do" +
                                "es not cover bodily injury or property damage claims arising from properties you" +
                                " manage.",
                            "I want a quote to insure the properties I manage also"});
                table1215.AddRow(new string[] {
                            "Do you provide appraisals?",
                            "No"});
                table1215.AddRow(new string[] {
                            "Do you provide any title related services such as closing agent, escrow agent, ti" +
                                "tle abstractor, title agent, or title search?",
                            "No"});
                table1215.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 30
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1215, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1216 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1216.AddRow(new string[] {
                            "First Name",
                            "Real"});
                table1216.AddRow(new string[] {
                            "Last Name",
                            "Estate"});
                table1216.AddRow(new string[] {
                            "Address",
                            "4174 Glades Pike"});
                table1216.AddRow(new string[] {
                            "Apt/Suite",
                            "1"});
                table1216.AddRow(new string[] {
                            "City",
                            "Somerset"});
                table1216.AddRow(new string[] {
                            "Use as Mailing Address",
                            "No"});
                table1216.AddRow(new string[] {
                            "Mailing Address",
                            "4258 Glades Pike"});
                table1216.AddRow(new string[] {
                            "Mailing Apt/Suite",
                            "1"});
                table1216.AddRow(new string[] {
                            "Mailing ZIP",
                            "15501"});
                table1216.AddRow(new string[] {
                            "Mailing City",
                            "Somerset"});
                table1216.AddRow(new string[] {
                            "Email",
                            "RealEstate@biz.com"});
                table1216.AddRow(new string[] {
                            "Business Phone",
                            "7777777777"});
                table1216.AddRow(new string[] {
                            "Ext",
                            "7777"});
                table1216.AddRow(new string[] {
                            "Website/Social",
                            "www.RealEstate.com"});
#line 41
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1216, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1217 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1217.AddRow(new string[] {
                            "Business name",
                            "Real Cheap Real Estate"});
                table1217.AddRow(new string[] {
                            "DBA",
                            "RCRE"});
                table1217.AddRow(new string[] {
                            "Contact first name",
                            "Real"});
                table1217.AddRow(new string[] {
                            "Contact last name",
                            "Estate"});
                table1217.AddRow(new string[] {
                            "Email",
                            "RealEstate@biz.com"});
                table1217.AddRow(new string[] {
                            "Phone",
                            "(777) 777-7777"});
                table1217.AddRow(new string[] {
                            "Ext",
                            "7777"});
                table1217.AddRow(new string[] {
                            "Business website",
                            "www.RealEstate.com"});
#line 57
 testRunner.When("user fills out the PL refer page with these values:", ((string)(null)), table1217, "When ");
#line hidden
#line 67
 testRunner.Then("user verifies the PL refer confirmation appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion