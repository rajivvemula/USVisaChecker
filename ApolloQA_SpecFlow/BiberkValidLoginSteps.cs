using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;


namespace ApolloQA_SpecFlow.Steps
{
    [Binding]
    public sealed class BiberkValidLoginSteps
    {
        public static IWebDriver driver;
   
        public static IWebElement element;
        public static IJavaScriptExecutor js;

        public void highligth(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script: "arguments[0].style.border='3px solid red'", element);
        }

        private String ExpectedHomePage = "Home", ActualHomePage = "";

        [Given(@"user(.*) landed biBerk page with valid URL")]
        public void GivenUserLandedBiBerkPageWithValidURL(int p0)
        {
            Console.WriteLine("01 user1 landed biBerk page with valid URL");
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Url = "https://biberk-apollo-qa2.azurewebsites.net";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Given(@"user(.*) enter valid username and click on Next CTA")]
        public void GivenUserEnterValidUsernameAndClickOnNextCTA(int p0)
        {
            Console.WriteLine("02 user1 enter valid username and click on Next CTA");
            driver.FindElement(By.XPath("//*[@id='i0116']")).SendKeys("ApolloTestUserG301@biberk.com");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[contains(@id,'idSIButton')]")).Click();
            
        }

        [Given(@"user(.*) enter valid password and click on Sign in CTA")]
        public void GivenUserEnterValidPasswordAndClickOnSignInCTA(int p0)
        {
            Console.WriteLine("03 user1 enter valid password and click on Sign in CTA");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@name='passwd']")).SendKeys("HashTagApollo#24");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
        }

        [Given(@"user(.*) click on Stay signed in No CTA")]
        public void GivenUserClickOnStaySignedInNoCTA(int p0)
        {
            Console.WriteLine("04 user1 click on Stay signed in No CTA");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@value='No']")).Click();
        }

        [Then(@"user(.*) login successfully to biBerk page")]
        public void ThenUserLoginSuccessfullyToBiBerkPage(int p0)
        {
            Console.WriteLine("05 user1 login successfully to biBerk page");
            highligth(driver, driver.FindElement(By.XPath("//fa-icon[@routerlink='home']")));
            Thread.Sleep(1000);
            ActualHomePage = driver.FindElement(By.XPath("//fa-icon[@routerlink='home']")).Text.Trim();
           // Assert.AreEqual(ExpectedHomePage, ActualHomePage);
        }

        [Then(@"user(.*) logout of biBerk home page")]
        public void ThenUserLogoutOfBiBerkHomePage(int p0)
        {
            Console.WriteLine("06 user1 logout of biBerk page");
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
