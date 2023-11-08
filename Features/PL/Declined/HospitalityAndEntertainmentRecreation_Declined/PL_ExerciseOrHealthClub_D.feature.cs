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
namespace ApolloQAAutomation.Features.PL.Declined.HospitalityAndEntertainmentRecreation_Declined
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_ExerciseOrHealthClub_DFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_ExerciseOrHealthClub_D.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Declined/HospitalityAndEntertainmentRecreation_Declined", "PL_ExerciseOrHealthClub_D", "Exercise or Health Club: What training do you provide?", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_ExerciseOrHealthClub_D")))
            {
                global::ApolloQAAutomation.Features.PL.Declined.HospitalityAndEntertainmentRecreation_Declined.PL_ExerciseOrHealthClub_DFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Exercise Or HealthClub gets declined")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_ExerciseOrHealthClub_D")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        public void PLExerciseOrHealthClubGetsDeclined()
        {
            string[] tagsOfScenario = new string[] {
                    "Regression",
                    "PL"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Exercise Or HealthClub gets declined", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table870 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table870.AddRow(new string[] {
                            "Exercise or Health Club",
                            "2",
                            "I Lease a Space From Others",
                            "",
                            "08234",
                            "PL"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table870, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table871 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table871.AddRow(new string[] {
                            "Corporation",
                            "Healthclub",
                            "7017 Fernwood Ave",
                            "No"});
#line 10
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table871, "Then ");
#line hidden
#line 13
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table872 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table872.AddRow(new string[] {
                            "What year was your business started?",
                            "2010"});
                table872.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "50000"});
#line 14
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table872, "Then ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table873 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table873.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table873.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "No"});
                table873.AddRow(new string[] {
                            "Have you had a Professional Liability (E&O) policy in the last 3 years?",
                            "No"});
#line 19
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table873, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table874 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table874.AddRow(new string[] {
                            "Do you sell dietary supplements, vitamins, or performance-enhancing substances?",
                            "No"});
                table874.AddRow(new string[] {
                            "To whom do you provide training?",
                            "Group Fitness Only"});
                table874.AddRow(new string[] {
                            "Do you help train clients for athletic competitions?",
                            "No"});
                table874.AddRow(new string[] {
                            "What training do you provide?",
                            "Rock Climbing"});
                table874.AddRow(new string[] {
                            "Do you operate tanning beds?",
                            "No"});
                table874.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 24
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table874, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table875 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table875.AddRow(new string[] {
                            "First Name",
                            "Test"});
                table875.AddRow(new string[] {
                            "Last Name",
                            "EJ"});
                table875.AddRow(new string[] {
                            "Address",
                            "7017 Fernwood Ave"});
                table875.AddRow(new string[] {
                            "Apt/Suite",
                            "3"});
                table875.AddRow(new string[] {
                            "City",
                            "Egg Harbor Township"});
                table875.AddRow(new string[] {
                            "Use as Mailing Address",
                            "No"});
                table875.AddRow(new string[] {
                            "Mailing Address",
                            "7017 Fernwood Ave"});
                table875.AddRow(new string[] {
                            "Mailing Apt/Suite",
                            "3"});
                table875.AddRow(new string[] {
                            "Mailing ZIP",
                            "08234"});
                table875.AddRow(new string[] {
                            "Mailing City",
                            "Egg Harbor Township"});
                table875.AddRow(new string[] {
                            "Email",
                            "abc@bargain.com"});
                table875.AddRow(new string[] {
                            "Business Phone",
                            "1231231212"});
                table875.AddRow(new string[] {
                            "Ext",
                            "123"});
                table875.AddRow(new string[] {
                            "Website/Social",
                            "www.tester.com"});
#line 32
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table875, "Then ");
#line hidden
#line 48
 testRunner.Then("user verifies the PL decline page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
