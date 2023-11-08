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
namespace BiBerkLOB.Features.WorkmansComp.Referred.ConstructionAndSpecialtyTradeContractors
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_FencingContractor_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_FencingContractor_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Referred/ConstructionAndSpecialtyTradeContractors", "WC_FencingContractor_R", "Referred due to the average employee wage being too low", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_FencingContractor_R")))
            {
                global::BiBerkLOB.Features.WorkmansComp.Referred.ConstructionAndSpecialtyTradeContractors.WC_FencingContractor_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC_FencingContractor_R employee wage is too low")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_FencingContractor_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Construction")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NE")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public void WC_FencingContractor_REmployeeWageIsTooLow()
        {
            string[] tagsOfScenario = new string[] {
                    "Construction",
                    "WC",
                    "Referred",
                    "NE",
                    "Regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC_FencingContractor_R employee wage is too low", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1946 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1946.AddRow(new string[] {
                            "Fencing Contractor",
                            "25",
                            "I Lease a Space From Others",
                            "",
                            "18706",
                            "WC"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1946, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1947 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1947.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table1947.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 6 years ago"});
                table1947.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table1947.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "4"});
                table1947.AddRow(new string[] {
                            "Are there any employees that never travel to job sites or do any construction wor" +
                                "k?",
                            "no"});
                table1947.AddRow(new string[] {
                            "Do you use any subcontractors or pay any workers using IRS Form 1099?",
                            "no"});
                table1947.AddRow(new string[] {
                            "Business",
                            "Fencing Contractor"});
                table1947.AddRow(new string[] {
                            "Address",
                            "44 Betsy Ross Dr;Wilkes Barre"});
                table1947.AddRow(new string[] {
                            "Contact First Name",
                            "TestF"});
                table1947.AddRow(new string[] {
                            "Contact Last Name",
                            "TestL"});
                table1947.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table1947.AddRow(new string[] {
                            "Phone",
                            "1231231321"});
                table1947.AddRow(new string[] {
                            "Business website",
                            "test.com"});
#line 11
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table1947, "Then ");
#line hidden
#line 26
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1948 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1948.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table1948.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "1"});
                table1948.AddRow(new string[] {
                            "Are there any included owners/officers that never travel to job sites or do any c" +
                                "onstruction work?",
                            "No"});
#line 27
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table1948, "Then ");
#line hidden
#line 32
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1949 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1949.AddRow(new string[] {
                            "Do you ever transport six or more workers in the same vehicle?",
                            "no"});
                table1949.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table1949.AddRow(new string[] {
                            "Do you perform any work in excess of 5 feet underground or 30 feet above ground?",
                            "no"});
                table1949.AddRow(new string[] {
                            "Do you do any demolition or wrecking of entire buildings or homes?",
                            "no"});
                table1949.AddRow(new string[] {
                            "Do the business owner(s) of this business have a combined majority ownership in a" +
                                "ny other construction business?",
                            "no"});
                table1949.AddRow(new string[] {
                            "Does any work involve the handling of barbed wire?",
                            "no"});
                table1949.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table1949.AddRow(new string[] {
                            "Do you agree to submit proof of insurance claims history, also called loss runs, " +
                                "for the prior 3 years within 30 days of the effective date of the policy?",
                            "yes"});
                table1949.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table1949.AddRow(new string[] {
                            "Federal Employer Identification Number (FEIN)",
                            "63-1212123"});
#line 33
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table1949, "Then ");
#line hidden
#line 45
 testRunner.Then("user begins the WC AI page having the FEIN with value 63-1212123", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 46
 testRunner.Then("wc user handles 1 covered oo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 47
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1950 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1950.AddRow(new string[] {
                            "Business name",
                            "Test Auto XMOD"});
                table1950.AddRow(new string[] {
                            "Contact first name",
                            "TestF"});
                table1950.AddRow(new string[] {
                            "Contact last name",
                            "TestL"});
                table1950.AddRow(new string[] {
                            "Email",
                            "TestCert@Plan.com"});
                table1950.AddRow(new string[] {
                            "Phone",
                            "(123) 123-1321"});
                table1950.AddRow(new string[] {
                            "Business website",
                            "www.TestPartnerCert.com"});
#line 48
 testRunner.When("user fills out the WC refer page with these values:", ((string)(null)), table1950, "When ");
#line hidden
#line 56
 testRunner.Then("user verifies the refer thank you page appears", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion