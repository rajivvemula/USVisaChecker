using BiBerkLOB.Pages.Other.FAQs.PL;
using BiBerkLOB.Pages.Other.FAQs.BOP;
using BiBerkLOB.Pages.Other.FAQs.Policyholders;
using BiBerkLOB.Pages.Other.FAQs.WC;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.Other.FAQs.CommAuto;
using BiBerkLOB.Pages.Other.FAQs.Popular;
using BiBerkLOB.Pages.Other.FAQs.GL;
using BiBerkLOB.Pages.Other.FAQs.UM;

namespace BiBerkLOB.StepDefinition.General.Other.FAQs
{
    [Binding]
    public sealed class FAQStepDefinition
    {
        [Then(@"user verifies each FAQ on the (.*) page")]
        public void ThenUserVerifiesEachFAQOnThePage(string questionCategory)
        {
            switch (questionCategory.ToLower())
            {
                case "bop":
                    ValidateFAQs(BOPAnswers.BOPFAQs);
                    break;
                case "pl":
                    ValidateFAQs(PLAnswers.PLAnswersFAQs);
                    break;
                case "policyholder":
                    ValidateFAQs(PolicyholdersAnswers.PolicyholderFAQs);
                    break;
                case "wc":
                    ValidateFAQs(WCAnswers.WorkerCompFAQsFlow);
                    break;
                case "ca":
                    ValidateFAQs(CAAnswers.CAFAQ);
                    break;
                case "popular":
                    ValidateFAQs(PopularAnswers.PopularFAQs);
                    break;
                case "gl":
                    ValidateFAQs(GLAnswers.GLAnswersFAQs);
                    break;
                case "um":
                    ValidateFAQs(UMAnswers.UMAnswersFAQs);
                    break;
            }
        }

        public void ValidateFAQs(List<FAQUserFlow> faqs)
        {
            foreach (var faq in faqs)
            {
                faq.AssertFAQ();
            }
        }
    }
}