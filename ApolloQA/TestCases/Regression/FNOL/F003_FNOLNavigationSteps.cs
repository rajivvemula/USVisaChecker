using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using ApolloQA.Pages.Fnol;
using ApolloQA.Pages.Shared;
using Microsoft.Azure.Cosmos;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.FNOL
{
    [Binding]
    public class F003_FNOLNavigationSteps
    {
        private IWebDriver driver;
        Random rnd;
        State state;
        MainNavBar mainNavBar;
        FNOLInsert fnolInsert;
        Components helper;
        Toaster toaster;
        Cosmos cosmos;


        public F003_FNOLNavigationSteps(IWebDriver driver, State state, CosmosClient cosmosClient)
        {
            this.driver = driver;
            this.state = state;
            rnd = new Random();
            mainNavBar = new MainNavBar(driver);
            fnolInsert = new FNOLInsert(driver);
            helper = new Components(driver);
            toaster = new Toaster(driver);
            cosmos = new Cosmos(cosmosClient);
        }

        [When(@"User navigates to claim ID (.*)")]
        public void WhenUserNavigatesToClaimID(string id)
        {
            string claimID = id;
            if (id == "recent")
            {
                claimID = cosmos.GetLatestClaimID().ToString();
            }
            try
            {
                mainNavBar.SearchQuery(claimID);
            }
            catch (ElementClickInterceptedException)
            {

                driver.Navigate().GoToUrl("https://biberk-apollo-qa2.azurewebsites.net/claims/fnol/" + claimID + "/occurence");
            }
            
        }
    }
}
