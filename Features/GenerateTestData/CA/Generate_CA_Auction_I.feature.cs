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
namespace ApolloQAAutomation.Features.GenerateTestData.CA
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class Generate_CA_Auction_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Generate_CA_Auction_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/GenerateTestData/CA", "Generate_CA_Auction_I", "Populate the system with testing data primarily base on most common policy types " +
                    "per book of business.", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Generate_CA_Auction_I")))
            {
                global::ApolloQAAutomation.Features.GenerateTestData.CA.Generate_CA_Auction_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Generate CA Auction successfully purchases a policy for GA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Generate_CA_Auction_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Generate")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        public void GenerateCAAuctionSuccessfullyPurchasesAPolicyForGA()
        {
            string[] tagsOfScenario = new string[] {
                    "Generate",
                    "CA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate CA Auction successfully purchases a policy for GA", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table555 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table555.AddRow(new string[] {
                            "Auction",
                            "2",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "31419",
                            "CA"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table555, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table556 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table556.AddRow(new string[] {
                            "",
                            "",
                            ""});
#line 11
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table556, "Then ");
#line hidden
#line 17
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table557 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address",
                            "Mailing Address"});
                table557.AddRow(new string[] {
                            "1900",
                            "Individual/Sole Proprietor",
                            "321 Tanglewood Rd",
                            "",
                            "Savannah",
                            "",
                            "Yes"});
#line 19
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table557, "And ");
#line hidden
#line 22
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 23
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table558 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "Plowing Snow"});
                table558.AddRow(new string[] {
                            "3D3KR19D97G838924",
                            "Georgia",
                            "12000",
                            "No"});
#line 24
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table558, "And ");
#line hidden
#line 27
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table559 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Plowing Snow"});
                table559.AddRow(new string[] {
                            "5NMZU3LB2JH065041",
                            "Georgia",
                            "No"});
#line 28
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table559, "And ");
#line hidden
#line 31
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table560 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "Plowing Snow"});
                table560.AddRow(new string[] {
                            "1FTNE2EW0DDA17671",
                            "Georgia",
                            "10000",
                            "No"});
#line 32
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table560, "And ");
#line hidden
#line 35
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 36
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table561 = new TechTalk.SpecFlow.Table(new string[] {
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
                table561.AddRow(new string[] {
                            "Chris",
                            "Rock",
                            "GA",
                            "03/13/1986",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "214398765"});
                table561.AddRow(new string[] {
                            "Eric",
                            "Smith",
                            "GA",
                            "04/01/1988",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "214398763"});
                table561.AddRow(new string[] {
                            "Mike",
                            "Jones",
                            "GA",
                            "09/03/1989",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "214398762"});
#line 37
 testRunner.And("user creates a driver with these values:", ((string)(null)), table561, "And ");
#line hidden
#line 42
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table562 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table562.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table562.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
#line 43
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table562, "Then ");
#line hidden
#line 47
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table563 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table563.AddRow(new string[] {
                            "First Name",
                            "Lawrence"});
                table563.AddRow(new string[] {
                            "Last Name",
                            "Michaels"});
                table563.AddRow(new string[] {
                            "Business Email",
                            "Auction@yopmail.com"});
                table563.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table563.AddRow(new string[] {
                            "Business Website",
                            ""});
                table563.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table563.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table563.AddRow(new string[] {
                            "Owner\'s First Name",
                            "AutoLarryzzzzzzzzzzz"});
                table563.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "AutoBarryzzzzzzzzzzzzz"});
                table563.AddRow(new string[] {
                            "Owner\'s Address",
                            "321 Tanglewood Rd"});
                table563.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table563.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "31419"});
                table563.AddRow(new string[] {
                            "Owner\'s City",
                            "Savannah"});
                table563.AddRow(new string[] {
                            "Owner\'s State",
                            "Georgia"});
#line 49
 testRunner.And("user enters contact information:", ((string)(null)), table563, "And ");
#line hidden
#line 65
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table564 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table564.AddRow(new string[] {
                            "Yearly",
                            "No"});
                table564.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
#line 67
 testRunner.And("user completes their Quote", ((string)(null)), table564, "And ");
#line hidden
#line 71
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 72
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table565 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table565.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
                table565.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
                table565.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
#line 73
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table565, "And ");
#line hidden
#line 78
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table566 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table566.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 79
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table566, "Then ");
#line hidden
#line 82
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 83
 testRunner.Then("user verifies the Thank You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion