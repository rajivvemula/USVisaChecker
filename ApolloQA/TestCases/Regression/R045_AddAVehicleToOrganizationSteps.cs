using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R045_AddAVehicleToOrganizationSteps
    {

        private IWebDriver driver;
        Toaster toaster;
        OrganizationVehicle organizationVehicle;

        public R045_AddAVehicleToOrganizationSteps(IWebDriver Driver)
        {
            driver = Driver;
            
            toaster = new Toaster(Driver);
            organizationVehicle = new OrganizationVehicle(Driver);

        }

        [When(@"User clicks Vehicles Tab In Organization")]
        public void WhenUserClicksVehiclesTabInOrganization()
        {
            Thread.Sleep(5000);
            organizationVehicle.VehicleTab.Click();
        }
        
        [When(@"User clicks Add Vehicle in Organization")]
        public void WhenUserClicksAddVehicleInOrganization()
        {
            organizationVehicle.addDriverButton.Click();
        }
    }
}
