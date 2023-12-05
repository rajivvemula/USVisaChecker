using System.Threading;
using ApolloQAAutomation.Pages;
using ApolloQAAutomation.Pages.Quote;
using ApolloQAAutomation.Pages.Quote.New_Quote;
using HitachiQA;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace ApolloQAAutomation.StepDefinition.Quote
{
    [Binding]
    public sealed class Quote_Gen_TableGrid
    {
        [When(@"user clicks on Quote button on the header")]
        public void WhenUserClicksOnQuoteButtonOnTheHeader()
        {
            Apollo_HomePage.HeaderQuoteBtn.Click();
        }

        [Then(@"user verifies the Quote table grid column names")]
        public void ThenUserVerifiesTheQuoteTableGridColumnNames()
        {
            AutomationHelper.ValidateElements(Quote_TableGrid.QuoteGridColumns);
        }

        [When(@"user clicks on \+New button on the Quote page")]
        public void WhenUserClicksOnNewButtonOnTheQuotePage()
        {
            Quote_TableGrid.NewQuoteBtn.Click();
        }

        [Then(@"user verifies Producer field values are more than (.*)")]
        public void ThenUserVerifiesProducerFieldValuesAreMoreThan(int noOfProducerFields)
        {
            NewQuote_BusinessInformation.NewQuoteHeader.AssertElementIsPresent();
            NewQuote_BusinessInformation.QuoteInformationHeader.AssertElementIsPresent();
            NewQuote_BusinessInformation.LineOfBusinessDD.SelectMatDropdownOptionByText("Commercial Auto");
            Thread.Sleep(1000); //Wait for a second in order to reflect the changes after selecting LOB
            NewQuote_BusinessInformation.SubLineDD.AssertMatDropdownCurrentlySelected("Commercial Auto");
            NewQuote_BusinessInformation.AgencyDD.AssertMatDropdownCurrentlySelected("biBERK");

            // Get all Producer options
            int noOfOptions = NewQuote_BusinessInformation.ProducerDD.GetCountOfMatDropdownOptions();
            Assert.IsTrue(noOfOptions > noOfProducerFields);
        }
    }
}