using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public sealed class PL_ContactDetailsPage : Reusable_PurchasePath
    {
        //Contact Details
        public static Element ContactDetails => new Element(By.XPath(""));
        //We respect your privacy and won't share your information. A licensed expert
        //will contact you to discuss your policy and answer any questions you may have.
        public static Element ContactDetailsParagraph => new Element(By.XPath(""));


        //Contact Name
        public static Element ContactNameQST => new Element(By.XPath(""));
        //Contact First Name Textbox
        public static Element ContactFirstNameTxtbox => new Element(By.XPath("//input[@name='FirstName']"));
        //Contact First Name Textbox Error Message
        public static Element ContactFirstNameError => new Element(By.XPath(""));
        //Contact Last Name Textbox
        public static Element ContactLastNameTxtbox => new Element(By.XPath("//input[@name='LastName']"));
        //Contact Last Name Textbox Error Message
        public static Element ContactLastNameError => new Element(By.XPath(""));


        //Business has an account manager with different contact information --- Check Box
        public static Element BusinessHasAccountManagerChkbox => new Element(By.XPath(""));
        //Business has an account manager with different contact information --- Text
        public static Element BusinessHasAccountManagerQST => new Element(By.XPath(""));


        //Account Manager/Broker Contact Name
        public static Element AccountManagerQST => new Element(By.XPath(""));
        //Account Manager/Broker First Name Textbox
        public static Element AccountManagerFirstNameTxtbox => new Element(By.XPath("//input[@name='BrokerFirstName']"));
        //Account Manager/Broker First Name Textbox Error Message
        public static Element AccountManagerFirstNameError => new Element(By.XPath(""));
        //Account Manager/Broker Last Name Textbox
        public static Element AccountManagerLastNameTxtbox => new Element(By.XPath("//input[@name='BrokerLastName']"));
        //Account Manager/Broker Last Name Textbox Error Message
        public static Element AccountManagerLastNameError => new Element(By.XPath(""));


        //Business Address
        public static Element BusinessAddressQST => new Element(By.XPath(""));
        //Business Street Address Textbox
        public static Element BusinessStreetAddressTxtbox => new Element(By.XPath("//input[@name='BusinessAddress1']"));
        //Business Street Address Textbox Error Message
        public static Element BusinessStreetAddressError => new Element(By.XPath(""));
        //Business Apartment, suite, unit, building, floor, c/o etc. Textbox
        public static Element BusinessApartmentSuiteTxtbox => new Element(By.XPath("//input[@name='BusinessAddress2']"));
        //Business Zip Code
        public static Element BusinessZipCodeTxtbox => new Element(By.XPath("//input[@name='BusinessZipCode']"));
        //Business City Dropdown
        public static Element BusinessCityDD => new Element(By.XPath(""));
        //Business State Textbox
        public static Element BusinessStateTxtbox => new Element(By.XPath("//input[@name='BusinessState']"));
        
        
        //Use as mailing address. Checkbox
        public static Element UseAsMailingAddressChkbox => new Element(By.XPath(""));
        //Use as mailing address. Text
        public static Element UseAsMailingAddressQST => new Element(By.XPath(""));


        //Mailing Address
        public static Element MailingAddressQST => new Element(By.XPath(""));
        //Mailing Street Address Textbox
        public static Element MailingStreetAddressTxtbox => new Element(By.XPath("//input[@name='MailingAddress1']"));
        //Mailing Street Address Textbox Error Message
        public static Element MailingStreetAddressError => new Element(By.XPath(""));
        //Mailing Apartment, suite, unit, building, floor, c/o etc. Textbox
        public static Element MailingApartmentSuiteTxtbox => new Element(By.XPath("//input[@name='MailingAddress2']"));
        //Mailing Zip Code
        public static Element MailingZipCodeTxtbox => new Element(By.XPath("//input[@name='MailingZipCode']"));
        //Mailing Zip Code Error Message
        public static Element MailingZipCodeError => new Element(By.XPath(""));
        //Mailing City Dropdown
        public static Element MailingCityDD => new Element(By.XPath(""));
        //Mailing State Textbox
        public static Element MailingStateTxtbox => new Element(By.XPath("//input[@name='MailingState']"));
        //Mailing State Textbox Error Message
        public static Element MailingStateError => new Element(By.XPath(""));


        //Account Manager/Broker's Email
        public static Element AccountManagerEmailQST => new Element(By.XPath(""));
        //Account Manager/Broker's Email Textbox
        public static Element AccountManagerEmailTxtbox => new Element(By.XPath("//input[@name='BrokerEmail']"));
        //Account Manager/Broker's Email Textbox Error Message
        public static Element AccountManagerEmailError => new Element(By.XPath(""));


        //How can we connect with you?
        public static Element ContactEmailQST => new Element(By.XPath(""));
        //Contact Email Address Textbox
        public static Element ContactEmailTxtbox => new Element(By.XPath("//input[@name='Email']"));
        //Contact Email Address Textbox Error Message
        public static Element ContactEmailError => new Element(By.XPath(""));
        //We'll only use this to contact you about your quote.
        public static Element ContactEmailTextBelow => new Element(By.XPath(""));


        //Account Manager/Broker's Phone
        public static Element AccountManagerPhoneQST => new Element(By.XPath(""));
        //Account Manager/Broker's Phone Textbox
        public static Element AccountManagerPhoneTxtbox => new Element(By.XPath("//input[@name='BrokerPhone']"));
        //Account Manager/Broker's Phone Textbox Error Message
        public static Element AccountManagerPhoneError => new Element(By.XPath(""));
        //Account Manager/Broker's Phone EXT
        public static Element AccountManagerPhoneExtQST => new Element(By.XPath(""));
        //Account Manager/Broker's Phone EXT Textbox
        public static Element AccountManagerPhoneExtTxtbox => new Element(By.XPath("//input[@name='BrokerPhoneExtension']"));


        //Business Phone
        public static Element BusinessPhoneQST => new Element(By.XPath(""));
        //Business Phone Textbox
        public static Element BusinessPhoneTxtbox => new Element(By.XPath("//input[@name='Phone']"));
        //Business Phone Textbox Error Message
        public static Element BusinessPhoneError => new Element(By.XPath(""));
        //Business Phone EXT
        public static Element BusinessPhoneExtQST => new Element(By.XPath(""));
        //Business Phone EXT Textbox
        public static Element BusinessPhoneExtTxtbox => new Element(By.XPath("//input[@name='PhoneExtension']"));
        //A licensed agent will follow up with you to make sure you have the right coverage.
        public static Element BusinessPhoneTextBelow => new Element(By.XPath(""));


        //Business Website
        public static Element BusinessWebsiteQST => new Element(By.XPath(""));
        //Business Website Textbox
        public static Element BusinessWebsiteTxtbox => new Element(By.XPath("//input[@name='Website']"));
        //Business Website Textbox Error Message
        public static Element BusinessWebsiteError => new Element(By.XPath(""));
        //Helps us ensure we are providing the best price. This is optional.
        public static Element BusinessWebsiteTextBelow => new Element(By.XPath(""));


        /*
        * Page CTA----------------------------------------------------------
        */
        //Back
        public static Element BackCTA => new Element(By.XPath(""));
        //Let's Wrap This Up
        public static Element LetsWrapThisUpCTA => new Element(By.XPath(""));


    }
}
