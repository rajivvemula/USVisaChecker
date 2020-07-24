using ApolloQA.Helpers;
using ApolloQA.Pages;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using ApolloQA.Workflows;
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
            loginPage.loginValidUser(Defaults.ADMIN_USERNAME, Defaults.DEFAULT_PASSWORD);
            ////Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Home"]));
            //homePage.MainNavBar.ClickOnTab("Policy");
            //homePage.MainNavBar.SearchQuery("10005");
            //homePage.MainNavBar.ClickFirstSearchResult();
            //driver.Navigate().GoToUrl(Defaults.QA_URLS["Organization"]);
            //OrganizationGrid orgGrid = new OrganizationGrid(driver);
            //OrganizationInsert orgInsert = orgGrid.ClickNewButton();
            //orgInsert.EnterAllValues();
            //OrganizationDetails orgDetails = orgInsert.ClickSubmitButton();
            //AddAddress orgAddress = orgDetails.ClickAddAddress();
            //orgAddress.SelectAddressType("Billing");
            //orgAddress.AddressLine1.SendKeys("57 Yeager Ave");
            //orgAddress.AddressCity.SendKeys("Forty Fort");
            //orgAddress.SelectState("Pennsylvania");
            //orgAddress.AddressZipCode.SendKeys("18704");
            //orgAddress.SelectCountry("United States");
            //orgAddress.ClickSubmit();


            //RightNavBar rightNavBar = new RightNavBar(driver);
            //rightNavBar.PolicyTab.Click();
            //rightNavBar.HomeIcon.Click();
            //rightNavBar.OrganizationTab.Click();
            //rightNavBar.SearchQuery("test");
            //rightNavBar.ClickFirstSearchResult();
            //rightNavBar.OrganizationTab.Click();
            ////rightNavBar.HistoryIcon.Click();
            //rightNavBar.ImpersonateIcon.Click();

            MainNavBar mainNavBar = new MainNavBar(driver);
            mainNavBar.ImpersonateValidUser("ApolloTestUserG105@biberk.com");

            //PolicyCRUD policyCrud = new PolicyCRUD(driver);
            //string result = policyCrud.CreateDefaultPolicy();
            //Console.WriteLine(result);

            mainNavBar.SearchQuery("10170");
            mainNavBar.ClickFirstSearchResult();

            PolicyMain policyMain = new PolicyMain(driver);
            policyMain.GoToSummary();

            PolicySummary policySummary = new PolicySummary(driver);
            string busType = policySummary.CheckBusinessType();
            Console.WriteLine(busType);





        }
    }
}
