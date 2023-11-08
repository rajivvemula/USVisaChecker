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
namespace ApolloQAAutomation.Features.CommAuto.Declined.TransportationAndWarehousing_Declined
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CA_TaxicabCompanyMoreThanOneVehicle_DFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_TaxicabCompanyMoreThanOneVehicle_D.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Declined/TransportationAndWarehousing_Declined", "CA_TaxicabCompanyMoreThanOneVehicle_D", "Declined due to selecting one of the following FMCSA options: Broker, Freight For" +
                    "warding.", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_TaxicabCompanyMoreThanOneVehicle_D")))
            {
                global::ApolloQAAutomation.Features.CommAuto.Declined.TransportationAndWarehousing_Declined.CA_TaxicabCompanyMoreThanOneVehicle_DFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 5
#line hidden
            TechTalk.SpecFlow.Table table107 = new TechTalk.SpecFlow.Table(new string[] {
                        "Industry",
                        "Employees",
                        "Location",
                        "Own or Lease",
                        "ZIP Code",
                        "LOB"});
            table107.AddRow(new string[] {
                        "Taxicab company: more than one vehicle",
                        "10",
                        "I Lease a Space From Others",
                        "Vehicles",
                        "77449",
                        "CA"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table107, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table108 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name of Business",
                        "DBA",
                        "Policy Start Date"});
            table108.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 10
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table108, "Then ");
#line hidden
#line 16
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table109 = new TechTalk.SpecFlow.Table(new string[] {
                        "Year Business Started",
                        "How Business Structured",
                        "Address1",
                        "Address2",
                        "City",
                        "Select an Address"});
            table109.AddRow(new string[] {
                        "2012",
                        "Corporation",
                        "18942 Sandelford Dr",
                        "",
                        "Katy",
                        ""});
#line 18
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table109, "And ");
#line hidden
#line 21
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table110 = new TechTalk.SpecFlow.Table(new string[] {
                        "VIN",
                        "Type Insure",
                        "Parking Address",
                        "Vehicle Worth",
                        "Fare Box",
                        "Seatbelt"});
            table110.AddRow(new string[] {
                        "2L1MJ5LK0FBL00196",
                        "Limousine: seating less than 10",
                        "Texas",
                        "1500",
                        "Yes",
                        "Yes"});
#line 23
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table110, "And ");
#line hidden
#line 26
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table111 = new TechTalk.SpecFlow.Table(new string[] {
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
            table111.AddRow(new string[] {
                        "Chuck",
                        "Norris",
                        "TX",
                        "03/13/1988",
                        "",
                        "",
                        "",
                        "",
                        "No",
                        "02938544"});
#line 28
 testRunner.And("user creates a driver with these values:", ((string)(null)), table111, "And ");
#line hidden
#line 31
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Taxi Cab Company More Than One Vehicle Declined FMCSA Broker")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_TaxicabCompanyMoreThanOneVehicle_D")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Declined")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TX")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("FMCSA")]
        public void CATaxiCabCompanyMoreThanOneVehicleDeclinedFMCSABroker()
        {
            string[] tagsOfScenario = new string[] {
                    "Transportation",
                    "Declined",
                    "Regression",
                    "TX",
                    "CA",
                    "FMCSA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Taxi Cab Company More Than One Vehicle Declined FMCSA Broker", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 34
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table112 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table112.AddRow(new string[] {
                            "Do you offer \"party\" bus or limousine services where alcohol is provided or expre" +
                                "ssly permitted?",
                            "No"});
                table112.AddRow(new string[] {
                            "Do you provide any school, camp, day care, or field trip transportation for child" +
                                "ren 12 or younger?",
                            "No"});
                table112.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "51 to 100 miles"});
                table112.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table112.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table112.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table112.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
                table112.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "Yes"});
                table112.AddRow(new string[] {
                            "Enter the USDOT number",
                            "355352"});
                table112.AddRow(new string[] {
                            "Do you have or plan on applying for an operating authority from the Federal Motor" +
                                " Carrier Safety Administration (FMCSA)?",
                            "Yes"});
                table112.AddRow(new string[] {
                            "Do the owner(s) of this business have a combined majority ownership in any other " +
                                "transportation business?",
                            "No"});
                table112.AddRow(new string[] {
                            "Which types of authority from FMCSA do you have or plan on having?",
                            "Broker"});
#line 35
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table112, "Then ");
#line hidden
#line 49
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table113 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table113.AddRow(new string[] {
                            "First Name",
                            "Larry"});
                table113.AddRow(new string[] {
                            "Last Name",
                            "Barry"});
                table113.AddRow(new string[] {
                            "Business Email",
                            "a@b.com"});
                table113.AddRow(new string[] {
                            "Business Phone",
                            "5558675309"});
                table113.AddRow(new string[] {
                            "Business Website",
                            ""});
                table113.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table113.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table113.AddRow(new string[] {
                            "Owner\'s First Name",
                            "Larry"});
                table113.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "Barry"});
                table113.AddRow(new string[] {
                            "Owner\'s Address",
                            "18942 Sandelford Dr"});
                table113.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table113.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "77449"});
                table113.AddRow(new string[] {
                            "Owner\'s City",
                            "Katy"});
                table113.AddRow(new string[] {
                            "Owner\'s State",
                            "Texas"});
#line 51
 testRunner.And("user enters contact information:", ((string)(null)), table113, "And ");
#line hidden
#line 67
 testRunner.Then("user verifies the appearance of the Decline page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Taxi Cab Company More Than One Vehicle Declined FMCSA Freight Forwarding")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_TaxicabCompanyMoreThanOneVehicle_D")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Declined")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TX")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("FMCSA")]
        public void CATaxiCabCompanyMoreThanOneVehicleDeclinedFMCSAFreightForwarding()
        {
            string[] tagsOfScenario = new string[] {
                    "Transportation",
                    "Declined",
                    "Regression",
                    "TX",
                    "CA",
                    "FMCSA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Taxi Cab Company More Than One Vehicle Declined FMCSA Freight Forwarding", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 70
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table114 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table114.AddRow(new string[] {
                            "Do you offer \"party\" bus or limousine services where alcohol is provided or expre" +
                                "ssly permitted?",
                            "No"});
                table114.AddRow(new string[] {
                            "Do you provide any school, camp, day care, or field trip transportation for child" +
                                "ren 12 or younger?",
                            "No"});
                table114.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "51 to 100 miles"});
                table114.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table114.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table114.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table114.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
                table114.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "Yes"});
                table114.AddRow(new string[] {
                            "Enter the USDOT number",
                            "355352"});
                table114.AddRow(new string[] {
                            "Do you have or plan on applying for an operating authority from the Federal Motor" +
                                " Carrier Safety Administration (FMCSA)?",
                            "Yes"});
                table114.AddRow(new string[] {
                            "Which types of authority from FMCSA do you have or plan on having?",
                            "Freight Forwarding"});
                table114.AddRow(new string[] {
                            "Do the owner(s) of this business have a combined majority ownership in any other " +
                                "transportation business?",
                            "Yes"});
#line 71
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table114, "Then ");
#line hidden
#line 85
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 86
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table115 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table115.AddRow(new string[] {
                            "First Name",
                            "Larry"});
                table115.AddRow(new string[] {
                            "Last Name",
                            "Barry"});
                table115.AddRow(new string[] {
                            "Business Email",
                            "a@b.com"});
                table115.AddRow(new string[] {
                            "Business Phone",
                            "5558675309"});
                table115.AddRow(new string[] {
                            "Business Website",
                            ""});
                table115.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table115.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table115.AddRow(new string[] {
                            "Owner\'s First Name",
                            "Larry"});
                table115.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "Barry"});
                table115.AddRow(new string[] {
                            "Owner\'s Address",
                            "18942 Sandelford Dr"});
                table115.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table115.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "77449"});
                table115.AddRow(new string[] {
                            "Owner\'s City",
                            "Katy"});
                table115.AddRow(new string[] {
                            "Owner\'s State",
                            "Texas"});
#line 87
 testRunner.And("user enters contact information:", ((string)(null)), table115, "And ");
#line hidden
#line 103
 testRunner.Then("user verifies the appearance of the Decline page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion