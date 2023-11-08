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
namespace ApolloQAAutomation.Features.PL.Issued.HealthCareAndSocialAssistance_Issued
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_HomeHealthAide_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_HomeHealthAide_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Issued/HealthCareAndSocialAssistance_Issued", "PL_HomeHealthAide_I", "Issuing a PL Policy with the Home Health Aide: No Registered Nurses keyword and v" +
                    "erified Your Services new Class Level Questions.\r\nQuestion:  Do you provide heal" +
                    "th care services or advice that requires a licensed health care professional?", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_HomeHealthAide_I")))
            {
                global::ApolloQAAutomation.Features.PL.Issued.HealthCareAndSocialAssistance_Issued.PL_HomeHealthAide_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Home Health Aide: No Registered Nurses Issued policy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_HomeHealthAide_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HealthCare")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ND")]
        public void PLHomeHealthAideNoRegisteredNursesIssuedPolicy()
        {
            string[] tagsOfScenario = new string[] {
                    "Regression",
                    "PL",
                    "HealthCare",
                    "Issued",
                    "ND"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Home Health Aide: No Registered Nurses Issued policy", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table960 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table960.AddRow(new string[] {
                            "Home Health Aide: No Registered Nurses",
                            "2",
                            "I Lease a Space From Others",
                            "",
                            "58011",
                            "PL"});
#line 8
 testRunner.Given("user starts a quote with:", ((string)(null)), table960, "Given ");
#line hidden
#line 11
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table961 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table961.AddRow(new string[] {
                            "Corporation",
                            "HHA",
                            "407 Main St",
                            "No"});
#line 12
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table961, "Then ");
#line hidden
#line 15
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table962 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table962.AddRow(new string[] {
                            "What year was your business started?",
                            "2010"});
                table962.AddRow(new string[] {
                            "How many healthcare professionals work for your business?",
                            "2"});
                table962.AddRow(new string[] {
                            "How many health students work for your business?",
                            "0"});
#line 16
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table962, "Then ");
#line hidden
#line 21
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table963 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table963.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table963.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table963.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "No"});
                table963.AddRow(new string[] {
                            "Which option best describes your current professional liability policy?",
                            "This was my first policy."});
                table963.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 22
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table963, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table964 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table964.AddRow(new string[] {
                            "Are any business owner(s) or staff an MD (Medical Doctor)?",
                            "No"});
                table964.AddRow(new string[] {
                            "Do you practice any radiology or medical dosimetry?",
                            "No"});
                table964.AddRow(new string[] {
                            "Do you provide health care services or advice that requires a licensed health car" +
                                "e professional?",
                            "No"});
                table964.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 29
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table964, "Then ");
#line hidden
#line 35
  testRunner.Then("user verifies the appearance of the PL About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table965 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table965.AddRow(new string[] {
                            "First Name",
                            "Tester"});
                table965.AddRow(new string[] {
                            "Last Name",
                            "EJ"});
                table965.AddRow(new string[] {
                            "Address",
                            "407 Main St"});
                table965.AddRow(new string[] {
                            "Apt/Suite",
                            ""});
                table965.AddRow(new string[] {
                            "City",
                            "Buffalo"});
                table965.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table965.AddRow(new string[] {
                            "Email",
                            "abc@tester.com"});
                table965.AddRow(new string[] {
                            "Business Phone",
                            "3213213221"});
                table965.AddRow(new string[] {
                            "Ext",
                            ""});
                table965.AddRow(new string[] {
                            "Website/Social",
                            ""});
                table965.AddRow(new string[] {
                            "Have Broker",
                            "No"});
#line 36
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table965, "Then ");
#line hidden
#line 49
 testRunner.Then("user verifies the appearance of the PL Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("user selects their Yearly - Standard Quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.Then("user verifies the PL purchase page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table966 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table966.AddRow(new string[] {
                            "Autopay",
                            "On"});
                table966.AddRow(new string[] {
                            "CC Name",
                            "Tester EJ"});
                table966.AddRow(new string[] {
                            "CC Number",
                            "4111 1111 1111 1111"});
                table966.AddRow(new string[] {
                            "CC Expiration",
                            "03/30"});
                table966.AddRow(new string[] {
                            "Street Address",
                            "407 Main St"});
                table966.AddRow(new string[] {
                            "ZIP Code",
                            "58011"});
                table966.AddRow(new string[] {
                            "City",
                            "Buffalo"});
                table966.AddRow(new string[] {
                            "Phone",
                            "321-321-3221"});
                table966.AddRow(new string[] {
                            "Extension",
                            ""});
#line 52
 testRunner.When("user fills out the PL purchase page with these values:", ((string)(null)), table966, "When ");
#line hidden
#line 63
 testRunner.Then("user verifies the PL how would you rate our service? page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.Then("user verifies the PL thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
