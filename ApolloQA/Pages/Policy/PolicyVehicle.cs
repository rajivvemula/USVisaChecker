using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyVehicle
    {
        private IWebDriver policyDriver;
        public PolicyVehicle(IWebDriver driver)
        {
            policyDriver = driver;

        }
        public IWebElement newVehicleButton => policyDriver.FindElement(By.XPath("//span[@class = 'mat-button-wrapper' and normalize-space(text())='New Vehicle']"));
        public IWebElement addExistingeButton => policyDriver.FindElement(By.XPath("//span[@class = 'mat-button-wrapper' and normalize-space(text())='Add Existing Vehicle']"));
        public IWebElement inputVin => policyDriver.FindElement(By.XPath("//input[@aria-label='VinNumber']"));
        public IWebElement cancelButton => policyDriver.FindElement(By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement submitButton => policyDriver.FindElement(By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Submit']"));

        public void ClickNewVehicle()
        {
            newVehicleButton.Click();
        }

        public void ClickExistingButton()
        {
            addExistingeButton.Click();
        }

        public void ClickSubmit()
        {
            submitButton.Click();
        }
        public void ClickCancel()
        {
            cancelButton.Click();
        }
        public bool CheckModalTitle()
        {
            bool title = policyDriver.FindElement(By.XPath("//h1[contains(text(),'Add vehicle for')]")).Displayed;
            return title;
        }

        public void EnterVin(string vin)
        {
            inputVin.SendKeys(vin);
        }
        public void SelectCoverage(int checkboxNum)
        {
            WebDriverWait wait = new WebDriverWait(policyDriver, TimeSpan.FromSeconds(10));
            IList<IWebElement> checkBoxes = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//input[@type = 'checkbox]")));
            checkBoxes[checkboxNum].Click();
        }
        //add grid actions
    }
}
