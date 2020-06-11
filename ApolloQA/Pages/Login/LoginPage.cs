using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace ApolloQA.Pages.Login
{
    class LoginPage
    {
        protected IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage loginValidUser(String username, String password)
        {
            this.EnterUsername(username);
            this.ClickNextButton();
            this.EnterPassword(password);
            this.ClickNextButton();
            this.ClickNoButton();
            return new HomePage(driver);
        }

        public void EnterUsername(string username)
        {
            //wait until field is ready
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(LoginLocs.locUsername)));
            //enter username
            element.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            //wait until field is ready
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(LoginLocs.locPassword)));
            //enter password
            element.SendKeys(password);
        }

        public string GetUsername()
        {
            string usernameText = driver.FindElement(By.XPath(LoginLocs.locUsername)).GetAttribute("value");
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
            string passwordText = driver.FindElement(By.XPath(LoginLocs.locPassword)).GetAttribute("value");
            return passwordText;

        }

        public void ClickNextButton()
        {
            driver.FindElement(By.Id(LoginLocs.locNextButton)).Click();
        }

        public void ClickNoButton()
        {
            driver.FindElement(By.Id(LoginLocs.locNoButton)).Click();
        }

        //avoid if conditions for scenarios(if username or password) such as below and use direct methods
        public void ClearUsername()
        {
            driver.FindElement(By.XPath(LoginLocs.locUsername)).Clear();
        }

        public void ClearPassword()
        {
            driver.FindElement(By.XPath(LoginLocs.locPassword)).Clear();
        }

        public bool VerifyLoginScreen()
        {
            string bottomText = driver.FindElement(By.Id(LoginLocs.locBottomText)).Text;
            bool verifyText = bottomText.Contains("biBERK");
            return verifyText;
        }
    }
}
