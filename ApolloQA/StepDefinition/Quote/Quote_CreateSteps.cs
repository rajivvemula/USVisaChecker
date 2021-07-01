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
    public class Quote_CreateSteps
    {
        public static Entity_Quote Quote;
        public Data.Entity.Organization _newOrg;

        public static string feinRandom = Functions.GetRandomInteger(1000000).ToString();
        public string feinNew = "1225" + feinRandom;

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
            Shared.GetInputField("Named Insured").assertTextFieldTextEquals(_newOrg.Name);
            Shared.GetDropdownField("Tax ID Type").assertElementTextEquals("FEIN");
            Shared.GetIconButton("visibility").Click();
            var taxIdType = Shared.GetInputField("Tax ID No").getTextFieldText();
            Assert.SoftAreEqual(taxIdType, feinNew);
            Shared.GetInputField("Business Email Address").assertTextFieldTextEquals("automate@biberk.com");
            Shared.GetInputField("Business Phone No").assertTextFieldTextEquals("231-790-0000");
            Shared.GetInputField("Business Website").assertTextFieldTextEquals("automate@biberk.com");
            Shared.GetInputField("Year Business Started").assertTextFieldTextEquals("2011");
            Shared.GetInputField("Year Ownership Started").assertTextFieldTextEquals("2012");
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
