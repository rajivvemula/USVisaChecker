using ApolloQA.Pages.Dashboard;
using ApolloQA.Pages.Nav;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Workflows
{
    class ImpersonateUser
    {

        private  IWebDriver workDriver;

        //Impersonate imp = new Impersonate(workDriver);
        public ImpersonateUser(IWebDriver driver)
        {
            workDriver = driver;

        }

        public void UserToImp(string user)
        {
            Impersonate imp = new Impersonate(workDriver);
            HomePage homePage = new HomePage(workDriver);
            imp.OpenImpersonate();
            imp.UserToImpersonate(user);
            string verifyUser = imp.VerifyInput();
            Assert.AreEqual(user, verifyUser);
            imp.ClickSubmit();
            homePage.GotToHome();
            string verifyName = homePage.VerifyLoggedInUser();
            Assert.AreEqual("First Name: ApolloTestUserG201", verifyName);
        }
    }
}
