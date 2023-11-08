using BiBerkLOB.Source.Driver.Input;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public sealed class PL_AboutYou
    {

        //Professional Liability About You 

        public static Element AboutYouHeader => new Element(By.XPath("//h1[@data-qa='about-you-header']"));
        public static Element AboutYouParagraph => new Element(By.XPath("//h6[@data-qa='about-you-subheader']"));

        //Contact Information
        
        public static Element FirstNameTxtbox => new Element(By.XPath("//md-input[@data-qa='firstname-input']//input"));
        public static Element FirstNameError => new Element(By.XPath("//span[@data-qa='firstname-input-validation-error']"));
        public static Element LastNameTxtbox => new Element(By.XPath("//md-input[@data-qa='lastname-input']//input"));
        public static Element LastNameError => new Element(By.XPath("//span[@data-qa='lastname-input-validation-error']"));
        public static Element BusinessAddressTxtbox => new Element(By.XPath("//md-input[@data-qa='Business_address_input']//input"));
        public static Element BusinessAddressError => new Element(By.XPath("//span[@data-qa='lastname-input-validation-error']"));
        public static Element AptSuiteTxtbox => new Element(By.XPath("//md-input[@data-qa='Business_apt_num_input']//input"));
        public static Element AddressCityDD => new Element(By.XPath("//select[@data-qa='Business_city_input']//preceding-sibling::input"));
        public static InputSection AboutYouCity => new PLDropdownInput(AddressCityDD);
        public static Element AddressCityDDOption1 (string option) => new Element (By.XPath($"//li/span[text()='{option}']"));
        public static Element StateZipTxt => new Element(By.XPath("//h6[@data-qa='Business_state_zip_label']"));
        public static Element UseMailingAddressChkbox => new Element(By.XPath("//md-checkbox[@data-qa='use-mailing-checkbox']"));
        
        //When Use as mailing address is not selected
        
        public static Element MailingAddressTxtbox => new Element(By.XPath("//md-input[@data-qa='mailing-address-input']//input"));
        public static Element MailingAddressError => new Element(By.XPath("//span[@data-qa='mailing-address-input-validation-error']"));
        public static Element AptSuite2Txtbox => new Element(By.XPath("//md-input[@data-qa='mailing-address2-input']//input"));
        public static Element MailingZipCodeTxtbox => new Element(By.XPath("//md-input[@data-qa='mailingzip-input']//input"));
        public static Element MailingZipCodeError => new Element(By.XPath("//span[@data-qa='mailingzip-input-validation-error']"));
        public static Element MailingCityDD => new Element(By.XPath("//select[@data-qa='mailing-city-input']//preceding-sibling::input"));
        public static Element MailingCityDDOption (string mailoption) => new Element(By.XPath($"(//li/span[text()='{mailoption}'])[last()]"));
        public static Element MailingStateTxtbox => new Element(By.XPath("//md-input[@data-qa='mailingstate-input']//input"));
        public static Element MailingStateError => new Element(By.XPath("//span[@data-qa='mailingstate-input-validation-error']"));

        //Email Address, Phone, and Website fields

        public static Element EmailAddressTxtbox => new Element(By.XPath("//md-input[@data-qa='your-email-input']//input"));
        public static Element EmailAddressError => new Element(By.XPath("//span[@data-qa='your-email-input-validation-error']"));
        public static Element BusinessPhoneTxtbox => new Element(By.XPath("//md-input[@data-qa='business-phone-input']//input"));
        public static Element BusinessPhoneError => new Element(By.XPath("//span[@data-qa='business-phone-input-validation-error']"));
        public static Element BusinessPhoneExtTxtbox => new Element(By.XPath("//md-input[@data-qa='phone-ext-input']//input"));
        public static Element BusinessWebsiteTxtbox => new Element(By.XPath("//md-input[@data-qa='website-input']//input"));
        public static Element BusinessWebsiteHelptext => new Element(By.XPath("//span[@data-qa='ensure-best-price-helptext']"));

        //Account Manager/Broker Contact Information
        public static Element BrokerChkbox => new Element(By.XPath("//md-checkbox[@data-qa='broker-checkbox']"));
        public static Element BrokerFirstName => new Element(By.XPath("//md-input[@data-qa='broker-firstname-input']//input"));
        public static Element BrokerLastName => new Element(By.XPath("//md-input[@data-qa='broker-lastname-input']//input"));
        public static Element BrokerPhone => new Element(By.XPath("//md-input[@data-qa='broker-phone-input']//input"));
        public static Element BrokerExt => new Element(By.XPath("//md-input[@data-qa='broker-ext-input']//input"));
        public static Element BrokerEmail => new Element(By.XPath("//md-input[@data-qa='broker-email-input']//input"));

        //Navigation buttons

        public static Element SummaryButton => new Element(By.XPath("//button[@data-qa='validate-contact-button']"));
        public static Element BackButton => new Element(By.XPath("//button[@data-qa='back-to-coverage-button']"));


        //Your Summary Page, about you section

        public static Element YourSummaryHeader => new Element(By.XPath("//h1[@data-qa='summary-header']"));
        public static Element YourSummarySubHeader => new Element(By.XPath("//h6[@data-qa='summary-subheader']"));
        public static Element SummaryAboutYouTitle => new Element(By.XPath("//span[@data-qa='about-you-title']"));
        public static Element EditButton => new Element(By.XPath("//i[@data-qa='about-you-edit-button']"));
        public static Element YourNameIsTitle => new Element(By.XPath("//div[@data-qa='your-name-title']"));
        public static Element ContactName => new Element(By.XPath("//div[@data-qa='contact-name']"));
        public static Element YourAddressTitle => new Element(By.XPath("//div[@data-qa='your-address-title']"));
        public static Element ContactAddress => new Element(By.XPath("//div[@data-qa='contact-address']"));
        public static Element ContactYouAtTitle => new Element(By.XPath("//div[@data-qa='contact-you-title']"));
        public static Element ContactEmail => new Element(By.XPath("//div[@data-qa='contact-email']"));
        public static Element ContactPhone => new Element(By.XPath("//div[@data-qa='contact-phone']"));
        public static Element ViewQuoteButton => new Element(By.XPath("//button[@data-qa='go-to-quote-button']"));
        public static Element ViewQuoteButton2 => new Element(By.XPath("//button[@data-qa='summary-go-to-quote-button']"));
        public static Element YourSummaryBackButton => new Element(By.XPath("//button[@data-qa='summary-go-back-button']"));
    

    }
}