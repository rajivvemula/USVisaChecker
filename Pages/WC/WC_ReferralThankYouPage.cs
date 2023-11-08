using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.WC
{
    [Binding]
    public sealed class WC_ReferralThankYouPage
    {
        public static Element ThankYouHeader => new Element(By.XPath("//h2[@data-qa='refer_confirm_thank_you_header']"));
        public static Element ReceivedInformationText => new Element(By.XPath("//h6[@data-qa='refer_confirm_helptext']"));
        public static Element GoToHomePageBtn => new Element(By.XPath("//button[@data-qa='refer_confirm_goto_homepage']"));
    }
}