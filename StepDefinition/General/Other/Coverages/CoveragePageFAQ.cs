using System;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.SimpleInteractions;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.Other.Coverages
{
    public class CoveragePageFAQ : IStaticInteraction
    {
        private readonly Element _faqQuestion;
        private readonly Element _faqAnswer;
        private readonly Element _faqArrow;
        private readonly Element[] _faqLinks;

        public CoveragePageFAQ(Element faqQuestion, Element faqAnswer, Element faqArrow)
        {
            _faqQuestion = faqQuestion;
            _faqAnswer = faqAnswer;
            _faqArrow = faqArrow;
            _faqLinks = Array.Empty<Element>();
        }

        public CoveragePageFAQ(Element faqQuestion, Element faqAnswer, Element faqArrow, params Element[] links)
        {
            _faqQuestion = faqQuestion;
            _faqAnswer = faqAnswer;
            _faqArrow = faqArrow;
            _faqLinks = links;
        }

        public void ValidateInteraction(int waitSeconds = StaticConstants.DEFAULT_INTERACTION_SECONDS) 
        {
            _faqQuestion.AssertElementIsVisible(waitSeconds);
            _faqArrow.AssertElementIsVisible(waitSeconds);
            _faqQuestion.Click(waitSeconds);
            _faqAnswer.AssertElementIsVisible(waitSeconds);
            foreach (var faqLink in _faqLinks)
            {
                faqLink.AssertElementIsVisible(waitSeconds);
            }
        }
    }
}