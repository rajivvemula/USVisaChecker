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
    public partial class CA_NoPP_UFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_NoPP_U.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/CA", "CA_NoPP_U", "Purpose: Verify the apperance and function of the No PP page.\r\nState: SC\r\nNumber " +
                    "of Vehicles: 1\r\nNumber of Trailers: 0", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_NoPP_U")))
            {
                global::ApolloQAAutomation.Features.Unit.CA.CA_NoPP_UFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA No PP Page Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_NoPP_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Auto")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        public void CANoPPPageUnit()
        {
            string[] tagsOfScenario = new string[] {
                    "Regression",
                    "CA",
                    "Auto",
                    "Unit"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA No PP Page Unit", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1358 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1358.AddRow(new string[] {
                            "Trucking: Long Distance Hauling: more than 300 miles",
                            "2",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "29209",
                            "CA"});
#line 9
 testRunner.Given("user starts a quote with:", ((string)(null)), table1358, "Given ");
#line hidden
#line 12
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1359 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table1359.AddRow(new string[] {
                            "",
                            "",
                            ""});
#line 13
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table1359, "Then ");
#line hidden
#line 16
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1360 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table1360.AddRow(new string[] {
                            "2012",
                            "Corporation",
                            "7501 Garners Ferry Rd",
                            "",
                            "Columbia",
                            ""});
#line 18
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table1360, "And ");
#line hidden
#line 21
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1361 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth"});
                table1361.AddRow(new string[] {
                            "5TDDK3DCXGS129517",
                            "South Carolina",
                            "2800"});
#line 23
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table1361, "And ");
#line hidden
#line 26
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1362 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DLState",
                            "DOB",
                            "CDL",
                            "ILDDC",
                            "ILViolation",
                            "ILDLRevoked",
                            "Accident",
                            "DLNumber"});
                table1362.AddRow(new string[] {
                            "Aubrey",
                            "Plaza",
                            "SC",
                            "03/13/1985",
                            "Yes 3 or more years",
                            "",
                            "",
                            "",
                            "No",
                            "098657477"});
                table1362.AddRow(new string[] {
                            "Anna",
                            "Kendrick",
                            "SC",
                            "01/30/2000",
                            "Yes 3 or more years",
                            "",
                            "",
                            "",
                            "No",
                            "123574987"});
                table1362.AddRow(new string[] {
                            "Emma",
                            "Stone",
                            "SC",
                            "08/11/1993",
                            "Yes 3 or more years",
                            "",
                            "",
                            "",
                            "No",
                            "048798455"});
#line 28
 testRunner.And("user creates a driver with these values:", ((string)(null)), table1362, "And ");
#line hidden
#line 33
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1363 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1363.AddRow(new string[] {
                            "Do you haul intermodal containers?",
                            "No"});
                table1363.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table1363.AddRow(new string[] {
                            "Do you haul any fine art or jewelry?",
                            "No"});
                table1363.AddRow(new string[] {
                            "Do you provide residential moving services?",
                            "No"});
                table1363.AddRow(new string[] {
                            "Does your business engage in team driving?",
                            "Yes we do some team driving"});
                table1363.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table1363.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table1363.AddRow(new string[] {
                            "I agree to submit proof of insurance claims history, also known as loss runs, for" +
                                " the last 3 years within 30 days of the effective date of the policy",
                            "true"});
                table1363.AddRow(new string[] {
                            "Do you haul large equipment or machinery requiring chains to secure in transit?",
                            "No"});
                table1363.AddRow(new string[] {
                            "Do you haul any hazardous materials?",
                            "No"});
                table1363.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table1363.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
                table1363.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "No"});
#line 34
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table1363, "Then ");
#line hidden
#line 49
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1364 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1364.AddRow(new string[] {
                            "First Name",
                            "Ariana"});
                table1364.AddRow(new string[] {
                            "Last Name",
                            "Grande"});
                table1364.AddRow(new string[] {
                            "Business Email",
                            "a@b.co"});
                table1364.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table1364.AddRow(new string[] {
                            "Business Website",
                            ""});
                table1364.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table1364.AddRow(new string[] {
                            "Manager\'s First Name",
                            ""});
                table1364.AddRow(new string[] {
                            "Manager\'s Last Name",
                            ""});
                table1364.AddRow(new string[] {
                            "Manager\'s Email",
                            ""});
                table1364.AddRow(new string[] {
                            "Manager\'s Phone",
                            ""});
                table1364.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table1364.AddRow(new string[] {
                            "Owner\'s First Name",
                            "Larry"});
                table1364.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "Barry"});
                table1364.AddRow(new string[] {
                            "Owner\'s Address",
                            "2112 S Spring St"});
                table1364.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table1364.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "62704"});
                table1364.AddRow(new string[] {
                            "Owner\'s City",
                            "Springfield"});
                table1364.AddRow(new string[] {
                            "Owner\'s State",
                            "Illinois"});
#line 51
 testRunner.And("user enters contact information:", ((string)(null)), table1364, "And ");
#line hidden
#line 71
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 72
 testRunner.Then("user forces No PP Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 73
 testRunner.Then("user verifies No PP page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
