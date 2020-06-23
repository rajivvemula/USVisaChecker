using ApolloQA.Helpers;
using ApolloQA.Pages.Dashboard;
using ApolloQA.Pages.Nav;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R002_AdminPrivilegesSteps
    {

        public IWebDriver driver;
        HomePage homePage;
        MainNavBar mainNavBar;
        public R002_AdminPrivilegesSteps(IWebDriver Driver)
        {
            driver = Driver;
            homePage = new HomePage(Driver);
            mainNavBar = new MainNavBar(Driver);
        }

        [Given(@"User is on Dashboard")]
        public void GivenUserIsLoggedInAsAdmin()
        {
            mainNavBar.ClickOnTab("Home");
            string title = driver.Title;
            Assert.AreEqual(title, "Home");
        }
        
        [When(@"User is logged in as Admin")]
        public void WhenUserIsOnDashboard()
        {
            
            bool verifyUser = homePage.VerifyLoggedInUser(Defaults.ADMIN_USERNAME);
            Assert.AreEqual(verifyUser, true);
        }
        
        [Then(@"Admin should have Appropriate User Roles")]
        public void ThenAdminShouldHaveAppropriateUserRoles()
        {
            
            
            foreach(string i in Defaults.adminRoles)
            {
                bool verifyRole = homePage.CheckRole(i);
                Assert.AreEqual(verifyRole, true);
            }
        }
    }
}
