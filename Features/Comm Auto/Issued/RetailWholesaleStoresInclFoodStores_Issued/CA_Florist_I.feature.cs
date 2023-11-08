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
namespace ApolloQAAutomation.Features.CommAuto.Issued.RetailWholesaleStoresInclFoodStores_Issued
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CA_Florist_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_Florist_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Issued/RetailWholesaleStoresInclFoodStores_Issued", "CA_Florist_I", "Testing the Save for Later modal as well as completing a Illinois run.", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_Florist_I")))
            {
                global::ApolloQAAutomation.Features.CommAuto.Issued.RetailWholesaleStoresInclFoodStores_Issued.CA_Florist_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Florist Issued In Illinois")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_Florist_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("IL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Retail")]
        public void CAFloristIssuedInIllinois()
        {
            string[] tagsOfScenario = new string[] {
                    "Issued",
                    "Regression",
                    "IL",
                    "CA",
                    "Retail"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Florist Issued In Illinois", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table195 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table195.AddRow(new string[] {
                            "Florist",
                            "5",
                            "I Own a Property & Lease to Others",
                            "Vehicles",
                            "60007",
                            "CA"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table195, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table196 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table196.AddRow(new string[] {
                            "TEST CA AUTH QUOTE",
                            "",
                            ""});
#line 11
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table196, "Then ");
#line hidden
#line 17
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table197 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table197.AddRow(new string[] {
                            "2005",
                            "Individual/Sole Proprietor",
                            "175 N Arlington Heights Rd",
                            "",
                            "Elk Grove Village",
                            ""});
#line 19
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table197, "And ");
#line hidden
#line 22
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 23
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table198 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "How Used",
                            "Deliver Goods"});
                table198.AddRow(new string[] {
                            "4T1G11AK3NU618541",
                            "Illinois",
                            "Errands only - no Delivery/Catering",
                            "No"});
#line 24
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table198, "And ");
#line hidden
#line 27
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 28
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table199 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DLState",
                            "DOB",
                            "Accident",
                            "DLNumber"});
                table199.AddRow(new string[] {
                            "TEST FN",
                            "TEST LN",
                            "IL",
                            "04/11/1981",
                            "No",
                            "x12345678901"});
#line 29
 testRunner.And("user creates a driver with these values:", ((string)(null)), table199, "And ");
#line hidden
#line 32
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table200 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table200.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table200.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
#line 33
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table200, "Then ");
#line hidden
#line 37
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 38
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table201 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table201.AddRow(new string[] {
                            "First Name",
                            "TEST FN"});
                table201.AddRow(new string[] {
                            "Last Name",
                            "TEST LN"});
                table201.AddRow(new string[] {
                            "Business Email",
                            "QAAutomation@biberk.com"});
                table201.AddRow(new string[] {
                            "Business Phone",
                            "(657) 478-4378"});
                table201.AddRow(new string[] {
                            "Business Website",
                            ""});
                table201.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table201.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table201.AddRow(new string[] {
                            "Owner\'s First Name",
                            "TEST FN"});
                table201.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "TEST LN"});
                table201.AddRow(new string[] {
                            "Owner\'s Address",
                            "175 N Arlington Heights Rd"});
                table201.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table201.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "60007"});
                table201.AddRow(new string[] {
                            "Owner\'s City",
                            "Elk Grove Village"});
                table201.AddRow(new string[] {
                            "Owner\'s State",
                            "IL"});
#line 39
 testRunner.And("user enters contact information:", ((string)(null)), table201, "And ");
#line hidden
#line 55
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 56
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 57
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table202 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table202.AddRow(new string[] {
                            "Yearly",
                            "Yes"});
                table202.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
                table202.AddRow(new string[] {
                            "Vehicle 1 Coverage",
                            "$500 Comprehensive Deductible / $500 Collision Deductible"});
#line 58
 testRunner.And("user completes their Quote", ((string)(null)), table202, "And ");
#line hidden
                TechTalk.SpecFlow.Table table203 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table203.AddRow(new string[] {
                            "Bodily Injury and Property Damage Liability",
                            "Yes"});
                table203.AddRow(new string[] {
                            "Uninsured/Underinsured Motorist",
                            "Yes"});
                table203.AddRow(new string[] {
                            "Comp/Collision (One Vehicle)",
                            "Yes"});
                table203.AddRow(new string[] {
                            "Medical Payments",
                            "No"});
                table203.AddRow(new string[] {
                            "Rental Reimbursement",
                            "No"});
