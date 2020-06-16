using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

//classes
using ApolloQA.Pages.Login;
using ApolloQA.Helpers;
using ApolloQA.Pages.Policy;
using System.Threading;

namespace ApolloQA.TestCases.LoginTest
{
    [Binding]
    public class LoginTestSteps
    {

        public IWebDriver driver;

        public LoginTestSteps(IWebDriver Driver)
        {
            driver = Driver;
        }

        [Given(@"User is on homepage and on log on screen")]
        public void GivenUserNavigatesToQaWebsite()
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
        }

        [When(@"User enters username and password")]

        public void WhenUserInputAUsername()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            LoginPage loginPage = new LoginPage(driver);
            bool verifyPage = loginPage.VerifyLoginScreen();
            //Assert.AreEqual(verifyPage, true);
            loginPage.EnterUsername(Defaults.ADMIN_USERNAME);
            string usernameVerify = loginPage.GetUsername();
            //Assert.AreEqual(Defaults.adminUsername, usernameVerify);

            //loginPage.ClearUsername();

            loginPage.ClickNextButton();

            loginPage.EnterPassword(Defaults.DEFAULT_PASSWORD);
            string passwordVerify = loginPage.GetPassword();
            //Assert.AreEqual(Defaults.defaultPassword, passwordVerify);
            loginPage.ClickNextButton();
            loginPage.ClickNoButton();
        }


        [Then(@"User is shown the Dashboard")]
        public void ThenPasswordscreenIsShown()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string pageTitle = driver.Title;
            Assert.AreEqual(pageTitle, "Home");
            
        }

        [Then(@"User navigates to policy")]
        public void ThenUserToPolicy()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            PolicyMain policyPage = new PolicyMain(driver);

            Thread.Sleep(5000);
            policyPage.NavigateToPolicyGrid();
            driver.FindElement(By.XPath("//button[@aria-label='Add Policy']")).Click();
            PolicyCreation policyCreationPage = new PolicyCreation(driver);

            policyCreationPage.EnterDefaultInputs();
            Thread.Sleep(10000);

            //policyPage.NavigateToPolicy(12843);
            /*
            driver.FindElement(By.XPath("//button[@aria-label='Add Policy']")).Click();
            PolicyCreation policyCreationPage = new PolicyCreation(driver);
            
            policyCreationPage.EnterInsuredOrg();
            policyCreationPage.EnterAgency();
            policyCreationPage.EnterLOB();
            policyCreationPage.EnterBusType();
            policyCreationPage.EnterYears();
            policyCreationPage.EnterTaxIDType();
            policyCreationPage.EnterTaxID();
            policyCreationPage.ClickSubmitButton();
            
            */
            /*
            policyPage.NavigateToPolicy(12841);
            policyPage.GoToSummary();
            policyPage.GoToLocations();
            policyPage.GoToContacts();
            policyPage.GoToVehicles();
            policyPage.GoToDrivers();
            policyPage.GoToCoverages();
            policyPage.GoToRates();
            */
        }

    }
}
