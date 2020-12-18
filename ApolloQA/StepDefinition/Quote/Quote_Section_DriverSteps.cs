using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class QuoteSectionDriverSteps
    {

        [When(@"user select a Driver with the following relevant values")]
        public void WhenUserSelectADriverWithTheFollowingRelevantValues()
        {
            Shared.GetDropdownField("Select Driver").SelectMatDropdownOptionByIndex(0);
        }

        [When(@"user select a Driver with the following relevant values")]
        public void WhenUserSelectADriverWithTheFollowingRelevantValues(Table table)
        {
            new NotImplementedException("Selecting a driver with defined values not yet implemented");   
        }

        



    }
}
