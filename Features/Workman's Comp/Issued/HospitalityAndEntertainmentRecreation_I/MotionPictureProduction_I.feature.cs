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
namespace BiBerkLOB.Features.WorkmansComp.Issued.HospitalityAndEntertainmentRecreation_I
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class MotionPictureProduction_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "MotionPictureProduction_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/HospitalityAndEntertainmentRecreation_I", "MotionPictureProduction_I", "Issuing a Motion Picture Production policy on OK", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "MotionPictureProduction_I")))
            {
                global::BiBerkLOB.Features.WorkmansComp.Issued.HospitalityAndEntertainmentRecreation_I.MotionPictureProduction_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("MotionPictureProduction_I creates issued policy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MotionPictureProduction_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Hospitality")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OK")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void MotionPictureProduction_ICreatesIssuedPolicy()
        {
            string[] tagsOfScenario = new string[] {
                    "Hospitality",
                    "WC",
                    "Issued",
                    "OK",
                    "Regression",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MotionPictureProduction_I creates issued policy", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table1501 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1501.AddRow(new string[] {
                            "Motion Picture Production",
                            "3",
                            "I work at a job site",
                            "",
                            "74820",
                            "WC"});
#line 7
 testRunner.Given("user starts a quote with:", ((string)(null)), table1501, "Given ");
#line hidden
#line 10
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1502 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1502.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table1502.AddRow(new string[] {
                            "When did you start your business?",
                            "Started last year"});
                table1502.AddRow(new string[] {
                            "How is your business structured?",
                            "Corporation"});
                table1502.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "50000"});
                table1502.AddRow(new string[] {
                            "Do you make any payments to workers using IRS Form 1099?",
                            "no"});
                table1502.AddRow(new string[] {
                            "Business",
                            "New Hollywood in OK"});
                table1502.AddRow(new string[] {
                            "Address",
                            "200 S Broadway Ave;Ada"});
                table1502.AddRow(new string[] {
                            "Contact First Name",
                            "TestF"});
                table1502.AddRow(new string[] {
                            "Contact Last Name",
                            "TestL"});
                table1502.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table1502.AddRow(new string[] {
                            "Phone",
                            "1231231321"});
                table1502.AddRow(new string[] {
                            "Business website",
                            ""});
#line 11
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table1502, "Then ");
#line hidden
#line 25
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1503 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1503.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "2"});
                table1503.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "1"});
#line 26
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table1503, "Then ");
#line hidden
#line 30
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1504 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table1504.AddRow(new string[] {
                            "Do you use pyrotechnics?",
                            "no"});
                table1504.AddRow(new string[] {
                            "Do you film choreographed fight scenes?",
                            "no"});
                table1504.AddRow(new string[] {
                            "Do you perform acts with knives, other sharp objects, fire, or live ammunition?",
                            "no"});
                table1504.AddRow(new string[] {
                            "Do you film car, motorcycle, or ATV stunts or chase scenes?",
                            "no"});
                table1504.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table1504.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table1504.AddRow(new string[] {
                            "Do you use any volunteers or donated labor?",
                            "no"});
                table1504.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
#line 31
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table1504, "Then ");
#line hidden
#line 41
    testRunner.Then("user verifies the WC your quote page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1505 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table1505.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 42
 testRunner.When("user selects a standard multi-bundle plan quote with the following customizations" +
                        " from the WC your quote page:", ((string)(null)), table1505, "When ");
#line hidden
#line 45
    testRunner.Then("user begins the WC AI page setting the FEIN with value 23-1234567", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1506 = new TechTalk.SpecFlow.Table(new string[] {
                            "Set Name"});
                table1506.AddRow(new string[] {
                            "Aaaa Bbbb"});
                table1506.AddRow(new string[] {
                            "Cccc Dddd"});
#line 46
 testRunner.Then("wc user handles 2 excluded oo with these values:", ((string)(null)), table1506, "Then ");
#line hidden
#line 50
    testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1507 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1507.AddRow(new string[] {
                            "Payment Option",
                            "One Pay Plan"});
                table1507.AddRow(new string[] {
                            "CC Name",
                            "TestF TestL"});
                table1507.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table1507.AddRow(new string[] {
                            "CC Expiration Month",
                            "03"});
                table1507.AddRow(new string[] {
                            "CC Expiration Year",
                            "30"});
                table1507.AddRow(new string[] {
                            "Autopay",
                            "Yes"});
                table1507.AddRow(new string[] {
                            "First Name",
                            "TestF"});
                table1507.AddRow(new string[] {
                            "Last Name",
                            "TestL"});
                table1507.AddRow(new string[] {
                            "Email",
                            "Test@Test123.com"});
                table1507.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table1507.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 51
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table1507, "Then ");
#line hidden
#line 64
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 65
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.Then("user verifies that these LOBs are recommended: PL", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion