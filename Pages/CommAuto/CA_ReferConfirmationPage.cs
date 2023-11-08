using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Pages.Other;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Referral Confirm")]
    public sealed class CA_ReferConfirmationPage
    {
        /*
        * Headers----------------------------------------------------------
        */

        //Your Information Has Been Submitted
        public static Element YourInfoHasBeenSubmittedTitle => new Element(By.XPath("//h1[@data-qa='refer-thankyou-title']"));

        //Our team will review your information and we'll be in touch.
        public static Element ReviewYourInfoAndBeInTouch => new Element(By.XPath("//p[@data-qa='refer-thankyou-subtitle']"));

        //Questions? Our customer service team is here to help.
        public static Element QuestionsCustomerServiceTeam => new Element(By.XPath("//h5[@data-qa='contact-footer-text']"));

        //1-844-472-0967 (clickable)
        public static Element PhoneNumberBTN => new Element(By.XPath("//a[@data-qa='contact-phoneNumber']"));

        //1-844-472-0967 Mon - Fri,8AM-9PM ET
        public static Element PhoneNumberAndHours => new Element(By.XPath("//div[@data-qa='contact-phone-hours']"));

        //customerservice@biberk.com
        public static Element CustomerServiceEmail => new Element(By.XPath("//a[@data-qa='contact-email']"));
    }
}
