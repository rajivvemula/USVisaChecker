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
namespace BiBerkLOB.Features.CommAuto.Unit
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Unit", "CA_SuggestedVINVerification_U", "Suggested VIN and Original VIN verification on Summary Page", ProgrammingLanguage.CSharp, featureTags);
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
                global::BiBerkLOB.Features.CommAuto.Unit.CA_SuggestedVINVerification_UFeature.FeatureSetup(null);
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
            TechTalk.SpecFlow.Table table703 = new TechTalk.SpecFlow.Table(new string[] {
                        "Industry",
                        "Employees",
                        "Location",
                        "Own or Lease",
                        "ZIP Code",
                        "LOB"});
            table703.AddRow(new string[] {
                        "Uber Driver",
                        "2",
                        "I Run My Business From Property I Own",
                        "Vehicles",
                        "37211",
                        "CA"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table703, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table704 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name of Business",
                        "DBA",
                        "Policy Start Date"});
            table704.AddRow(new string[] {
                        "",
                        "",
                        ""});
#line 10
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table704, "Then ");
#line hidden
#line 16
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
    testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table705 = new TechTalk.SpecFlow.Table(new string[] {
                        "Year Business Started",
                        "How Business Structured",
                        "Address1",
                        "Address2",
                        "City",
                        "Select an Address"});
            table705.AddRow(new string[] {
                        "1980",
                        "Individual",
                        "708 Misty Pines Cir",
                        "",
                        "Nashville",
                        ""});
#line 18
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table705, "And ");
#line hidden
#line 21
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
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
#line 25
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
                TechTalk.SpecFlow.Table table706 = new TechTalk.SpecFlow.Table(new string[] {
                            "Suggested VIN",
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "Type Insure",
                            "Year",
                            "Make",
                            "Model",
                            "Fare Box"});
                table706.AddRow(new string[] {
                            "Original",
                            "JH4DA1745GP002661",
                            "Tennessee",
                            "12000",
                            "Car - Sedan",
                            "1986",
                            "ACURA",
                            "INTEGRA",
                            "No"});
#line 26
 testRunner.Then("user creates a vehicle or trailer with variable values:", ((string)(null)), table706, "Then ");
#line hidden
#line 29
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 30
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table707 = new TechTalk.SpecFlow.Table(new string[] {
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
                table707.AddRow(new string[] {
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
#line 31
 testRunner.And("user creates a driver with these values:", ((string)(null)), table707, "And ");
#line hidden
#line 34
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 35
 testRunner.Then("user verifies the appearance of the Drivers Incidents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table708 = new TechTalk.SpecFlow.Table(new string[] {
                            "Driver",
                            "Date",
                            "Incident Type",
                            "At Fault"});
                table708.AddRow(new string[] {
                            "Anna Kendrick",
                            "11/11/2021",
                            "Accident",
                            "No"});
#line 36
 testRunner.Then("user adds incidents with the following values:", ((string)(null)), table708, "Then ");
#line hidden
#line 39
 testRunner.Then("user continues to the Operations page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table709 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table709.AddRow(new string[] {
                            "Do you offer \"party\" bus or limousine services where alcohol is provided or expre" +
                                "ssly permitted?",
                            "No"});
                table709.AddRow(new string[] {
                            "Do you provide any school, camp, day care, or field trip transportation for child" +
                                "ren 12 or younger?",
                            "No"});
                table709.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table709.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table709.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table709.AddRow(new string[] {
                            "Do you rent, hire, or borrow any vehicles?",
                            "No"});
                table709.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
#line 40
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table709, "Then ");
#line hidden
#line 49
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table710 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table710.AddRow(new string[] {
                            "First Name",
                            "Ariana"});
                table710.AddRow(new string[] {
                            "Last Name",
                            "Grande"});
                table710.AddRow(new string[] {
                            "Business Email",
                            "chauffeur@yopmail.com"});
                table710.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table710.AddRow(new string[] {
                            "Business Website",
                            ""});
                table710.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table710.AddRow(new string[] {
                            "Owner\'s First Name",
                            "AutoLarryzzzzzzzzzzz"});
                table710.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "AutoBarryzzzzzzzzzzzzz"});
                table710.AddRow(new string[] {
                            "Owner\'s Address",
                            "1879 Watson Blvd Apt 1"});
                table710.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table710.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "31093"});
                table710.AddRow(new string[] {
                            "Owner\'s City",
                            "warner robins"});
                table710.AddRow(new string[] {
                            "Owner\'s State",
                            "Georgia"});
                table710.AddRow(new string[] {
                            "Select an Address",
                            "Suggested"});
#line 51
 testRunner.And("user enters contact information:", ((string)(null)), table710, "And ");
#line hidden
#line 67
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
                TechTalk.SpecFlow.Table table711 = new TechTalk.SpecFlow.Table(new string[] {
                            "Suggested VIN",
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "Fare Box"});
                table711.AddRow(new string[] {
                            "Suggested",
                            "JH4DA1745GP002661",
                            "Tennessee",
                            "12000",
                            "No"});
#line 71
 testRunner.Then("user creates a vehicle or trailer with variable values:", ((string)(null)), table711, "Then ");
#line hidden
#line 74
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 75
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table712 = new TechTalk.SpecFlow.Table(new string[] {
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
                table712.AddRow(new string[] {
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
#line 76
 testRunner.And("user creates a driver with these values:", ((string)(null)), table712, "And ");
#line hidden
#line 79
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 80
 testRunner.Then("user verifies the appearance of the Drivers Incidents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table713 = new TechTalk.SpecFlow.Table(new string[] {
                            "Driver",
                            "Date",
                            "Incident Type",
                            "At Fault"});
                table713.AddRow(new string[] {
                            "Anna Kendrick",
                            "11/11/2021",
                            "Accident",
                            "No"});
#line 81
 testRunner.Then("user adds incidents with the following values:", ((string)(null)), table713, "Then ");
#line hidden
#line 84
 testRunner.Then("user continues to the Operations page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table714 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table714.AddRow(new string[] {
                            "Do you offer \"party\" bus or limousine services where alcohol is provided or expre" +
                                "ssly permitted?",
                            "No"});
                table714.AddRow(new string[] {
                            "Do you provide any school, camp, day care, or field trip transportation for child" +
                                "ren 12 or younger?",
                            "No"});
                table714.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table714.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table714.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table714.AddRow(new string[] {
                            "Do you rent, hire, or borrow any vehicles?",
                            "No"});
                table714.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
#line 85
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table714, "Then ");
#line hidden
#line 94
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 95
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table715 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table715.AddRow(new string[] {
                            "First Name",
                            "Ariana"});
                table715.AddRow(new string[] {
                            "Last Name",
                            "Grande"});
                table715.AddRow(new string[] {
                            "Business Email",
                            "chauffeur@yopmail.com"});
                table715.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table715.AddRow(new string[] {
                            "Business Website",
                            ""});
                table715.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table715.AddRow(new string[] {
                            "Owner\'s First Name",
                            "AutoLarryzzzzzzzzzzz"});
                table715.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "AutoBarryzzzzzzzzzzzzz"});
                table715.AddRow(new string[] {
                            "Owner\'s Address",
                            "1879 Watson Blvd Apt 1"});
                table715.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table715.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "31093"});
                table715.AddRow(new string[] {
                            "Owner\'s City",
                            "warner robins"});
                table715.AddRow(new string[] {
                            "Owner\'s State",
                            "Georgia"});
                table715.AddRow(new string[] {
                            "Select an Address",
                            "Suggested"});
#line 96
 testRunner.And("user enters contact information:", ((string)(null)), table715, "And ");
#line hidden
#line 112
 testRunner.Then("user verifies the appearance of the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion