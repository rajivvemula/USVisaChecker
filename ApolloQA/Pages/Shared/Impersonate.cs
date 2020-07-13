using ApolloQA.Helpers;
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
        private Functions functions;

        public Impersonate(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
        }

        public IWebElement impButton => functions.FindElementWait(10, By.XPath("//mat-icon[contains(text(),'assignment_ind')]"));

        public IWebElement userEmail => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='email']"));
        public IWebElement submitButton => functions.FindElementWait(10, By.XPath("//button[@aria-label='Submit']"));

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
