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
    public partial class PL_PublicRelationsAgencies_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_PublicRelationsAgencies_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Referred/ServiceIndustries_Referred", "PL_PublicRelationsAgencies_R", "US 80522 [Refactor] General Referral Refactor", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_PublicRelationsAgencies_R")))
            {
                global::ApolloQAAutomation.Features.PL.Referred.ServiceIndustries_Referred.PL_PublicRelationsAgencies_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Public Relations Agencies gets referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_PublicRelationsAgencies_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public void PLPublicRelationsAgenciesGetsReferred()
        {
            string[] tagsOfScenario = new string[] {
                    "PL",
                    "Referred",
                    "Service",
                    "Regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Public Relations Agencies gets referred", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1204 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1204.AddRow(new string[] {
                            "Public Relations Agencies",
                            "2",
                            "I Lease a Space From Others",
                            "",
                            "60606",
                            "PL"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table1204, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1205 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table1205.AddRow(new string[] {
                            "Corporation",
                            "PR Agency",
                            "15872 Co Rd 29",
                            "No"});
#line 10
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1205, "Then ");
#line hidden
#line 13
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1206 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1206.AddRow(new string[] {
                            "What year was your business started?",
                            "2000"});
                table1206.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "770,770"});
                table1206.AddRow(new string[] {
                            "Do you use a written contract or statement of work (SOW)?",
                            "Always"});
                table1206.AddRow(new string[] {
                            "Who signs off on the terms & conditions for written contracts or statements of wo" +
                                "rk (SOW)?",
                            "In House"});
#line 14
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1206, "Then ");
#line hidden
#line 20
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1207 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1207.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1207.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table1207.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "Yes"});
                table1207.AddRow(new string[] {
                            "What is the retroactive date?",
                            ""});
                table1207.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 21
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1207, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1208 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1208.AddRow(new string[] {
                            "Do you provide financial investment advice?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you have attorneys on staff that provide legal advice to others?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you create advertisements or provide brand advice for your clients?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you provide advice or services that require a Certified Public Accountant?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you provide architectural or engineering advice?",
                            "Yes"});
                table1208.AddRow(new string[] {
                            "Do you do work involving aerospace engineering?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you advise on Geotechnical, Soils, or Structural Engineering?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you give advice on nuclear materials?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you design any weapons?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you directly perform physical work for others?",
                            "Yes"});
                table1208.AddRow(new string[] {
                            "Do you design amusement rides or playgrounds?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do client deliverables undergo a peer review?",
                            "Always"});
                table1208.AddRow(new string[] {
                            "Do you advise on the contamination risk, presence of, or clean up of any pollutan" +
                                "ts?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you provide staffing services?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you offer asbestos evaluation or abatement services?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you develop medical diagnostic machines or artificial organs?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you design bridges?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you provide emergency response services?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you manufacture, sell, or distribute products under your business name?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you do Human Resources (HR) consulting or management for clients?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you do workplace safety consulting for occupational hazards?",
                            "No"});
                table1208.AddRow(new string[] {
                            "Do you provide health care services or advice that requires a licensed health car" +
                                "e professional?",
                            "No"});
                table1208.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 28
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1208, "Then ");
#line hidden
#line 53
 testRunner.Then("user verifies the appearance of the PL About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1209 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1209.AddRow(new string[] {
                            "First Name",
                            "Teddy"});
                table1209.AddRow(new string[] {
                            "Last Name",
                            "Roosevelt"});
                table1209.AddRow(new string[] {
                            "Address",
                            "123 Fake St"});
                table1209.AddRow(new string[] {
                            "City",
                            "Haymarket"});
                table1209.AddRow(new string[] {
                            "Email",
                            "test@biz.com"});
                table1209.AddRow(new string[] {
                            "Business Phone",
                            "(432) 123-4423"});
                table1209.AddRow(new string[] {
                            "Have Broker",
                            "No"});
#line 54
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1209, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1210 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1210.AddRow(new string[] {
                            "Business name",
                            "PR Agency"});
                table1210.AddRow(new string[] {
                            "Contact first name",
                            "Teddy"});
                table1210.AddRow(new string[] {
                            "Contact last name",
                            "Roosevelt"});
                table1210.AddRow(new string[] {
                            "Email",
                            "test@biz.com"});
                table1210.AddRow(new string[] {
                            "Phone",
                            "(432) 123-4423"});
#line 63
 testRunner.When("user fills out the PL refer page with these values:", ((string)(null)), table1210, "When ");
#line hidden
#line 70
 testRunner.Then("user verifies the PL refer confirmation appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
