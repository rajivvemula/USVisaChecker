using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages
{
    class ContactUsPage
    {
        //Main title headers
        public static Element ContactUsMainHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element HereToHelpHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element HereToHelpSubtext => new Element(By.XPath("//[@data-qa='']"));

        //Questions box
        public static Element QustionsHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element QuestionsSubtext => new Element(By.XPath("//[@data-qa='']"));
        public static Element ExpertsEmailLink => new Element(By.XPath("//[@data-qa='']"));
        public static Element ExpertsHoursText => new Element(By.XPath("//[@data-qa='']"));
        public static Element QuestionsPhoneNumberLink => new Element(By.XPath("//[@data-qa='']"));

        //PolicyHolders Box
        public static Element PolicyHolderHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element PolicyHolderSubText => new Element(By.XPath("//[@data-qa='']"));
        public static Element CustomerServiceEmailLink => new Element(By.XPath("//[@data-qa='']"));
        public static Element CustomerServiceHoursText => new Element(By.XPath("//[@data-qa='']"));
        public static Element CustomerServicePhoneNumberLink => new Element(By.XPath("//[@data-qa='']"));
        public static Element ReportAClaimButton => new Element(By.XPath("//[@data-qa='']"));
        public static Element MakePaymentButton => new Element(By.XPath("//[@data-qa='']"));
        public static Element GetCertificateButton => new Element(By.XPath("//[@data-qa='']"));

        //Frequently Asked Questions 
        public static Element FAQHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element FAQSubtext => new Element(By.XPath("//[@data-qa='']"));
        public static Element FAQButton => new Element(By.XPath("//[@data-qa='']"));

        //Let's Connect Section
        public static Element LetsConnectHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element LetsConnectSubtext => new Element(By.XPath("//[@data-qa='']"));
        public static Element HowCanWeHelpHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element QuestionAboutDD => new Element(By.XPath("//[@data-qa='']"));
        public static Element QuestionAboutDDError => new Element(By.XPath("//[@data-qa='']"));
        public static Element QuestionDetailsTextBox => new Element(By.XPath("//[@data-qa='']"));
        public static Element QuestionDetailsError => new Element(By.XPath("//[@data-qa='']"));

        //Contact Section
        public static Element ContactNameHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element ContactFirstNameTextbox => new Element(By.XPath("//[@data-qa='']"));
        public static Element ContactFirstNameTextboxError => new Element(By.XPath("//[@data-qa='']"));
        public static Element ContactLastNameTextbox => new Element(By.XPath("//[@data-qa='']"));
        public static Element ContactLastNameTextboxError => new Element(By.XPath("//[@data-qa='']"));
        public static Element EmailHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element EmailTextbox => new Element(By.XPath("//[@data-qa='']"));
        public static Element EmailTextboxError => new Element(By.XPath("//[@data-qa='']"));
        public static Element PhoneNumberHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element PhoneNumberTextbox => new Element(By.XPath("//[@data-qa='']"));
        public static Element PhoneNumberTextboxError => new Element(By.XPath("//[@data-qa='']"));
        public static Element PhoneNumberExtHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element PhoneNumberExtTextbox => new Element(By.XPath("//[@data-qa='']"));

        //Business Address Section
        public static Element BusinessAddressHeader => new Element(By.XPath("//[@data-qa='']"));
        public static Element BusinessAddressTextbox => new Element(By.XPath("//[@data-qa='']"));
        public static Element BusinessAddressTextboxError => new Element(By.XPath("//[@data-qa='']"));
        public static Element BusinessAddressLine2Textbox => new Element(By.XPath("//[@data-qa='']"));
        public static Element ZIPCodeTextbox => new Element(By.XPath("//[@data-qa='']"));
        public static Element ZIPCodeTextboxError => new Element(By.XPath("//[@data-qa='']"));
        public static Element CityDD => new Element(By.XPath("//[@data-qa='']"));
        public static Element CityDDError => new Element(By.XPath("//[@data-qa='']"));
        public static Element StateTextbox => new Element(By.XPath("//[@data-qa='']"));
        public static Element StateTextboxError => new Element(By.XPath("//[@data-qa='']"));

        //Contact Biberk button
        public static Element ContactBiBerkButton => new Element(By.XPath("//[@data-qa='']"));

    }
}
