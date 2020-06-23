using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Pages.Shared
{
    class Impersonate
    {

        private IWebDriver driver;
        public Impersonate(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IWebElement impButton => driver.FindElement(By.XPath("//mat-icon[contains(text(),'assignment_ind')]"));

        public IWebElement userEmail => driver.FindElement(By.XPath("//input[@formcontrolname='email']"));
        public IWebElement submitButton => driver.FindElement(By.XPath("//button[@aria-label='Submit']"));

        public void OpenImpersonate()
        {
            impButton.Click();
            //add assert
        }

        public void UserToImpersonate(string user)
        {
            userEmail.SendKeys(user);
            

        }
        public void ClickSubmit()
        {
            submitButton.Click();
            Thread.Sleep(1500);
        }
        public string VerifyInput()
        {
            string inputString = userEmail.GetAttribute("value");
            return inputString;
        }

    }
}
