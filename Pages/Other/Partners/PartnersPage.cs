using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using HitachiQA.Driver;
using OpenQA.Selenium;
using BiBerkLOB.Pages.Other;
using Microsoft.DotNet.PlatformAbstractions;

namespace BiBerkLOB.Pages.PartnersPage
{
    public class PartnersPage 
    {        
        //Partners
        public static Element  PartnersTitle=> new Element(By.XPath("//h1[@data-qa='become-a-biberk-partner']"));
        //Join the biBERK partner agency program
        public static Element PartnerHeader => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
        //4.9 out of 5 customer review rating and 200,000+ policies sold.
        public static Element PartnerRating  => new Element(By.XPath("//p[@data-qa='review-teaser-text']"));
        //Collaborating to Provide Outstanding Coverage
        public static Element CollaboratingToProvide => new Element(By.XPath("//h2[@data-qa='more-info-label']"));
        //Let’s partner to enhance our respective brands, grow our businesses, and bring better commercial insurance to companies throughout the U.S. Together we can achieve tremendous shared success.
        public static Element CollaboratingToProvide_Subtext => new Element(By.XPath("//p[@data-qa='basic-header-and-text-paragraph']"));
        //Get Access to Our Full Line
        public static Element GetAccessToOurFullLine => new Element(By.XPath("//h6[@data-qa='FullLine-first-card-header']"));
        //Professional Liability (E&O). biBERK offers coverage in all 50 states, writing over 95% of all classes.
        public static Element ProfessionalLiability => new Element(By.XPath("//span[@data-qa='FullLine-first-card-first-list-item-text']"));
        //BOP/GL and Umbrella. We offer coverages at highly competitive rates.
        public static Element BOPAndGL => new Element(By.XPath("//span[@data-qa='FullLine-first-card-second-list-item-text']"));
        //Workers’ Compensation. biBERK writes 95% of all class codes. Depending on the state and business type, the cost of insuring business owners or officers could be 35% to 50% below market.
        public static Element WorkersCompensation => new Element(By.XPath("//span[@data-qa='FullLine-first-card-third-list-item-text']"));
        //Get Exceptional Support
        public static Element GetExceptionalSupport => new Element(By.XPath("//h6[@data-qa='FullLine-second-card-header']"));
        //Our dedicated Partner Services Team provides assistance to both insureds and agents.
        public static Element OurDedicatedPartner => new Element(By.XPath("//span[@data-qa='FullLine-second-card-first-list-item-text']"));
        // Access to the biBERK platform allows you to quote, bind, and issue ANY policy online in 5 minutes.
        public static Element AccessToTheBiberk => new Element(By.XPath("//span[@data-qa='FullLine-second-card-second-list-item-text']"));
        //Let's Connect
        public static Element LetsConnect => new Element(By.XPath("//h1[@data-qa='partner-contact-form-header']"));
        //Interested in becoming a biBERK partner agency? Whether your agency is starting out or has developed a large book of business, we will have a solution that allows you access to our products. Complete the form below and our team will contact you
        public static Element LetsConnectText => new Element(By.XPath("//p[@data-qa='partner-contact-form-paragraph']"));
        public static Element ContactName => new Element(By.XPath("//label[@data-qa='partner-contact-form-contact-name-label']"));
        public static Element ContactFirstName => new Element(By.XPath("//div[@data-qa='partner-contact-form-first-name-input']//input"));
        public static Element ContactLastName => new Element(By.XPath("//div[@data-qa='partner-contact-form-last-name-input']//input"));
        public static Element Company => new Element(By.XPath("//label[@data-qa='partner-contact-form-company-label']"));
        public static Element CompanyInput => new Element(By.XPath("//div[@data-qa='partner-contact-form-company-name-input']//input"));
        public static Element Email => new Element(By.XPath("//label[@data-qa='partner-contact-form-email-label']"));
        public static Element EmailInput => new Element(By.XPath("//div[@data-qa='partner-contact-form-email-address-input']//input"));
        public static Element Phone => new Element(By.XPath("//label[@data-qa='partner-contact-form-phone-label']"));
        public static Element PhoneInput => new Element(By.XPath("//div[@data-qa='partner-contact-form-phone-input']//input"));
        public static Element ContactBiberk_BTN => new Element(By.XPath("//button[@data-qa='partner-contact-form-contact-button']//span"));

        public static List<Element> PartnersElements = new List<Element>
        {
            PartnersTitle,
            PartnerHeader,
            PartnerRating,
            CollaboratingToProvide,
            CollaboratingToProvide_Subtext,
            GetAccessToOurFullLine,
            ProfessionalLiability,
            BOPAndGL,
            WorkersCompensation,
            GetExceptionalSupport,
            OurDedicatedPartner,
            AccessToTheBiberk,
            LetsConnect,
            LetsConnectText,
            ContactName,
            ContactFirstName,
            ContactLastName,
            Company,
            CompanyInput,
            Email,
            EmailInput,
            Phone,
            PhoneInput,
            ContactBiberk_BTN
        };
     }
}