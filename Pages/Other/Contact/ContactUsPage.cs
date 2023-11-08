using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.Contact
{
    public sealed class ContactUsPage
    {
        // Title Elements
        public static Element ContactUsPageTitle => new Element(By.XPath("//h1[@data-qa='contactus-page-title']"));
        public static Element WereHereToHelp => new Element(By.XPath("//h2[@data-qa='contactus-help-header']"));
        public static Element HelpDescription => new Element(By.XPath("//p[@data-qa='contactus-help-description']"));

        // Questions? card
        public static Element QuestionsHeader => new Element(By.XPath("//h4[@data-qa='contactus-questions-header']"));
        public static Element OurLicensedTeam => new Element(By.XPath("//h6[@data-qa='contactus-questions-subheader']"));
        public static Element QuestionsEmailImage => new Element(By.XPath("//i[@class='col s3 right-align bright-blue-text material-icons']"));
        public static Element QuestionsEmail => new Element(By.XPath("//a[@data-qa='contactus-questions-email']"));
        public static Element QuestionsPhoneImage => new Element(By.XPath("//i[@class='col s3 right-align material-icons bright-blue-text']"));
        public static Element QuestionsPhone => new Element(By.XPath("//a[@data-qa='contactus-questions-phone']"));
        public static Element QuestionsHours => new Element(By.XPath("//div[@data-qa='contactus-questions-hours']"));

        // Insurance Policy Holders card
        public static Element PolicyHoldersTitle => new Element(By.XPath("//h4[@data-qa='contactus-policyholders-header']"));
        public static Element HowCanWeAssistYou => new Element(By.XPath("//h6[@data-qa='contactus-policyholders-subheader']"));
        public static Element PolicyHoldersEmailImage => new Element(By.XPath("//i[@class='col s3 bright-blue-text right-align material-icons']"));
        public static Element PolicyHoldersEmail => new Element(By.XPath("//a[@data-qa='contactus-policyholders-email']"));
        public static Element PolicyHoldersPhoneImage => new Element(By.XPath("//i[@class='col s3 material-icons right-align bright-blue-text']"));
        public static Element PolicyHoldersHours => new Element(By.XPath("//div[@data-qa='contactus-policyholders-hours']"));
        public static Element PolicyHoldersReportAClaim => new Element(By.XPath("//a[@data-qa='contactus-policyholders-reportclaim-link']"));
        public static Element PolicyHoldersMakeAPayment => new Element(By.XPath("//a[@data-qa='contactus-policyholders-makepayment-link']"));
        public static Element PolicyHoldersGetACertificate => new Element(By.XPath("//a[@data-qa='contactus-policyholders-getcert-link']"));

        // Frequently Asked Questions card
        public static Element FAQTitle => new Element(By.XPath("//h4[@data-qa='contactus-faq-header']"));
        public static Element GetHelpfulAnswers => new Element(By.XPath("//h6[@data-qa='contactus-faq-subheader']"));
        public static Element FAQButton => new Element(By.XPath("//a[@data-qa='contactus-faq-link']"));

        //Lets Connect
        public static Element LetsConnectHeader => new Element(By.XPath("//h2[@data-qa='contactus-form-header']"));
        public static Element LetsConnectSubHeader => new Element(By.XPath("//p[@data-qa='contactus-form-subheader']"));
        //How can we help?
        public static Element HowCanWeHelpQst => new Element(By.XPath("//span[@data-qa='contactus-form-questioninfo-label']"));
        public static Element HowCanWeHelpDD=> new Element(By.XPath("//select[@data-qa='contactus-form-questioninfo-category-select']"));
        public static InputSection HowCanWeHelpDDInput => new HtmlDropdownInput(HowCanWeHelpDD)
            .AsAQuestion(HowCanWeHelpQst);
        public static Element HowCanWeHelpTxtbox => new Element(By.XPath("//md-input[@data-qa='contactus-form-questioninfo-additionaldetails-textarea']"));
        public static InputSection HowCanWeHelpTxtboxInput => new TextBoxInput(HowCanWeHelpTxtbox);
        public static Element HowCanWeHelpError => new Element(By.XPath("//span[@data-qa='contactus-form-questioninfo-additionaldetails-textarea-validation-error']"));
        //Contact Name
        public static Element ContactNameQst => new Element(By.XPath("//span[@data-qa='contactus-form-contactname-label']"));
        public static Element ContactFirstNameTxtbox => new Element(By.XPath("//md-input[@data-qa='contactus-form-contactname-firstname-input']"));
        public static InputSection ContactFirstNameTxtboxInput => new TextBoxInput(ContactFirstNameTxtbox).AsAQuestion(ContactNameQst);
        public static Element ContactFirstNameError => new Element(By.XPath("//span[@data-qa='contactus-form-contactname-firstname-input-validation-error']"));
        public static Element ContactLastNameTxtbox => new Element(By.XPath("//md-input[@data-qa='contactus-form-contactname-lastname-input']"));
        public static InputSection ContactLastNameTxtboxInput => new TextBoxInput(ContactLastNameTxtbox);
        public static Element ContactlastNameError => new Element(By.XPath("//span[@data-qa='contactus-form-contactname-lastname-input-validation-error']"));
        //Email
        public static Element EmailQst => new Element(By.XPath("//span[@data-qa='contactus-form-email-label']"));
        public static Element EmailTxtbox => new Element(By.XPath("//me-input[@data-qa='contactus-form-email-input']"));
        public static InputSection EmailTxtboxInput => new TextBoxInput(EmailTxtbox)
            .AsAQuestion(EmailQst);
        public static Element EmailError => new Element(By.XPath("//span[@data-qa='contactus-form-email-input-validation-error']"));
        //Phone/Ext
        public static Element PhoneQst => new Element(By.XPath("//span[@data-qa='contactus-form-phone-number-label']"));
        public static Element PhoneTxtbox => new Element(By.XPath("//md-input[@data-qa='contactus-form-phone-number-input']"));
        public static InputSection PhoneTxtboxInput = new TextBoxInput(PhoneTxtbox)
            .AsAQuestion(PhoneQst);
        public static Element PhoneError=> new Element(By.XPath("//span[@data-qa='contactus-form-phone-number-input-validation-error']"));
        public static Element ExtQst => new Element(By.XPath("//span[@data-qa='contactus-form-phone-extension-label']"));
        public static Element ExtTxtbox => new Element(By.XPath("//md-input[@data-qa='contactus-form-phone-extension-input']"));
        public static InputSection ExtQstInput => new TextBoxInput(ExtTxtbox)
            .AsAQuestion(ExtQst);
        //Business Address
        public static Element BusinessAddressQst => new Element(By.XPath("//span[@data-qa='contactus-form-businessaddress-label']"));
        public static Element AddressOneTxtbox => new Element(By.XPath("//md-input[@data-qa='contactus-form-businessaddress-line1-input']"));
        public static InputSection AddressOneTxtboxInput => new TextBoxInput(AddressOneTxtbox)
            .AsAQuestion(BusinessAddressQst);
        public static Element AddressTwoTxtbox => new Element(By.XPath("//md-input[@data-qa='contactus-form-businessaddress-line2-input']"));
        public static InputSection AddressTwoTxtboxInput => new TextBoxInput(AddressTwoTxtbox);
        public static Element ZipCodeTxtbox => new Element(By.XPath("//md-input[@data-qa='contactus-form-businessaddress-zip-input']"));
        public static InputSection ZipCodeTxtBoxInput => new TextBoxInput(ZipCodeTxtbox);
        public static Element ZipCodeError => new Element(By.XPath("//span[@data-qa='contactus-form-businessaddress-zip-input-validation-error']"));
        public static Element CityDD => new Element(By.XPath("//select[@data-qa='contactus-form-businessaddress-city-select']"));
        public static InputSection CittyDDInput => new HtmlDropdownInput(CityDD);
        public static Element StateTxtbox => new Element(By.XPath("//md-input[@data-qa='contactus-form-businessaddress-state-input']"));
        public static InputSection StateTxtboxInput => new TextBoxInput(StateTxtbox);
        //Contact biBERK
        public static Element ContactBiberkCTA => new Element(By.XPath("//button[@data-qa='contactus-form-submit-button']"));
    }
}