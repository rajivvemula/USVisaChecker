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
namespace ApolloQAAutomation.Features.CommAuto.Issued.TransportationAndWarehousing_Issued
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CA_TransportationOfGoodsTerminalToTerminal_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_TransportationOfGoodsTerminalToTerminal_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Issued/TransportationAndWarehousing_Issued", "CA_TransportationOfGoodsTerminalToTerminal_I", null, ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_TransportationOfGoodsTerminalToTerminal_I")))
            {
                global::ApolloQAAutomation.Features.CommAuto.Issued.TransportationAndWarehousing_Issued.CA_TransportationOfGoodsTerminalToTerminal_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Transportation Of Goods Terminal To Terminal Issued In Georgia")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_TransportationOfGoodsTerminalToTerminal_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        public void CATransportationOfGoodsTerminalToTerminalIssuedInGeorgia()
        {
            string[] tagsOfScenario = new string[] {
                    "Issued",
                    "Regression",
                    "GA",
                    "CA",
                    "Transportation"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Transportation Of Goods Terminal To Terminal Issued In Georgia", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table410 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table410.AddRow(new string[] {
                            "Transportation of Goods: Terminal to Terminal",
                            "2",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "31093",
                            "CA"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table410, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table411 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table411.AddRow(new string[] {
                            "Georgia Transportation of Goods",
                            "GA Transportation",
                            ""});
#line 10
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table411, "Then ");
#line hidden
#line 16
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table412 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Government Entity Type",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table412.AddRow(new string[] {
                            "2012",
                            "Government Entity",
                            "Federal",
                            "1879 Watson Blvd Apt 1",
                            "",
                            "Warner Robins",
                            ""});
#line 18
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table412, "And ");
#line hidden
#line 21
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table413 = new TechTalk.SpecFlow.Table(new string[] {
                            "No VIN",
                            "Type Insure",
                            "Year",
                            "Make",
                            "Model",
                            "Parking Address",
                            "Vehicle Worth"});
                table413.AddRow(new string[] {
                            "1XKWDB9X8Y850920",
                            "Truck Tractor",
                            "2000",
                            "KENWORTH",
                            "CONSTRUCTION",
                            "Georgia",
                            "5800"});
#line 23
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table413, "And ");
#line hidden
#line 26
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table414 = new TechTalk.SpecFlow.Table(new string[] {
                            "No VIN",
                            "Type Insure",
                            "Year",
                            "Make",
                            "No Model",
                            "Trailer Address",
                            "Trailer Worth"});
                table414.AddRow(new string[] {
                            "2TLSBES87NB000753",
                            "Dry Van Trailer",
                            "2020",
                            "BIG TEX TRAILER CO INC",
                            "",
                            "Georgia",
                            "2800"});
#line 27
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table414, "And ");
#line hidden
#line 30
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 31
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table415 = new TechTalk.SpecFlow.Table(new string[] {
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
                table415.AddRow(new string[] {
                            "Donald",
                            "Duck",
                            "GA",
                            "03/13/1986",
                            "Yes 3 or more years",
                            "",
                            "",
                            "",
                            "No",
                            "147849578"});
#line 32
 testRunner.And("user creates a driver with these values:", ((string)(null)), table415, "And ");
#line hidden
#line 35
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table416 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table416.AddRow(new string[] {
                            "Do you haul intermodal containers?",
                            "No"});
                table416.AddRow(new string[] {
                            "Do you have any active Trailer Interchange Agreements?",
                            "No"});
                table416.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table416.AddRow(new string[] {
                            "Do you haul any fine art or jewelry?",
                            "No"});
                table416.AddRow(new string[] {
                            "Do you provide residential moving services?",
                            "No"});
                table416.AddRow(new string[] {
                            "Does your business engage in team driving?",
                            "No - one driver per haul"});
                table416.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table416.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table416.AddRow(new string[] {
                            "I agree to provide a claims history (also known as a \"loss run\") that matches the" +
                                " information in this application for the last 3 years within 30 days of {effecti" +
                                "ve date}.",
                            "true"});
                table416.AddRow(new string[] {
                            "Do you haul any of these? Check all that apply:",
                            ""});
                table416.AddRow(new string[] {
                            "Do you haul large equipment or machinery requiring chains to secure in transit?",
                            "No"});
                table416.AddRow(new string[] {
                            "Do you haul any hazardous materials?",
                            "No"});
                table416.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table416.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
                table416.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "No"});
#line 36
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table416, "Then ");
#line hidden
#line 53
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 54
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table417 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table417.AddRow(new string[] {
                            "First Name",
                            "Ariana"});
                table417.AddRow(new string[] {
                            "Last Name",
                            "Grande"});
                table417.AddRow(new string[] {
                            "Business Email",
                            "transportationterminaltoterminal@yopmail.com"});
                table417.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table417.AddRow(new string[] {
                            "Business Website",
                            ""});
                table417.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table417.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table417.AddRow(new string[] {
                            "Owner\'s First Name",
                            "AutoLarryzzzzzzzzzzz"});
                table417.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "AutoBarryzzzzzzzzzzzzz"});
                table417.AddRow(new string[] {
                            "Owner\'s Address",
                            "1879 Watson Blvd Apt 1"});
                table417.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table417.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "31093"});
                table417.AddRow(new string[] {
                            "Owner\'s City",
                            "Warner Robins"});
                table417.AddRow(new string[] {
                            "Owner\'s State",
                            "GA"});
#line 55
 testRunner.And("user enters contact information:", ((string)(null)), table417, "And ");
#line hidden
#line 71
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 72
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 73
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table418 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table418.AddRow(new string[] {
                            "Yearly",
                            "No"});
                table418.AddRow(new string[] {
                            "Policy Coverages",
                            "$750,000 Combined Single Limit"});
                table418.AddRow(new string[] {
                            "Vehicle 1 Coverage",
                            "$1000 Comprehensive Deductible / $1000 Collision Deductible"});
                table418.AddRow(new string[] {
                            "Vehicle 2 Coverage",
                            "No Physical Damage Coverage"});
                table418.AddRow(new string[] {
                            "Cargo Liability",
                            "$100,000 Limit / $1,000 Deductible"});
                table418.AddRow(new string[] {
                            "Trailer Interchange",
                            "$50,000 Limit / $1,000 Deductible"});
#line 74
 testRunner.And("user completes their Quote", ((string)(null)), table418, "And ");
#line hidden
                TechTalk.SpecFlow.Table table419 = new TechTalk.SpecFlow.Table(new string[] {
                            "Coverages Not Selected"});
                table419.AddRow(new string[] {
                            "Medical"});
                table419.AddRow(new string[] {
                            "Rental"});
#line 82
 testRunner.Then("user verifies the coverage details", ((string)(null)), table419, "Then ");
#line hidden
#line 86
 testRunner.Then("user clicks Get Plan from coverage details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 87
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table420 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Trim",
                            "OLF",
                            "Who Holds Vehicle"});
                table420.AddRow(new string[] {
                            "1XKWDB9X8Y850920",
                            "W900L Extended Hood",
                            "Owned",
                            "The Business"});
                table420.AddRow(new string[] {
                            "2TLSBES87NB000753",
                            "",
                            "Owned",
                            "The Business"});
#line 88
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table420, "And ");
#line hidden
#line 92
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table421 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table421.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 93
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table421, "Then ");
#line hidden
#line 96
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 97
 testRunner.Then("user verifies the Thank You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 98
 testRunner.And("user verifies the WC section on the Thank You page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
