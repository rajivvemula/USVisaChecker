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
    public partial class Generate_CA_Geologist_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Generate_CA_Geologist_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/GenerateTestData/CA", "Generate_CA_Geologist_I", "Populate the system with testing data primarily base on most common policy types " +
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Generate_CA_Geologist_I")))
            {
                global::ApolloQAAutomation.Features.GenerateTestData.CA.Generate_CA_Geologist_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Generate CA Geologist successfully purchases a policy for FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Generate_CA_Geologist_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Generate")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        public void GenerateCAGeologistSuccessfullyPurchasesAPolicyForFL()
        {
            string[] tagsOfScenario = new string[] {
                    "Generate",
                    "CA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate CA Geologist successfully purchases a policy for FL", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table690 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table690.AddRow(new string[] {
                            "Geologist",
                            "2",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "33458",
                            "CA"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table690, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table691 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table691.AddRow(new string[] {
                            "",
                            "",
                            ""});
#line 11
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table691, "Then ");
#line hidden
#line 17
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table692 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address",
                            "Mailing Address"});
                table692.AddRow(new string[] {
                            "1900",
                            "Individual/Sole Proprietor",
                            "112 Palomino Dr",
                            "",
                            "Jupiter",
                            "",
                            "Yes"});
#line 19
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table692, "And ");
#line hidden
#line 22
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 23
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table693 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth"});
                table693.AddRow(new string[] {
                            "3D3KR19D97G838924",
                            "Florida",
                            "12000"});
#line 24
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table693, "And ");
#line hidden
#line 27
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table694 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address"});
                table694.AddRow(new string[] {
                            "5NMZU3LB2JH065041",
                            "Florida"});
#line 28
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table694, "And ");
#line hidden
#line 31
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table695 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "Commuter"});
                table695.AddRow(new string[] {
                            "1FTNE2EW0DDA17671",
                            "Florida",
                            "10000",
                            "No"});
#line 32
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table695, "And ");
#line hidden
#line 35
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 36
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table696 = new TechTalk.SpecFlow.Table(new string[] {
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
                table696.AddRow(new string[] {
                            "Chris",
                            "Rock",
                            "FL",
                            "03/13/1986",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "G544061459250"});
                table696.AddRow(new string[] {
                            "Eric",
                            "Smith",
                            "FL",
                            "04/01/1988",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "G544061739250"});
                table696.AddRow(new string[] {
                            "Mike",
                            "Jones",
                            "FL",
                            "09/03/1989",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "G544061739150"});
#line 37
 testRunner.And("user creates a driver with these values:", ((string)(null)), table696, "And ");
#line hidden
#line 42
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table697 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table697.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table697.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
#line 43
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table697, "Then ");
#line hidden
#line 47
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table698 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table698.AddRow(new string[] {
                            "First Name",
                            "Steve"});
                table698.AddRow(new string[] {
                            "Last Name",
                            "Smith"});
                table698.AddRow(new string[] {
                            "Business Email",
                            "Geologist@yopmail.com"});
                table698.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table698.AddRow(new string[] {
                            "Business Website",
                            ""});
                table698.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table698.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table698.AddRow(new string[] {
                            "Owner\'s First Name",
                            "OwnerzFirstName"});
                table698.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "OwnerzLastName"});
                table698.AddRow(new string[] {
                            "Owner\'s Address",
                            "112 Palomino Dr"});
                table698.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table698.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "33458"});
                table698.AddRow(new string[] {
                            "Owner\'s City",
                            "Jupiter"});
                table698.AddRow(new string[] {
                            "Owner\'s State",
                            "Florida"});
#line 49
 testRunner.And("user enters contact information:", ((string)(null)), table698, "And ");
#line hidden
#line 65
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table699 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table699.AddRow(new string[] {
                            "Yearly",
                            "No"});
                table699.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
#line 67
 testRunner.And("user completes their Quote", ((string)(null)), table699, "And ");
#line hidden
#line 71
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 72
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table700 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table700.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
                table700.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
                table700.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
#line 73
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table700, "And ");
#line hidden
#line 78
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table701 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table701.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 79
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table701, "Then ");
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
