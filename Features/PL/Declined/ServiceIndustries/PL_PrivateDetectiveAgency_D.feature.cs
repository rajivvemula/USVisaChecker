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
    public partial class PL_PrivateDetectiveAgency_DFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PL_PrivateDetectiveAgency_D.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/PL/Declined/ServiceIndustries", "PL_PrivateDetectiveAgency_D", "Declination of the Private Detective Agency keyword caused by answering the \"Do y" +
                    "ou provide bodyguard services?\" in the affirmative.\r\n21 W 75th St, New York, NY " +
                    "10023", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PL_PrivateDetectiveAgency_D")))
            {
                global::ApolloQAAutomation.Features.PL.Declined.ServiceIndustries.PL_PrivateDetectiveAgency_DFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL Private Detective Agency declined Private detective bodyguard")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_PrivateDetectiveAgency_D")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Declined")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        public void PLPrivateDetectiveAgencyDeclinedPrivateDetectiveBodyguard()
        {
            string[] tagsOfScenario = new string[] {
                    "PL",
                    "Declined",
                    "Service"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL Private Detective Agency declined Private detective bodyguard", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table912 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table912.AddRow(new string[] {
                            "Private Detective Agency",
                            "7",
                            "I Own a Property & Lease to Others",
                            "",
                            "10023",
                            "PL"});
#line 8
 testRunner.Given("user starts a quote with:", ((string)(null)), table912, "Given ");
#line hidden
#line 11
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table913 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Name of Business",
                            "Business Address",
                            "DBA"});
                table913.AddRow(new string[] {
                            "Limited Liability Co LLC",
                            "Guardian Detective Agency",
                            "21 W 75th St",
                            "GDA"});
#line 12
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table913, "Then ");
#line hidden
#line 15
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table914 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table914.AddRow(new string[] {
                            "What year was your business started?",
                            "1990"});
                table914.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "700,000"});
#line 16
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table914, "Then ");
#line hidden
#line 20
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table915 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table915.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table915.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table915.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "No"});
                table915.AddRow(new string[] {
                            "Which option best describes your current professional liability policy?",
                            "This was my first policy."});
                table915.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "0"});
#line 21
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table915, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table916 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table916.AddRow(new string[] {
                            "Do you provide security services for any of these?",
                            "None of the Above"});
                table916.AddRow(new string[] {
                            "Do you provide emergency response services?",
                            "No"});
                table916.AddRow(new string[] {
                            "Do you do work outside the U.S. and Canada?",
                            "No"});
                table916.AddRow(new string[] {
                            "Do you engage in bail bond recovery, bounty hunting, car repossession, or evictio" +
                                "ns?",
                            "No"});
                table916.AddRow(new string[] {
                            "Do you provide bodyguard services?",
                            "Yes"});
                table916.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 28
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table916, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table917 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table917.AddRow(new string[] {
                            "First Name",
                            "Barney"});
                table917.AddRow(new string[] {
                            "Last Name",
                            "Calhoun"});
                table917.AddRow(new string[] {
                            "Address",
                            "21 W 75th St"});
                table917.AddRow(new string[] {
                            "Apt/Suite",
                            "1"});
                table917.AddRow(new string[] {
                            "City",
                            "New York"});
                table917.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table917.AddRow(new string[] {
                            "Email",
                            "test@biz.com"});
                table917.AddRow(new string[] {
                            "Business Phone",
                            "7777777777"});
                table917.AddRow(new string[] {
                            "Ext",
                            "7777"});
                table917.AddRow(new string[] {
                            "Website/Social",
                            "www.test.com"});
                table917.AddRow(new string[] {
                            "Have Broker",
                            "No"});
#line 36
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table917, "Then ");
#line hidden
#line 49
 testRunner.Then("user verifies the PL decline page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PL_PrivateDetectiveAgency_D Private detective UW Question Decline")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PL_PrivateDetectiveAgency_D")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("PL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Declined")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Staging")]
        public void PL_PrivateDetectiveAgency_DPrivateDetectiveUWQuestionDecline()
        {
            string[] tagsOfScenario = new string[] {
                    "PL",
                    "Declined",
                    "Service",
                    "Staging"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PL_PrivateDetectiveAgency_D Private detective UW Question Decline", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 52
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table918 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table918.AddRow(new string[] {
                            "Private Detective Agency",
                            "2",
                            "I Own a Property & Lease to Others",
                            "",
                            "55322",
                            "PL"});
#line 53
 testRunner.Given("user starts a quote with:", ((string)(null)), table918, "Given ");
#line hidden
#line 56
 testRunner.Then("user verifies the appearance of the PL A Quick Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table919 = new TechTalk.SpecFlow.Table(new string[] {
                            "Business Structure",
                            "Business Address",
                            "DBA"});
                table919.AddRow(new string[] {
                            "Individual/Sole Proprietor",
                            "11360 US-212",
                            "TPAC25"});
#line 57
 testRunner.Then("user fills out A Quick Introduction page with these values:", ((string)(null)), table919, "Then ");
#line hidden
#line 60
 testRunner.Then("user verifies the appearance of the PL Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table920 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table920.AddRow(new string[] {
                            "What year was your business started?",
                            "2021"});
                table920.AddRow(new string[] {
                            "What is your estimated gross annual revenue?",
                            "225,000"});
#line 61
 testRunner.Then("user fills out the PL Business Details page with these values:", ((string)(null)), table920, "Then ");
#line hidden
#line 65
 testRunner.Then("user verifies the appearance of the PL Coverage Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table921 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table921.AddRow(new string[] {
                            "When should your policy start?",
                            ""});
                table921.AddRow(new string[] {
                            "Do you currently have a Professional Liability (E&O) policy in effect?",
                            "Yes"});
                table921.AddRow(new string[] {
                            "Does your current policy have a retroactive date?",
                            "No"});
                table921.AddRow(new string[] {
                            "Which option best describes your current professional liability policy?",
                            "This was my first policy."});
                table921.AddRow(new string[] {
                            "How many Professional Liability (E&O) claims have you had in the past 3 years, if" +
                                " any?",
                            "3"});
#line 66
 testRunner.Then("user fills out the PL Coverage Details page with these values:", ((string)(null)), table921, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table922 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table922.AddRow(new string[] {
                            "Do you provide security services for any of these?",
                            "Airports"});
                table922.AddRow(new string[] {
                            "Do you provide emergency response services?",
                            "No"});
                table922.AddRow(new string[] {
                            "Do you do work outside the U.S. and Canada?",
                            "No"});
                table922.AddRow(new string[] {
                            "Are there any drivers that drive trucks you own but pay via 1099?",
                            "No"});
                table922.AddRow(new string[] {
                            "Do you engage in bail bond recovery, bounty hunting, car repossession, or evictio" +
                                "ns?",
                            "No"});
                table922.AddRow(new string[] {
                            "Do you provide bodyguard services?",
                            "No"});
                table922.AddRow(new string[] {
                            "In the past 3 years, has any party threatened or made claims for damages or other" +
                                " legal remedies against you or against any business entity with which you or any" +
                                " other business owner have been associated as owner, principal, officer, or empl" +
                                "oyee?",
                            "No"});
#line 73
 testRunner.Then("user fills out the PL Your Services page", ((string)(null)), table922, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table923 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table923.AddRow(new string[] {
                            "First Name",
                            "TEST PL API"});
                table923.AddRow(new string[] {
                            "Last Name",
                            "TEST CASE 25"});
                table923.AddRow(new string[] {
                            "Address",
                            "15580 114TH sT"});
                table923.AddRow(new string[] {
                            "Apt/Suite",
                            ""});
                table923.AddRow(new string[] {
                            "City",
                            "Young America"});
                table923.AddRow(new string[] {
                            "Use as Mailing Address",
                            "Yes"});
                table923.AddRow(new string[] {
                            "Email",
                            "test@biz.com"});
                table923.AddRow(new string[] {
                            "Business Phone",
                            "1231231321"});
                table923.AddRow(new string[] {
                            "Ext",
                            "1234"});
                table923.AddRow(new string[] {
                            "Website/Social",
                            "TestPartnerCert.com"});
                table923.AddRow(new string[] {
                            "Have Broker",
                            "No"});
#line 82
 testRunner.Then("user fills out About You page with these values:", ((string)(null)), table923, "Then ");
#line hidden
#line 95
 testRunner.Then("user verifies the PL decline page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
