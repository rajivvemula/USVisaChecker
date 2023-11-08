using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.FAQs
{
    public class CategoryBase : BaseFAQPage
    {
        public static Element CategoryTitle => new Element(By.XPath("//h1[@data-qa='faq-category-list-header']"));
        public static Element BackToMainBtn => new Element(By.XPath("//a[data-qa='faq-category-list-back-button']"));
    }
}
