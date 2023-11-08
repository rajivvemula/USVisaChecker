using BiBerkLOB.Components.PL;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BiBerkLOB.Pages.Other.Claims
{
    class WCClaimsPage : ClaimsPageBase
    {
        // Title - Report a Claim
        public static Element TitleReportClaim => new Element(By.XPath("//h1[@data-qa=\"report-a-workers'-compensation-claim-header\"]"));
        public static Element CompleteTheForm => new Element(By.XPath("//p[@data-qa='report-claim-info-description']"));
        public static Element DirectoryOfMedicalProvidersInNetworkHeader => new Element(By.XPath("//div[@data-qa='directory-of-medical-providers-accordion']"));
        public static Element DirectoryOfMedicalProvidersInNetworkTXT => new Element(By.XPath("//div[@data-qa='directory-cs-copy']"));
        public static Element ImportantStepsRightAfterHeader => new Element(By.XPath("//div[@data-qa='important-steps-accordion']"));
        public static Element ImportantStepsRightAfterTXT => new Element(By.XPath("//div[@data-qa='important-steps-copy']"));

        //Injured Worker Name
        public static Element InjuredWorkerNameQST => new Element(By.XPath("//span[@data-qa='injured-worker-name-label']"));
        public static Element InjuredWorkerFirstNameAnswer => new Element(By.XPath("//md-input[@data-qa='injured-worker-first-name-input']//input"));
        public static Element InjuredWorkerFirstNameError => new Element(By.XPath("//span[@data-qa='injured-worker-first-name-input-validation-error']"));
        public static Element InjuredWorkerLastNameAnswer => new Element(By.XPath("//md-input[@data-qa='injured-worker-last-name-input']//input"));
        public static Element InjuredWorkerLastNameError => new Element(By.XPath("//span[@data-qa='injured-worker-last-name-input-validation-error']"));

        //Injured Worker Address
        public static Element InjuredWorkerAddressQST => new Element(By.XPath("//span[@data-qa='injured-worker-name-label']"));
        public static Element InjuredWorkerAddress1 => new Element(By.XPath("//md-input[@data-qa='worker-address-1']//input"));
        public static Element InjuredWorkerAddress2 => new Element(By.XPath("//md-input[@data-qa='worker-address-2']//input"));
        public static Element InjuredWorkerZip => new Element(By.XPath("//md-input[@data-qa='worker-zip-code-input']//input"));
        public static Element InjuredWorkerCity => new Element(By.XPath("//select[@data-qa='worker-city']/..//input"));
        public static Element InjuredWorkerCityModel(string city) => new Element(By.XPath($"//option[@model.bind='city' and text()='{city}']/ancestor::fieldset"));
        public static Element InjuredWorkerCityOption(string city) => new Element(By.XPath($"//select[@data-qa='worker-city']/..//li/span[text()='{city}']"));
        public static Element InjuredWorkerState => new Element(By.XPath("//md-input[@data-qa='worker-state']//input"));

        //Injured Worker Social Security Number
        public static Element InjuredWorkerSSNQST => new Element(By.XPath("//span[@data-qa='worker-ssn-label']"));
        public static Element InjuredWorkerSSNAnswer => new Element(By.XPath("//md-input[@data-qa='worker-ssn-input']//input"));

        //Injured Worker Birth Date
        public static Element InjuredWorkerBirthDateQST => new Element(By.XPath("//span[@data-qa='worker-birth-date-label']"));
        public static Element InjuredWorkerBirthDateAnswer => new Element(By.XPath("//bbmd-datepicker[@data-qa='worker-birth-date-input']"));
        public static InputSection InjuredWorkerDOBInput => new DatePickerInput(new PL_DatePicker("Injured Worker Birth Date"))
            .AsAQuestion(InjuredWorkerBirthDateQST);
        
        //Injured Worker Phone Number
        public static Element InjuredWorkerPhoneQST => new Element(By.XPath("//span[@data-qa='worker-phone-number-label']"));
        public static Element InjuredWorkerPhoneAnswer => new Element(By.XPath("//md-input[@data-qa='worker-phone-number-input']//input"));
        public static Element InjuredWorkerExtQST => new Element(By.XPath("//span[@data-qa='worker-phone-ext-label']"));
        public static Element InjuredWorkerExtAnswer => new Element(By.XPath("//md-input[@data-qa='worker-phone-ext-input']//input"));

        public static List<Element> WC_ClaimsPageElements => new List<Element>
        {
            TitleReportClaim,
            CompleteTheForm,
            DirectoryOfMedicalProvidersInNetworkHeader,
            ImportantStepsRightAfterHeader,
            PolicyNumberHeader,
            PolicyNumberTextbox,
            BusinessNameQST,
            BusinessNameTextbox,
            ContactNameHeader,
            FirstNameTextbox,
            LastNameTextbox,
            PhoneHeader,
            PhoneTextbox,
            ExtHeader,
            PhoneNumExtTextbox,
            HowToConnectQST,
            HowToConnectTextbox,
            InjuredWorkerNameQST,
            InjuredWorkerFirstNameAnswer,
            InjuredWorkerLastNameAnswer,
            InjuredWorkerAddressQST,
            InjuredWorkerAddress1,
            InjuredWorkerAddress2,
            InjuredWorkerZip,
            InjuredWorkerCity,
            InjuredWorkerState,
            InjuredWorkerSSNQST,
            InjuredWorkerSSNAnswer,
            InjuredWorkerBirthDateQST,
            InjuredWorkerBirthDateAnswer,
            InjuredWorkerPhoneQST,
            InjuredWorkerPhoneAnswer,
            InjuredWorkerExtQST,
            InjuredWorkerExtAnswer,
            DateOfLoss,
            DateOfLossDateField,
            LocationOfLoss,
            LocationOfLossTxtbox,
            ShortDescrip,
            ShortDescripTextbox,
            SubmitClaimsButton,
            QuestionsHeader,
            PhoneIcon,
            PhoneNumber,
            OfficeHours,
            FaxNumber,
            EmailIcon,
            ClaimsEmail,
            ClaimsContactAddress
        };

        public static List<Element> WC_ClaimsPageErrorMessages = new()
        {
            PolicyNumberError,
            BusinessNameError,
            FirstNameError,
            LastNameError,
            PhoneError,
            HowToConnectError,
            InjuredWorkerFirstNameError, 
            InjuredWorkerLastNameError,
            DateofLossError,
            LocationOfLossError,
            ShortDescripError
        };
    }
}