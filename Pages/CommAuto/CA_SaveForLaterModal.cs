using BiBerkLOB.Pages.Other;
using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Save for Later")]
    public sealed class CA_SaveForLaterModal
    {
        public static Element SaveYourProgressTitle => new Element(By.XPath("//h2[@data-qa='Save your progress-header']"));
        public static Element SaveYourProgressCloseButton => new Element(By.XPath("//button[@data-qa='close-modal']"));
    }
}
