using ApolloQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_Section_Additional_InterestSteps
    {
        [When(@"User selects Additional (.*)")]
        public void WhenUserSelectsAdditional(string AddlIntrstType)
        {
            Quote_Additional_Interests_Page.AddlInterestTypeDropdown.SelectMatDropdownOptionByText($"{AddlIntrstType}");
        }

        [When(@"User selects Party Type '(.*)'")]
        public void WhenUserSelectsPartyType(string partyType)
        {
            if (partyType == "Organization")
            {
                Quote_Additional_Interests_Page.PartyTypeOrgButton.Click();
                var org = Data.Entity.Organization.GetLatestOrganization();
                Quote_Additional_Interests_Page.OrgNameInput.setText($"{org.Name}");
                Log.Info($"OrgName: {org.Name}");
            }
            else
            {
                Quote_Additional_Interests_Page.PartyTypeIndividualButton.Click();
                Quote_Additional_Interests_Page.IndividFirstNameInput.setText("Bob");
                Quote_Additional_Interests_Page.IndividMiddleNameInput.setText("Da");
                Quote_Additional_Interests_Page.IndividLastNameInput.setText("Testa");
                Quote_Additional_Interests_Page.IndividSuffixNameInput.setText("3rd");
            }
        }

        [When(@"user completes address section")]
        public void WhenUserCompletesAddressSection()
        {
            Quote_Additional_Interests_Page.Address1Input.setText("81 n 13th st");
            Quote_Additional_Interests_Page.CityInput.setText("Prospect Park");
            Quote_Additional_Interests_Page.StateDropdown.SelectMatDropdownOptionByText("NJ");
            Quote_Additional_Interests_Page.ZipInput.setText("07508");
        }

        [When(@"user completes contact info and description")]
        public void WhenUserCompletesContactInfoAndDescription()
        {
            var OrgContact = Data.Entity.Organization.GetLatestOrganization();
            Quote_Additional_Interests_Page.PhoneInput.setText($"{OrgContact.BusinessPhoneNumber}");
            Quote_Additional_Interests_Page.EmailInput.setText($"{OrgContact.BusinessEmailAddress}");
            Quote_Additional_Interests_Page.DescriptionInput.setText("Test Additional Interest Add");
        }

        [Then(@"user verifies Additional Interest Add successful")]
        public void ThenUserVerifiesAdditionalInterestAddSuccessful()
        {
            var toastMessage = Occurrence.toastrMessage.GetInnerText();
            try
            {
                Assert.TextContains(toastMessage, "Additional Interest Saved");
            }
            catch { Assert.TextContains(toastMessage, "Error saving Additional Interest"); }
            Log.Info($"Expected: Additional Interest Saved. Result: " + toastMessage + "");
        }
    }
}
