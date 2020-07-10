using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class HomePage
    {
        protected IWebDriver driver;
        MainNavBar mainNavBar;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
        }

        //this allows us to reference MainNavBar object and functions from Page object like so:
        // homePage.MainNavBar.ClickOnTab("Policy");
        //Per Cabe, there is likely a better way of doing this with context injection
        public MainNavBar MainNavBar { get => mainNavBar; }
    }
}
