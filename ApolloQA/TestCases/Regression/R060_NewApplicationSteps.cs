using ApolloQA.Helpers;
using ApolloQA.Pages.Application;
using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R060_NewApplicationSteps
    {
        private IWebDriver driver;
        private MainNavBar mainNavBar;
        private ApplicationGrid appGrid;
        private ApplicationInformation appInfo;
        private Components components;
        private Toaster toaster;

        public R060_NewApplicationSteps(IWebDriver Driver)
        {
            this.driver = Driver;
            mainNavBar = new MainNavBar(driver);
            appGrid = new ApplicationGrid(driver);
            appInfo = new ApplicationInformation(driver);
            components = new Components(driver);
            toaster = new Toaster(driver);
        }


        [When(@"I attempt to create a policy with (.*), (.*), (.*)")]
        public void WhenIAttemptToCreateAPolicyWith(string orgName, string lob, string effectiveDate)
        {
            mainNavBar.ClickApplicationTab();
            appGrid.ClickNew();
            appInfo.EnterBusinessName(orgName);
            appInfo.SelectLOB(lob);
            appInfo.EnterEffectiveDate(effectiveDate);
            appInfo.ClickNext();
        }
        
        [Then(@"a policy is successfully created with (.*), (.*), (.*)")]
        public void ThenAPolicyIsSuccessfullyCreatedWith(string orgName, string lob, string effectiveDate)
        {
            string toastTitle = toaster.GetToastTitle();


        }
    }
}
