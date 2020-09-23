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
        private dynamic policy;
        RestAPI api;
        public RA001_SetupValidPolicySteps(IWebDriver driver, RestAPI api)
        {
            this.driver = driver;
            this.api = api;
        }

        [When(@"User Navigates to Policy")]
        public void WhenUserNavigatesToPolicy()
        {
            Console.WriteLine("Navigate");
        }
        
        [Then(@"The policy should load successfully")]
        public void ThenThePolicyShouldLoadSuccessfully()
        {
            this.policy = this.api.GET("/policy/10564");

            var scheduleTypeID = policy["billing"]["scheduleTypeId"];

            var scheduleTypeStr = policy["billing"]["scheduleTypeId"];
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
            var some = new { Number = 3, Text = "Some text" };

            Console.WriteLine(some.Number);


            Console.WriteLine("Vehicle");
            SQL.executeQuery("select * from risk.Vehicle where VinNumber=@vin;", ("@vin", "MEDICALTESTVIM123") ).ForEach(row =>
            {
                foreach(var column in row)
                {
                    Console.Write($"{column.Key}:{column.Value},");
                }
                Console.WriteLine(" ");
            });
        }

        [Then(@"The policy should have Coverage")]
        public void ThenThePolicyShouldHaveCoverage()
        {
            Console.WriteLine("Coverage");
        }
    }
}
