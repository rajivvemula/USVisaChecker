using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using Microsoft.Azure.Cosmos;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using ApolloQA.DataFiles;
using ApolloQA.Pages.Policy;
namespace ApolloQA.TestCases.Regression.Policy
{
    [Binding]
    public class P001_PolicyNavigationSteps
    {
        private IWebDriver driver;
        Buttons buttons;
        Cosmos cosmos;
        State state;
        PolicyMain policyMain;
        public P001_PolicyNavigationSteps(IWebDriver driver, CosmosClient cosmosClient, State state)
        {
            this.driver = driver;
            buttons = new Buttons(driver);
            cosmos = new Cosmos(cosmosClient);
            this.state = state;
            this.policyMain  = new PolicyMain(driver);

        }

        [When(@"User navigates to policy ID (.*)")]
        public void WhenUserNavigatesToPolicyID(string id)
        {
            //todo: modify it to where if no ID is provided, the it grabs the last id in policy 
            int policyID = int.Parse(id);
            if (id == "recent")
            {
                policyID = cosmos.GetLatestPolicyID().Result;
            }
            this.state.currentPolicy = new DataFiles.Entity.Policy(policyID);
            this.state.engine = new Engine(state.currentPolicy);

            policyMain.NavigateToPolicy(policyID);
        }

        [When(@"User navigates to Policy Summary Section")]
        public void WhenUserNavigatesToPolicySummarySection()
        {
            policyMain.GoToSummary();
        }

        [When(@"User navigates to the Policy Rating Worksheet")]
        public void WhenUserNavigatesToThePolicyRatingWorksheet()
        {
            new PolicySummary(driver).NavigateToRatingWorksheet();
        }


    }
}
