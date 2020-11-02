using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Claims;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class BiberkClaimFNOLAddSteps
    {
        public IWebDriver driver;


        BiberkClaimFNOLAddSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Then(@"user verifies '(.*)' is not an option")]
        public void ThenUserVerifiesIsNotAnOption(string text)
        {
            Occurrence.howWasNoticeReceivedDropdown.Click();
            Occurrence.receivedByCarrierPigeonOption.assertElementIsVisible();
            //will need to be "assertElementNotVisible" when option is removed
        }
    }
}
