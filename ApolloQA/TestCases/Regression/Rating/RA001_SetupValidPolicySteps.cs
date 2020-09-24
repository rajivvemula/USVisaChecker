using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using ApolloQA.Helpers;
using System.Collections.Generic;
using System.Text.Json;
using Entity = ApolloQA.DataFiles.Entity;
using ApolloQA.DataFiles;

namespace ApolloQA.TestCases.Regression.Rating
{
    [Binding]
    public class RA001_SetupValidPolicySteps
    {
        private IWebDriver driver;
        private Entity.Policy policy;

        RestAPI api;
        public RA001_SetupValidPolicySteps(IWebDriver driver, RestAPI api, State state)
        {
            this.driver = driver;
            this.api = api;
            //this.policy = new Entity.Policy(int.Parse(state.PolicyId));
        }

        [When(@"User Navigates to Policy")]
        public void WhenUserNavigatesToPolicy()
        {
            Console.WriteLine("Navigate");
        }
        
        [Then(@"The policy should load successfully")]
        public void ThenThePolicyShouldLoadSuccessfully()
        {
            this.policy = new Entity.Policy(10564);



            Console.WriteLine($"coverage 1: {this.policy.getCoverageCodes()[0]}");
            Console.WriteLine($"coverage 2: {this.policy.getCoverageCodes()[1]}");

            int scheduleTypeID = policy.getProperties()["billing"]["scheduleTypeId"];

            String scheduleTypeStr = policy.getProperties()["billing"]["scheduleTypeId"];

            Console.WriteLine($"{scheduleTypeID} {scheduleTypeStr}");
        }
        
        [Then(@"The policy should have Driver")]
        public void ThenThePolicyShouldHaveDiver()
        {
            Console.WriteLine("driver");
            //Console.WriteLine(this.policy["applicationId"]);
        }

        [Then(@"The policy should have Vehicle")]
        public void ThenThePolicyShouldHaveVehicle()
        {
            
            Console.WriteLine("Vehicle");

            Entity.Vehicle vehicle = new Entity.Vehicle(10054);
            vehicle.setProperties(("YearOfManufacture", 2010));
            Console.WriteLine(" ");

            foreach (var column in vehicle.getProperties())
            {
                Console.Write($"{column.Key}:{column.Value}, ");

            }
            Console.WriteLine(" ");

        }

        [Then(@"The policy should have Coverage")]
        public void ThenThePolicyShouldHaveCoverage()
        {
            Console.WriteLine("Coverage");
        }
    }
}
