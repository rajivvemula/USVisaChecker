using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages
{
    class CertificateEmailedToYou
    {
        public static Element EmailedToYouTitle => new Element(By.XPath("//[@data-qa='']"));
        public static Element EmailedToYouSubTitle => new Element(By.XPath("//[@data-qa='']"));
        public static Element QuestionsText => new Element(By.XPath("//h5[@data-qa='contact-header']"));
        public static Element PhoneIcon => new Element(By.XPath("//i[@data-qa='contact-phone-icon']"));
        public static Element PhoneNumber => new Element(By.XPath("//a[@data-qa='contact-phone']"));
        public static Element HoursOfOperation => new Element(By.XPath("//span[@data-qa='contact-hours']"));
        public static Element EmailIcon => new Element(By.XPath("//i[@data-qa='contact-mail-icon']"));
        public static Element Email => new Element(By.XPath("//a[@data-qa='contact-email']"));
    }
}