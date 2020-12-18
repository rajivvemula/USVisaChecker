using ApolloQA.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.General
{
    [Binding]
    public class G004_RadioButtonsSteps
    {

        private IWebDriver driver;
        Components helper;

        public G004_RadioButtonsSteps(IWebDriver driver)
        {
            this.driver = driver;
            helper = new Components(driver);
        }

        [Then(@"Verify Radio Option is present : (.*)")]
        public void ThenVerifyRadioOptionIsPresent(string radioValue)
        {
            bool verifyRadio = helper.CheckIfRadioExists(radioValue);
            Assert.IsTrue(verifyRadio, " radio button with the value: " + radioValue + " does not exist");
        }

        [When(@"User selects radio option: (.*)")]
        public void WhenUserSelectsRadioOption(string radio)
        {
            helper.SelectRadioOption(radio);
        }

    }
}
