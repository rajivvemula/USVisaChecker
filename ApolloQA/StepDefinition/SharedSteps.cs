using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Data.Entity;
using System.Collections.Generic;
using TechTalk.SpecFlow.Assist;

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
            Shared.GetDropdownField("Physical Address").Click();
        }

        public static Address previouslyEnteredAddress;
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


            IDictionary<String, String> fieldValues = new Dictionary<String, String>();

            foreach (var row in table.Rows)
            {
                fieldValues.Add(row["Field Display Name"], row["Field Value"]);
            }

            previouslyEnteredAddress = new Address(fieldValues["Street Address Line 1"],
                        fieldValues["Street Address Line 2"],
                        fieldValues["City"],
                        fieldValues["State / Province / Region"],
                        fieldValues["Zip / Postal Code"]
                        );            
        }

        [When(@"user saves the address")]
        public void WhenUserSavesTheAddress()
        {
            Shared.GetButton("Save").Click();
            Shared.SuggestedAddressCTA.Click(optional: true);
            Shared.GetButton("Use selected").Click(3, true);
        }

        [When(@"user clicks '(.*)' icon button")]
        public void WhenUserClicksIconButton(string iconButton)
        {
            Shared.GetIconButton(iconButton).Click();
        }

        [When(@"user clicks (.*) right menu button")]
        public void WhenUserClicksRightMenuButton(string rightMenuButton)
        {
            Shared.GetRightSideTab(rightMenuButton).Click();
        }

        [Then(@"user asserts for error - '(.*)'")]
        public void ThenUserAssertsForError_(string ErrorText)
        {
            Shared.GetError(ErrorText);
        }

        [When(@"user enters '(.*)' into '(.*)' field")]
        public void WhenUserEnterIntoField(string username, string fieldName)
        {
            Shared.GetField(fieldName, "input").setText(username);
        }

        [When(@"user waits for spinner to load")]
        public void WhenUserWaitsForSpinnerToLoad()
        {
            Shared.SpinnerLoad.assertElementIsVisible(5, true);
            Shared.SpinnerLoad.assertElementNotPresent();
        }

        [When(@"user clicks (.*) Sidetab")]
        public void WhenUserClicksSidetab(string sidetab)
        {
            Shared.GetLeftSideTab(sidetab).Click();
        }

        [Then(@"Grid column label is displayed")]
        public void ThenGridColumnLabelIsDisplayed(Table table)
        {
            var details = table.CreateDynamicSet();

            foreach (var detail in details)
            {
                Shared.GetColumnTitle(detail.Value).assertElementIsVisible();
            }
        }

        [Then(@"Toast with a message: (.*) is visible")]
        public void ThenToastWithAMessageIsVisible(string toastValue)
        {
            Shared.GetToast().assertElementTextEquals(toastValue);
        }

        [Then(@"Grid contains: (.*)")]
        public void ThenGridContains(string gridValue)
        {
            Shared.GetGridValue(gridValue).assertElementIsVisible();
        }

        [Then(@"Verify sidetab is present")]
        public void ThenVerifySidetabIsPresent(Table table)
        {
            var details = table.CreateDynamicSet();

            foreach (var detail in details)
            {
                Shared.GetLeftSideTab(detail.Value).assertElementIsVisible();
            }
        }
    }
}
