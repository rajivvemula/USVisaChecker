using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using Microsoft.Azure.Cosmos;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.Policy
{
    [Binding]
    public class P001_PolicyNavigationSteps
    {
        private IWebDriver driver;
        Buttons buttons;
        Cosmos cosmos;

        public P001_PolicyNavigationSteps(IWebDriver driver, CosmosClient cosmosClient)
        {
            this.driver = driver;
            buttons = new Buttons(driver);
            cosmos = new Cosmos(cosmosClient);
        }

        [When(@"User navigates to policy ID (.*)")]
        public void WhenUserNavigatesToPolicyID(string id)
        {
            //todo: modify it to where if no ID is provided, the it grabs the last id in policy 
            string policyID = id;
            if (id == "recent")
            {
                policyID = cosmos.GetLatestPolicyID().ToString();
            }
            driver.Navigate().GoToUrl("https://biberk-apollo-qa2.azurewebsites.net/policy/" + policyID);
        }
    }
}
