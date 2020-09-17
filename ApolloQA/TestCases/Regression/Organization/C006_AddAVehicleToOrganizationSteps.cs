using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression.Organization
{
    [Binding]
    public class C006_AddAVehicleToOrganizationSteps
    {
        private IWebDriver driver;
        Random rnd;
        State state;
        Components components;
        Toaster toaster;
        OrganizationVehicle organizationVehicle;
        AddVehicle addVehicle;
        Buttons button;


        public C006_AddAVehicleToOrganizationSteps(IWebDriver driver, State state)
        {
            this.driver = driver;
            this.state = state;
            rnd = new Random();
            components = new Components(driver);
            toaster = new Toaster(driver);
            addVehicle = new AddVehicle(driver);
            organizationVehicle = new OrganizationVehicle(driver);
            button = new Buttons(driver);
        }

        [When(@"User adds vehicle to Organization")]
        public void WhenUserAddsVehicleToOrganization(Table table)
        {
            //Navigate to Vehicle Tab
            organizationVehicle.VehicleTab.Click();
            if (components.CheckIfDialogPresent())
            {
                components.continueAnywayButton.Click();
            }
            Assert.That(() => driver.Url, Does.Contain("vehicle").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Vehicle Tab");

            // Add Vehicle Button
            organizationVehicle.addDriverButton.Click();
            Assert.That(() => components.GetDialogTitle(), Is.EqualTo("Add vehicle for " + state.createdOrgName).After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add Vehicle Button/Open Add Vehicle Dialog");

            var details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                // Generate a random Vin
                // add if conditions
                string vinNumber;
                if (detail.VIN == "Random")
                {
                    string vinRND = rnd.Next(100, 900).ToString();
                    vinNumber = "1FAFP34N97W156" + vinRND;
                }
                else { vinNumber = detail.VIN.ToString(); };


                //Vehicle Input
                addVehicle.EnterInput("VIN", vinNumber);
                addVehicle.EnterInput("Year", detail.Year.ToString());
                addVehicle.EnterInput("Make", detail.Make);
                addVehicle.EnterInput("Model", detail.Model);
                addVehicle.EnterInput("Trim", detail.Trim);
                addVehicle.EnterSelect("Type", detail.Type);
                addVehicle.EnterSelect("Category", detail.Category);
                addVehicle.EnterSelect("SubCategory", detail.SubCategory);
                //addVehicle.EnterSelect("Code", "Airport Limousines -826");
                //addVehicle.EnterSelect("Business", "Retail Vehicle");
                addVehicle.EnterSelect("Seating", detail.Seating.ToString());
                addVehicle.EnterSelect("Gross", detail.Gross.ToString());
                addVehicle.EnterInput("Cost", detail.Cost.ToString());
                addVehicle.EnterInput("Value", detail.Value.ToString());
                addVehicle.EnterInput("Stated", detail.Stated.ToString());

            }
            // Vehicle Submit and Toast
            addVehicle.submitButton.Click();
            
        }
        
        [Then(@"Verify vehicle is added to Organization")]
        public void ThenVerifyVehicleIsAddedToOrganization()
        {
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Vehicle saved"), "Vehicle not added to organization");
        }
    }
}
