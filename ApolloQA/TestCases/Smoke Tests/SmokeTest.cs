using ApolloQA.Helpers;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Shared;
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
        MainNavBar mainNavBar;

        public SmokeTest()
        {
            //driver = new ChromeDriver();
            //mainNavBar = new MainNavBar(driver);
        }
        [OneTimeSetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            mainNavBar = new MainNavBar(driver);
        }

        [OneTimeTearDown]
        public void teardown()
        {
            driver.Quit();
        }

        /// <summary>
		/// Logs in As Admin
		/// </summary>
        [TestCase]
        public void LogIn()
        {
            LogInAsAdmin logInAsAdmin = new LogInAsAdmin(driver);
            logInAsAdmin.LoginAsValidUser();
        }

        /// <summary>
		/// Test 4  Main Nav Tabs(Home, Policy, Organization, and Application
		/// </summary>
        [TestCase]
        public void TestNav()
        {
            //bool atHome = driver.Url.Contains(Defaults.QA_URLS["Home"]);
            //Check If User is at Home if not go to Home
            //MainNavBar mainNavBar = new MainNavBar(driver);
            if (driver.Url.Contains(Defaults.QA_URLS["Home"])) { 
                //home 
            } 
            else { 
                driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]); 
            }
            mainNavBar.ClickHomeIcon();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Home"]));
            mainNavBar.ClickPolicyTab();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Policy"]));
            mainNavBar.ClickOrganizationTab();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Organization"]));
            mainNavBar.ClickApplicationTab();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Application"]));
        }

    }
}
