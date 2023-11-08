using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.COI
{
    public class CertificateOfInsuranceErrorPage
    {
        // Certificate of Insurance (COI)
        public static Element PageTitleCOI => new Element(By.XPath("//h1[@data-qa='certificate-of-insurance']"));
               
        public static Element CallForAssistanceHeader => new Element(By.XPath("//h2[@data-qa='unauthorized-header']"));
        public static Element CallForAssistanceParagraph => new Element(By.XPath("//p[@data-qa='unauthorized-subheader']"));
        public static Element PhoneNumberLink => new Element(By.XPath("//p[@data-qa='unauthorized-subheader']/a"));
        public static Element Questions => new Element(By.XPath("//h5[@data-qa='contact-header']"));
        public static Element CustomerServicePragraph => new Element(By.XPath("//p[@data-qa='contact-subheader']"));
        public static Element PhoneIcon => new Element(By.XPath("//div//i[@data-qa='contact-phone-icon']")); //??
        public static Element ContactPhoneNumber => new Element(By.XPath("//div//a[@data-qa='contact-phone']"));  //??
        public static Element ContactHours => new Element(By.XPath("//p[@data-qa='contact-hours']"));
        public static Element EmailIcon => new Element(By.XPath("//i[@data-qa='contact-mail-icon']"));
        public static Element EmailLink => new Element(By.XPath("//a[@data-qa='contact-email']"));

        public static List<Element> COIErrorPageElements => new List<Element>
        {
            PageTitleCOI,
            CallForAssistanceHeader,
            CallForAssistanceParagraph,
            PhoneNumberLink,
            Questions,
            CustomerServicePragraph,
            PhoneIcon,
            ContactPhoneNumber,
            ContactHours,
            EmailIcon,
            EmailLink
        };
    }
}
