using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Contact Details")]
    public sealed class CA_ContactDetailsPage
    {
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(ContactDetailsTitle);

        /*
       * Headers----------------------------------------------------------
       */

        //Contact Details
        public static Element ContactDetailsTitle => new Element(By.XPath("//h1[@data-qa='Contacts-label']"));

        //We respect your privacy and won't share your information.  A licensed expert will contact you
        //      to discuss your policy and answer any questions you may have.
        public static Element RespectYourPrivacy => new Element(By.XPath ("//p[@data-qa='Contacts-sub-label']"));

        /*
        * Questions----------------------------------------------------------
        */

        //First Name
        public static Element FirstNameQst => new Element(By.XPath("//label[@data-qa='Contacts-firstName-label']"));
        public static Element FirstNameTxtbox => new Element(By.XPath("//input[@data-qa='Contacts-firstName']"));
        public static InputSection FirstNameInput => new TextBoxInput(FirstNameTxtbox)
            .AsAQuestion(FirstNameQst);
        public static Element FirstNameError => new Element(By.XPath("//mat-error[@data-qa='firstName-error']"));

        //Last Name
        public static Element LastNameQst => new Element(By.XPath("//label[@data-qa='Contacts-lastName-label']"));
        public static Element LastNameTxtbox => new Element(By.XPath("//input[@data-qa='Contacts-lastName']"));
        public static InputSection LastNameInput => new TextBoxInput(LastNameTxtbox)
            .AsAQuestion(LastNameQst);
        public static Element LastNameError => new Element(By.XPath("//mat-error[@data-qa='lastName-error']"));        

        //Business Email
        public static Element BusinessEmailQST => new Element(By.XPath("//label[@data-qa='_apollo_BusinessEmail-label']"));
        public static Element BusinessEmailTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_BusinessEmail']"));        
        public static InputSection BusinessEmailInput => new TextBoxInput(BusinessEmailTxtbox)
            .AsAQuestion(BusinessEmailQST);
        public static Element BusinessEmailError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_BusinessEmail-errorMessage']"));

        //Business Phone
        public static Element BusinessPhoneQST => new Element(By.XPath("//label[@data-qa='_apollo_BusinessPhone-label']"));
        
        public static Element BusinessPhoneTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_BusinessPhoneAndExt']"));
        public static Element BusinessPhoneTextBelow => new Element(By.XPath("//mat-hint[@data-qa='_apollo_BusinessPhone-hint']"));
        public static InputSection BusinessPhoneInput => new TextBoxInput(BusinessPhoneTxtbox)
            .AsAQuestion(BusinessPhoneQST)
            .WithExtraText(BusinessPhoneTextBelow);
        public static Element BusinessPhoneExtTxtbox => new Element(By.XPath("//input[@data-qa='BusinessPhoneAndExt-phoneExtension']"));
        public static InputSection BusinessPhoneExtInput => new TextBoxInput(BusinessPhoneExtTxtbox);
        public static Element BusinessPhoneError => new Element(By.XPath("//mat-error[@data-qa='number-error']"));
        

        //Business Website
        public static Element BusinessWebsiteQST => new Element(By.XPath("//label[@data-qa='_apollo_BusinessWebsite-label']"));
        public static Element BusinessWebsiteTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_BusinessWebsite']"));
        public static Element BusinessWebsiteTextBelow => new Element(By.XPath("//mat-hint[@data-qa='_apollo_BusinessWebsite-hint']"));
        public static InputSection BusinessWebsiteInput => new TextBoxInput(BusinessWebsiteTxtbox)
            .AsAQuestion(BusinessWebsiteQST)
            .WithExtraText(BusinessPhoneTextBelow);
        public static Element BusinessWebsiteError => new Element(By.XPath("//mat-error[@data-qa='_apollo_BusinessWebsite-error']"));

        //Business has an account manager with different contact information
        public static Element BusinessHasAccntMngQST => new Element(By.XPath("_apollo_IsAccountManagerDifferent"));  //missing
        public static Element BusinessHasAccntMngChkbox => new Element(By.XPath("//mat-checkbox[@data-qa='_apollo_IsAccountManagerDifferent-checkbox']"));
        public static InputSection BusinessHasAccntMngInput => new HtmlCheckBoxToggleInput(BusinessHasAccntMngChkbox)
            .AsAQuestion(BusinessHasAccntMngQST);

        //Account Manager/Broker's First Name
        public static Element ManagersFirstNameQST => new Element(By.XPath("//label[@data-qa='AccountManagerName-firstName-label']"));
        public static Element ManagersFirstNameTxtbox => new Element(By.XPath("//input[@data-qa='AccountManagerName-firstName']"));
        public static InputSection ManagersFirstNameInput => new TextBoxInput(ManagersFirstNameTxtbox)
            .AsAQuestion(ManagersFirstNameQST)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);
        public static Element ManagersFirstNameError => new Element(By.XPath("(//mat-error[@data-qa='firstName-error'])[last()]"));

        //Account Manager/Broker's Last Name
        public static Element ManagersLastNameQST => new Element(By.XPath("//label[@data-qa='AccountManagerName-lastName-label']"));
        public static Element ManagersLastNameTxtbox => new Element(By.XPath("//input[@data-qa='AccountManagerName-lastName']"));
        public static InputSection ManagersLastNameInput => new TextBoxInput(ManagersLastNameTxtbox)
            .AsAQuestion(ManagersLastNameQST);
        public static Element ManagersLastNameError => new Element(By.XPath("(//mat-error[@data-qa='lastName-error'])[last()]"));

        //Account Manager/Broker's Email
        public static Element ManagersEmailQST => new Element(By.XPath("//label[@data-qa='_apollo_AccountManagerEmail-label']"));
        public static Element ManagersEmailTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_AccountManagerEmail']"));
        public static InputSection ManagersEmailInput => new TextBoxInput(ManagersEmailTxtbox)
            .AsAQuestion(ManagersEmailQST)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);
        public static Element ManagersEmailError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_AccountManagerEmail-errorMessage'][last()]"));

        //Account Manager/Broker's Phone
        public static Element ManagersPhoneQST => new Element(By.XPath("//label[@data-qa='_apollo_AccountManagerPhone-label']"));
        public static Element ManagersPhoneTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_AccountManagerPhoneAndExt']"));
        public static InputSection ManagersPhoneInput => new TextBoxInput(ManagersPhoneTxtbox)
            .AsAQuestion(ManagersPhoneQST);
        public static Element ManagersPhoneExtTxtbox => new Element(By.XPath("//input[@data-qa='AccountManagerPhoneAndExt-phoneExtension']"));
        public static InputSection ManagersPhoneExtInput => new TextBoxInput(ManagersPhoneExtTxtbox);
        public static Element ManagersPhoneError => new Element(By.XPath("//label[@data-qa='_apollo_AccountManagerPhoneAndExt-label']/ancestor::bb-apollo-phone//mat-error[@data-qa='number-error']"));

        //Would you like to SAVE more money?
        public static Element SaveMoreMoneyQST => new Element(By.XPath("//label[@data-qa='_apollo_SaveMoney-label']"));
        public static Element SaveMoreMoneyYes => new Element(By.XPath("//button[@data-qa='_apollo_SaveMoney-9002-yes-button']"));
        public static Element SaveMoreMoneyNo => new Element(By.XPath("//button[@data-qa='_apollo_SaveMoney-9002-no-button']"));
        public static InputSection SaveMoreMoneyInput => new YesOrNoInput(SaveMoreMoneyYes, SaveMoreMoneyNo, ButtonSelectionPredicates.AngularSingleSelect);
        public static Element SaveMoreMoneyError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_SaveMoney-errorMessage']"));

        //Save More With a Soft Credit Score Check
        public static Element PrimaryOwnersInfoTitle => new Element(By.XPath("//h3[@data-qa='primary-owners-information']"));
        public static Element PrimaryOwnersInfoParagraph => new Element(By.XPath("//p[@data-qa='soft-credit-message']"));
        public static Element PrimaryOwnersInfoSoftCreditNotImpactScore => new Element(By.XPath("//p[@data-qa='soft-credit-no-impact']"));

        //Owner's First Name
        public static Element OwnersFirstNameTxtbox => new Element(By.XPath("//input[@data-qa='firstName']"));
        public static InputSection OwnersFirstNameInput => new TextBoxInput(OwnersFirstNameTxtbox);
        public static Element OwnersFirstNameError => new Element(By.XPath("//mat-error[@data-qa='firstName-error']"));

        //Owner's Last Name
        public static Element OwnersLastNameTxtbox => new Element(By.XPath("//input[@data-qa='lastName']"));
        public static InputSection OwnersLastNameInput => new TextBoxInput(OwnersLastNameTxtbox);
        public static Element OwnersLastNameError => new Element(By.XPath("//mat-error[@data-qa='lastName-error']"));

        //Owner's Home Address
        public static Element OwnersHomeAddressTxtbox => new Element(By.XPath("//input[@data-qa='apollo_1076-line1']"));
        public static InputSection OwnersHomeAddressInput => new TextBoxInput(OwnersHomeAddressTxtbox);
        public static Element OwnersHomeAddressError => new Element(By.XPath("//mat-error[@data-qa='line1-error']"));

        //Apartment, Suite, etc.
        public static Element OwnersHomeAddressApptTxtbox => new Element(By.XPath("//input[@data-qa='apollo_1076-line2']"));
        public static InputSection OwnersHomeAddressApptInput => new TextBoxInput(OwnersHomeAddressApptTxtbox);

        //ZIP Code
        public static Element OwnersZipTxtbox => new Element(By.XPath("//input[@data-qa='apollo_1076-postalCode-zipcode']"));
        
        public static InputSection OwnersZipInput => new TextBoxInput(OwnersZipTxtbox);
        public static Element OwnersZipError => new Element(By.XPath("//mat-error[@data-qa='postalCode-error']"));

        //City
        public static Element OwnersCityTxtbox => new Element(By.XPath("//input[@data-qa='apollo_1076-majorMunicipality-city']"));
        public static InputSection OwnersCityInput => new TextBoxInput(OwnersCityTxtbox);
        public static Element OwnersCityError => new Element(By.XPath("//mat-error[@data-qa='majorMunicipality-error']"));

        //State        
        public static Element OwnersStateDD => new Element(By.XPath("//mat-select[@data-qa='apollo_1076-stateProvince-state']"));
        public static InputSection OwnersStateInput => new MatDropdownInput(OwnersStateDD);
        public static Element OwnersStateError => new Element(By.XPath("//mat-error[@data-qa='stateProvince-error']"));
        public static Element GetInnerTextElementFromState(State state) => new Element(By.XPath($"//mat-select[@data-qa='apollo_1076-stateProvince-state']//span[text()='{state}']"));
        public static Element AddressProgressBar => new Element(By.XPath("//mat-progress-bar"));
        public static Element BusinessAddressConfirmSubTitleNotFound => new Element(By.XPath("//p[@data-qa='apollo_1076-select-panel-title-info']"));
        public static Element CreditCheckAddressUseAsEnteredBTN => new Element(By.XPath("//button[@data-qa='apollo_1076-original-btn']"));
        public static Element CreditCheckAddressUseSuggestedBTN => new Element(By.XPath("//button[@data-qa='apollo_1076-suggested-btn']"));
        public static ChoiceGroup CreditCheckAddressSuggestionGroup => new ChoiceGroup(new Dictionary<string, Element>()
        {
            { "Original", CreditCheckAddressUseAsEnteredBTN },
            { "Suggested", CreditCheckAddressUseSuggestedBTN }
        });
        public static InputSection CreditCheckAddressSuggestionInput => new SingleChoiceGroupInput(CreditCheckAddressSuggestionGroup, ButtonSelectionPredicates.AngularSingleSelect);

        /*
        * Page CTA----------------------------------------------------------
        */

        //Let's Continue
        public static Element LetsWrapThisUpCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

        //Back
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));

        public static List<Element> ErrorElements = new List<Element>
        {
            FirstNameError,
            LastNameError,
            BusinessEmailError,
            BusinessPhoneError,
            BusinessWebsiteError,
            ManagersFirstNameError,
            ManagersLastNameError,
            ManagersEmailError,
            ManagersPhoneError,
            OwnersFirstNameError,
            OwnersLastNameError,
            OwnersHomeAddressError,
            OwnersZipError,
            OwnersCityError,
            OwnersStateError
        };
    }
}
