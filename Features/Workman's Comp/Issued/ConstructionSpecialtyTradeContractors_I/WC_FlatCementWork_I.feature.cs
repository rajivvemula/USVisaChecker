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
namespace ApolloQAAutomation.Features.WorkmansComp.Issued.ConstructionSpecialtyTradeContractors_I
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_FlatCementWork_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_FlatCementWork_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/ConstructionSpecialtyTradeContractors_I", "WC_FlatCementWork_I", @"Get quote details, payment and issued policy.
Keyword: Flat Cement Work
Employee option: 3
ZIP code: 70006
Business Structured: LLC
Business Operation: I Lease a Space From Others
Business started year : Started 9 years ago
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 ", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_FlatCementWork_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.ConstructionSpecialtyTradeContractors_I.WC_FlatCementWork_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Flat Cement Work: No Self-Bearing Work policy issued in Louisiana")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_FlatCementWork_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Construction")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("LA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void WCFlatCementWorkNoSelf_BearingWorkPolicyIssuedInLouisiana()
        {
            string[] tagsOfScenario = new string[] {
                    "WC",
                    "Issued",
                    "Construction",
                    "LA",
                    "Regression",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Flat Cement Work: No Self-Bearing Work policy issued in Louisiana", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table2025 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2025.AddRow(new string[] {
                            "Flat Cement Work: No Self-Bearing Work",
                            "3",
                            "I Lease a Space From Others",
                            "",
                            "70006",
                            "WC"});
#line 14
 testRunner.Given("user starts a quote with:", ((string)(null)), table2025, "Given ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2026 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2026.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2026.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 9 years ago"});
                table2026.AddRow(new string[] {
                            "How is your business structured?",
                            "Limited Liability Co. (LLC)"});
                table2026.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "57000"});
                table2026.AddRow(new string[] {
                            "Are there any employees that never travel to job sites or do any construction wor" +
                                "k?",
                            "no"});
                table2026.AddRow(new string[] {
                            "Do you use any subcontractors or pay any workers using IRS Form 1099?",
                            "no"});
                table2026.AddRow(new string[] {
                            "Business",
                            "Celestial Echos"});
                table2026.AddRow(new string[] {
                            "Address",
                            "4901 SAINT MARY ST;Metairie"});
                table2026.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 18
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2026, "Then ");
#line hidden
#line 29
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2027 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2027.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table2027.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "0"});
#line 30
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2027, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2028 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name"});
                table2028.AddRow(new string[] {
                            "Vera",
                            "Angel"});
#line 34
 testRunner.Then("user handles the WC Excluded OO with these values:", ((string)(null)), table2028, "Then ");
#line hidden
#line 37
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2029 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2029.AddRow(new string[] {
                            "Do you build any load-bearing concrete walls?",
                            "no"});
                table2029.AddRow(new string[] {
                            "Do you do any masonry work such as manual brick or stone laying?",
                            "no"});
                table2029.AddRow(new string[] {
                            "Do you do residential foundation work?",
                            "no"});
                table2029.AddRow(new string[] {
                            "Do you ever transport six or more workers in the same vehicle?",
                            "no"});
                table2029.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2029.AddRow(new string[] {
                            "Do you perform any work over 30 feet above ground level?",
                            "no"});
                table2029.AddRow(new string[] {
                            "Do you perform any work underground including in trenches, holes, or tunnels?",
                            "no"});
                table2029.AddRow(new string[] {
                            "Do you do any demolition or wrecking of entire buildings or homes?",
                            "no"});
                table2029.AddRow(new string[] {
                            "Do the business owner(s) of this business have a combined majority ownership in a" +
                                "ny other construction business?",
                            "no"});
                table2029.AddRow(new string[] {
                            "Do you do any construction work in New York?",
                            "no"});
                table2029.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "no"});
                table2029.AddRow(new string[] {
                            "When was your last policy in effect?",
                            "Never no prior insurance"});
                table2029.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
#line 38
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2029, "Then ");
#line hidden
#line 53
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 54
    testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 55
    testRunner.Then("user verifies the WC your quote page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2030 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2030.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 56
 testRunner.When("user selects a standard single-bundle plan quote with the following customization" +
                        "s from the WC your quote page:", ((string)(null)), table2030, "When ");
#line hidden
#line 59
 testRunner.Then("user begins the WC AI page setting the FEIN with value 06-2671064", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2031 = new TechTalk.SpecFlow.Table(new string[] {
                            "Have Name"});
                table2031.AddRow(new string[] {
                            ""});
#line 60
 testRunner.Then("wc user handles 1 excluded oo with these values:", ((string)(null)), table2031, "Then ");
#line hidden
#line 63
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2032 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2032.AddRow(new string[] {
                            "Payment Option",
                            "One Pay Plan"});
                table2032.AddRow(new string[] {
                            "CC Name",
                            "Celestial Echos"});
                table2032.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2032.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2032.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2032.AddRow(new string[] {
                            "Autopay",
                            "No"});
                table2032.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table2032.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table2032.AddRow(new string[] {
                            "Email",
                            "TestFTestL@Test123.com"});
                table2032.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2032.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 64
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2032, "Then ");
#line hidden
#line 77
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 78
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
