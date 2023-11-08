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
namespace ApolloQAAutomation.Features.WorkmansComp.Issued.TransportationAndWarehousing_I
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_CharterBusService_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_CharterBusService_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/TransportationAndWarehousing_I", "WC_CharterBusService_I", "Issuing a Charter Bus Service policy", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_CharterBusService_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.TransportationAndWarehousing_I.WC_CharterBusService_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Charter Bus Service creates issued policy in Montana")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_CharterBusService_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("MT")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void WCCharterBusServiceCreatesIssuedPolicyInMontana()
        {
            string[] tagsOfScenario = new string[] {
                    "Transportation",
                    "WC",
                    "Issued",
                    "MT",
                    "Regression",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Charter Bus Service creates issued policy in Montana", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table2890 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2890.AddRow(new string[] {
                            "Charter Bus Service",
                            "10",
                            "I Work at a Job Site",
                            "",
                            "59901",
                            "WC"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table2890, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2891 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2891.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2891.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 4 years ago"});
                table2891.AddRow(new string[] {
                            "How is your business structured?",
                            "Partnership"});
                table2891.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "250000"});
                table2891.AddRow(new string[] {
                            "Do any employees do any maintenance, repair, or service on motor vehicles?",
                            "no"});
                table2891.AddRow(new string[] {
                            "Do any employees only do general office work and rarely travel?",
                            "no"});
                table2891.AddRow(new string[] {
                            "Business",
                            "Git\'U\'Dere"});
                table2891.AddRow(new string[] {
                            "Address",
                            "1004 6th Ave W;Kalispell"});
                table2891.AddRow(new string[] {
                            "Contact First Name",
                            "TestF"});
                table2891.AddRow(new string[] {
                            "Contact Last Name",
                            "TestL"});
                table2891.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table2891.AddRow(new string[] {
                            "Phone",
                            "1231233333"});
                table2891.AddRow(new string[] {
                            "Business website",
                            "test.com"});
#line 11
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2891, "Then ");
#line hidden
#line 26
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2892 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2892.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "2"});
                table2892.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "2"});
#line 27
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2892, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2893 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name",
                            "W2 payroll",
                            "Annual Payroll",
                            "Job Duty"});
                table2893.AddRow(new string[] {
                            "Kaladin",
                            "Stormblessed",
                            "yes",
                            "22000",
                            "Driver or Mechanic"});
                table2893.AddRow(new string[] {
                            "Shallan",
                            "Davar",
                            "yes",
                            "25000",
                            "General Office Worker"});
#line 31
 testRunner.Then("user handles the WC Covered OO with these values:", ((string)(null)), table2893, "Then ");
#line hidden
#line 35
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2894 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2894.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "0 - 50 miles"});
                table2894.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2894.AddRow(new string[] {
                            "Do you review MVRs for all employees with a driving exposure?",
                            "No"});
                table2894.AddRow(new string[] {
                            "Do drivers assist any handicapped passengers with entering or exiting the vehicle" +
                                "?",
                            "no"});
                table2894.AddRow(new string[] {
                            "Are your employees engaged in the unloading/loading of any passenger luggage?",
                            "yes"});
                table2894.AddRow(new string[] {
                            "Do you mainly transport customers to, from, or within an airport such as a shuttl" +
                                "e service?",
                            "yes"});
                table2894.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2894.AddRow(new string[] {
                            "Do the business owner(s) of this business have a combined majority ownership in a" +
                                "ny other transportation business?",
                            "no"});
                table2894.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table2894.AddRow(new string[] {
                            "Federal Employer Identification Number (FEIN)",
                            "832803691"});
#line 36
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2894, "Then ");
#line hidden
#line 48
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2895 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2895.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 50
 testRunner.When("user selects a plus plan quote with the following customizations from the WC your" +
                        " quote page:", ((string)(null)), table2895, "When ");
#line hidden
#line 53
 testRunner.Then("user begins the WC AI page having the FEIN with value 83-2803691", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 54
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2896 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2896.AddRow(new string[] {
                            "Payment Option",
                            "10% Down + 10 Monthly Installments"});
                table2896.AddRow(new string[] {
                            "CC Name",
                            "Funky Chicken-cheese"});
                table2896.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2896.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2896.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2896.AddRow(new string[] {
                            "Autopay",
                            "No"});
                table2896.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table2896.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table2896.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table2896.AddRow(new string[] {
                            "Phone",
                            "1231233333"});
                table2896.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 55
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2896, "Then ");
#line hidden
#line 68
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 69
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
