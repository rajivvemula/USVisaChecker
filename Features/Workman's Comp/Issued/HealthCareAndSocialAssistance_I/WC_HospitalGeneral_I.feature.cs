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
namespace ApolloQAAutomation.Features.WorkmansComp.Issued.HealthCareAndSocialAssistance_I
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_HospitalGeneral_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_HospitalGeneral_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/HealthCareAndSocialAssistance_I", "WC_HospitalGeneral_I", "Issuing policy for Hospital: General\r\nZIP Code: 29706 (SC)\r\n130 Walnut St, Cheste" +
                    "r, SC 29706", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_HospitalGeneral_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.HealthCareAndSocialAssistance_I.WC_HospitalGeneral_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Hospital: General creates issued policy in South Carolina")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_HospitalGeneral_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Health")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SC")]
        public void WCHospitalGeneralCreatesIssuedPolicyInSouthCarolina()
        {
            string[] tagsOfScenario = new string[] {
                    "WC",
                    "Regression",
                    "Health",
                    "Issued",
                    "SC"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Hospital: General creates issued policy in South Carolina", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2157 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2157.AddRow(new string[] {
                            "Hospital: General",
                            "7",
                            "I Lease a Space From Others",
                            "",
                            "29706",
                            "WC"});
#line 8
 testRunner.Given("user starts a quote with:", ((string)(null)), table2157, "Given ");
#line hidden
#line 11
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2158 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2158.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2158.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 9 years ago"});
                table2158.AddRow(new string[] {
                            "How is your business structured?",
                            "Non-Profit Corp 501(c)(3)"});
                table2158.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "440440"});
                table2158.AddRow(new string[] {
                            "Are there any licensed employee physicians, RNs, practical nurses, directors or a" +
                                "dministrators?",
                            "no"});
                table2158.AddRow(new string[] {
                            "Are there any administrative staff that never interact with clients/patients?",
                            "no"});
                table2158.AddRow(new string[] {
                            "Do you make any payments to workers using IRS Form 1099?",
                            "no"});
                table2158.AddRow(new string[] {
                            "Business",
                            "General Hospital;General Hospital"});
                table2158.AddRow(new string[] {
                            "Address",
                            "130 Walnut St;Chester"});
                table2158.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 12
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2158, "Then ");
#line hidden
#line 24
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2159 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2159.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "1"});
                table2159.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "1"});
                table2159.AddRow(new string[] {
                            "Are any included owners/officers licensed physicians, nurses, directors or admini" +
                                "strators?",
                            "No"});
                table2159.AddRow(new string[] {
                            "Are there any included owners/officers that never interact with clients/patients?" +
                                "",
                            "No"});
#line 25
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2159, "Then ");
#line hidden
#line 31
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 32
 testRunner.Then("user verifies the appearance of the WC Your Services Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2160 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2160.AddRow(new string[] {
                            "Do you provide emergency response workers to areas with disease outbreaks, catast" +
                                "rophes, or disasters?",
                            "no"});
                table2160.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2160.AddRow(new string[] {
                            "Do you make any payments to individuals or businesses using IRS Form 1099?",
                            "no"});
                table2160.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2160.AddRow(new string[] {
                            "Do you use any volunteers or donated labor?",
                            "no"});
                table2160.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table2160.AddRow(new string[] {
                            "Federal Employer Identification Number (FEIN)",
                            "23-2651148"});
#line 33
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2160, "Then ");
#line hidden
#line 42
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
    testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 44
    testRunner.Then("user verifies the WC your quote page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2161 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2161.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "1,000,000/1,000,000/1,000,000"});
#line 45
 testRunner.When("user selects a Standard Multi-Bundle plan quote with the following customizations" +
                        " from the WC your quote page:", ((string)(null)), table2161, "When ");
#line hidden
#line 48
 testRunner.Then("user begins the WC AI page having the FEIN with value 23-2651148", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2162 = new TechTalk.SpecFlow.Table(new string[] {
                            "Set Name"});
                table2162.AddRow(new string[] {
                            "General Doctor"});
#line 49
 testRunner.Then("wc user handles 1 excluded oo with these values:", ((string)(null)), table2162, "Then ");
#line hidden
#line 52
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2163 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2163.AddRow(new string[] {
                            "Payment Option",
                            "20% Down + 9 Monthly Installments"});
                table2163.AddRow(new string[] {
                            "CC Name",
                            "Funky Chicken-cheese"});
                table2163.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2163.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2163.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2163.AddRow(new string[] {
                            "Autopay",
                            "No"});
                table2163.AddRow(new string[] {
                            "First Name",
                            "Funky"});
                table2163.AddRow(new string[] {
                            "Last Name",
                            "Kong"});
                table2163.AddRow(new string[] {
                            "Email",
                            "FunkyKong@Cheese.com"});
                table2163.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2163.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 53
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2163, "Then ");
#line hidden
#line 66
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 67
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion