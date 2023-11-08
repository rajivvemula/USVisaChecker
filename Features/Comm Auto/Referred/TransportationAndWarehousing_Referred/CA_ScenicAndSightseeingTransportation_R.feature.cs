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
    public partial class CA_ScenicAndSightseeingTransportation_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_ScenicAndSightseeingTransportation_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Referred/TransportationAndWarehousing_Referred", "CA_ScenicAndSightseeingTransportation_R", @"verify the new refferal reason due to US 38007
Referral reason : ""Initial Premium over $70,000""
If the cost is under $70k and add vehicle/driver makes it go over - it WILL refer.
Initial premium is less than $70k, however material changes (adding vehicles or drivers) are made bumping premium >= $70k----> Refer", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_ScenicAndSightseeingTransportation_R")))
            {
                global::ApolloQAAutomation.Features.CommAuto.Referred.TransportationAndWarehousing_Referred.CA_ScenicAndSightseeingTransportation_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Scenic And Sightseeing Transportation Referred Over 70k")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_ScenicAndSightseeingTransportation_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TX")]
        public void CAScenicAndSightseeingTransportationReferredOver70K()
        {
            string[] tagsOfScenario = new string[] {
                    "CA",
                    "Regression",
                    "Transportation",
                    "Referred",
                    "TX"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Scenic And Sightseeing Transportation Referred Over 70k", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 9
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table446 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table446.AddRow(new string[] {
                            "Scenic and Sightseeing Transportation",
                            "2",
                            "I Lease a Space From Others",
                            "Vehicles",
                            "76226",
                            "CA"});
#line 10
 testRunner.Given("user starts a quote with:", ((string)(null)), table446, "Given ");
#line hidden
#line 13
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table447 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table447.AddRow(new string[] {
                            "ScenicSights Transportation",
                            "",
                            ""});
#line 14
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table447, "Then ");
#line hidden
#line 17
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table448 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City"});
                table448.AddRow(new string[] {
                            "2005",
                            "Limited Liability Co. (LLC)",
                            "2516 Basswood Dr",
                            "",
                            "Argyle"});
#line 19
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table448, "And ");
#line hidden
#line 22
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 23
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table449 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Trailer Address",
                            "Trailer Worth"});
                table449.AddRow(new string[] {
                            "13N14830731017973",
                            "Texas",
                            "76000"});
#line 24
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table449, "And ");
#line hidden
#line 27
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 28
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table450 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DLState",
                            "DOB",
                            "Accident",
                            "DLNumber"});
                table450.AddRow(new string[] {
                            "TEST FN",
                            "TEST LN",
                            "TX",
                            "09/03/1989",
                            "No",
                            "01234568"});
#line 29
 testRunner.And("user creates a driver with these values:", ((string)(null)), table450, "And ");
#line hidden
#line 32
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table451 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table451.AddRow(new string[] {
                            "Do you offer \"party\" bus or limousine services where alcohol is provided or expre" +
                                "ssly permitted?",
                            "No"});
                table451.AddRow(new string[] {
                            "Do you provide any school, camp, day care, or field trip transportation for child" +
                                "ren 12 or younger?",
                            "No"});
                table451.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "51 to 100 miles"});
                table451.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table451.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "5"});
                table451.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table451.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
#line 33
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table451, "Then ");
#line hidden
#line 42
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table452 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table452.AddRow(new string[] {
                            "First Name",
                            "TEST CFN"});
                table452.AddRow(new string[] {
                            "Last Name",
                            "TEST CLN"});
                table452.AddRow(new string[] {
                            "Business Email",
                            "ydwsaiq6wtn@vddaz.com"});
                table452.AddRow(new string[] {
                            "Business Phone",
                            "(123) 555-5678"});
                table452.AddRow(new string[] {
                            "Business Website",
                            ""});
                table452.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table452.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table452.AddRow(new string[] {
                            "Owner\'s First Name",
                            "TEST FN"});
                table452.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "TEST LN"});
                table452.AddRow(new string[] {
                            "Owner\'s Address",
                            "7424 W Flint St"});
                table452.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table452.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "65802"});
                table452.AddRow(new string[] {
                            "Owner\'s City",
                            "Springfield"});
                table452.AddRow(new string[] {
                            "Owner\'s State",
                            "Missouri"});
#line 43
 testRunner.And("user enters contact information:", ((string)(null)), table452, "And ");
#line hidden
#line 59
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table453 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table453.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "The Business"});
#line 60
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table453, "And ");
#line hidden
#line 63
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.And("user verifies the CA refer confirmation appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion