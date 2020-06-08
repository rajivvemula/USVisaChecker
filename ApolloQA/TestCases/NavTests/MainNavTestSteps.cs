using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Nav.MainNav;
using ApolloQA.Helpers;

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
            LoginClass loginPage = new LoginClass(driver);
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
            MainNavClass mainNav1 = new MainNavClass(driver);
            mainNav1.ClickOnTab(tabName);
        }

    }
}
