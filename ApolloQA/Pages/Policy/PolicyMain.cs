using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ApolloQA.Pages.Policy
{
    class PolicyMain
    {
        private IWebDriver policyDriver;
        WebDriverWait wait;
        public PolicyMain(IWebDriver driver)
        {
            policyDriver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }


        public IWebElement summaryLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='General Information']"));
        public IWebElement locationLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Locations']"));
        public IWebElement contactsLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Contacts']"));
        public IWebElement vehicleLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Vehicles']"));
        public IWebElement driverLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Drivers']"));
        public IWebElement coverageLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Coverages']"));
        public IWebElement rateLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Rate Calculation']"));
        public IWebElement documentLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Documents']"));
        public IWebElement historyLink => policyDriver.FindElement(By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Policy History']"));
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

        public void GotoHistory()
        {
            historyLink.Click();
        }

        public string GetLastBreadCrumb()
        {
            string lastCrumb = policyDriver.FindElement(By.ClassName("last-item")).Text;
            return lastCrumb;
        }
        public string CheckLastBreadCrumb(string crumb)
        {
            IWebElement crumbCheck = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[@class='last-item' and normalize-space(text())='" + crumb + "']")));
            string lastCrumb = crumbCheck.Text;
            return lastCrumb;
        }
    }
}
