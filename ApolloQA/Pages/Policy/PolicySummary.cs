using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace ApolloQA.Pages.Policy
{
    class PolicySummary
    {

        private IWebDriver policyDriver;
        public PolicySummary(IWebDriver driver)
        {
            policyDriver = driver;
            
        }

        public IList<IWebElement> status => policyDriver.FindElements(By.XPath("//input[contains(@id,'mat-input')]"));



        public string CheckPolicyStatus()
        {
            string policyStatus = status[4].GetAttribute("value");
            return policyStatus;
        }
    }
}
