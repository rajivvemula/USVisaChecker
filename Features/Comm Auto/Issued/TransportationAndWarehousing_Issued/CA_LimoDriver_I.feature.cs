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
    public partial class CA_LimoDriver_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_LimoDriver_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Issued/TransportationAndWarehousing_Issued", "CA_LimoDriver_I", "Purpose: Purchase a CA policy in CA with one vehicle and no accidents/incidents.\r" +
                    "\nState: CA\r\nNumber of Vehicles: 1\r\nNumber of Trailers: 0", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_LimoDriver_I")))
            {
                global::ApolloQAAutomation.Features.CommAuto.Issued.TransportationAndWarehousing_Issued.CA_LimoDriver_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Limo Driver Issued In California")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_LimoDriver_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Cali")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        public void CALimoDriverIssuedInCalifornia()
        {
            string[] tagsOfScenario = new string[] {
                    "Issued",
                    "Regression",
                    "Cali",
                    "CA",
                    "Transportation"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Limo Driver Issued In California", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table353 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table353.AddRow(new string[] {
                            "Limo Driver",
                            "0",
                            "I Lease a Space From Others",
                            "Vehicles;Tools or Equipment",
                            "93644",
                            "CA"});
#line 9
 testRunner.Given("user starts a quote with:", ((string)(null)), table353, "Given ");
#line hidden
#line 12
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table354 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table354.AddRow(new string[] {
                            "",
                            "",
                            ""});
#line 13
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table354, "Then ");
#line hidden
#line 16
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table355 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table355.AddRow(new string[] {
                            "2012",
                            "Corporation",
                            "40112 Highway 41",
                            "",
                            "Oakhurst",
                            ""});
#line 18
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table355, "And ");
#line hidden
#line 21
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table356 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address"});
                table356.AddRow(new string[] {
                            "1J4AA2D14AL151630",
                            "California"});
#line 23
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table356, "And ");
#line hidden
#line 26
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table357 = new TechTalk.SpecFlow.Table(new string[] {
                            "No VIN",
                            "Type Insure",
                            "Year",
                            "Make",
                            "Enter Year Make Model",
                            "Trailer Address",
                            "Trailer Worth"});
                table357.AddRow(new string[] {
                            "16VDX1024L5068821",
                            "Service or Utility Trailer",
                            "2020",
                            "BIG TEX TRAILER CO INC",
                            "",
                            "California",
                            "2800"});
#line 27
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table357, "And ");
#line hidden
#line 30
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 31
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table358 = new TechTalk.SpecFlow.Table(new string[] {
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
                table358.AddRow(new string[] {
                            "Donald",
                            "Duck",
                            "CA",
                            "03/13/1986",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            ""});
#line 32
 testRunner.And("user creates a driver with these values:", ((string)(null)), table358, "And ");
#line hidden
#line 35
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table359 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table359.AddRow(new string[] {
                            "Do you offer \"party\" bus or limousine services where alcohol is provided or expre" +
                                "ssly permitted?",
                            "No"});
                table359.AddRow(new string[] {
                            "Do you provide any school, camp, day care, or field trip transportation for child" +
                                "ren 12 or younger?",
                            "No"});
                table359.AddRow(new string[] {
                            "How do your passengers access your services?",
                            "Both on demand and pre-arranged"});
                table359.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table359.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table359.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table359.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table359.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
                table359.AddRow(new string[] {
                            "Do you have or plan on applying for an operating authority from the California Pu" +
                                "blic Utilities Commission (PUC)?",
                            "Yes"});
                table359.AddRow(new string[] {
                            "Enter your California Carrier ID (TCP, PSG, VCC, or MTR):",
                            "059785"});
                table359.AddRow(new string[] {
                            "Do the owner(s) of this business have a combined majority ownership in any other " +
                                "transportation business?",
                            "No"});
#line 36
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table359, "Then ");
#line hidden
#line 49
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table360 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table360.AddRow(new string[] {
                            "First Name",
                            "Ariana"});
                table360.AddRow(new string[] {
                            "Last Name",
                            "Grande"});
                table360.AddRow(new string[] {
                            "Business Email",
                            "a@b.co"});
                table360.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table360.AddRow(new string[] {
                            "Business Website",
                            ""});
                table360.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table360.AddRow(new string[] {
                            "Owner\'s First Name",
                            "Larry"});
                table360.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "Barry"});
                table360.AddRow(new string[] {
                            "Owner\'s Address",
                            "2112 S Spring St"});
                table360.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table360.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "62704"});
                table360.AddRow(new string[] {
                            "Owner\'s City",
                            "Springfield"});
                table360.AddRow(new string[] {
                            "Owner\'s State",
                            "IL"});
#line 51
 testRunner.And("user enters contact information:", ((string)(null)), table360, "And ");
#line hidden
#line 66
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 67
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 68
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table361 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table361.AddRow(new string[] {
                            "Yearly",
                            "Yes"});
                table361.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
                table361.AddRow(new string[] {
                            "Vehicle 1 Coverage",
                            "$500 Comprehensive Deductible / $500 Collision Deductible"});
                table361.AddRow(new string[] {
                            "Medical Payments",
                            "$500"});
                table361.AddRow(new string[] {
                            "Rental Reimbursement",
                            "$30 per day/30 days/$900 total"});
#line 69
 testRunner.And("user completes their Quote", ((string)(null)), table361, "And ");
#line hidden
                TechTalk.SpecFlow.Table table362 = new TechTalk.SpecFlow.Table(new string[] {
                            "Coverages Not Selected"});
#line 76
 testRunner.Then("user verifies the coverage details", ((string)(null)), table362, "Then ");
#line hidden
#line 78
 testRunner.Then("user clicks Get Plan from coverage details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 79
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table363 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table363.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "The Business"});
                table363.AddRow(new string[] {
                            "16VDX1024L5068821",
                            "Financed",
                            ""});
#line 80
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table363, "And ");
#line hidden
#line 84
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table364 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table364.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 85
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table364, "Then ");
#line hidden
#line 88
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 89
 testRunner.Then("user verifies the Thank You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 90
 testRunner.And("user verifies the WC section on the Thank You page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion