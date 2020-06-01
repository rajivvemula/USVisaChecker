using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace ApolloQA.Pages.Login
{
    class Login
    {
        private IWebDriver loginDriver;
        public Login(IWebDriver driver)
        {
            loginDriver = driver;
        }

        public void EnterUsername(string username)
        {
            bool usernamePresent = string.IsNullOrEmpty(username);
            loginDriver.FindElement(By.XPath(LoginLocs.locUsername)).SendKeys(usernamePresent ? "ApolloTestUserG301@biberk.com" : username);
        }

        public void EnterPassword(string password)
        {
            loginDriver.FindElement(By.XPath(LoginLocs.locPassword)).SendKeys(password);
        }

        public string GetUsername()
        {
            string usernameText = loginDriver.FindElement(By.XPath(LoginLocs.locUsername)).GetAttribute("value");
            return usernameText;

        }
        //Verify in class is usefull sometimes but we want to stick with external asserts and use GetUsername
        /*
        public bool VerifyUsername(string userToVerify)
        {
            string usernameText = loginDriver.FindElement(By.XPath(LoginLocs.locUsername)).GetAttribute("value");
            bool usernameBool = usernameText.Equals(userToVerify);
            return usernameBool;
        }
        */
        public string GetPassword()
        {
            string passwordText = loginDriver.FindElement(By.XPath(LoginLocs.locPassword)).GetAttribute("value");
            return passwordText;

        }

        public void ClickNextButton()
        {
            loginDriver.FindElement(By.Id(LoginLocs.locNextButton)).Click();
        }

        public void ClickNoButton()
        {
            loginDriver.FindElement(By.Id(LoginLocs.locNoButton)).Click();
        }

        //avoid if conditions for scenarios(if username or password) such as below and use direct methods
        public void ClearUsername()
        {
            loginDriver.FindElement(By.XPath(LoginLocs.locUsername)).Clear();
        }

        public void ClearPassword()
        {
            loginDriver.FindElement(By.XPath(LoginLocs.locPassword)).Clear();
        }

        public bool VerifyLoginScreen()
        {
            string bottomText = loginDriver.FindElement(By.Id(LoginLocs.locBottomText)).Text;
            bool verifyText = bottomText.Contains("biBERK");
            return verifyText;
        }
    }
}
