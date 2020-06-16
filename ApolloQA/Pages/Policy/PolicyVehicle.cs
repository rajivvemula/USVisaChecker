using OpenQA.Selenium;
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

        public void ClickNewVehicle()
        {
            newVehicleButton.Click();
        }

        public void ClickExistingButton()
        {
            addExistingeButton.Click();
        }

        //add grid actions
    }
}
