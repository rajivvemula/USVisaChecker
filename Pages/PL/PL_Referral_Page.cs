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
    class PL_Referral_Page
    {
        // Header
        public static Element YourQuoteIsNearlyReadyTitle => new Element(By.XPath("//h1[@data-qa='referred-header']"));
        public static Element ReferredSubHeader => new Element(By.XPath("//h6[@data-qa='referred-subheader']"));

        // What's the name of your business?
        public static Element WhatsTheNameOfYourBusinessQST => new Element(By.XPath("//span[@data-qa='business-name-label']"));
        public static Element WhatsTheNameOfYourIndiBusinessQST => new Element(By.XPath("//span[@data-qa='referred-business-name-label']"));
        public static Element BusinessNameTxtbox => new Element(By.XPath("//md-input[@data-qa='referred-business-name-input']//input"));

        // What name do you do business under (if different than above)?
        public static Element WhatNameDoYouDoBusinessQST => new Element(By.XPath("//span[@data-qa='referred-different-business-name-label']"));
        public static Element WhatNameDoYouDoBusinessTxtbox => new Element(By.XPath("//md-input[@data-qa='referred-DBA-input']//input"));

        //Insured Name
        public static Element InsuredFirstNameTxtbox => new Element(By.XPath("//fieldset[@show.one-way='UseInsuredName']//md-input[@data-qa='referred-firstname-input']//input"));
        public static Element InsuredLastNameTxtbox => new Element(By.XPath("//fieldset[@show.one-way='UseInsuredName']//md-input[@data-qa='referred-lastname-input']//input"));

        // Contact Name
        public static Element ContactName => new Element(By.XPath("//span[@data-qa='referred-contact-name-label']"));
        public static Element ContactFirstName => new Element(By.XPath("//div[@data-qa='referred-firstname-text']//input"));
        public static Element ContactLastName => new Element(By.XPath("//div[@data-qa='referred-lastname-text']//input"));

        // Account Manager/Broker Contact Name
        public static Element BrokerName => new Element(By.XPath("//span[@data-qa='referred-broker-name-label']"));
        public static Element BrokerFirstName => new Element(By.XPath("//md-input[@data-qa='referred-broker-firstname-input']//input"));
        public static Element BrokerLastName => new Element(By.XPath("//md-input[@data-qa='referred-broker-lastname-input']//input"));

        // Email
        public static Element Email => new Element(By.XPath("//span[@data-qa='referred-email-label']"));
        public static Element EmailTxtbox => new Element(By.XPath("//md-input[@data-qa='referred-email-input']//input"));

        // Account Manager/Broker's Email
        public static Element BrokerEmail => new Element(By.XPath("//span[@data-qa='broker-email-label']"));
        public static Element BrokerEmailTxtbox => new Element(By.XPath("//md-input[@data-qa='broker-email-input']//input"));

        // Phone
        public static Element Phone => new Element(By.XPath("//label[@data-qa='referred-phone']"));
        public static Element Ext => new Element(By.XPath("//label[@data-qa='extension-label']"));
        public static Element PhoneTxtbox => new Element(By.XPath("//md-input[@data-qa='referred-phone-input']//input"));
        public static Element ExtTxtbox => new Element(By.XPath("//md-input[@data-qa='referred-phone-ext-input']//input"));

        // Account Manager/Broker's Phone
        public static Element BrokerPhone => new Element(By.XPath("//label[@data-qa='broker-phone-label']"));
        public static Element BrokerPhoneTxtbox => new Element(By.XPath("//md-input[@data-qa='broker-phone-input']//input"));
        public static Element BrokerExt => new Element(By.XPath("//label[@data-qa='broker-phone-ext-label']"));
        public static Element BrokerExtTxtbox => new Element(By.XPath("//md-input[@data-qa='broker-phone-ext-input']//input"));

        // Website
        public static Element Website => new Element(By.XPath("//span[@data-qa='referred-website-label']"));
        public static Element WebsiteTxtbox => new Element(By.XPath("//md-input[@data-qa='referred-website-input']//input"));

        public static Element WellBeInTouchCTA => new Element(By.XPath("//button[@data-qa='referred-submit-button']"));
        public static Element ProudToBePartOfCopy => new Element(By.XPath("//div[@data-qa='footer-text']"));

        public static List<Element> TitleElements => new List<Element>
        {
            YourQuoteIsNearlyReadyTitle,
            ReferredSubHeader
        };

        public static List<ReferPageFieldObject> ReferFields = new List<ReferPageFieldObject>
            {
                new ReferPageFieldObject("Business name","What's the name of your business?", PL_Referral_Page.WhatsTheNameOfYourBusinessQST, PL_Referral_Page.BusinessNameTxtbox),
                new ReferPageFieldObject("Insured first name","What's the name you do business under?", PL_Referral_Page.WhatsTheNameOfYourIndiBusinessQST, PL_Referral_Page.InsuredFirstNameTxtbox),
                new ReferPageFieldObject("Insured last name","What's the name you do business under?", PL_Referral_Page.WhatsTheNameOfYourIndiBusinessQST, PL_Referral_Page.InsuredLastNameTxtbox),
                new ReferPageFieldObject("DBA","What name do you do business under (if different than above)?", PL_Referral_Page.WhatNameDoYouDoBusinessQST, PL_Referral_Page.WhatNameDoYouDoBusinessTxtbox),
                new ReferPageFieldObject("Contact first name","Contact name", PL_Referral_Page.ContactName, PL_Referral_Page.ContactFirstName),
                new ReferPageFieldObject("Contact last name","Contact name", PL_Referral_Page.ContactName, PL_Referral_Page.ContactLastName),
                new ReferPageFieldObject("Broker first name","Account Manager/Broker Contact Name", PL_Referral_Page.BrokerName, PL_Referral_Page.BrokerFirstName),
                new ReferPageFieldObject("Broker last name","Account Manager/Broker Contact Name", PL_Referral_Page.BrokerName, PL_Referral_Page.BrokerLastName),
                new ReferPageFieldObject("Email","Email", PL_Referral_Page.Email, PL_Referral_Page.EmailTxtbox),
                new ReferPageFieldObject("Broker Email","Account Manager/Broker's Email", PL_Referral_Page.BrokerEmail, PL_Referral_Page.BrokerEmailTxtbox),
                new ReferPageFieldObject("Phone", "Phone", PL_Referral_Page.Phone, PL_Referral_Page.PhoneTxtbox),
                new ReferPageFieldObject("Ext","Ext", PL_Referral_Page.Ext, PL_Referral_Page.ExtTxtbox),
                new ReferPageFieldObject("Broker Phone", "Account Manager/Broker's Phone", PL_Referral_Page.BrokerPhone, PL_Referral_Page.BrokerPhoneTxtbox),
                new ReferPageFieldObject("Broker Ext","Ext", PL_Referral_Page.BrokerExt, PL_Referral_Page.BrokerExtTxtbox),
                new ReferPageFieldObject("Website","Website", PL_Referral_Page.Website, PL_Referral_Page.WebsiteTxtbox),
            };
    }
}
