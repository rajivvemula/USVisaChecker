using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Pages
{
    class DeclinePage : Reusable_PurchasePath
    {
        // We are sorry
        public static Element WeAreSorry => new Element(By.XPath("(//*[contains(@data-qa,'declined')])[1]"));

        /*Unfortunately we are unable to offer insurance for your business at this time. We respect your time, so we are telling you this as soon as 
         we were able to determine we wouldn’t be able to offer you a quote today. 
         We are always working to be able to cover more businesses and we hope to be able to cover yours in the future as we grow ours.
          */
        public static Element Text1 => new Element(By.XPath("(//p[contains(@data-qa,'declined')])[1]"));

        /* If you think there was a mistake or have questions regarding why you received this message, 
         * please call us at 1-844-472-0967. We welcome any feedback you may have to help us improve our website or the products we offer. 
         */
        public static Element Text2 => new Element(By.XPath("(//p[contains(@data-qa,'declined')])[2]"));
        public static Element PhoneNum => new Element(By.XPath("(//p[contains(@data-qa,'declined')])[2]/a"));
        
        // Go to Homepage CTA - only for WC
        public static Element GoToHomepageCTA => new Element(By.XPath("//button[@data-qa='declined_go_home_button']"));

        //Quote ID - Only for CA
        public static Element CAQuoteID_Decline => new Element(By.XPath("//div[@data-qa='quoteID-ribbon']"));

        // We are sorry, but a system error has occurred. Please contact technical support. Thank you.
        public static Element SystemErrorText => new Element(By.XPath("//h2[contains(text(),'re sorry')]"));
        // Return to Homepage CTA 
        public static Element ReturnToHomePageCTA => new Element(By.XPath("//button[contains(text(),'go to home')]"));
    }
}
