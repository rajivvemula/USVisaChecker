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
namespace ApolloQAAutomation.Features.WorkmansComp.Referred.RetailWholesaleStoresInclFoodStores_R
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_CeramicTileStore_Retail_NoInstallation_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_CeramicTileStore_Retail_NoInstallation_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Referred/RetailWholesaleStoresInclFoodStores_R", "WC_CeramicTileStore_Retail_NoInstallation_R", @"Ineligible quote - Keyword: Ceramic Tile Store: Retail; No Installation
Description: Refer due to potential misclassification, in addition please check whether subbed out work always has cert collected. 
No more than 50% of subcontracted install is allowed..
Yes I have Employees
Number of employees : 6
Business Operation: I Run My Business From Property I Own 
ZIP Code: 11211
Included Officer: 1
Business started year : Started 7 years ago
Business Structured: LLC", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_CeramicTileStore_Retail_NoInstallation_R")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Referred.RetailWholesaleStoresInclFoodStores_R.WC_CeramicTileStore_Retail_NoInstallation_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Ceramic Tile Store: Retail No Installation gets referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_CeramicTileStore_Retail_NoInstallation_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Retail")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NY")]
        public void WCCeramicTileStoreRetailNoInstallationGetsReferred()
        {
            string[] tagsOfScenario = new string[] {
                    "Retail",
                    "WC",
                    "Regression",
                    "Referred",
                    "NY"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Ceramic Tile Store: Retail No Installation gets referred", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2991 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2991.AddRow(new string[] {
                            "Ceramic Tile Store: Retail; No Installation",
                            "6",
                            "I Run My Business Out of My Home",
                            "",
                            "11211",
                            "WC"});
#line 15
 testRunner.Given("user starts a quote with:", ((string)(null)), table2991, "Given ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2992 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2992.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2992.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 7 years ago"});
                table2992.AddRow(new string[] {
                            "How is your business structured?",
                            "Limited Liability Co. (LLC)"});
                table2992.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "700000"});
                table2992.AddRow(new string[] {
                            "Do any employees deliver goods but wouldn\'t help set up or install anything?",
                            "no"});
                table2992.AddRow(new string[] {
                            "Are there any retail store employees that do not do any installation, maintenance" +
                                ", or contracting work?",
                            "no"});
                table2992.AddRow(new string[] {
                            "Do any employees only do general office work and do not work a cash register?",
                            "no"});
                table2992.AddRow(new string[] {
                            "Business",
                            "Ceramic Tile Store"});
                table2992.AddRow(new string[] {
                            "Address",
                            "147 Powers St;Brooklyn"});
                table2992.AddRow(new string[] {
                            "Contact First Name",
                            "TestF"});
                table2992.AddRow(new string[] {
                            "Contact Last Name",
                            "TestL"});
                table2992.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table2992.AddRow(new string[] {
                            "Phone",
                            "1231231321"});
                table2992.AddRow(new string[] {
                            "Business website",
                            "test.com"});
#line 19
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2992, "Then ");
#line hidden
#line 35
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2993 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2993.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table2993.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "1"});
#line 36
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2993, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2994 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name",
                            "W2 payroll",
                            "Annual Payroll",
                            "Job Duty"});
                table2994.AddRow(new string[] {
                            "OneF",
                            "OneL",
                            "yes",
                            "40000",
                            "General Office Worker"});
#line 40
 testRunner.Then("user handles the WC Covered OO with these values:", ((string)(null)), table2994, "Then ");
#line hidden
#line 43
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2995 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2995.AddRow(new string[] {
                            "Do you pay any subcontractors/1099 workers to install, service, or do repairs for" +
                                " customers?",
                            "no"});
                table2995.AddRow(new string[] {
                            "What percentage of your overall sales involve delivery?",
                            "100"});
                table2995.AddRow(new string[] {
                            "What percentage of delivery is done by a third party or independent contractors?",
                            "100"});
                table2995.AddRow(new string[] {
                            "Are certificates of insurance kept for all third parties that deliver on your beh" +
                                "alf?",
                            "No we don\'t require they have insurance"});
                table2995.AddRow(new string[] {
                            "What is the annual pay to third parties that deliver on your behalf?",
                            "48,000"});
                table2995.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2995.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2995.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
#line 44
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2995, "Then ");
#line hidden
#line 54
 testRunner.Then("user begins the WC AI page setting the FEIN with value 63-1212123", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 55
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2996 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2996.AddRow(new string[] {
                            "Business name",
                            "Ceramic Tile Store"});
                table2996.AddRow(new string[] {
                            "Contact first name",
                            "TestF"});
                table2996.AddRow(new string[] {
                            "Contact last name",
                            "TestL"});
                table2996.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table2996.AddRow(new string[] {
                            "Phone",
                            "(123) 123-1321"});
                table2996.AddRow(new string[] {
                            "Business website",
                            "www.TestPartnerCert.com"});
#line 56
 testRunner.When("user fills out the WC refer page with these values:", ((string)(null)), table2996, "When ");
#line hidden
#line 64
 testRunner.Then("user verifies the refer thank you page appears", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion