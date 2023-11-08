using Faker;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.AutopayEnrollment
{ 
    public class AutopayLoginPage : IStaticPage
    {
        //Title
        public static Element Autopay => new Element(By.XPath("//h1[@data-qa='autopay']"));
        //Header
        public static Element AutopayEnrollment => new Element(By.XPath("//h2[@data-qa='autopay-enrollment']"));
        public static Element AutopayEnrollmentText => new Element(By.XPath("//p[@data-qa='fill-the-auth-fields']"));
        public static Element PolicyNumber => new Element(By.XPath("//span[@data-qa='policy-number-label']"));
        public static Element PolicyNumberInput => new Element(By.XPath("//md-input[@data-qa='policy-number-input']//input"));
        public static Element PhoneNum => new Element(By.XPath("//span[@data-qa='phone-number-label']"));
        public static Element PhoneNumInput => new Element(By.XPath("//md-input[@data-qa='phone-number-input']//input"));
        public static Element Continue_BTN => new Element(By.XPath("//button[@data-qa='continue-auth']//span"));


        public static List<Element> AutopayLoginPageElements => new List<Element>
        {
            Autopay,
            AutopayEnrollment,
            AutopayEnrollmentText,
            PolicyNumber,
            PolicyNumberInput,
            PhoneNum,
            PhoneNumInput,
            Continue_BTN
        };
    }
}