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
namespace ApolloQAAutomation.Features.WorkmansComp.Referred.ServiceIndustries_R
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_ActuarialServices_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_ActuarialServices_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Referred/ServiceIndustries_R", "WC_ActuarialServices_R", @"Ineligible quote: REFERRED - Potential misclassification. Submit description of ops to UW. Direct physical work is not contemplated by consultant class.
Keyword: Actuarial Services
Yes I have Employees
Number of employee : 3
Business Operation: I Work at a Job Site
ZIP Code: 17601
Included Officer: 0
Business started year : Started 8 years ago
Business Structured: Partnership", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_ActuarialServices_R")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Referred.ServiceIndustries_R.WC_ActuarialServices_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Actuarial Services gets referred due to potential misclassification")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_ActuarialServices_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        public void WCActuarialServicesGetsReferredDueToPotentialMisclassification()
        {
            string[] tagsOfScenario = new string[] {
                    "Referred",
                    "Regression",
                    "Staging",
                    "PA",
                    "Service"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Actuarial Services gets referred due to potential misclassification", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table3016 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table3016.AddRow(new string[] {
                            "Actuarial Services",
                            "3",
                            "I Work at a Job Site",
                            "",
                            "17601",
                            "WC"});
#line 14
 testRunner.Given("user starts a quote with:", ((string)(null)), table3016, "Given ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3017 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table3017.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table3017.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 8 years ago"});
                table3017.AddRow(new string[] {
                            "How is your business structured?",
                            "Partnership"});
                table3017.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "50000"});
                table3017.AddRow(new string[] {
                            "Do any employees travel frequently for sales, consultation, or auditing?",
                            "no"});
                table3017.AddRow(new string[] {
                            "Do you provide any staffing services?",
                            "no"});
                table3017.AddRow(new string[] {
                            "Business",
                            "Test refer"});
                table3017.AddRow(new string[] {
                            "Address",
                            "701 SE 71st St;Lancaster"});
                table3017.AddRow(new string[] {
                            "Contact First Name",
                            "TestF"});
                table3017.AddRow(new string[] {
                            "Contact Last Name",
                            "TestL"});
                table3017.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table3017.AddRow(new string[] {
                            "Phone",
                            "1231231231"});
                table3017.AddRow(new string[] {
                            "Business website",
                            "test.com"});
#line 18
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table3017, "Then ");
#line hidden
#line 33
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3018 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table3018.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "2"});
                table3018.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "2"});
                table3018.AddRow(new string[] {
                            "Do any included owners/officers travel frequently for sales, consultation, or aud" +
                                "iting?",
                            "No"});
#line 34
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table3018, "Then ");
#line hidden
#line 39
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3019 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table3019.AddRow(new string[] {
                            "Do you do any direct physical work such as construction, landscaping, or farming?" +
                                "",
                            "no"});
                table3019.AddRow(new string[] {
                            "Do you provide emergency response workers to areas with disease outbreaks, catast" +
                                "rophes, or disasters?",
                            "no"});
                table3019.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table3019.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
#line 40
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table3019, "Then ");
#line hidden
#line 46
 testRunner.Then("user begins the WC AI page setting the FEIN with value 832803691", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3020 = new TechTalk.SpecFlow.Table(new string[] {
                            "Set Name"});
                table3020.AddRow(new string[] {
                            "OneF OneL"});
                table3020.AddRow(new string[] {
                            "TwoF TwoL"});
#line 47
 testRunner.Then("wc user handles 2 excluded oo with these values:", ((string)(null)), table3020, "Then ");
#line hidden
#line 51
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3021 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table3021.AddRow(new string[] {
                            "Business name",
                            "Test Refer"});
                table3021.AddRow(new string[] {
                            "Contact first name",
                            "TestF"});
                table3021.AddRow(new string[] {
                            "Contact last name",
                            "TestL"});
                table3021.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table3021.AddRow(new string[] {
                            "Phone",
                            "1231231231"});
                table3021.AddRow(new string[] {
                            "Business website",
                            "www.TestPartnerCert.com"});
#line 52
 testRunner.When("user fills out the WC refer page with these values:", ((string)(null)), table3021, "When ");
#line hidden
#line 60
 testRunner.Then("user verifies the refer thank you page appears", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
