using BiBerkLOB.StepDefinition.General.Other.FAQs;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.FAQs.UM
{

    public class UMAnswers
    {
        //Back to Category Button
        public static Element BackToUmbrella => new Element(By.XPath("//a[@data-qa='umbrella-commercial-excess']"));

        //Flow       
        public static FAQUserFlow CoveredUnderUMFlow => new FAQUserFlow(UMCategoryPage.CoveredUnderUM, BackToUmbrella);
        public static FAQUserFlow NotCoveredUnderUMFlow => new FAQUserFlow(UMCategoryPage.NotCoveredUnderUM, BackToUmbrella);
        public static FAQUserFlow DoINeedUMFlow => new FAQUserFlow(UMCategoryPage.DoINeedUM, BackToUmbrella);
        public static FAQUserFlow HowMuchUMFlow => new FAQUserFlow(UMCategoryPage.HowMuchUM, BackToUmbrella);
        public static FAQUserFlow WhatIsUMFlow => new FAQUserFlow(UMCategoryPage.WhatIsUM, BackToUmbrella);
        public static List<FAQUserFlow> UMAnswersFAQs => new List<FAQUserFlow>
        {
            CoveredUnderUMFlow,
            NotCoveredUnderUMFlow,
            DoINeedUMFlow,
            HowMuchUMFlow,
            WhatIsUMFlow
        };
    }
}