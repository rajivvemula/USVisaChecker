using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Pages.Nav
{
    class Impersonate
    {

        private IWebDriver navDriver;
        public Impersonate(IWebDriver driver)
        {
            navDriver = driver;

        }

        public IWebElement impButton => navDriver.FindElement(By.XPath("//mat-icon[contains(text(),'assignment_ind')]"));
        public IWebElement impInput => navDriver.FindElement(By.XPath("//input[@formcontrolname='email']"));
        public IWebElement submitButton => navDriver.FindElement(By.XPath("//button[@aria-label='Submit']"));

        public void OpenImpersonate()
        {
            impButton.Click();
            //add assert
        }

        public void UserToImpersonate(string user)
        {
            impInput.SendKeys(user);
            

        }
        public void ClickSubmit()
        {
            submitButton.Click();
            Thread.Sleep(1500);
        }
        public string VerifyInput()
        {
            string inputString = impInput.GetAttribute("value");
            return inputString;
        }

    }
}
