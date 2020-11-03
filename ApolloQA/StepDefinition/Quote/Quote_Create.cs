using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages.Quote;
using ApolloQA.Source.Driver;
using System.Linq;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_Create
    {
        public string BusinessName = "";
        public string LineOfBusiness = "";
        public string PolicyEffectiveDate = "";
        public int quoteID;

        [When(@"user navigates to Quote Page")]
        public void WhenUserNavigatesToQuotePage()
        {
            Quote_Home.navigate();
        }
        
        [When(@"user clicks the \+ New button")]
        public void WhenUserClicksTheNewButton()
        {
            Quote_Home.NewButton.Click();
           
        }
        
        [When(@"user Selects a random Business Name")]
        public void WhenUserEntersARandomBusinessName()
        {
            Pages.Quote.Quote_Create.BusinessName.SelectMatDropdownOptionByIndex(0, out string selectionDisplayName);
            BusinessName = selectionDisplayName;
            Log.Info($"Expected: {nameof(BusinessName)}={BusinessName}");


        }

        [When(@"user Selects Line of Business as (.*)")]
        public void WhenUserSelectsLineOfBusinessAs(string LOB)
        {
            LineOfBusiness = LOB;
            Pages.Quote.Quote_Create.LineOfBusiness.SelectMatDropdownOptionByText(LOB);
        }
        
        [When(@"user Selects Policy Effective Date as (.*)")]
        public void WhenUserSelectsPolicyEffectiveDateAs(string Date)
        {
            
            if(Date == "Tomorrow")
            {
               Date= DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
            }
            PolicyEffectiveDate = Date;
            Pages.Quote.Quote_Create.PolicyEffectiveDate.setText(Date);

        }
        
        [When(@"user Clicks the Next Button")]
        public void WhenUserClicksTheNextButton()
        {
            Pages.Quote.Quote_Create.SubmitButton.Click();
        }
        
        [Then(@"A new Quote should successfully be created")]
        public void ThenANewQuoteShouldSuccessfullyBeCreated()
        {

            var toastMessage = Pages.Quote.Quote_Create.toastMessage.GetInnerText();
            Assert.TextContains(toastMessage, "created");

            this.quoteID = int.Parse(string.Join("", toastMessage.Where(Char.IsDigit)));
        }
        
        [Then(@"User should be redirected to the newly created Quote")]
        public void ThenUserShouldBeRedirectedToTheNewlyCreatedQuote()
        {

            Assert.CurrentURLEquals(Quote_Page.GetURL(quoteID));

        }

        [Then(@"Quote header should contain correct values")]
        public void ThenQuoteHeaderShouldContainCorrectValues()
        {
            Quote_Page.GetHeaderField("Quote Number").assertElementInnerTextEquals(this.quoteID.ToString());
            Quote_Page.GetHeaderField("Business Name").assertElementInnerTextEquals(this.BusinessName);
            Quote_Page.GetHeaderField("Status").assertElementInnerTextEquals("Pre-Submission");
            Quote_Page.GetHeaderField("Effective Date").assertElementInnerTextEquals(this.PolicyEffectiveDate);
            Quote_Page.GetHeaderField("Line of Business").assertElementInnerTextEquals(this.LineOfBusiness);
            Quote_Page.GetHeaderField("Carrier");
            Quote_Page.GetHeaderField("Agency");
            Quote_Page.GetHeaderField("Underwriter").assertElementInnerTextEquals("Unassigned");


            Log.Info($"Expected: {nameof(BusinessName)}={BusinessName}");
            Log.Info($"Expected: {nameof(LineOfBusiness)}={LineOfBusiness}");
            Log.Info($"Expected: {nameof(PolicyEffectiveDate)}={PolicyEffectiveDate}");
            Log.Warn("Lastly created quote page test to be implemented");
        }

    }
}
