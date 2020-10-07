using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using ApolloQA.Pages.Fnol;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.FNOL
{
    [Binding]
    public class F004_FNOLOccurenceNegativeTestsSteps
    {
        private IWebDriver driver;
        Random rnd;
        State state;
        FNOLInsert fnolInsert;
        Components helper;
        Toaster toaster;


        public F004_FNOLOccurenceNegativeTestsSteps(IWebDriver driver, State state)
        {
            this.driver = driver;
            this.state = state;
            rnd = new Random();
            fnolInsert = new FNOLInsert(driver);
            helper = new Components(driver);
            toaster = new Toaster(driver);
        }

        [Then(@"Verify Date of Loss - cannot be a future date\.")]
        public void ThenVerifyDateOfLoss_CannotBeAFutureDate_()
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);
            string stringDate = tomorrow.ToString("MM/dd/yyyy");
            fnolInsert.dateOfLossInput.SendKeys(stringDate);
            bool verify = helper.CheckError("Date cannot be in the future.");
            Assert.IsTrue(verify, "an error did not show for putting a future date of loss");
        }

        [Then(@"Verify Time of Loss - default time")]
        public void ThenVerifyTimeOfLoss_DefaultToAmOfDOL()
        {
            Assert.That(() => fnolInsert.timeOfLossInput.GetAttribute("value"), Does.Contain("12:01 AM").After(3).Seconds.PollEvery(250).MilliSeconds, "Time of Loss Default Value Not Set");
        }

        [Then(@"Verify How Received contains phone - email - carrier pigeon")]
        public void ThenVerifyHowReceivedPhoneEmailCarrierPigeon()
        {
            string[] recievedValues = { "Phone", "Email", "Carrier Pigeon" };
            fnolInsert.receivedSelect.Click();
            foreach(string i in recievedValues)
            {
                bool valueCheck = helper.CheckSelectValue(i);
                Assert.IsTrue(valueCheck, i + " does not exist");
            }
            fnolInsert.inputFirstName.Click();
        }

        [Then(@"Verify Date Reported - defaults to today")]
        public void ThenVerifyDateReported_DefaultsToToday()
        {
            DateTime today = DateTime.Today;
            string stringDateToday = today.ToString("MM/dd/yyyy");
            Assert.That(() => fnolInsert.dateReportedInput.GetAttribute("value"), Does.Contain(stringDateToday).After(3).Seconds.PollEvery(250).MilliSeconds, "Date Reported Date Not Defaulting To Today");
            DateTime tomorrow = DateTime.Today.AddDays(1);
            string stringDate = tomorrow.ToString("MM/dd/yyyy");
            fnolInsert.dateReportedInput.SendKeys(stringDate);
            bool verify = helper.CheckError("Date cannot be in the future.");
            Assert.IsTrue(verify, "an error did not show for putting a future date of loss");

        }

        [Then(@"Verify CAT defaults to None and has option1 and option2")]
        public void ThenVerifyCATDefaultsToNone()
        {
            Assert.That(() => fnolInsert.claimCategory.GetAttribute("value"), Does.Contain("None").After(3).Seconds.PollEvery(250).MilliSeconds, "Cat Field Not Defaulting to None");
            string[] recievedValues = { "Option 1", "Option 2" };
            fnolInsert.claimCategory.Click();
            foreach (string i in recievedValues)
            {
                bool valueCheck = helper.CheckSelectValue(i);
                Assert.IsTrue(valueCheck, i + " does not exist");
            }
            fnolInsert.inputFirstName.Click();
        }



    }
}
