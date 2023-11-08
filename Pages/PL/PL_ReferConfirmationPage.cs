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
    class PL_ReferConfirmationPage
    {
        /*
         * Referred Thank You Page
         */
        public static Element ReferredPageTitle => new Element(By.XPath("//h1[@data-qa='referred-thankyou-header']"));
        public static Element ReferredPageSubtitle => new Element(By.XPath("//p[@data-qa='referred-thankyou-text']"));
        //Questions? Our customer service team is here to help.
        public static Element QuestionsHeader => new Element(By.XPath("//h5[@data-qa='contact-header']"));
        //Phone
        public static Element PhoneIcon => new Element(By.XPath("//i[@data-qa='contact-phone-icon']"));
        public static Element Phone => new Element(By.XPath("//a[@data-qa='contact-phone']"));
        public static Element HoursOfOperation => new Element(By.XPath("//p[@data-qa='contact-hours']"));
        //Email
        public static Element EmailIcon => new Element(By.XPath("//i[@data-qa='contact-mail-icon']"));
        public static Element Email => new Element(By.XPath("//a[@data-qa='contact-email']"));
    }
}
