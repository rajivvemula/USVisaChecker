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
namespace BiBerkLOB.Features.SmokeTest
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CanNotFindBusinessFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CanNotFindBusiness.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/SmokeTest", "CanNotFindBusiness", "Industry type is not displayed on the dropdwon\r\nUser enters Industry type as \"Sil" +
                    "ver\"\r\nUser performs Business Information", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CanNotFindBusiness")))
            {
                global::BiBerkLOB.Features.SmokeTest.CanNotFindBusinessFeature.FeatureSetup(null);
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
        
        public virtual void _01_UserNavigateUnderwriterQuestionPageForCannotFindMyIndustry(string indName, string findIndName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Smoke"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("IndName", indName);
            argumentsOfScenario.Add("FindIndName", findIndName);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01_User navigate Underwriter Question Page for cannot find my industry", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
#line 9
   testRunner.Given("user lands biBerk Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table460 = new TechTalk.SpecFlow.Table(new string[] {
                            "Options"});
                table460.AddRow(new string[] {
                            "Top Quote CTA"});
                table460.AddRow(new string[] {
                            "Dark Blue Banner WC CTA"});
                table460.AddRow(new string[] {
                            "Explore Our Insurance Products WC"});
                table460.AddRow(new string[] {
                            "Get a Quote Today"});
                table460.AddRow(new string[] {
                            "Footer WCCTA"});
#line 10
     testRunner.And("user clicks on Top Quote CTA Home page WC option", ((string)(null)), table460, "And ");
#line hidden
#line 17
 testRunner.Then("user landed on What\'s your industry page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.And(string.Format("user enters industry {0} for the question What\'s your industry for can not find y" +
                            "our business", indName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
 testRunner.And(string.Format("user enters business name {0} for the question What does your business do and cli" +
                            "cks on Lets Go CTA", findIndName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
 testRunner.Then("user landed on Do you have any employees page General", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 21
 testRunner.Then("user clicks Yes for Do you have any employees and for How many employees do you h" +
                        "ave enters 6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table461 = new TechTalk.SpecFlow.Table(new string[] {
                            "WhereDoesYourBusinessOperatePage"});
                table461.AddRow(new string[] {
                            "I Run My Business Out of My Home"});
                table461.AddRow(new string[] {
                            "I Lease a Space From Others"});
                table461.AddRow(new string[] {
                            "I Work at a Job Site"});
                table461.AddRow(new string[] {
                            "I Run My Business From Property I Own"});
                table461.AddRow(new string[] {
                            "I Own a Property & Lease to Others"});
#line 22
 testRunner.Then("user enters for Where does your business operate that I Lease a Space From Others" +
                        "", ((string)(null)), table461, "Then ");
#line hidden
#line 29
 testRunner.Then("user enters Where is your business located as 11211", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("01_User navigate Underwriter Question Page for cannot find my industry: Silver")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CanNotFindBusiness")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Smoke")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Silver")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:IndName", "Silver")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FindIndName", "Silver: Retail Store")]
        public void _01_UserNavigateUnderwriterQuestionPageForCannotFindMyIndustry_Silver()
        {
#line 8
this._01_UserNavigateUnderwriterQuestionPageForCannotFindMyIndustry("Silver", "Silver: Retail Store", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("01_User navigate Underwriter Question Page for cannot find my industry: Florist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CanNotFindBusiness")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Smoke")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Florist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:IndName", "Florist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FindIndName", "Florist: Retail Store")]
        public void _01_UserNavigateUnderwriterQuestionPageForCannotFindMyIndustry_Florist()
        {
#line 8
this._01_UserNavigateUnderwriterQuestionPageForCannotFindMyIndustry("Florist", "Florist: Retail Store", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("02_User performs Your Quote is Nearly Ready for cannot find my industry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CanNotFindBusiness")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Smoke")]
        public void _02_UserPerformsYourQuoteIsNearlyReadyForCannotFindMyIndustry()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02_User performs Your Quote is Nearly Ready for cannot find my industry", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 38
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 39
   testRunner.Given("user lands Your Quote is Nearly Ready page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 40
 testRunner.When("user enters business name Love Silver for the question What\'s the name you do bus" +
                        "iness under", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 41
 testRunner.And("user enters DBA DBA for the question What name do you do business under (if diffe" +
                        "rent than above)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.And("user enters contact name Daren and contact last name Well", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
 testRunner.And("user enters email darenw@lovesilver.com and phone number 8626802020", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 44
 testRunner.And("user enters website wwww.darensilver.com", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
 testRunner.And("user clicks on We will be In Touch CTA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("03_User navigates Your Information has been submitted page and verifes details fo" +
            "r cannot find my industry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CanNotFindBusiness")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Smoke")]
        public void _03_UserNavigatesYourInformationHasBeenSubmittedPageAndVerifesDetailsForCannotFindMyIndustry()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03_User navigates Your Information has been submitted page and verifes details fo" +
                    "r cannot find my industry", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 48
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 49
  testRunner.Given("user lands Your Information has been submitted page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 50
 testRunner.Then("user verifes Qusetion, phone number, days and times, and email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
