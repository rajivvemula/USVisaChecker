using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R017_PolicyVehicleAddNewSteps
    {

        public IWebDriver driver;
        PolicyMain policyMain;
        AddVehicle addVehicle;
        PolicyVehicle policyVehicle;

        public R017_PolicyVehicleAddNewSteps(IWebDriver Driver)
        {
            driver = Driver;
            policyMain = new PolicyMain(Driver);
            addVehicle = new AddVehicle(Driver);
            policyVehicle = new PolicyVehicle(Driver);
        }

        [When(@"I user enter all info into add new vehicle")]
        public void WhenIUserEnterAllInfoIntoAddNewVehicle(Table table)
        {
            var detail = table.CreateDynamicSet();
            foreach(var details in detail)
            {
                addVehicle.EnterInput("VIN", details.VIN);
                Thread.Sleep(5000);
                addVehicle.EnterInput("Year", details.Year.ToString());
                addVehicle.EnterInput("Make", details.Make);
            }



        }
        
        [Then(@"vehicle with those inputs is added and confirmed via toast")]
        public void ThenVehicleWithThoseInputsIsAddedAndConfirmedViaToast()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
