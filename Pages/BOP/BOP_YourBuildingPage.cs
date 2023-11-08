using OpenQA.Selenium;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using BiBerkLOB.Source.Driver;
using HitachiQA.Helpers;

namespace BiBerkLOB.Pages.BOP
{
    public class BOP_YourBuildingPage
    {
        //Header
        public static Element YourBuildingTitle => new Element(By.XPath("//h1[@data-qa='Buildings-label']"));
        public static Element YourBuildingSubTitle => new Element(By.XPath("//h6[@data-qa='Buildings-sub-label']"));

        //Expanded Building Panel (click after it is fully filled out)
        public static Element ExpandedBuildingPanel => new Element(By.XPath("BUILDING-expansion-panel-label"));

        /*
         * Business Address-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */

        //Street Address
        public static Element BusinessAddressLabel => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_BuildingLocationAddress')])[last()]"));
        public static Element StreeAddressInput => new Element(By.XPath("(//input[starts-with(@data-qa,'_apollo_BuildingLocationAddress')and contains(@data-qa,'line1')])[last()]"));
        public static Element StreetAddressError => new Element(By.XPath("(//mat-error[starts-with(@data-qa,'line1-error')])[last()]"));                                                                                                         

        //Apartment, Suite, etc.
        public static Element ApartmentTxtBox => new Element(By.XPath("(//input[starts-with(@data-qa,'_apollo_BuildingLocationAddress') and contains(@data-qa,'line2')])[last()]"));

        //Zip
        public static Element ZipTextBox => new Element(By.XPath("(//input[starts-with(@data-qa,'_apollo_BuildingLocationAddress') and contains(@data-qa,'postalCode-zipcode')])[last()]"));
        public static Element ZipTextBoxError => new Element(By.XPath("(//mat-error[@data-qa='postalCode-error'])[last()]"));

        //City
        public static Element CityTextBox => new Element(By.XPath("(//input[starts-with(@data-qa,'_apollo_BuildingLocationAddress') and contains(@data-qa,'majorMunicipality-city')])[last()]"));
        public static Element CityTextBoxError => new Element(By.XPath("(//mat-error[@data-qa='majorMunicipality-error'])[last()]"));

        //State
        public static Element StateDD => new Element(By.XPath("(//mat-select[starts-with(@data-qa,'_apollo_BuildingLocationAddress') and contains(@data-qa,'stateProvince-state')])[last()]"));
        public static Element StateDDError => new Element(By.XPath("(//mat-error[@data-qa='stateProvince-error'])[last()]"));

        /*
        * Questions----------------------------------------------------------
        * questionAlias or alias: question.QuestionDefinition.Alias
        * answerValue: question.QuestionAnswer.AnswerValue
        */

        //Question Text
        public static Element GetQuestionText(string alias) => new Element($"(//label[starts-with(@data-qa,'_apollo_{alias}')])[last()]");

        //Error message
        public static Element GetErrorText(string questionAlias) => new Element(By.XPath($"(//bb-error-message[starts-with(@data-qa,'_apollo_{questionAlias}')])[last()]"));

        //Help text
        public static Element GetHelpIcon(string questionAlias) => new Element(By.XPath($"(//button[starts-with(@data-qa, 'buttonShowHelpToggle-_apollo_{questionAlias}')])[last()]"));
        public static Element GetHelpText(string questionAlias) => new Element(By.XPath($"(//p[starts-with(@data-qa, 'bbHelpText-_apollo_{questionAlias}')])[last()]"));
        public static Element GetHelpX(string questionAlias) => new Element(By.XPath($"(//button[starts-with(@data-qa, 'buttonClose-bbHelpText-_apollo_{questionAlias}')])[last()]"));

