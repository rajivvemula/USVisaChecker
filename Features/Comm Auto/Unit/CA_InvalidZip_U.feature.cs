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
    public partial class CA_InvalidZipTest_UFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_InvalidZip_U.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Unit", "CA_InvalidZipTest_U", "Verify that invalid zip codes cannot be used and confirm error text appears", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_InvalidZipTest_U")))
            {
                global::BiBerkLOB.Features.CommAuto.Unit.CA_InvalidZipTest_UFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Invalid Zip Test Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_InvalidZipTest_U")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public void CAInvalidZipTestUnit()
        {
            string[] tagsOfScenario = new string[] {
                    "Unit",
                    "Staging",
                    "Regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Invalid Zip Test Unit", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table571 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table571.AddRow(new string[] {
                            "Delivery: Courier Service",
                            "3",
                            "I Work at a Job Site",
                            "Vehicles",
                            "31201",
                            "CA"});
#line 5
 testRunner.Given("user starts a quote with:", ((string)(null)), table571, "Given ");
#line hidden
#line 8
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table572 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table572.AddRow(new string[] {
                            "TEST CA QUOTE",
                            "TEST CA DBA",
                            ""});
#line 9
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table572, "Then ");
#line hidden
#line 12
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 13
    testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table573 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table573.AddRow(new string[] {
                            "2000",
                            "Corporation",
                            "550 Gray Hwy",
                            "",
                            "Macon",
                            "Original"});
#line 14
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table573, "And ");
#line hidden
#line 17
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
    testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table574 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address"});
                table574.AddRow(new string[] {
                            "3N1AB6AP9CL760256",
                            "Georgia"});
#line 19
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table574, "And ");
#line hidden
#line 22
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 23
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table575 = new TechTalk.SpecFlow.Table(new string[] {
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
                table575.AddRow(new string[] {
                            "TEST FN",
                            "TEST LN",
                            "GA",
                            "08/08/1988",
                            "Yes 3 or more years",
                            "",
                            "",
                            "",
                            "No",
                            "097584622"});
#line 24
 testRunner.And("user creates a driver with these values:", ((string)(null)), table575, "And ");
#line hidden
#line 27
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table576 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table576.AddRow(new string[] {
                            "Do you haul intermodal containers?",
                            "No"});
                table576.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table576.AddRow(new string[] {
                            "Do you haul any fine art or jewelry?",
                            "No"});
                table576.AddRow(new string[] {
                            "Do you provide residential moving services?",
                            "No"});
                table576.AddRow(new string[] {
                            "Does your business engage in team driving?",
                            "No - one driver per haul"});
                table576.AddRow(new string[] {
                            "Do any of your vehicles travel to Mexico?",
                            "No"});
                table576.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
                table576.AddRow(new string[] {
                            "Do you haul any of these? Check all that apply:",
                            ""});
                table576.AddRow(new string[] {
                            "Do you haul large equipment or machinery requiring chains to secure in transit?",
                            "No"});
                table576.AddRow(new string[] {
                            "Do you haul any hazardous materials?",
                            "No"});
                table576.AddRow(new string[] {
                            "Do you participate in a delivery service on behalf of Amazon.com, Inc.?",
                            "No"});
                table576.AddRow(new string[] {
                            "Do you rent, hire, or borrow any vehicles?",
                            "No"});
                table576.AddRow(new string[] {
                            "Do you use any Owner-Operators?",
                            "No"});
                table576.AddRow(new string[] {
                            "Does your business have a USDOT Number?",
                            "No"});
#line 28
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table576, "Then ");
#line hidden
#line 44
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 45
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table577 = new TechTalk.SpecFlow.Table(new string[] {
                            "Owner\'s Zip Code"});
                table577.AddRow(new string[] {
                            ".42.4"});
#line 46
 testRunner.Then("user enters contact information to validate zip code error:", ((string)(null)), table577, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table578 = new TechTalk.SpecFlow.Table(new string[] {
                            "Owner\'s Zip Code"});
                table578.AddRow(new string[] {
                            "A3F5G"});
#line 49
 testRunner.Then("user enters contact information to validate zip code error:", ((string)(null)), table578, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table579 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table579.AddRow(new string[] {
                            "First Name",
                            "TEST FN"});
                table579.AddRow(new string[] {
                            "Last Name",
                            "TEST LN"});
                table579.AddRow(new string[] {
                            "Business Email",
                            "QAAutomation@biberk.com"});
                table579.AddRow(new string[] {
                            "Business Phone",
                            "(123) 123-1321"});
                table579.AddRow(new string[] {
                            "Business Website",
                            ""});
                table579.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table579.AddRow(new string[] {
                            "Owner\'s First Name",
                            "TEST FN"});
                table579.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "TEST LN"});
                table579.AddRow(new string[] {
                            "Owner\'s Address",
                            "7777 E Flamingo Rd"});
                table579.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table579.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "31201"});
                table579.AddRow(new string[] {
                            "Owner\'s City",
                            "Paradise"});
                table579.AddRow(new string[] {
                            "Owner\'s State",
                            "Nevada"});
                table579.AddRow(new string[] {
                            "Select an Address",
                            "Original"});
#line 52
 testRunner.And("user enters contact information:", ((string)(null)), table579, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion