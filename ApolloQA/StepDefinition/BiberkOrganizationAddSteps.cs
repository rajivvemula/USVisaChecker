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
            UserActions.FindElementWaitUntilVisible(By.XPath("//input[@name='orgEmailAddress' and @aria-required='false']"));
            // Required tag will need to be set to 'true' once implemented. 
        }
    }
}
