using HitachiQA.Driver;
using OpenQA.Selenium;
using BiBerkLOB.Pages.Other;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Terms and Conditions")]
    public sealed class CA_Gen_TermsAndConditionsPage
    {
        //Term & Conditions
        public static Element TermsAndConditionsTitle => new Element(By.XPath("//h1[@data-qa='T&C-Header']"));
        public static Element TermsAndConditionsParagraph => new Element(By.XPath("//div[@data-qa='T&C-Subheader-Text']"));
        public static Element TermsAndConditionsX => new Element(By.XPath("//button[@data-qa='close-modal']"));

        //Personal Information
        public static Element PersonalInfoTitle => new Element(By.XPath("//h2[@data-qa='T&C-Personal-Information']"));
        public static Element PersonalInfoParagraph => new Element(By.XPath("//div[@data-qa='T&C-Personal-Information-text']"));

        //Cancellation
        public static Element CancellationTitle => new Element(By.XPath("//h2[@data-qa='T&C-Cancellation']"));
        public static Element CancellationParagraph => new Element(By.XPath("//div[@data-qa='T&C-Cancellation-text']"));

        //AutoPay - Recurring Credit Card Program
        public static Element AutoPayTitle => new Element(By.XPath("//h2[@data-qa='T&C-AutoPay---Recurring-Credit-Card-Program']"));
        public static Element AutoPayParagraph => new Element(By.XPath("//div[@data-qa='T&C-AutoPay---Recurring-Credit-Card-Program-text']"));

        //Payment Schedule
        public static Element PaymentSchedTitle => new Element(By.XPath("//h2[@data-qa='T&C-Payment-Schedule']"));
        public static Element PaymentSchedParagraph => new Element(By.XPath("//div[@data-qa='T&C-Payment-Schedule-text']"));

        //Recurring Direct Draft Program
        public static Element RecurringDirectDraftTitle => new Element(By.XPath("//h2[@data-qa='T&C-Recurring-Direct-Draft-Program']"));
        public static Element RecurringDirectDraftParagraph => new Element(By.XPath("//div[@data-qa='T&C-Recurring-Direct-Draft-Program-text']"));
        /* The element in question does not have an XPath attribute.  Rather than double-list the same element with a different name,
         * I am commenting it out as a placeholder for future changes to the link element attributes.
         public static Element RecurringDirectDraftHyperlink => new Element(By.XPath("//p[@data-qa='T&C-Recurring Direct Draft Program-text']/a"));*/

        //State Specific Terms & Conditions
        public static Element StateTermsTitle => new Element(By.XPath("//h2[@data-qa='T&C-State-Specific-Header']"));
        public static Element StateTerms_AZTitle => new Element(By.XPath("//h3[@data-qa='T&C-Arizona']"));
        public static Element StateTerms_AZParagraph => new Element(By.XPath("//p[@data-qa='T&C-Arizona-Text']"));
        public static Element StateTerms_CATitle => new Element(By.XPath("//h3[@data-qa='T&C-California']"));
        public static Element StateTerms_CAParagraph => new Element(By.XPath("//h3[@data-qa='T&C-California']"));
        public static Element StateTerms_MassTitle => new Element(By.XPath("//h3[@data-qa='T&C-Massachusetts']"));
        public static Element StateTerms_MassParagraph => new Element(By.XPath("//p[@data-qa='T&C-Massachusetts-Text']"));
        public static Element StateTerms_MinnTitle => new Element(By.XPath("//h3[@data-qa='T&C-Minnesota']"));
        public static Element StateTerms_MinnParagraph => new Element(By.XPath("//p[@data-qa='T&C-Minnesota-Text']"));
        public static Element StateTerms_ORTitle => new Element(By.XPath("//h3[@data-qa='T&C-Oregon']"));
        public static Element StateTerms_ORParagraph => new Element(By.XPath("//p[@data-qa='T&C-Oregon-Text']"));
       
        //Alabama, Arkansas, District of Columbia, Louisiana, Maryland, New Mexico, Rhode Island and West Virginia
        public static Element StateTerms_ALDCLAMYNMRIWVTitle => new Element(By.XPath("//h3[@data-qa='T&C-Alabama-Arkansas-District-of-Columbia-Louisiana-Maryland-New-Mexico-Rhode-Island-and-West-Virginia']"));
        public static Element StateTerms_ALDCLAMYNMRIWVParagraph => new Element(By.XPath("//p[@data-qa='T&C-Alabama-Arkansas-District-of-Columbia-Louisiana-Maryland-New-Mexico-Rhode-Island-and-West-Virginia-Text']"));
        public static Element StateTerms_ALDCLAMYNMRIWV_Asterisk => new Element(By.XPath("//p[@data-qa='T&C-Sixth-Addendum']"));
        public static Element StateTerms_COTitle => new Element(By.XPath("//h3[@data-qa='T&C-Colorado']"));
        public static Element StateTerms_COParagraph => new Element(By.XPath("//p[@data-qa='T&C-Colorado-Text']"));
        public static Element StateTerms_FLOKTitle => new Element(By.XPath("//h3[@data-qa='T&C-Florida-and-Oklahoma']"));
        public static Element StateTerms_FLOKParagraph => new Element(By.XPath("//p[@data-qa='T&C-Florida-and-Oklahoma-Text']"));
        public static Element StateTerms_FLOK_Asterisk => new Element(By.XPath("//p[@data-qa='T&C-Eighth-Addendum']"));
        public static Element StateTerms_KSTitle => new Element(By.XPath("//h3[@data-qa='T&C-Kansas']"));
        public static Element StateTerms_KSParagraph => new Element(By.XPath("//p[@data-qa='T&C-Kansas-Text']"));
       
        //Kentucky, New York, Ohio and Pennsylvania
        public static Element StateTerms_KYNYOHPATitle => new Element(By.XPath("//h3[@data-qa='T&C-Kentucky-New-York-Ohio-and-Pennsylvania']"));
        public static Element StateTerms_KYNYOHPAParagraph => new Element(By.XPath("//p[@data-qa='T&C-Kentucky-New-York-Ohio-and-Pennsylvania-Text']"));
        public static Element StateTerms_KYNYOHPA_Asterisk => new Element(By.XPath("//p[@data-qa='T&C-Tenth-Addendum']"));
       
        //Maine, Tennessee, Virginia and Washington
        public static Element StateTerms_METNVAWATitle => new Element(By.XPath("//h3[@data-qa='T&C-Maine-Tennessee-Virginia-and-Washington']"));
        public static Element StateTerms_METNVAWAParagraph => new Element(By.XPath("//p[@data-qa='T&C-Maine-Tennessee-Virginia-and-Washington-Text']"));
        public static Element StateTerms_METNVAWA_Asterisk => new Element(By.XPath("//p[@data-qa='T&C-Eleventh-Addendum']"));
        public static Element StateTerms_NJTitle => new Element(By.XPath("//h3[@data-qa='T&C-New-Jersey']"));
        public static Element StateTerms_NJParagraph => new Element(By.XPath("//p[@data-qa='T&C-New-Jersey-Text']"));
        public static Element StateTerms_UTTitle => new Element(By.XPath("//h3[@data-qa='T&C-Utah']"));
        public static Element StateTerms_UTParagraph => new Element(By.XPath("//p[@data-qa='T&C-Utah-Text']"));
        public static Element StateTerms_VTTitle => new Element(By.XPath("//h3[@data-qa='T&C-Vermont']"));
        public static Element StateTerms_VTParagraph => new Element(By.XPath("//p[@data-qa='T&C-Vermont-Text']"));

        public static Element PrintBTN => new Element(By.XPath("//button[@data-qa='printer-icon']"));

    }
}