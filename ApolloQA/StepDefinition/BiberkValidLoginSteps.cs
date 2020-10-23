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
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Steps
{
    [Binding]
    public sealed class BiberkValidLoginSteps
    {
        public IWebDriver driver;


        BiberkValidLoginSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Given(@"user landed biBerk page with valid URL")]
        public void GivenUserLandedBiBerkPageWithValidURL()
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
        }

        [When(@"user enters username: (.*) and password: (.*)")]
        public void WhenUserEntersAnd(string username, string password)
        {
            Log.Info("User enters username");
            Log.Critical("critical username");


            Pages.Login.usernameField.setText(username);
            Pages.Login.nextButton.Click();
            Pages.Login.passwordField.setText(password);
            var sev1 = new Severity(2);
            var sev2 = new Severity(2);
            Console.WriteLine(Assert.AreEqual(sev1, sev2,true));
            Boolean? somebool = null;
            Console.WriteLine(Assert.IsNull(somebool));

        }

        [When(@"user attempts to login")]
        public void WhenUserAttemptsToLogin()
        {
            Pages.Login.nextButton.Click();
            Pages.Login.noButton.Click();
            
        }
       
        [Then(@"user login successfully to biBerk page")]
        public void ThenUserLoginSuccessfullyToBiBerkPage()
        {
            driver.FindElement(By.XPath("//fa-icon[@routerlink='home']"));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//fa-icon[@routerlink='home']")).Text.Trim();
            //ScreenShot.Debug();

        }


    }
}
