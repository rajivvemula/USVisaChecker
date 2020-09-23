using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Helpers;
using ApolloQA.Pages.Dashboard;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace ApolloQA.Pages.Login
{
    class LoginPage
    {
        protected IWebDriver driver;
        protected Functions functions;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
        }

        public IWebElement usernameField => functions.FindElementWait(10, By.XPath("//input[@type='email' and @name='loginfmt']"));
        public IWebElement passwordField => functions.FindElementWait(10, By.XPath("//input[@type='password' and @name='passwd']"));
        public IWebElement nextButton => functions.FindElementWait(10, By.Id("idSIButton9"));
        public IWebElement noButton => functions.FindElementWait(10, By.Id("idBtn_Back"));
        public IWebElement bottomText => functions.FindElementWait(10, By.XPath("idBoilerPlateText"));

        public void loginValidUser(String username, String password)
        {
            EnterUsername(username);
            ClickNextButton();
            EnterPassword(password);
            ClickNextButton();
            ClickNoButton();
        }

        public void EnterUsername(string username)
        {
            usernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
        }

        public string GetUsername()
        {
            return usernameField.GetAttribute("value");
        }

        public string GetPassword()
        {
            return passwordField.GetAttribute("value");

        }

        public void ClickNextButton()
        {
            nextButton.Click();
        }

        public void ClickNoButton()
        {
            noButton.Click();
        }

        //avoid if conditions for scenarios(if username or password) such as below and use direct methods
        public void ClearUsername()
        {
            usernameField.Clear();
        }

        public void ClearPassword()
        {
            passwordField.Clear();
        }

        public bool VerifyLoginScreen()
        {
            string bottomTextString = bottomText.Text;
            bool verifyText = bottomTextString.Contains("biBERK");
            return verifyText;
        }
    }
}
