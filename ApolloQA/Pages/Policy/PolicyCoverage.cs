using ApolloQA.Helpers;
using Dynamitey.DynamicObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyCoverage
    {
        private IWebDriver policyDriver;
        Functions functions;

        public PolicyCoverage(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement newButton => functions.FindElementWait(10, By.XPath("//button[@aria-label='Add Coverage Output']"));
        public IWebElement inputPremium => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='premiumAmount']"));
        public IWebElement selectCoverage => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='associatedCoverageId']"));
        public IWebElement saveButton => functions.FindElementWait(10, By.XPath("//button[@class='mat-raised-button mat-primary save-button']"));

        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "premium": return inputPremium;
                case "coverage": return selectCoverage;
                default: return null;

            }
        }

        public void ClickCoverage()
        {
            getElementFromFieldname("coverage").Click();
            IWebElement selectValue = functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Additional Insured - Blanket (VA00034)']"));
            selectValue.Click();
        }
        public void EnterInput(string locator, string value)
        {
            getElementFromFieldname(locator).SendKeys(value);

        }
    }
}
