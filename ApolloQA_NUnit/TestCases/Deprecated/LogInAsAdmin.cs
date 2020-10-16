using ApolloQA.Helpers;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Dashboard;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ApolloQA.TestCases.Smoke_Tests
{
    class LogInAsAdmin
    {
        public IWebDriver driver;

        public LogInAsAdmin(IWebDriver Driver)
        {
            driver = Driver;

        }
        public void LoginAsValidUser()
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.loginValidUser(Defaults.ADMIN_USERNAME, Defaults.DEFAULT_PASSWORD);
            HomePage homePage = new HomePage(driver);
            bool verifyUser = homePage.VerifyLoggedInUser(Defaults.ADMIN_USERNAME);
            Assert.AreEqual(verifyUser, true);
        }
    }
}
