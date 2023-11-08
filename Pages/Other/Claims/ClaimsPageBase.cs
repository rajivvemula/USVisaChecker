using BiBerkLOB.Components.PL;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BiBerkLOB.Pages.Other.Claims
{
    public class ClaimsPageBase
    {
        //Policy Number
        public static Element PolicyNumberHeader => new Element(By.XPath("//span[@data-qa='policy-number-label']"));
        public static Element PolicyNumberTextbox => new Element(By.XPath("//md-input[@data-qa='policy-number-input']//input"));
        public static Element PolicyNumberError => new Element(By.XPath("//span[@data-qa='policy-number-input-validation-error']"));


        //What's the name of your business?
        public static Element BusinessNameQST => new Element(By.XPath("//span[@data-qa='business-name-label']"));
        public static Element BusinessNameTextbox => new Element(By.XPath("//md-input[@data-qa='business-name-input']//input"));
        public static Element BusinessNameError => new Element(By.XPath("//span[@data-qa='business-name-input-validation-error']"));

        //Contact Name
        public static Element ContactNameHeader => new Element(By.XPath("//span[@data-qa='contact-name-label']"));
        public static Element FirstNameTextbox => new Element(By.XPath("//md-input[@data-qa='contact-first-name-input']//input"));
        public static Element FirstNameError => new Element(By.XPath("//span[@data-qa='contact-first-name-input-validation-error']"));
        public static Element LastNameTextbox => new Element(By.XPath("//md-input[@data-qa='contact-last-name-input']//input"));
        public static Element LastNameError => new Element(By.XPath("//span[@data-qa='contact-last-name-input-validation-error']"));

        //Phone
        public static Element PhoneHeader => new Element(By.XPath("//span[@data-qa='phone-number-label']"));
        public static Element PhoneTextbox => new Element(By.XPath("//md-input[@data-qa='phone-number-input']//input"));
        public static Element PhoneError => new Element(By.XPath("//span[@data-qa='phone-number-input-validation-error']"));

        //Ext
        public static Element ExtHeader => new Element(By.XPath("//span[@data-qa='phone-extension-label']"));
        public static Element PhoneNumExtTextbox => new Element(By.XPath("//md-input[@data-qa='phone-extension-input']//input"));

        //How can we connect with you?
        public static Element HowToConnectQST => new Element(By.XPath("//span[@data-qa='contact-email-label']"));
        public static Element HowToConnectTextbox => new Element(By.XPath("//md-input[@data-qa='contact-email-input']//input"));
        public static Element HowToConnectError => new Element(By.XPath("//span[@data-qa='contact-email-input-validation-error']"));

        //Date of Loss
        public static Element DateOfLoss => new Element(By.XPath("//span[@data-qa='loss-date-label']"));
        public static Element DateOfLossDateField => new Element(By.XPath("//bbmd-datepicker[@data-qa='loss-date-datepicker']"));
        public static InputSection DateOfLossInput => new DatePickerInput(new PL_DatePicker("Date of Loss"))
            .AsAQuestion(DateOfLoss);
        public static InputSection DateOfInjuryOrIllnessInput => new DatePickerInput(new PL_DatePicker("Date of Injury or illness"))
            .AsAQuestion(DateOfLoss);
        public static Element DateofLossError => new Element(By.XPath("//span[@data-qa='loss-date-datepicker-validation-error']"));

        //Location of loss
        public static Element LocationOfLoss => new Element(By.XPath("//span[@data-qa='loss-location-label']"));
        public static Element LocationOfLossTxtbox => new Element(By.XPath("//md-input[@data-qa='loss-location-input']//input"));
        public static Element LocationOfLossError => new Element(By.XPath("//span[@data-qa='loss-location-input-validation-error']"));

        //Short Description of Loss and Damage/Injury if Liability
        public static Element ShortDescrip => new Element(By.XPath("//span[@data-qa='loss-summary-label']"));
        public static Element ShortDescripTextbox => new Element(By.XPath("//md-input[@data-qa='loss-summary-input']//textarea"));
        public static Element ShortDescripError => new Element(By.XPath("//span[@data-qa='loss-summary-input-validation-error']"));

        //Submit Claim Button
        public static Element SubmitClaimsButton => new Element(By.XPath("//button[@data-qa='submit-claim-button']"));

        //Contact information
        public static Element QuestionsHeader => new Element(By.XPath("//h5[@data-qa='contact-header']"));
        public static Element PhoneIcon => new Element(By.XPath("//i[@data-qa='contact-phone-icon']"));
        public static Element PhoneNumber => new Element(By.XPath("//a[@data-qa='contact-phone']"));
        public static Element OfficeHours => new Element(By.XPath("//p[@data-qa='contact-hours']"));
        public static Element FaxNumber => new Element(By.XPath("//a[@data-qa='contact-fax-phone']"));
        public static Element EmailIcon => new Element(By.XPath("//i[@data-qa='contact-mail-icon']"));
        public static Element ClaimsEmail => new Element(By.XPath("//a[@data-qa='contact-email']"));
        public static Element ClaimsContactAddress => new Element(By.XPath("//span[@data-qa='contact-address']"));
    }
}