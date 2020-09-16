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
    public class C005_AddADriverToOrganizationSteps
    {
        private IWebDriver driver;
        Random rnd;
        State state;
        Components components;
        Toaster toaster;
        OrganizationDriver organizationDriver;
        AddDriver addDriver;
        Buttons button;
        

        public C005_AddADriverToOrganizationSteps(IWebDriver driver, State state)
        {
            this.driver = driver;
            this.state = state;
            rnd = new Random();
            components = new Components(driver);
            toaster = new Toaster(driver);
            organizationDriver = new OrganizationDriver(driver);
            addDriver = new AddDriver(driver);
            button = new Buttons(driver);
        }

        [When(@"User adds driver to Organization")]
        public void WhenUserAddsDriverToOrganization(Table table)
        {
            //Navigate to Driver Tab
            organizationDriver.driverTab.Click();
            if (components.CheckIfDialogPresent())
            {
                button.alertContinueAnyway.Click();
            }
            Assert.That(() => driver.Url, Does.Contain("driver").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Driver Tab");

            // Add Driver Button
            organizationDriver.addDriverButton.Click();
            Assert.That(() => components.GetDialogTitle(), Is.EqualTo("Add Driver").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add Driver Button/Open Add Driver Dialog");

            var details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                //generate random number for license plate
                string licenseRND = rnd.Next(100, 900).ToString();
                string licenseNumber = detail.State + "15" + licenseRND;

                components.EnterInput(addDriver.inputFirst, detail.First);
                components.EnterInput(addDriver.inputLast, detail.Last);
                components.EnterInput(addDriver.inputMiddle, detail.Middle);
                components.EnterInput(addDriver.inputBirth, detail.DOB.ToString());
                components.EnterSelect(addDriver.selectLicenseState, detail.State);
                components.EnterInput(addDriver.inputLicenseNumber, licenseNumber);
                components.EnterInput(addDriver.inputLicenseExp, detail.Exp.ToString());
                components.EnterSelect(addDriver.selectCDL, detail.CDL);
                state.recentDriverLicenseNumber = licenseNumber;
            }

            //Driver Save
            addDriver.submitButton.Click();

        }
        
        [Then(@"Verify driver is added to Organization")]
        public void ThenVerifyDriverIsAddedToOrganization()
        {
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Driver saved"), "Driver was not saved");
            bool verifyAdd = organizationDriver.CheckLicenseNumber(state.recentDriverLicenseNumber);
            Assert.IsTrue(verifyAdd, "Driver was not added to the organization");
        }
    }
}
