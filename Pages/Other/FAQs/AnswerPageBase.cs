using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.FAQs
{
    public class AnswerPageBase : BaseFAQPage
    {
        public static Element AnswerParagraph => new Element(By.XPath("//div[@data-qa='header-with-text-answer']"));
    }
}