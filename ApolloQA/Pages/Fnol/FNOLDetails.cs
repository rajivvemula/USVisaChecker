using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Fnol
{
    class FNOLDetails
    {
        private IWebDriver fnolDriver;
        private Functions functions;

        public FNOLDetails(IWebDriver driver)
        {
            fnolDriver = driver;
            functions = new Functions(driver);
        }

        //Checkboxes
        public IWebElement checkboxFirstParty => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='First Party']"));
        public IWebElement checkboxThirdParty => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Third Party']"));
        public IWebElement checkboxBodilyInjury => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Bodily Injury']"));
        public IWebElement checkboxPropertyDamage => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Property Damage']"));
        public IWebElement checkboxInsured => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Insured']"));
        public IWebElement checkboxNotInsuredIndividual => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Not Insured - Individual']"));
        public IWebElement checkboxNotInsuredBusiness => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Not Insured - Business']"));
        public IWebElement checkboxVehicle => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Vehicle on Policy']"));
        public IWebElement checkboxVehicleNot => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Vehicle Not on Policy']"));
        public IWebElement checkboxDriverOnPolicy => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Driver on Policy']"));
        public IWebElement checkboxDriverNotOnPolicy => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Driver Not on Policy']"));
        public IWebElement checkboxNoDriver => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='No Driver']"));
        public IWebElement checkboxUnknown => functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and normalize-space(text())='Unknown']"));


        //Selects
        public IWebElement selectFault => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='faultIndicatorTypeId']"));
        public IWebElement selectSuitFiled => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='isSuitFiled']"));
        public IWebElement selectAttyRep => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='authorizedRep']"));
        public IWebElement selectReportOnly => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='isReportOnly']"));
        public IWebElement selectSex => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='sexTypeId']"));
        public IWebElement selectMaritalStatus => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='maritalStatusId']"));
        public IWebElement selectFatality => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='isFatalityId']"));
        public IWebElement selectTort => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='tortThresholdId']"));
        public IWebElement selectSubrogation => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='subrogationReferralId']"));
        public IWebElement selectRelationship => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='relationshipTypeId']"));
        public IWebElement selectPhoneType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='phoneTypeId']"));

        //Inputs
        public IWebElement inputOtherInsurer => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='otherInsurer']"));
        public IWebElement inputOtherInsurerPolicy => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='otherInsurerPolicy']"));
        public IWebElement inputOtherInsurerClaim => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='otherInsurerClaim']"));
        public IWebElement inputOtherInsurerAdjuster => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='otherInsurerAdjuster']"));
        public IWebElement inputDateOfBirth => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='dateOfBirth']"));
        public IWebElement inputDamageDescription => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='damageLocated']"));
        public IWebElement inputTreatmentFacility => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='treatmentFacility']"));
        public IWebElement inputAdditionalNotes => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='additionalNotes']"));
        public IWebElement inputFirstName => functions.FindElementWait(10, By.Name("firstName"));
        public IWebElement inputMiddleName => functions.FindElementWait(10, By.Name("middleName"));
        public IWebElement inputLastName => functions.FindElementWait(10, By.Name("lastName"));
        public IWebElement inputSuffixName => functions.FindElementWait(10, By.Name("suffix"));
        public IWebElement inputEmail => functions.FindElementWait(10, By.Name("email"));
        public IWebElement inputOccupation => functions.FindElementWait(10, By.Name("occupation"));
        public IWebElement inputPhone => functions.FindElementWait(10, By.Name("phone"));

        //Buttons
        public IWebElement submitButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Contacts']"));

        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                        case "Fault": return selectFault;
                        case "SuitFiled": return selectSuitFiled;
                        case "AttyRep": return selectAttyRep;
                        case "ReportOnly": return selectReportOnly;
                        case "Sex": return selectSex;
                        case "MaritalStatus": return selectMaritalStatus;
                        case "Fatality": return selectFatality;
                        case "Tort": return selectTort;
                        case "Subrogation": return selectSubrogation; 
                        case "Relationship": return selectRelationship;
                        case "PhoneType": return selectPhoneType;
                        case "OtherInsurer": return inputOtherInsurer; 
                        case "OtherInsurerPolicy": return inputOtherInsurerPolicy; 
                        case "OtherInsurerClaim": return inputOtherInsurerClaim;
                        case "OtherInsurerAdjuster": return inputOtherInsurerAdjuster; 
                        case "DateOfBirth": return inputDateOfBirth; 
                        case "DamageDescription": return inputDamageDescription; 
                        case "TreatmentFacility": return inputTreatmentFacility; 
                        case "AdditionalNotes": return inputAdditionalNotes;
                        case "FirstName": return inputFirstName;
                        case "MiddleName": return inputMiddleName;
                        case "LastName": return inputLastName;
                        case "SuffixName": return inputSuffixName;
                        case "Email": return inputEmail;
                        case "Occupation": return inputOccupation;
                        case "Phone": return inputPhone;
                default: return null;

            } 
        }

        public void EnterInput(string locator, string value)
        {
            getElementFromFieldname(locator).SendKeys(value);
        }

        public void EnterSelect(string locator, string value)
        {
            getElementFromFieldname(locator).Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Click();
        }
    }
}
