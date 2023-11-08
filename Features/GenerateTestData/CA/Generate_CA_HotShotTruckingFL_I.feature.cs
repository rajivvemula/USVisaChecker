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
    public partial class Generate_CA_HotShotTruckingFL_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Generate_CA_HotShotTruckingFL_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/GenerateTestData/CA", "Generate_CA_HotShotTruckingFL_I", "Populate the system with testing data primarily base on most common policy types " +
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Generate_CA_HotShotTruckingFL_I")))
            {
                global::ApolloQAAutomation.Features.GenerateTestData.CA.Generate_CA_HotShotTruckingFL_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Generate CA Hot Shot Trucking successfully purchases a policy for FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Generate_CA_HotShotTruckingFL_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Generate")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        public void GenerateCAHotShotTruckingSuccessfullyPurchasesAPolicyForFL()
        {
            string[] tagsOfScenario = new string[] {
                    "Generate",
                    "CA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate CA Hot Shot Trucking successfully purchases a policy for FL", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table738 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table738.AddRow(new string[] {
                            "Hot Shot Trucking",
                            "2",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "32506",
                            "CA"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table738, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table739 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table739.AddRow(new string[] {
                            "",
                            "",
                            ""});
#line 11
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table739, "Then ");
#line hidden
#line 17
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table740 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address",
                            "Mailing Address"});
                table740.AddRow(new string[] {
                            "1900",
                            "Individual/Sole Proprietor",
                            "8423 Kause Rd",
                            "",
                            "Pensacola",
                            "",
                            "Yes"});
#line 19
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table740, "And ");
#line hidden
#line 22
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 23
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table741 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "Fifth Wheel"});
                table741.AddRow(new string[] {
                            "3D3KR19D97G838924",
                            "Florida",
                            "12000",
                            "No"});
#line 24
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table741, "And ");
#line hidden
#line 27
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table742 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth"});
                table742.AddRow(new string[] {
                            "5NMZU3LB2JH065041",
                            "Florida",
                            "10000"});
#line 28
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table742, "And ");
#line hidden
#line 31
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table743 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth"});
                table743.AddRow(new string[] {
                            "1FTNE2EW0DDA17671",
                            "Florida",
                            "10000"});
#line 32
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table743, "And ");
#line hidden
#line 35
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 36
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table744 = new TechTalk.SpecFlow.Table(new string[] {
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
                table744.AddRow(new string[] {
                            "Chris",
                            "Rock",
                            "FL",
                            "03/13/1986",
                            "Yes less than 1 year",
                            "",
                            "",
                            "",
                            "No",
                            "A000214398765"});
                table744.AddRow(new string[] {
                            "Eric",
                            "Smith",
                            "FL",
                            "04/01/1988",
                            "Yes less than 1 year",
                            "",
                            "",
                            "",
                            "No",
                            "A000214398763"});
                table744.AddRow(new string[] {
                            "Mike",
                            "Jones",
                            "FL",
                            "09/03/1989",
                            "Yes less than 1 year",
                            "",
                            "",
                            "",
                            "No",
                            "A000214398762"});
#line 37
 testRunner.And("user creates a driver with these values:", ((string)(null)), table744, "And ");
#line hidden
#line 42
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table745 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table745.AddRow(new string[] {
                            "Does your business engage in team driving?",
                            "No - one driver per haul"});
                table745.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table745.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "No"});
                table745.AddRow(new string[] {
                            "Do you haul any fine art or jewelry?",
                            "No"});
                table745.AddRow(new string[] {
                            "Do you haul intermodal containers?",
                            "No"});
                table745.AddRow(new string[] {
                            "Do you haul large equipment or machinery?",
                            "No"});
                table745.AddRow(new string[] {
                            "Do you provide residential moving services?",
                            "No"});
                table745.AddRow(new string[] {
                            "Do you haul any hazardous materials?",
                            "No"});
                table745.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table745.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table745.AddRow(new string[] {
                            "I agree to submit proof of insurance claims history, also known as loss runs, for" +
                                " the last 3 years within 30 days of the effective date of the policy",
                            "true"});
                table745.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table745.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
#line 43
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table745, "Then ");
#line hidden
#line 58
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 59
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table746 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table746.AddRow(new string[] {
                            "First Name",
                            "John"});
                table746.AddRow(new string[] {
                            "Last Name",
                            "Jones"});
                table746.AddRow(new string[] {
                            "Business Email",
                            "Auction@yopmail.com"});
                table746.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table746.AddRow(new string[] {
                            "Business Website",
                            ""});
                table746.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table746.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table746.AddRow(new string[] {
                            "Owner\'s First Name",
                            "OwnerzFirstName"});
                table746.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "OwnerzLastName"});
                table746.AddRow(new string[] {
                            "Owner\'s Address",
                            "8423 Kause Rd"});
                table746.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table746.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "32506"});
                table746.AddRow(new string[] {
                            "Owner\'s City",
                            "Pensacola"});
                table746.AddRow(new string[] {
                            "Owner\'s State",
                            "Florida"});
#line 60
 testRunner.And("user enters contact information:", ((string)(null)), table746, "And ");
#line hidden
#line 76
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 77
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table747 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table747.AddRow(new string[] {
                            "Yearly",
                            "No"});
                table747.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
#line 78
 testRunner.And("user completes their Quote", ((string)(null)), table747, "And ");
#line hidden
#line 82
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 83
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table748 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table748.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
                table748.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
                table748.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
#line 84
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table748, "And ");
#line hidden
#line 89
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table749 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table749.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 90
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table749, "Then ");
#line hidden
#line 93
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 94
 testRunner.Then("user verifies the Thank You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
