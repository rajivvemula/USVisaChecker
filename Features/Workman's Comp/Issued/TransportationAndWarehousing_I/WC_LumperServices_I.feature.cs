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
    public partial class WC_LumperServicesIFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_LumperServices_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/TransportationAndWarehousing_I", "WC_LumperServicesI", "Issuing a LumperServices - North Carolina Issued Policy ", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_LumperServicesI")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.TransportationAndWarehousing_I.WC_LumperServicesIFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Lumper Services issued in North Carolina")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_LumperServicesI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void WCLumperServicesIssuedInNorthCarolina()
        {
            string[] tagsOfScenario = new string[] {
                    "Service",
                    "WC",
                    "Issued",
                    "NC",
                    "Regression",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Lumper Services issued in North Carolina", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2907 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2907.AddRow(new string[] {
                            "Lumper Services",
                            "3",
                            "I Lease a Space From Others",
                            "",
                            "27601",
                            "WC"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table2907, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2908 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2908.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2908.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 9 years ago"});
                table2908.AddRow(new string[] {
                            "How is your business structured?",
                            "Limited Liability Co. (LLC)"});
                table2908.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "57000"});
                table2908.AddRow(new string[] {
                            "Do you provide any staffing services?",
                            "no"});
                table2908.AddRow(new string[] {
                            "Business",
                            "Lumper LLC;CE"});
                table2908.AddRow(new string[] {
                            "Address",
                            "128 Steese Hwy;Raleigh"});
                table2908.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 10
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2908, "Then ");
#line hidden
#line 20
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2909 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2909.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table2909.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "0"});
#line 21
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2909, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2910 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name"});
                table2910.AddRow(new string[] {
                            "Ken",
                            "Masters"});
#line 25
 testRunner.Then("user handles the WC Excluded OO with these values:", ((string)(null)), table2910, "Then ");
#line hidden
#line 28
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2911 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2911.AddRow(new string[] {
                            "Is your business in charge of getting any goods to their final destination?",
                            "No"});
                table2911.AddRow(new string[] {
                            "Do you load or unload any goods?",
                            "yes"});
                table2911.AddRow(new string[] {
                            "Do you load or unload any furniture?",
                            "yes"});
                table2911.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2911.AddRow(new string[] {
                            "Do you transport any hazardous materials?",
                            "no"});
                table2911.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2911.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table2911.AddRow(new string[] {
                            "Does your business have a state-issued experience modification factor (XMOD)?",
                            "no"});
#line 29
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2911, "Then ");
#line hidden
#line 39
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 40
 testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 41
 testRunner.Then("user verifies the WC your quote page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2912 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2912.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 42
 testRunner.When("user selects a standard single-bundle plan quote with the following customization" +
                        "s from the WC your quote page:", ((string)(null)), table2912, "When ");
#line hidden
#line 45
 testRunner.Then("user begins the WC AI page setting the FEIN with value 23-1326965", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 46
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2913 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2913.AddRow(new string[] {
                            "Payment Option",
                            "One Pay Plan"});
                table2913.AddRow(new string[] {
                            "CC Name",
                            "Young Mens Christian Association"});
                table2913.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2913.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2913.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2913.AddRow(new string[] {
                            "Autopay",
                            "N/A"});
                table2913.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table2913.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table2913.AddRow(new string[] {
                            "Email",
                            "TestFTestL@Test123.com"});
                table2913.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2913.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 47
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2913, "Then ");
#line hidden
#line 60
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 61
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion