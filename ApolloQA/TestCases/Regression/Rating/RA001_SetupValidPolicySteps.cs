using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using ApolloQA.Helpers;
using System.Collections.Generic;
using System.Text.Json;
using Entity = ApolloQA.DataFiles.Entity;
using ApolloQA.DataFiles;
using DynamicExpresso;
using Newtonsoft.Json.Linq;

namespace ApolloQA.TestCases.Regression.Rating
{
    [Binding]
    public class RA001_SetupValidPolicySteps
    {
        private IWebDriver driver;
        private Entity.Policy policy;
        State state;
        RestAPI api;
        public RA001_SetupValidPolicySteps(IWebDriver driver, RestAPI api, State state)
        {
            this.driver = driver;
            this.api = api;
            this.policy = new Entity.Policy(10000);
            this.state = state;
            Console.WriteLine("was set");

            //this.policy = new Entity.Policy(int.Parse(state.PolicyId));

        }

        [When(@"User Navigates to Policy")]
        public void WhenUserNavigatesToPolicy()
        {
            this.state.engine = new Engine(new Entity.Policy(10000), "VA00034");

        }

        [Then(@"The policy should load successfully")]
        public void ThenThePolicyShouldLoadSuccessfully()
        {
            foreach (var coverage in this.state.engine.Run())
            {
                foreach (var factor in coverage)
                {
                    Console.WriteLine($"{factor.Key} ->{factor.Value}");
                }
            }
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
            /*Entity.Vehicle vehicle = policy.GetApplication().GetVehicles()[0];
            Console.WriteLine((String)vehicle["RadiusOfOperation"]);
            vehicle.SetProperties(("YearOfManufacture", 2011));

            foreach (var column in vehicle.GetProperties())
            {
                Console.Write($"{column.Key}:{column.Value}, "); 
            }
            Console.WriteLine(" ");*/

        }

        [Then(@"The policy should have Coverage")]
        public void ThenThePolicyShouldHaveCoverage()
        {
            Console.WriteLine("Coverage");
        }
    }
}
