using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Helpers;
using OpenQA.Selenium;

namespace ApolloQA.Pages.Policy
{
    class PolicyMain
    {
        private IWebDriver policyDriver;
        public PolicyMain(IWebDriver driver)
        {
            policyDriver = driver;
        }

        public IWebElement documentLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Documents']"));

        public void NavigateToPolicy(int policyNumber)
        {
            policyDriver.Navigate().GoToUrl(Defaults.QA_URLS["Policy"] + "/" + policyNumber);
        }

        public void NavigateToPolicyCreation()
        {
            policyDriver.Navigate().GoToUrl(Defaults.QA_URLS["Policy"] + "/insert");
        }

        public void GoToSummary()
        {
            policyDriver.FindElement(By.XPath(PolicyLocs.locPolicySummary)).Click();
        }
        public void GoToLocations()
        {
            policyDriver.FindElement(By.XPath(PolicyLocs.locPolicyLocation)).Click();
        }
        public void GoToContacts()
        {
            policyDriver.FindElement(By.XPath(PolicyLocs.locPolicyContacts)).Click();
        }
        public void GoToVehicles()
        {
            policyDriver.FindElement(By.XPath(PolicyLocs.locPolicyVehicles)).Click();
        }
        public void GoToDrivers()
        {
            policyDriver.FindElement(By.XPath(PolicyLocs.locPolicyDrivers)).Click();
        }
        public void GoToCoverages()
        {
            policyDriver.FindElement(By.XPath(PolicyLocs.locPolicyCoverages)).Click();
        }
        public void GoToRates()
        {
            policyDriver.FindElement(By.XPath(PolicyLocs.locPolicyRates)).Click();
        }

        public void GoToDocuments()
        {
            documentLink.Click();
        }

    }
}
