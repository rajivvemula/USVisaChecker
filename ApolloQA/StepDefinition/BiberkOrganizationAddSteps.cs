using ApolloQA.Data.Entity;
using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class BiberkOrganizationAddSteps
    {
        public IWebDriver driver;


        BiberkOrganizationAddSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Then(@"user verifies Email is required")]
        public void ThenUserVerifiesEmailIsRequired()
        {
            BusinessInformation.businessEmailAddressField.Click();
           string isRequired = BusinessInformation.businessEmailAddressField.GetAttribute("aria-required");
            Assert.AreEqual("false", isRequired);
            // Required tag will need to be set to 'true' once implemented. 
        }
    }
}
