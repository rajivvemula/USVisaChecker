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
namespace ApolloQAAutomation.Features.WorkmansComp.Issued.Manufacturing_I
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_FurnitureManufacturing_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_FurnitureManufacturing_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/Manufacturing_I", "WC_FurnitureManufacturing_I", "Issued Policy for Keyword: WC Furniture Manufacturing", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_FurnitureManufacturing_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.Manufacturing_I.WC_FurnitureManufacturing_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Furniture Manufacturing Issued in Nebraska")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_FurnitureManufacturing_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Manufacturing")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NE")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void WCFurnitureManufacturingIssuedInNebraska()
        {
            string[] tagsOfScenario = new string[] {
                    "WC",
                    "Manufacturing",
                    "Regression",
                    "Issued",
                    "NE",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Furniture Manufacturing Issued in Nebraska", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table2403 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2403.AddRow(new string[] {
                            "Furniture Manufacturing",
                            "2",
                            "I Own a Property & Lease to Others",
                            "",
                            "68467",
                            "WC"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table2403, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2404 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2404.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 8 years ago"});
                table2404.AddRow(new string[] {
                            "How is your business structured?",
                            "Partnership"});
                table2404.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "500000"});
                table2404.AddRow(new string[] {
                            "Do any employees only do general office work and rarely travel?",
                            "no"});
                table2404.AddRow(new string[] {
                            "Are there any travelling sales staff that are not involved at all in the manufact" +
                                "uring process?",
                            "no"});
                table2404.AddRow(new string[] {
                            "Business",
                            ""});
                table2404.AddRow(new string[] {
                            "Address",
                            "1618 Rd N,York"});
                table2404.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 11
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2404, "Then ");
#line hidden
#line 21
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2405 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2405.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "5+"});
                table2405.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "3"});
                table2405.AddRow(new string[] {
                            "How many owners/officers do you want to exclude from this policy?",
                            "2"});
#line 22
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2405, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2406 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name",
                            "Job Duty"});
                table2406.AddRow(new string[] {
                            "FirstOne",
                            "LastOne",
                            "Manufacturer"});
                table2406.AddRow(new string[] {
                            "FirstTwo",
                            "LastTwo",
                            "Manufacturer"});
                table2406.AddRow(new string[] {
                            "FirstThree",
                            "LastThree",
                            "Manufacturer"});
#line 27
 testRunner.Then("user handles the WC Covered OO with these values:", ((string)(null)), table2406, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2407 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name"});
                table2407.AddRow(new string[] {
                            ""});
                table2407.AddRow(new string[] {
                            ""});
#line 32
 testRunner.Then("user handles the WC Excluded OO with these values:", ((string)(null)), table2407, "Then ");
#line hidden
#line 36
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.Then("user verifies the appearance of the WC Your Services Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2408 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2408.AddRow(new string[] {
                            "Do you operate a sawmill?",
                            "no"});
                table2408.AddRow(new string[] {
                            "Other than hand-held power tools, do you use any equipment or machinery?",
                            "no"});
                table2408.AddRow(new string[] {
                            "Do your employees deliver any of your finished product?",
                            "Never - 3rd party/Postal Service delivers all"});
                table2408.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2408.AddRow(new string[] {
                            "Are any employees required to physically lift/move more than 50 lbs?",
                            "no"});
                table2408.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2408.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
#line 38
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2408, "Then ");
#line hidden
#line 47
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
    testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
    testRunner.Then("user verifies the WC your quote page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2409 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2409.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "1,000,000/1,000,000/1,000,000"});
#line 50
 testRunner.When("user selects a standard multi-bundle plan quote with the following customizations" +
                        " from the WC your quote page:", ((string)(null)), table2409, "When ");
#line hidden
#line 53
 testRunner.Then("user begins the WC AI page setting the FEIN with value 12-3123124", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 54
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2410 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2410.AddRow(new string[] {
                            "Payment Option",
                            "15% Down + 9 Monthly Installments"});
                table2410.AddRow(new string[] {
                            "CC Name",
                            "Boiler Inspector Guys"});
                table2410.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2410.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2410.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2410.AddRow(new string[] {
                            "Autopay",
                            "N/A"});
                table2410.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table2410.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table2410.AddRow(new string[] {
                            "Email",
                            "TestFTestL@Test123.com"});
                table2410.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2410.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 55
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2410, "Then ");
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
