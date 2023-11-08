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
namespace ApolloQAAutomation.Features.WorkmansComp.Referred.TransportationAndWarehousing_R
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_TaxicabMoreThanOneVehicle_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_TaxicabMoreThanOneVehicle_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Referred/TransportationAndWarehousing_R", "WC_TaxicabMoreThanOneVehicle_R", @"Ineligible quote: Refer as exposure base is number of vehicles if not using w-2 payroll for the employee drivers. 
Applies in most states, generally it is around $60k but please check state bureaus before calculating actual remuneration., StateLevel-DirectSalesOK=N. .
Keyword: Taxicab company: more than one vehicle
Employee option: Yes Ihave employee
How many employee: 2
Business Operation: I Lease a Space From Others
How many vehicle:6", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_TaxicabMoreThanOneVehicle_R")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Referred.TransportationAndWarehousing_R.WC_TaxicabMoreThanOneVehicle_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Taxicab Company More Than One Vehicle is referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_TaxicabMoreThanOneVehicle_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NJ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public void WCTaxicabCompanyMoreThanOneVehicleIsReferred()
        {
            string[] tagsOfScenario = new string[] {
                    "Transportation",
                    "WC",
                    "Referred",
                    "NJ",
                    "Regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Taxicab Company More Than One Vehicle is referred", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table3039 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table3039.AddRow(new string[] {
                            "Taxicab company: more than one vehicle",
                            "2",
                            "I Lease a Space From Others",
                            "",
                            "19808",
                            "WC"});
#line 12
 testRunner.Given("user starts a quote with:", ((string)(null)), table3039, "Given ");
#line hidden
#line 15
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3040 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table3040.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table3040.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 2 years ago"});
                table3040.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table3040.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "80000"});
                table3040.AddRow(new string[] {
                            "Do any employees only do general office work and rarely travel?",
                            "no"});
                table3040.AddRow(new string[] {
                            "Business",
                            "Taxicab company"});
                table3040.AddRow(new string[] {
                            "Address",
                            "2106 Walmsley Dr;Wilmington"});
                table3040.AddRow(new string[] {
                            "Contact First Name",
                            "TestF"});
                table3040.AddRow(new string[] {
                            "Contact Last Name",
                            "TestL"});
                table3040.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table3040.AddRow(new string[] {
                            "Phone",
                            "1231231321"});
                table3040.AddRow(new string[] {
                            "Business website",
                            "test.com"});
#line 16
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table3040, "Then ");
#line hidden
#line 30
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3041 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table3041.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "2"});
                table3041.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "2"});
                table3041.AddRow(new string[] {
                            "Do any included owners/officers only do general office work and rarely travel?",
                            "No"});
#line 31
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table3041, "Then ");
#line hidden
#line 36
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3042 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table3042.AddRow(new string[] {
                            "How many vehicles do you own that are operated by employees?",
                            "6"});
                table3042.AddRow(new string[] {
                            "Do you lease or rent out any vehicles to any non-employees?",
                            "no"});
                table3042.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table3042.AddRow(new string[] {
                            "Do you pay any drivers via 1099 that use their own vehicle?",
                            "no"});
                table3042.AddRow(new string[] {
                            "Do you review MVRs for all employees with a driving exposure?",
                            "No"});
                table3042.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table3042.AddRow(new string[] {
                            "Do the business owner(s) of this business have a combined majority ownership in a" +
                                "ny other transportation business?",
                            "no"});
                table3042.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
#line 37
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table3042, "Then ");
#line hidden
#line 47
 testRunner.Then("user begins the WC AI page setting the FEIN with value 63-1212123", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.Then("wc user handles 2 covered oo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3043 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table3043.AddRow(new string[] {
                            "Business name",
                            "Taxicab company"});
                table3043.AddRow(new string[] {
                            "Contact first name",
                            "TestF"});
                table3043.AddRow(new string[] {
                            "Contact last name",
                            "TestL"});
                table3043.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table3043.AddRow(new string[] {
                            "Phone",
                            "(123) 123-1321"});
                table3043.AddRow(new string[] {
                            "Business website",
                            "www.TestPartnerCert.com"});
#line 50
 testRunner.When("user fills out the WC refer page with these values:", ((string)(null)), table3043, "When ");
#line hidden
#line 58
 testRunner.Then("user verifies the refer thank you page appears", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
