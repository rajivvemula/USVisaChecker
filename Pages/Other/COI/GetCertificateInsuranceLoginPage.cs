using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BiBerkLOB.Pages
{
    class GetCertificateInsuranceLoginPage 
    {
        // Certificate of Insurance (COI)
        public static Element PageTitleCOI => new Element(By.XPath("//h1[@data-qa='certificate-of-insurance']"));

        //Get a Certificate of Insurance
        public static Element GetCertfOfInsuranceTitle => new Element(By.XPath("//h2[@data-qa='get-a-certificate-of-insurance']"));
        //Complete the fields below to locate your insurance policy
        public static Element GetCertfOfInsuranceParagraph => new Element(By.XPath("//p[@data-qa='fill-the-auth-fields']"));
        //Policy Number
        public static Element PolicyNumber => new Element(By.XPath("//span[@data-qa='policy-number-label']"));
        public static Element PolicyNumberTxtBox => new Element(By.XPath("//md-input[@data-qa='policy-number-input']//input"));
        //Phone
        public static Element Phone => new Element(By.XPath("//span[@data-qa='phone-number-label']"));
        public static Element PhoneTxtBox => new Element(By.XPath("//md-input[@data-qa='phone-number-input']//input"));
        public static Element ContinueCTA => new Element(By.XPath("//button[@data-qa='continue-auth']"));

        public static List<Element> COILoginPageElements => new List<Element>
        {
            PageTitleCOI,
            GetCertfOfInsuranceTitle,
            GetCertfOfInsuranceParagraph,
            PolicyNumber,
            PolicyNumberTxtBox,
            Phone,
            PhoneTxtBox,
            ContinueCTA
        };
    }
}