using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.AutopayEnrollment
{
   public class AutopayComplete : IStaticPage
    {
        //Header
        public static Element AutopayEnrollmentCompleted => new Element(By.XPath("//h1[@data-qa='autopay_enrollment_complete_header']"));
        public static Element EnrollmentCompletedText => new Element(By.XPath("//p[@data-qa='autopay_enrollment_complete_subHeader']"));
    }
}