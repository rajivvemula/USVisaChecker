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
namespace BiBerkLOB.Features.CommAuto.Unit
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CA_VehiclePage_HelpErrorTxtFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "CA_VehiclePage_HelpErrorTxt.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Comm Auto/Unit", "CA_VehiclePage_HelpErrorTxt", "This file validates the appearence of help and error text on the vehicles page", ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CA_VehiclePage_HelpErrorTxt")))
            {
                global::BiBerkLOB.Features.CommAuto.Unit.CA_VehiclePage_HelpErrorTxtFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CA_VehiclePage_HelpErrorTxt validates the help and error text appears on the vehi" +
            "cle page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CA_VehiclePage_HelpErrorTxt")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Unit")]
        public void CA_VehiclePage_HelpErrorTxtValidatesTheHelpAndErrorTextAppearsOnTheVehiclePage()
        {
            string[] tagsOfScenario = new string[] {
                    "Unit"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CA_VehiclePage_HelpErrorTxt validates the help and error text appears on the vehi" +
                    "cle page", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table680 = new TechTalk.SpecFlow.Table(new string[] {
                            "Industry",
                            "Employees",
                            "Location",
                            "Own or Lease",
                            "ZIP Code",
                            "LOB"});
                table680.AddRow(new string[] {
                            "Food Truck",
                            "0",
                            "I Run My Business From Property I Own",
                            "Vehicles",
                            "60004",
                            "CA"});
#line 6
 testRunner.Given("user starts a quote with:", ((string)(null)), table680, "Given ");
#line hidden
#line 9
 testRunner.Then("user verifies the appearance of the Start Your Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table681 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name of Business",
                            "DBA",
                            "Policy Start Date"});
                table681.AddRow(new string[] {
                            "TEST CA AUTH REFER",
                            "",
                            ""});
#line 10
 testRunner.Then("user fills in the Start Your Quote page with these values:", ((string)(null)), table681, "Then ");
#line hidden
#line 13
 testRunner.Then("user verifies the appearance of the Introduction page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table682 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year Business Started",
                            "How Business Structured",
                            "Address1",
                            "Address2",
                            "City",
                            "Select an Address"});
                table682.AddRow(new string[] {
                            "2010",
                            "Limited Liability Co. (LLC)",
                            "1600 N Yale Ave",
                            "",
                            "Arlington Heights",
                            "Original"});
#line 14
 testRunner.And("user fills in the Introduction page with these values:", ((string)(null)), table682, "And ");
#line hidden
#line 17
 testRunner.Then("user verifies the appearance of the Vehicles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.Then("user clicks Let\'s Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table683 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table683.AddRow(new string[] {
                            "isVinTelligence",
                            "Error"});
#line 19
 testRunner.Then("user verifies the following front end help and error text of the Vehicle Page:", ((string)(null)), table683, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table684 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN"});
                table684.AddRow(new string[] {
                            ""});
#line 22
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table684, "And ");
#line hidden
                TechTalk.SpecFlow.Table table685 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table685.AddRow(new string[] {
                            "isVinTelligence",
                            "Help"});
                table685.AddRow(new string[] {
                            "vinNumber",
                            "Error"});
#line 25
 testRunner.Then("user verifies the following front end help and error text of the Vehicle Page:", ((string)(null)), table685, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table686 = new TechTalk.SpecFlow.Table(new string[] {
                            "VIN"});
                table686.AddRow(new string[] {
                            "1GNFK13067J109399"});
#line 29
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table686, "And ");
#line hidden
                TechTalk.SpecFlow.Table table687 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table687.AddRow(new string[] {
                            "details",
                            "Help"});
