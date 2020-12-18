using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class QuoteSectionVehicleSteps
    {
        [When(@"user selects a Vehicle with the following relevant values")]
        public void WhenUserSelectsAVehicleWithTheFollowingRelevantValues()
        {
            Shared.GetDropdownField("Select Vehicle").SelectMatDropdownOptionByIndex(1);   
        }

        [When(@"user selects a Vehicle with the following relevant values")]
        public void WhenUserSelectsAVehicleWithTheFollowingRelevantValues(Table table)
        {
            new NotImplementedException("Selecting a driver with defined values not yet implemented");    
        }

    }
}
