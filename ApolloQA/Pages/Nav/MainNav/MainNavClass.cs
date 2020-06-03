using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ApolloQA.Pages.Login;
using ApolloQA.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ApolloQA.Pages.Nav.MainNav
{
    class MainNavClass
    {
        private IWebDriver mainNavDriver;

        private string[] tabs = { "Policy", "Organization", "Claim", "FNOL"};

        public MainNavClass(IWebDriver driver)
        {
            mainNavDriver = driver;
        }

        public void VerifyTabsArePresentAndClickable()
        {
            foreach(string tabName in tabs)
            {
                //build Xpath based on tab name
                string xpath = "//button//*[contains(text(), " + tabName + ")]";
                //wait for the button to be clickable
                WebDriverWait wait = new WebDriverWait(mainNavDriver, TimeSpan.FromSeconds(5));
                IWebElement target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));

                //REMOVE LATER
                System.Threading.Thread.Sleep(5000);

                //click it
                target.Click();
            }
        }

    }
}
