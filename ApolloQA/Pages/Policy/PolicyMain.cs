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


        public IWebElement summaryLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='General Information']"));
        public IWebElement locationLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Locations']"));
        public IWebElement contactsLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Contacts']"));
        public IWebElement vehicleLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Vehicles']"));
        public IWebElement driverLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Drivers']"));
        public IWebElement coverageLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Coverages']"));
        public IWebElement rateLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Rate Calculation']"));
        public IWebElement documentLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Documents']"));

        public void NavigateToPolicy(int policyNumber)
        {
            policyDriver.Navigate().GoToUrl(Defaults.QA_URLS["Policy"] + "/" + policyNumber);
        }

        public void NavigateToPolicyCreation()
        {
            policyDriver.Navigate().GoToUrl(Defaults.QA_URLS["Policy"] + "/insert");
        }

        public void NavigateToPolicyGrid()
        {
            policyDriver.Navigate().GoToUrl(Defaults.QA_URLS["Policy"]);
        }

        public void GoToSummary()
        {
            summaryLink.Click();
        }
        public void GoToLocations()
        {
            locationLink.Click();
        }
        public void GoToContacts()
        {
            contactsLink.Click();
        }
        public void GoToVehicles()
        {
            vehicleLink.Click();
        }
        public void GoToDrivers()
        {
            driverLink.Click();
        }
        public void GoToCoverages()
        {
            coverageLink.Click();
        }
        public void GoToRates()
        {
            rateLink.Click();
        }

        public void GoToDocuments()
        {
            documentLink.Click();
        }

    }
}
