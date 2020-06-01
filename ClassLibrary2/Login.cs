using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary2
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
            loginDriver.FindElement(By.XPath("//input[@class='form-control ltr_override' and @name='loginfmt']")).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            loginDriver.FindElement(By.XPath("//input[@class='form-control' and @name='passwd']")).SendKeys(password);
        }
    }
}
