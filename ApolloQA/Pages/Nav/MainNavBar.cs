using OpenQA.Selenium;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using ApolloQA.Helpers;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace ApolloQA.Pages.Nav.MainNav
{
    class MainNavBar
    {
        private IWebDriver mainNavDriver;

        private string[] tabs = {"Home", "Policy", "Organization", "Home"};

        //public IWebElement searchField => mainNavDriver.FindElement(By.XPath(MainNavLocs.MainNavXPaths["Search Field"]));
        public IList<IWebElement> searchResults;

        public MainNavBar(IWebDriver driver)
        {
            mainNavDriver = driver;
        }

        //This is for smoke test - make sure we can click on all tabs (tabs listed in above array)
        public void VerifyAllTabsArePresentAndClickable()
        {
            foreach(string tabName in tabs)
            {
                this.ClickOnTab(tabName);
            }
        }

        //Function for clicking individual tabs on navbar
        public void ClickOnTab(string tabName)
        {
            string targetUrl = Defaults.QA_URLS[tabName];

            //set stored xpath
            string xpath = MainNavLocs.MainNavXPaths[tabName];

            //wait for the button to be clickable
            WebDriverWait wait = new WebDriverWait(mainNavDriver, TimeSpan.FromSeconds(10));
            IWebElement target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));

            //click it
            target.Click();

            //asserts
            // check current URL vs default URL for that tab
            Assert.AreEqual(mainNavDriver.Url, Defaults.QA_URLS[tabName]);
        }

        public void searchQuery(string query)
        {

            //wait for the button to be clickable
            WebDriverWait wait = new WebDriverWait(mainNavDriver, TimeSpan.FromSeconds(10));
            IWebElement searchField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(MainNavLocs.MainNavXPaths["Search Field"])));

            searchField.Clear();
            searchField.SendKeys(query);

        }

        public void clickFirstSearchResult()
        {
            //wait for the button to be clickable
            WebDriverWait wait = new WebDriverWait(mainNavDriver, TimeSpan.FromSeconds(10));
            IWebElement target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(MainNavLocs.MainNavXPaths["Search Results"])));

            target.Click();
        }




    }
}
