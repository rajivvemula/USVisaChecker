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

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);

            //login
            LoginClass loginPage = new LoginClass(driver);
            loginPage.EnterUsername(Defaults.ADMIN_USERNAME);
            loginPage.ClickNextButton();
            loginPage.EnterPassword(Defaults.DEFAULT_PASSWORD);
            loginPage.ClickNextButton();
            loginPage.ClickNoButton();
        }

        [When(@"I navigate to the homepage")]
        public void WhenINavigateToTheHomepage()
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
        }
        
        [Then(@"The Main Navbar should display properly")]
        public void ThenTheMainNavbarShouldDisplayProperly()
        {
            MainNavClass mainNav1 = new MainNavClass(driver);
            mainNav1.VerifyAllTabsArePresentAndClickable();
        }
    }
}
