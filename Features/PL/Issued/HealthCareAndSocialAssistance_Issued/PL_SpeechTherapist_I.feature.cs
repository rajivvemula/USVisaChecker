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
namespace ApolloQAAutomation.Features.PL.Issued.HealthCareAndSocialAssistance_Issued
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_SpeechTherapist_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_SpeechTherapist_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Issued/HealthCareAndSocialAssistance_Issued", "PL_SpeechTherapist_I", "Issuing a PL Policy using the Speech Therapist: Non-Traveling keyword to verify B" +
                    "usiness Details page new Industry Level Questions and Your Services new Class Le" +
                    "vel Questions.", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_SpeechTherapist_I")))
            {
                global::ApolloQAAutomation.Features.PL.Issued.HealthCareAndSocialAssistance_Issued.PL_SpeechTherapist_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Speech Therapist: Non-Traveling Issued policy in ND")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_SpeechTherapist_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HealthCare")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ND")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        public void PLSpeechTherapistNon_TravelingIssuedPolicyInND()
        {
            string[] tagsOfScenario = new string[] {
                    "Regression",
                    "PL",
                    "HealthCare",
                    "ND",
                    "Issued"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Speech Therapist: Non-Traveling Issued policy in ND", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1016 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1016.AddRow(new string[] {
                            "Speech Therapist: Non-Traveling",
                            "0",
                            "I Lease a Space From Others",
                            "",
                            "58011",
                            "PL"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1016, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1017 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Business Address",
                            "DBA"});
                table1017.AddRow(new string[] {
                            "Individual/Sole Proprietor",
                            "407 Main St",
                            "No"});
#line 11
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1017, "Then ");
#line hidden
#line 14
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1018 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1018.AddRow(new string[] {
                            "What year was your business started?",
                            "2010"});
                table1018.AddRow(new string[] {
                            "How many healthcare professionals work for your business?",
                            "2"});
                table1018.AddRow(new string[] {
                            "Do you work as an independent contractor (paid via 1099) or as an employee of a h" +
                                "ealth organization (paid via W-2)?",
                            "Independent Contractor"});
                table1018.AddRow(new string[] {
                            "Have you obtained this professional healthcare designation within the last two ye" +
                                "ars?",
                            "Yes"});
                table1018.AddRow(new string[] {
                            "When did you graduate or obtain this designation?",
                            ""});
#line 15
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1018, "Then ");
#line hidden
#line 22
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1019 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1019.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1019.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table1019.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "No"});
                table1019.AddRow(new string[] {
                            "Which option best describes your current professional liability policy?",
                            "This was my first policy."});
                table1019.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 23
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1019, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1020 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1020.AddRow(new string[] {
                            "Are any business owner(s) or staff an MD (Medical Doctor)?",
                            "No"});
                table1020.AddRow(new string[] {
                            "Do you perform any Intraoperative neurophysiological monitoring (IONM) or intraop" +
                                "erative neuromonitoring?",
                            "No"});
                table1020.AddRow(new string[] {
                            "Do you practice any radiology or medical dosimetry?",
                            "No"});
                table1020.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 30
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1020, "Then ");
#line hidden
#line 36
 testRunner.Then("user verifies the appearance of the PL About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1021 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1021.AddRow(new string[] {
                            "First Name",
                            "Tester"});
                table1021.AddRow(new string[] {
                            "Last Name",
                            "EJ"});
                table1021.AddRow(new string[] {
                            "Address",
                            "407 Main St"});
                table1021.AddRow(new string[] {
                            "Apt/Suite",
                            ""});
                table1021.AddRow(new string[] {
                            "City",
                            "Buffalo"});
                table1021.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1021.AddRow(new string[] {
                            "Email",
                            "abc@tester.com"});
                table1021.AddRow(new string[] {
                            "Business Phone",
                            "3213213211"});
                table1021.AddRow(new string[] {
                            "Ext",
                            ""});
                table1021.AddRow(new string[] {
                            "Website/Social",
                            ""});
                table1021.AddRow(new string[] {
                            "Have Broker",
                            "No"});
#line 37
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1021, "Then ");
#line hidden
#line 50
 testRunner.Then("user verifies the appearance of the PL Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.Then("user selects their Monthly - Standard Quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 52
 testRunner.Then("user verifies the PL purchase page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1022 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1022.AddRow(new string[] {
                            "Autopay",
                            "Mandatory"});
                table1022.AddRow(new string[] {
                            "CC Name",
                            "Tester"});
                table1022.AddRow(new string[] {
                            "CC Number",
                            "4111 1111 1111 1111"});
                table1022.AddRow(new string[] {
                            "CC Expiration",
                            "03/30"});
                table1022.AddRow(new string[] {
                            "Street Address",
                            "407 Main St"});
                table1022.AddRow(new string[] {
                            "ZIP Code",
                            "58011"});
                table1022.AddRow(new string[] {
                            "City",
                            "Buffalo"});
                table1022.AddRow(new string[] {
                            "Phone",
                            "321-321-3221"});
                table1022.AddRow(new string[] {
                            "Extension",
                            ""});
#line 53
 testRunner.When("user fills out the PL purchase page with these values:", ((string)(null)), table1022, "When ");
#line hidden
#line 64
 testRunner.Then("user verifies the PL how would you rate our service? page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 65
 testRunner.Then("user verifies the PL thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion