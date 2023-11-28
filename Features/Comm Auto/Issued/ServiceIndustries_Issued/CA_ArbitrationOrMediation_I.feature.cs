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
namespace ApolloQAAutomation.Features.CommAuto.Issued.ServiceIndustries_Issued
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CA_ArbitrationOrMediation_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_ArbitrationOrMediation_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Issued/ServiceIndustries_Issued", "CA_ArbitrationOrMediation_I", null, ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_ArbitrationOrMediation_I")))
            {
                global::ApolloQAAutomation.Features.CommAuto.Issued.ServiceIndustries_Issued.CA_ArbitrationOrMediation_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA Arbitration Or Mediation Issued In Nevada")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_ArbitrationOrMediation_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NV")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        public void CAArbitrationOrMediationIssuedInNevada()
        {
            string[] tagsOfScenario = new string[] {
                    "Issued",
                    "Regression",
                    "NV",
                    "CA",
                    "Service"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA Arbitration Or Mediation Issued In Nevada", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table149 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Client Home",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table149.AddRow(new string[] {
                            "Arbitration or Mediation",
                            "3",
                            "I Run My Business Out of My Home",
                            "No",
                            "Vehicles",
                            "89109",
                            "CA"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table149, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table150 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table150.AddRow(new string[] {
                            "TEST CA QUOTE",
                            "TEST CA DBA",
                            ""});
#line 10
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table150, "Then ");
#line hidden
#line 16
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table151 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table151.AddRow(new string[] {
                            "1999",
                            "Partnership",
                            "333 Celeste Ave",
                            "",
                            "Las Vegas",
                            "Original"});
#line 18
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table151, "And ");
#line hidden
#line 21
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table152 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address"});
                table152.AddRow(new string[] {
                            "1FMCU02Z58KA43824",
                            "Nevada"});
#line 23
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table152, "And ");
#line hidden
#line 26
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table153 = new TechTalk.SpecFlow.Table(new string[] {
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
                table153.AddRow(new string[] {
                            "TEST FN",
                            "TEST LN",
                            "NV",
                            "09/01/1991",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "123456789091"});
#line 28
 testRunner.And("user creates a driver with these values:", ((string)(null)), table153, "And ");
#line hidden
#line 31
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table154 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table154.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table154.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
#line 32
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table154, "Then ");
#line hidden
#line 36
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table155 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table155.AddRow(new string[] {
                            "First Name",
                            "TEST FN"});
                table155.AddRow(new string[] {
                            "Last Name",
                            "TEST LN"});
                table155.AddRow(new string[] {
                            "Business Email",
                            "QAAutomation@biberk.com"});
                table155.AddRow(new string[] {
                            "Business Phone",
                            "(123) 123-1321"});
                table155.AddRow(new string[] {
                            "Business Website",
                            ""});
                table155.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table155.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table155.AddRow(new string[] {
                            "Owner\'s First Name",
                            "TEST FN"});
                table155.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "TEST LN"});
                table155.AddRow(new string[] {
                            "Owner\'s Address",
                            "33 Celeste Ave"});
                table155.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table155.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "89109"});
                table155.AddRow(new string[] {
                            "Owner\'s City",
                            "Las Vegas"});
                table155.AddRow(new string[] {
                            "Owner\'s State",
                            "Nevada"});
                table155.AddRow(new string[] {
                            "Select an Address",
                            "Original"});
#line 38
 testRunner.And("user enters contact information:", ((string)(null)), table155, "And ");
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
                TechTalk.SpecFlow.Table table156 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table156.AddRow(new string[] {
                            "Yearly",
                            "No"});
                table156.AddRow(new string[] {
                            "Policy Coverages",
                            "$300,000 Combined Single Limit"});
                table156.AddRow(new string[] {
                            "Vehicle 1 Coverage",
                            "$500 Comprehensive Deductible / $500 Collision Deductible"});
                table156.AddRow(new string[] {
                            "Policy Medical",
                            "$2,000"});
#line 58
 testRunner.And("user completes their Quote", ((string)(null)), table156, "And ");
#line hidden
                TechTalk.SpecFlow.Table table157 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table157.AddRow(new string[] {
                            "Bodily Injury and Property Damage Liability",
                            "Yes"});
                table157.AddRow(new string[] {
                            "Medical Payments",
                            "Yes"});
                table157.AddRow(new string[] {
                            "Comp/Collision-ACV (One Vehicle)",
                            "Yes"});
                table157.AddRow(new string[] {
                            "Uninsured/Underinsured Motorist",
                            "Yes"});
                table157.AddRow(new string[] {
                            "Rental Reimbursement",
                            "No"});
#line 64
 testRunner.Then("user verifies proposal email modal", ((string)(null)), table157, "Then ");
#line hidden
#line 71
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 72
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table158 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table158.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "The Business"});
#line 73
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table158, "And ");
#line hidden
#line 76
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table159 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table159.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 77
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table159, "Then ");
#line hidden
#line 80
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 81
 testRunner.Then("user verifies the Thank You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 82
 testRunner.And("user verifies the WC section on the Thank You page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
 testRunner.And("user verifies the PL section on the Thank You page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
