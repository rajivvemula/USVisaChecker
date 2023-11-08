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
    public partial class PL_EmergencyMedicalTechnicianEMS_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_EmergencyMedicalTechnician(EMS)_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Issued/HealthCareAndSocialAssistance_Issued", "PL_EmergencyMedicalTechnician(EMS)_I", "Issuing a PL Policy using the Emergency Medical Technician (EMT) keyword", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_EmergencyMedicalTechnician(EMS)_I")))
            {
                global::ApolloQAAutomation.Features.PL.Issued.HealthCareAndSocialAssistance_Issued.PL_EmergencyMedicalTechnicianEMS_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Emergency Medical Technician (EMT) issued policy in ND")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_EmergencyMedicalTechnician(EMS)_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Health")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ND")]
        public void PLEmergencyMedicalTechnicianEMTIssuedPolicyInND()
        {
            string[] tagsOfScenario = new string[] {
                    "Regression",
                    "PL",
                    "Health",
                    "Issued",
                    "ND"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Emergency Medical Technician (EMT) issued policy in ND", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table946 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table946.AddRow(new string[] {
                            "Emergency Medical Technician (EMT)",
                            "2",
                            "I Lease a Space From Others",
                            "",
                            "58011",
                            "PL"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table946, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table947 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table947.AddRow(new string[] {
                            "Corporation",
                            "EMS",
                            "407 Main St",
                            "No"});
#line 11
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table947, "Then ");
#line hidden
#line 14
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table948 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table948.AddRow(new string[] {
                            "What year was your business started?",
                            "2010"});
                table948.AddRow(new string[] {
                            "How many healthcare professionals work for your business?",
                            "2"});
                table948.AddRow(new string[] {
                            "How many health students work for your business?",
                            "0"});
#line 15
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table948, "Then ");
#line hidden
#line 20
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table949 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table949.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table949.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table949.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "No"});
                table949.AddRow(new string[] {
                            "Which option best describes your current professional liability policy?",
                            "This was my first policy."});
                table949.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 21
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table949, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table950 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table950.AddRow(new string[] {
                            "Are any business owner(s) or staff an MD (Medical Doctor)?",
                            "No"});
                table950.AddRow(new string[] {
                            "Do you practice any radiology or medical dosimetry?",
                            "No"});
                table950.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 28
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table950, "Then ");
#line hidden
#line 33
 testRunner.Then("user verifies the appearance of the PL About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table951 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table951.AddRow(new string[] {
                            "First Name",
                            "Tester"});
                table951.AddRow(new string[] {
                            "Last Name",
                            "EJ"});
                table951.AddRow(new string[] {
                            "Address",
                            "407 Main St"});
                table951.AddRow(new string[] {
                            "Apt/Suite",
                            ""});
                table951.AddRow(new string[] {
                            "City",
                            "Buffalo"});
                table951.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table951.AddRow(new string[] {
                            "Email",
                            "abc@tester.com"});
                table951.AddRow(new string[] {
                            "Business Phone",
                            "3213213221"});
                table951.AddRow(new string[] {
                            "Ext",
                            ""});
                table951.AddRow(new string[] {
                            "Website/Social",
                            ""});
                table951.AddRow(new string[] {
                            "Have Broker",
                            "No"});
#line 34
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table951, "Then ");
#line hidden
#line 47
 testRunner.Then("user verifies the appearance of the PL Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.Then("user selects their Yearly - Standard Quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.Then("user verifies the PL purchase page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table952 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table952.AddRow(new string[] {
                            "Autopay",
                            "On"});
                table952.AddRow(new string[] {
                            "CC Name",
                            "Tester EJ"});
                table952.AddRow(new string[] {
                            "CC Number",
                            "4111 1111 1111 1111"});
                table952.AddRow(new string[] {
                            "CC Expiration",
                            "03/30"});
                table952.AddRow(new string[] {
                            "Street Address",
                            "407 Main St"});
                table952.AddRow(new string[] {
                            "ZIP Code",
                            "58108"});
                table952.AddRow(new string[] {
                            "City",
                            "Buffalo"});
                table952.AddRow(new string[] {
                            "Phone",
                            "321-321-3221"});
                table952.AddRow(new string[] {
                            "Extension",
                            ""});
#line 50
 testRunner.When("user fills out the PL purchase page with these values:", ((string)(null)), table952, "When ");
#line hidden
#line 61
 testRunner.Then("user verifies the PL how would you rate our service? page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 62
 testRunner.Then("user verifies the PL thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
