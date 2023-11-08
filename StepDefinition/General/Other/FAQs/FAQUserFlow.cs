using BiBerkLOB.Pages.Other.FAQs;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.Other.FAQs
{
    public class FAQUserFlow
    {
        private Element _backToCategory;
        private Element _questionLink;
        public FAQUserFlow(Element questionLink, Element backToCategory)
        {
            _questionLink = questionLink;
            _backToCategory = backToCategory;
        }

        public void AssertFAQ()
        {
            var dataQa = _questionLink.GetAttribute("data-qa");
            var title = new Element($"//h2[@data-qa='{dataQa}']");

            _questionLink.Click();
            BaseFAQPage.FAQTitle.AssertElementIsVisible();
            BaseFAQPage.SearchBar.AssertElementIsVisible();

            title.AssertElementIsVisible();
            AnswerPageBase.AnswerParagraph.AssertElementIsVisible();
            _backToCategory.AssertElementIsVisible();

            _backToCategory.Click();
        }
    }
}