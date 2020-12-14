using ApolloQA.Pages;
using ApolloQA.Pages.Quote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_VehiclesSteps
    {
        [When(@"user selects (.*) Button")]
        public void WhenUserSelectsButton(string button)
        {
            // TODO : Temporary fix until scroll to Element is working again.
            for (var i = 0; i < 5; i++)
            {
                switch (button.ToLower())
                {
                    case "owned":
                        Quote_Vehicles_Page.OwnedButton.Click();
                        break;
                    case "financed":
                        Quote_Vehicles_Page.FinancedButton.Click();
                        break;
                    case "leased":
                        Quote_Vehicles_Page.LeasedButton.Click();
                        break;
                    default:
                        throw new Exception($"Button option {button} not found");
                }
            }
        }

        [When(@"user verifies owner input is visible")]
        public void WhenUserVerifiesOwnerInputIsVisible()
        {
            Quote_Vehicles_Page.NameOfOwnerFirstInput.assertElementIsVisible();
            Quote_Vehicles_Page.NameOfOwnerSecondInput.assertElementIsVisible();
            Quote_Vehicles_Page.NameOfOwnerFirstInput.setText("Test Owner 1");
            Quote_Vehicles_Page.NameOfOwnerSecondInput.setText("Test Owner 2");
        }

        [When(@"user enters (.*) info")]
        public void WhenUserEntersInfo(string info)
        {
            switch (info.ToLower())
            {
                case "lienholder":
                    Quote_Vehicles_Page.NameOfLienholderInput.setText("Test Name of Lienholder");
                    break;
                case "lessor":
                    Quote_Vehicles_Page.NameOfLessorInput.setText("Test Name of Lessor");
                    break;
                default:
                   throw new Exception($"Ownership type {info} not found.");
            }
        }


        [Then(@"user adds Address")]
        public void ThenUserAddsAddress()
        {
            Quote_Vehicles_Page.AddAddressButton.Click();
            Quote_Vehicles_Page.AddressTypeDropdown.SelectMatDropdownOptionByText(" Location ");
            Quote_Vehicles_Page.StreetAddressOneInput.setText("14662 La Grange Road");
            Quote_Vehicles_Page.StreetAddressTwoInput.setText("Unit B-1");
            Quote_Vehicles_Page.CityInput.setText("Orland Park");
            Quote_Vehicles_Page.StateDropdown.SelectMatDropdownOptionByText(" IL ");
            Quote_Vehicles_Page.ZipInput.setText("60462");
            Quote_Vehicles_Page.CountryDropdown.SelectMatDropdownOptionByText(" United States ");
        }
    }
}
