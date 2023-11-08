using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Binding]
    public sealed class CA_NoPPPage : Reusable_PurchasePath
    {
        //We're currently reviewing your submission.
        public static Element CurrentlyReviewingSubmission => new Element(By.XPath("//h2[@data-qa='nopp-header-text']"));

        //We'll be in contact in the near future, if we haven't been already
        public static Element ContactNearFuture => new Element(By.XPath("//p[@data-qa='nopp-header-subText']"));

        //Questions? Our customer service team is here to help.
        public static Element Questions => new Element(By.XPath("//h5[@data-qa='contact-footer-text']"));
        public static Element OurCustomerService => new Element(By.XPath("//p[@data-qa='contact-footer-text-continued']"));
        public static Element QuestionsCustServiceImage_Phone => new Element(By.XPath("//mat-icon[@data-qa='phone-icon']"));
        public static Element QuestionsCustServicePhoneNumber => new Element(By.XPath("//a[@data-qa='contact-phoneNumber']"));
        public static Element QuestionsCustServiceImage_Email => new Element(By.XPath("//mat-icon[@data-qa='email-icon']"));
        public static Element QuestionsCustServiceEmailAddress => new Element(By.XPath("//a[@data-qa='contact-email']"));
    }
}
