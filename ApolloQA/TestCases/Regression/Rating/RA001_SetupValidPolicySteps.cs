using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using ApolloQA.Helpers;
using System.Collections.Generic;
using System.Text.Json;

namespace ApolloQA.TestCases.Regression.Rating
{
    [Binding]
    public class RA001_SetupValidPolicySteps
    {
        private IWebDriver driver;
        private JsonElement policy;
        private RestAPI api;

        public RA001_SetupValidPolicySteps(IWebDriver driver)
        {
            this.driver = driver;
            this.api = new RestAPI(driver);

        }

        [When(@"User Navigates to Policy")]
        public void WhenUserNavigatesToPolicy()
        {
            Console.WriteLine("Navigate");
        }
        
        [Then(@"The policy should load successfully")]
        public void ThenThePolicyShouldLoadSuccessfully()
        {
            this.policy = (JsonElement)api.GET("/policy/19799");

        }
        
        [Then(@"The policy should have Driver")]
        public void ThenThePolicyShouldHaveDiver()
        {
            Console.WriteLine("driver");
            Console.WriteLine(this.policy.GetProperty("applicationId").ToString());
        }
        
        [Then(@"The policy should have Vehicle")]
        public void ThenThePolicyShouldHaveVehicle()
        {
            Console.WriteLine("Vehicle");
        }

        [Then(@"The policy should have Coverage")]
        public void ThenThePolicyShouldHaveCoverage()
        {
            Console.WriteLine("Coverage");
        }
    }
}
