using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;
using NUnit.Framework;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R017_PolicyVehicleAddNewSteps
    {

        public IWebDriver driver;
        PolicyMain policyMain;
        AddVehicle addVehicle;
        PolicyVehicle policyVehicle;
        Toaster toaster;

        public R017_PolicyVehicleAddNewSteps(IWebDriver Driver)
        {
            driver = Driver;
            policyMain = new PolicyMain(Driver);
            addVehicle = new AddVehicle(Driver);
            policyVehicle = new PolicyVehicle(Driver);
            toaster = new Toaster(Driver);
        }

        [When(@"I user enter all info into add new vehicle")]
        public void WhenIUserEnterAllInfoIntoAddNewVehicle(Table table)
        {
            Thread.Sleep(10000);
            var detail = table.CreateDynamicSet();
            foreach(var details in detail)
            {
                //addVehicle.inputCode.Click();
                Thread.Sleep(20000);
                //addVehicle.inputCode.SendKeys(Keys.Enter);
                //addVehicle.ClickClassCodeOption("401: Truckers - Long Haul");
                addVehicle.EnterInput("VIN", details.VIN);
                addVehicle.EnterInput("Year", details.Year.ToString());
                addVehicle.EnterInput("Make", details.Make);
                
                addVehicle.EnterInput("Model", details.Model);
                addVehicle.EnterInput("Trim", details.Trim);
                addVehicle.EnterSelect("State", details.State);
                addVehicle.EnterInput("Plate", details.Plate);
                addVehicle.EnterSelect("Type", details.Type);
                addVehicle.EnterInput("Cost", details.Cost.ToString());
                addVehicle.EnterInput("Value", details.Value.ToString());
                addVehicle.EnterInput("Radius", details.Radius.ToString());
                addVehicle.EnterSelect("Business", details.Business);
                //addVehicle.EnterInput("Code", details.Code.ToString());
                //Thread.Sleep(4000);
                //addVehicle.ClickClassCodeOption("401: Truckers - Long Haul");
                addVehicle.EnterInput("Notes", details.Notes);
            }



        }
        
        [Then(@"vehicle with those inputs is added and confirmed via toast")]
        public void ThenVehicleWithThoseInputsIsAddedAndConfirmedViaToast()
        {
            addVehicle.submitButton.Click();
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Vehicle added successfully"));
            
        }
    }
}

/*
 * 	| VIN               | Year | Make  | Model  | Trim | State   | Plate   | Type | Cost | Value | Radius | Business       | Code | Notes          |
	| JHMCG56492C003897 | 2002 | Honda | Accord | XL   | Arizona | BJV7821 | Car  | 4000 | 3000  | 200    | Commercial Use | 401  | Sample Vehicle |

 case "VIN": return inputVin;

                case "Year": return inputYearMan;
                case "Make": return inputMake;
                case "Model": return inputModel;
                case "Trim": return inputTrim;
                case "State": return selectState;
                case "Plate": return inputPlatNum;
                case "Type": return selectType;
                case "Cost": return inputCost;
                case "Value": return inputValue;
                case "Radius": return inputRadius;
                case "Business": return selectBusUse;
                case "Code": return inputCode;
                case "Rating Group": return inputRatingGroup;
                case "Rating Plan": return inputRatingPlan;
                case "Limit": return inputLimit;
                case "Notes": return inputNotes;
                default: return inputNotes;
*/
