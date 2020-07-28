using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyDrivers
    {
        private IWebDriver policyDriver;
        private Functions functions;

        public PolicyDrivers(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }


        public IWebElement newDriverButton => functions.FindElementWait(10, By.XPath("//span[@class = 'mat-button-wrapper' and normalize-space(text())='Add Driver']"));

        public bool CheckModalTitle()
        {
            bool title = functions.FindElementWait(10, By.XPath("//h1[contains(text(),'Add Driver')]")).Displayed;
            return title;
        }
    }
}
