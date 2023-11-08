using HitachiQA.Driver;
using OpenQA.Selenium;
namespace BiBerkLOB.Pages.Other
{
    public sealed class Careers_Page
    {
        public static Element CareerPageheader => new Element(By.XPath("//h1[@data-qa='careers']"));
        public static Element CareerPagesubheader => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
        public static Element OpenPositionsButton => new Element(By.XPath("//button[@data-qa='page-banner-button']"));
    }
}
