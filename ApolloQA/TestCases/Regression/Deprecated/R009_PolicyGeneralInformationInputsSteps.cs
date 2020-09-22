using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R009_PolicyGeneralInformationInputsSteps
    {

        public IWebDriver driver;
        PolicySummary policySummary;
        Toaster toaster;

        public R009_PolicyGeneralInformationInputsSteps(IWebDriver Driver)
        {
            driver = Driver;
            policySummary = new PolicySummary(Driver);
            toaster = new Toaster(Driver);

        }
        [Given(@"User is shown the General Information screen")]
        public void GivenUserIsShownTheGeneralInformationScreen()
        {
            string verifyTitle = driver.Title;
            Assert.AreEqual(verifyTitle, "General Information");
        }

        [When(@"User changes Business Type")]
        public void WhenUserChangesBusinessType()
        {
            policySummary.EnterBusType("Partnership");
        }

        [When(@"Clicks Save Button")]
        public void WhenClicksSaveButton()
        {
            policySummary.ClickSaveButton();
        }



        [Then(@"Expected input labels are there")]
        public void ThenExpectedInputLabelsAreThere()
        {
            foreach (string i in policySummary.generalInformationLabels)
            {
                bool verifyRole = policySummary.CheckLabel(i);
                Assert.AreEqual(verifyRole, true);
            }
        }

        [Then(@"User is shown a Toast confirming policy changes are saved")]
        public void ThenUserIsShownAToastConfirmingPolicyChangesAreSaved()
        {
            string currentToast = toaster.GetToastTitle();
            Assert.AreEqual(currentToast, "Policy was saved.");
        }


    }
}
