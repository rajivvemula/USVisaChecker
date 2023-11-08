using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Source.Driver;
using HitachiQA.Helpers;
using System;
using HitachiQA.Driver;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CAContactDetailsAutomation
{
    private readonly CASummaryObject _caSummaryObject;

    public CAContactDetailsAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public void ValidateStepper()
    {
        Reusable_PurchasePath.CAStepper_1Coverage_Current.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_1Coverage_Past.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_2Operations_Before.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_2Operations_Current.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_2Operations_Past.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_3AboutYou_Before.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_3AboutYou_Current.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_3AboutYou_Past.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_4Summary_Before.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_4Summary_Current.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_5Quote_Before.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_6Purchase_Before.AssertElementIsVisible();
    }

    public void EnterContactFirstName(string firstName)
    {
        CA_ContactDetailsPage.FirstNameInput.EnterResponse(firstName);
        _caSummaryObject.ContactFirstName = firstName;
    }

    public void EnterContactLastName(string lastName)
    {
        CA_ContactDetailsPage.LastNameInput.EnterResponse(lastName);
        _caSummaryObject.ContactLastName = lastName;
    }

    public void EnterBusinessEmail(string email)
    {
        CA_ContactDetailsPage.BusinessEmailInput.EnterResponse(email);
        _caSummaryObject.BusinessEmail = email;
    }

    public void EnterBusinessPhone(string phone)
    {
        
        CA_ContactDetailsPage.BusinessPhoneInput.EnterResponse(phone);
        _caSummaryObject.BusinessPhone = phone;
    }

    public void EnterBusinessExt(string phoneExt)
    {
        CA_ContactDetailsPage.BusinessPhoneExtInput.EnterResponse(phoneExt);
        _caSummaryObject.BusinessExt = phoneExt;
    }

    public void EnterBusinessWebsite(string site)
    {
        CA_ContactDetailsPage.BusinessWebsiteInput.EnterResponse(site);
        _caSummaryObject.BusinessWebsite = site;
    }

    public void ToggleBusinessAccountManagerCheckbox(bool shouldBeChecked)
    {
        CA_ContactDetailsPage.BusinessHasAccntMngInput.EnterResponse(shouldBeChecked);
        _caSummaryObject.HasAccountManager = Functions.ConvertBoolToYesNoString(shouldBeChecked);
    }

    public void EnterManagerFirstName(string firstName)
    {
        CA_ContactDetailsPage.ManagersFirstNameInput.AssertAllElements();
        CA_ContactDetailsPage.ManagersFirstNameInput.EnterResponse(firstName);
        _caSummaryObject.ManagerFirstName = firstName;
    }

    public void EnterManagerLastName(string lastName)
    {
        CA_ContactDetailsPage.ManagersLastNameInput.EnterResponse(lastName);
        _caSummaryObject.ManagerLastName = lastName;
    }

    public void EnterManagerEmail(string email)
    {
        CA_ContactDetailsPage.ManagersEmailInput.AssertAllElements();
        CA_ContactDetailsPage.ManagersEmailInput.EnterResponse(email);
        _caSummaryObject.ManagerEmail = email;
    }

    public void EnterManagerPhone(string phone)
    {
        CA_ContactDetailsPage.ManagersPhoneInput.EnterResponse(phone);
        _caSummaryObject.ManagerPhone = phone;
    }

    public void EnterManagerExt(string phoneExt)
    {
        CA_ContactDetailsPage.ManagersPhoneExtInput.EnterResponse(phoneExt);
        _caSummaryObject.ManagerExt = phoneExt;
    }

    public void SelectSaveMoneyYesNo(string yesOrNo)
    {
        CA_ContactDetailsPage.SaveMoreMoneyInput.AssertAllElements();
        CA_ContactDetailsPage.SaveMoreMoneyInput.EnterResponse(yesOrNo);
    }

    public void EnterOwnerFirstName(string firstName)
    {
        CA_ContactDetailsPage.PrimaryOwnersInfoTitle.AssertElementIsVisible();
        CA_ContactDetailsPage.PrimaryOwnersInfoParagraph.AssertElementIsVisible();
        CA_ContactDetailsPage.PrimaryOwnersInfoSoftCreditNotImpactScore.AssertElementIsVisible();

        CA_ContactDetailsPage.OwnersFirstNameInput.EnterResponse(firstName);
        _caSummaryObject.PrimaryOwnerFirstName = firstName;
    }

    public void EnterOwnerLastName(string lastName)
    {
        CA_ContactDetailsPage.OwnersLastNameInput.EnterResponse(lastName);
        _caSummaryObject.PrimaryOwnerLastName = lastName;
    }

    public void EnterOwnerAddress(string address)
    {
        CA_ContactDetailsPage.OwnersHomeAddressInput.EnterResponse(address);
        _caSummaryObject.PrimaryOwnerAddress = new Address();
        _caSummaryObject.PrimaryOwnerAddress.Line1 = address;
    }

    public void EnterOwnerAddressLine2(string addressLine2)
    {
        CA_ContactDetailsPage.OwnersHomeAddressApptInput.EnterResponse(addressLine2);
        _caSummaryObject.PrimaryOwnerAddress.Line2 = addressLine2;
    }

    public void EnterOwnerZipCode(string zipCode)
    {
        
        CA_ContactDetailsPage.OwnersZipInput.EnterResponse(zipCode);        
        _caSummaryObject.PrimaryOwnerAddress.ZipCode = zipCode;
    }

    public void EnterOwnerCity(string city)
    {
        CA_ContactDetailsPage.OwnersCityInput.EnterResponse(city);
        _caSummaryObject.PrimaryOwnerAddress.City = city;
        VerifyAddressLoading();
    }

    public void SelectOwnerState(State state)
    {
        _caSummaryObject.PrimaryOwnerAddress.State = state;
        if (CA_ContactDetailsPage.GetInnerTextElementFromState(state).GetCountOfElements() == 0) // If the state is prepopulated then no need to select from the dropdown
        {
            CA_ContactDetailsPage.OwnersStateInput.EnterResponse(state.Name);
            VerifyAddressLoading();
        }
    }

    public void ChooseAddressPreference(string choice)
    {
        VerifyAddressLoading();

        //safety check for question engine
        var check = new InflightStatusChecker(CA_ReusableElements.InflightStatusElement);
        UserActions.WaitUntil(() => !check.IsInflight(), InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //check if suggested address section appears and then clicking on the desired button if so
        var suggestionAppeared = CA_ContactDetailsPage.BusinessAddressConfirmSubTitleNotFound.AssertElementIsVisible(1, true);
        if (suggestionAppeared)
        {
            CA_ContactDetailsPage.CreditCheckAddressSuggestionInput.EnterResponse(choice);
            if (choice.Equals("Suggested"))
            {
                _caSummaryObject.PrimaryOwnerAddressUsedSuggested = true;
            }
        }
    }

    private void VerifyAddressLoading()
    {
        //check that the progress bar appears (we may miss it and it's already gone)
        CA_ContactDetailsPage.AddressProgressBar.AssertElementIsVisible(5, true);
        //check that the progress bar disappears (wait for loading to finish)
        CA_ContactDetailsPage.AddressProgressBar.AssertElementNotPresent();
    }

    public void VerifyAddress(Address uiAddress)
    {
        //verify that the prefilled address parsed from UI is the same as the business address saved earlier
        _caSummaryObject.BusinessAddress.Equals(uiAddress);
    }

    public void ClickContinue()
    {
        CA_ContactDetailsPage.LetsWrapThisUpCTA.Click();
    }

    public void VerifyPrefilledOwnerName()
    {       
        string[] name = _caSummaryObject.NameOfBusiness.Split(' ');

        //If the entered Buisiness name has two words then that data will be prefilled as Owner's name (for biz type Individual/Sole Proprietor)
        if (name.Length == 2)
        {
            Assert.AreEqual(CA_ContactDetailsPage.OwnersFirstNameTxtbox.GetTextFieldValue(), name[0]);
            Assert.AreEqual(CA_ContactDetailsPage.OwnersLastNameTxtbox.GetTextFieldValue(), name[1]);
        }
        else
        {
            Assert.AreEqual(CA_ContactDetailsPage.OwnersFirstNameTxtbox.GetTextFieldValue(), "");
            Assert.AreEqual(CA_ContactDetailsPage.OwnersLastNameTxtbox.GetTextFieldValue(), "");
        }
    }
}