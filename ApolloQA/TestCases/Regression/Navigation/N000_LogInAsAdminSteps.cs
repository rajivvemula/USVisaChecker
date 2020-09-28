using ApolloQA.Helpers;
using ApolloQA.Pages.Dashboard;
using ApolloQA.Pages.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class N000_LogInAsAdminSteps
    {
        public IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;

        public N000_LogInAsAdminSteps(IWebDriver Driver)
        {
            driver = Driver;
            loginPage = new LoginPage(Driver);
            homePage = new HomePage(Driver);

        }

        [Given(@"User is on Apollo Homepage")]
        public void GivenUserIsOnApolloHomepage()
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);

            //Automatic Redirect
        }


        [When(@"I enter AdminUsername and AdminPassword")]
        public void WhenIEnterUsernameAndPassword()
        {
            loginPage.loginValidUser(Defaults.ADMIN_USERNAME, Defaults.DEFAULT_PASSWORD);
        }

        [Then(@"I should see the Apollo Dashboard as Admin")]
        public void ThenIShouldSeeTheApolloDashboardAsAdmin()
        {
            bool verifyUser = homePage.VerifyLoggedInUser(Defaults.ADMIN_USERNAME);
            Assert.AreEqual(verifyUser, true);
        }
    }
}
