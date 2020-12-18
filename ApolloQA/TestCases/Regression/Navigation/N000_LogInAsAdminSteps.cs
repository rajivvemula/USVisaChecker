using ApolloQA.Helpers;
using ApolloQA.Pages.Dashboard;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.ComponentModel.DataAnnotations;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class N000_LogInAsAdminSteps
    {
        public IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        MainNavBar mainNavBar;
        FeatureContext featureContext;

        public N000_LogInAsAdminSteps(IWebDriver Driver, FeatureContext featureContext)
        {
            this.featureContext = featureContext;

            driver = Driver;
                

            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            mainNavBar = new MainNavBar(driver);
            

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


        //[Given(@"User opens a new window and logs in as (.*)")]
        //public void GivenUserOpensANewWindowAndLogsInAs(string email)
        //{
        //    driver = new ChromeDriver();
        //    driver.Manage().Window.Maximize();
        //    featureContext.Add("newWebdriver", driver);

        //    loginPage = new LoginPage(driver);
        //    homePage = new HomePage(driver);

        //    driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
        //    loginPage.loginValidUser(email, Defaults.DEFAULT_PASSWORD);
        //}

        //[Given(@"User closes the new window")]
        //public void GivenUserClosesTheNewWindow()
        //{
        //    IWebDriver driverToClose = featureContext.Get<IWebDriver>("newWebdriver");
        //    driverToClose.Quit();

        //    //need to remove newWindow from FeatureContext

        //}


        [When(@"User logs in as (.*) with default password (.*)")]
        public void WhenUserLogsInAs(string email, int pwNumber)
        {
            if (pwNumber == 1)
                loginPage.loginValidUser(email, Defaults.DEFAULT_PASSWORD);
            else
                loginPage.loginValidUser(email, Defaults.DEFAULT_PASSWORD2);
        }

        [Then(@"current logged in user is (.*)")]
        public void ThenCurrentLoggedInUserIs(string email)
        {
            Assert.IsTrue(email.Contains(mainNavBar.GetCurrentLoggedInUser()), "Current logged in user does not match expected.");
        }

        [When(@"User logs out")]
        public void WhenUserLogsOut()
        {
            mainNavBar.LogoutCurrentUser();
        }



    }
}
