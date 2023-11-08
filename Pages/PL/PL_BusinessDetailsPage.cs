using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using BiBerkLOB.Components.PL;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public sealed class PL_BusinessDetailsPage :Reusable_PurchasePath
    {
        public static Element BusinessDetails => new Element(By.XPath("//h1[@data-qa='business-details-header']"));
        //Next we'll need a few more details about your business.
        public static Element BusinessDetailsSubtitle => new Element(By.XPath("//h6[@data-qa='business-details-subheader']"));
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(Reusable_PurchasePath.YourPLQuoteID, BusinessDetails, BusinessDetailsSubtitle);

        //What year was your business started?
        public static Element WhatYearBusStartQstTxt => new Element(By.XPath("//span[@data-qa='business-start-year-label']"));
        public static Element WhatYearBusStartTxtbox => new Element(By.XPath("//md-input[@data-qa='business-start-year-input']/div/input"));
        public static Element WhatYearBusStartTextBelow => new Element(By.XPath("//span[@data-qa='business-year-helptext']"));
        public static Element WhatYearBusStartError => new Element(By.XPath("//span[@data-qa='business-start-year-input-validation-error']"));
        public static Element WhatYearBusStartHelper => new Element(By.XPath("//i[@data-qa='business-start-year-help-icon']"));
        public static Element WhatYearBusStartHelperText => new Element(By.XPath("//div[@data-qa='business-start-year-help-text']"));
        public static Element WhatYearBusStartHelperX => new Element(By.XPath("//i[@data-qa='business-start-year-help-text-close-icon']"));
        public static InputSection WhatYearBusStartQuestion =>
            new TextBoxInput(WhatYearBusStartTxtbox)
                .AsAQuestion(WhatYearBusStartQstTxt)
                .WithExtraText(WhatYearBusStartTextBelow)
                .WithHelpText(WhatYearBusStartHelper, WhatYearBusStartHelperText, WhatYearBusStartHelperX);

        //What is your estimated gross annual revenue?
        public static Element EstGrossRevQstTxt => new Element(By.XPath("//span[@data-qa='question-33703-label']"));
        public static Element EstGrossRevTxtbox => new Element(By.XPath("//md-input[@data-qa='gross-revenue-input']//input"));
        public static Element EstGrossRevTextBelow => new Element(By.XPath("//span[@data-qa='33703-validation-text']"));
        public static Element EstGrossRevError => new Element(By.XPath("//span[@data-qa='gross-revenue-input-validation-error']"));
        public static Element EstGrossRevHelper => new Element(By.XPath("//i[@data-qa='question-33703-help-icon']"));
        public static Element EstGrossRevHelperText => new Element(By.XPath("//div[@data-qa='question-33703-help-text']"));
        public static Element EstGrossRevHelperX => new Element(By.XPath("//i[@data-qa='question-33703-help-text-close-icon']"));
        public static InputSection EstGrossRevQuestion => 
            new TextBoxInput(EstGrossRevTxtbox)
                .AsAQuestion(EstGrossRevQstTxt)
                .WithExtraText(EstGrossRevTextBelow)
                .WithHelpText(EstGrossRevHelper, EstGrossRevHelperText, EstGrossRevHelperX);

        //Do you use a written contract or statement of work (SOW)?
        public static Element UseSOWQstTxt => new Element(By.XPath("//span[@data-qa='question-33727-label']"));
        public static Element UseSOWBTN_Always => new Element(By.XPath("//label[@data-qa='33727Always']"));
        public static Element UseSOWBTN_Sometimes => new Element(By.XPath("//label[@data-qa='33727Sometimes']"));
        public static Element UseSOWBTN_Never => new Element(By.XPath("//label[@data-qa='33727Never']"));
        public static ChoiceGroup UseSOWBTNGroup => new ChoiceGroup(new Dictionary<string, Element>()
        {
            {"Always", UseSOWBTN_Always},
            {"Sometimes", UseSOWBTN_Sometimes},
            {"Never", UseSOWBTN_Never}
        });
        public static Element UseSOWHelper => new Element(By.XPath("//i[@data-qa='question-33727-help-icon']"));
        public static Element UseSOWHelperText => new Element(By.XPath("//div[@data-qa='question-33727-help-text']"));
        public static Element UseSOWHelperX => new Element(By.XPath("//i[@data-qa='question-33727-help-text-close-icon']"));
        public static Element UseSOWError => new Element(By.XPath("//span[@data-qa='33727-button-validation-error']"));
        public static InputSection UseSOWQuestion => 
            new SingleChoiceGroupInput(UseSOWBTNGroup)
                .AsAQuestion(UseSOWQstTxt)
                .WithHelpText(UseSOWHelper, UseSOWHelperText, UseSOWHelperX);

        //How many attorneys does your firm have?
        public static Element HowManyAttorneysQstTxt => new Element(By.XPath("//span[@data-qa='question-33710-label']"));
        public static Element HowManyAttorneysTxtbox => new Element(By.XPath("//md-input[@data-qa='on-staff-attorney-input']//input"));
        public static Element HowManyAttorneysTextBelow => new Element(By.XPath("//span[@data-qa='33710-validation-text']"));
        public static Element HowManyAttorneysError => new Element(By.XPath("//span[@data-qa='on-staff-attorney-input-validation-error']"));

        public static InputSection HowManyAttorneysQuestion =>
            new TextBoxInput(HowManyAttorneysTxtbox)
                .AsAQuestion(HowManyAttorneysQstTxt)
                .WithExtraText(HowManyAttorneysTextBelow);

        //Do you use any of counsel or independent contractor attorneys?
        public static Element UseCounselOrIndepContrAttorneysQstTxt => new Element(By.XPath("//span[@data-qa='question-33692-label']"));
        public static Element UseCounselOrIndepContrAttorneyszBTN_Yes => new Element(By.XPath("//label[@data-qa='33692Yes']"));
        public static Element UseCounselOrIndepContrAttorneysBTN_No => new Element(By.XPath("//label[@data-qa='33692No']"));
        public static YesOrNoGroup UseCounselIndepContrAttorneysBTNGroup => new YesOrNoGroup(UseCounselOrIndepContrAttorneyszBTN_Yes, UseCounselOrIndepContrAttorneysBTN_No);
        public static Element UseCounselOrIndepContrAttorneysHelper => new Element(By.XPath("//i[@data-qa='question-33692-help-icon']"));
        public static Element UseCounselOrIndepContrAttorneysHelperText => new Element(By.XPath("//div[@data-qa='question-33692-help-text']"));
        public static Element UseCounselOrIndepContrAttorneysHelperX => new Element(By.XPath("//i[@data-qa='question-33692-help-text-close-icon']"));
        public static Element UseCounselOrIndepContrAttorneysError => new Element(By.XPath("//span[@data-qa='33692-button-validation-error']"));
        public static InputSection UseCounselOrIndepContrAttorneysQuestion =>
            new YesOrNoInput(UseCounselIndepContrAttorneysBTNGroup)
                .AsAQuestion(UseCounselOrIndepContrAttorneysQstTxt)
                .WithHelpText(UseCounselOrIndepContrAttorneysHelper, UseCounselOrIndepContrAttorneysHelperText, UseCounselOrIndepContrAttorneysHelperX);

        //Number of full-time counsel/independent contractor attorneys:
        public static Element FullTimeCounselIndepContrAttorneysQstTxt => new Element(By.XPath("//span[@data-qa='question-33702-label']"));
        public static Element FullTimeCounselIndepContrAttorneysTxtbox => new Element(By.XPath("//md-input[@data-qa='fulltime-attorney-input']/div/input"));
        public static Element FullTimeCounselIndepContrAttorneysError => new Element(By.XPath("//span[@data-qa='fulltime-attorney-input-validation-error']"));
        public static InputSection FullTimeCounselIndepContrAttorneysQuestion => 
            new TextBoxInput(FullTimeCounselIndepContrAttorneysTxtbox)
                .AsAQuestion(FullTimeCounselIndepContrAttorneysQstTxt);

        //Number of part-time counsel/independent contractor attorneys:
        public static Element PartTimeCounselIndepContrAttorneysQstTxt => new Element(By.XPath("//span[@data-qa='question-33712-label']"));
        public static Element PartTimeCounselIndepContrAttorneysTxtbox => new Element(By.XPath("//md-input[@data-qa='parttime-attorney-input']/div/input"));
        public static Element PartTimeCounselIndepContrAttorneysTextBelow => new Element(By.XPath("//span[@data-qa='33712-validation-text']"));
        public static Element PartTimeCounselIndepContrAttorneysError => new Element(By.XPath("//span[@data-qa='parttime-attorney-input-validation-error']"));
        public static InputSection PartTimeCounselIndepContrAttorneysQuestion =>
            new TextBoxInput(PartTimeCounselIndepContrAttorneysTxtbox)
                .AsAQuestion(PartTimeCounselIndepContrAttorneysQstTxt)
                .WithExtraText(PartTimeCounselIndepContrAttorneysTextBelow);

        //Who signs off on the terms & conditions for written contracts or statements of work (SOW)?
        public static Element WhoSignsSOWQstTxt => new Element(By.XPath("//span[@data-qa='question-33694-label']"));
        public static Element WhoSignsSOWBTN_Outside => new Element(By.XPath("//label[@data-qa='33694Outside Legal Counsel']"));
        public static Element WhoSignsSOWBTN_InHouse => new Element(By.XPath("//label[@data-qa='33694Inhouse Legal Counsel']"));
        public static Element WhoSignsSOWBTN_Legal => new Element(By.XPath("//label[@data-qa='33694Legal Counsel is not required']"));
        public static ChoiceGroup WhoSignsSOWBTNGroup => new ChoiceGroup(new Dictionary<string, Element>()
        {
            { "Outside", WhoSignsSOWBTN_Outside },
            { "In House", WhoSignsSOWBTN_InHouse },
            { "Legal", WhoSignsSOWBTN_Legal }
        });
        public static Element WhoSignsSOWHelper => new Element(By.XPath("//i[@data-qa='question-33694-help-icon']"));
        public static Element WhoSignsSOWHelperText => new Element(By.XPath("//div[@data-qa='question-33694-help-text']"));
        public static Element WhoSignsSOWHelperX => new Element(By.XPath("//i[@data-qa='question-33694-help-text-close-icon']"));
        public static Element WhoSignsSOWError => new Element(By.XPath("//span[@data-qa='33694-button-validation-error']"));
        public static InputSection WhoSignsSOWQuestion =>
            new SingleChoiceGroupInput(WhoSignsSOWBTNGroup)
                .AsAQuestion(WhoSignsSOWQstTxt)
                .WithHelpText(WhoSignsSOWHelper, WhoSignsSOWHelperText, WhoSignsSOWHelperX);

        //How many healthcare professionals work for your business?
        public static Element HowManyHealthProfQstTxt => new Element(By.XPath("//span[@data-qa='question-39558-label']"));
        public static Element HowManyHealthProfTxtbox => new Element(By.XPath("//md-input[@data-qa='number-healthcare-professionals-input']/div/input"));
        public static Element HowManyHealthProfHelper => new Element(By.XPath("//i[@data-qa='question-39558-help-icon']"));
        public static Element HowManyHealthProfHelperText => new Element(By.XPath("//div[@data-qa='question-39558-help-text']"));
        public static Element HowManyHealthProfHelperText_X => new Element(By.XPath("//i[@data-qa='question-39558-help-text-close-icon']"));
        public static InputSection HowManyHealthProfQuestion =>
            new TextBoxInput(HowManyHealthProfTxtbox)
                .AsAQuestion(HowManyHealthProfQstTxt)
                .WithHelpText(HowManyHealthProfHelper, HowManyHealthProfHelperText, HowManyHealthProfHelperText_X);

        //Do any health students work for your business?
        public static Element AnyHealthStudentsQstTxt => new Element(By.XPath("//span[@data-qa='question-39550-label']"));
        public static Element AnyHealthStudents_No => new Element(By.XPath("//label[@data-qa='39550No']"));
        public static Element AnyHealthStudents_Yes => new Element(By.XPath("//label[@data-qa='39550Yes']"));
        public static YesOrNoGroup AnyHealthStudentsGroup => new YesOrNoGroup(AnyHealthStudents_Yes, AnyHealthStudents_No);
        public static InputSection AnyHealthStudentsQuestion => 
            new YesOrNoInput(AnyHealthStudentsGroup)
                .AsAQuestion(AnyHealthStudentsQstTxt);

        public static Element HealthStudentsNumQstTxt => new Element(By.XPath("//span[@data-qa='question-39559-label']"));
        public static Element HealthStudentsNumInput => new Element(By.XPath("//md-input[@data-qa='num-healthcare-students-input']/div/input"));
        public static InputSection HealthStudentsNumQuestion => 
            new TextBoxInput(HealthStudentsNumInput)
                .AsAQuestion(HealthStudentsNumQstTxt);
        public static YesNoGatedNumericQuestion AnyHealthStudentSection =>
            new YesNoGatedNumericQuestionBuilder(AnyHealthStudentsQuestion, HealthStudentsNumQuestion)
                .Build();
        
        //Do you work as an independent contractor (paid via 1099) or as an employee of a health organization (paid via W-2)?
        public static Element ContractorOrEmployeeQstTxt => new Element(By.XPath("//span[@data-qa='question-39551-label']"));
        public static Element IndependentContractor => new Element(By.XPath("//label[@data-qa='39551Independent Contractor']"));
        public static Element EmployeeOfHealthOrg => new Element(By.XPath("//label[@data-qa='39551Employee of Health Organization']"));
        public static ChoiceGroup ContractorOrEmployeeChoiceGroup => new ChoiceGroup(new Dictionary<string, Element>()
        {
            { "Independent Contractor", IndependentContractor },
            { "Employee of Health Organization", EmployeeOfHealthOrg }
        });
        public static InputSection ContractorOrEmployeeQuestion =>
            new SingleChoiceGroupInput(ContractorOrEmployeeChoiceGroup)
                .AsAQuestion(ContractorOrEmployeeQstTxt);

        //Have you obtained this professional healthcare designation within the last two years?
        public static Element HealthCareDesignationQstTxt => new Element(By.XPath("//span[@data-qa='question-39552-label']"));
        public static Element HCD_Yes => new Element(By.XPath("//label[@data-qa='39552Yes']"));
        public static Element HCD_No => new Element(By.XPath("//label[@data-qa='39552No']"));
        public static YesOrNoGroup HealthCareDesignationGroup => new YesOrNoGroup(HCD_Yes, HCD_No);
        public static InputSection HealthCareDesignationQuestion =>
            new YesOrNoInput(HealthCareDesignationGroup)
                .AsAQuestion(HealthCareDesignationQstTxt);

        //When did you graduate or obtain this designation?
        public static Element HCDesignationDateQstTxt => new Element(By.XPath("//span[@data-qa='healthcare-designation-date-label']"));
        public static IDatePicker HCDesignationDateInput => new PL_DatePicker("When did you graduate or obtain this designation?");
        public static InputSection HCDesignationDateQuestion => 
            new DatePickerInput(HCDesignationDateInput)
                .AsAQuestion(HCDesignationDateQstTxt);

        /*
        * Page CTAs
        */
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='back-to-introduction-button']"));
        public static Element LetsContinueCTA => new Element(By.XPath("//button[@data-qa='business-details-validate-button']"));

        // Save for later
        public static Element QuoteRibbonSaveButton => new Element(By.XPath("//a[contains(text(),'Save')]"));
        public static Element EmailInput => new Element(By.XPath("//input[@class='input']"));
        public static Element GetMyLinkButton => new Element(By.XPath("//button[@data-qa='sfl-link-button']"));
        public static Element QuoteRibbonNeedToFinishLater => new Element(By.XPath("//h6[contains(text(),'Need to finish later?')]"));
        public static Element EmailConfirmationPopUpByText(string text) => new Element(By.XPath($"//div[@id='toast-container']/div[text()='{text}']"));
    }
}