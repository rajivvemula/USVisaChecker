using ApolloQA.Pages.Nav.MainNav;
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

        public MainNavBar MainNavBar { get => mainNavBar; }
    }
}
