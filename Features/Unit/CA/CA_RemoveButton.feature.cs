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
    public partial class CA_RemoveButtonFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_RemoveButton.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/CA", "CA_RemoveButton", "Using Remove Button to delete a vehicle, a driver and a driver incident, and a bu" +
                    "tton \"No, go back\" from a Removal dialog modal", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_RemoveButton")))
            {
                global::ApolloQAAutomation.Features.Unit.CA.CA_RemoveButtonFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Using Remove button and subsequently Go back button for Drivers, Incidents, and V" +
            "ehicles pages")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_RemoveButton")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        public void UsingRemoveButtonAndSubsequentlyGoBackButtonForDriversIncidentsAndVehiclesPages()
        {
            string[] tagsOfScenario = new string[] {
                    "Unit",
                    "Regression",
                    "CA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Using Remove button and subsequently Go back button for Drivers, Incidents, and V" +
                    "ehicles pages", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1485 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1485.AddRow(new string[] {
                            "Amazon Delivery Service",
                            "3",
                            "I Lease a Space From Others",
                            "Vehicles",
                            "60185",
                            "CA"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1485, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1486 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table1486.AddRow(new string[] {
                            "TEST CA AUTH QUOTE",
                            "",
                            ""});
#line 11
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table1486, "Then ");
#line hidden
#line 14
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 15
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1487 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table1487.AddRow(new string[] {
                            "2005",
                            "Corporation",
                            "100 Main St",
                            "",
                            "West Chicago",
                            ""});
#line 16
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table1487, "And ");
#line hidden
#line 19
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 20
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1488 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth"});
                table1488.AddRow(new string[] {
                            "2HGFA16517H504306",
                            "Illinois",
                            "5000"});
#line 21
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table1488, "And ");
#line hidden
                TechTalk.SpecFlow.Table table1489 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth"});
                table1489.AddRow(new string[] {
                            "JH4KA4630JC008595",
                            "Illinois",
                            "5000"});
#line 24
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table1489, "And ");
#line hidden
#line 27
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1490 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth"});
                table1490.AddRow(new string[] {
                            "KLATA52671B611178",
                            "Illinois",
                            "6000"});
#line 28
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table1490, "And ");
#line hidden
#line 31
 testRunner.Then("user clicks on Remove Vehicle button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 32
 testRunner.And("user verifies the removal modal for a vehicle with answer of No, go back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 34
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1491 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DLState",
                            "DOB",
                            "CDL",
                            "Accident",
                            "DLNumber"});
                table1491.AddRow(new string[] {
                            "John",
                            "Legend",
                            "IL",
                            "03/13/1986",
                            "No",
                            "Yes",
                            "A12345678910"});
                table1491.AddRow(new string[] {
                            "Kelly",
                            "Clarkson",
                            "IL",
                            "10/01/1990",
                            "No",
                            "Yes",
                            "B12345678910"});
#line 35
 testRunner.And("user creates a driver with these values:", ((string)(null)), table1491, "And ");
#line hidden
#line 39
    testRunner.And("user clicks on Remove Driver button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
 testRunner.And("user verifies the removal modal for a driver with answer of No, go back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 41
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
 testRunner.Then("user verifies the appearance of the Drivers Incidents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1492 = new TechTalk.SpecFlow.Table(new string[] {
                            "Driver",
                            "Date",
                            "Incident Type",
                            "At Fault"});
                table1492.AddRow(new string[] {
                            "John Legend",
                            "11/11/2021",
                            "Accident",
                            "No"});
                table1492.AddRow(new string[] {
                            "John Legend",
                            "11/12/2021",
                            "Accident",
                            "No"});
#line 43
 testRunner.Then("user adds incidents with the following values:", ((string)(null)), table1492, "Then ");
#line hidden
#line 47
 testRunner.And("user clicks on Remove Incident button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
 testRunner.And("user verifies the removal modal for an incident with answer of No, go back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
