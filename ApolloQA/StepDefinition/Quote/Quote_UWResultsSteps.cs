using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Source.Helpers;
using ApolloQA.Source.Driver;
using Entity_Quote = ApolloQA.Data.Entity.Quote;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_UWResultsSteps
    {
        public static Entity_Quote Quote;
        public Data.Entity.Organization _newOrg;

        public static string feinRandom = Functions.GetRandomInteger(1000000).ToString();
        public string feinNew = "1225" + feinRandom;
        [Then(@"User enters '(.*)' for claims")]
        public void ThenUserEntersForClaims(int p0)
        {

            ApolloQA.Pages.Quote.Quote_Summary.Claim.setText("5");
            Shared.GetQuestionAnswer("What is the furthest any of your vehicles travel in any one direction from their home base?", "50 miles or less").Click();
            Shared.GetQuestionAnswer("Do you haul any non-owned goods for pay?", "Yes").Click();
        }
        
        [Then(@"User verifies the Quote has a declined status on UW Results")]
        public void ThenUserVerifiesTheQuoteHasADeclinedStatusOnUWResults()
        {
            string statusText = ApolloQA.Pages.Quote.Quote_Summary.ClaimStatusOnUW.GetElementText();
            Assert.TextContains(statusText, "Decline");
        }
        [When(@"User changes (.*)")]
        public void WhenUserChanges(string keywordText)
        {
            var inputField = Shared.GetInputField("Keyword");
            inputField.setText(keywordText);
            inputField.SelectMatDropdownOptionByText(keywordText);
        }
        [When(@"User create a new Org state IL")]
        public void WhenUserCreateANewOrgStateIL()
        {
            _newOrg = Functions.CreateNewOrganization();
            //_newOrg.OrganizationAddAddress(state);
            Functions.AddAddressToOrganization(_newOrg, "IL");
            var inputField = Shared.GetInputField("Named Insured");
            inputField.setText(_newOrg.Name);
            inputField.SelectMatDropdownOptionByText(_newOrg.Name);
            Shared.GetDropdownField("Organization Type").SelectMatDropdownOptionByText("Corporation");
            Shared.GetDropdownField("Tax ID Type").SelectMatDropdownOptionByText("FEIN");
            Shared.GetField("Tax ID No", "input").setText(feinNew);
            Shared.GetField("Business Email Address", "input").setText("automate@biberk.com");
            Shared.GetField("Business Phone No", "input").setText("231-790-0000");
            Shared.GetField("Business Website", "input").setText("automate@biberk.com");
            Shared.GetField("Year Business Started", "input").setText("2011");
            Shared.GetField("Year Ownership Started", "input").setText("2012");
            Shared.GetDropdownField("Physical Address").SelectMatDropdownOptionByIndex(0);

        }


    }
}
