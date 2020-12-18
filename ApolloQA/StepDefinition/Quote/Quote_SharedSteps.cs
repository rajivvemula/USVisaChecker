using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using System.Linq;
using EntityQuote = ApolloQA.Data.Entity.Quote;


namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_SharedSteps
    {
        public static EntityQuote Quote;

        [When(@"User Navigates to Quote (.*)")]
        public void GivenUserNavigatesToQuote(string quote)
        {
            if (quote?.ToLower() == "recent" || quote?.ToLower() == "latest")
            {
                Quote = EntityQuote.GetLatestQuote();
            }
            else
            {
                Quote = new EntityQuote(int.Parse(quote));
            }
            Quote_Page.Navigate(Quote.Id);
        }
    }
}
