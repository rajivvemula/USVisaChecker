using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.WC
{
    [Binding]
    public sealed class WC_CoverageDeclinedPage
    {
        public static Element CoverageDeclinedTitle => new Element(By.XPath("//h2[@data-qa='declined_sorry_header']"));
        public static Element UnfortunatelyParagraph => new Element(By.XPath("//p[@data-qa='declined_text_1']"));
        public static Element IfYouHaveParagraph => new Element(By.XPath("//p[@data-qa='declined_text_2']"));
        public static Element PhoneHyperLink => new Element(By.XPath(".//*[contains(@class,'container')]/descendant::*[contains(text(),'1-844-472-0967')]"));

        public static Element IfYouThinkParagraph { get; internal set; }
    }
}