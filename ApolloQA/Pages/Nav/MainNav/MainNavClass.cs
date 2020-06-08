using OpenQA.Selenium;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using ApolloQA.Helpers;


namespace ApolloQA.Pages.Nav.MainNav
{
    class MainNavClass
    {
        private IWebDriver mainNavDriver;

        private string[] tabs = {"Home", "Policy", "Organization", "Home"};

        public MainNavClass(IWebDriver driver)
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

            //build Xpath based on tab name
            // find a button whose class includes 'top-menu-item' and has a child span containing the tab name
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
    }
}
