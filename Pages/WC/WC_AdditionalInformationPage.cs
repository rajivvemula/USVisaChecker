using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using HitachiQA.Driver;
using OpenQA.Selenium;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Pages.WC
{
    [Binding]
    public class WC_AdditionalInformationPage
    {
        public static Element AdditionalInfoTitle => new Element(By.XPath("//div[@data-qa='add_info_header']"));
        public static Element AdditionalInfoSubTitle => new Element(By.XPath("//p[@data-qa='add_info_helptext']"));

        //Do you have a Federal Employer Identification Number (FEIN)?
        public static Element HaveFEIN => new Element(By.XPath("//label[@data-qa='add_info_FEIN_label']"));
        public static Element HaveFEINBTN_Yes => new Element(By.XPath("//label[contains(text(),'Do you have a Federal Employer Identification Number')]//following::button[text()='Yes']"));
        public static Element HaveFEINBTN_No => new Element(By.XPath("//label[contains(text(),'Do you have a Federal Employer Identification Number')]//following::button[text()='No']"));
        public static Element HaveFEINBTN_YesDisabled => new Element(By.XPath("//bb-options[@data-qa='add_info_FEIN_select']//button[@disabled.bind = 'disabled' and @class = 'au-target btn active' and text()='Yes']"));
        public static Element HaveFEINBTN_NoDisabled => new Element(By.XPath("//bb-options[@data-qa='add_info_FEIN_select']//button[@disabled.bind = 'disabled' and @class = 'au-target btn active' and text()='No']"));
        public static Element HaveFEINHelper => new Element(By.XPath("//bb-tooltip[@data-qa='add_info_FEIN']"));
       
        //What is your Federal Employer Identification Number (FEIN)?
        public static Element WhatIsFEIN => new Element(By.XPath("//label[@data-qa='add_info_FEIN_input_label']"));
        public static Element WhatIsFEINTxtbox => new Element(By.XPath("//bb-fein[@data-qa='add_info_FEIN_input']/input"));
        public static Element WhatIsFEINTxtbox_Disabled => new Element(By.XPath("//bb-fein[@data-qa='add_info_FEIN_input']/input//following-sibling::label"));
        public static Element FEINError => new Element(By.XPath($"//p[@data-qa='error-{WhatIsFEINTxtbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        //State Unemployment Insurance Number
        public static Element StateUnemploymentLabel => new Element(By.XPath("//label[@data-qa='add_info_state_unemployment_label']"));
        public static Element StateUnemploymentTxtBox => new Element(By.XPath("//input[@data-qa='add_info_state_unemployment_input']"));
        public static Element StateUnemploymentParagraph => new Element(By.XPath("//p[@data-qa='add_info_unemployment_blurb']"));
        public static Element StateUnemploymentError => new Element(By.XPath($"//p[@data-qa='error-{StateUnemploymentTxtBox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));
        public static InputSection StateUnemploymentInput =>
            new TextBoxInput(StateUnemploymentTxtBox)
            .AsAQuestion(StateUnemploymentLabel)
            .WithExtraText(StateUnemploymentParagraph);

        // If user doesn't have FEIN number
        public static Element WhatIsSSNLabel => new Element(By.XPath("//label[@data-qa='add_info_SSN_label']"));
        public static Element WhatIsSSNTextbox => new Element(By.XPath("//bb-ssn[@data-qa='add_info_SSN_input']/input"));
        public static Element WhatIsSSNTextbox_Disabled => new Element(By.XPath("//bb-ssn[@data-qa='add_info_SSN_input']/label"));
        public static Element WhatIsSSNError => new Element(By.XPath($"//p[@data-qa='error-{WhatIsSSNTextbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        //Excluded Officers Owners--------------------------------------------------------------------------------------------------------------
        public static Element ExcludedOfficersOwnersLabel => new Element(By.XPath("//p[@data-qa='ai_excluded_owner_officer_header']"));
        //If you can SET the first and last name of the OO
        public static Element ExcludedOfficersOwnersFirstNameLabel(string incExc, int num) => new Element(By.XPath($"//label[@data-qa='ai_{incExc}_oo_firstname_label_{num}']"));
        public static Element ExcludedOfficerOwnerFirstNameTextbox(string incExc, int num) => new Element(By.XPath($"//input[@data-qa='ai_{incExc}_oo_firstname_input_{num}']"));
        public static Element ExcludedFirstNameError(string incExc, int num) => new Element(By.XPath($"//p[@data-qa='error-{ExcludedOfficerOwnerFirstNameTextbox(incExc,num).GetAttribute("bb-validation-id")}']/preceding-sibling::p"));
        public static Element ExcludedOfficerOwnerLastNameLabel(string incExc, int num) => new Element(By.XPath($"//label[@data-qa='ai_{incExc}_oo_lastname_label_{num}']"));
        public static Element ExcludedOfficerOwnerLastNameTextbox(string incExc, int num) => new Element(By.XPath($"//input[@data-qa='ai_{incExc}_oo_lastname_input_{num}']"));
        public static Element ExcludedLastNameError(string incExc, int num) => new Element(By.XPath($"//p[@data-qa='error-{ExcludedOfficerOwnerLastNameTextbox(incExc,num).GetAttribute("bb-validation-id")}']/preceding-sibling::p"));
        //If the first name last name is already displayed for the OO
        public static Element ExcludedFullNameLabel(string incExc,int num) => new Element(By.XPath($"//strong[@data-qa='ai_{incExc}_oo_list_{num}']"));
        //Other Excluded Owner Officer Fields:
        public static Element ExcludedOfficerOwnerJobTitleLabel(string incExc, int num) => new Element(By.XPath($"//label[@data-qa='ai_{incExc}_oo_jobtitle_{num}']"));
        public static Element ExcludedOfficerOwnerJobTitleDD(string incExc, int num) => new Element(By.XPath($"//bb-select[@data-qa='ai_{incExc}_oo_jobtitle_dropdown_{num}']//select"));
        public static Element ExcludedOfficerJobTitleError(string incExc, int num) => new Element(By.XPath($"//p[@data-qa='error-{ExcludedOfficerOwnerJobTitleDD(incExc, num).GetAttribute("bb-validation-id")}']/preceding-sibling::p"));
        public static Element ExcludedOfficerOwnerDOBLabel(string incExc, int num) => new Element(By.XPath($"//label[@data-qa='ai_{incExc}_oo_DOB_{num}']"));
        public static Element ExcludedOfficerOwnerDOBInput(string incExc, int num) => new Element(By.XPath($"//input[@data-qa='ai_{incExc}_oo_DOB_dropdown_{num}_input']"));
        public static Element ExcludedOfficerDOBError(string incExc, int num) => new Element(By.XPath($"//p[@data-qa='error-{ExcludedOfficerOwnerDOBInput(incExc, num).GetAttribute("bb-validation-id")}']/preceding-sibling::p"));
        public static Element ExcludedOfficerSSNLabel(string incExc, int num) => new Element(By.XPath($"//label[@data-qa='ai_{incExc}_oo_SSN_{num}']"));
        public static Element ExcludedOfficerSSNTextbox(string incExc, int num) => new Element(By.XPath($"//bb-ssn[@data-qa='ai_{incExc}_oo_SSN_{num}']/input"));
        public static Element ExcludedOfficerSSNHelper(string incExc, int num) => new Element(By.XPath($"//label[@data-qa='ai_{incExc}_oo_SSN_{num}']/bb-tooltip/button"));
        public static Element ExcludedOfficerSSNHelperTxt(string incExc, int num) => new Element(By.XPath($"//label[@data-qa='ai_{incExc}_oo_SSN_{num}']/bb-tooltip/button[contains(@aria-describedby,'popover')]"));

        //Covered Owners and Officers----------------------------------------------------------------------------------------------------------
        //If you can SET the first and last name of the OO
        public static Element CoveredOwnersOfficersLabel => new Element(By.XPath("//p[@data-qa='ai_included_owner_officer_label']"));
        public static Element CoveredOwnersOfficersFirstNameLabel(int num) => new Element(By.XPath($"//label[@data-qa='ai_covered_oo_firstname_label_{num}']"));
        public static Element CoveredOwnerOfficerFirstNameTextBox(int num) => new Element(By.XPath($"//input[@data-qa='ai_covered_oo_firstname_input_{num}']"));
        public static Element CoveredFirstNameError(int num) => new Element(By.XPath($"//p[@data-qa='error-{CoveredOwnerOfficerFirstNameTextBox(num).GetAttribute("bb-validation-id")}']/preceding-sibling::p"));
        public static Element CoveredOwnerOfficerLastNameLabel(int num) => new Element(By.XPath($"//label[@data-qa='ai_covered_oo_lastname_label_{num}']"));
        public static Element CoveredOwnerOfficerLastNameTextBox(int num) => new Element(By.XPath($"//input[@data-qa='ai_covered_oo_lastname_input_{num}']"));
        public static Element CoveredLastNameError(int num) => new Element(By.XPath($"//p[@data-qa='error-{CoveredOwnerOfficerLastNameTextBox(num).GetAttribute("bb-validation-id")}']/preceding-sibling::p"));
        //Covered Owners and Officers (To be excluded due to bundle selected)
        //If the first name last name is already displayed for the OO
        public static Element CoveredIncludedOOLabel => new Element(By.XPath("//p[@data-qa='ai_included_owner_officer_label']"));
        //First Name Last Name populated on the page
        //example of text found within the element "Kirst Nast:"
        public static Element CoveredIncludedExcludedOOFullNameLabel(int num) => new Element(By.XPath($"//strong[@data-qa='ai_included_oo_list_{num}']"));
        //Job Duty populated on the page
        //example of text found within the element "Role: Contractor"
        public static Element CoveredIncludedExcludedOOJobLabel(int num) => new Element(By.XPath($"//span[@data-qa='ai_included_oo_role_{num}']"));

        public static Element ContinueToPurchaseCTA => new Element(By.XPath("//button[@data-qa='add_info_continue_purchase_button']/i"));
    }
}
