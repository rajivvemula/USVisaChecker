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
    [Mapping("CA Decline")]
    public sealed class CA_DeclinePage
    {

        //QuoteID
        //ex: "Your Commercial Auto Quote ID: 9007011"
        public static Element CAQuoteID_Decline => new Element(By.XPath("//div[@data-qa='quoteID-ribbon']"));

        /*
        * Decline Based on Answers In the Path ----------------------------------------------------------
        */

        //Coverage Declined
        public static Element CoverageDeclinedTitle => new Element(By.XPath("//h1[@data-qa='coverage-declined-title']"));

        //Unfortunately, based on the information you provided, we will not be able to offer commercial auto insurance coverage for your business.
        //However we are continually looking for ways to expand our coverage capabilities, and may be able to insure businesses like yours in the future.
        public static Element UnfortunatelyNotOfferCommercialAutoIns => new Element(By.XPath("//p[@data-qa='coverage-declined-text-1']"));

        //If you have questions about why we are declining coverage at this time, or would like to provide feedback on the online quote process, please call us at
        
        public static Element ForQuestionsOrGiveFeedback => new Element(By.XPath("//p[@data-qa='coverage-declined-text-2']"));

        //1-833-224-5431.
        public static Element PhoneNumber => new Element(By.XPath("//a[@data-qa='contact-phone']"));

        /*
        * Decline Based on Madlibs ----------------------------------------------------------
        * ex: Professional Football Team
        */
        public static Element ThankYouForInterest => new Element(By.XPath("//h1[@data-qa='page-title']"));
        public static Element ThankYouForInterestParagraph => new Element(By.XPath("//h6[@data-qa='page-message']"));
    }
}
