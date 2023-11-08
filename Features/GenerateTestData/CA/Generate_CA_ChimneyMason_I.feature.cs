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
    public partial class Generate_CA_ChimneyMason_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Generate_CA_ChimneyMason_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/GenerateTestData/CA", "Generate_CA_ChimneyMason_I", null, ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Generate_CA_ChimneyMason_I")))
            {
                global::ApolloQAAutomation.Features.GenerateTestData.CA.Generate_CA_ChimneyMason_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Generate_CA_CarpetInstallation_I successfully purchases a policy for FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Generate_CA_ChimneyMason_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Generate")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CA")]
        public void Generate_CA_CarpetInstallation_ISuccessfullyPurchasesAPolicyForFL()
        {
            string[] tagsOfScenario = new string[] {
                    "Generate",
                    "CA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate_CA_CarpetInstallation_I successfully purchases a policy for FL", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table606 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table606.AddRow(new string[] {
                            "Chimney Mason",
                            "2",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "94558",
                            "CA"});
#line 5
 testRunner.Given("user starts a quote with:", ((string)(null)), table606, "Given ");
#line hidden
#line 8
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table607 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table607.AddRow(new string[] {
                            "",
                            "",
                            ""});
#line 9
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table607, "Then ");
#line hidden
#line 15
 testRunner.Then("user clicks continue from the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 16
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table608 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address",
                            "Mailing Address"});
                table608.AddRow(new string[] {
                            "1900",
                            "Individual/Sole Proprietor",
                            "572 Putah Creek Dr",
                            "",
                            "Napa",
                            "",
                            "Yes"});
#line 17
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table608, "And ");
#line hidden
#line 20
 testRunner.Then("user clicks continue from CA Introduction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 21
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table609 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Vehicle Worth",
                            "Plowing Snow",
                            "Escort Trucks"});
                table609.AddRow(new string[] {
                            "3D3KR19D97G838924",
                            "California",
                            "12000",
                            "No",
                            "Yes"});
#line 22
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table609, "And ");
#line hidden
#line 25
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table610 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Plowing Snow",
                            "Escort Trucks"});
                table610.AddRow(new string[] {
                            "5NMZU3LB2JH065041",
                            "California",
                            "No",
                            "No"});
#line 26
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table610, "And ");
#line hidden
#line 29
 testRunner.Then("user adds another vehicle or trailer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table611 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "Parking Address",
                            "Plowing Snow",
                            "Escort Trucks"});
                table611.AddRow(new string[] {
                            "1FTNE2EW0DDA17671",
                            "California",
                            "No",
                            "No"});
#line 30
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table611, "And ");
#line hidden
#line 33
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 34
 testRunner.Then("User verifies appearance of the Drivers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table612 = new TechTalk.SpecFlow.Table(new string[] {
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
                table612.AddRow(new string[] {
                            "Donald",
                            "Duck",
                            "CA",
                            "03/13/1986",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "D1234567"});
                table612.AddRow(new string[] {
                            "Goofy",
                            "Woofy",
                            "CA",
                            "04/01/1988",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "D1234568"});
                table612.AddRow(new string[] {
                            "Mike",
                            "Jones",
                            "CA",
                            "09/03/1989",
                            "",
                            "",
                            "",
                            "",
                            "No",
                            "D1234569"});
#line 35
 testRunner.And("user creates a driver with these values:", ((string)(null)), table612, "And ");
#line hidden
#line 40
 testRunner.Then("user clicks continue from the Drivers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table613 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table613.AddRow(new string[] {
                            "What is the furthest any of your vehicles travel in any one direction from their " +
                                "home base?",
                            "50 miles or less"});
                table613.AddRow(new string[] {
                            "How many auto insurance claims did your business file in the last 3 years?",
                            "0"});
#line 41
 testRunner.Then("user fills out the Operations page:", ((string)(null)), table613, "Then ");
#line hidden
#line 45
 testRunner.Then("user continues to the Contact page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 46
 testRunner.Then("user verifies appearance of the contacts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table614 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table614.AddRow(new string[] {
                            "First Name",
                            "Ariana"});
                table614.AddRow(new string[] {
                            "Last Name",
                            "Grande"});
                table614.AddRow(new string[] {
                            "Business Email",
                            "ChimneyMason@yopmail.com"});
                table614.AddRow(new string[] {
                            "Business Phone",
                            "(555) 867-5309"});
                table614.AddRow(new string[] {
                            "Business Website",
                            ""});
                table614.AddRow(new string[] {
                            "Business has an account manager",
                            ""});
                table614.AddRow(new string[] {
                            "Want Save Money",
                            "Yes"});
                table614.AddRow(new string[] {
                            "Owner\'s First Name",
                            "AutoLarryzzzzzzzzzzz"});
                table614.AddRow(new string[] {
                            "Owner\'s Last Name",
                            "AutoBarryzzzzzzzzzzzzz"});
                table614.AddRow(new string[] {
                            "Owner\'s Address",
                            "711 Central Ave"});
                table614.AddRow(new string[] {
                            "Owner\'s Address 2",
                            ""});
                table614.AddRow(new string[] {
                            "Owner\'s Zip Code",
                            "94558"});
                table614.AddRow(new string[] {
                            "Owner\'s City",
                            "Napa"});
                table614.AddRow(new string[] {
                            "Owner\'s State",
                            "California"});
#line 47
 testRunner.And("user enters contact information:", ((string)(null)), table614, "And ");
#line hidden
#line 63
 testRunner.Then("user clicks continue from the Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.Then("user verifies the appearance of the Quote Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table615 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table615.AddRow(new string[] {
                            "Yearly",
                            "No"});
                table615.AddRow(new string[] {
                            "Policy Coverages",
                            "$100,000 Combined Single Limit"});
#line 65
 testRunner.And("user completes their Quote", ((string)(null)), table615, "And ");
#line hidden
#line 69
 testRunner.Then("user clicks continue from the Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 70
 testRunner.Then("user verifies the appearance of the Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table616 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN",
                            "OLF",
                            "Who Holds Vehicle"});
                table616.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
                table616.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
                table616.AddRow(new string[] {
                            "Yes",
                            "Owned",
                            "Myself"});
#line 71
 testRunner.And("user fills out the Additional Information page:", ((string)(null)), table616, "And ");
#line hidden
#line 76
 testRunner.Then("user clicks continue from Additional Information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table617 = new TechTalk.SpecFlow.Table(new string[] {
                            "Payment Plan",
                            "Card Type"});
                table617.AddRow(new string[] {
                            "12 Monthly",
                            "Visa"});
#line 77
 testRunner.Then("user goes to purchase a plan using the following information:", ((string)(null)), table617, "Then ");
#line hidden
#line 80
 testRunner.Then("user clicks purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 81
 testRunner.Then("user verifies the Thank You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion