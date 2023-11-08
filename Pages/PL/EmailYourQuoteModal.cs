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
    class EmailYourQuoteModal
    {
        //Email Your Quote Modal
        public static Element EmailMyQuoteBttn => new Element(By.XPath("//a[@data-qa='email-my-quote-modal']"));
        public static Element YourQuoteID => new Element(By.XPath("//div[@data-qa='email-modal-quoteID']"));
        public static Element EmailYourPolicyQuoteHeader => new Element(By.XPath("//h2[@data-qa='email-modal-title']"));
        public static Element ChooseYourInsurancePlanHeaader => new Element(By.XPath("//h3[@data-qa='email-modal-subHeader-text']"));
        public static Element StandardPlanCTA => new Element(By.XPath("//md-checkbox[@data-qa='Standard-plan-checkbox']"));
        public static Element PlusPlanCTA => new Element(By.XPath("//md-checkbox[@data-qa='Plus-plan-checkbox']"));
        public static Element PlusPlan => new Element(By.XPath("//p[@data-qa='Plus-plan']/ancestor::figure"));
        public static Element StandardPlan => new Element(By.XPath("//p[@data-qa='Standard-plan']/ancestor::figure"));
        public static Element EmailAddressQST => new Element(By.XPath("//p[@data-qa='email-my-quote-text']"));
        public static Element EmailAddressTxtbox => new Element(By.XPath("//div[@data-qa='email-chip-1']"));
        public static Element EmailAddressError => new Element(By.XPath("//span[@data-qa='email-error']"));
        public static Element EmailYourQuoteCTA => new Element(By.XPath("//button[@data-qa='email-policy-button']"));
        public static Element EmailYourQuoteExitBttn => new Element(By.XPath("//i[@data-qa='email-modal-x-icon']"));
        public static Element PolicyEmailedToaster => new Element(By.XPath("//div[contains(text(),'Your policy quote details have been emailed.')]"));

        public static List<Element> BaseElements = new List<Element>
        {
            EmailMyQuoteBttn,
            YourQuoteID,
            EmailYourPolicyQuoteHeader,
            ChooseYourInsurancePlanHeaader
        };

        public static List<Element> StandardElements = new List<Element> 
        {
            StandardPlan,
            StandardPlanCTA,
        };

        public static List<Element> PlusElements = new List<Element>
        {
            PlusPlan,
            PlusPlanCTA
        };
        
        public static List<Element> EmailElements = new List<Element>
        {
            EmailAddressQST,
            EmailAddressTxtbox,
            EmailAddressQST,
            EmailYourQuoteCTA
        };
    }
}