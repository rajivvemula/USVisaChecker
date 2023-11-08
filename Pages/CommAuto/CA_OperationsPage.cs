using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using OpenQA.Selenium;
using HitachiQA.Driver.Input;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Operations")]
    public sealed class CA_OperationsPage
    {
        public static LoadingRequirements LoadingRequirements =>
            new LoadingRequirements(YourOperationsTitle, NextWellNeedDetailsAboutBusiness);
        /*
        * Headers----------------------------------------------------------
        */

        //Your Operations
        public static Element YourOperationsTitle => new Element(By.XPath("//h1[@data-qa='Operations-label']"));
        public static Element NextWellNeedDetailsAboutBusiness => new Element(By.XPath("//p[@data-qa='Operations-sub-label']"));

        /*
        * Questions----------------------------------------------------------
        * questionAlias or alias: question.QuestionDefinition.Alias
        * answerValue: question.QuestionAnswer.AnswerValue
        */

        //Question Text
        public static Element GetQuestionText(string alias) => new Element($"//label[@data-qa='_apollo_{alias}-label']");

        //Error message
        public static Element GetErrorText(string questionAlias) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_{questionAlias}-errorMessage']/*[@data-qa='bb-error']"));

        //Help text
        public static Element GetHelpIcon(string questionAlias) => new Element(By.XPath($"//button[@data-qa='buttonShowHelpToggle-_apollo_{questionAlias}']"));
        public static Element GetHelpText(string questionAlias) => new Element(By.XPath($"//p[@data-qa='bbHelpText-_apollo_{questionAlias}-label']"));
        public static Element GetHelpX(string questionAlias) => new Element(By.XPath($"//button[@data-qa='buttonClose-bbHelpText-_apollo_{questionAlias}']"));

        // singleselection-buttons: button group
        // ex: What is the furthest any of your vehicles travel in any one direction from their home base?
        public static Element GetSSButton(string questionAlias, string answerValue) => new Element($"//button[starts-with(@data-qa, '_apollo_{questionAlias}') and contains(@data-qa, \"{answerValue}-button\")]");
        public static ChoiceGroup SingleSelectGroup(string questionAlias) => new ChoiceGroup(Functions.CreateSingleArgSelector(GetSSButton, questionAlias));
        public static InputSection GetSingleSelectInput(string questionAlias) =>
            new SingleChoiceGroupInput(SingleSelectGroup(questionAlias), ButtonSelectionPredicates.AngularSingleSelect)
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        // number-string: numeric textbox
        // ex: Enter the USDOT number (this is the only one of that kind)
        // text: textbox
        // ex: Enter your California Motor Carrier #: (this is the only one of that kind)
        // numeric: numeric textbox
        // ex: How many auto insurance claims did your business file in the last 3 years?
        public static Element GetTextBox(string alias) => new Element($"//input[@data-qa='_apollo_{alias}']");
        public static InputSection GetTextBoxInput(string questionAlias) =>
            new TextBoxInput(GetTextBox(questionAlias))
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        // boolean: yes/no buttons
        // ex: Do you haul intermodal containers?
        public static Element GetBooleanButton(string questionAlias, string yesOrNo) => new Element($"//button[starts-with(@data-qa, '_apollo_{questionAlias}') and contains(@data-qa, '{yesOrNo.ToLower()}-button')]");
        public static YesOrNoGroup BooleanGroup(string questionAlias) => new YesOrNoGroup(GetBooleanButton(questionAlias, "yes"), GetBooleanButton(questionAlias, "no"));
        public static InputSection GetBooleanInput(string questionAlias)
            => new YesOrNoInput(BooleanGroup(questionAlias), ButtonSelectionPredicates.AngularSingleSelect)
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);
        
        // multiselection: checkbox list
        // (This will be called iteratively if multiple fields are selected)
        // ex: Do you haul any of these? Check all that apply:
        public static Element GetMultiSelection(string questionAlias, string answerValue) => new Element($"(//ul[@data-qa='_apollo_{questionAlias}']//li[@data-qa='{answerValue}']/mat-checkbox)[1]");
        public static ChoiceGroup MultiSelectGroup(string questionAlias) => 
            new ChoiceGroup(Functions.CreateSingleArgSelector(GetMultiSelection, questionAlias))
                .MayAlreadyBeSelected();
        public static InputSection GetMultiSelectInput(string questionAlias) =>
            new MultiChoiceGroupInput(MultiSelectGroup(questionAlias))
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        // singleselection: dropdown
        // ex: What services do you provide?
        public static Element GetSingleSelectDD(string alias) => new Element($"//mat-select[@data-qa='_apollo_{alias}']");
        public static InputSection GetSingleSelectDropdownInput(string questionAlias) =>
            new MatDropdownInput(GetSingleSelectDD(questionAlias))
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        // checkbox-label: single checkbox toggle
        // ex: I agree to submit proof of insurance claims history, also known as loss
        // runs, for the last 3 years within 30 days of the effective date of the policy
        public static Element GetSoloCheckbox(string alias) => new Element(By.XPath($"(//mat-checkbox[@data-qa='_apollo_{alias}-checkbox']//input/..)[1]"));
        public static InputSection GetSoloCheckboxInput(string questionAlias) =>
            new MatCheckBoxToggleInput(GetSoloCheckbox(questionAlias))
                .AsAQuestion(GetQuestionText(questionAlias))
                .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);
        
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
        public static Element FirstErrorMsg => new Element(By.XPath("(//mat-error)[1]"));
    }
}
