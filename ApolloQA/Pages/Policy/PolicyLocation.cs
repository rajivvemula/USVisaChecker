using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyLocation
    {

        private IWebDriver policyDriver;
        private Functions functions;
        public PolicyLocation(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement newButton => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label='add']"));
        public IWebElement newButton2 => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label='add'][1]"));
        public IWebElement locationInput => functions.FindElementWait(10, By.Name("name"));
        public IWebElement submitButton => functions.FindElementWait(10, By.XPath("//span[contains(text(),'Submit')]"));
        public IWebElement moreOptions => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label='more']"));
        public IWebElement removeButton => functions.FindElementWait(10, By.XPath("//button[contains(text(),'Remove')]"));
        public IWebElement deleteButton => functions.FindElementWait(10, By.XPath("//button[@color='warn']"));



        public void ClickAddNew()
        {
            newButton.Click();
        }
        public void ClickSecondAddNew()
        {
            newButton2.Click();
        }
        public void ClickLocation(string title)
        {
            IWebElement location = functions.FindElementWait(30, By.XPath("//span[@title='" + title + "']"));
            location.Click();
        }

        public bool checkLocation(string title)
        {
            IWebElement location = functions.FindElementWait(30, By.XPath("//span[@title='" + title + "']"));
            bool verifyLocation = location.Displayed;
            return verifyLocation;
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
