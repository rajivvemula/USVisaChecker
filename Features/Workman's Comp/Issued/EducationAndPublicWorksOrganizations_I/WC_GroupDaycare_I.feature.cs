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
namespace ApolloQAAutomation.Features.WorkmansComp.Issued.EducationAndPublicWorksOrganizations_I
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WC_GroupDaycare_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_GroupDaycare_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/EducationAndPublicWorksOrganizations_I", "WC_GroupDaycare_I", "Issued Policy For A WC Group Daycare", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_GroupDaycare_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.EducationAndPublicWorksOrganizations_I.WC_GroupDaycare_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Group Daycare Issued Policy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_GroupDaycare_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Education")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("MS")]
        public void WCGroupDaycareIssuedPolicy()
        {
            string[] tagsOfScenario = new string[] {
                    "YourServices",
                    "WC",
                    "Issued",
                    "Education",
                    "Regression",
                    "MS"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Group Daycare Issued Policy", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2102 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2102.AddRow(new string[] {
                            "Group Daycare",
                            "10",
                            "I Lease a Space From Others",
                            "",
                            "38603",
                            "WC"});
#line 5
 testRunner.Given("user starts a quote with:", ((string)(null)), table2102, "Given ");
#line hidden
#line 8
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2103 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2103.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2103.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 9 years ago"});
                table2103.AddRow(new string[] {
                            "How is your business structured?",
                            "Partnership"});
                table2103.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "440440"});
                table2103.AddRow(new string[] {
                            "Are there any licensed or certified teachers on staff?",
                            "yes"});
                table2103.AddRow(new string[] {
                            "Enter their total annual payroll",
                            "40000"});
                table2103.AddRow(new string[] {
                            "Business",
                            "Boys and Girls Club of America;BGCA"});
                table2103.AddRow(new string[] {
                            "Address",
                            "343 Broad St;Ashland"});
                table2103.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 9
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2103, "Then ");
#line hidden
#line 20
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2104 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2104.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "5+"});
                table2104.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "0"});
                table2104.AddRow(new string[] {
                            "How many owners/officers do you want to exclude from this policy? State law requi" +
                                "res that they all be excluded.",
                            "5"});
#line 21
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2104, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2105 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name"});
                table2105.AddRow(new string[] {
                            "Kirk",
                            "Hammett"});
                table2105.AddRow(new string[] {
                            "James",
                            "Hetfield"});
                table2105.AddRow(new string[] {
                            "Lars",
                            "Ulrich"});
                table2105.AddRow(new string[] {
                            "Rob",
                            "Trujillo"});
                table2105.AddRow(new string[] {
                            "Jason",
                            "Newsted"});
#line 26
 testRunner.Then("user handles the WC Excluded OO with these values:", ((string)(null)), table2105, "Then ");
#line hidden
#line 33
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2106 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2106.AddRow(new string[] {
                            "Do you require any staff to be licensed or certified as a teacher?",
                            "yes"});
                table2106.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2106.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "no"});
                table2106.AddRow(new string[] {
                            "When was your last policy in effect?",
                            "Never no prior insurance"});
                table2106.AddRow(new string[] {
                            "Do you use any volunteers or donated labor?",
                            "no"});
                table2106.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
#line 34
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2106, "Then ");
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
                TechTalk.SpecFlow.Table table2107 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2107.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 45
 testRunner.When("user selects a standard single-bundle plan quote with the following customization" +
                        "s from the WC your quote page:", ((string)(null)), table2107, "When ");
#line hidden
#line 48
 testRunner.Then("user begins the WC AI page setting the FEIN with value 23-1326965", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2108 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2108.AddRow(new string[] {
                            "Payment Option",
                            "10% Down + 10 Monthly Installments"});
                table2108.AddRow(new string[] {
                            "CC Name",
                            "Funky Chicken-cheese"});
                table2108.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2108.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2108.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2108.AddRow(new string[] {
                            "Autopay",
                            "No"});
                table2108.AddRow(new string[] {
                            "First Name",
                            "Funky"});
                table2108.AddRow(new string[] {
                            "Last Name",
                            "Kong"});
                table2108.AddRow(new string[] {
                            "Email",
                            "FunkyKong@Cheese.com"});
                table2108.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2108.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 50
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2108, "Then ");
#line hidden
#line 63
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
