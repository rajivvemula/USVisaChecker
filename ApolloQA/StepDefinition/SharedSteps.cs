using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Source.Helpers;
namespace ApolloQA.StepDefinition
{
    [Binding]
    public class SharedSteps
    {
        [When(@"user clicks (.*) Button")]
        public void WhenUserClicksButton(string buttonName)
        {
            Shared.GetButton(buttonName).Click();
        }

        [When(@"user clicks (.*) Dropdown")]
        public void WhenUserClicksOnPhysicalAddressDropdown(string DropdownDisplayName)
        {
            Pages.Shared.GetDropdownField("Physical Address").Click();
        }



        public static Table previouslyEnteredAddress;
        [When(@"user enters the following address")]
        public void WhenUserEntersTheFollowingAddress(Table table)
        {
           foreach(var row in table.Rows)
            {
                var fieldDisplayName = row["Field Display Name"];
                var fieldType = row["Field Type"];
                var fieldValue = row["Field Value"];

                Shared.GetField(fieldDisplayName, fieldType).setValue(fieldType, fieldValue);


            }
            previouslyEnteredAddress = table;

        }
        [When(@"user saves the address")]
        public void WhenUserSavesTheAddress()
        {
            Shared.GetButton("Save").Click();
            Shared.SuggestedAddressCTA.Click(optional: true);
            Shared.GetButton("Use selected").Click(3, true);
        }


        

    }
}
