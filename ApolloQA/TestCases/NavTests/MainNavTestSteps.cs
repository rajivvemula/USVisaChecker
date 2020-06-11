using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Nav;
using ApolloQA.Helpers;
using NUnit.Framework;

namespace ApolloQA.TestCases.NavTests
{
    [Binding]
    public class MainNavTestSteps
    {
        public IWebDriver driver;
        public MainNavTestSteps(IWebDriver Driver)
        {
            driver = Driver;
        }
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);

            //login
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterUsername(Defaults.ADMIN_USERNAME);
            loginPage.ClickNextButton();
            loginPage.EnterPassword(Defaults.DEFAULT_PASSWORD);
            loginPage.ClickNextButton();
            loginPage.ClickNoButton();
        }

        [When(@"I click on the (.*) tab")]
        public void WhenIClickOnTab(string tabName)
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS[tabName]);
        }
        
        [Then(@"The (.*) tab should load properly")]
        public void ThenTheTabShouldDisplayProperly(string tabName)
        {
            MainNavBar mainNav1 = new MainNavBar(driver);
            mainNav1.ClickOnTab(tabName);
        }

        [When(@"I enter policy number (.*) in the search field")]
        public void WhenIEnterPolicyNumberInTheSearchField(int policyNumber)
        {
            MainNavBar mainNav1 = new MainNavBar(driver);
            mainNav1.searchQuery(policyNumber.ToString());
        }

        [Then(@"I should be able to click the policy number")]
        public void ThenIShouldBeAbleToClickThePolicyNumber()
        {
            MainNavBar mainNav1 = new MainNavBar(driver);
            mainNav1.clickFirstSearchResult();
        }

        [Then(@"I should be directed to policy (.*)")]
        public void ThenIShouldBeDirectedToPolicy(int policyNumber)
        {
            Assert.AreEqual(driver.Url, Defaults.QA_URLS["Policy"] + "/" + policyNumber + "/summary");
        }

        [When(@"I enter organization name (.*) in the search field")]
        public void WhenIEnterOrganizationNameInTheSearchField(string orgName)
        {
            MainNavBar mainNav1 = new MainNavBar(driver);
            mainNav1.searchQuery(orgName);
        }

        [Then(@"I should be able to click the organization")]
        public void ThenIShouldBeAbleToClickTheOrganization()
        {
            MainNavBar mainNav1 = new MainNavBar(driver);
            mainNav1.clickFirstSearchResult();
        }

        [Then(@"I should be directed to organization (.*)")]
        public void ThenIShouldBeDirectedToOrganization(string orgName)
        {
            Assert.IsTrue(driver.Url.Contains("https://biberk-apollo-qa.azurewebsites.net/organization"));
        }



    }
}
