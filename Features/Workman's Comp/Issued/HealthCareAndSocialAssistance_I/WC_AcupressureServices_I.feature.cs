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
namespace ApolloQAAutomation.Features.WorkmansComp.Issued.HealthCareAndSocialAssistance_I
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_AcupressureServices_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_AcupressureServices_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/HealthCareAndSocialAssistance_I", "WC_AcupressureServices_I", "Issuing an Acupressure Services policy \r\nZIP Code: 55406 (MN)\r\nAdditional Info pa" +
                    "ge - Verifying Excluded OO", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_AcupressureServices_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.HealthCareAndSocialAssistance_I.WC_AcupressureServices_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Acupressure Services creates issued policy in Minnesota")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_AcupressureServices_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OwnerOfficer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Health")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("MN")]
        public void WCAcupressureServicesCreatesIssuedPolicyInMinnesota()
        {
            string[] tagsOfScenario = new string[] {
                    "OwnerOfficer",
                    "Regression",
                    "WC",
                    "Issued",
                    "Health",
                    "MN"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Acupressure Services creates issued policy in Minnesota", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table2119 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2119.AddRow(new string[] {
                            "Acupressure Services",
                            "8",
                            "I Own a Property & Lease to Others",
                            "",
                            "55406",
                            "WC"});
#line 8
 testRunner.Given("user starts a quote with:", ((string)(null)), table2119, "Given ");
#line hidden
#line 11
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2120 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2120.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2120.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 9 years ago"});
                table2120.AddRow(new string[] {
                            "How is your business structured?",
                            "Limited Liability Co. (LLC)"});
                table2120.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "440440"});
                table2120.AddRow(new string[] {
                            "Business",
                            "So Much Pressure;Press Your Luck"});
                table2120.AddRow(new string[] {
                            "Address",
                            "3110 E Lake St;Minneapolis"});
                table2120.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 12
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2120, "Then ");
#line hidden
#line 21
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2121 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2121.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "4"});
                table2121.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy? State law require" +
                                "s owners/officers with less than 10% ownership to be covered.",
                            "4"});
#line 22
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2121, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2122 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name",
                            "W2 payroll",
                            "Annual Payroll"});
                table2122.AddRow(new string[] {
                            "Kirst",
                            "Nast",
                            "yes",
                            "22000"});
                table2122.AddRow(new string[] {
                            "Mc",
                            "Donald",
                            "yes",
                            "18000"});
                table2122.AddRow(new string[] {
                            "Mike",
                            "Madden",
                            "yes",
                            "25000"});
                table2122.AddRow(new string[] {
                            "Sunny",
                            "Days",
                            "yes",
                            "23000"});
#line 26
 testRunner.Then("user handles the WC Covered OO with these values:", ((string)(null)), table2122, "Then ");
#line hidden
#line 32
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2123 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2123.AddRow(new string[] {
                            "Do you provide emergency response workers to areas with disease outbreaks, catast" +
                                "rophes, or disasters?",
                            "no"});
                table2123.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2123.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2123.AddRow(new string[] {
                            "Do you use any volunteers or donated labor?",
                            "no"});
                table2123.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table2123.AddRow(new string[] {
                            "Social Security Number (SSN)",
                            "231-11-1111"});
#line 33
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2123, "Then ");
#line hidden
#line 41
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
    testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
    testRunner.Then("user verifies the WC your quote page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2124 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2124.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "1,000,000/1,000,000/1,000,000"});
#line 44
 testRunner.When("user selects a standard multi-bundle plan quote with the following customizations" +
                        " from the WC your quote page:", ((string)(null)), table2124, "When ");
#line hidden
#line 47
 testRunner.Then("user begins the WC AI page having the SSN with value 231-11-1111", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2125 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2125.AddRow(new string[] {
                            "Payment Option",
                            "20% Down + 9 Monthly Installments"});
                table2125.AddRow(new string[] {
                            "CC Name",
                            "Funky Chicken-cheese"});
                table2125.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2125.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2125.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2125.AddRow(new string[] {
                            "Autopay",
                            "No"});
                table2125.AddRow(new string[] {
                            "First Name",
                            "Funky"});
                table2125.AddRow(new string[] {
                            "Last Name",
                            "Kong"});
                table2125.AddRow(new string[] {
                            "Email",
                            "FunkyKong@Cheese.com"});
                table2125.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2125.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 49
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2125, "Then ");
#line hidden
#line 62
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 63
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.Then("user verifies that these LOBs are recommended: PL, BOP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion