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
    public partial class WC_ComputerTrainingSchool_IFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "WC_ComputerTrainingSchool_I.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Workman\'s Comp/Issued/EducationAndPublicWorksOrganizations_I", "WC_ComputerTrainingSchool_I", "Issuing a Computer Training School policy in Kansas", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WC_ComputerTrainingSchool_I")))
            {
                global::ApolloQAAutomation.Features.WorkmansComp.Issued.EducationAndPublicWorksOrganizations_I.WC_ComputerTrainingSchool_IFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("WC Computer Training School issued policy in KS")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WC_ComputerTrainingSchool_I")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Issued")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Education")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("KS")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("YourServices")]
        public void WCComputerTrainingSchoolIssuedPolicyInKS()
        {
            string[] tagsOfScenario = new string[] {
                    "WC",
                    "Issued",
                    "Education",
                    "Regression",
                    "KS",
                    "YourServices"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WC Computer Training School issued policy in KS", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2085 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table2085.AddRow(new string[] {
                            "Computer Training School",
                            "10",
                            "I Lease a Space From Others",
                            "",
                            "66103",
                            "WC"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table2085, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the WC About You Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2086 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2086.AddRow(new string[] {
                            "When do you want your policy to start?",
                            ""});
                table2086.AddRow(new string[] {
                            "When did you start your business?",
                            "Started 9 years ago"});
                table2086.AddRow(new string[] {
                            "How is your business structured?",
                            "Partnership"});
                table2086.AddRow(new string[] {
                            "What is the total annual payroll for W-2 employees? (exclude business owners/offi" +
                                "cers)",
                            "440440"});
                table2086.AddRow(new string[] {
                            "Are there any security personnel, maintenance, janitorial, bus drivers, or food s" +
                                "ervice workers?",
                            "no"});
                table2086.AddRow(new string[] {
                            "Business",
                            "Kansas Computer Training center"});
                table2086.AddRow(new string[] {
                            "Address",
                            "4215 Rainbow Blvd;Kansas City"});
                table2086.AddRow(new string[] {
                            "Fill Contact",
                            ""});
#line 10
 testRunner.Then("user fills out the WC About You page with these values:", ((string)(null)), table2086, "Then ");
#line hidden
#line 20
 testRunner.Then("user verifies the appearance of the WC Owners and Officers Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2087 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2087.AddRow(new string[] {
                            "How many owners/officers does your business have?",
                            "3"});
                table2087.AddRow(new string[] {
                            "How many owners/officers do you want to cover with this policy?",
                            "1"});
#line 21
 testRunner.Then("user handles the WC OO kickoff questions with these values:", ((string)(null)), table2087, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2088 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name",
                            "Job Duty"});
                table2088.AddRow(new string[] {
                            "Billy",
                            "Bob",
                            "Professor, Teacher, or Admin"});
#line 25
 testRunner.Then("user handles the WC Covered OO with these values:", ((string)(null)), table2088, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2089 = new TechTalk.SpecFlow.Table(new string[] {
                            "First Name",
                            "Last Name"});
                table2089.AddRow(new string[] {
                            "Madison",
                            "Ken"});
                table2089.AddRow(new string[] {
                            "Emilee",
                            "Harrison"});
#line 28
 testRunner.Then("user handles the WC Excluded OO with these values:", ((string)(null)), table2089, "Then ");
#line hidden
#line 32
 testRunner.Then("user continues on from the WC OO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2090 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question",
                            "Answer"});
                table2090.AddRow(new string[] {
                            "In the past 3 years how many Workers\' Compensation claims were reported?",
                            "None"});
                table2090.AddRow(new string[] {
                            "Are any children or students younger than five years old?",
                            "No"});
                table2090.AddRow(new string[] {
                            "Do you currently have a Workers\' Compensation insurance policy in effect?",
                            "yes"});
                table2090.AddRow(new string[] {
                            "Do you use any volunteers or donated labor?",
                            "no"});
                table2090.AddRow(new string[] {
                            "Do you have multiple locations in more than one state?",
                            "no"});
                table2090.AddRow(new string[] {
                            "Federal Employer Identification Number (FEIN)",
                            "23-1326965"});
#line 33
 testRunner.Then("user fills out the WC Your Services page", ((string)(null)), table2090, "Then ");
#line hidden
#line 41
 testRunner.Then("user verifies the appearance of the WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
    testRunner.Then("user clicks continue from WC Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
    testRunner.Then("user verifies the WC your quote page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2091 = new TechTalk.SpecFlow.Table(new string[] {
                            "Customization",
                            "Value"});
                table2091.AddRow(new string[] {
                            "ELL - Each Accident / Total Policy / Each Employee",
                            "100,000/500,000/100,000"});
#line 44
 testRunner.When("user selects a Plus plan quote with the following customizations from the WC your" +
                        " quote page:", ((string)(null)), table2091, "When ");
#line hidden
#line 47
 testRunner.Then("user begins the WC AI page having the FEIN with value 23-1326965", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.Then("user continues on from the WC Additional Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2092 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2092.AddRow(new string[] {
                            "Payment Option",
                            "15% Down + 9 Monthly Installments"});
                table2092.AddRow(new string[] {
                            "CC Name",
                            "Test Pay"});
                table2092.AddRow(new string[] {
                            "CC Number",
                            "4111111111111111"});
                table2092.AddRow(new string[] {
                            "CC Expiration Month",
                            "11"});
                table2092.AddRow(new string[] {
                            "CC Expiration Year",
                            "25"});
                table2092.AddRow(new string[] {
                            "Autopay",
                            "No"});
                table2092.AddRow(new string[] {
                            "First Name",
                            "FN"});
                table2092.AddRow(new string[] {
                            "Last Name",
                            "LN"});
                table2092.AddRow(new string[] {
                            "Email",
                            "FNLN@gamil.com"});
                table2092.AddRow(new string[] {
                            "Phone",
                            "7777777777"});
                table2092.AddRow(new string[] {
                            "Same Billing Info?",
                            "Yes"});
#line 49
 testRunner.Then("user fills out the WC purchase page with these values:", ((string)(null)), table2092, "Then ");
#line hidden
#line 62
 testRunner.Then("user verifies the WC how would you rate our service modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 63
 testRunner.Then("user verifies the WC thank you page appearance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
