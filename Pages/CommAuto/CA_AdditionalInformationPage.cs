using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Driver.Input;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Additional Info")]
    public sealed class CA_AdditionalInformationPage
    {
        private const int AI_MAX_WAIT = 10; // state changes shown to take longer on this page

        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(AdditionalInformationTitle, InformationRequiredForComAutoCoverage);
        /*
        * Headers----------------------------------------------------------
        */

        //Additional Information
        public static Element AdditionalInformationTitle => new Element(By.XPath("//h1[@data-qa='Additional Vehicle Information-label']"));

        //Please fill out the information below.  This information is required for commercial auto coverage.
        public static Element InformationRequiredForComAutoCoverage => new Element(By.XPath("//p[@data-qa='Additional Vehicle Information-sub-label']"));

        /*
        * Questions----------------------------------------------------------
        */

        //Accordian Open
        //Accordian Close
        /// <summary>
        /// the above might be handled with additional logic instead of more direct mappings on this page, leaving as a placeholder/reminder
        /// </summary>
        /// 

        /*
         * Please Note these are PURPOSELY MAPPED WITHOUT a NAME ATTRIBUTE
         */
        //Panel header (expanded attribute is aria-expanded)
        public static Element VehiclePanelHeader(int panelIndex) => new Element(By.XPath($"(//mat-expansion-panel-header)[{panelIndex+1}]"));
        public static Element AnyGreyedOutPanel => new Element(By.XPath("//bb-expansion-panel[contains(@style, 'transition')]"));

        //Vehicle Details
        public static Element VehicleDetailsQST(int panelIndex) => new Element(By.XPath($"//label[@data-qa='vehicle-details-{panelIndex}-label']"));
        //**pull the text from the Populated field and verify via regex it has numbers followed by a space followed by atleast one letter
        public static Element VehicleDetailsPopulated(int panelIndex) => new Element(By.XPath($"//div[@data-qa='makemodel-{panelIndex}']"));
        public static Element VehicleDetailsHelper(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonShowHelpToggle-vehicle-details-{panelIndex}']"));
        public static Element VehicleDetailsHelperText(int panelIndex) => new Element(By.XPath($"//p[@data-qa='bbHelpText-vehicle-details-{panelIndex}-label']"));
        public static Element VehicleDetailsHelperX(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonClose-bbHelpText-vehicle-details-{panelIndex}']"));

        //Vehicle Value
        public static Element VehicleValueQST(int panelIndex) => new Element(By.XPath($"//label[@data-qa='vehicle-value-{panelIndex}-label']"));
        public static Element VehicleValuePopulated(int panelIndex) => new Element(By.XPath($"//div[@data-qa='vehicle-value-{panelIndex}']"));


        //Vehicle Identification Number (VIN)--picks up last instance of expanded one
        public static Element VINQST(int panelIndex) => new Element(By.XPath($"//label[@data-qa='vin-{panelIndex}-label']"));
        public static Element VINTxtbox(int panelIndex) => new Element(By.XPath($"//input[@data-qa='vin-{panelIndex}']"));
        public static Element VINErrorMessage => new Element(By.XPath("(//mat-expansion-panel-header[@role='button' and @aria-expanded='true']/following-sibling::div[1]//mat-error[@data-qa='vinNumber-error'])[last()]"));
        public static InputSection VINInput(int panelIndex) => new TextBoxInput(VINTxtbox(panelIndex))
            .AsAQuestion(VINQST(panelIndex));

        //Trim drop down (can appear after supplying the VIN)
        public static Element TrimDD(int panelIndex) => new Element(By.XPath($"//mat-select[starts-with(@data-qa,'VehiclesAdditional-') and contains(@data-qa,'-trim-{panelIndex}')]"));
        public static InputSection TrimInput(int panelIndex) => new MatDropdownInput(TrimDD(panelIndex));

        //Is this vehicle owned, financed, or leased?
        public static Element IsVehicleOwnedFinancedOrLeasedQST(int panelIndex) => new Element(By.XPath($"//label[@data-qa='_apollo_VehicleOwnedLeasedFinanced_{panelIndex}-label' or @data-qa='_apollo_TrailerOwnedFinancedLeased_{panelIndex}-label']"));
        public static Element VehicleOwnedButton(int panelIndex) => new Element(By.XPath($"//button[(starts-with(@data-qa,'_apollo_VehicleOwnedLeasedFinanced_{panelIndex}') or starts-with(@data-qa,'_apollo_TrailerOwnedFinancedLeased_{panelIndex}')) and contains(@data-qa,'Owned-button')]"));
        public static Element VehicleFinancedButton(int panelIndex) => new Element(By.XPath($"//button[(starts-with(@data-qa,'_apollo_VehicleOwnedLeasedFinanced_{panelIndex}') or starts-with(@data-qa,'_apollo_TrailerOwnedFinancedLeased_{panelIndex}')) and contains(@data-qa,'Financed-button')]"));
        public static Element VehicleLeasedButton(int panelIndex) => new Element(By.XPath($"//button[(starts-with(@data-qa,'_apollo_VehicleOwnedLeasedFinanced_{panelIndex}') or starts-with(@data-qa,'_apollo_TrailerOwnedFinancedLeased_{panelIndex}')) and contains(@data-qa,'Leased-button')]"));
        public static ChoiceGroup IsVehicleOwnedFinancedOrLeasedChoices(int panelIndex) => new ChoiceGroup(
            new Dictionary<string, Element>()
            {
                { "Owned", VehicleOwnedButton(panelIndex) },
                { "Financed", VehicleFinancedButton(panelIndex) },
                { "Leased", VehicleLeasedButton(panelIndex) }
            });
        public static InputSection IsVehicleOwnedFinancedOrLeasedInput(int panelIndex) => new SingleChoiceGroupInput(IsVehicleOwnedFinancedOrLeasedChoices(panelIndex), ButtonSelectionPredicates.AngularSingleSelect)
            .AsAQuestion(IsVehicleOwnedFinancedOrLeasedQST(panelIndex))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, AI_MAX_WAIT);

        //Is this trailer owned, financed, or leased
        public static Element IsTrailerOwnedFinancedOrLeasedQST(int panelIndex) => new Element(By.XPath($"//label[]"));
        public static Element TrailerOwnedButton(int panelIndex) => new Element(By.XPath($"//button[ and contains(@data-qa,'Owned-button')]"));
        public static Element TrailerFinancedButton(int panelIndex) => new Element(By.XPath($"//button[ and contains(@data-qa,'Financed-button')]"));
        public static Element TrailerLeasedButton(int panelIndex) => new Element(By.XPath($"//button[ and contains(@data-qa,'Leased-button')]"));

        //Who holds the vehicle title/registration?
        public static Element VehicleTitleQST(int panelIndex) => new Element(By.XPath($"//label[@data-qa='_apollo_VehicleTitleOwner_{panelIndex}-label' or @data-qa='_apollo_TrailerTitleOwner_{panelIndex}-label']"));
        public static Element VehicleTitleTheBusinessButton(int panelIndex) => new Element(By.XPath($"//button[(starts-with(@data-qa,'_apollo_VehicleTitleOwner_{panelIndex}') or starts-with(@data-qa,'_apollo_TrailerTitleOwner_{panelIndex}')) and contains(@data-qa,'-Business-button')]"));
        public static Element VehicleTitleOneOrMoreButton(int panelIndex) => new Element(By.XPath($"//button[(starts-with(@data-qa,'_apollo_VehicleTitleOwner_{panelIndex}') or starts-with(@data-qa,'_apollo_TrailerTitleOwner_{panelIndex}')) and contains(@data-qa,'-Multiple-button')]"));
        public static Element VehicleTitleSomeoneElseButton(int panelIndex) => new Element(By.XPath($"//button[(starts-with(@data-qa,'_apollo_VehicleTitleOwner_{panelIndex}') or starts-with(@data-qa,'_apollo_TrailerTitleOwner_{panelIndex}')) and contains(@data-qa,'-Other-button')]"));
        public static Element VehicleTitleMyselfButton(int panelIndex) => new Element(By.XPath($"//button[(starts-with(@data-qa,'_apollo_VehicleTitleOwner_{panelIndex}')) and contains(@data-qa,'-Myself-button')]"));
        public static ChoiceGroup VehicleTitleChoices(int panelIndex) => new ChoiceGroup(
            new Dictionary<string, Element>()
            {
                { "The Business", VehicleTitleTheBusinessButton(panelIndex) },
                { "Multiple", VehicleTitleOneOrMoreButton(panelIndex) },
                { "Someone else", VehicleTitleSomeoneElseButton(panelIndex) },
                { "Myself", VehicleTitleMyselfButton(panelIndex) }
            });
        public static InputSection VehicleTitleInput(int panelIndex) => new SingleChoiceGroupInput(VehicleTitleChoices(panelIndex), ButtonSelectionPredicates.AngularSingleSelect)
            .AsAQuestion(VehicleTitleQST(panelIndex))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, AI_MAX_WAIT);

        //Who holds the trailer title/registration?
        public static Element TrailerTitleQST(int panelIndex) => new Element(By.XPath($"//label                 []"));
        public static Element TrailerTitleTheBusinessButton(int panelIndex) => new Element(By.XPath($"//button  [ and contains(@data-qa,'-Business-button')]"));
        public static Element TrailerTitleOneOrMoreButton(int panelIndex) => new Element(By.XPath($"//button    [ and contains(@data-qa,'-Multiple-button')]"));
        public static Element TrailerTitleSomeoneElseButton(int panelIndex) => new Element(By.XPath($"//button  [ and contains(@data-qa,'-Other-button')]"));
        
        //One or More of the business Owner(s) Selected - Vehicle, First Name
        public static Element OwnerVehicleContactDetailsQST(int panelIndex) => new Element(By.XPath($"//label[@data-qa='_apollo_VehicleOwner1FirstName_{panelIndex}-label' or @data-qa='_apollo_TrailerOwner1FirstName_{panelIndex}-label']"));
        public static Element OwnerVehicleFirstNameTxtbox(int panelIndex) => new Element(By.XPath($"//input[@data-qa='_apollo_VehicleOwner1FirstName_{panelIndex}' or @data-qa='_apollo_TrailerOwner1FirstName_{panelIndex}']"));
        public static Element OwnerVehicleFirstNameHelper(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonShowHelpToggle-_apollo_VehicleOwner1FirstName_{panelIndex}' or @data-qa='buttonShowHelpToggle-_apollo_TrailerOwner1FirstName_{panelIndex}']"));
        public static Element OwnerVehicleFirstNameHelperText(int panelIndex) => new Element(By.XPath($"//p[@data-qa='bbHelpText-_apollo_VehicleOwner1FirstName_{panelIndex}' or @data-qa='bbHelpText-_apollo_TrailerOwner1FirstName_{panelIndex}']"));
        public static Element OwnerVehicleFirstNameHelperX(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonClose-bbHelpText-_apollo_VehicleOwner1FirstName_{panelIndex}' or @data-qa='buttonClose-bbHelpText-_apollo_TrailerOwner1FirstName_{panelIndex}']"));
        public static Element OwnerVehicleFirstNameError(int panelIndex) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_VehicleOwner1FirstName_{panelIndex}' or @data-qa='_apollo_TrailerOwner1FirstName_{panelIndex}']"));
        public static InputSection OwnerVehicleFirstNameInput(int panelIndex) => new TextBoxInput(OwnerVehicleFirstNameTxtbox(panelIndex))
            .AsAQuestion(OwnerVehicleContactDetailsQST(panelIndex))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, AI_MAX_WAIT);

        //One or More of the business Owner(s) Selected - Trailer, First Name
        public static Element OwnerTrailerContactDetailsQST(int panelIndex) => new Element(By.XPath($"//label           []"));
        public static Element OwnerTrailerFirstNameTxtbox(int panelIndex) => new Element(By.XPath($"//input             []"));
        public static Element OwnerTrailerFirstNameHelper(int panelIndex) => new Element(By.XPath($"//button            []"));
        public static Element OwnerTrailerFirstNameHelperText(int panelIndex) => new Element(By.XPath($"//p             []"));
        public static Element OwnerTrailerFirstNameHelperX(int panelIndex) => new Element(By.XPath($"//button           []"));
        public static Element OwnerTrailerFirstNameError(int panelIndex) => new Element(By.XPath($"//bb-error-message   []"));
        
        //One or More of the business Owner(s) Selected - Vehicle, Last Name
        public static Element OwnerVehicleLastNameQST(int panelIndex) => new Element(By.XPath($"//label[@data-qa='_apollo_VehicleOwner1LastName_{panelIndex}-label' or @data-qa='_apollo_TrailerOwner1LastName_{panelIndex}-label']"));
        public static Element OwnerVehicleLastNameTxtbox(int panelIndex) => new Element(By.XPath($"//input[@data-qa='_apollo_VehicleOwner1LastName_{panelIndex}' or @data-qa='_apollo_TrailerOwner1LastName_{panelIndex}']"));
        public static Element OwnerVehicleLastNameHelper(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonShowHelpToggle-_apollo_VehicleOwner1FirstName_{panelIndex}' or @data-qa='buttonShowHelpToggle-_apollo_TrailerOwner1FirstName_{panelIndex}']"));
        public static Element OwnerVehicleLastNameHelperText(int panelIndex) => new Element(By.XPath($"//p[@data-qa='bbHelpText-_apollo_VehicleOwner1FirstName_{panelIndex}' or @data-qa='bbHelpText-_apollo_TrailerOwner1FirstName_{panelIndex}']"));
        public static Element OwnerVehicleLastNameHelperX(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonClose-bbHelpText-_apollo_VehicleOwner1FirstName_{panelIndex}' or @data-qa='buttonClose-bbHelpText-_apollo_TrailerOwner1FirstName_{panelIndex}']"));
        public static Element OwnerVehicleLastNameError(int panelIndex) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_VehicleOwner1LastName_{panelIndex}-errorMessage' or @data-qa='_apollo_TrailerOwner1LastName_{panelIndex}-errorMessage']"));
        public static InputSection OwnerVehicleLastNameInput(int panelIndex) => new TextBoxInput(OwnerVehicleLastNameTxtbox(panelIndex))
            .AsAQuestion(OwnerVehicleLastNameQST(panelIndex))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, AI_MAX_WAIT);

        //One or More of the business Owner(s) Selected - Trailer, Last Name
        public static Element OwnerTrailerLastNameQST(int panelIndex) => new Element(By.XPath($"//label             []"));
        public static Element OwnerTrailerLastNameTxtbox(int panelIndex) => new Element(By.XPath($"//input          []"));
        public static Element OwnerTrailerLastNameHelper(int panelIndex) => new Element(By.XPath($"//button         []"));
        public static Element OwnerTrailerLastNameHelperText(int panelIndex) => new Element(By.XPath($"//p          []"));
        public static Element OwnerTrailerLastNameHelperX(int panelIndex) => new Element(By.XPath($"//button        []"));
        public static Element OwnerTrailerLastNameError(int panelIndex) => new Element(By.XPath($"//bb-error-message[]"));
        
        //Provide the Address of who owns the vehicle:
        public static Element StreetAddressTxtbox(int panelIndex) => new Element(By.XPath($"//input[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}-line1' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}-line1' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}-line1' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}-line1' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}-line1' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}-line1']"));
        public static InputSection StreetAddressInput(int panelIndex) => new TextBoxInput(StreetAddressTxtbox(panelIndex));
        public static Element ApartmentSuiteTxtbox(int panelIndex) => new Element(By.XPath($"//input[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}-line2' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}-line2' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}-line2' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}-line2' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}-line2' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}-line2']"));
        public static InputSection ApartmentSuiteInput(int panelIndex) => new TextBoxInput(ApartmentSuiteTxtbox(panelIndex));
        public static Element ZipCodeTxtbox(int panelIndex) => new Element(By.XPath($"//input[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}-postalCode-zipcode' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}-postalCode-zipcode' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}-postalCode-zipcode' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}-postalCode-zipcode' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}-postalCode-zipcode' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}-postalCode-zipcode']"));
        public static InputSection ZipCodeInput(int panelIndex) => new TextBoxInput(ZipCodeTxtbox(panelIndex));
        public static Element CityTxtbox(int panelIndex) => new Element(By.XPath($"//input[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}-majorMunicipality-city' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}-majorMunicipality-city' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}-majorMunicipality-city' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}-majorMunicipality-city' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}-majorMunicipality-city' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}-majorMunicipality-city']"));
        public static InputSection CityInput(int panelIndex) => new TextBoxInput(CityTxtbox(panelIndex));
        public static Element StateDD(int panelIndex) => new Element(By.XPath($"//mat-select[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}-stateProvince-state' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}-stateProvince-state' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}-stateProvince-state' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}-stateProvince-state' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}-stateProvince-state' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}-stateProvince-state']"));
        public static InputSection StateInput(int panelIndex) => new MatDropdownInput(StateDD(panelIndex))
            .TakesAStateAsInput(StateInputStrategy.Name);
        public static Element AddressSuggestionTitle(int panelIndex) => new Element($"//div[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}-select-panel-title' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}-select-panel-title' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}-select-panel-title' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}-select-panel-title' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}-select-panel-title' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}-select-panel-title']");
        public static Element AddressUseEnteredBtn(int panelIndex) => new Element($"//button[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}-original-btn' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}-original-btn' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}-original-btn' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}-original-btn' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}-original-btn' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}-original-btn']");
        public static Element AddressUseSuggestedBtn(int panelIndex) => new Element($"//button[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}-suggested-btn' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}-suggested-btn' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}-suggested-btn' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}-suggested-btn' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}-suggested-btn' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}-suggested-btn']");
        private static SmartyStreetAddressElements AddressParts(int panelIndex) => new SmartyStreetAddressElements()
        {
            AddressLine1 = StreetAddressInput(panelIndex),
            AddressLine2 = ApartmentSuiteInput(panelIndex),
            City = CityInput(panelIndex),
            State = StateInput(panelIndex),
            ZipCode = ZipCodeInput(panelIndex),
            LoadingBar = CA_ReusableElements.AddressProgressBar,
            SuggestionBoxTitle = AddressSuggestionTitle(panelIndex),
            AsEnteredBtn = AddressUseEnteredBtn(panelIndex),
            SuggestedBtn = AddressUseSuggestedBtn(panelIndex)
        };
        public static InputSection VehicleContactAddressInput(int panelIndex) => new SmartyStreetsAddressInput(AddressParts(panelIndex))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, AI_MAX_WAIT);

        public static Element StreetAddressError(int panelIndex) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}']/mat-error[@data-qa='line1-error']"));
        public static Element ZipCodeError(int panelIndex) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}']/mat-error[@data-qa='postalCode-error']"));
        public static Element CityError(int panelIndex) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}']/mat-error[@data-qa='majorMunicipality-error']"));
        public static Element StateError(int panelIndex) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_VehicleOwner1Address_{panelIndex}' or @data-qa='_apollo_VehicleLienholder1Address_{panelIndex}' or @data-qa='_apollo_VehicleLessorAddress_{panelIndex}' or @data-qa='_apollo_TrailerOwner1Address_{panelIndex}' or @data-qa='_apollo_TrailerLienholder1Address_{panelIndex}' or @data-qa='_apollo_TrailerLessorAddress_{panelIndex}']/mat-error[@data-qa='stateProvince-error']"));

        //Provide the name and address of whomever you are leasing the vehicle from (lessor):
        public static Element LienholderContactDetailsQST(int panelIndex) => new Element(By.XPath($"//label[@data-qa='_apollo_VehicleLienholder1FirstName_{panelIndex}-label' or @data-qa='_apollo_TrailerLienholder1FirstName_{panelIndex}-label']"));
        public static Element LienholderNameTxtbox(int panelIndex) => new Element(By.XPath($"//input[@data-qa='_apollo_VehicleLienholder1FirstName_{panelIndex}' or @data-qa='_apollo_TrailerLienholder1FirstName_{panelIndex}']"));
        public static Element LienholderNameHelper(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonShowHelpToggle-_apollo_VehicleLienholder1FirstName_{panelIndex}' or @data-qa='buttonShowHelpToggle-_apollo_TrailerLienholder1FirstName_{panelIndex}']"));
        public static Element LienholderNameHelperText(int panelIndex) => new Element(By.XPath($"//p[@data-qa='bbHelpText-_apollo_VehicleLienholder1FirstName_{panelIndex}-label' or @data-qa='bbHelpText-_apollo_TrailerLienholder1FirstName_{panelIndex}-label']"));
        public static Element LienholderNameHelperX(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonClose-bbHelpText-_apollo_VehicleLienholder1FirstName_{panelIndex}' or @data-qa='buttonClose-bbHelpText-_apollo_TrailerLienholder1FirstName_{panelIndex}']"));
        public static Element LienholderNameError(int panelIndex) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_VehicleLienholder1FirstName_{panelIndex}-errorMessage' or @data-qa='_apollo_TrailerLienholder1FirstName_{panelIndex}-errorMessage']"));
        public static InputSection LienholderNameInput(int panelIndex) => new TextBoxInput(LienholderNameTxtbox(panelIndex))
            .AsAQuestion(LienholderContactDetailsQST(panelIndex))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, AI_MAX_WAIT);

        //Provide the name and address of whomever you are leasing the vehicle from (lessor):
        public static Element LessorContactDetailsQST(int panelIndex) => new Element(By.XPath($"//label[@data-qa='_apollo_VehicleLessorName_{panelIndex}-label' or @data-qa='_apollo_TrailerLessorName_{panelIndex}-label']"));
        public static Element LessorNameTxtbox(int panelIndex) => new Element(By.XPath($"//input[@data-qa='_apollo_VehicleLessorName_{panelIndex}' or @data-qa='_apollo_TrailerLessorName_{panelIndex}']"));
        public static Element LessorNameHelper(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonShowHelpToggle-_apollo_VehicleLessorName_{panelIndex}' or @data-qa='buttonShowHelpToggle-_apollo_TrailerLessorName_{panelIndex}']"));
        public static Element LessorNameHelperText(int panelIndex) => new Element(By.XPath($"//p[@data-qa='bbHelpText-_apollo_VehicleLessorName_{panelIndex}-label' or @data-qa='bbHelpText-_apollo_TrailerLessorName_{panelIndex}-label']"));
        public static Element LessorNameHelperX(int panelIndex) => new Element(By.XPath($"//button[@data-qa='buttonClose-bbHelpText-_apollo_VehicleLessorName_{panelIndex}' or @data-qa='buttonClose-bbHelpText-_apollo_TrailerLessorName_{panelIndex}']"));
        public static Element LessorNameError(int panelIndex) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_VehicleLessorName_{panelIndex}-errorMessage' or @data-qa='_apollo_TrailerLessorName_{panelIndex}-errorMessage']"));
        public static InputSection LessorNameInput(int panelIndex) => new TextBoxInput(LessorNameTxtbox(panelIndex))
            .AsAQuestion(LessorContactDetailsQST(panelIndex))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, AI_MAX_WAIT);
        
        /*
        * Page CTA----------------------------------------------------------
        */
        //Let's Continue
        public static Element ContinueToPurchaseCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

        //Back
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));
    }
}
