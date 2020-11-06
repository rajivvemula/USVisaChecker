using ApolloQA.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Impersonation
{
    [Binding]
    public sealed class apolloOrganizationAddSteps
    {
        public IWebDriver driver;


        apolloOrganizationAddSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [When(@"user enters (.*) username into (.*) field")]
        public void WhenUserEnterUsernameIntoField(string username, string fieldName)
        {
            Shared.GetField(fieldName, "input").setText(username);
        }

    }
}
