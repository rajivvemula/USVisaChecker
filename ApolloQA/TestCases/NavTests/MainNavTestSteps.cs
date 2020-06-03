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
            driver.Navigate().GoToUrl(Defaults.qaUrl);

            //login
            LoginClass loginPage = new LoginClass(driver);
            loginPage.EnterUsername(Defaults.adminUsername);
            loginPage.ClickNextButton();
            loginPage.EnterPassword(Defaults.defaultPassword);
            loginPage.ClickNextButton();
            loginPage.ClickNoButton();
        }

        [When(@"I navigate to the homepage")]
        public void WhenINavigateToTheHomepage()
        {
            driver.Navigate().GoToUrl(Defaults.qaUrl);
        }
        
        [Then(@"The Main Navbar should display properly")]
        public void ThenTheMainNavbarShouldDisplayProperly()
        {
            MainNavClass mainNav1 = new MainNavClass(driver);
            mainNav1.VerifyTabsArePresentAndClickable();
        }
    }
}
