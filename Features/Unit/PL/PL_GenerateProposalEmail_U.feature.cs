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
    public partial class PL_GenerateProposalEmail_UFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_GenerateProposalEmail_U.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/PL", "PL_GenerateProposalEmail_U", "Verify that the UI indicates a proposal email has been generated for a PL policy", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_GenerateProposalEmail_U")))
            {
                global::ApolloQAAutomation.Features.Unit.PL.PL_GenerateProposalEmail_UFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Dance Instructor Proposal Email")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_GenerateProposalEmail_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        public void DanceInstructorProposalEmail()
        {
            string[] tagsOfScenario = new string[] {
                    "Regression",
                    "PL",
                    "Staging"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dance Instructor Proposal Email", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1750 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1750.AddRow(new string[] {
                            "Dance Instructor",
                            "3",
                            "I Lease a Space From Others",
                            "",
                            "17404",
                            "PL"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1750, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1751 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table1751.AddRow(new string[] {
                            "Limited Liability Co. (LLC)",
                            "Test PL Harassment",
                            "1060 Church Rd",
                            "No"});
#line 11
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1751, "Then ");
#line hidden
#line 14
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1752 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1752.AddRow(new string[] {
                            "What year was your business started?",
                            "2020"});
                table1752.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "$400,000"});
#line 15
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1752, "Then ");
#line hidden
#line 19
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1753 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1753.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1753.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table1753.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "I Don\'t Know"});
                table1753.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 20
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1753, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1754 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1754.AddRow(new string[] {
                            "Do you sell dietary supplements, vitamins, or performance-enhancing substances?",
                            "No"});
                table1754.AddRow(new string[] {
                            "To whom do you provide training?",
                            "Group Fitness Only"});
                table1754.AddRow(new string[] {
                            "Do you help train clients for athletic competitions?",
                            "No"});
                table1754.AddRow(new string[] {
                            "Do you operate tanning beds?",
                            "No"});
                table1754.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 26
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1754, "Then ");
#line hidden
#line 33
 testRunner.Then("user verifies the appearance of the PL About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1755 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1755.AddRow(new string[] {
                            "First Name",
                            "Expert"});
                table1755.AddRow(new string[] {
                            "Last Name",
                            "Dancer"});
                table1755.AddRow(new string[] {
                            "Address",
                            "100 Test Road"});
                table1755.AddRow(new string[] {
                            "Apt/Suite",
                            ""});
                table1755.AddRow(new string[] {
                            "City",
                            "York"});
                table1755.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1755.AddRow(new string[] {
                            "Email",
                            "Expert@Dancer.com"});
                table1755.AddRow(new string[] {
                            "Business Phone",
                            "1542659875"});
                table1755.AddRow(new string[] {
                            "Ext",
                            "1217"});
                table1755.AddRow(new string[] {
                            "Website/Social",
                            ""});
                table1755.AddRow(new string[] {
                            "Have Broker",
                            "No"});
#line 34
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1755, "Then ");
#line hidden
#line 47
 testRunner.Then("user verifies the appearance of the PL Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1756 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1756.AddRow(new string[] {
                            "Deductible PO",
                            "$2,500"});
                table1756.AddRow(new string[] {
                            "Limits PO",
                            "$3,000,000"});
                table1756.AddRow(new string[] {
                            "Limits Agg",
                            "$3,000,000"});
#line 48
 testRunner.Then("user adjusts their Yearly - Standard quote with these values:", ((string)(null)), table1756, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1757 = new TechTalk.SpecFlow.Table(new string[] {
                            "DeductibleOrCoverage",
                            "Value"});
                table1757.AddRow(new string[] {
                            "Deductible PO",
                            "$2,500"});
                table1757.AddRow(new string[] {
                            "Limits PO",
                            "$3,000,000"});
                table1757.AddRow(new string[] {
                            "Limits Agg",
                            "$3,000,000"});
                table1757.AddRow(new string[] {
                            "SAbuse Agg",
                            "$250,000"});
#line 53
 testRunner.Then("user verifies that the following deductible or coverage values are displayed on t" +
                        "he Quote page:", ((string)(null)), table1757, "Then ");
#line hidden
#line 59
 testRunner.When("user emails their Standard quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
