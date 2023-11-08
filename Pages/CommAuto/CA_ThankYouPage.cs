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
    [Mapping("CA Thank You")]
    public sealed class CA_ThankYouPage
    {
        // Thank you 
        public static Element ThankYouTitle => new Element(By.XPath("//h1[@data-qa='thank-you-text']"));
        public static Element ThankYouParagraph => new Element(By.XPath("//h6[@data-qa='thank-you']"));

        //Policy Header with PolicyID - Blue
        public static Element PolicyHeader => new Element(By.XPath("//h3[@data-qa='policy-header']"));
        public static Element PolicyId => new Element(By.XPath("//span[@data-qa='policy-identifier']"));

        //Information Block About Purchased Policy - White
        public static Element CompanyName => new Element(By.XPath("//h3[@data-qa='company-name']"));
        public static Element PolicyStartsOnWithXTimeOfCoverage => new Element(By.XPath("//p[@data-qa='policy-start-name']"));
        public static Element PaymentTermsTitle => new Element(By.XPath("//p[@data-qa='payment-term-name']"));
        public static Element PaymentTermsAmount => new Element(By.XPath("//h2[@data-qa='payment-ammount-name']"));
        //ex: 12 Monthly Payments
        public static Element PaymentTermsFrequency => new Element(By.XPath("//span[@data-qa='payment-term-name']"));
        //ex: " You paid $211.92 on 12/07/2021. Confirmation Number: 40078970310 "
        public static Element PaymentMadeTodayInfo => new Element(By.XPath("//p[@data-qa='paid-amount-name']"));
        //ex: "NEXT PAYMENT DUE 01/08/2022"
        public static Element NextPaymentDueInfo => new Element(By.XPath("//p[@data-qa='next-payment-name']"));
        public static Element CopyOfPolicyMailedToYou => new Element(By.XPath("//p[@data-qa='copy-policy-name']"));

        // Make sure your business is fully covered
        public static Element TitleMakeSureBusFullCovered => new Element(By.XPath("//h3[@data-qa='fully-covered-name']"));

        /*
         * LOB Sections with CTAs
         */
        //-----------Workers' Compensation-----------
        public static Element WorkersCompAccordianCTA_Closed => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']//mat-panel-title[@data-qa='WC-available']"));
        public static Element WorkersCompAccordianCTA => new Element(By.XPath("//mat-panel-title[@data-qa='WC-available']"));
        public static Element WCWhatIsIt => new Element(By.XPath("//span[@data-qa='what-is-it-WC']"));
        public static Element WCWhyGetIt => new Element(By.XPath("//span[@data-qa='why-get-it-WC']"));
        public static Element WCExample => new Element(By.XPath("//span[@data-qa='example-WC']"));
        public static Element GetWCCTA => new Element(By.XPath("//button[@data-qa='navbtn-WC']"));


        //-----------General Liability-----------
        public static Element GeneralLibAccordianCTA => new Element(By.XPath("//mat-panel-title[@data-qa='GL-available']"));
        public static Element GLWhatIsIt => new Element(By.XPath("//span[@data-qa='what-is-it-GL']"));
        public static Element GLWhyGetIt => new Element(By.XPath("//span[@data-qa='why-get-it-GL']"));
        public static Element GLExample => new Element(By.XPath("//span[@data-qa='example-GL']"));
        public static Element GetGeneralLibCTA => new Element(By.XPath("//button[@data-qa='navbtn-GL']"));


        //-----------Professional Liability (E&O)-----------
        public static Element ProfessionalLibAccordianCTA_Closed => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']/span/mat-panel-title[@data-qa='PL-available']"));
        public static Element ProfessionalLibAccordianCTA => new Element(By.XPath("//mat-panel-title[@data-qa='PL-available']"));
        public static Element PLWhatIsIt => new Element(By.XPath("//span[@data-qa='what-is-it-PL']"));
        public static Element PLWhyGetIt => new Element(By.XPath("//span[@data-qa='why-get-it-PL']"));
        public static Element PLExample => new Element(By.XPath("//span[@data-qa='example-PL']"));
        public static Element GetProfessionalLibCTA => new Element(By.XPath("//button[@data-qa='navbtn-PL']"));


        //-----------Property & Liability (BOP)-----------
        public static Element PropertyAndLibAccordianCTA_Closed => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']/span/mat-panel-title[@data-qa='BP-available']"));
        public static Element PropertyAndLibAccordianCTA => new Element(By.XPath("//mat-panel-title[@data-qa='BP-available']"));
        public static Element BOPWhatIsIt => new Element(By.XPath("//span[@data-qa='what-is-it-BP']"));
        public static Element BOPWhyGetIt => new Element(By.XPath("//span[@data-qa='why-get-it-BP']"));
        public static Element BOPExample => new Element(By.XPath("//span[@data-qa='example-BP']"));
        public static Element GetPropertyAndLibCTA => new Element(By.XPath("//button[@data-qa='navbtn-BP']"));
    }
}
