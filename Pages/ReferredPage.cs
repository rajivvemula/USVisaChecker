using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Pages
{
    class ReferredPage : Reusable_PurchasePath
    {
        // Your coverage requires a little special attention.
        public static Element CoverageRequiresAttention => new Element(By.XPath("//h2[contains(text(),'attention')]"));
        // Please contact us at 1-844-472-0967 or fill in the form below and we'll get in touch right away to help you secure the coverage you need.
        public static Element PleaseContactUs => new Element(By.XPath("//h6[@class='text-center']"));
        // Business name
        public static Element BusinessName => new Element(By.XPath("//input[@id='BusinessName']"));
        // Doing business as (optional)
        public static Element DoingBusiness => new Element(By.XPath("//input[@id='DBA_0']"));
        // First name
        public static Element FirstName => new Element(By.XPath("//input[@id='FirstName']"));
        // Last name
        public static Element LastName => new Element(By.XPath("//input[@id='LastName']"));
        // Email
        public static Element Email => new Element(By.XPath("//input[@name='Email']"));
        // Contact Phone
        public static Element ContactPhone => new Element(By.XPath("//input[@id='PhoneAndExtension']"));
        // Business website (optional)
        public static Element BusinessWebsite => new Element(By.XPath("//input[@id='WebAddr']"));
        // Submit CTA
        public static Element SubmitCTA => new Element(By.XPath("//button[@type='submit']"));
        // We've received your information and will contact you shortly.
        public static Element ReceivedYourInformation => new Element(By.XPath("//h6[contains(text(),'received your information')]"));
        // Go to Homepage CTA
        public static Element GoToHomepageCTA => new Element(By.XPath("//button[@click.delegate='goHome()']"));

        // Insured First Name 
        public static Element InsuredFirstName => new Element(By.XPath("//input[@id='InsuredFirstName']"));
        // Insured First Name 
        public static Element InsuredLastName => new Element(By.XPath("//input[@id='InsuredLastName']"));


    }
}
