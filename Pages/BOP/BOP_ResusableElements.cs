using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.BOP
{
    public class BOP_ResusableElements
    {
        //Header
        public static Element HeaderHomeButton => new Element(By.XPath("//a[@data-qa='header-homeButton']"));
        public static Element QuoteIDRibbon => new Element(By.XPath("//div[@data-qa='quoteID-ribbon']"));
        
        //Stepper bar
        public static Element StepperBar => new Element(By.XPath("//div[@data-qa='stepper-section']"));
        public static Element AddressProgressBar => new Element(By.XPath("//div[starts-with(@class,'mat-progress-bar-primary')]"));

        //Universal Error Messages
        public static Element ErrorHeader => new Element(By.XPath("//div[@data-qa='error-header']"));
        public static Element ErrorTitle => new Element(By.XPath("//div[@data-qa='bbnav-error-title']"));
        public static Element ErrorMsg => new Element(By.XPath("//div[@data-qa='bbnav-error-message']"));

        //Navigation Buttons:
        public static Element LetsGoButton => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));
        public static Element BackButton => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));

        //A flag, was created specifically for Team Automation to check against to see if changes were happening on the page similar to CA PP
        //The attribute data-stchg in this element changes from false to true. Is used in SingleChoiceGroupInput construct on BOP_BusinessDetailsPage
        public static Element InflightStatusElement => new Element(By.XPath("//bb-inflight-status/div"));
    }
}
