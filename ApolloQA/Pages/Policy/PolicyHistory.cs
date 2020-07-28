using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyHistory
    {

        private IWebDriver policyDriver;
        private Functions functions;
        public PolicyHistory(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public bool CheckTransaction(string value)
        {
            return functions.FindElementWait(10, By.XPath("//span[@title='" + value + "']")).Displayed;
        }
    }
}
