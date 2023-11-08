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
namespace ApolloQAAutomation.Features.Unit.WC
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_CompanionClassWageCalc_UFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_CompanionClassWageCalc_U.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/WC", "WC_CompanionClassWageCalc_U", @"Verifies the logic for Wage page related to comapnion classes
The annual payroll for W-2 employees should be equal or above the 50,000 for companion classes payroll questions to appear
First Unit test verifies the comapnion classes payroll questions and input fields on About you page stay enabled
Second Unit test verifies the comapnion classes payroll questions and input fields on About you page becomes disabled (greyed out)", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_CompanionClassWageCalc_U")))
            {
                global::ApolloQAAutomation.Features.Unit.WC.WC_CompanionClassWageCalc_UFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Garage: Auto Repair quote issued for Cali with enabled questions and input fie" +
            "lds")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_CompanionClassWageCalc_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Cali")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Auto")]
        public void WCGarageAutoRepairQuoteIssuedForCaliWithEnabledQuestionsAndInputFields()
        {
            string[] tagsOfScenario = new string[] {
                    "Unit",
                    "WC",
                    "Cali",
                    "Regression",
                    "Auto"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Garage: Auto Repair quote issued for Cali with enabled questions and input fie" +
                    "lds", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 9
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1838 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1838.AddRow(new string[] {
                            "Garage: Auto Repair",
                            "5",
                            "I Lease a Space From Others",
                            "",
                            "90012",
                            "WC"});
#line 10
 testRunner.Given("user starts a quote with:", ((string)(null)), table1838, "Given ");
#line hidden
#line 13
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1839 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1839.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table1839.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 5 years ago"});
                table1839.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table1839.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "100000"});
                table1839.AddRow(new string[] {
                            "Do you have any auto salespersons on staff?",
                            "yes;20000"});
                table1839.AddRow(new string[] {
                            "Do any employees do any roadside assistance or towing?",
                            "yes;40000"});
                table1839.AddRow(new string[] {
                            "Do any employees only do clerical office tasks and does not write up repair estim" +
                                "ates?",
                            "yes;20000"});
                table1839.AddRow(new string[] {
                            "Business",
                            "The best garage"});
                table1839.AddRow(new string[] {
                            "Address",
                            "100 S Main St;Los Angeles"});
                table1839.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 14
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table1839, "Then ");
#line hidden
#line 26
 testRunner.And("user verifies the Wage Calculator page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table1840 = new TechTalk.SpecFlow.Table(new string[] {
                            "Average Employee Wage",
                            "Number of Employees",
                            "Hours per Week"});
                table1840.AddRow(new string[] {
                            "20",
                            "2",
                            "40"});
                table1840.AddRow(new string[] {
                            "20",
                            "1",
                            "40"});
                table1840.AddRow(new string[] {
                            "15",
                            "1",
                            "40"});
                table1840.AddRow(new string[] {
                            "15",
                            "1",
                            "40"});
#line 27
 testRunner.Then("user fills out the Wage Calculator with these values:", ((string)(null)), table1840, "Then ");
#line hidden
#line 33
 testRunner.Then("user clicks back and modify from the Payroll Calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 34
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1841 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Disabled"});
                table1841.AddRow(new string[] {
                            "Do you have any auto salespersons on staff?",
                            "not"});
                table1841.AddRow(new string[] {
                            "Do any employees do any roadside assistance or towing?",
                            "not"});
                table1841.AddRow(new string[] {
                            "Do any employees only do clerical office tasks and does not write up repair estim" +
                                "ates?",
                            "not"});
#line 35
 testRunner.Then("user verifies the following companion class payroll answers and input fields:", ((string)(null)), table1841, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Garage: Auto Repair quote issued for Cali with disabled questions and input fi" +
            "elds")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_CompanionClassWageCalc_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Cali")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Auto")]
        public void WCGarageAutoRepairQuoteIssuedForCaliWithDisabledQuestionsAndInputFields()
        {
            string[] tagsOfScenario = new string[] {
                    "Unit",
                    "WC",
                    "Cali",
                    "Regression",
                    "Auto"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Garage: Auto Repair quote issued for Cali with disabled questions and input fi" +
                    "elds", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 42
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1842 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1842.AddRow(new string[] {
                            "Garage: Auto Repair",
                            "3",
                            "I Lease a Space From Others",
                            "",
                            "90012",
                            "WC"});
#line 43
 testRunner.Given("user starts a quote with:", ((string)(null)), table1842, "Given ");
#line hidden
#line 46
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1843 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1843.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table1843.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 5 years ago"});
                table1843.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table1843.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "100000"});
                table1843.AddRow(new string[] {
                            "Do you have any auto salespersons on staff?",
                            "yes;20000"});
                table1843.AddRow(new string[] {
                            "Do any employees do any roadside assistance or towing?",
                            "yes;40000"});
                table1843.AddRow(new string[] {
                            "Do any employees only do clerical office tasks and does not write up repair estim" +
                                "ates?",
                            "yes;20000"});
                table1843.AddRow(new string[] {
                            "Business",
                            "The best garage"});
                table1843.AddRow(new string[] {
                            "Address",
                            "100 S Main St;Los Angeles"});
                table1843.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 47
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table1843, "Then ");
#line hidden
#line 59
 testRunner.And("user verifies the Wage Calculator page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table1844 = new TechTalk.SpecFlow.Table(new string[] {
                            "Average Employee Wage",
                            "Number of Employees",
                            "Hours per Week"});
                table1844.AddRow(new string[] {
                            "20",
                            "2",
                            "40"});
                table1844.AddRow(new string[] {
                            "20",
                            "1",
                            "40"});
                table1844.AddRow(new string[] {
                            "15",
                            "1",
                            "40"});
                table1844.AddRow(new string[] {
                            "15",
                            "1",
                            "40"});
#line 60
 testRunner.Then("user fills out the Wage Calculator with these values:", ((string)(null)), table1844, "Then ");
#line hidden
#line 66
    testRunner.And("user clicks continue from the Wage Calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 68
 testRunner.Then("user clicks back and modify from the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 69
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1845 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Disabled"});
                table1845.AddRow(new string[] {
                            "Do you have any auto salespersons on staff?",
                            "yes"});
                table1845.AddRow(new string[] {
                            "Do any employees do any roadside assistance or towing?",
                            "yes"});
                table1845.AddRow(new string[] {
                            "Do any employees only do clerical office tasks and does not write up repair estim" +
                                "ates?",
                            "yes"});
#line 70
 testRunner.Then("user verifies the following companion class payroll answers and input fields:", ((string)(null)), table1845, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
