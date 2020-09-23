using ApolloQA.Helpers;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R043_AddAnAddressToOrganizationSteps
    {

        private IWebDriver driver;
        Toaster toaster;
        AddAddress addAddress;
        OrganizationAddress organizationAddress;

        public R043_AddAnAddressToOrganizationSteps(IWebDriver Driver)
        {
            driver = Driver;
            toaster = new Toaster(Driver);
            organizationAddress = new OrganizationAddress(Driver);
            addAddress = new AddAddress(Driver);

        }

        [Given(@"User is Address Tab")]
        public void GivenUserIsAddressTab()
        {
            organizationAddress.addressTab.Click();
        }
        
        [When(@"User Clicks Add Address")]
        public void WhenUserClicksAddAddress()
        {
            organizationAddress.addAddressButton.Click();
        }
        
        [When(@"User inputs address details")]
        public void WhenUserInputsAddressDetails(Table table)
        {
            var detail = table.CreateDynamicSet();
            foreach (var details in detail)
            {
                //addAddress.EnterInput("add1", details.Address.ToString());
                //addAddress.EnterInput("city", details.City);
                //addAddress.EnterInput("zip", details.Zip.ToString());
                //addAddress.EnterSelect("state", details.State);
            }
        }

        /*
         *
         * case "add1": return inputAddressLine1;
                case "add2": return inputAddressLine2;
                case "city": return inputCity;
                case "zip": return inputZipCode;
                case "state": return selectState;
                default: return null;
         *| Address          | City         | State | Zip   |
	| 39 Public Square | Wilkes Barre | PA    | 18703 | 
         * */

        [When(@"User clicks edit on a adress in the grid")]
        public void WhenUserClicksEditOnAAdressInTheGrid()
        {
            organizationAddress.moreButton.Click();
            organizationAddress.editButton.Click();
        }
        
        [When(@"user edits Address")]
        public void WhenUserEditsAddressLine()
        {
            addAddress.inputAddressLine1.Clear();
            //addAddress.EnterInput("add1", "38 Public Sq");
        }
        
        [When(@"User saves changes")]
        public void WhenUserSavesChanges()
        {
            addAddress.saveButton.Click();
        }
        
        [Then(@"User Submits the address")]
        public void ThenUserSubmitsTheAddress()
        {
            addAddress.saveButton.Click();
            addAddress.defaultAddressInfo.Click();
            addAddress.useSelectedButton.Click();
        }
        
        [Then(@"Address is added in the grid")]
        public void ThenAddressIsAddedInTheGrid()
        {
            bool verify = organizationAddress.CheckAddress("39 Public Sq");
            Assert.IsTrue(verify);
        }
        
        [Then(@"Address model is shown with address filled")]
        public void ThenAddressModelIsShownWithAddressFilled()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"Edited addrress should appear in the grid")]
        public void ThenEditedAddrressShouldAppearInTheGrid()
        {
            bool verify = organizationAddress.CheckAddress("38 Public Sq");
            Assert.IsTrue(verify);
        }
    }
}