#line 32
 testRunner.Then("user verifies the following front end help and error text of the Vehicle Page:", ((string)(null)), table687, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table688 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table688.AddRow(new string[] {
                            "VehicleUse",
                            "Error"});
#line 35
 testRunner.Then("user verifies the following Apollo help and error text of the Vehicle Page:", ((string)(null)), table688, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table689 = new TechTalk.SpecFlow.Table(new string[] {
                            "No VIN"});
                table689.AddRow(new string[] {
                            ""});
#line 38
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table689, "And ");
#line hidden
                TechTalk.SpecFlow.Table table690 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table690.AddRow(new string[] {
                            "vehicleCategory",
                            "Error"});
                table690.AddRow(new string[] {
                            "yearOfManufacture",
                            "Error"});
#line 41
 testRunner.Then("user verifies the following front end help and error text of the Vehicle Page:", ((string)(null)), table690, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table691 = new TechTalk.SpecFlow.Table(new string[] {
                            "Year",
                            "Enter Year Make Model"});
                table691.AddRow(new string[] {
                            "2007",
                            ""});
#line 45
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table691, "And ");
#line hidden
                TechTalk.SpecFlow.Table table692 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table692.AddRow(new string[] {
                            "make",
                            "Error"});
#line 48
 testRunner.Then("user verifies the following front end help and error text of the Vehicle Page:", ((string)(null)), table692, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table693 = new TechTalk.SpecFlow.Table(new string[] {
                            "Make",
                            "Enter Year Make Model"});
                table693.AddRow(new string[] {
                            "CHEVROLET",
                            ""});
#line 51
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table693, "And ");
#line hidden
                TechTalk.SpecFlow.Table table694 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table694.AddRow(new string[] {
                            "model",
                            "Error"});
#line 54
 testRunner.Then("user verifies the following front end help and error text of the Vehicle Page:", ((string)(null)), table694, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table695 = new TechTalk.SpecFlow.Table(new string[] {
                            "Model"});
                table695.AddRow(new string[] {
                            "TAHOE"});
#line 57
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table695, "And ");
#line hidden
                TechTalk.SpecFlow.Table table696 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table696.AddRow(new string[] {
                            "VehicleValue",
                            "Help"});
#line 60
 testRunner.Then("user verifies the following Apollo help and error text of the Vehicle Page:", ((string)(null)), table696, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table697 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type Insure"});
                table697.AddRow(new string[] {
                            "Food Truck"});
#line 63
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table697, "And ");
#line hidden
                TechTalk.SpecFlow.Table table698 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table698.AddRow(new string[] {
                            "GVWr",
                            "Help"});
#line 66
 testRunner.Then("user verifies the following Apollo help and error text of the Vehicle Page:", ((string)(null)), table698, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table699 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type Insure"});
                table699.AddRow(new string[] {
                            "Limousine: seating less than 10"});
#line 69
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table699, "And ");
#line hidden
                TechTalk.SpecFlow.Table table700 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table700.AddRow(new string[] {
                            "Seatbelts",
                            "Error"});
#line 72
 testRunner.Then("user verifies the following Apollo help and error text of the Vehicle Page:", ((string)(null)), table700, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table701 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type Insure"});
                table701.AddRow(new string[] {
                            "Bus"});
#line 75
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table701, "And ");
#line hidden
                TechTalk.SpecFlow.Table table702 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table702.AddRow(new string[] {
                            "VehicleSeatCount",
                            "Error"});
#line 78
 testRunner.Then("user verifies the following Apollo help and error text of the Vehicle Page:", ((string)(null)), table702, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table703 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type Insure"});
                table703.AddRow(new string[] {
                            "Tow Truck: Tilt Bed"});
#line 81
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table703, "And ");
#line hidden
                TechTalk.SpecFlow.Table table704 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table704.AddRow(new string[] {
                            "Repossession",
                            "Error"});
#line 84
 testRunner.Then("user verifies the following Apollo help and error text of the Vehicle Page:", ((string)(null)), table704, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table705 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type Insure"});
                table705.AddRow(new string[] {
                            "Dump Truck"});
#line 87
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table705, "And ");
#line hidden
                TechTalk.SpecFlow.Table table706 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table706.AddRow(new string[] {
                            "Landfills",
                            "Error"});
#line 90
 testRunner.Then("user verifies the following Apollo help and error text of the Vehicle Page:", ((string)(null)), table706, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table707 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type Insure"});
                table707.AddRow(new string[] {
                            "Other Open Trailer"});
#line 93
 testRunner.And("user creates a vehicle or trailer with variable values:", ((string)(null)), table707, "And ");
#line hidden
                TechTalk.SpecFlow.Table table708 = new TechTalk.SpecFlow.Table(new string[] {
                            "Question Alias",
                            "Type"});
                table708.AddRow(new string[] {
                            "TrailerValue",
                            "Error"});
#line 96
 testRunner.Then("user verifies the following Apollo help and error text of the Vehicle Page:", ((string)(null)), table708, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion