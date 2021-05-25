using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using Entity_Quote = ApolloQA.Data.Entity.Quote;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class CreateQuoteSteps
    {
        public static Entity_Quote Quote;
        public Data.Entity.Organization _newOrg;
        [When(@"User create a new Org with (.*)")]
        public void WhenUserCreateANewOrgWith(string state)
        {
            _newOrg = Functions.CreateNewOrganization();
            //_newOrg.OrganizationAddAddress(state);
            Functions.AddAddressToOrganization(_newOrg, state);
            

        }
        
        [When(@"User enters quote details on Quote Page")]
        public void WhenUserEntersQuoteDetailsOnQuotePage()
        {

            var inputField = Shared.GetInputField("Named Insured");
            inputField.setText(_newOrg.Name);
            inputField.SelectMatDropdownOptionByText(_newOrg.Name);
            Shared.GetDropdownField("Organization Type").SelectMatDropdownOptionByText("Corporation");
            Shared.GetDropdownField("Tax ID Type").SelectMatDropdownOptionByText("FEIN");
            string feinRandom = Functions.GetRandomInteger(1000000).ToString();
            string feinNew = "1225" + feinRandom;
            Shared.GetField("Tax ID No", "input").setText(feinNew);

            Shared.GetField("Business Email Address", "input").setText("automate@biberk.com");
            Shared.GetField("Business Phone No", "input").setText("231-790-0000");
            Shared.GetField("Business Website", "input").setText("automate@biberk.com");
            Shared.GetField("Year Business Started", "input").setText("2011");
            Shared.GetField("Year Ownership Started", "input").setText("2012");
            Shared.GetDropdownField("Physical Address").SelectMatDropdownOptionByIndex(0);
        }
        
        [Then(@"User verifies quote details on Business Information Page")]
        public void ThenUserVerifiesQuoteDetailsOnBusinessInformationPage()
        {
            Shared.GetField("Named Insured", "input").assertElementTextEquals(_newOrg.Name);
            Shared.GetDropdownField("Tax ID Type").assertElementTextEquals("FEIN");
            Shared.GetField("Tax ID No", "input").assertElementTextEquals("12-31232");

            Shared.GetField("Business Email Address", "input").assertElementTextEquals("automate@biberk.com");
            Shared.GetField("Business Phone No", "input").assertElementTextEquals("231-790-0000");
            Shared.GetField("Business Website", "input").assertElementTextEquals("automate@biberk.com");
            Shared.GetField("Year Business Started", "input").assertElementTextEquals("2011");
            Shared.GetField("Year Ownership Started", "input").assertElementTextEquals("2012");
        }

        [Then(@"User checks Governing (.*) are correctly matching")]
        public void ThenUserChecksGoverningAreCorrectlyMatching(string state)
        {
            //Get quote ID from URL
            //UserActions.GetCurrentURL();
            string quoteURL = UserActions.GetCurrentURL();
            //int urlLength = quoteURL.Length;
            
            string quoteID = quoteURL.Substring(quoteURL.IndexOf("quote/") + 6, 5 );
            int parsedURL = int.Parse(quoteID);


            var quote = new Data.Entity.Quote(parsedURL);
            if (quote.GoverningStateCode == state)
            {
                return;
            }
            throw Functions.handleFailure("governing state incorrect");
        }
    }
}
