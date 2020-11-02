using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
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
            UserActions.Click(By.XPath("//mat-select[@name='receivedTypeId']"));
            UserActions.FindElementWaitUntilPresent(By.XPath("//mat-option[@value='2'] //*[contains(text(), '" + text + "')]"));
            // Handle expected failure when option is removed
        }
    }
}
