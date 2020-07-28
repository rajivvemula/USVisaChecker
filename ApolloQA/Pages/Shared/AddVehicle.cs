using ApolloQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class AddVehicle
    {

        private IWebDriver Driver;
        private Functions functions;

        public AddVehicle(IWebDriver driver)
        {
            Driver = driver;
            functions = new Functions(driver);
        }

        
        public static IDictionary<string, string> vehicleLoc = new Dictionary<string, string>()
        {
            {"VIN", "vinNumber" },
            {"Year", "yearOfManufacture" },
            {"Make", "make" },
            {"Model", "model" },
            {"Trim", "trim" },
            {"State", "plateStateProvinceId" },
            {"Plate", "plateNumber" },
            {"Type", "typeId" },
            {"Cost", "costNew" },
            {"Value", "estimatedCurrentValue" },
            {"Radius", "radiusOfOperation" },
            {"Business", "businessUseId" },
            {"Code", "classCode" },
            {"Rating Group", "ratingGroup" },
            {"Rating Plan", "driverRatingPlan" },
            {"Limit", "increasedLimitGroup" },
            {"Notes", "notes" }
        };

        
        public readonly IDictionary<string, string[]> dropValues = new Dictionary<string, string[]>()
        {
            {"State", new []{"Arizona", "California", "Illinois", "Nevada", "New Jersey", "New York", "Ontario", "Pennsylvania", "Quebec City", "South Carolina" } },
            {"Type", new []{"Car", "Van", "Work Truck" }},
            {"Business", new []{"Commercial Use", "Retail Vehicle", "Service Vehicle" }},
        };

        public readonly string[] vehicleLabels =
        {
            "VIN",
            "Year",
            "Make",
            "Model",
            "Trim",
            "State/Province",
            "Plate Number",
            "Type",
            "Cost New",
            "Estimated Value",
            "Operation Radius",
            "Business Use",
            "Class Code",
            "Rating Group",
            "Driver Rating Plan",
            "Increased Limit Group",
            "Notes"
        };


        /*
        public void EnterInput(string locator, string value)
        {
            switch (locator)
            {
                case "Notes":
                    Driver.FindElement(By.XPath("//textarea[@formcontrolname='" + vehicleLoc[locator] + "']")).SendKeys(value);
                    break;
                default:
                    Driver.FindElement(By.XPath("//input[@formcontrolname='" + vehicleLoc[locator] + "']")).SendKeys(value);
                    break;
            }
            
            
        }

        public string GetValue(string locator)
        {
            string value; 
            switch (locator)
            {
                case "Notes":
                    value = Driver.FindElement(By.XPath("//textarea[@formcontrolname='" + vehicleLoc[locator] + "']")).GetAttribute("value");
                    break;
                default:
                    value = Driver.FindElement(By.XPath("//input[@formcontrolname='" + vehicleLoc[locator] + "']")).GetAttribute("value");
                    break;
            }
            return value;

        }

        public string GetRequired(string locator)
        {
            string aria;
            switch (locator)
            {
                case "Notes":
                    aria = Driver.FindElement(By.XPath("//textarea[@formcontrolname='" + vehicleLoc[locator] + "']")).GetAttribute("aria-required");
                    break;
                default:
                    aria = Driver.FindElement(By.XPath("//input[@formcontrolname='" + vehicleLoc[locator] + "']")).GetAttribute("aria-required");
                    break;
            }
            //string aria = Driver.FindElement(By.XPath("//input[@formcontrolname='" + vehicleLoc[locator] + "']")).GetAttribute("aria-required");
            return aria;
        }
        */

        public void EnterInput(string locator, string value)
        {
            getElementFromFieldname(locator).SendKeys(value);
        }
        public string GetRequired(string locator)
        {
            return getElementFromFieldname(locator).GetAttribute("aria-required");
        }
        public string GetValue(string locator)
        {
            return getElementFromFieldname(locator).GetAttribute("value");
        }

        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
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
                   
            }
        }
        
        public void ClickSelect(string locator)
        {
            functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='" + vehicleLoc[locator] + "']")).Click();

        }

        public bool CheckDropDownValue(string value)
        {
            bool verify = functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Displayed;

            return verify;
        }
        public string GetSelectRequired(string locator)
        {
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + dropValues[locator][1] + "']")).Click();
            string aria = functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='" + vehicleLoc[locator] + "']")).GetAttribute("aria-required");
            return aria;
        }

        public IWebElement inputVin => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='vinNumber']"));
        public IWebElement inputYearMan => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='yearOfManufacture']"));
        public IWebElement inputMake => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='make']"));
        public IWebElement inputModel => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='model']"));
        public IWebElement inputTrim => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='trim']"));
        public IWebElement inputPlatNum => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='plateNumber']"));
        public IWebElement inputCost => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='costNew']"));
        public IWebElement inputValue => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='estimatedCurrentValue']"));
        public IWebElement inputRadius => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='radiusOfOperation']"));
        public IWebElement inputNotes => functions.FindElementWait(10, By.XPath("//textarea[@formcontrolname='notes']"));
        public IWebElement inputCode => functions.FindElementWait(60, By.XPath("//bh-input-autocomplete[@formcontrolname='classCode']/input"));
        public IWebElement inputRatingGroup => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='ratingGroup']"));
        public IWebElement inputRatingPlan => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='driverRatingPlan']"));
        public IWebElement inputLimit => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='increasedLimitGroup']"));
        public IWebElement selectState => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='plateStateProvinceId']"));
        public IWebElement selectType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='typeId']"));
        public IWebElement selectBusUse => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='businessUseId']"));
        public IWebElement cancelButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement submitButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Submit']"));
        public IWebElement searchButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Search Vin']"));

        public void ClickClassCodeOption(string value)
        {
            IWebElement selectValue = functions.FindElementWait(20, By.XPath("//div[@class='line-label' and normalize-space(text())='" + value + "']"));
            selectValue.Click();
        }
        

        public void EnterVin(string vin)
        {
            inputVin.SendKeys(vin);
        }
        public void EnterYearMan(string yearMan)
        {
            inputYearMan.SendKeys(yearMan);
        }
        public void EnterMake(string make)
        {
            inputMake.SendKeys(make);
        }
        public void EnterModel(string model)
        {
            inputModel.SendKeys(model);
        }
        public void EnterTrim(string trim)
        {
            inputTrim.SendKeys(trim);
        }
        public void EnterPlate(string plate)
        {
            inputPlatNum.SendKeys(plate);
        }
        public void EnterCost(string cost)
        {
            inputCost.SendKeys(cost);
        }
        public void EnterValue(string value)
        {
            inputValue.SendKeys(value);
        }
        public void EnterRadius(string radius)
        {
            inputRadius.SendKeys(radius);
        }
        public void EnterNotes(string note)
        {
            inputNotes.SendKeys(note);
        }
        public void EnterState(string state)
        {
            selectState.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + state + "']")).Click();
        }

        public void EnterType(string vehicleType )
        {
            selectType.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + vehicleType + "']")).Click();
        }

        public void EnterBusiness(string bus)
        {
            selectBusUse.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + bus + "']")).Click();
        }

        public void EnterAllInputs()
        {
            EnterState("California");

        }
        public void SelectCoverage(int checkboxNum)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IList<IWebElement> checkBoxes = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//input[@type = 'checkbox]")));
            checkBoxes[checkboxNum].Click();
        }


    }
}
