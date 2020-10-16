using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Application
{
    class ApplicationMain
    {
        private IWebDriver policyDriver;
        private Functions functions;

        public ApplicationMain(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement appInfoLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Application Information']"));
        public IWebElement busInfoLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Business Information']"));
        public IWebElement contactsLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Contacts']"));
        public IWebElement uwQuestionsLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='UW Questions']"));
        public IWebElement vehicleLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Vehicles']"));
        public IWebElement driverLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Drivers']"));
        public IWebElement coverageLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Policy Coverages']"));
        public IWebElement addQuestionsLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Additional Questions']"));
        public IWebElement summaryLink => functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Summary']"));
    }
}
