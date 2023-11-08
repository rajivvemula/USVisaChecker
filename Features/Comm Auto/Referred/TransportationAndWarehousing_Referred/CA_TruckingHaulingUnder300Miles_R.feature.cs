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
namespace ApolloQAAutomation.Features.CommAuto.Referred.TransportationAndWarehousing_Referred
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CA_TruckingHaulingUnder300Miles_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_TruckingHaulingUnder300Miles_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Referred/TransportationAndWarehousing_Referred", "CA_TruckingHaulingUnder300Miles_R", "CA Trucking Hauling Under 300 Miles Referred In Missouri", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_TruckingHaulingUnder300Miles_R")))
            {
                global::ApolloQAAutomation.Features.CommAuto.Referred.TransportationAndWarehousing_Referred.CA_TruckingHaulingUnder300Miles_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Trucking Hauling Under 300 Miles Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_TruckingHaulingUnder300Miles_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("MO")]
        public void CATruckingHaulingUnder300MilesReferred()
        {
            string[] tagsOfScenario = new string[] {
                    "CA",
                    "Regression",
                    "Transportation",
                    "Referred",
                    "MO"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Trucking Hauling Under 300 Miles Referred", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table454 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table454.AddRow(new string[] {
                            "Trucking: Local Hauling: less than 300 miles",
                            "2",
                            "I Lease a Space From Others",
                            "Vehicles",
                            "65802",
                            "CA"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table454, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table455 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table455.AddRow(new string[] {
                            "Local Hauling Refer",
                            "",
                            ""});
#line 10
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table455, "Then ");
#line hidden
#line 13
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 14
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table456 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City"});
                table456.AddRow(new string[] {
                            "2005",
                            "Limited Liability Co. (LLC)",
                            "7424 W Flint St",
                            "",
                            "Springfield"});
#line 15
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table456, "And ");
#line hidden
#line 18
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 19
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table457 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Trailer Address",
                            "Trailer Worth"});
                table457.AddRow(new string[] {
                            "13N14830731017973",
                            "Missouri",
                            "2000"});
#line 20
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table457, "And ");
#line hidden
#line 23
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 24
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table458 = new TechTalk.SpecFlow.Table(new string[] {
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
                table458.AddRow(new string[] {
                            "TEST FN",
                            "TEST LN",
                            "MO",
                            "09/03/1989",
                            "No",
                            "",
                            "",
                            "",
                            "No",
                            "D123456789"});
#line 25
 testRunner.And("user creates a driver with these values:", ((string)(null)), table458, "And ");
#line hidden
#line 28
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table459 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table459.AddRow(new string[] {
                            "Do you haul intermodal containers?",
                            "No"});
                table459.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "51 to 100 miles"});
                table459.AddRow(new string[] {
                            "Do you haul any fine art or jewelry?",
                            "No"});
                table459.AddRow(new string[] {
                            "Do you provide residential moving services?",
                            "No"});
                table459.AddRow(new string[] {
                            "Does your business engage in team driving?",
                            "No - one driver per haul"});
                table459.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table459.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "5"});
                table459.AddRow(new string[] {
                            "Do you haul any of these? Check all that apply:",
                            ""});
                table459.AddRow(new string[] {
                            "Do you haul large equipment or machinery requiring chains to secure in transit?",
                            "No"});
                table459.AddRow(new string[] {
                            "Do you haul any hazardous materials?",
                            "No"});
                table459.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table459.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
                table459.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "No"});
#line 29
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table459, "Then ");
#line hidden
#line 44
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table460 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table460.AddRow(new string[] {
                            "First Name",
                            "TEST CFN"});
                table460.AddRow(new string[] {
                            "Last Name",
                            "TEST CLN"});
                table460.AddRow(new string[] {
                            "Business Email",
                            "ydwsaiq6wtn@vddaz.com"});
                table460.AddRow(new string[] {
                            "Business Phone",
                            "(123) 555-5678"});
                table460.AddRow(new string[] {
                            "Business Website",
                            ""});
                table460.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table460.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table460.AddRow(new string[] {
                            "Owner\'s First Name",
                            "TEST FN"});
                table460.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "TEST LN"});
                table460.AddRow(new string[] {
                            "Owner\'s Address",
                            "7424 W Flint St"});
                table460.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table460.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "65802"});
                table460.AddRow(new string[] {
                            "Owner\'s City",
                            "Springfield"});
                table460.AddRow(new string[] {
                            "Owner\'s State",
                            "Missouri"});
#line 45
 testRunner.And("user enters contact information:", ((string)(null)), table460, "And ");
#line hidden
#line 61
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table461 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table461.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "The Business"});
#line 62
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table461, "And ");
#line hidden
#line 65
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.And("user verifies the CA refer confirmation appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
