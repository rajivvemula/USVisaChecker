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
namespace ApolloQAAutomation.Features.Unit.PL
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_GenerateProposalEmail_Pollution_UFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_GenerateProposalEmail_Pollution_U.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/PL", "PL_GenerateProposalEmail_Pollution_U", "User Story 81901: Staging Regression | Create Test Case | PL | Generate Proposal " +
                    "Email | Pollution", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_GenerateProposalEmail_Pollution_U")))
            {
                global::ApolloQAAutomation.Features.Unit.PL.PL_GenerateProposalEmail_Pollution_UFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Generate Proposal Email Pollution")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_GenerateProposalEmail_Pollution_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PA")]
        public void PLGenerateProposalEmailPollution()
        {
            string[] tagsOfScenario = new string[] {
                    "Unit",
                    "Regression",
                    "PL",
                    "Staging",
                    "PA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Generate Proposal Email Pollution", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1743 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1743.AddRow(new string[] {
                            "Environmental Engineering",
                            "3",
                            "I Lease a Space From Others",
                            "",
                            "17404",
                            "PL"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1743, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1744 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table1744.AddRow(new string[] {
                            "Limited Liability Co. (LLC)",
                            "Test PL Pollution",
                            "1060 Church Rd",
                            "No"});
#line 11
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1744, "Then ");
#line hidden
#line 14
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1745 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1745.AddRow(new string[] {
                            "What year was your business started?",
                            "2020"});
                table1745.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "400,000"});
                table1745.AddRow(new string[] {
                            "Do you use a written contract or statement of work (SOW)?",
                            "Always"});
                table1745.AddRow(new string[] {
                            "Who signs off on the terms & conditions for written contracts or statements of wo" +
                                "rk (SOW)?",
                            "Outside"});
#line 15
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1745, "Then ");
#line hidden
#line 21
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1746 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1746.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1746.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table1746.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "I Don\'t Know"});
                table1746.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 22
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1746, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1747 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1747.AddRow(new string[] {
                            "Do you do work involving aerospace engineering?",
                            "No"});
                table1747.AddRow(new string[] {
                            "Do you advise on Geotechnical, Soils, or Structural Engineering?",
                            "No"});
                table1747.AddRow(new string[] {
                            "Do you give advice on nuclear materials?",
                            "No"});
                table1747.AddRow(new string[] {
                            "Do you design any weapons?",
                            "No"});
                table1747.AddRow(new string[] {
                            "Do you directly perform physical work for others?",
                            "No"});
                table1747.AddRow(new string[] {
                            "Do client deliverables undergo a peer review?",
                            "Never"});
                table1747.AddRow(new string[] {
                            "Do you advise on the contamination risk, presence of, or clean up of any pollutan" +
                                "ts?",
                            "No"});
                table1747.AddRow(new string[] {
                            "Do you offer asbestos evaluation or abatement services?",
                            "No"});
                table1747.AddRow(new string[] {
                            "Do you provide emergency response services?",
                            "No"});
                table1747.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 28
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1747, "Then ");
#line hidden
#line 40
 testRunner.Then("user verifies the appearance of the PL About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1748 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1748.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table1748.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table1748.AddRow(new string[] {
                            "Address",
                            "100 Test Road"});
                table1748.AddRow(new string[] {
                            "Apt/Suite",
                            ""});
                table1748.AddRow(new string[] {
                            "City",
                            "York"});
                table1748.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1748.AddRow(new string[] {
                            "Email",
                            "Test@biBERK.com"});
                table1748.AddRow(new string[] {
                            "Business Phone",
                            "(123)123-1321"});
                table1748.AddRow(new string[] {
                            "Ext",
                            "1234"});
                table1748.AddRow(new string[] {
                            "Website/Social",
                            ""});
#line 41
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1748, "Then ");
#line hidden
#line 53
 testRunner.Then("user verifies the appearance of the PL Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1749 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1749.AddRow(new string[] {
                            "Deductible PO",
                            "$2,500"});
                table1749.AddRow(new string[] {
                            "Limits PO",
                            "$300,000"});
                table1749.AddRow(new string[] {
                            "Limits Agg",
                            "$500,000"});
                table1749.AddRow(new string[] {
                            "Plus PL Agg",
                            "$1,000,000"});
#line 54
 testRunner.Then("user adjusts their  -  quote with these values:", ((string)(null)), table1749, "Then ");
#line hidden
#line 60
 testRunner.Then("user verifies the PL Email Your Quote modal appears", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
