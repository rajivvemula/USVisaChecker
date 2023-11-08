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
namespace BiBerkLOB.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class QuoteSavingFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "QuoteSaving.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "QuoteSaving", "Ensuring tests are able to save quote ID for future use", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "QuoteSaving")))
            {
                global::BiBerkLOB.Features.QuoteSavingFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("test saves a PL quote ID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "QuoteSaving")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("QuoteSave")]
        public void TestSavesAPLQuoteID()
        {
            string[] tagsOfScenario = new string[] {
                    "Internal",
                    "QuoteSave"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test saves a PL quote ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
#line 7
 testRunner.Given("no quote ID is set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1212 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1212.AddRow(new string[] {
                            "Magazine Publishing",
                            "3",
                            "I Lease a Space From Others",
                            "",
                            "67155",
                            "PL"});
#line 8
 testRunner.And("user starts a quote with:", ((string)(null)), table1212, "And ");
#line hidden
                TechTalk.SpecFlow.Table table1213 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "State"});
                table1213.AddRow(new string[] {
                            "Magazine Publishing",
                            "Kansas"});
#line 11
 testRunner.When("user saves their PL quote ID", ((string)(null)), table1213, "When ");
#line hidden
#line 14
 testRunner.Then("saved quote ID should persist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 15
 testRunner.And("output the saved quote ID", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("test saves a CA quote ID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "QuoteSaving")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("QuoteSave")]
        public void TestSavesACAQuoteID()
        {
            string[] tagsOfScenario = new string[] {
                    "Internal",
                    "QuoteSave"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test saves a CA quote ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 19
 testRunner.Given("no quote ID is set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1214 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1214.AddRow(new string[] {
                            "Food Truck",
                            "0",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "60004",
                            "CA"});
#line 20
 testRunner.And("user starts a quote with:", ((string)(null)), table1214, "And ");
#line hidden
                TechTalk.SpecFlow.Table table1215 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "State"});
                table1215.AddRow(new string[] {
                            "Food Truck",
                            "Illinois"});
#line 23
 testRunner.When("user saves their CA quote ID", ((string)(null)), table1215, "When ");
#line hidden
#line 26
 testRunner.Then("saved quote ID should persist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
 testRunner.And("output the saved quote ID", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("test saves a WC quote ID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "QuoteSaving")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("QuoteSave")]
        public void TestSavesAWCQuoteID()
        {
            string[] tagsOfScenario = new string[] {
                    "Internal",
                    "QuoteSave"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test saves a WC quote ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 31
 testRunner.Given("no quote ID is set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1216 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1216.AddRow(new string[] {
                            "Acoustical Insulation Material Installation: No Ceilings",
                            "3",
                            "I Lease a Space From Others",
                            "",
                            "85383",
                            "WC"});
#line 32
 testRunner.And("user starts a quote with:", ((string)(null)), table1216, "And ");
#line hidden
                TechTalk.SpecFlow.Table table1217 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "State"});
                table1217.AddRow(new string[] {
                            "Acoustical Insulation Material Installation: No Ceilings",
                            "Illinois"});
#line 35
 testRunner.When("user saves their WC quote ID", ((string)(null)), table1217, "When ");
#line hidden
#line 38
 testRunner.Then("saved quote ID should persist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 39
 testRunner.And("output the saved quote ID", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("test saves a CA quote ID with a reason")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "QuoteSaving")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("QuoteSave")]
        public void TestSavesACAQuoteIDWithAReason()
        {
            string[] tagsOfScenario = new string[] {
                    "Internal",
                    "QuoteSave"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test saves a CA quote ID with a reason", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 42
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 43
 testRunner.Given("no quote ID is set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1218 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1218.AddRow(new string[] {
                            "Food Truck",
                            "0",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "60004",
                            "CA"});
#line 44
 testRunner.And("user starts a quote with:", ((string)(null)), table1218, "And ");
#line hidden
                TechTalk.SpecFlow.Table table1219 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "State",
                            "Save Reason"});
                table1219.AddRow(new string[] {
                            "Food Truck",
                            "Illinois",
                            "Want to send to app insights"});
#line 47
 testRunner.When("user saves their CA quote ID", ((string)(null)), table1219, "When ");
#line hidden
#line 50
 testRunner.Then("saved quote ID should have a reason", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.And("output the saved quote ID", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("test saves a CA quote ID without a reason")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "QuoteSaving")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("QuoteSave")]
        public void TestSavesACAQuoteIDWithoutAReason()
        {
            string[] tagsOfScenario = new string[] {
                    "Internal",
                    "QuoteSave"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test saves a CA quote ID without a reason", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 54
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 55
 testRunner.Given("no quote ID is set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1220 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table1220.AddRow(new string[] {
                            "Food Truck",
                            "0",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "60004",
                            "CA"});
#line 56
 testRunner.And("user starts a quote with:", ((string)(null)), table1220, "And ");
#line hidden
                TechTalk.SpecFlow.Table table1221 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "State"});
                table1221.AddRow(new string[] {
                            "Food Truck",
                            "Illinois"});
#line 59
 testRunner.When("user saves their CA quote ID", ((string)(null)), table1221, "When ");
#line hidden
#line 62
 testRunner.Then("saved quote ID should not have a reason", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 63
 testRunner.And("output the saved quote ID", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion