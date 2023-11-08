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
namespace ApolloQAAutomation.Features.PL.Referred.ServiceIndustries_Referred
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_TitleAgent_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_TitleAgent_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Referred/ServiceIndustries_Referred", "PL_TitleAgent_R", "Referral Target Question: Which property services are provided?\r\nAnswer: Real Est" +
                    "ate Agent\r\nReferral Reason: Yes to non-eligible risk. Referral need to add real " +
                    "estate agent forms.", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_TitleAgent_R")))
            {
                global::ApolloQAAutomation.Features.PL.Referred.ServiceIndustries_Referred.PL_TitleAgent_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL_TitleAgent_R Title Agent UW Question Checkbox")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_TitleAgent_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        public void PL_TitleAgent_RTitleAgentUWQuestionCheckbox()
        {
            string[] tagsOfScenario = new string[] {
                    "PL",
                    "Staging",
                    "Regression",
                    "Service",
                    "Referred"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL_TitleAgent_R Title Agent UW Question Checkbox", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1218 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1218.AddRow(new string[] {
                            "Title Agents",
                            "0",
                            "I Lease a Space From Others",
                            "",
                            "17404",
                            "PL"});
#line 9
 testRunner.Given("user starts a quote with:", ((string)(null)), table1218, "Given ");
#line hidden
#line 12
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1219 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table1219.AddRow(new string[] {
                            "Limited Liability Co. (LLC)",
                            "Test PL Refer UW Checkbox",
                            "2125 York Crossing Dr",
                            "Test DBA"});
#line 13
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1219, "Then ");
#line hidden
#line 16
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1220 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1220.AddRow(new string[] {
                            "What year was your business started?",
                            "2016"});
                table1220.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "450000"});
#line 17
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1220, "Then ");
#line hidden
#line 21
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1221 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1221.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1221.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table1221.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "I Don\'t Know"});
                table1221.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 22
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1221, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1222 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1222.AddRow(new string[] {
                            "Which property services are provided?",
                            "Real Estate Agent"});
                table1222.AddRow(new string[] {
                            "Do you collect private data?",
                            "Yes"});
                table1222.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 28
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1222, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1223 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1223.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table1223.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table1223.AddRow(new string[] {
                            "Address",
                            "100 Test Road"});
                table1223.AddRow(new string[] {
                            "City",
                            "York"});
                table1223.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1223.AddRow(new string[] {
                            "Email",
                            "test@biz.com"});
                table1223.AddRow(new string[] {
                            "Business Phone",
                            "3172491913"});
#line 33
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1223, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1224 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1224.AddRow(new string[] {
                            "Business name",
                            "Test PL Refer UW Checkbox"});
                table1224.AddRow(new string[] {
                            "DBA",
                            "Test DBA"});
                table1224.AddRow(new string[] {
                            "Contact first name",
                            "TestF"});
                table1224.AddRow(new string[] {
                            "Contact last name",
                            "TestL"});
                table1224.AddRow(new string[] {
                            "Email",
                            "test@biz.com"});
                table1224.AddRow(new string[] {
                            "Phone",
                            "(317) 249-1913"});
#line 42
 testRunner.When("user fills out the PL refer page with these values:", ((string)(null)), table1224, "When ");
#line hidden
#line 50
 testRunner.Then("user verifies the PL refer confirmation appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion