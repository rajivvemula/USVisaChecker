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
namespace ApolloQAAutomation.Features.WorkmansComp.Referred.HealthCareAndSocialAssistance_R
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_AdultLivingFacility_NoMedicalCare_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_AdultLivingFacility_NoMedicalCare_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Referred/HealthCareAndSocialAssistance_R", "WC_AdultLivingFacility_NoMedicalCare_R", @"Ineligible Quote;
Description: Policy gets referred due to premium exceeding max allowable value for sales/online..
Keyword: Adult Living Facility: No Medical Care
Employee option: Various employees - 30
ZIPCode: 07043
Employee Payroll: 1,500,000
Entity type: Corporation
Years in business: Started last year
Included owner officers: Yes 2
Excluded owner officer: 2", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_AdultLivingFacility_NoMedicalCare_R")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Referred.HealthCareAndSocialAssistance_R.WC_AdultLivingFacility_NoMedicalCare_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Adult Living Facility No Medical Care gets referred due to policy premium exce" +
            "eding max allowable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_AdultLivingFacility_NoMedicalCare_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Health")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("MA")]
        public void WCAdultLivingFacilityNoMedicalCareGetsReferredDueToPolicyPremiumExceedingMaxAllowable()
        {
            string[] tagsOfScenario = new string[] {
                    "WC",
                    "Regression",
                    "Referred",
                    "Health",
                    "MA"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Adult Living Facility No Medical Care gets referred due to policy premium exce" +
                    "eding max allowable", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table2961 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2961.AddRow(new string[] {
                            "Adult Living Facility: No Medical Care",
                            "30",
                            "I Lease a Space From Others",
                            "",
                            "02152",
                            "WC"});
#line 15
 testRunner.Given("user starts a quote with:", ((string)(null)), table2961, "Given ");
#line hidden
#line 18
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2962 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2962.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2962.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 6 years ago"});
                table2962.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table2962.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "2,000,000"});
                table2962.AddRow(new string[] {
                            "Do any employees only do general office work and would never interact with any re" +
                                "sidents?",
                            "no"});
                table2962.AddRow(new string[] {
                            "Business",
                            "Premium Exceeds Max Allowable"});
                table2962.AddRow(new string[] {
                            "Address",
                            "242 Lincoln St;Winthrop"});
                table2962.AddRow(new string[] {
                            "Contact First Name",
                            "TestF"});
                table2962.AddRow(new string[] {
                            "Contact Last Name",
                            "TestL"});
                table2962.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table2962.AddRow(new string[] {
                            "Phone",
                            "1231231321"});
                table2962.AddRow(new string[] {
                            "Business website",
                            "test.com"});
#line 19
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2962, "Then ");
#line hidden
#line 33
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2963 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2963.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table2963.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "1"});
#line 34
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2963, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2964 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name",
                            "W2 payroll",
                            "Annual Payroll",
                            "Job Duty"});
                table2964.AddRow(new string[] {
                            "TestF",
                            "TestL",
                            "yes",
                            "40000",
                            "Interacts with residents/clients"});
#line 38
 testRunner.Then("user handles the WC Covered OO with these values:", ((string)(null)), table2964, "Then ");
#line hidden
#line 41
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2965 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2965.AddRow(new string[] {
                            "Do you accept clients that have been diagnosed with a form of dementia?",
                            "No"});
                table2965.AddRow(new string[] {
                            "Do you provide any alcohol or drug abuse counseling?",
                            "No"});
                table2965.AddRow(new string[] {
                            "Do you provide emergency response workers to areas with disease outbreaks, catast" +
                                "rophes, or disasters?",
                            "no"});
                table2965.AddRow(new string[] {
                            "What percentage of residents or clients are ambulatory?",
                            "0"});
                table2965.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2965.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2965.AddRow(new string[] {
                            "Do you use any volunteers or donated labor?",
                            "no"});
                table2965.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table2965.AddRow(new string[] {
                            "Federal Employer Identification Number (FEIN)",
                            "63-1212123"});
#line 42
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2965, "Then ");
#line hidden
#line 53
 testRunner.Then("user begins the WC AI page having the FEIN with value 63-1212123", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 54
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2966 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2966.AddRow(new string[] {
                            "Business name",
                            "Test Number Of Claims"});
                table2966.AddRow(new string[] {
                            "Contact first name",
                            "TestF"});
                table2966.AddRow(new string[] {
                            "Contact last name",
                            "TestL"});
                table2966.AddRow(new string[] {
                            "Email",
                            "TestCert@Plan.com"});
                table2966.AddRow(new string[] {
                            "Phone",
                            "(123) 123-1321"});
                table2966.AddRow(new string[] {
                            "Business website",
                            "www.TestPartnerCert.com"});
#line 55
 testRunner.When("user fills out the WC refer page with these values:", ((string)(null)), table2966, "When ");
#line hidden
#line 63
 testRunner.Then("user verifies the refer thank you page appears", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
