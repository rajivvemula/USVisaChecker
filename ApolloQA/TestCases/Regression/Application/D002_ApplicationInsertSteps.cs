using ApolloQA.Helpers;
using ApolloQA.Pages.Application;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.Application
{
    [Binding]
    public class D002_ApplicationInsertSteps
    {
        private IWebDriver driver;
        Buttons button;
        Components components;
        ApplicationInformation applicationInformation;
        Inputs inputs;


        public D002_ApplicationInsertSteps(IWebDriver driver)
        {
            this.driver = driver;
            button = new Buttons(driver);
            components = new Components(driver);
            applicationInformation = new ApplicationInformation(driver);
            inputs = new Inputs(driver);
        }

        [When(@"User searches (.*) in Business Name")]
        public void WhenUserSearchesInBusinessName(string value)
        {
            applicationInformation.businessName.SendKeys(value);
        }

        [When(@"User enters (.*) in Business Name")]
        public void WhenUserEntersInBusinessName(string name)
        {
            string valueInPlace = applicationInformation.businessName.GetAttribute("value");
            if (valueInPlace.Length > 0)
            {
                applicationInformation.businessName.Clear();
                applicationInformation.EnterBusinessName(name);
            } else
            {
                applicationInformation.EnterBusinessName(name);
            }
            Assert.That(() => applicationInformation.businessName.GetAttribute("value"), Does.Contain(name).After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Qoute Creation From App Grid");

        }


        [Then(@"Search (.*) displayed is (.*)")]
        public void ThenSearchDisplayedIs(string value, string check)
        {
            if (check == "false")
            {
                bool verify = inputs.noResultFound.Displayed;
                Assert.IsTrue(verify, "a result was found");
            } else
            {
                bool verify = inputs.CheckIfResultExists(value);
                Assert.IsTrue(verify, "a result was not found");
            }
        }

    }
}
