using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Claims
{
    [Binding]
    public sealed class ClaimSubmittedPage
    {

        //Biberk Logo
        public static Element BiberkLogo => new Element(By.XPath("//a[@data-qa='biBERK-Logo']"));

        //Phone Icon
        public static Element PhoneButton => new Element(By.XPath("//a[@data-qa='header-link-mobile-phone-icon']"));

        //Menu Icon
        public static Element MenuButton => new Element(By.XPath("//button[@data-qa='header-trigger-mobile-menu-icon']"));

        //Claim Header
        public static Element ClaimHeader => new Element(By.XPath("//h1[@data-qa='submitted-claim-header']"));

        //Claim Subheader
        public static Element ClaimSubheader => new Element(By.XPath("//p[@data-qa='submitted-claim-subheader']"));

        //Contact Header
        public static Element ContactHeader => new Element(By.XPath("//h5[@data-qa='contact-header']"));

        //Contact Subheader
        public static Element ContactSubheader => new Element(By.XPath("//p[@data-qa='contact-subheader']"));

        //Contact Phone Icon
        public static Element ContactPhoneIcon => new Element(By.XPath("//i[@data-qa='contact-phone-icon']"));

        //Contact Phone
        public static Element ContactPhone => new Element(By.XPath("//a[@data-qa='contact-phone']"));

        //Contact Fax
        public static Element ContactFax => new Element(By.XPath("//a[@data-qa='contact-fax-phone']"));

        //Contact Hours
        public static Element ContactHours => new Element(By.XPath("//p[@data-qa='contact-hours']"));

        //Contact Mail Icon
        public static Element ContactMailIcon => new Element(By.XPath("//i[@data-qa='contact-mail-icon']"));

        //Contact Email
        public static Element ContactEmail => new Element(By.XPath("//a[@data-qa='contact-email']"));

        //Contact Address
        public static Element ContactAddress => new Element(By.XPath("//span[@data-qa='contact-address']"));
    }
}