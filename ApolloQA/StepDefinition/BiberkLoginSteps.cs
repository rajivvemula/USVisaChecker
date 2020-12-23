﻿using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using ApolloQA.Source.Driver;
using System.IO;
using ApolloQA.Source.Helpers;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class BiberkLoginSteps
    {
        public IWebDriver driver;


        public BiberkLoginSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Given(@"user is successfully logged into biberk")]
        public void GivenUserIsSuccessfullyLoggedIntoBiberk()
        {
            if (driver.Url == "data:," && loadSessionIntoDriver() == false)
            {
                
                GivenUserLandedBiBerkPageWithValidURL();
                WhenUserEntersAnd("ApolloTestUserG311@biberk.com", "ApolloTest12");
                WhenUserAttemptsToLogin();
                ThenUserLoginSuccessfullyToBiBerkPage();

                return;
            }

            GivenUserLandedBiBerkPageWithValidURL();

            Pages.Home.ApolloIcon.assertElementIsVisible(10, optional: true);
        }

        [Given(@"user landed biBerk page with valid URL")]
        public void GivenUserLandedBiBerkPageWithValidURL()
        {
            Pages.Login.navigate();
        }

        [When(@"user enters username: (.*) and password: (.*)")]
        public void WhenUserEntersAnd(string username, string password)
        {
            Log.Info($"Login in with {username}");
            Pages.Login.usernameField.setText(username, 120);
            
            Pages.Login.nextButton.Click();
            Pages.Login.passwordField.setText(password);            
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
            Pages.Home.ApolloIcon.assertElementIsVisible(120);
        }

        public static bool loadSessionIntoDriver()
        {
            String filepath = Path.Combine(Setup.SourceDir, "SessionToken.temp");
            if (File.Exists(filepath))
            {
                string sessionObject = File.ReadAllText(filepath);
                Pages.Login.navigate();
                JSExecutor.execute($"window.localStorage.setItem('currentUser', arguments[0])", sessionObject);
                Pages.Login.navigate();
                return true;
            }
            return false;
        }
    }
}