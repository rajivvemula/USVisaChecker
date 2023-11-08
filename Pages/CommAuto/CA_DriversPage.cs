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
    [Mapping("CA Drivers")]
    public sealed class CA_DriversPage
    {
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(DriversTitle, DriversSubTitle);
        /*
        * Headers----------------------------------------------------------
        */

        //Driver
        public static Element DriversTitle => new Element(By.XPath("//h1[@data-qa='Drivers-label']"));
        //Now we need a little information about your drivers.
        public static Element DriversSubTitle => new Element(By.XPath("//p[@data-qa='Drivers-sub-label']"));

        /*
        * Questions----------------------------------------------------------
        */
        //First Name
        public static Element FirstNameQST(int index) => new Element(By.XPath($"//label[@data-qa='Drivers-{index}-firstName-label']"));
        public static Element FirstNameTxtBox(int index) => new Element(By.XPath($"//input[@data-qa='Drivers-{index}-firstName']"));
        public static InputSection FirstNameInput(int index) => new TextBoxInput(FirstNameTxtBox(index))
            .AsAQuestion(FirstNameQST(index));

        //Last Name
        public static Element LastNameQST(int index) => new Element(By.XPath($"//label[@data-qa='Drivers-{index}-lastName-label']"));
        public static Element LastNameTxtBox(int index) => new Element(By.XPath($"//input[@data-qa='Drivers-{index}-lastName']"));
        public static InputSection LastNameInput(int index) => new TextBoxInput(LastNameTxtBox(index))
            .AsAQuestion(LastNameQST(index));

        //Driver's License State
        public static Element DriversLicenseStateQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverLicenseState_{index}-label']"));
        public static Element DriversLicenseStateDD(int index) => new Element(By.XPath($"//mat-select[@data-qa='_apollo_DriverLicenseState_{index}']"));
        public static InputSection DriversLicenseStateInput(int index) => new MatDropdownInput(DriversLicenseStateDD(index))
            .AsAQuestion(DriversLicenseStateQST(index));

        //Date of Birth
        public static Element DOBQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverDOB_{index}-label']"));
        public static Element DOBTxtBox(int index) => new Element(By.XPath($"//input[@data-qa='_apollo_DriverDOB_{index}']"));
        public static InputSection DOBInput(int index) => new DatePickerInput(new TextEnterDatePicker(DOBTxtBox(index), true))
            .AsAQuestion(DOBQST(index));

        //Does this driver have a Commercial Driver's License (CDL)?
        public static Element DriverHaveCDLQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_CDL_{index}-label']"));
        public static Element DriverHaveCDLNo(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_CDL_{index}') and contains(@data-qa,'-0-button')]"));
        public static Element DriverHaveCDLLessThanOneYr(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_CDL_{index}') and contains(@data-qa,'-1-button')]"));
        public static Element DriverHaveCDLOneToTwo(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_CDL_{index}') and contains(@data-qa,'-2-button')]"));
        public static Element DriverHaveCDLThreeOrMore(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_CDL_{index}') and contains(@data-qa,'-3-button')]"));
        private static Dictionary<string, Element> DriverHaveCDLChoices(int index) => new Dictionary<string, Element>()
        {
            { "No", DriverHaveCDLNo(index) },
            { "Yes less than 1 year", DriverHaveCDLLessThanOneYr(index) },
            { "Yes 1 to 2 years", DriverHaveCDLOneToTwo(index) },
            { "Yes 3 or more years", DriverHaveCDLThreeOrMore(index) }
        };
        public static ChoiceGroup DriverHaveCDLGroup(int index) => new ChoiceGroup(DriverHaveCDLChoices(index));
        public static InputSection DriverHaveCDLInput(int index) => new SingleChoiceGroupInput(DriverHaveCDLGroup(index), ButtonSelectionPredicates.AngularSingleSelect)
            .AsAQuestion(DriverHaveCDLQST(index))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);


        //NSC Defensive Driving Course
        public static Element NSCDDCourseQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_IL-DefensiveDriving_{index}-label']"));
        public static Element NSCDDCourseYes(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_IL-DefensiveDriving_{index}') and contains(@data-qa,'yes-button')]"));
        public static Element NSCDDCourseNo(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_IL-DefensiveDriving_{index}') and contains(@data-qa,'no-button')]"));
        public static InputSection NSCDDCourseInput(int index) => new YesOrNoInput(NSCDDCourseYes(index), NSCDDCourseNo(index), ButtonSelectionPredicates.AngularSingleSelect)
            .AsAQuestion(NSCDDCourseQST(index));

        //Illinois motor vehicle laws violations
        public static Element ILViolationQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_IL-LastYearViolation_{index}-label']"));
        public static Element ILViolationYes(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_IL-LastYearViolation_{index}') and contains(@data-qa,'yes')]"));
        public static Element ILViolationNo(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_IL-LastYearViolation_{index}') and contains(@data-qa,'no')]"));
        public static InputSection ILViolationInput(int index) => new YesOrNoInput(ILViolationYes(index), ILViolationNo(index), ButtonSelectionPredicates.AngularSingleSelect)
            .AsAQuestion(ILViolationQST(index));

        //Illinois Driver License revoked/suspended
        public static Element ILDLRevokedQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_IL-Last3YearsLicenseSuspended_{index}-label']"));
        public static Element ILDLRevokedYes(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_IL-Last3YearsLicenseSuspended_{index}') and contains(@data-qa,'yes')]"));
        public static Element ILDLRevokedNo(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_IL-Last3YearsLicenseSuspended_{index}') and contains(@data-qa,'no')]"));
        public static InputSection ILDLRevokedInput(int index) => new YesOrNoInput(ILDLRevokedYes(index), ILDLRevokedNo(index), ButtonSelectionPredicates.AngularSingleSelect)
            .AsAQuestion(ILDLRevokedQST(index));

        //Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years?
        public static Element DriverHaveAccidentOrViolationQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_AccidentOrViolation_{index}-label'] "));
        public static Element DriverHaveAccidentOrViolationYes(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_AccidentOrViolation_{index}') and contains(@data-qa,'yes')]"));
        public static Element DriverHaveAccidentOrViolationNo(int index) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_AccidentOrViolation_{index}') and contains(@data-qa,'no')]"));
        public static Element DriverHaveAccidentOrViolationTextBelow(int index) => new Element(By.XPath($"//mat-hint[@data-qa='_apollo_AccidentOrViolation_{index}-hint']"));
        public static InputSection DriverHaveAccidentOrViolationInput(int index) => new YesOrNoInput(DriverHaveAccidentOrViolationYes(index), DriverHaveAccidentOrViolationNo(index), ButtonSelectionPredicates.AngularSingleSelect)
            .AsAQuestion(DriverHaveAccidentOrViolationQST(index))
            .WithExtraText(DriverHaveAccidentOrViolationTextBelow(index))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Driver's License Number
        public static Element DriversLicenseNumberQST(string state, int index) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverLicenseNumber_{state}_{index}-label']"));
        public static Element DriversLicenseNumberTxtBox(string state, int index) => new Element(By.XPath($"//input[@data-qa='_apollo_DriverLicenseNumber_{state}_{index}']"));
        public static InputSection DriversLicenseNumberInput(string state, int index) => new TextBoxInput(DriversLicenseNumberTxtBox(state, index))
            .AsAQuestion(DriversLicenseNumberQST(state, index))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Add Another Driver
        public static Element AddAnotherDriverButton => new Element(By.XPath("//div/bb-add-panel[@data-qa='Driver-addPanel']/button"));

        //Remove Driver
        public static Element RemoveButton => new Element(By.XPath("//bb-remove-panel[@data-qa='DRIVER-Remove-button']"));
        
        // front end help and error text
        public static Element GetFrontEndErrorText(string questionAlias, int index) => new Element(By.XPath($"//bb-expansion-panel[{index+1}]//mat-error[@data-qa='{questionAlias}-error']"));
        public static Element GetFrontEndHelpIcon(string questionAlias, int index) => new Element(By.XPath($"//button[@data-qa,'buttonShowHelpToggle-{questionAlias}-{index}']"));
        public static Element GetFrontEndHelpText(string questionAlias, int index) => new Element(By.XPath($"//bb-helptext//p[@data-qa='bbHelpText-{questionAlias}-{index}-label']"));
        public static Element GetFrontEndHelpExit(string questionAlias, int index) => new Element(By.XPath($"//button[@data-qa='buttonClose-bbHelpText-{questionAlias}-{index}']"));

        // apollo help and error text
        public static Element GetApolloErrorText(string questionAlias, int index) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_{questionAlias}_{index}-errorMessage']"));
        public static Element GetApolloHelpIcon(string questionAlias, int index) => new Element(By.XPath($"//button[@data-qa='buttonShowHelpToggle-_apollo_{questionAlias}_{index}']"));
        public static Element GetApolloHelpText(string questionAlias, int index) => new Element(By.XPath($"//bb-helptext//p[@data-qa='bbHelpText-_apollo_{questionAlias}_{index}-label']"));
        public static Element GetApolloHelpExit(string questionAlias, int index) => new Element(By.XPath($"//bb-helptext//button[@data-qa='buttonClose-bbHelpText-_apollo_{questionAlias}_{index}']"));

        //Please fix the following error(s) before proceeding:
        public static Element PleaseFixErrors => new Element(By.XPath("//div[@data-qa='bbnav-error-title']"));
        public static Element OneOrMoreInvalid => new Element(By.XPath("//div[@data-qa='bbnav-error-message']"));
        /*
        * Page CTA----------------------------------------------------------
        */

        //Back
        public static Element BackCTA => new Element(By.XPath("//div/button[@data-qa='bbnav-navBack']"));

        //Let's Continue
        public static Element LetsContinueCTA => new Element(By.XPath("//div/button[@data-qa='bbnav-navNext-tablet']"));
    }
}