using ApolloQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Dashboard
{
    class HomePage
    {
        private IWebDriver homeDriver;
        private Functions functions;

        public HomePage(IWebDriver driver)
        {
            homeDriver = driver;
            functions = new Functions(driver);
        }

        //public IWebElement firstName => homeDriver.FindElement(By.XPath("//p[contains(text(),'First Name:')]"));
        public void GotToHome()
        {
            homeDriver.Navigate().GoToUrl("https://biberk-apollo-qa2.azurewebsites.net/home");
        }
        public bool VerifyLoggedInUser(string user)
        {
            //bool verifyUser = homeDriver.FindElement(By.XPath("//p[contains(text(),'Email: " + user + "')]")).Text;
            //return verifyUser;

            IWebElement target = functions.FindElementWait(10, By.XPath("//p[contains(text(),'Email: " + user + "')]"));
            bool verifyUser = target.Displayed;

            return verifyUser;
        }

        public bool CheckRole(string role)
        {
            IWebElement target = functions.FindElementWait(10, By.XPath("//p[@class='ng-star-inserted' and normalize-space(text())='" + role +"']"));
            bool verifyRole = target.Displayed;
            return verifyRole;
        }

        public string GetTitle()
        {
            string title = homeDriver.Title;
            return title;
        }



    }
}
