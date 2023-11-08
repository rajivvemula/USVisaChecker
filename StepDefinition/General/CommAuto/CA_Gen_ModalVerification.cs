using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Helpers;
using System;
using TechTalk.SpecFlow;
using HitachiQA.Driver;
using HitachiQA;
using System.Collections.Generic;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_ModalVerification
    {
        private readonly CASummaryObject _caSummaryObject;
        
        public CA_Gen_ModalVerification(CASummaryObject caSummaryObject)
        {
            _caSummaryObject = caSummaryObject;
        }

        [Then(@"user verifies the Save for Later Modal")]
        public void ThenUserVerifiesAppearanceOfTheContactsPage()
        {
            //Verify it is on the page and click to open it
            SaveForLater_Modal.SflNeedToFinishLater.AssertElementIsVisible();
            SaveForLater_Modal.SflSaveBTN.AssertElementIsVisible();
            SaveForLater_Modal.SflSaveBTN.Click();

            //pull the quoteid from this and compare it to what was on the Start Your Quote page
            SaveForLater_Modal.SflSubTitle.AssertElementContainsText(_caSummaryObject.QuoteID);

            //Close the modal without putting information in and reopen
            SaveForLater_Modal.SfLSeeYouLaterHelperX.Click();
            SaveForLater_Modal.SflSaveBTN.Click();

            //Verify appearance, fill out modal, submit modal
            SaveForLater_Modal.SfLSeeYouLater.AssertElementIsVisible();
            SaveForLater_Modal.SfLSeeYouLaterSubtitle.AssertElementIsVisible();
            SaveForLater_Modal.SfLSeeYouLaterTxtbox.AssertElementIsVisible();
            SaveForLater_Modal.SfLSeeYouLaterTxtbox.SetText(Functions.GetRandomStringWithRestrictions(7, "alphaNumeric") + "@yopmail.com");
            SaveForLater_Modal.SfLSeeYouLaterTxtbox.ArrowDownEnter();
            SaveForLater_Modal.SfLGetMyLinkCTA.Click();

            //Success toast should appear and then disappear
            SaveForLater_Modal.SfLSuccessToast.AssertElementIsVisible();
            SaveForLater_Modal.SfLSuccessToast.AssertElementNotPresent();
        }

        [When(@"user enters the following email address into the CA save quote for later modal: (.*)")]
        public void WhenUserEntersAnInvalidEmailAddressIntoTheSaveQuoteForLaterModal(string email)
        {
            SaveForLater_Modal.SflSaveBTN.Click();
            SaveForLater_Modal.SflEmailTxtbox.SetText("a");
            SaveForLater_Modal.SfLSeeYouLater.Click();
        }

        [Then(@"user verifies Save Your Progresss is pre-populated with info entered by the user")]
        public void ThenUserVerifiesSaveYourProgresssIsPre_PopulatedWithInfoEnteredByTheUser()
        {
            SaveForLater_Modal.SflSaveBTN.Click();
            AutomationHelper.ValidateElements(new List<Element>
            {
                SaveForLater_Modal.SflHeader,
                SaveForLater_Modal.SfLSeeYouLaterSubtitle,
                SaveForLater_Modal.VerifyPrePopulatedEmail(_caSummaryObject.BusinessEmail),
                SaveForLater_Modal.SfLMatHint,
                SaveForLater_Modal.SfLGetMyLinkCTA
            });
            SaveForLater_Modal.SfLSeeYouLaterHelperX.Click();
        }

        [Then(@"user verifies that the save for later modal appears after attempting to navigate away")]
        public void ThenUserVerifiesThatTheSaveForLaterModalAppearsAfterAttemptingToNavigateAway()
        {
            UserActions.Navigate("get-a-quote");

            try
            {
                UserActions.GetBrowserAlert().Dismiss();
            }
            catch (Exception)
            {
                Log.Error("The alert did not appear when the user attempted to navigate away from the CA path");
                throw;
            }

            CA_SaveForLaterModal.SaveYourProgressTitle.AssertElementIsVisible();
            CA_SaveForLaterModal.SaveYourProgressCloseButton.AssertElementIsVisible();
            CA_SaveForLaterModal.SaveYourProgressCloseButton.Click();
        }

        [Then(@"user verifies the (.*) save for later modal appears")]
        public void ThenUserVerifiesTheRegularSaveForLaterModalAppears(string ModalType)
        {
            AutomationHelper.WaitForLoading();
            SaveForLater_Modal.SflSaveBTN.Click();
            if (ModalType == "regular")
            {
                AutomationHelper.ValidateElements(SaveForLater_Modal.SFLModalElements);
            }
            else if (ModalType == "slim")
            {
                AutomationHelper.ValidateElements(SaveForLater_Modal.SfLSlimModalElements);
            }
            else
            {
                throw new Exception();
            }
            SaveForLater_Modal.SfLSeeYouLaterHelperX.Click();
        }

        [Then(@"user verifies the removal modal for (.*) with answer of (.*)")]
        public void ThenUserVerifiesTheRemovalModalForWithAnswerOf(string subject, string answer)
        {
            AutomationHelper.ValidateElements(RemovalDialog_Modal.ListOfElements(subject));

            switch (answer)
            {
                case "Yes, remove the vehicle":
                    RemovalDialog_Modal.YesButton.Click();
                    break;
                case "No, go back":
                    RemovalDialog_Modal.NoButton.Click();
                    break;
            }
        }
    }
}
