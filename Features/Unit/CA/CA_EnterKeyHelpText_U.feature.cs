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
namespace ApolloQAAutomation.Features.Unit.CA
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CA_EnterKeyHelpText_UFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_EnterKeyHelpText_U.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/CA", "CA_EnterKeyHelpText_U", "Unit test that verifies that the help text does not appear when pressing the ente" +
                    "r key after every question, Issued in Illinois", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_EnterKeyHelpText_U")))
            {
                global::ApolloQAAutomation.Features.Unit.CA.CA_EnterKeyHelpText_UFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Enter Key Help Text Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_EnterKeyHelpText_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public void CAEnterKeyHelpTextUnit()
        {
            string[] tagsOfScenario = new string[] {
                    "Staging",
                    "Unit",
                    "Regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Enter Key Help Text Unit", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1302 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1302.AddRow(new string[] {
                            "Florist",
                            "0",
                            "I Lease a Space From Others",
                            "Vehicles",
                            "60101",
                            "CA"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1302, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1303 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table1303.AddRow(new string[] {
                            "Test CA",
                            "Test DBA",
                            ""});
#line 11
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table1303, "Then ");
#line hidden
#line 14
 testRunner.When("user presses enter after selecting each relevant field on the Let\'s Start Your Qu" +
                        "ote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 15
 testRunner.Then("user verifies that no help text messages are displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 16
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1304 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table1304.AddRow(new string[] {
                            "2015",
                            "Limited Liability Co. (LLC)",
                            "233 N Mill Rd",
                            "",
                            "Addison",
                            ""});
#line 18
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table1304, "And ");
#line hidden
#line 21
 testRunner.When("user presses enter after selecting each relevant field on the A Quick Introductio" +
                        "n page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 22
 testRunner.Then("user verifies that no help text messages are displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 23
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 24
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1305 = new TechTalk.SpecFlow.Table(new string[] {
                            "No VIN",
                            "Type Insure",
                            "Year",
                            "Make",
                            "Model",
                            "Parking Address",
                            "Vehicle Worth",
                            "How Used",
                            "Deliver Goods"});
                table1305.AddRow(new string[] {
                            "3VWCA21C9XM407107",
                            "Car - Coupe",
                            "1999",
                            "VOLKSWAGEN",
                            "New Beetle",
                            "Illinois",
                            "3000",
                            "Delivery/Catering",
                            "Yes"});
#line 25
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table1305, "And ");
#line hidden
#line 28
 testRunner.When("user presses enter after selecting each relevant field on the Your Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 29
 testRunner.Then("user verifies that no help text messages are displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 30
 testRunner.And("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 31
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1306 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DLState",
                            "DOB",
                            "Accident",
                            "DLNumber"});
                table1306.AddRow(new string[] {
                            "TEST FN",
                            "TEST LN",
                            "IL",
                            "09/01/1991",
                            "No",
                            "H11112222333"});
#line 32
 testRunner.And("user creates a driver with these values:", ((string)(null)), table1306, "And ");
#line hidden
#line 35
 testRunner.When("user presses enter after selecting each relevant field on the Your Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 36
 testRunner.Then("user verifies that no help text messages are displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.And("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table1307 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1307.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table1307.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
#line 38
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table1307, "Then ");
#line hidden
#line 42
 testRunner.When("user presses enter after selecting each relevant field on the Your Operations pag" +
                        "e", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 43
 testRunner.Then("user verifies that no help text messages are displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 44
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1308 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1308.AddRow(new string[] {
                            "First Name",
                            "TEST F"});
                table1308.AddRow(new string[] {
                            "Last Name",
                            "TEST L"});
                table1308.AddRow(new string[] {
                            "Business Email",
                            "John.Taggart@biberk.com"});
                table1308.AddRow(new string[] {
                            "Business Phone",
                            "(123) 123-1321"});
                table1308.AddRow(new string[] {
                            "Business Website",
                            "test.com"});
                table1308.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table1308.AddRow(new string[] {
                            "Owner\'s First Name",
                            "TEST FN"});
                table1308.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "TEST LN"});
                table1308.AddRow(new string[] {
                            "Owner\'s Address",
                            "530 W Stevens Dr"});
                table1308.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table1308.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "60101"});
                table1308.AddRow(new string[] {
                            "Owner\'s City",
                            "Addison"});
                table1308.AddRow(new string[] {
                            "Owner\'s State",
                            "Illinois"});
#line 45
 testRunner.And("user enters contact information:", ((string)(null)), table1308, "And ");
#line hidden
#line 60
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 61
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 62
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1309 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1309.AddRow(new string[] {
                            "Yearly",
                            "Yes"});
                table1309.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
                table1309.AddRow(new string[] {
                            "Vehicle 1 Coverage",
                            "$500 Comprehensive Deductible / $500 Collision Deductible"});
#line 63
 testRunner.And("user completes their Quote", ((string)(null)), table1309, "And ");
#line hidden
#line 68
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 69
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1310 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table1310.AddRow(new string[] {
                            "3VWCA21C9XM407107",
                            "Owned",
                            "The Business"});
#line 70
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table1310, "And ");
#line hidden
#line 73
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1311 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table1311.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 74
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table1311, "Then ");
#line hidden
#line 77
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
