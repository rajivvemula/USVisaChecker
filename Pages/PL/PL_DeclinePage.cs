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
    class PL_DeclinePage
    {
        /*
         * Declined Page
         */
        public static Element CoverageDeclinedPageTitle => new Element(By.XPath("//h1[@data-qa='declined-header']"));
        public static Element DeclinedCopyOne => new Element(By.XPath("//p[@data-qa='declined-subheader']"));
        public static Element DeclinedCopyTwo => new Element(By.XPath("//p[@data-qa='declined-text']"));
        public static Element DeclinedPhoneNum => new Element(By.XPath("//a[@data-qa='referred-system-phone']"));
    }
}
