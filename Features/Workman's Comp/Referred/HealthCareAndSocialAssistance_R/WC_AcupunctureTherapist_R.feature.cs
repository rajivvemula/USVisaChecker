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
namespace BiBerkLOB.Features.WorkmansComp.Referred.HealthCareAndSocialAssistance_R
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_AcupunctureTherapist_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_AcupunctureTherapist_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Referred/HealthCareAndSocialAssistance_R", "WC_AcupunctureTherapist_R", @"Partial feature file for verifying the WC Your coverage requires a little special attention page.

Ineligible Quote Policy for;
Keyword: Acupunture Therapist
Reason: Number of claims specified 2 
Description: Total number of claims in past three years exceeds the threshold based on class, state, and payroll amount.
Multiple locations: Yes
Employee option: Various employees - 8
ZIPCode: 32801
Employee Payroll: 850000
Entity type: Corporation
Years in business: Started 3 years ago
Included owner officers: Yes 1", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_AcupunctureTherapist_R")))
            {
                global::BiBerkLOB.Features.WorkmansComp.Referred.HealthCareAndSocialAssistance_R.WC_AcupunctureTherapist_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC_AcupunctureTherapist_R gets referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_AcupunctureTherapist_R")]
        public void WC_AcupunctureTherapist_RGetsReferred()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC_AcupunctureTherapist_R gets referred", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1372 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1372.AddRow(new string[] {
                            "Acupuncture Therapist",
                            "8",
                            "I Lease a Space From Others",
                            "",
                            "32801",
                            "WC"});
#line 18
 testRunner.Given("user starts a quote with:", ((string)(null)), table1372, "Given ");
#line hidden
#line 21
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1373 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1373.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table1373.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 9 years ago"});
                table1373.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table1373.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "500000"});
                table1373.AddRow(new string[] {
                            "Business",
                            "Funky Chicken-cheese;FCC"});
                table1373.AddRow(new string[] {
                            "Address",
                            "120 E Pine St,;Orlando"});
                table1373.AddRow(new string[] {
                            "Contact First Name",
                            "Acupuncture"});
                table1373.AddRow(new string[] {
                            "Contact Last Name",
                            "Therapy"});
                table1373.AddRow(new string[] {
                            "Email",
                            "test@test123.com"});
                table1373.AddRow(new string[] {
                            "Phone",
                            "1212631654"});
                table1373.AddRow(new string[] {
                            "Business website",
                            "www.Acupuncture.com"});
#line 22
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table1373, "Then ");
#line hidden
#line 35
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1374 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1374.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table1374.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "1"});
#line 36
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table1374, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1375 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name",
                            "Annual Payroll"});
                table1375.AddRow(new string[] {
                            "Contact",
                            "1",
                            "50000"});
#line 40
 testRunner.Then("user handles the WC Covered OO with these values:", ((string)(null)), table1375, "Then ");
#line hidden
#line 43
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1376 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1376.AddRow(new string[] {
                            "Business name",
                            "Acupuncture Therapy"});
                table1376.AddRow(new string[] {
                            "Doing business as",
                            "AT"});
                table1376.AddRow(new string[] {
                            "Contact first name",
                            "Acupuncture"});
                table1376.AddRow(new string[] {
                            "Contact last name",
                            "Therapy"});
                table1376.AddRow(new string[] {
                            "Contact email",
                            "test@test123.com"});
                table1376.AddRow(new string[] {
                            "Contact phone",
                            "(121) 263-1654 x9874"});
                table1376.AddRow(new string[] {
                            "Business website",
                            "www.Acupuncture.com"});
#line 44
 testRunner.When("user fills out the WC refer page with these values:", ((string)(null)), table1376, "When ");
#line hidden
#line 53
 testRunner.Then("user verifies the WC refer confirmation appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
