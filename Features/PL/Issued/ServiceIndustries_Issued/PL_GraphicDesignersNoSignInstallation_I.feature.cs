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
namespace ApolloQAAutomation.Features.PL.Issued.ServiceIndustries_Issued
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_GraphicDesignersNoSignInstallation_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_GraphicDesignersNoSignInstallation_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Issued/ServiceIndustries_Issued", "PL_GraphicDesignersNoSignInstallation_I", "Issuing a PL policy for Graphic Designers: No Sign Installation in WI\r\nUS 71963, " +
                    "US 124751", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_GraphicDesignersNoSignInstallation_I")))
            {
                global::ApolloQAAutomation.Features.PL.Issued.ServiceIndustries_Issued.PL_GraphicDesignersNoSignInstallation_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Graphic Designers No Sign Installation verify the details of your quote page (" +
            "Standard)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_GraphicDesignersNoSignInstallation_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        public void PLGraphicDesignersNoSignInstallationVerifyTheDetailsOfYourQuotePageStandard()
        {
            string[] tagsOfScenario = new string[] {
                    "Regression",
                    "PL",
                    "Service",
                    "WI",
                    "Issued"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Graphic Designers No Sign Installation verify the details of your quote page (" +
                    "Standard)", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1089 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1089.AddRow(new string[] {
                            "Graphic Designers: No Sign Installation",
                            "7",
                            "I Lease a Space From Others",
                            "",
                            "35747",
                            "PL"});
#line 8
 testRunner.Given("user starts a quote with:", ((string)(null)), table1089, "Given ");
#line hidden
#line 11
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1090 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table1090.AddRow(new string[] {
                            "Corporation",
                            "Best designers",
                            "11 Pecan St",
                            "No"});
#line 12
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1090, "Then ");
#line hidden
#line 15
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1091 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1091.AddRow(new string[] {
                            "What year was your business started?",
                            "2020"});
                table1091.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "700,000"});
                table1091.AddRow(new string[] {
                            "Do you use a written contract or statement of work (SOW)?",
                            "Always"});
                table1091.AddRow(new string[] {
                            "Who signs off on the terms & conditions for written contracts or statements of wo" +
                                "rk (SOW)?",
                            "Outside"});
#line 16
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1091, "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1092 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1092.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1092.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table1092.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "No"});
                table1092.AddRow(new string[] {
                            "Which option best describes your current professional liability policy?",
                            "This was my first policy."});
                table1092.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 23
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1092, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1093 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1093.AddRow(new string[] {
                            "Do you have a written procedure to check materials for copyright or trademark vio" +
                                "lations?",
                            "Yes"});
                table1093.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 30
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1093, "Then ");
#line hidden
#line 34
 testRunner.Then("user verifies the appearance of the PL About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1094 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1094.AddRow(new string[] {
                            "First Name",
                            "NameF"});
                table1094.AddRow(new string[] {
                            "Last Name",
                            "NameL"});
                table1094.AddRow(new string[] {
                            "Address",
                            "11 Pecan St"});
                table1094.AddRow(new string[] {
                            "Apt/Suite",
                            ""});
                table1094.AddRow(new string[] {
                            "City",
                            "Grant"});
                table1094.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1094.AddRow(new string[] {
                            "Email",
                            "test@this.com"});
                table1094.AddRow(new string[] {
                            "Business Phone",
                            "8887775767"});
                table1094.AddRow(new string[] {
                            "Ext",
                            ""});
                table1094.AddRow(new string[] {
                            "Website/Social",
                            ""});
                table1094.AddRow(new string[] {
                            "Have Broker",
                            "No"});
#line 35
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1094, "Then ");
#line hidden
#line 48
 testRunner.Then("user verifies the appearance of the PL Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.Then("user selects their Yearly - Standard Quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("user verifies the PL purchase page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1095 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1095.AddRow(new string[] {
                            "Autopay",
                            "Off"});
                table1095.AddRow(new string[] {
                            "CC Name",
                            "K-12 Educator"});
                table1095.AddRow(new string[] {
                            "CC Number",
                            "4111 1111 1111 1111"});
                table1095.AddRow(new string[] {
                            "CC Expiration",
                            "07/25"});
                table1095.AddRow(new string[] {
                            "Street Address",
                            "10 Abels Ln"});
                table1095.AddRow(new string[] {
                            "ZIP Code",
                            "04660"});
                table1095.AddRow(new string[] {
                            "City",
                            "Mt Desert"});
                table1095.AddRow(new string[] {
                            "Phone",
                            "888-777-5767"});
                table1095.AddRow(new string[] {
                            "Extension",
                            ""});
#line 51
 testRunner.When("user fills out the PL purchase page with these values:", ((string)(null)), table1095, "When ");
#line hidden
#line 62
 testRunner.Then("user verifies the PL how would you rate our service? page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 63
 testRunner.Then("user verifies the PL thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.And("user verifies that the following LOBs are recommended: WC", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
