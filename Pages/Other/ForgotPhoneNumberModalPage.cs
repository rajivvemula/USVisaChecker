using TechTalk.SpecFlow;
using BiBerkLOB.General;
using BiBerkLOB.Pages;
using System.Collections.Generic;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other
{
    [Binding]
    public sealed class ForgotPhoneNumberModalPage
    {
        //Forgot Phone Number
        public static Element ForgotPhoneNumberCTA => new Element(By.XPath("//a[@data-qa='forgot-phone-number']"));

        //Pop-up 'Phone Number Recovery'
        public static Element PhoneNumRecoveryTitle => new Element(By.XPath("//h2[@data-qa='phone-number-recovery-banner']"));
        public static Element PhoneNumRecoveryParagraph => new Element(By.XPath("//p[@data-qa='phone-number-recovery-info']"));
        public static Element PolicyNumberLabel => new Element(By.XPath("//span[@data-qa='phone-number-recovery-policy-number-label']"));
        public static Element PolicyNumberPNRTxtBox => new Element(By.XPath("//md-input[@data-qa='phone-number-recovery-policy-number-input']//input"));
        public static Element EmailPhoneNumberCTA_Disabled => new Element(By.XPath("//button[@data-qa='email-phone-number-recovery' and (@disabled)]"));
        public static Element EmailPhoneNumberCTA_Enabled => new Element(By.XPath("//button[@data-qa='email-phone-number-recovery' and not(@disabled)]"));
        public static Element CloseIcon => new Element(By.XPath("//a[@data-qa='phone-number-recovery-close']"));

        //Loading B (different from the Reusable Purchase Path one)
        public static Element LoadingB => new Element(By.XPath("//div[@id='loadingmodal']//img[@alt='Loading']"));

        //Successful submission toaster message
        public static Element ToasterMsgSuccessful => new Element(By.XPath("//div[@id='toast-container']/div[contains(text(),'Your policy details have been emailed.')]"));

        public static List<Element> ForgotPhoneModal => new List<Element>
        {
            PhoneNumRecoveryTitle,
            PhoneNumRecoveryParagraph,
            PolicyNumberLabel,
            PolicyNumberPNRTxtBox,
            EmailPhoneNumberCTA_Disabled
        };
    }
}