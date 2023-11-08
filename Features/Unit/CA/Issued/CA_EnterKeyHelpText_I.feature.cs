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
namespace BiBerkLOB.Features.Unit.CA.Issued
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CA_EnterKeyHelpText_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_EnterKeyHelpText_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/CA/Issued", "CA_EnterKeyHelpText_I", "Unit test that verifies that the help text does not appear when pressing the ente" +
                    "r key after every question", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_EnterKeyHelpText_I")))
            {
                global::BiBerkLOB.Features.Unit.CA.Issued.CA_EnterKeyHelpText_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA_EnterKeyHelpText")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_EnterKeyHelpText_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA_EnterKeyHelpText")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public void CA_EnterKeyHelpText()
        {
            string[] tagsOfScenario = new string[] {
                    "Staging",
                    "Unit",
                    "CA_EnterKeyHelpText",
                    "Regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA_EnterKeyHelpText", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1125 = new TechTalk.SpecFlow.Table(new string[] {
                            "Setting",
                            "Value"});
                table1125.AddRow(new string[] {
                            "CAPreventContinue",
                            "True"});
#line 7
 testRunner.Given("the following pre-test settings have been applied:", ((string)(null)), table1125, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1126 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1126.AddRow(new string[] {
                            "Florist",
                            "0",
                            "I Lease a Space From Others",
                            "Vehicles",
                            "60101",
                            "CA"});
#line 10
 testRunner.Given("user starts a quote with:", ((string)(null)), table1126, "Given ");
#line hidden
#line 13
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1127 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table1127.AddRow(new string[] {
                            "Test CA",
                            "Test DBA",
                            ""});
#line 14
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table1127, "Then ");
#line hidden
#line 17
 testRunner.When("user presses enter after selecting each relevant field on the Let\'s Start Your Qu" +
                        "ote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.Then("user verifies that no help text messages are displayed before continuing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 19
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1128 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table1128.AddRow(new string[] {
                            "2015",
                            "Limited Liability Co. (LLC)",
                            "233 N Mill Rd",
                            "",
                            "Addison",
                            ""});
#line 20
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table1128, "And ");
#line hidden
#line 23
 testRunner.When("user presses enter after selecting each relevant field on the A Quick Introductio" +
                        "n page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.Then("user verifies that no help text messages are displayed before continuing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1129 = new TechTalk.SpecFlow.Table(new string[] {
                            "No VIN",
                            "Type Insure",
                            "Year",
                            "Make",
                            "Model",
                            "Parking Address",
                            "Vehicle Worth",
                            "How Used",
                            "Deliver Goods"});
                table1129.AddRow(new string[] {
                            "3VWCA21C9XM407107",
                            "Car - Coupe",
                            "1999",
                            "VOLKSWAGEN",
                            "New Beetle",
                            "Illinois",
                            "3000",
                            "Delivery/Catering",
                            "Yes"});
#line 26
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table1129, "And ");
#line hidden
#line 29
 testRunner.When("user presses enter after selecting each relevant field on the Your Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.Then("user verifies that no help text messages are displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 31
 testRunner.And("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1130 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DLState",
                            "DOB",
                            "Accident",
                            "DLNumber"});
                table1130.AddRow(new string[] {
                            "TEST FN",
                            "TEST LN",
                            "IL",
                            "09/01/1991",
                            "No",
                            "H11112222333"});
#line 33
 testRunner.And("user creates a driver with these values:", ((string)(null)), table1130, "And ");
#line hidden
#line 36
 testRunner.When("user presses enter after selecting each relevant field on the Your Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 37
 testRunner.Then("user verifies that no help text messages are displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 38
 testRunner.And("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table1131 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1131.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table1131.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
#line 39
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table1131, "Then ");
#line hidden
#line 43
 testRunner.When("user presses enter after selecting each relevant field on the Your Operations pag" +
                        "e", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 44
 testRunner.Then("user verifies that no help text messages are displayed before continuing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1132 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1132.AddRow(new string[] {
                            "First Name",
                            "TEST F"});
                table1132.AddRow(new string[] {
                            "Last Name",
                            "TEST L"});
                table1132.AddRow(new string[] {
                            "Business Email",
                            "John.Taggart@biberk.com"});
                table1132.AddRow(new string[] {
                            "Business Phone",
                            "(123) 123-1321"});
                table1132.AddRow(new string[] {
                            "Business Website",
                            "test.com"});
                table1132.AddRow(new string[] {
                            "Owner\'s First Name",
                            "TEST FN"});
                table1132.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "TEST LN"});
                table1132.AddRow(new string[] {
                            "Owner\'s Address",
                            "530 W Stevens Dr"});
                table1132.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table1132.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "60101"});
                table1132.AddRow(new string[] {
                            "Owner\'s City",
                            "Addison"});
                table1132.AddRow(new string[] {
                            "Owner\'s State",
                            "Illinois"});
#line 45
 testRunner.And("user enters contact information:", ((string)(null)), table1132, "And ");
#line hidden
#line 59
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 60
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 61
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1133 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1133.AddRow(new string[] {
                            "Yearly",
                            "Yes"});
                table1133.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
                table1133.AddRow(new string[] {
                            "Vehicle 1 Coverage",
                            "$500 Comprehensive Deductible / $500 Collision Deductible"});
#line 62
 testRunner.And("user completes their Quote", ((string)(null)), table1133, "And ");
#line hidden
#line 67
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 68
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1134 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table1134.AddRow(new string[] {
                            "3VWCA21C9XM407107",
                            "Owned",
                            "The Business"});
#line 69
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table1134, "And ");
#line hidden
                TechTalk.SpecFlow.Table table1135 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table1135.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 72
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table1135, "Then ");
#line hidden
#line 75
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion