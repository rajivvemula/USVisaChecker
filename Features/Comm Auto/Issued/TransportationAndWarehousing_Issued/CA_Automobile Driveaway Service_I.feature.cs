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
namespace BiBerkLOB.Features.CommAuto.Issued.TransportationAndWarehousing_Issued
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CA_AutomobileDriveawayService_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_Automobile Driveaway Service_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Issued/TransportationAndWarehousing_Issued", "CA_Automobile Driveaway Service_I", "Issuing a Automobile Driveway Service (Originally added to verify the Phone Exten" +
                    "sion changes)", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_Automobile Driveaway Service_I")))
            {
                global::BiBerkLOB.Features.CommAuto.Issued.TransportationAndWarehousing_Issued.CA_AutomobileDriveawayService_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Automobile Driveway Service Issuance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_Automobile Driveaway Service_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        public void AutomobileDrivewayServiceIssuance()
        {
            string[] tagsOfScenario = new string[] {
                    "Regression",
                    "Issued",
                    "Transportation",
                    "CA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Automobile Driveway Service Issuance", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table243 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table243.AddRow(new string[] {
                            "Automobile Driveaway Service",
                            "3",
                            "I Own a Property & Lease to Others",
                            "Vehicles",
                            "86506",
                            "CA"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table243, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table244 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table244.AddRow(new string[] {
                            "",
                            "",
                            ""});
#line 11
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table244, "Then ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table245 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address",
                            "Mailing Address"});
                table245.AddRow(new string[] {
                            "2020",
                            "Corporation",
                            "147 S Frontage Rd",
                            "B",
                            "Houck",
                            "Original",
                            "No"});
#line 18
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table245, "And ");
#line hidden
#line 21
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table246 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address"});
                table246.AddRow(new string[] {
                            "ZHWUS4ZF6KLA11669",
                            "Arizona"});
#line 22
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table246, "And ");
#line hidden
#line 25
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 26
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table247 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DLState",
                            "DOB",
                            "CDL",
                            "Accident",
                            "DLNumber"});
                table247.AddRow(new string[] {
                            "Speed",
                            "Racer",
                            "AZ",
                            "09/23/1967",
                            "Yes 3 or more years",
                            "No",
                            "S14265987"});
#line 27
 testRunner.And("user creates a driver with these values:", ((string)(null)), table247, "And ");
#line hidden
#line 30
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table248 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table248.AddRow(new string[] {
                            "Do you haul intermodal containers?",
                            "No"});
                table248.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table248.AddRow(new string[] {
                            "Do you haul any fine art or jewelry?",
                            "No"});
                table248.AddRow(new string[] {
                            "Do you provide residential moving services?",
                            "No"});
                table248.AddRow(new string[] {
                            "Does your business engage in team driving?",
                            "No - one driver per haul"});
                table248.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table248.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table248.AddRow(new string[] {
                            "I agree to submit proof of insurance claims history, also known as loss runs, for" +
                                " the last 3 years within 30 days of the effective date of the policy",
                            "true"});
                table248.AddRow(new string[] {
                            "Do you haul any of these? Check all that apply:",
                            ""});
                table248.AddRow(new string[] {
                            "Do you haul large equipment or machinery requiring chains to secure in transit?",
                            "No"});
                table248.AddRow(new string[] {
                            "Do you haul any hazardous materials?",
                            "No"});
                table248.AddRow(new string[] {
                            "Do you rent, hire, or borrow any vehicles?",
                            "No"});
                table248.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
                table248.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "No"});
#line 31
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table248, "Then ");
#line hidden
#line 47
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table249 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table249.AddRow(new string[] {
                            "First Name",
                            "Speed"});
                table249.AddRow(new string[] {
                            "Last Name",
                            "Racer"});
                table249.AddRow(new string[] {
                            "Business has an account manager",
                            "Yes"});
                table249.AddRow(new string[] {
                            "Business Email",
                            "Speed@Racer.com"});
                table249.AddRow(new string[] {
                            "Business Phone",
                            "(555) 777-5309"});
                table249.AddRow(new string[] {
                            "Business Ext",
                            "7777"});
                table249.AddRow(new string[] {
                            "Business Website",
                            "SpeedRacer.com"});
                table249.AddRow(new string[] {
                            "Manager\'s First Name",
                            "Chim"});
                table249.AddRow(new string[] {
                            "Manager\'s Last Name",
                            "Chim"});
                table249.AddRow(new string[] {
                            "Manager\'s Email",
                            "ChimChim@Racer.com"});
                table249.AddRow(new string[] {
                            "Manager\'s Phone",
                            "(555) 777-7412"});
                table249.AddRow(new string[] {
                            "Manager\'s Ext",
                            "3071"});
                table249.AddRow(new string[] {
                            "Owner\'s First Name",
                            "Pops"});
                table249.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "Racer"});
                table249.AddRow(new string[] {
                            "Owner\'s Address",
                            "147 S Frontage Rd"});
                table249.AddRow(new string[] {
                            "Owner\'s Address 2",
                            "B"});
                table249.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "86506"});
                table249.AddRow(new string[] {
                            "Owner\'s City",
                            "Houck"});
                table249.AddRow(new string[] {
                            "Owner\'s State",
                            "Arizona"});
                table249.AddRow(new string[] {
                            "Select an Address",
                            "Original"});
#line 49
 testRunner.And("user enters contact information:", ((string)(null)), table249, "And ");
#line hidden
#line 71
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 72
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table250 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table250.AddRow(new string[] {
                            "Yearly",
                            "No"});
                table250.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
                table250.AddRow(new string[] {
                            "Vehicle 1 Coverage",
                            "$1000 Comprehensive Deductible / $1000 Collision Deductible"});
#line 73
 testRunner.And("user completes their Quote", ((string)(null)), table250, "And ");
#line hidden
#line 78
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 79
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table251 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table251.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "The Business"});
#line 80
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table251, "And ");
#line hidden
                TechTalk.SpecFlow.Table table252 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table252.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 83
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table252, "Then ");
#line hidden
#line 86
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 87
 testRunner.Then("user verifies the Thank You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 88
 testRunner.And("user verifies the WC section on the Thank You page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
