using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Dashboard
{
    class HomePage
    {
        private IWebDriver homeDriver;
        public HomePage(IWebDriver driver)
        {
            homeDriver = driver;

        }

        //public IWebElement firstName => homeDriver.FindElement(By.XPath("//p[contains(text(),'First Name:')]"));
        public void GotToHome()
        {
            homeDriver.Navigate().GoToUrl("https://biberk-apollo-qa.azurewebsites.net/home");
        }
        public string VerifyLoggedInUser()
        {
            string verifyUser = homeDriver.FindElement(By.XPath("//p[contains(text(),'First Name: ApolloTestUserG201')]")).Text;
            return verifyUser;
        }

       

    }
}
