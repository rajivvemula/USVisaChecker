using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace ClassLibrary2
{
    [Binding]
    public class SpecFlowFeature1Steps
    {

        public IWebDriver driver;
        string USERNAME = "ApolloTestUserG301@biberk.com";
        string PASSWORD = "HashTagApollo#24";

        [Given(@"user navigates to qa website")]
        public void GivenUserNavigatesToQaWebsite()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://biberk-apollo-qa.azurewebsites.net/home");
        }
        
        [When(@"user input a username and password")]
        
        public void WhenUserInputAUsername()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.FindElement(By.XPath("//input[@class='form-control ltr_override' and @name='loginfmt']")).SendKeys(USERNAME);
            Login loginPage = new Login(driver);
            loginPage.EnterUsername(USERNAME);
            driver.FindElement(By.Id("idSIButton9")).Click();
            loginPage.EnterPassword(PASSWORD);
            driver.FindElement(By.Id("idSIButton9")).Click();
            driver.FindElement(By.Id("idBtn_Back")).Click();
        }
        
        
        [Then(@"user is shown the homepage")]
        public void ThenPasswordscreenIsShown()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string pageTitle = driver.Title;
            Console.WriteLine(pageTitle);
            Assert.AreEqual(pageTitle, "Home");
            driver.Quit();
        }

    }
}
