using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Data.Entity;
using System.Collections.Generic;
using TechTalk.SpecFlow.Assist;
using ApolloQA.Source.Helpers;
using System.Linq;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public class SharedSteps
    {
        [When(@"user clicks '(.*)' Button")]
        public void WhenUserClicksButton(string buttonName)
        {
            var button = Shared.GetButton(buttonName);
            if(!button.TryClick())
            {
                while (Shared.toastrMessage.assertElementIsPresent(3, true) == true)
                {
                    Shared.toastrMessage.assertElementNotPresent();
                }


                button.Click();
            }
           

        }

        [When(@"user clicks (.*) Dropdown")]
        public void WhenUserClicksOnPhysicalAddressDropdown(string DropdownDisplayName)
        {
            Shared.GetDropdownField("Physical Address").Click();
        }
        [When(@"user selects dropdown (.*) option equaling (.*)")]
        public void WhenUserSelectsDropdownOption(string DropdownDisplayText, string OptionDisplayText)
        {
            Shared.GetDropdownField(DropdownDisplayText).SelectMatDropdownOptionByText(OptionDisplayText);
        }
        [When(@"user selects dropdown (.*) option containing (.*)")]
        public void WhenUserSelectsDropdownOptionContaining(string DropdownDisplayText, string OptionDisplayText)
        {
            Shared.GetDropdownField(DropdownDisplayText).SelectMatDropdownOptionContainingText(OptionDisplayText);
        }

        [When(@"user selects dropdown (.*) option at index (.*)")]
        public void WhenUserSelectsDropdownOptionAtIndex(string DropdownDisplayText, int index)
        {
            Shared.GetDropdownField(DropdownDisplayText).SelectMatDropdownOptionByIndex(index);
        }

        [When(@"user waits '(.*)' seconds")]
        public void WhenUserWaitsSeconds(string seconds)
        {
            System.Threading.Thread.Sleep(int.Parse(seconds) * 1000);
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
                        fieldValues["State / Region"],
                        fieldValues["Zip / Postal Code"]
                        );            
        }

        [When(@"user saves the address")]
        public void WhenUserSavesTheAddress()
        {
            Shared.GetButton("Save").Click();
            WhenUserWaitsForSpinnerToLoad();
            Shared.SuggestedAddressCTA.Click(optional: true);
            Shared.GetButton("Use selected").Click(3, true);
        }

        [When(@"user clicks '(.*)' icon Button")]
        public void WhenUserClicksIconButton(string iconButton)
        {
            Shared.GetIconButton(iconButton).Click();
        }


        [When(@"user clicks '(.*)' right menu Button")]
        public void WhenUserClicksRightMenuButton(string rightMenuButton)
        {
            Shared.GetRightSideTab(rightMenuButton).Click();
        }

        [Then(@"user asserts for error - '(.*)'")]
        public void ThenUserAssertsForError_(string ErrorText)
        {
            Shared.GetError(ErrorText);
        }

        [When(@"user enters (.*) into (.*) field")]
        public void WhenUserEnterIntoField(string username, string fieldName)
        {
            Shared.GetField(fieldName, "input").setText(username);
        }

        [When(@"user waits for spinner to load")]
        public void WhenUserWaitsForSpinnerToLoad()
        {
            Shared.SpinnerLoad.assertElementIsVisible(2, true);
            Shared.SpinnerLoad.assertElementNotPresent();
        }


        [When(@"user waits for spinner to dissappear for (.*) seconds")]
        public void WhenUserWaitsForSpinnerToDissappearForSeconds(int waitTime)
        {
            Shared.SpinnerLoad.assertElementIsVisible(2, true);
            Shared.SpinnerLoad.assertElementNotPresent(waitTime);
        }


        [When(@"user clicks '(.*)' Sidetab")]
        public void WhenUserClicksSidetab(string sidetab)
        {
            Shared.GetLeftSideTab(sidetab).Click();
            Shared.GetButton("Continue anyway").TryClick(1);
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
        [Then(@"Toast containing (.*) is visible")]
        public void ThenToastContainingIsVisible(string message)
        {
            Shared.GetToastContaining(message).assertElementIsVisible();
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

        [When(@"user selects answer to (.*) as (.*)")]
        public void WhenUserSelectsAnswerToAs(string QuestionDisplayText, string AnswerDisplayText)
        {
            Shared.GetQuestionAnswer(QuestionDisplayText, AnswerDisplayText).Click();
        }

        [When(@"user enters answer to (.*) as (.*)")]
        public void WhenUserEntersAnswerToAs(string QuestionDisplayText, string AnswerText)
        {
            Shared.GetQuestionTextField(QuestionDisplayText).setText(AnswerText);
        }


        [When(@"user selects (.*) coverage with (.*) deductible of (.*)")]
        public void WhenUserSelectsCoverageWithDeductibleOf(string CoverageDisplayText, string DeductibleTypeDisplayText, string DeductilbeAmountDisplayText)
        {
            Shared.GetCoverageCheckbox(CoverageDisplayText).Click();
            Shared.GetCoverageLimitButton(CoverageDisplayText, DeductibleTypeDisplayText).Click();
            Shared.GetCoverageLimitDropdown(CoverageDisplayText, DeductibleTypeDisplayText).SelectMatDropdownOptionByText(DeductilbeAmountDisplayText);
            new SharedSteps().WhenUserWaitsForSpinnerToLoad();
        }

        [When(@"user enters (.*) and selects option equaling (.*) into (.*)")]
        public void WhenUserEntersAndSelectsOptionEqualingInto(string typeAheadText, string OptionDisplayText, string FieldDisplayText)
        {
            var inputField = Shared.GetInputField(FieldDisplayText);
            inputField.setText(typeAheadText);
            inputField.SelectMatDropdownOptionByText(OptionDisplayText);
        }

        [Then(@"mark Test Case as (.*) passed")]
        public void markTestCaseaspassed(string testCaseId)
        {
            Functions.MarkTestCasePassed(int.Parse(testCaseId));
        }

        [Then(@"mark Test Case as (.*) failed")]
        public void markTestCaseasfailed(string testCaseId)
        {
            Functions.MarkTestCaseFailed(int.Parse(testCaseId));
        }

        [Given(@"user navigates to Administration (.*)")]
        public void GivenUserNavigatesToAdministration(string tabName)
        {
            WhenUserClicksIconButton(" apps ");
            WhenUserClicksRightMenuButton("Administration");
            Shared.GetHeaderButton("Billing").Click();
        }

        [Then(@"table should have entries")]
        public void ThenTableShouldContainEntries()
        {
            Assert.IsTrue(Shared.Table.parseUITable().Count() > 1);

        }
    }
}
