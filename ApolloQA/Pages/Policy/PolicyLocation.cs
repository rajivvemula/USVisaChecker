using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyLocation
    {

        private IWebDriver policyDriver;
        public PolicyLocation(IWebDriver driver)
        {
            policyDriver = driver;

        }

        public IWebElement newButton => policyDriver.FindElement(By.XPath("//mat-icon[@aria-label='add']"));
        public IWebElement locationInput => policyDriver.FindElement(By.Name("name"));
        public IWebElement submitButton => policyDriver.FindElement(By.XPath("//span[contains(text(),'Submit')]"));
        public IWebElement moreOptions => policyDriver.FindElement(By.XPath("//mat-icon[@aria-label='more']"));
        public IWebElement removeButton => policyDriver.FindElement(By.XPath("//button[contains(text(),'Remove')]"));
        public IWebElement deleteButton => policyDriver.FindElement(By.XPath("//button[@color='warn']"));


        public void ClickAddNew()
        {
            newButton.Click();
        }

        public void AddLocationName()
        {
            locationInput.SendKeys("TestAutomation");
        }

        public void ClickSubmit()
        {
            submitButton.Click();
        }

        public void removeLocation()
        {
            moreOptions.Click();
            removeButton.Click();
            deleteButton.Click();
        }
    }
}
