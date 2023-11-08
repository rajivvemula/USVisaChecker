using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BiBerkLOB.Pages.Other.Policyholders
{
    class WorkersCompAuditPage
    {
        // Complete Workers' Compensation Audit
        public static Element WCAuditTitle => new Element(By.XPath("//h1[@data-qa='complete-workers-compensation-audit']"));
        //Workers’ Compensation Payroll Audit
        public static Element WCAuditHeader => new Element(By.XPath("//h2[@data-qa='workers-compensation-payroll-audit']"));
        //Complete the fields below to begin or complete your payroll audit.
        //Broken Data-qa 
        public static Element WCAuditHeader_Subtext => new Element(By.XPath("//p[@data-qa='workers-compensation-payroll-audit-subtitle']"));
        public static Element PolicyNumber => new Element(By.XPath("//span[@data-qa='policy-number-label']"));
        public static Element PolicyNumber_Input => new Element(By.XPath("//md-input[@data-qa='policy-number-input']//input"));
        public static Element Phone => new Element(By.XPath("//span[@data-qa='phone-number-label']"));
        public static Element Phone_Input => new Element(By.XPath("//md-input[@data-qa='phone-number-input']//input"));
        public static Element ForgotPhoneNumber_BTN => new Element(By.XPath("//a[@data-qa='forgot-phone-number']"));
        public static Element WCAudit_CTN => new Element(By.XPath("//button[@data-qa='continue-auth']"));

        //new modal pops up 
        public static Element PhoneNumberRecovery => new Element(By.XPath("//h2[@data-qa='phone-number-recovery-banner']"));
        public static Element PhoneNumberRecovery_Text => new Element(By.XPath("//p[@data-qa='phone-number-recovery-info']"));
        public static Element PolicyNumberRecovery => new Element(By.XPath("//span[@data-qa='phone-number-recovery-policy-number-label']"));
        public static Element PolicyNumberRecovery_Input => new Element(By.XPath("//md-input[@data-qa='phone-number-recovery-policy-number-input']//input"));
        public static Element EmailYourPhoneNumber_CTA => new Element(By.XPath("//button[@data-qa='email-phone-number-recovery']"));
        public static Element PolicyDetailsHaveBeenEmailed => new Element(By.XPath("//div[@data-qa='policy-details-emailed-modal']"));


        public static List<Element> WCAuditElements = new List<Element>
        {
            WCAuditTitle,
            WCAuditHeader,
            WCAuditHeader_Subtext,
            PolicyNumber,
            PolicyNumber_Input,
            Phone,
            Phone_Input,
            ForgotPhoneNumber_BTN,
            WCAudit_CTN
        };

        public static List<Element> ForgotNumElements = new List<Element>
        {
            PhoneNumberRecovery,
            PhoneNumberRecovery_Text,
            PolicyNumberRecovery,
            PolicyNumberRecovery_Input,
            EmailYourPhoneNumber_CTA
        };

    }
}