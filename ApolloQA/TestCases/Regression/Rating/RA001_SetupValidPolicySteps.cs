using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using ApolloQA.Pages.Shared;

namespace ApolloQA.TestCases.Regression.Rating
{
    [Binding]
    public class RA001_SetupValidPolicySteps
    {
        
        private IWebDriver driver;
        State state;
        RestAPI api;

        List<JObject> ratingResult;
        RatingWorksheet ratingWorksheet;
       
        public RA001_SetupValidPolicySteps(IWebDriver driver, RestAPI api, State state)
        {
            this.driver = driver;
            this.api = api;
            this.state = state;
            ratingWorksheet = new RatingWorksheet(driver);


        }

        [When(@"the premium is calculated")]
        public void WhenThePremiumIsCalculated()
        {
            this.ratingResult = this.state.engine.Run().ToList<JObject>();
            foreach (var coverage in ratingResult)
            {
                foreach (var factor in coverage)
                {
                    Console.WriteLine($"{factor.Key} ->{factor.Value}");
                }
            }
        }
       

        [Then(@"Rating Worksheet should display the correct result")]
        public void ThenRatingWorksheetShouldDisplayTheCorrectResult()
        {


        }



    }
}
