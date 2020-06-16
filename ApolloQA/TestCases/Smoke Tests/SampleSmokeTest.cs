using ApolloQA.Helpers;
using ApolloQA.Pages;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Organization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.TestCases.Smoke_Tests
{
    [TestFixture]
    class SampleSmokeTest
    {
        [TestCase]
        public void LoginAsValidUser()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.loginValidUser(Defaults.ADMIN_USERNAME, Defaults.DEFAULT_PASSWORD);
            //Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Home"]));
            homePage.MainNavBar.ClickOnTab("Policy");
            homePage.MainNavBar.searchQuery("12890");
            homePage.MainNavBar.clickFirstSearchResult();
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Organization"]);
            OrganizationGrid orgGrid = new OrganizationGrid(driver);
            OrganizationInsert orgInsert = orgGrid.ClickNewButton();
            orgInsert.EnterAllValues();
            OrganizationDetails orgDetails = orgInsert.ClickSubmitButton();
            orgDetails.ClickAddAddress();
        }
    }
}
