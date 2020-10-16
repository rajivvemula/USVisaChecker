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
        private Functions functions;

        public PolicyMain(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement infoLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Business Information']"));
        public IWebElement contactsLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Contacts']"));
        public IWebElement uwQuestionsLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='UW Questions']"));
        public IWebElement vehicleLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Vehicles']"));
        public IWebElement driverLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Drivers']"));
        public IWebElement trailersLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Trailers']"));
        public IWebElement addQuestionsLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Additional Questions']"));
        public IWebElement modifierLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Modifiers']"));
        public IWebElement interestsLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Additional Interests']"));
        public IWebElement summaryLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Summary']"));
        public IWebElement coverageLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Policy Coverages']"));
        public IWebElement rateLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Rate Calculation']"));
        public IWebElement documentLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Documents']"));
        public IWebElement activitiesLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Activities']"));
        public IWebElement lossLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Loss History']"));
        public IWebElement historyLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Policy History']"));
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
            string lastCrumb = functions.FindElementWait(10, By.ClassName("last-item")).Text;
            return lastCrumb;
        }
        public string CheckLastBreadCrumb(string crumb)
        {
            IWebElement crumbCheck = functions.FindElementWait(10, By.XPath("//span[@class='last-item' and normalize-space(text())='" + crumb + "']"));
            string lastCrumb = crumbCheck.Text;
            return lastCrumb;
        }
    }
}
