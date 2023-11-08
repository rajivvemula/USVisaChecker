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
    public partial class WC_LyftDriver_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_LyftDriver_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/TransportationAndWarehousing_I", "WC_LyftDriver_I", "Issuing a Lyft Driver policy\r\nZipcode:10001", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_LyftDriver_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.TransportationAndWarehousing_I.WC_LyftDriver_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Lyft Driver creates an isued policy in NY")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_LyftDriver_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NY")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void WCLyftDriverCreatesAnIsuedPolicyInNY()
        {
            string[] tagsOfScenario = new string[] {
                    "Transportation",
                    "WC",
                    "Issued",
                    "NY",
                    "Regression",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Lyft Driver creates an isued policy in NY", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table2914 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2914.AddRow(new string[] {
                            "Lyft Driver",
                            "4",
                            "I Lease a Space From Others",
                            "",
                            "10001",
                            "WC"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table2914, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2915 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2915.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2915.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 5 years ago"});
                table2915.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table2915.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "505000"});
                table2915.AddRow(new string[] {
                            "Do any employees do any maintenance, repair, or service on motor vehicles?",
                            "no"});
                table2915.AddRow(new string[] {
                            "Do any employees only do general office work and rarely travel?",
                            "no"});
                table2915.AddRow(new string[] {
                            "Business",
                            "Lyft Driver"});
                table2915.AddRow(new string[] {
                            "Address",
                            "550 W 25th St;New York"});
                table2915.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 11
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2915, "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2916 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2916.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table2916.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "0"});
#line 23
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2916, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2917 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name"});
                table2917.AddRow(new string[] {
                            "Tommy",
                            "Oliver"});
#line 27
 testRunner.Then("user handles the WC Excluded OO with these values:", ((string)(null)), table2917, "Then ");
#line hidden
#line 30
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2918 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2918.AddRow(new string[] {
                            "How many vehicles do you own that are operated by employees?",
                            "0"});
                table2918.AddRow(new string[] {
                            "Do you lease or rent out any vehicles to any non-employees?",
                            "no"});
                table2918.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2918.AddRow(new string[] {
                            "Do you pay any drivers via 1099 that use their own vehicle?",
                            "no"});
                table2918.AddRow(new string[] {
                            "Do you review MVRs for all employees with a driving exposure?",
                            "No"});
                table2918.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "no"});
                table2918.AddRow(new string[] {
                            "When was your last policy in effect?",
                            "Never no prior insurance"});
                table2918.AddRow(new string[] {
                            "Do the business owner(s) of this business have a combined majority ownership in a" +
                                "ny other transportation business?",
                            "no"});
                table2918.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
#line 31
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2918, "Then ");
#line hidden
#line 42
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
 testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2919 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2919.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 44
 testRunner.When("user selects a Standard Single-Bundle plan quote with the following customization" +
                        "s from the WC your quote page:", ((string)(null)), table2919, "When ");
#line hidden
#line 47
 testRunner.Then("user begins the WC AI page setting the FEIN with value 23-7177659IV", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2920 = new TechTalk.SpecFlow.Table(new string[] {
                            "Have Name"});
                table2920.AddRow(new string[] {
                            ""});
#line 48
 testRunner.Then("wc user handles 1 excluded oo with these values:", ((string)(null)), table2920, "Then ");
#line hidden
#line 51
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2921 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2921.AddRow(new string[] {
                            "Payment Option",
                            "25% Down + 6 Monthly Installments"});
                table2921.AddRow(new string[] {
                            "CC Name",
                            "Lyft Driver"});
                table2921.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2921.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2921.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2921.AddRow(new string[] {
                            "Autopay",
                            "No"});
                table2921.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table2921.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table2921.AddRow(new string[] {
                            "Email",
                            "TestFTestL@Test123.com"});
                table2921.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2921.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 52
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2921, "Then ");
#line hidden
#line 65
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion