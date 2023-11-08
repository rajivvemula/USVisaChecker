using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.Input;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA.Driver.Input;
using BiBerkLOB.Source.Driver;

namespace BiBerkLOB.Pages
{
    [Mapping("CA Quick Intro")]
    class CA_IntroductionPage 
    {
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(IntroPageTitle, PleaseTellUsALittle);
        /*
       * Headers----------------------------------------------------------
       */

        // A Quick Introduction
        public static Element IntroPageTitle => new Element(By.XPath("//h1[@data-qa='Introduction-label']"));
        // Please tell us a little bit about your company
        public static Element PleaseTellUsALittle => new Element(By.XPath("//p[@data-qa='Introduction-sub-label']"));

        /*
        * Questions----------------------------------------------------------
        */
        // What year was your business started?
        public static Element BusinessStartedQST => new Element(By.XPath("//label[@data-qa='_apollo_YearBusinessStarted-label']"));
        public static Element BusinessStartedTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_YearBusinessStarted']"));
        public static Element BusinessStartedTextBelow => new Element(By.XPath("//mat-hint[@data-qa='_apollo_YearBusinessStarted-hint']"));
        public static InputSection BusinessStartedInput => new TextBoxInput(BusinessStartedTxtbox)
            .AsAQuestion(BusinessStartedQST)
            .WithExtraText(BusinessStartedTextBelow);
        public static Element BusinessStartedHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_YearBusinessStarted']"));
        public static Element BusinessStartedHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_YearBusinessStarted-label']"));
        public static Element BusinessStartedHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_YearBusinessStarted']"));
        public static Element BusinessStartedError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_YearBusinessStarted-errorMessage']/span/div"));

        //How is your business structured?
        public static Element BusinessStructuredQST => new Element(By.XPath("//label[@data-qa='_apollo_BusinessStructure-label']"));
        public static Element BusinessStructuredDD => new Element(By.XPath("//mat-select[@data-qa='_apollo_BusinessStructure']"));
        public static InputSection BusinessStructuredInput => new MatDropdownInput(BusinessStructuredDD)
            .AsAQuestion(BusinessStructuredQST);
        public static Element BusinessStructuredHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_BusinessStructure']/mat-icon"));
        public static Element BusinessStructuredHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_BusinessStructure']/span/mat-icon"));
        public static Element BusinessStructuredHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_BusinessStructure-label']"));
        public static Element BusinessStructuredError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_BusinessStructure-errorMessage']/span/div"));

        //What type of Government entity is it?
        public static Element GovTypeQST => new Element(By.XPath("//label[@data-qa='_apollo_GovernmentEntityType-label']"));
        public static Element GovTypeDD => new Element(By.XPath("//mat-select[@data-qa='_apollo_GovernmentEntityType']"));
        public static InputSection GovTypeInput => new MatDropdownInput(GovTypeDD)
            .AsAQuestion(GovTypeQST);
        public static Element GovTypeError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_GovernmentEntityType-errorMessage']/span/div"));

        //Business Address
        public static Element BusinessAddressQST => new Element(By.XPath("//label[@data-qa='_apollo_PhysicalBusinessAddress-label']"));
        public static Element BusinessAddressAddress1Txtbox => new Element(By.XPath("//input[@data-qa='_apollo_PhysicalBusinessAddress-line1']"));
        public static Element BusinessAddressAddress1Error => new Element(By.XPath("//mat-error[@data-qa='line1-error']"));
        public static Element BusinessAddressAddress2Txtbox => new Element(By.XPath("//input[@data-qa='_apollo_PhysicalBusinessAddress-line2']"));
        public static Element BusinessAddressCityTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_PhysicalBusinessAddress-majorMunicipality-city']"));
        public static Element BusinessAddressCityError => new Element(By.XPath("//mat-error[@data-qa='majorMunicipality-error']"));
        public static Element BusinessAddressStateCommaZip => new Element(By.XPath("//div[@class='column is-5']/h6[@class='p-5']"));
        public static InputSection BusinessAddressAddress1Input => new TextBoxInput(BusinessAddressAddress1Txtbox);
        public static InputSection BusinessAddressAddress2Input => new TextBoxInput(BusinessAddressAddress2Txtbox);
        public static InputSection BusinessAddressCityInput => new TextBoxInput(BusinessAddressCityTxtbox);
        //Confirm your Business Address
        public static Element BusinessAddressConfirmTitle => new Element(By.XPath("//div[@data-qa='_apollo_PhysicalBusinessAddress-select-panel-title']"));
        public static Element BusinessAddressConfirmSubTitleNotFound => new Element(By.XPath("//p[@data-qa='_apollo_PhysicalBusinessAddress-select-panel-title-info']"));
        public static Element BusinessAddressConfirmSubTitle => new Element(By.XPath("//p[@data-qa='_apollo_PhysicalBusinessAddress-found-precise-address']"));
        public static Element BusinessAddressOriginalLabel => new Element(By.XPath("//p[@data-qa='_apollo_PhysicalBusinessAddress-original-address']"));
        public static Element BusinessAddressUseAsEnteredBTN => new Element(By.XPath("//button[@data-qa='_apollo_PhysicalBusinessAddress-original-btn']"));
        public static Element BusinessAddressSuggestedLabel => new Element(By.XPath("//p[@data-qa='_apollo_PhysicalBusinessAddress-suggested-address']"));
        public static Element BusinessAddressUseSuggestedBTN => new Element(By.XPath("//button[@data-qa='_apollo_PhysicalBusinessAddress-suggested-btn']"));
        private static SmartyStreetAddressElements BusinessAddressElements => new SmartyStreetAddressElements()
        {
            AddressLine1 = BusinessAddressAddress1Input,
            AddressLine2 = BusinessAddressAddress2Input,
            City = BusinessAddressCityInput,
            LoadingBar = CA_ReusableElements.AddressProgressBar,
            SuggestionBoxTitle = BusinessAddressConfirmSubTitleNotFound,
            AsEnteredBtn = BusinessAddressUseAsEnteredBTN,
            SuggestedBtn = BusinessAddressUseSuggestedBTN
        };
        public static InputSection BusinessAddressInput = new SmartyStreetsAddressInput(BusinessAddressElements)
            .AsAQuestion(BusinessAddressQST);

        //Use Different Mailing Address?
        public static Element UseAsMailingAddressQST => new Element(By.XPath("//mat-checkbox[@data-qa='_apollo_MailingAddressDifferent-checkbox']//label"));
        public static Element UseAsMailingAddressChkbox => new Element(By.XPath("//mat-checkbox[@data-qa='_apollo_MailingAddressDifferent-checkbox']//input/.."));

        public static InputSection UseAsMailingAddressInput => new MatCheckBoxToggleInput(UseAsMailingAddressChkbox)
            .AsAQuestion(UseAsMailingAddressQST);

        //Business Mailing Address
        public static Element MailingAddressQST => new Element(By.XPath("//label[@data-qa='_apollo_MailingBusinessAddress-label']"));
        public static Element MailingAddressAddress1 => new Element(By.XPath("//input[@data-qa='_apollo_MailingBusinessAddress-line1']"));
        public static Element MailingAddressAddress2 => new Element(By.XPath("//input[@data-qa='_apollo_MailingBusinessAddress-line2']"));
        public static Element MailingAddressZip => new Element(By.XPath("//input[@data-qa='_apollo_MailingBusinessAddress-postalCode-zipcode']"));
        public static Element MailingAddressCity => new Element(By.XPath("//input[@data-qa='_apollo_MailingBusinessAddress-majorMunicipality-city']"));
        public static Element MailingAddressState => new Element(By.XPath("//mat-select[@data-qa='_apollo_MailingBusinessAddress-stateProvince-state']"));
        public static InputSection MailingAddressAddress1Input => new TextBoxInput(MailingAddressAddress1);
        public static InputSection MailingAddressAddress2Input => new TextBoxInput(MailingAddressAddress2);
        public static InputSection MailingAddressZipInput => new TextBoxInput(MailingAddressZip);
        public static InputSection MailingAddressCityInput => new TextBoxInput(MailingAddressCity);
        public static InputSection MailingAddressStateInput => new MatDropdownInput(MailingAddressState)
            .TakesAStateAsInput(StateInputStrategy.Name);
        private static SmartyStreetAddressElements MailingAddressParts => new SmartyStreetAddressElements()
        {
            AddressLine1 = MailingAddressAddress1Input,
            AddressLine2 = MailingAddressAddress2Input,
            City = MailingAddressCityInput,
            State = MailingAddressStateInput,
            ZipCode = MailingAddressZipInput,
            LoadingBar = CA_ReusableElements.AddressProgressBar,
            SuggestionBoxTitle = MailingAddressConfirmTitle,
            AsEnteredBtn = MailingAddressUseAsEnteredBTN,
            SuggestedBtn = MailingAddressUseSuggestedBTN
        };
        public static InputSection MailingAddressInput => new SmartyStreetsAddressInput(MailingAddressParts)
            .AsAQuestion(MailingAddressQST)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        public static Element MailingAddressAddress1Error => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_MailingBusinessAddress-errorMessage']/mat-error[@data-qa='line1-error']"));
        public static Element MailingAddressCityError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_MailingBusinessAddress-errorMessage']/mat-error[@data-qa='majorMunicipality-error']"));
        public static Element MailingAddressZipError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_MailingBusinessAddress-errorMessage']/mat-error[@data-qa='postalCode-error']"));
        public static Element MailingAddressStateError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_MailingBusinessAddress-errorMessage']/mat-error[@data-qa='stateProvince-error']"));

        //Confirm Your Mailing Address
        public static Element MailingAddressConfirmTitle => new Element(By.XPath("//div[@data-qa='_apollo_MailingBusinessAddress-select-panel-title']"));
        public static Element MailingAddressConfirmSubTitle => new Element(By.XPath("//p[@data-qa='_apollo_MailingBusinessAddress-select-panel-title-info']"));
        public static Element MailingAddressOriginalLabel => new Element(By.XPath("//p[@data-qa='_apollo_MailingBusinessAddress-original-address']"));
        public static Element MailingAddressUseAsEnteredBTN => new Element(By.XPath("//button[@data-qa='_apollo_MailingBusinessAddress-original-btn']"));
        public static Element MailingAddressSuggestedLabel => new Element(By.XPath("//p[@data-qa='_apollo_MailingBusinessAddress-suggested-address']"));
        public static Element MailingAddressUseSuggestedBTN => new Element(By.XPath("//button[@data-qa='_apollo_MailingBusinessAddress-suggested-btn']"));

        //Please fix the following error(s) before proceeding:
        public static Element PleaseFixErrors => new Element(By.XPath("//div[@data-qa='bbnav-error-title']"));
        public static Element OneOrMoreInvalid => new Element(By.XPath("//div[@data-qa='bbnav-error-message']"));

        /*
        * Page CTA----------------------------------------------------------
        */

        //Let's Continue
        public static Element LetsContinueCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

        //Back
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));
    }
}
