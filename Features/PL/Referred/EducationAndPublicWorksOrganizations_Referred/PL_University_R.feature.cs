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
namespace ApolloQAAutomation.Features.PL.Referred.EducationAndPublicWorksOrganizations_Referred
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_University_RFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_University_R.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Referred/EducationAndPublicWorksOrganizations_Referred", "PL_University_R", "Feature File that verifies certain classes automatically result in a referral", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_University_R")))
            {
                global::ApolloQAAutomation.Features.PL.Referred.EducationAndPublicWorksOrganizations_Referred.PL_University_RFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL University class referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_University_R")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Referred")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL_University_R")]
        public void PLUniversityClassReferred()
        {
            string[] tagsOfScenario = new string[] {
                    "PL",
                    "Referred",
                    "Service",
                    "Regression",
                    "Staging",
                    "PL_University_R"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL University class referred", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1140 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1140.AddRow(new string[] {
                            "University",
                            "10",
                            "I Lease a Space From Others",
                            "",
                            "80011",
                            "PL"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1140, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1141 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table1141.AddRow(new string[] {
                            "Corporation",
                            "TEST PL API CASE 17",
                            "1250 Chambers Rd",
                            "No"});
#line 11
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table1141, "Then ");
#line hidden
#line 14
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1142 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1142.AddRow(new string[] {
                            "What year was your business started?",
                            "2021"});
                table1142.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "50000"});
#line 15
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table1142, "Then ");
#line hidden
#line 19
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1143 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1143.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table1143.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "No"});
                table1143.AddRow(new string[] {
                            "Have you had a Professional Liability (E&O) policy in the last 3 years?",
                            "Yes"});
                table1143.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 20
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table1143, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1144 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1144.AddRow(new string[] {
                            "Describe the type of training/education provided:",
                            "TEST UNIVERSITY CASE 17"});
                table1144.AddRow(new string[] {
                            "Do you provide medical training?",
                            "No"});
                table1144.AddRow(new string[] {
                            "Do you provide driving or flying instruction?",
                            "No"});
                table1144.AddRow(new string[] {
                            "Do you provide law enforcement or security guard services or training?",
                            "No"});
                table1144.AddRow(new string[] {
                            "Do you train animals?",
                            "No"});
                table1144.AddRow(new string[] {
                            "Do you have nurses on staff?",
                            "No"});
                table1144.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 26
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table1144, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1145 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1145.AddRow(new string[] {
                            "First Name",
                            "TEST PL API"});
                table1145.AddRow(new string[] {
                            "Last Name",
                            "TEST CASE 17"});
                table1145.AddRow(new string[] {
                            "Address",
                            "3475 N Salida St"});
                table1145.AddRow(new string[] {
                            "City",
                            "Aurora"});
                table1145.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table1145.AddRow(new string[] {
                            "Email",
                            "TestCert@Plan.com"});
                table1145.AddRow(new string[] {
                            "Business Phone",
                            "(123) 123-1321"});
                table1145.AddRow(new string[] {
                            "Ext",
                            "1234"});
                table1145.AddRow(new string[] {
                            "Website/Social",
                            "TestPartnerCert.com"});
#line 35
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table1145, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1146 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1146.AddRow(new string[] {
                            "Business name",
                            "TEST PL API CASE 17"});
                table1146.AddRow(new string[] {
                            "Contact first name",
                            "Test PL API"});
                table1146.AddRow(new string[] {
                            "Contact last name",
                            "TEST CASE 17"});
                table1146.AddRow(new string[] {
                            "Email",
                            "TestCert@Plan.com"});
                table1146.AddRow(new string[] {
                            "Phone",
                            "(123) 123-1231"});
                table1146.AddRow(new string[] {
                            "Ext",
                            "1234"});
                table1146.AddRow(new string[] {
                            "Business website",
                            "www.TestPartnerCert.com"});
#line 46
 testRunner.When("user fills out the PL refer page with these values:", ((string)(null)), table1146, "When ");
#line hidden
#line 55
 testRunner.Then("user verifies the PL refer confirmation appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
