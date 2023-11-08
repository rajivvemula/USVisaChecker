using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using HitachiQA.Helpers;
using HitachiQA;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_ContactDetails
    {
        private CAContactDetailsAutomation _automation;

        public CA_Gen_ContactDetails(CAContactDetailsAutomationFactory factory)
        {
            _automation = factory.CreateAutomation();
        }

        [Then(@"user verifies appearance of the contacts page")]
        public void ThenUserVerifiesAppearanceOfTheContactsPage()
        {
            AutomationHelper.WaitForLoading();
            CA_ContactDetailsPage.LoadingRequirements.Assert();
        }

        [Then(@"user verifies whether the Owner's name is prefilled")]
        public void ThenUserVerifiesWhetherTheOwnersNameIsPrefilled()
        {
            _automation.VerifyPrefilledOwnerName();
        }
        
        [Then(@"user checks the stepper appearance on the Contact Details page")]
        public void ThenUserChecksStepperContactDetailsPage()
        {
            _automation.ValidateStepper();
        }

        [Then(@"user enters contact information:")]
        public void ThenUserEntersContactInformation(Table table)
        {
            //Pulls the data from the table in the feature file
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                //If an answer is empty/null, skips over the question to the next one.
                if (!string.IsNullOrEmpty(theAnswer))
                {  
                    HandleTableValue(theQuestion, theAnswer);
                }
            }
            _automation.ClickContinue();
        }

        [Then(@"user verifies the owner's address prefilled")]
        public void ThenUserVerifiesTheOwnersAddressPrefilled()
        {
            var uiAddress = new Address()
            {
                Line1 = CA_ContactDetailsPage.OwnersHomeAddressTxtbox.GetTextFieldValue(),
                Line2 = CA_ContactDetailsPage.OwnersHomeAddressApptTxtbox.GetTextFieldValue(),
                City = CA_ContactDetailsPage.OwnersCityTxtbox.GetTextFieldValue(),
                State = State.FromName(CA_ContactDetailsPage.OwnersStateDD.GetAttribute("innerText")),
                ZipCode = CA_ContactDetailsPage.OwnersZipTxtbox.GetTextFieldValue()
            };

            _automation.VerifyAddress(uiAddress);
        }

        public void HandleTableValue(string tableQuestion, string tableAnswer)
        {
            switch (tableQuestion)
            {
                case "First Name":
                    _automation.EnterContactFirstName(tableAnswer);
                    break;
                case "Last Name":
                    _automation.EnterContactLastName(tableAnswer);
                    break;
                case "Business Email":
                    _automation.EnterBusinessEmail(tableAnswer);
                    break;
                case "Business Phone":  //(###) ###-####
                    _automation.EnterBusinessPhone(tableAnswer);
                    break;
                case "Business Ext":
                    _automation.EnterBusinessExt(tableAnswer);
                    break;
                case "Business Website":
                    _automation.EnterBusinessWebsite(tableAnswer);
                    break;
                case "Business has an account manager":
                    _automation.ToggleBusinessAccountManagerCheckbox(true);
                    break;
                case "Manager's First Name":
                    _automation.EnterManagerFirstName(tableAnswer);
                    break;
                case "Manager's Last Name":
                    _automation.EnterManagerLastName(tableAnswer);
                    break;
                case "Manager's Email":
                    _automation.EnterManagerEmail(tableAnswer);
                    break;
                case "Manager's Phone":
                    _automation.EnterManagerPhone(tableAnswer);
                    break;
                case "Manager's Ext":
                    _automation.EnterManagerExt(tableAnswer);
                    break;
                case "Want Save Money":
                    _automation.SelectSaveMoneyYesNo(tableAnswer);
                    break;
                case "Owner's First Name":
                    _automation.EnterOwnerFirstName(tableAnswer);
                    break;
                case "Owner's Last Name":
                    _automation.EnterOwnerLastName(tableAnswer);
                    break;
                case "Owner's Address":
                    _automation.EnterOwnerAddress(tableAnswer);
                    break;
                case "Owner's Address 2":
                    _automation.EnterOwnerAddressLine2(tableAnswer);
                    break;
                case "Owner's Zip Code":
                    _automation.EnterOwnerZipCode(tableAnswer);
                    break;
                case "Owner's City":
                    _automation.EnterOwnerCity(tableAnswer);
                    break;
                case "Owner's State": // full state name
                    _automation.SelectOwnerState(State.FromAny(tableAnswer));
                    break;
                case "Select an Address":
                    _automation.ChooseAddressPreference(tableAnswer);
                    break;
                default:
                    break;
            }
        }
    }
}