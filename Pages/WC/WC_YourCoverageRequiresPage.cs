using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BiBerkLOB.Pages.WC
{
    public sealed class WC_YourCoverageRequiresPage
    {
        public static Element YourCoverageHeader => new Element(By.XPath("//h2[@data-qa='wc_referred_header']"));
        public static Element PleaseContactUsHeader => new Element(By.XPath("//h6[@data-qa='wc_referred_contact_us_header']"));
        public static Element BusinessNameLabel => new Element(By.XPath("//label[@data-qa='wc_referred_businessname_label']"));
        public static Element BusinessNameTxtbox => new Element(By.XPath("//input[@data-qa='wc_referred_businessname_input']"));
        public static Element DoingBusinessAsLabel => new Element(By.XPath("//label[@data-qa='wc_referred_DBA_label']"));
        public static Element DoingBusinessAsTxtbox => new Element(By.XPath("//input[@data-qa='wc_referred_DBA_input']"));
        public static Element InsuredFirstNameLabel => new Element(By.XPath("//label[@data-qa='wc_referred_insured_firstname_label']"));
        public static Element InsuredFirstNameTxtbox => new Element(By.XPath("//input[@data-qa='wc_referred_insured_firstname_input']"));
        public static Element InsuredLastNameLabel => new Element(By.XPath("//label[@data-qa='wc_referred_insured_lastname_label']"));
        public static Element InsuredLastNameTxtbox => new Element(By.XPath("//input[@data-qa='wc_referred_insured_lastname_input']"));
        public static Element ContactFirstNameLabel => new Element(By.XPath("//label[@data-qa='wc_referred_contact_firstname_label']"));
        public static Element ContactFirstNameTxtbox => new Element(By.XPath("//input[@data-qa='wc_referred_contact_firstname_input']"));
        public static Element ContactLastNameLabel => new Element(By.XPath("//label[@data-qa='wc_referred_contact_lastname_label']"));
        public static Element ContactLastNameTxtbox => new Element(By.XPath("//input[@data-qa='wc_referred_contact_lastname_input']"));
        public static Element ContactEmailLabel => new Element(By.XPath("//label[@data-qa='wc_referred_contact_email_label']"));
        public static Element ContactEmailTxtbox => new Element(By.XPath("//bb-email[@data-qa='wc_referred_contact_email_input']//input"));
        public static Element ContactPhoneLabel => new Element(By.XPath("//label[@data-qa='wc_referred_contact_phone_label']"));
        public static Element ContactPhoneTxtbox => new Element(By.XPath("//bb-phone[@data-qa='wc_referred_contact_phone_input']//input"));
        public static Element BusinessWebsiteLabel => new Element(By.XPath("//label[@data-qa='wc_referred_business_website_label']"));
        public static Element BusinessWebsiteTxtbox => new Element(By.XPath("//input[@data-qa='wc_referred_business_website_input']"));
        public static Element SubmitCTA => new Element(By.XPath("//button[@data-qa='wc_referred_submit_button']"));

        public static List<Element> TitleElements => new List<Element>
        {
            YourCoverageHeader,
            PleaseContactUsHeader
        };

        public static List<ReferPageFieldObject> ReferFields => new List<ReferPageFieldObject>
        {
            new ReferPageFieldObject("Business name","Business name", WC_YourCoverageRequiresPage.BusinessNameLabel, WC_YourCoverageRequiresPage.BusinessNameTxtbox),
            new ReferPageFieldObject("Insured first name","Insured first name", WC_YourCoverageRequiresPage.InsuredFirstNameLabel, WC_YourCoverageRequiresPage.InsuredFirstNameTxtbox),
            new ReferPageFieldObject("Insured last name","Insured last name", WC_YourCoverageRequiresPage.InsuredLastNameLabel, WC_YourCoverageRequiresPage.InsuredLastNameTxtbox),
            new ReferPageFieldObject("Doing business as","Doing Business as (optional)", WC_YourCoverageRequiresPage.DoingBusinessAsLabel, WC_YourCoverageRequiresPage.DoingBusinessAsTxtbox),
            new ReferPageFieldObject("Contact first name","Contact first name", WC_YourCoverageRequiresPage.ContactFirstNameLabel, WC_YourCoverageRequiresPage.ContactFirstNameTxtbox),
            new ReferPageFieldObject("Contact last name","Contact last name", WC_YourCoverageRequiresPage.ContactLastNameLabel, WC_YourCoverageRequiresPage.ContactLastNameTxtbox),
            new ReferPageFieldObject("Contact email","Contact email", WC_YourCoverageRequiresPage.ContactEmailLabel, WC_YourCoverageRequiresPage.ContactEmailTxtbox),
            new ReferPageFieldObject("Contact phone","Contact phone", WC_YourCoverageRequiresPage.ContactPhoneLabel, WC_YourCoverageRequiresPage.ContactPhoneTxtbox),
            new ReferPageFieldObject("Business website","Business website (optional)", WC_YourCoverageRequiresPage.BusinessWebsiteLabel, WC_YourCoverageRequiresPage.BusinessWebsiteTxtbox),
        };
    }
}