        // text: textbox
        // ex: Please describe the other businesses in your building
        // numeric: numeric textbox
        // ex: What is the total square footage of your building?
        public static Element GetTextBox(string alias) => new Element($"(//input[starts-with(@data-qa,'_apollo_{alias}')])[last()]");
        public static InputSection GetTextBoxInput(string questionAlias) =>
            new TextBoxInput(GetTextBox(questionAlias))
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(BOP_ResusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        // boolean: yes/no buttons
        // ex: Is there a smoke/fire alarm on each floor of the building?
        public static Element GetBooleanButton(string questionAlias, string yesOrNo) => new Element($"(//button[starts-with(@data-qa, '_apollo_{questionAlias}') and contains(@data-qa, '{yesOrNo.ToLower()}-button')])[last()]");
        public static YesOrNoGroup BooleanGroup(string questionAlias) => new YesOrNoGroup(GetBooleanButton(questionAlias, "yes"), GetBooleanButton(questionAlias, "no"));
        public static InputSection GetBooleanInput(string questionAlias)
            => new YesOrNoInput(BooleanGroup(questionAlias), ButtonSelectionPredicates.AngularSingleSelect)
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(BOP_ResusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        // singleselection: dropdown
        // ex: What services do you provide?
        public static Element GetSingleSelectDD(string alias) => new Element($"(//mat-select[starts-with(@data-qa,'_apollo_{alias}')])[last()])");
        public static InputSection GetSingleSelectDropdownInput(string questionAlias) =>
            new MatDropdownInput(GetSingleSelectDD(questionAlias))
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(BOP_ResusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        // checkbox-label: single checkbox toggle
        // ex: Your insurance may be invalidated if you fail to keep these protective devices in working order or fail to notify us if their functioning becomes
        // impaired or suspended. Please check the box below to indicate you understand these requirements.
        public static Element GetSoloCheckbox(string alias) => new Element(By.XPath($"(//mat-checkbox[starts-with(@data-qa, '_apollo_{alias}')]//input)[last()]"));
        public static InputSection GetSoloCheckboxInput(string questionAlias) =>
            new MatCheckBoxToggleInput(GetSoloCheckbox(questionAlias))
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(BOP_ResusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        // multiselection: checkbox list
        // (This will be called iteratively if multiple fields are selected)
        // ex: Please select what type(s) of businesses occupy your building. Check all that apply.
        public static Element GetMultiSelection(string questionAlias, string answerValue) => new Element($"(//ul[starts-with(@data-qa,'_apollo_{questionAlias}')]//li[(@data-qa='{answerValue}')]/mat-checkbox)[last()]");
        public static ChoiceGroup MultiSelectGroup(string questionAlias) =>
            new ChoiceGroup(Functions.CreateSingleArgSelector(GetMultiSelection, questionAlias))
                .MayAlreadyBeSelected();
        public static InputSection GetMultiSelectInput(string questionAlias) =>
            new MultiChoiceGroupInput(MultiSelectGroup(questionAlias))
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(BOP_ResusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        // singleselection-buttons: button group
        // ex: Which of the following best describes how your building is constructed?
        public static Element GetSSButton(string questionAlias, string answerValue) => new Element($"//button[starts-with(@data-qa, '_apollo_{questionAlias}') and contains(@data-qa, \"{answerValue}-button\")]");
        
        //data driven selection domain 
        //answer choices will be puled from Apollo and will be implemented on a later stage
        public static SelectionDomain SSChoiceDomain(string[] answerChoices) => new SelectionDomain(answerChoices);
        public static ChoiceGroup SingleSelectGroup(string questionAlias, string[] answerChoices) => new ChoiceGroup(Functions.CreateSingleArgSelector(GetSSButton, questionAlias), SSChoiceDomain(answerChoices));
        public static InputSection GetSingleSelectInput(string questionAlias, string[] answerChoices) =>
            new SingleChoiceGroupInput(SingleSelectGroup(questionAlias, answerChoices), ButtonSelectionPredicates.AngularSingleSelect)
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(BOP_ResusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);


        //Remove Building button
        public static Element RemoveButton => new Element(By.XPath("//bb-remove-panel[@data-qa='BUILDING-Remove-button']/button"));

        //Please fix the following error(s) before proceeding:
        public static Element PleaseFixErrors => new Element(By.XPath("//div[@data-qa='bbnav-error-title']"));
        public static Element OneOrMoreInvalid => new Element(By.XPath("//div[@data-qa='bbnav-error-message']"));

        /*
        * Page CTA----------------------------------------------------------
        */

        //Add Another Building
        public static Element AddAnotherBuildingButton => new Element(By.XPath("//bb-add-panel[@data-qa='Building-addPanel']/button"));
    }
}
