using ApolloQA.Pages.Dashboard;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R004_AccessPolicyListSteps
    {

        public IWebDriver driver;
        MainNavBar mainNavBar;
        HomePage homePage;
        public R004_AccessPolicyListSteps(IWebDriver Driver)
        {
            driver = Driver;
            mainNavBar = new MainNavBar(Driver);
            homePage = new HomePage(Driver);
        }


        [When(@"User clicks on Policy Link in Navigation Bar")]
        public void WhenUserClicksOnPolicyLinkInNavigationBar()
        {
            mainNavBar.ClickHomeIcon();
        }
        
        [Then(@"User is shown the Policy List")]
        public void ThenUserIsShownThePolicyList()
        {
            Thread.Sleep(2000);
            string verifyTitle = driver.Title;
            Assert.AreEqual(verifyTitle, "Policy List");
        }
    }
}
