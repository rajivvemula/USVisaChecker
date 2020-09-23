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
    public class C004_AddAnAddressToOrganizationSteps
    {
        private IWebDriver driver;
        Random rnd;
        State state;
        Components components;
        Toaster toaster;
        OrganizationAddress organizationAddress;
        AddAddress addAddress;

        string createdAdd;

        public C004_AddAnAddressToOrganizationSteps(IWebDriver driver, State state)
        {
            this.driver = driver;
            this.state = state;
            rnd = new Random();
            components = new Components(driver);
            toaster = new Toaster(driver);
            organizationAddress = new OrganizationAddress(driver);
            addAddress = new AddAddress(driver);
        }
        

        [When(@"User adds address to Organization")]
        public void WhenUserAddsAddressToOrganization(Table table)
        {
            organizationAddress.addressTab.Click();
            Assert.That(() => driver.Url, Does.Contain("address").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Address Tab");

            //Click Add Address Button
            organizationAddress.addAddressButton.Click();
            Assert.That(() => components.GetDialogTitle(), Is.EqualTo("Add New Address").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add Address Button/Open Add Adress Dialog");

            var details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                components.EnterInput(addAddress.inputAddressLine1, detail.Line1);
                components.EnterInput(addAddress.inputCity, detail.City);
                components.EnterInput(addAddress.inputZipCode, detail.Zip.ToString());
                components.EnterSelect(addAddress.selectState, detail.State);
                createdAdd = detail.Line1;
            }
            addAddress.saveButton.Click();
            //Select Default Address
            //addAddress.defaultAddressInfo.Click();
            //addAddress.useSelectedButton.Click();

        }
        
        [Then(@"Verify address is added to Organization")]
        public void ThenVerifyAddressIsAddedToOrganization()
        {

            bool verifyAdd = organizationAddress.CheckAddress(createdAdd);
            Assert.IsTrue(verifyAdd, "Address was not added to the organization");
        }
    }
}
