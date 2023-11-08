using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages
{
    class GetACertificateOfInsuranceFormPage
    {
        // Get a Certificate of Insurance (COI)
        public static Element GetCOITitle => new Element(By.XPath("//h1[@data-qa='get-certificate-of-insurance']"));
        public static Element GetCOISubTitle => new Element(By.XPath("//p[@data-qa='certificate-of-insurance-form-info']"));

        //Certificate Holder Information
        public static Element CertHolderTitle => new Element(By.XPath("//span[@data-qa='certificate-holder-info-label']"));
        public static Element CertHolderTitleHelper => new Element(By.XPath("//i[@data-qa='certificate-holder-info-help-icon']"));
        public static Element CertHolderTitleHelperText => new Element(By.XPath("//div[@data-qa='certificate-holder-info-help-text']"));
        public static Element CertHolderTitleHelperX => new Element(By.XPath("//i[@data-qa='certificate-holder-info-help-text-close-icon']"));

        public static Element CertForSubContractorQST => new Element(By.XPath("//span[@data-qa='subcontractor-or-third-party-label']"));
        public static Element CertForSubContractorYes => new Element(By.XPath("//label[@data-qa='subcontractor-or-third-party-select-true']"));
        public static Element CertForSubContractorNo => new Element(By.XPath("//label[@data-qa='subcontractor-or-third-party-select-false']"));


        //Do you want a certificate for all of your insurance policies?
        public static Element CertForAllQST => new Element(By.XPath("//span[@data-qa='coi-all-insurance-policies-label']"));
        public static Element CertForAllYes => new Element(By.XPath("//label[@data-qa='coi-all-insurance-policies-select-true']"));
        public static Element CertForAllNo => new Element(By.XPath("//label[@data-qa='coi-all-insurance-policies-select-false']"));

        //Contact Name
        public static Element ContactNameQST => new Element(By.XPath("//span[@data-qa='contact-name-label']"));
        public static Element ContactNameTxtbox => new Element(By.XPath("//md-input[@data-qa='contact-name-input']//input"));
        public static Element ContactNameError => new Element(By.XPath("//span[@data-qa='contact-name-input-validation-error']"));

        // Business Address
        public static Element BusAdd => new Element(By.XPath("//span[@data-qa='business-address-label']"));
        public static Element BusAdd_StreetTxtbox => new Element(By.XPath("//md-input[@data-qa='business-address1-input']//input"));
        public static Element BusAdd_StreetError => new Element(By.XPath("//span[@data-qa='business-address1-input-validation-error']"));
        public static Element BusAdd_AptTxtbox => new Element(By.XPath("//md-input[@data-qa='business-address2-input']//input"));
        public static Element BusAdd_ZipTxtbox => new Element(By.XPath("//md-input[@data-qa='zip-code-input']//input"));
        public static Element BusAdd_ZipError => new Element(By.XPath("//span[@data-qa='zip-code-input-validation-error']"));
        public static Element BusAdd_ZipTextBelow => new Element(By.XPath("//span[@data-qa='zip-code-hint']"));
        public static Element BusAdd_CityDD => new Element(By.XPath("//select[@data-qa='city-dropdown']"));
        public static Element BusAdd_City => new Element(By.XPath("//select[@data-qa='city-dropdown']//preceding-sibling::input"));
        public static Element BusAdd_CityDDOption(string option) => new Element(By.XPath($"//li/span[text()='{option}']"));
        public static Element BusAdd_StateTxtbox => new Element(By.XPath("//md-input[@data-qa='state-input']"));

        // Email
        public static Element Email => new Element(By.XPath("//span[@data-qa='email-label']"));
        public static Element EmailTxtbox => new Element(By.XPath("//md-input[@data-qa='email-input']//input"));
        public static Element EmailError => new Element(By.XPath("//span[@data-qa='email-input-validation-error']"));
        public static Element EmailHelpText => new Element(By.XPath("//span[@data-qa='email-hint']"));

        // Get Certificate
        public static Element GetCertificateCTA => new Element(By.XPath("//button[@data-qa='get-certificate']"));
    }
}