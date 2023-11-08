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
namespace BiBerkLOB.Features.Unit.PL
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_Generic_COIFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_Generic_COI.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/PL", "PL_Generic_COI", "Task 81972: Staging Regression (PL) | Create Test Case | Provide a generic COI as" +
                    " part of the policy confirmation email in order to improve the customer experien" +
                    "ce and reduce service engagement", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_Generic_COI")))
            {
                global::BiBerkLOB.Features.Unit.PL.PL_Generic_COIFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL_Generic_COI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_Generic_COI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        public void PL_Generic_COI()
        {
            string[] tagsOfScenario = new string[] {
                    "PL",
                    "Unit",
                    "Staging"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL_Generic_COI", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1299 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1299.AddRow(new string[] {
                            "Hair Stylist",
                            "3",
                            "I Lease a Space From Others",
                            "",
                            "60101",
                            "PL"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1299, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1300 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Insured First Name",
                            "Insured Last Name",
                            "DBA"});
                table1300.AddRow(new string[] {
                            "Individual/Sole Proprietor",
                            "TestF",
                            "TestL",
                            "TEST DBA PL - NON-ATTORNEY PURCHASE"});
#line 11
  testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1300, "Then ");
#line hidden
#line 14
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1301 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1301.AddRow(new string[] {
                            "What year was your business started?",
                            "2016"});
                table1301.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "250,000"});
#line 15
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1301, "Then ");
#line hidden
#line 19
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1302 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1302.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table1302.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "Yes"});
                table1302.AddRow(new string[] {
                            "What is the retroactive date?",
                            "01/01/2021"});
                table1302.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 20
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1302, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1303 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1303.AddRow(new string[] {
                            "Do you provide body massage services?",
                            "No"});
                table1303.AddRow(new string[] {
                            "Do you provide tattoo services?",
                            "No"});
                table1303.AddRow(new string[] {
                            "Do you operate tanning beds?",
                            "No"});
                table1303.AddRow(new string[] {
                            "Do you do keratin hair-straightening procedures or brazilian blowouts?",
                            "No"});
                table1303.AddRow(new string[] {
                            "Do you do body piercings?",
                            "No"});
                table1303.AddRow(new string[] {
                            "Do you do any body sculpting or cosmetic medical procedures?",
                            "No"});
                table1303.AddRow(new string[] {
                            "Do you provide acupuncture, facial injection, fillers, or laser treatment service" +
                                "s?",
                            "No"});
                table1303.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 26
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1303, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1304 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1304.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table1304.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table1304.AddRow(new string[] {
                            "Address",
                            "233 N Mill Rd"});
                table1304.AddRow(new string[] {
                            "Apt/Suite",
                            ""});
                table1304.AddRow(new string[] {
                            "City",
                            "Addison"});
                table1304.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1304.AddRow(new string[] {
                            "Email",
                            "TestCert@Plan.com"});
                table1304.AddRow(new string[] {
                            "Business Phone",
                            "(123) 123-1321"});
                table1304.AddRow(new string[] {
                            "Website/Social",
                            ""});
#line 36
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1304, "Then ");
#line hidden
#line 47
 testRunner.Then("user verifies the appearance of the PL Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.Then("user verifies that the following coverages are displayed in the details of their " +
                        "PL Plus Quote: PL,Cyber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.Then("user selects their Yearly - Plus Quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1305 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1305.AddRow(new string[] {
                            "Autopay",
                            "Off"});
                table1305.AddRow(new string[] {
                            "CC Name",
                            "TestF TestL"});
                table1305.AddRow(new string[] {
                            "CC Number",
                            "4111 1111 1111 1111"});
                table1305.AddRow(new string[] {
                            "CC Expiration",
                            "03/30"});
                table1305.AddRow(new string[] {
                            "Phone",
                            "1231231321"});
                table1305.AddRow(new string[] {
                            "Extension",
                            "1234"});
#line 50
 testRunner.When("user fills out the PL purchase page with these values:", ((string)(null)), table1305, "When ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion