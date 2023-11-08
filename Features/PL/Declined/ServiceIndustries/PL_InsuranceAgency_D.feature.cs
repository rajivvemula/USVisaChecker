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
namespace ApolloQAAutomation.Features.PL.Declined.ServiceIndustries
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PL_InsuranceAgency_DFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_InsuranceAgency_D.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Declined/ServiceIndustries", "PL_InsuranceAgency_D", "Partial Feature File added for implementing the \"Then user verifes the PL purchas" +
                    "e page appearance\" step logic - US 71967\r\nInsurance Agency Decline Path : \"Do yo" +
                    "u do any work as a public adjustor?\": \"Yes\"", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_InsuranceAgency_D")))
            {
                global::ApolloQAAutomation.Features.PL.Declined.ServiceIndustries.PL_InsuranceAgency_DFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Insurance Agency gets Declined")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_InsuranceAgency_D")]
        public void PLInsuranceAgencyGetsDeclined()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Insurance Agency gets Declined", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table888 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table888.AddRow(new string[] {
                            "Insurance Agency",
                            "5",
                            "I Lease a Space From Others",
                            "",
                            "33065",
                            "PL"});
#line 8
 testRunner.Given("user starts a quote with:", ((string)(null)), table888, "Given ");
#line hidden
#line 11
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table889 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table889.AddRow(new string[] {
                            "Limited Liability Co LLC",
                            "Samus Insurance",
                            "9604 NW 35th Ct",
                            "No"});
#line 12
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table889, "Then ");
#line hidden
#line 15
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table890 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table890.AddRow(new string[] {
                            "What year was your business started?",
                            "2019"});
                table890.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "$100,000"});
#line 16
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table890, "Then ");
#line hidden
#line 20
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table891 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table891.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table891.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table891.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "Yes"});
                table891.AddRow(new string[] {
                            "What is the retroactive date?",
                            "06/01/2022"});
                table891.AddRow(new string[] {
                            "How many Errors & Omissions claims have you had in the past 3 years, if any?",
                            "0"});
#line 21
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table891, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table892 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table892.AddRow(new string[] {
                            "What types of customers do you serve?",
                            "Individuals only"});
                table892.AddRow(new string[] {
                            "Do you provide financial investment advice?",
                            "No"});
                table892.AddRow(new string[] {
                            "Do you adjust claims?",
                            "Yes"});
                table892.AddRow(new string[] {
                            "Do you do any work as a public adjustor?",
                            "Yes"});
                table892.AddRow(new string[] {
                            "Do you adjust Asbestos, Energy, Environmental, or Marine claims?",
                            "Yes"});
                table892.AddRow(new string[] {
                            "Do you have a written procedure for handling large claims volume increases from a" +
                                " catastrophe?",
                            "No"});
                table892.AddRow(new string[] {
                            "Do you provide advice or services that require a Certified Public Accountant?",
                            "No"});
                table892.AddRow(new string[] {
                            "Which types of Property & Casualty insurance do you sell?",
                            "Homeowners"});
                table892.AddRow(new string[] {
                            "Do you sell insurance products directly over the internet?",
                            "No"});
                table892.AddRow(new string[] {
                            "Do you act as a broker for any reinsurance contracts such as quota shares or exce" +
                                "ss loss treaties?",
                            "Yes"});
                table892.AddRow(new string[] {
                            "Do you function as a Managing General Agent/Underwriter (MGA)?",
                            "No"});
                table892.AddRow(new string[] {
                            "Do you create, manage, or provide services for a Health Maintenance Organization " +
                                "(HMO) plan?",
                            "No"});
                table892.AddRow(new string[] {
                            "Do you help set up or service self-insurance, risk retention groups, or captives?" +
                                "",
                            "Yes"});
                table892.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 28
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table892, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table893 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table893.AddRow(new string[] {
                            "First Name",
                            "Test"});
                table893.AddRow(new string[] {
                            "Last Name",
                            "Zero"});
                table893.AddRow(new string[] {
                            "Address",
                            "100 Main St"});
                table893.AddRow(new string[] {
                            "Appt/Suite",
                            ""});
                table893.AddRow(new string[] {
                            "City",
                            "Coral Springs"});
                table893.AddRow(new string[] {
                            "Email",
                            "zero@samus.com"});
                table893.AddRow(new string[] {
                            "Business Phone",
                            "2789282892"});
#line 44
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table893, "Then ");
#line hidden
#line 53
 testRunner.Then("user verifies the PL decline page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion