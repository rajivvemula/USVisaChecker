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
    public partial class WC_Bulk_Hauling_Under_300_Miles_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_Bulk_Hauling_Under_300_Miles_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/TransportationAndWarehousing_I", "WC_Bulk_Hauling_Under_300_Miles_I", "Testing the Your Services questions for the keyword\r\nIssuing Bulk Hauling: under " +
                    "300 miles policy", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_Bulk_Hauling_Under_300_Miles_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.TransportationAndWarehousing_I.WC_Bulk_Hauling_Under_300_Miles_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Bulk Hauling Under 300 Miles creates an issued policy in Florida")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_Bulk_Hauling_Under_300_Miles_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void WCBulkHaulingUnder300MilesCreatesAnIssuedPolicyInFlorida()
        {
            string[] tagsOfScenario = new string[] {
                    "Transportation",
                    "WC",
                    "Issued",
                    "FL",
                    "Regression",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Bulk Hauling Under 300 Miles creates an issued policy in Florida", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table2882 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2882.AddRow(new string[] {
                            "Bulk Hauling: under 300 miles",
                            "4",
                            "I Lease a Space From Others",
                            "",
                            "33609",
                            "WC"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table2882, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2883 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2883.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2883.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 5 years ago"});
                table2883.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table2883.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "505000"});
                table2883.AddRow(new string[] {
                            "Are there any employees that do not drive and do not load/unload goods?",
                            "no"});
                table2883.AddRow(new string[] {
                            "Are there any drivers that drive trucks you own or lease but pay via 1099?",
                            "no"});
                table2883.AddRow(new string[] {
                            "Do any owner operators or sub-haulers transport goods on your behalf?",
                            "no"});
                table2883.AddRow(new string[] {
                            "Business",
                            "Super Sentai"});
                table2883.AddRow(new string[] {
                            "Address",
                            "306 N Habana Ave;Tampa"});
                table2883.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 11
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2883, "Then ");
#line hidden
#line 23
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2884 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2884.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table2884.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "0"});
#line 24
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2884, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2885 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name"});
                table2885.AddRow(new string[] {
                            "Tommy",
                            "Oliver"});
#line 28
 testRunner.Then("user handles the WC Excluded OO with these values:", ((string)(null)), table2885, "Then ");
#line hidden
#line 31
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2886 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2886.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "yes"});
                table2886.AddRow(new string[] {
                            "Enter the USDOT number:",
                            "23223"});
                table2886.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "101 - 200 miles"});
                table2886.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2886.AddRow(new string[] {
                            "Do you review MVRs for all employees with a driving exposure?",
                            "Yes at the time of hire and annually"});
                table2886.AddRow(new string[] {
                            "Do you do manual tarping?",
                            "no"});
                table2886.AddRow(new string[] {
                            "Do you transport any hazardous materials?",
                            "yes"});
                table2886.AddRow(new string[] {
                            "In the past 3 years has the DOT cited you for any out of service HazMat violation" +
                                "s?",
                            "no"});
                table2886.AddRow(new string[] {
                            "Do you haul any explosives, radioactives, or corrosives (DOT Hazard Classes 1, 7," +
                                " or 8)?",
                            "no"});
                table2886.AddRow(new string[] {
                            "Do your drivers do any manual loading/unloading of materials?",
                            "no"});
                table2886.AddRow(new string[] {
                            "Do drivers use chains to secure equipment, logs, or other large loads for transpo" +
                                "rt?",
                            "no"});
                table2886.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2886.AddRow(new string[] {
                            "Do the business owner(s) of this business have a combined majority ownership in a" +
                                "ny other transportation business?",
                            "no"});
                table2886.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table2886.AddRow(new string[] {
                            "Federal Employer Identification Number (FEIN)",
                            "23-7177659"});
#line 32
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2886, "Then ");
#line hidden
#line 49
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2887 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2887.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 51
 testRunner.When("user selects a Standard Single-Bundle plan quote with the following customization" +
                        "s from the WC your quote page:", ((string)(null)), table2887, "When ");
#line hidden
#line 54
 testRunner.Then("user begins the WC AI page having the FEIN with value 23-7177659", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2888 = new TechTalk.SpecFlow.Table(new string[] {
                            "Have Name"});
                table2888.AddRow(new string[] {
                            ""});
#line 55
 testRunner.Then("wc user handles 1 excluded oo with these values:", ((string)(null)), table2888, "Then ");
#line hidden
#line 58
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2889 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2889.AddRow(new string[] {
                            "Payment Option",
                            "25% Down + 9 Monthly Installments"});
                table2889.AddRow(new string[] {
                            "CC Name",
                            "Super Sentai"});
                table2889.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2889.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2889.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2889.AddRow(new string[] {
                            "Autopay",
                            "No"});
                table2889.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table2889.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table2889.AddRow(new string[] {
                            "Email",
                            "TestFTestL@Test123.com"});
                table2889.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2889.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
                table2889.AddRow(new string[] {
                            "Read Florida Applications?",
                            "Yes"});
                table2889.AddRow(new string[] {
                            "Read Foregoing Application?",
                            "Yes"});
#line 59
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2889, "Then ");
#line hidden
#line 74
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 75
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 76
 testRunner.Then("user verifies that these LOBs are recommended: CA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion