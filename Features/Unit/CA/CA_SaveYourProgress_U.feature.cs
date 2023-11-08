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
    public partial class CA_SaveYourProgress_UFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_SaveYourProgress_U.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/CA", "CA_SaveYourProgress_U", "Verifying CA Save Your Progresss is pre-populated with info entered by the user", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_SaveYourProgress_U")))
            {
                global::ApolloQAAutomation.Features.Unit.CA.CA_SaveYourProgress_UFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Save Your Progress is pre-populated with info")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_SaveYourProgress_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Cali")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Transportation")]
        public void CASaveYourProgressIsPre_PopulatedWithInfo()
        {
            string[] tagsOfScenario = new string[] {
                    "Unit",
                    "Cali",
                    "CA",
                    "Transportation"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Save Your Progress is pre-populated with info", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1500 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1500.AddRow(new string[] {
                            "Hot Shot Trucking",
                            "2",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "95204",
                            "CA"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1500, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1501 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table1501.AddRow(new string[] {
                            "",
                            "",
                            ""});
#line 11
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table1501, "Then ");
#line hidden
#line 14
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 15
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1502 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City"});
                table1502.AddRow(new string[] {
                            "2012",
                            "Corporation",
                            "1687 N California St",
                            "",
                            "Stockton"});
#line 16
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table1502, "And ");
#line hidden
#line 19
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 20
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1503 = new TechTalk.SpecFlow.Table(new string[] {
                            "No VIN",
                            "Type Insure",
                            "Year",
                            "Make",
                            "Enter Year Make Model",
                            "Model",
                            "Parking Address",
                            "Vehicle Worth"});
                table1503.AddRow(new string[] {
                            "1M1AE07Y63W014598",
                            "Truck Tractor",
                            "2003",
                            "MACK",
                            "",
                            "600",
                            "California",
                            "7800"});
#line 21
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table1503, "And ");
#line hidden
#line 24
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1504 = new TechTalk.SpecFlow.Table(new string[] {
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
                table1504.AddRow(new string[] {
                            "Donald",
                            "Duck",
                            "CA",
                            "03/13/1988",
                            "Yes 3 or more years",
                            "",
                            "",
                            "",
                            "No",
                            ""});
#line 26
 testRunner.And("user creates a driver with these values:", ((string)(null)), table1504, "And ");
#line hidden
#line 29
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1505 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1505.AddRow(new string[] {
                            "Do you haul intermodal containers?",
                            "No"});
                table1505.AddRow(new string[] {
                            "Do you have any active Trailer Interchange Agreements?",
                            "No"});
                table1505.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "101 to 300 miles"});
                table1505.AddRow(new string[] {
                            "Do you haul any fine art or jewelry?",
                            "No"});
                table1505.AddRow(new string[] {
                            "Do you provide residential moving services?",
                            "No"});
                table1505.AddRow(new string[] {
                            "Does your business engage in team driving?",
                            "No - one driver per haul"});
                table1505.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table1505.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table1505.AddRow(new string[] {
                            "I agree to submit proof of insurance claims history, also known as loss runs, for" +
                                " the last 3 years within 30 days of the effective date of the policy",
                            "true"});
                table1505.AddRow(new string[] {
                            "Do you haul any of these? Check all that apply:",
                            "Building Materials;Logs (Forestry);Mobile/Manufactured Homes;Sand & Gravel"});
                table1505.AddRow(new string[] {
                            "Do you haul large equipment or machinery requiring chains to secure in transit?",
                            "No"});
                table1505.AddRow(new string[] {
                            "Do you haul any hazardous materials?",
                            "No"});
                table1505.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table1505.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "Yes"});
                table1505.AddRow(new string[] {
                            "Have you added all Owner-Operator vehicles to this quote?",
                            "Yes"});
                table1505.AddRow(new string[] {
                            "What is the annual cost for vehicles that you rent, hire, or borrow?",
                            "2800"});
                table1505.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "Yes"});
                table1505.AddRow(new string[] {
                            "Enter the USDOT number",
                            "2676783"});
                table1505.AddRow(new string[] {
                            "Do you have or plan on applying for an operating authority from the Federal Motor" +
                                " Carrier Safety Administration (FMCSA)?",
                            "Yes"});
                table1505.AddRow(new string[] {
                            "Which types of authority from FMCSA do you have or plan on having?",
                            "Contract Carrier;Common Carrier"});
                table1505.AddRow(new string[] {
                            "Do you have or plan on applying for an operating authority from the California De" +
                                "partment of Motor Vehicles?",
                            "Yes"});
                table1505.AddRow(new string[] {
                            "Enter your California Motor Carrier #:",
                            "BPYCKN"});
                table1505.AddRow(new string[] {
                            "Do the owner(s) of this business have a combined majority ownership in any other " +
                                "transportation business?",
                            "No"});
#line 30
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table1505, "Then ");
#line hidden
#line 55
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 56
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1506 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1506.AddRow(new string[] {
                            "First Name",
                            "ZZZZZLarryzzz"});
                table1506.AddRow(new string[] {
                            "Last Name",
                            "ZZZZBarryzz"});
                table1506.AddRow(new string[] {
                            "Business Email",
                            "larryzbarryzzz@b.com"});
                table1506.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table1506.AddRow(new string[] {
                            "Business Website",
                            ""});
                table1506.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table1506.AddRow(new string[] {
                            "Owner\'s First Name",
                            "ZZZZLarryzz"});
                table1506.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "ZZZBarryz"});
                table1506.AddRow(new string[] {
                            "Owner\'s Address",
                            "2112 S Spring St"});
                table1506.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table1506.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "62704"});
                table1506.AddRow(new string[] {
                            "Owner\'s City",
                            "Springfield"});
                table1506.AddRow(new string[] {
                            "Owner\'s State",
                            "IL"});
#line 57
 testRunner.And("user enters contact information:", ((string)(null)), table1506, "And ");
#line hidden
#line 72
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 73
 testRunner.Then("user verifies Save Your Progresss is pre-populated with info entered by the user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion