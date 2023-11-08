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
    public partial class WC_EventPlanner_NoCatering_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_EventPlanner_NoCatering_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/ServiceIndustries_I", "WC_EventPlanner_NoCatering_I", "Issuing an Event Planner No Catering policy ", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_EventPlanner_NoCatering_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.ServiceIndustries_I.WC_EventPlanner_NoCatering_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Event Planner No Catering policy issued for Kansas")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_EventPlanner_NoCatering_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("KS")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void WCEventPlannerNoCateringPolicyIssuedForKansas()
        {
            string[] tagsOfScenario = new string[] {
                    "Service",
                    "WC",
                    "Issued",
                    "KS",
                    "Regression",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Event Planner No Catering policy issued for Kansas", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table2719 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2719.AddRow(new string[] {
                            "Event Planner: No Catering",
                            "3",
                            "I Lease a Space From Others",
                            "",
                            "67476",
                            "WC"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table2719, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2720 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2720.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2720.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 9 years ago"});
                table2720.AddRow(new string[] {
                            "How is your business structured?",
                            "Limited Liability Co. (LLC)"});
                table2720.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "57000"});
                table2720.AddRow(new string[] {
                            "Do any employees help set up/install items such as furniture, lighting, stages, o" +
                                "r tents?",
                            "no"});
                table2720.AddRow(new string[] {
                            "Do any employees travel frequently for sales, consultation, or auditing?",
                            "no"});
                table2720.AddRow(new string[] {
                            "Do you provide any staffing services?",
                            "no"});
                table2720.AddRow(new string[] {
                            "Do you make any payments to workers using IRS Form 1099?",
                            "no"});
                table2720.AddRow(new string[] {
                            "Business",
                            "2Nite Events LLC;CE"});
                table2720.AddRow(new string[] {
                            "Address",
                            "108 South St;Roxbury"});
                table2720.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 11
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2720, "Then ");
#line hidden
#line 24
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2721 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2721.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table2721.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "0"});
#line 25
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2721, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2722 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name"});
                table2722.AddRow(new string[] {
                            "Vera",
                            "Angel"});
#line 29
 testRunner.Then("user handles the WC Excluded OO with these values:", ((string)(null)), table2722, "Then ");
#line hidden
#line 32
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2723 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2723.AddRow(new string[] {
                            "Do you help set up furniture or install any sound or lighting at events?",
                            "No"});
                table2723.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2723.AddRow(new string[] {
                            "Do you do any caving, rock climbing, or white water rafting?",
                            "no"});
                table2723.AddRow(new string[] {
                            "Do you do fishing or hunting activities?",
                            "no"});
                table2723.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
#line 33
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2723, "Then ");
#line hidden
#line 40
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 41
 testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
 testRunner.Then("user verifies the WC your quote page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2724 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2724.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 43
 testRunner.When("user selects a standard single-bundle plan quote with the following customization" +
                        "s from the WC your quote page:", ((string)(null)), table2724, "When ");
#line hidden
#line 46
 testRunner.Then("user begins the WC AI page setting the FEIN with value 23-1965495", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2725 = new TechTalk.SpecFlow.Table(new string[] {
                            "Have Name"});
                table2725.AddRow(new string[] {
                            "Vera Angel"});
#line 47
 testRunner.Then("wc user handles 1 excluded oo with these values:", ((string)(null)), table2725, "Then ");
#line hidden
#line 50
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2726 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2726.AddRow(new string[] {
                            "Payment Option",
                            "One Pay Plan"});
                table2726.AddRow(new string[] {
                            "CC Name",
                            "Young Mens Christian Association"});
                table2726.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2726.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2726.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2726.AddRow(new string[] {
                            "Autopay",
                            "N/A"});
                table2726.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table2726.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table2726.AddRow(new string[] {
                            "Email",
                            "TestFTestL@Test123.com"});
                table2726.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2726.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 51
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2726, "Then ");
#line hidden
#line 64
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 65
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.Then("user verifies that these LOBs are recommended: PL,BOP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion