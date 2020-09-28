using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyHeader
    {
        private IWebDriver policyDriver;
        private Functions functions;

        public PolicyHeader(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement chevronCTA => functions.FindElementWait(20, By.XPath("//span[contains(@class,'mat-expansion')]"));
        public IWebElement pagesName => functions.FindElementWait(20, By.XPath("//div[contains(text(),'Activities')]"));
        public IWebElement getElementFor(String labelName)
        {
            return functions.FindElementWait(10, By.XPath("//div[contains(text(),'" + labelName + "')]/parent::div/child::div"));
        }
    }
}
