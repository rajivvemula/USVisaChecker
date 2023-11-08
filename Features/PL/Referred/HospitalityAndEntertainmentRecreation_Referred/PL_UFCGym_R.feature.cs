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
namespace ApolloQAAutomation.Features.PL.Referred.HospitalityAndEntertainmentRecreation_Referred
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_UFCGym_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_UFCGym_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Referred/HospitalityAndEntertainmentRecreation_Referred", "PL_UFCGym_R", "UFC gym PL Referral due to having 2 claims", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_UFCGym_R")))
            {
                global::ApolloQAAutomation.Features.PL.Referred.HospitalityAndEntertainmentRecreation_Referred.PL_UFCGym_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL UFC Gym gets referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_UFCGym_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Hospitality")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        public void PLUFCGymGetsReferred()
        {
            string[] tagsOfScenario = new string[] {
                    "PL",
                    "Hospitality",
                    "Regression",
                    "Referred",
                    "Staging",
                    "Ignore"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL UFC Gym gets referred", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1154 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1154.AddRow(new string[] {
                            "UFC Gym",
                            "2",
                            "I Run My Business From Property I Own",
                            "",
                            "29209",
                            "PL"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table1154, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1155 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "DBA"});
                table1155.AddRow(new string[] {
                            "Corporation",
                            "UFC Gym",
                            "UFC Bust"});
#line 10
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1155, "Then ");
#line hidden
#line 13
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1156 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1156.AddRow(new string[] {
                            "What year was your business started?",
                            "2000"});
                table1156.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "500000"});
#line 14
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1156, "Then ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1157 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1157.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1157.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "No"});
                table1157.AddRow(new string[] {
                            "Have you had a Professional Liability (E&O) policy in the last 3 years?",
                            "Yes"});
                table1157.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "1"});
#line 19
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1157, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1158 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1158.AddRow(new string[] {
                            "Do you sell dietary supplements, vitamins, or performance-enhancing substances?",
                            "No"});
                table1158.AddRow(new string[] {
                            "To whom do you provide training?",
                            "Group Fitness Only"});
                table1158.AddRow(new string[] {
                            "Do you help train clients for athletic competitions?",
                            "Yes"});
                table1158.AddRow(new string[] {
                            "Describe the athletic competitions:",
                            "They always win"});
                table1158.AddRow(new string[] {
                            "Do you train professional athletes?",
                            "No"});
                table1158.AddRow(new string[] {
                            "What training do you provide?",
                            "Weight Training"});
                table1158.AddRow(new string[] {
                            "Do you operate tanning beds?",
                            "No"});
                table1158.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 25
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1158, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1159 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1159.AddRow(new string[] {
                            "First Name",
                            "Marty"});
                table1159.AddRow(new string[] {
                            "Last Name",
                            "Mailbox"});
                table1159.AddRow(new string[] {
                            "Address",
                            "7501 Garners Ferry Rd"});
                table1159.AddRow(new string[] {
                            "City",
                            "Columbia"});
                table1159.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1159.AddRow(new string[] {
                            "Email",
                            "test@biz.com"});
                table1159.AddRow(new string[] {
                            "Business Phone",
                            "3172491913"});
#line 35
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1159, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1160 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1160.AddRow(new string[] {
                            "Business name",
                            "Test PL API Test Case 16"});
                table1160.AddRow(new string[] {
                            "DBA",
                            "UFC Bust"});
                table1160.AddRow(new string[] {
                            "Contact first name",
                            "Test PL API"});
                table1160.AddRow(new string[] {
                            "Contact last name",
                            "Test Case 16"});
                table1160.AddRow(new string[] {
                            "Email",
                            "TestCert@Plan.com"});
                table1160.AddRow(new string[] {
                            "Phone",
                            "(123) 123-1231"});
                table1160.AddRow(new string[] {
                            "Ext",
                            "1234"});
                table1160.AddRow(new string[] {
                            "Business website",
                            "www.MixedMartialArtsTraining.com"});
#line 44
 testRunner.When("user fills out the PL refer page with these values:", ((string)(null)), table1160, "When ");
#line hidden
#line 54
 testRunner.Then("user verifies the PL refer confirmation appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion