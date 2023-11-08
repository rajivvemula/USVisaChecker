using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages
{
    [Binding]
    public class ContactUsFormSubmission
    {
        public static Element ContactUsFormSubmissionHeader => new Element(By.XPath(""));
        public static Element ContactUsFormSubmissionText => new Element(By.XPath(""));
        public static Element ContactUsFormQuestionsText => new Element(By.XPath("//h5[@data-qa='contact-header']"));
        public static Element ContactUsPhoneNumber => new Element(By.XPath("//a[@data-qa='contact-phone']"));
        public static Element ContactUsHoursText => new Element(By.XPath("//span[@data-qa='contact-hours']"));
        public static Element ContactUsFaxNumber => new Element(By.XPath("//a[@data-qa='contact-fax-phone']"));
        public static Element ContactUsPhoneIcon => new Element(By.XPath("//i[@data-qa='contact-phone-icon']"));
        public static Element ContactUsEmailIcon => new Element(By.XPath("//i[@data-qa='contact-mail-icon']"));
        public static Element ContactUsEmail => new Element(By.XPath("//a[@data-qa='contact-email']"));
        public static Element ContactUsAddress => new Element(By.XPath("//span[@data-qa='contact-address']"));
    }
}