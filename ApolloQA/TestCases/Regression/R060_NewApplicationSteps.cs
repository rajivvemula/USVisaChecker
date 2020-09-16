using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using ApolloQA.Pages.Application;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R060_NewApplicationSteps
    {
        private FeatureContext _featureContext;
        private List<ApplicationObject> applicationList;

        private IWebDriver driver;
        private MainNavBar mainNavBar;
        private ApplicationMain appMain;
        private ApplicationGrid appGrid;
        private ApplicationInformation appInfo;
        private BusinessInformation busInfo;
        private Components components;
        private Functions functions;
        private Toaster toaster;

        public R060_NewApplicationSteps(IWebDriver driver, FeatureContext featureContext)
        {
            this.driver = driver;
            _featureContext = featureContext;

            applicationList = _featureContext.Get<List<ApplicationObject>>("Application List");

            mainNavBar = new MainNavBar(driver);
            appMain = new ApplicationMain(driver);
            appGrid = new ApplicationGrid(driver);
            appInfo = new ApplicationInformation(driver);
            busInfo = new BusinessInformation(driver);
            components = new Components(driver);
            functions = new Functions(driver);
            toaster = new Toaster(driver);
        }

        [When(@"I create a new application with values (.*), (.*), (.*) as Application Index (.*)")]
        public void WhenIStartANewApplicationWithValuesAsApplicationIndex(string businessName, string lineOfBusiness, string effectiveDate, int applicationIndex)
        {
            //complete initial page of application
            mainNavBar.ClickApplicationTab();
            appGrid.ClickNew();
            appInfo.EnterBusinessName(businessName);
            appInfo.SelectLOB(lineOfBusiness);
            appInfo.EnterEffectiveDate(effectiveDate);
            appInfo.ClickNext();

            //create our ApplicationObject and add it to list
            ApplicationObject newlyCreatedApp = new ApplicationObject();
            newlyCreatedApp.BusinessName = businessName;
            newlyCreatedApp.LineOfBusiness = lineOfBusiness;
            newlyCreatedApp.EffectiveDate = effectiveDate;

            applicationList.Add(newlyCreatedApp);


        }




        [Then(@"an application is successfully created with the proper values for Application Index (.*)")]
        public void ThenAnApplicationIsSuccessfullyCreatedWithTheProperValuesForApplicationIndex(int applicationIndex)
        {

            //check toast
            string toastTitle = toaster.GetToastTitle();
            Assert.That(toastTitle, Does.Contain("was created"));

            //write application number to application object
            applicationList[applicationIndex].ApplicationNumber = int.Parse(components.GetValueFromHeaderField("Application Number"));

            //go to business info and check values in top bar
            appMain.busInfoLink.Click();

            //Console.WriteLine(components.GetValueFromHeaderField("Business Name"));
            //Console.WriteLine(components.GetValueFromHeaderField("Line of Business"));
            //Console.WriteLine(components.GetValueFromHeaderField("Effective Date"));

            Assert.That(components.GetValueFromHeaderField("Business Name"), Is.EqualTo(applicationList[applicationIndex].BusinessName), "Organization Name does not match expected.");
            Assert.That(components.GetValueFromHeaderField("Line of Business"), Is.EqualTo(applicationList[applicationIndex].LineOfBusiness), "LOB does not match expected.");
            Assert.That(components.GetValueFromHeaderField("Effective Date"), Is.EqualTo(applicationList[applicationIndex].EffectiveDate), "Effective Date does not match expected.");
        }

        [When(@"I update mailing address to existing address (.*) for Application Index (.*)")]
        public void WhenIUpdateMailingAddressToExistingAddressForApplicationIndex(string existingAddress, int applicationIndex)
        {

            driver.Navigate().GoToUrl(Defaults.QA_URLS["Application"] + applicationList[applicationIndex].ApplicationNumber);

            appMain.busInfoLink.Click();
            busInfo.UpdateMailingAddress(existingAddress);
            busInfo.SaveChanges();

            //update mailing address of our object
            applicationList[applicationIndex].MailingAddress = existingAddress;
        }

        [Then(@"The Mailing Address is successfully updated for Application Index (.*)")]
        public void ThenTheMailingAddressIsSuccessfullyUpdatedForApplicationIndex(int applicationIndex)
        {
            appMain.busInfoLink.Click();
            Assert.That(busInfo.GetCurrentMailingAddress(), Is.EqualTo(applicationList[applicationIndex].MailingAddress), "Mailing Address does not match expected.");
        }




        //[When(@"I start a new application with below values")]
        //public void WhenIStartANewApplicationWithBelowValues(Table table)
        //{
        //    string orgName = table.Rows[0]["Business Name"];
        //    string lob = table.Rows[0]["LOB"];
        //    string effectiveDate = table.Rows[0]["Effective Date"];

        //    //complete initial page of application
        //    mainNavBar.ClickApplicationTab();
        //    appGrid.ClickNew();
        //    appInfo.EnterBusinessName(orgName);
        //    appInfo.SelectLOB(lob);
        //    appInfo.EnterEffectiveDate(effectiveDate);
        //    appInfo.ClickNext();

        //    //save parameters to scenario context for use in other step
        //    _featureContext.Add("Organization Name", orgName);
        //    _featureContext.Add("LOB", lob);
        //    _featureContext.Add("Effective Date", effectiveDate);
        //}


        //[Then(@"an application is successfully created with the proper values")]
        //public void ThenAnApplicationIsSuccessfullyCreatedWithTheProperValues()
        //{
        //    ////BEFORE ANY ACTIONS ON A NEW APPLICATION, HAVE TO WAIT FOR TAXONOMY FIELD TO LOAD, OTHERWISE APPLICATION BREAKS
        //    //// if this fails, class taxonomy field is glitched for that particular application
        //    //IWebElement taxonomyField = functions.FindElementWait(15, By.XPath("//input[@formcontrolname='industryClassTaxonomyClassName' and contains(@class, 'ng-valid')]"));

        //    //check toast
        //    string toastTitle = toaster.GetToastTitle();
        //    Assert.That(toastTitle, Does.Contain("was created"));

        //    //write application number to feature context
        //    _featureContext.Add("Application Number", components.GetValueFromHeaderField("Application Number"));

        //    //go to business info and check values in top bar
        //    appMain.busInfoLink.Click();

        //    Console.WriteLine(components.GetValueFromHeaderField("Business Name"));
        //    Console.WriteLine(components.GetValueFromHeaderField("Line of Business"));
        //    Console.WriteLine(components.GetValueFromHeaderField("Effective Date"));

        //    Assert.That(components.GetValueFromHeaderField("Business Name"), Is.EqualTo(_featureContext.Get<string>("Organization Name")), "Organization Name does not match expected.");
        //    Assert.That(components.GetValueFromHeaderField("Line of Business"), Is.EqualTo(_featureContext.Get<string>("LOB")), "LOB does not match expected.");
        //    Assert.That(components.GetValueFromHeaderField("Effective Date"), Is.EqualTo(_featureContext.Get<string>("Effective Date")), "Effective Date does not match expected.");
        //}


        //[When(@"I update mailing address to existing address (.*)")]
        //public void WhenIUpdateMailingAddressToExistingAddress(string newAddress)
        //{
        //    appMain.busInfoLink.Click();
        //    busInfo.UpdateMailingAddress(newAddress);
        //    busInfo.SaveChanges();

        //    //update mailing address in feature context
        //    _featureContext.Add("Mailing Address", newAddress);
        //}

        //[Then(@"The Mailing Address is successfully updated")]
        //public void ThenTheMailingAddressIsSuccessfullyUpdated()
        //{
        //    appMain.busInfoLink.Click();
        //    Assert.That(busInfo.GetCurrentMailingAddress(), Is.EqualTo(_featureContext.Get<string>("Mailing Address")), "Mailing Address does not match expected.");
        //}


    }
}
