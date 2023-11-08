using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.MakeAPayment
{
    [Binding]
    public sealed class MakeAPaymentLoginPage
    {
        public static Element PayForYourInsuranceTitle => new Element(By.XPath("//h1[@data-qa='pay-for-your-insurance']"));
        public static Element MakeAPaymentTitle => new Element(By.XPath("//h2[@data-qa='make-a-payment']"));
        public static Element MakeAPaymentParagraph => new Element(By.XPath("//h2[@data-qa='make-a-payment']//parent::div//p[contains(text(),'Making a payment')]"));

        public static Element PolicyNumberQST => new Element(By.XPath("//span[@data-qa='policy-number-label']"));
        public static Element PolicyNumberTxtbox => new Element(By.XPath("//md-input[@data-qa='policy-number-input']"));
        public static Element PolicyNumberError => new Element(By.XPath("//span[@data-qa='policy-number-input-validation-error']"));
        public static Element PhoneQST => new Element(By.XPath("//span[@data-qa='phone-number-label']")); 
        public static Element PhoneTxtbox => new Element(By.XPath("//md-input[@data-qa='phone-number-input']"));
        public static Element PhoneError => new Element(By.XPath("//span[@data-qa='phone-number-input-validation-error']"));
        public static Element ForgotPhoneNumLink => new Element(By.XPath("//a[@data-qa='forgot-phone-number']"));

        public static Element MakeAPaymentCTA_Enabled => new Element(By.XPath("//button[@data-qa='continue-auth' and not(@disabled)]"));
        public static Element MakeAPaymentCTA_Disabled => new Element(By.XPath("//button[@data-qa='continue-auth' and (@disabled)]"));

        public static List<Element> MakeAPaymentLoginPageElements => new List<Element>
        {
            PayForYourInsuranceTitle,
            MakeAPaymentTitle,
            MakeAPaymentParagraph,
            PolicyNumberQST,
            PolicyNumberTxtbox,
            PhoneQST,
            PhoneTxtbox,
            ForgotPhoneNumLink
        };
    }
}