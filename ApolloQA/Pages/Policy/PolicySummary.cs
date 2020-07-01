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

        public static IDictionary<string, string> tabId = new Dictionary<string, string>()
        {
            {"business", "mat-tab-label-0-0" },
            {"renewal", "mat-tab-label-0-1" },
            {"agency", "mat-tab-label-0-2" },
            {"accounting", "mat-tab-label-0-3" },
            {"operations", "mat-tab-label-0-4" },
            {"website", "mat-tab-label-0-5" }
        };

        public IWebElement businessTab => policyDriver.FindElement(By.Id("mat-tab-label-0-0"));
        public IWebElement renewalTab => policyDriver.FindElement(By.Id("mat-tab-label-0-1"));
        public IWebElement agencyTab => policyDriver.FindElement(By.Id("mat-tab-label-0-2"));
        public IWebElement accountingTab => policyDriver.FindElement(By.Id("mat-tab-label-0-3"));
        public IWebElement operationsTab => policyDriver.FindElement(By.Id("mat-tab-label-0-4"));
        public IWebElement websiteTab => policyDriver.FindElement(By.Id("mat-tab-label-0-5"));


        public string CheckPolicyStatus()
        {
            string policyStatus = status[4].GetAttribute("value");
            return policyStatus;
        }

        public void GoToTab(string id)
        {
            policyDriver.FindElement(By.Id(tabId[id])).Click();
        }

        public string VerifyTab(string id)
        {
            string selected = policyDriver.FindElement(By.Id(tabId[id])).GetAttribute("aria-selected");
            return selected;
        }
    }
}