#line 63
 testRunner.Then("user verifies proposal email modal", ((string)(null)), table203, "Then ");
#line hidden
#line 70
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 71
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table204 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table204.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
#line 72
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table204, "And ");
#line hidden
#line 75
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table205 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table205.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 76
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table205, "Then ");
#line hidden
#line 79
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Florist Issued In Illinois With Optional Autopay")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_Florist_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Florist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("IL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Retail")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        public void CAFloristIssuedInIllinoisWithOptionalAutopay()
        {
            string[] tagsOfScenario = new string[] {
                    "Florist",
                    "Issued",
                    "Regression",
                    "IL",
                    "CA",
                    "Retail",
                    "Staging"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Florist Issued In Illinois With Optional Autopay", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 83
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table206 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table206.AddRow(new string[] {
                            "Florist",
                            "0",
                            "I Lease a Space From Others",
                            "Vehicles",
                            "60101",
                            "CA"});
#line 84
 testRunner.Given("user starts a quote with:", ((string)(null)), table206, "Given ");
#line hidden
#line 87
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table207 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table207.AddRow(new string[] {
                            "TEST CA",
                            "TEST DBA",
                            ""});
#line 88
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table207, "Then ");
#line hidden
#line 91
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 92
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table208 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table208.AddRow(new string[] {
                            "2015",
                            "Limited Liability Co. (LLC)",
                            "233 N Mill Rd",
                            "",
                            "Addison",
                            ""});
#line 93
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table208, "And ");
#line hidden
#line 96
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 97
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table209 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "How Used",
                            "Deliver Goods"});
                table209.AddRow(new string[] {
                            "3VWCA21C9XM407107",
                            "Illinois",
                            "3000",
                            "Delivery/Catering",
                            "Yes"});
#line 98
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table209, "And ");
#line hidden
#line 101
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 102
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table210 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DLState",
                            "DOB",
                            "Accident",
                            "DLNumber"});
                table210.AddRow(new string[] {
                            "TestF",
                            "TestL",
                            "IL",
                            "09/01/1991",
                            "No",
                            "H11112222333"});
#line 103
 testRunner.And("user creates a driver with these values:", ((string)(null)), table210, "And ");
#line hidden
#line 106
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table211 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table211.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table211.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
#line 107
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table211, "Then ");
#line hidden
#line 111
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 112
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table212 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table212.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table212.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table212.AddRow(new string[] {
                            "Business Email",
                            "qaautomation@biberk.com"});
                table212.AddRow(new string[] {
                            "Business Phone",
                            "(123) 123-1321"});
                table212.AddRow(new string[] {
                            "Business Website",
                            ""});
                table212.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table212.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table212.AddRow(new string[] {
                            "Owner\'s First Name",
                            "TestF"});
                table212.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "TestL"});
                table212.AddRow(new string[] {
                            "Owner\'s Address",
                            "530 W Stevens Dr"});
                table212.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table212.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "60101"});
                table212.AddRow(new string[] {
                            "Owner\'s City",
                            "Addison"});
                table212.AddRow(new string[] {
                            "Owner\'s State",
                            "Illinois"});
#line 113
 testRunner.And("user enters contact information:", ((string)(null)), table212, "And ");
#line hidden
#line 129
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 130
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 131
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table213 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table213.AddRow(new string[] {
                            "Yearly",
                            "No"});
                table213.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
                table213.AddRow(new string[] {
                            "Vehicle 1 Coverage",
                            "$500 Comprehensive Deductible / $500 Collision Deductible"});
#line 132
 testRunner.And("user completes their Quote", ((string)(null)), table213, "And ");
#line hidden
#line 137
 testRunner.Then("user verifies the current price is more than $1,000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 138
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 139
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table214 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table214.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "The Business"});
#line 140
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table214, "And ");
#line hidden
#line 143
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table215 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type",
                            "Autopay"});
                table215.AddRow(new string[] {
                            "12 Monthly",
                            "Visa",
                            "Optional Choose On"});
#line 144
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table215, "Then ");
#line hidden
#line 147
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 148
 testRunner.Then("user verifies the Thank You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 149
 testRunner.And("user verifies the BOP section on the Thank You page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion