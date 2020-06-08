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

        public IWebElement status => policyDriver.FindElement(By.XPath("//input[@id='mat-input-2']"));



        public string CheckPolicyStatus()
        {
            string policyStatus = status.GetAttribute("value");
            return policyStatus;
        }
    }
}
