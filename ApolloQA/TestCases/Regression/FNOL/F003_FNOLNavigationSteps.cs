using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using ApolloQA.Pages.Fnol;
using ApolloQA.Pages.Shared;
using Microsoft.Azure.Cosmos;
using NUnit.Framework;
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

                driver.Navigate().GoToUrl(Defaults.HOST + "/claims/fnol/" + claimID + "/occurence");
            }
            
        }

        [When(@"User navigates to FNOl Insert Via Navbar")]
        public void WhenUserNavigatesToFNOlInsertViaNavbar()
        {
            mainNavBar.HomeIcon.Click();
            Assert.That(() => driver.Title, Does.Contain("Home").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Home");
            mainNavBar.AddIcon.Click();
            mainNavBar.addFnolButton.Click();
            Assert.That(() => driver.Title, Does.Contain("Insert First Notice of Loss").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add New FNOl Button In Navbar/Navigate to FNOL Insert");
        }

    }
}
