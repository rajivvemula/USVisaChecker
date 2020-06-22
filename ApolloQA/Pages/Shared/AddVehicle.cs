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
        public AddVehicle(IWebDriver driver)
        {
            Driver = driver;

        }

        public IWebElement inputVin => Driver.FindElement(By.XPath("//input[@formcontrolname='vinNumber']"));
        public IWebElement inputYearMan => Driver.FindElement(By.XPath("//input[@formcontrolname='yearOfManufacture']"));
        public IWebElement inputMake => Driver.FindElement(By.XPath("//input[@formcontrolname='make']"));
        public IWebElement inputModel => Driver.FindElement(By.XPath("//input[@formcontrolname='model']"));
        public IWebElement inputTrim => Driver.FindElement(By.XPath("//input[@formcontrolname='trim']"));
        public IWebElement inputPlatNum => Driver.FindElement(By.XPath("//input[@formcontrolname='plateNumber']"));
        public IWebElement inputCost => Driver.FindElement(By.XPath("//input[@formcontrolname='costNew']"));
        public IWebElement inputValue => Driver.FindElement(By.XPath("//input[@formcontrolname='estimatedCurrentValue']"));
        public IWebElement inputYRadius => Driver.FindElement(By.XPath("//input[@formcontrolname='radiusOfOperation']"));
        public IWebElement inputNotes => Driver.FindElement(By.XPath("//input[@formcontrolname='notes']"));
        public IWebElement selectState => Driver.FindElement(By.XPath("//mat-select[@formcontrolname='plateStateProvinceId']"));
        public IWebElement selectType => Driver.FindElement(By.XPath("//mat-select[@formcontrolname='typeId']"));
        public IWebElement selectBusUse => Driver.FindElement(By.XPath("//mat-select[@formcontrolname='businessUseId']"));
        public IWebElement cancelButton => Driver.FindElement(By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement submitButton => Driver.FindElement(By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Submit']"));
        public IWebElement searchButton => Driver.FindElement(By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Search Vin']"));


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
            inputYRadius.SendKeys(radius);
        }
        public void EnterNotes(string note)
        {
            inputNotes.SendKeys(note);
        }
        public void EnterState(string state)
        {
            selectState.Click();
            Driver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + state + "']")).Click();
        }

        public void EnterType(string vehicleType )
        {
            selectType.Click();
            Driver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + vehicleType + "']")).Click();
        }

        public void EnterBusiness(string bus)
        {
            selectBusUse.Click();
            Driver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + bus + "']")).Click();
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
