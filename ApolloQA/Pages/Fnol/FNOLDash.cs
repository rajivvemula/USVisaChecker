using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Fnol
{
    class FNOLDash
    {

        private IWebDriver fnolDriver;
        public FNOLDash(IWebDriver driver)
        {
            fnolDriver = driver;
        }

        public IWebElement addFNOLButton => fnolDriver.FindElement(By.XPath("//button[@aria-label = 'Add FNOL']"));

        public void GoToFNOL()
        {
            fnolDriver.Navigate().GoToUrl("https://biberk-apollo-qa.azurewebsites.net/claims/fnol");
        }

        public void AddNewFNOL()
        {
            addFNOLButton.Click();
        }
    }
}
