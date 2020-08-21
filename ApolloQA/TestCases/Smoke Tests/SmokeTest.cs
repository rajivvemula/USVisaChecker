using ApolloQA.Helpers;
using ApolloQA.Pages.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.TestCases.Smoke_Tests
{

    [TestFixture]
    class SmokeTest
    {

        public IWebDriver driver;
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestCase]
        public void LogIn()
        {
            LogInAsAdmin logInAsAdmin = new LogInAsAdmin(driver);
            logInAsAdmin.LoginAsValidUser();
        }

    }
}
