using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Fnol
{
    class FNOLDash
    {

        private IWebDriver fnolDriver;
        private Functions functions;

        public FNOLDash(IWebDriver driver)
        {
            fnolDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement addFNOLButton => functions.FindElementWait(10, By.XPath("//button[@aria-label = 'New FNOL']"));

        public void GoToFNOL()
        {
            fnolDriver.Navigate().GoToUrl("https://biberk-apollo-qa.azurewebsites.net/claims/fnol-dashboard");
        }

        public void AddNewFNOL()
        {
            addFNOLButton.Click();
        }
    }
}
