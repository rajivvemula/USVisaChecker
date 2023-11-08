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
namespace ApolloQAAutomation.Features.WorkmansComp.Issued.ServiceIndustries_I
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_BoilerInspection_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_BoilerInspection_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/ServiceIndustries_I", "WC_BoilerInspection_I", "Issuing a Boiler Inspection policy", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_BoilerInspection_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.ServiceIndustries_I.WC_BoilerInspection_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Boiler Inspection Issuing a policy for Illinois")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_BoilerInspection_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("IL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void WCBoilerInspectionIssuingAPolicyForIllinois()
        {
            string[] tagsOfScenario = new string[] {
                    "Service",
                    "WC",
                    "Issued",
                    "IL",
                    "Regression",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Boiler Inspection Issuing a policy for Illinois", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table2656 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2656.AddRow(new string[] {
                            "Boiler Inspection",
                            "4",
                            "I Own a Property & Lease to Others",
                            "",
                            "61752",
                            "WC"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table2656, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2657 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2657.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2657.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 10 years or more ago"});
                table2657.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table2657.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "50,000"});
                table2657.AddRow(new string[] {
                            "Do any employees only do general office work and rarely travel?",
                            "no"});
                table2657.AddRow(new string[] {
                            "Do you use any subcontractors or pay any workers using IRS Form 1099?",
                            "no"});
                table2657.AddRow(new string[] {
                            "Business",
                            "Boiler Inspector Guys;BIG"});
                table2657.AddRow(new string[] {
                            "Address",
                            "501 E Elm St;Le Roy"});
                table2657.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 11
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2657, "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2658 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2658.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table2658.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "1"});
                table2658.AddRow(new string[] {
                            "Do any included owners/officers only do general office work and rarely travel?",
                            "No"});
#line 23
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2658, "Then ");
#line hidden
#line 28
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2659 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2659.AddRow(new string[] {
                            "Do you do any boiler inspections for commercial, industrial, or multi-family resi" +
                                "dences?",
                            "no"});
                table2659.AddRow(new string[] {
                            "Do you travel to damaged properties to adjust claims?",
                            "no"});
                table2659.AddRow(new string[] {
                            "Do you do any installation, repair, or damage restoration services?",
                            "no"});
                table2659.AddRow(new string[] {
                            "Do you do any asbestos inspection?",
                            "no"});
                table2659.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2659.AddRow(new string[] {
                            "Do you perform any work over 30 feet above ground level?",
                            "no"});
                table2659.AddRow(new string[] {
                            "Do you inspect any roofs?",
                            "yes"});
                table2659.AddRow(new string[] {
                            "Do you set up emergency tarping or repair roofs?",
                            "no"});
                table2659.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2659.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table2659.AddRow(new string[] {
                            "Federal Employer Identification Number (FEIN)",
                            "23-1326965"});
#line 29
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2659, "Then ");
#line hidden
#line 42
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
 testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2660 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2660.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 44
 testRunner.When("user selects a Plus plan quote with the following customizations from the WC your" +
                        " quote page:", ((string)(null)), table2660, "When ");
#line hidden
#line 47
 testRunner.Then("user begins the WC AI page having the FEIN with value 23-1326965", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.Then("wc user handles 1 covered oo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2661 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2661.AddRow(new string[] {
                            "Payment Option",
                            "15% Down + 9 Monthly Installments"});
                table2661.AddRow(new string[] {
                            "CC Name",
                            "Boiler Inspector Guys"});
                table2661.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2661.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2661.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2661.AddRow(new string[] {
                            "Autopay",
                            "N/A"});
                table2661.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table2661.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table2661.AddRow(new string[] {
                            "Email",
                            "TestFTestL@Test123.com"});
                table2661.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2661.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 50
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2661, "Then ");
#line hidden
#line 63
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 65
 testRunner.Then("user verifies that these LOBs are recommended: PL,BOP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion