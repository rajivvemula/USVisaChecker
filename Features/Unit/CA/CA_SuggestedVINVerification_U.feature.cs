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
    public partial class CA_SuggestedVINVerification_UFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_SuggestedVINVerification_U.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Unit/CA", "CA_SuggestedVINVerification_U", "Suggested VIN and Original VIN verification on Summary Page", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_SuggestedVINVerification_U")))
            {
                global::ApolloQAAutomation.Features.Unit.CA.CA_SuggestedVINVerification_UFeature.FeatureSetup(null);
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
            TechTalk.SpecFlow.Table table1523 = new TechTalk.SpecFlow.Table(new string[] {
                        "Industry",
                        "Employees",
                        "Location",
                        "Own or Lease",
                        "ZIP Code",
                        "LOB"});
            table1523.AddRow(new string[] {
                        "Uber Driver",
                        "2",
                        "I Run My Business From Property I Own",
                        "Vehicles",
                        "37211",
                        "CA"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table1523, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1524 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name of Business",
                        "DBA",
                        "Policy Start Date"});
            table1524.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 10
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table1524, "Then ");
#line hidden
#line 13
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 14
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1525 = new TechTalk.SpecFlow.Table(new string[] {
                        "Year Business Started",
                        "How Business Structured",
                        "Address1",
                        "Address2",
                        "City",
                        "Select an Address"});
            table1525.AddRow(new string[] {
                        "1980",
                        "Individual/Sole Proprietor",
                        "708 Misty Pines Cir",
                        "",
                        "Nashville",
                        ""});
#line 15
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table1525, "And ");
#line hidden
#line 18
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 19
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Suggested VIN Verification Unit Summary Page Original VIN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_SuggestedVINVerification_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SuggestedVIN")]
        public void CASuggestedVINVerificationUnitSummaryPageOriginalVIN()
        {
            string[] tagsOfScenario = new string[] {
                    "Unit",
                    "CA",
                    "SuggestedVIN"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Suggested VIN Verification Unit Summary Page Original VIN", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
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
                TechTalk.SpecFlow.Table table1526 = new TechTalk.SpecFlow.Table(new string[] {
                            "Suggested VIN",
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "Type Insure",
                            "Year",
                            "Make",
                            "Model",
                            "Fare Box"});
                table1526.AddRow(new string[] {
                            "Original",
                            "JH4DA1745GP002661",
                            "Tennessee",
                            "12000",
                            "Car - Sedan",
                            "1986",
                            "ACURA",
                            "INTEGRA",
                            "No"});
#line 23
 testRunner.Then("user creates a vehicle or trailer with variable values:", ((string)(null)), table1526, "Then ");
#line hidden
#line 26
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1527 = new TechTalk.SpecFlow.Table(new string[] {
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
                table1527.AddRow(new string[] {
                            "Anna",
                            "Kendrick",
                            "TN",
                            "03/13/1986",
                            "",
                            "",
                            "",
                            "",
                            "Yes",
                            "147849578"});
#line 28
 testRunner.And("user creates a driver with these values:", ((string)(null)), table1527, "And ");
#line hidden
#line 31
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 32
 testRunner.Then("user verifies the appearance of the Drivers Incidents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1528 = new TechTalk.SpecFlow.Table(new string[] {
                            "Driver",
                            "Date",
                            "Incident Type",
                            "At Fault"});
                table1528.AddRow(new string[] {
                            "Anna Kendrick",
                            "11/11/2021",
                            "Accident",
                            "No"});
#line 33
 testRunner.Then("user adds incidents with the following values:", ((string)(null)), table1528, "Then ");
#line hidden
#line 36
 testRunner.Then("user continues to the Operations page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1529 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1529.AddRow(new string[] {
                            "Do you offer \"party\" bus or limousine services where alcohol is provided or expre" +
                                "ssly permitted?",
                            "No"});
                table1529.AddRow(new string[] {
                            "Do you provide any school, camp, day care, or field trip transportation for child" +
                                "ren 12 or younger?",
                            "No"});
                table1529.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table1529.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table1529.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table1529.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table1529.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
#line 37
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table1529, "Then ");
#line hidden
#line 46
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 47
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1530 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1530.AddRow(new string[] {
                            "First Name",
                            "Ariana"});
                table1530.AddRow(new string[] {
                            "Last Name",
                            "Grande"});
                table1530.AddRow(new string[] {
                            "Business Email",
                            "chauffeur@yopmail.com"});
                table1530.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table1530.AddRow(new string[] {
                            "Business Website",
                            ""});
                table1530.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table1530.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table1530.AddRow(new string[] {
                            "Owner\'s First Name",
                            "AutoLarryzzzzzzzzzzz"});
                table1530.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "AutoBarryzzzzzzzzzzzzz"});
                table1530.AddRow(new string[] {
                            "Owner\'s Address",
                            "1879 Watson Blvd Apt 1"});
                table1530.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table1530.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "31093"});
                table1530.AddRow(new string[] {
                            "Owner\'s City",
                            "warner robins"});
                table1530.AddRow(new string[] {
                            "Owner\'s State",
                            "Georgia"});
                table1530.AddRow(new string[] {
                            "Select an Address",
                            "Suggested"});
#line 48
 testRunner.And("user enters contact information:", ((string)(null)), table1530, "And ");
#line hidden
#line 65
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Suggested VIN Verification Unit Summary Page Suggested VIN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_SuggestedVINVerification_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SuggestedVIN")]
        public void CASuggestedVINVerificationUnitSummaryPageSuggestedVIN()
        {
            string[] tagsOfScenario = new string[] {
                    "Unit",
                    "CA",
                    "SuggestedVIN"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Suggested VIN Verification Unit Summary Page Suggested VIN", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 68
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
                TechTalk.SpecFlow.Table table1531 = new TechTalk.SpecFlow.Table(new string[] {
                            "Suggested VIN",
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "Fare Box"});
                table1531.AddRow(new string[] {
                            "Suggested",
                            "JH4DA1745GP002661",
                            "Tennessee",
                            "12000",
                            "No"});
#line 69
 testRunner.Then("user creates a vehicle or trailer with variable values:", ((string)(null)), table1531, "Then ");
#line hidden
#line 72
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 73
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1532 = new TechTalk.SpecFlow.Table(new string[] {
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
                table1532.AddRow(new string[] {
                            "Anna",
                            "Kendrick",
                            "TN",
                            "03/13/1986",
                            "",
                            "",
                            "",
                            "",
                            "Yes",
                            "147849578"});
#line 74
 testRunner.And("user creates a driver with these values:", ((string)(null)), table1532, "And ");
#line hidden
#line 77
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 78
 testRunner.Then("user verifies the appearance of the Drivers Incidents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1533 = new TechTalk.SpecFlow.Table(new string[] {
                            "Driver",
                            "Date",
                            "Incident Type",
                            "At Fault"});
                table1533.AddRow(new string[] {
                            "Anna Kendrick",
                            "11/11/2021",
                            "Accident",
                            "No"});
#line 79
 testRunner.Then("user adds incidents with the following values:", ((string)(null)), table1533, "Then ");
#line hidden
#line 82
 testRunner.Then("user continues to the Operations page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1534 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1534.AddRow(new string[] {
                            "Do you offer \"party\" bus or limousine services where alcohol is provided or expre" +
                                "ssly permitted?",
                            "No"});
                table1534.AddRow(new string[] {
                            "Do you provide any school, camp, day care, or field trip transportation for child" +
                                "ren 12 or younger?",
                            "No"});
                table1534.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table1534.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table1534.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table1534.AddRow(new string[] {
                            "Do you rent any vehicles?",
                            "No"});
                table1534.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
#line 83
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table1534, "Then ");
#line hidden
#line 92
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 93
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1535 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1535.AddRow(new string[] {
                            "First Name",
                            "Ariana"});
                table1535.AddRow(new string[] {
                            "Last Name",
                            "Grande"});
                table1535.AddRow(new string[] {
                            "Business Email",
                            "chauffeur@yopmail.com"});
                table1535.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table1535.AddRow(new string[] {
                            "Business Website",
                            ""});
                table1535.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table1535.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table1535.AddRow(new string[] {
                            "Owner\'s First Name",
                            "AutoLarryzzzzzzzzzzz"});
                table1535.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "AutoBarryzzzzzzzzzzzzz"});
                table1535.AddRow(new string[] {
                            "Owner\'s Address",
                            "1879 Watson Blvd Apt 1"});
                table1535.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table1535.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "31093"});
                table1535.AddRow(new string[] {
                            "Owner\'s City",
                            "warner robins"});
                table1535.AddRow(new string[] {
                            "Owner\'s State",
                            "Georgia"});
                table1535.AddRow(new string[] {
                            "Select an Address",
                            "Suggested"});
#line 94
 testRunner.And("user enters contact information:", ((string)(null)), table1535, "And ");
#line hidden
#line 111
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion