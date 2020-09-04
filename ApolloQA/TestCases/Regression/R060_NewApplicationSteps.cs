using ApolloQA.Helpers;
using ApolloQA.Pages.Application;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R060_NewApplicationSteps
    {
        private ScenarioContext _scenarioContext;

        private IWebDriver driver;
        private MainNavBar mainNavBar;
        private ApplicationMain appMain;
        private ApplicationGrid appGrid;
        private ApplicationInformation appInfo;
        private BusinessInformation busInfo;
        private Components components;
        private Toaster toaster;

        public R060_NewApplicationSteps(IWebDriver Driver, ScenarioContext scenarioContext)
        {
            this.driver = Driver;
            _scenarioContext = scenarioContext;

            mainNavBar = new MainNavBar(driver);
            appMain = new ApplicationMain(driver);
            appGrid = new ApplicationGrid(driver);
            appInfo = new ApplicationInformation(driver);
            busInfo = new BusinessInformation(driver);
            components = new Components(driver);
            toaster = new Toaster(driver);
        }


        [When(@"I attempt to create an application with (.*), (.*), (.*)")]
        public void WhenIAttemptToCreateAPolicyWith(string orgName, string lob, string effectiveDate)
        {
            //complete initial page of application
            mainNavBar.ClickApplicationTab();
            appGrid.ClickNew();
            appInfo.EnterBusinessName(orgName);
            appInfo.SelectLOB(lob);
            appInfo.EnterEffectiveDate(effectiveDate);
            appInfo.ClickNext();

            //save parameters to scenario context for use in other step
            _scenarioContext.Add("Organization Name", orgName);
            _scenarioContext.Add("LOB", lob);
            _scenarioContext.Add("Effective Date", effectiveDate);
        }

        [Then(@"an application is successfully created with the proper values")]
        public void ThenAnApplicationIsSuccessfullyCreatedWithTheProperValues()
        {
            //check toast
            string toastTitle = toaster.GetToastTitle();
            Assert.That(toastTitle, Does.Contain("was created"));

            //go to business info and check values in top bar
            appMain.busInfoLink.Click();

            Console.WriteLine(components.GetValueFromHeaderField("Business Name"));
            Console.WriteLine(components.GetValueFromHeaderField("Line of Business"));
            Console.WriteLine(components.GetValueFromHeaderField("Effective Date"));

            Assert.That(components.GetValueFromHeaderField("Business Name"), Is.EqualTo(_scenarioContext.Get<string>("Organization Name")), "Organization Name does not match expected.");
            Assert.That(components.GetValueFromHeaderField("Line of Business"), Is.EqualTo(_scenarioContext.Get<string>("LOB")), "LOB does not match expected.");
            Assert.That(components.GetValueFromHeaderField("Effective Date"), Is.EqualTo(_scenarioContext.Get<string>("Effective Date")), "Effective Date does not match expected.");
        }

    }
}
