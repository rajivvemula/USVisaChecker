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
namespace ApolloQAAutomation.Features.Unit
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_UpdateYourQuoteFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_UpdateYourQuote.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit", "PL_UpdateYourQuote", "Partial Feature File added for implementing the \"Then user verifies the PL Custom" +
                    "ize Your Plan modal appears\" step logic ", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_UpdateYourQuote")))
            {
                global::ApolloQAAutomation.Features.Unit.PL_UpdateYourQuoteFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Update Your Quote modal partial file")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_UpdateYourQuote")]
        public void PLUpdateYourQuoteModalPartialFile()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Update Your Quote modal partial file", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1830 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1830.AddRow(new string[] {
                            "Graphic Designers: No Sign Installation",
                            "2",
                            "I Run My Business From Property I Own",
                            "",
                            "65781",
                            "PL"});
#line 5
 testRunner.Given("user starts a quote with:", ((string)(null)), table1830, "Given ");
#line hidden
#line 8
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1831 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "DBA"});
                table1831.AddRow(new string[] {
                            "Corporation",
                            "Mikes Graphics",
                            "MGD"});
#line 9
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1831, "Then ");
#line hidden
#line 12
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1832 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1832.AddRow(new string[] {
                            "What year was your business started?",
                            "2000"});
                table1832.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "250,000"});
                table1832.AddRow(new string[] {
                            "Do you use a written contract or statement of work (SOW)?",
                            "Never"});
#line 13
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1832, "Then ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1833 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1833.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "No"});
                table1833.AddRow(new string[] {
                            "Have you had a Professional Liability (E&O) policy in the last 3 years?",
                            "No"});
#line 19
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1833, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1834 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1834.AddRow(new string[] {
                            "Do you have a written procedure to check materials for copyright or trademark vio" +
                                "lations?",
                            "No"});
                table1834.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 23
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1834, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1835 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1835.AddRow(new string[] {
                            "First Name",
                            "Mike"});
                table1835.AddRow(new string[] {
                            "Last Name",
                            "Jones"});
                table1835.AddRow(new string[] {
                            "Address",
                            "109 Long Dr"});
                table1835.AddRow(new string[] {
                            "City",
                            "Willard"});
                table1835.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1835.AddRow(new string[] {
                            "Email",
                            "MikeJones@yahoo.com"});
                table1835.AddRow(new string[] {
                            "Business Phone",
                            "7777777777"});
                table1835.AddRow(new string[] {
                            "Ext",
                            "7777"});
                table1835.AddRow(new string[] {
                            "Website/Social",
                            "www.MikeJones.com"});
#line 27
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1835, "Then ");
#line hidden
#line 38
 testRunner.Then("user verifies the appearance of the PL Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1836 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1836.AddRow(new string[] {
                            "Deductible PO",
                            "$5,000"});
                table1836.AddRow(new string[] {
                            "Limits PO",
                            "$1,000,000"});
                table1836.AddRow(new string[] {
                            "Limits Agg",
                            "$2,000,000"});
                table1836.AddRow(new string[] {
                            "Plus Deductible PO",
                            ""});
                table1836.AddRow(new string[] {
                            "Plus Limits PO",
                            ""});
                table1836.AddRow(new string[] {
                            "Plus Limits Agg",
                            ""});
                table1836.AddRow(new string[] {
                            "Plus CL Agg",
                            ""});
                table1836.AddRow(new string[] {
                            "Plus PL Agg",
                            ""});
#line 40
 testRunner.Then("user adjusts their Yearly - Standard quote with these values:", ((string)(null)), table1836, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1837 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1837.AddRow(new string[] {
                            "Deductible",
                            "1,000"});
                table1837.AddRow(new string[] {
                            "Limits",
                            "1,000,000"});
                table1837.AddRow(new string[] {
                            "Aggregate",
                            "1,000,000"});
#line 50
 testRunner.Then("user fills out the PL Customize Your Plan Modal wih these values:", ((string)(null)), table1837, "Then ");
#line hidden
#line 55
 testRunner.Then("user selects their Yearly - Standard Quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion