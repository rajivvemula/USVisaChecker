using ApolloQA.Helpers;
using ApolloQA.Pages.Application;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static ApolloQA.Pages.Application.ApplicationUWQuestions;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R061_NewApplicationOneAtATimeSteps
    {
        private IWebDriver driver;
        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;

        private MainNavBar mainNavBar;
        private ApplicationMain appMain;
        private ApplicationGrid appGrid;
        private ApplicationInformation appInfo;
        private BusinessInformation busInfo;
        private Components components;
        private Functions functions;
        private Toaster toaster;
        private ApplicationUWQuestions appUWQuestions;

        public R061_NewApplicationOneAtATimeSteps(IWebDriver driver, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;

            mainNavBar = new MainNavBar(driver);
            appMain = new ApplicationMain(driver);
            appGrid = new ApplicationGrid(driver);
            appInfo = new ApplicationInformation(driver);
            busInfo = new BusinessInformation(driver);
            components = new Components(driver);
            functions = new Functions(driver);
            toaster = new Toaster(driver);
            appUWQuestions = new ApplicationUWQuestions(driver);
        }

        [When(@"I create a new application with values")]
        public void WhenICreateANewApplicationWithValues(Table table)
        {
            string orgName = table.Rows[0]["Business Name"];
            string lob = table.Rows[0]["LOB"];
            string effectiveDate = table.Rows[0]["Effective Date"];

            //complete initial page of application
            mainNavBar.ClickApplicationTab();
            appGrid.ClickNew();
            appInfo.EnterBusinessName(orgName);
            appInfo.SelectLOB(lob);
            appInfo.EnterEffectiveDate(effectiveDate);
            appInfo.ClickNext();

            //save parameters to scenario context for use in then step
            _featureContext.Add("Organization Name", orgName);
            _featureContext.Add("LOB", lob);
            _featureContext.Add("Effective Date", effectiveDate);

        }

        [When(@"I update physical address to existing address (.*)")]
        public void WhenIUpdatePhysicalAddressToExistingAddress(string existingAddress)
        {
            busInfo.UpdatePhysicalAddress(existingAddress);
            busInfo.SaveChanges();

            //update physical address in feature context for use in then step
            _featureContext.Add("Physical Address", existingAddress);
        }

        [Then(@"an application is successfully created with the proper values")]
        public void ThenAnApplicationIsSuccessfullyCreatedWithTheProperValues()
        {
            //check toast
            string toastTitle = toaster.GetToastTitle();
            Console.WriteLine(toastTitle);
            Assert.That(toastTitle, Does.Contain("was created"));

            Assert.That(components.GetValueFromHeaderField("Business Name"), Is.EqualTo(_featureContext.Get<string>("Organization Name")), "Organization Name does not match expected.");
            Assert.That(components.GetValueFromHeaderField("Line of Business"), Is.EqualTo(_featureContext.Get<string>("LOB")), "LOB does not match expected.");
            Assert.That(components.GetValueFromHeaderField("Effective Date"), Is.EqualTo(_featureContext.Get<string>("Effective Date")), "Effective Date does not match expected.");
        }

        [Then(@"The Physical Address is successfully updated")]
        public void ThenThePhysicalAddressIsSuccessfullyUpdated()
        {

            //Remove later - related to continue anyway bug
            try
            {
                appMain.busInfoLink.Click();
            }
            catch
            {
                try { busInfo.continueAnyway.Click(); }
                catch { }

                appMain.busInfoLink.Click();
            }
            Assert.That(busInfo.GetCurrentPhysicalAddress(), Is.EqualTo(_featureContext.Get<string>("Physical Address")), "Physical Address does not match expected.");
        }

        [Then(@"the following values are displayed on application's Business Information tab")]
        public void ThenTheFollowingValuesAreDisplayedOnApplicationsBusinessInformationTab(Table table)
        {
            foreach (var row in table.Rows)
            {
                string fieldName = row[0];

                string displayedValue = components.GetValueFromInputFieldByNameAttribute(BusinessInformation.inputFieldNames[fieldName]);

                string expectedValue = row[1];

                Assert.AreEqual(expectedValue, displayedValue);
                
            }
        }

        //[Then(@"the values are stored in the application's database entry")]
        //public void ThenTheValuesAreStoredInTheApplicationsDatabaseEntry()
        //{
        //    ScenarioContext.Current.Pending();
        //}


        [Given(@"I am on the application's UW Questions tab")]
        public void GivenIAmOnTheApplicationsUWQuestionsTab()
        {

            if(!driver.Url.Contains("section/9005"))
                appMain.uwQuestionsLink.Click();

            //REMOVE LATER ONCE CONTINUE ANYWAY BUG IS FIXED
            if (!driver.Url.Contains("section/9005"))
            {
                try { busInfo.continueAnyway.Click(); }
                catch { }
            }
        }


        [Then(@"question type (.*) is displayed with text: (.*)")]
        public void ThenQuestionTypeIsDisplayedWithText(string questionType, string questionText)
        {
            //store text and type for use in other steps
            _scenarioContext.Add("Question Type", questionType);
            _scenarioContext.Add("Question Text", questionText);

            //make sure question is present
            Assert.IsTrue(appUWQuestions.QuestionIsDisplayed(questionType, questionText));
        }

        [When(@"I attempt to answer with selection: (.*)")]
        public void WhenIAttemptToAnswerWithSelection(string selection)
        {
            //store desired selection
            _scenarioContext.Add("Selection Text", selection);

            //attempt to answer
            bool ableToAnswer = appUWQuestions.AnswerQuestion(_scenarioContext.Get<string>("Question Type"), _scenarioContext.Get<string>("Question Text"), _scenarioContext.Get<string>("Selection Text"));

            Assert.IsTrue(ableToAnswer);
        }

        [Then(@"the selection is recorded")]
        public void ThenTheSelectionIsRecorded()
        {
            //verify proper answer is selected
            bool properAnswerSelected = appUWQuestions.AnswerIsSelected(_scenarioContext.Get<string>("Question Type"), _scenarioContext.Get<string>("Question Text"), _scenarioContext.Get<string>("Selection Text"));

            Assert.IsTrue(properAnswerSelected);
        }


    }
}
