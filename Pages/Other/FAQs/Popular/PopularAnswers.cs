using BiBerkLOB.StepDefinition.General.Other.FAQs;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.FAQs.Popular
{
    public class PopularAnswers
    {
        //Back to Category Button
        public static Element BackToPopular => new Element(By.XPath("//a[@data-qa='popular']"));
        public static Element BackToPopular2 => new Element(By.XPath("//a[@data-qa='faqs']"));

        //Flow       
        public static FAQUserFlow DoesBbrkProvideBizInsrnceFlow => new FAQUserFlow(PopularCategoryPage.DoesBbrkProvideBizInsrnceInMyState, BackToPopular);
        public static FAQUserFlow CanIBuyAndMngeMyPoliciesFlow => new FAQUserFlow(PopularCategoryPage.CanIBuyAndMngeMyPoliciesFromBbrkOnline, BackToPopular);
        public static FAQUserFlow AmIReqrdToHavInsrnceFlow => new FAQUserFlow(PopularCategoryPage.AmIReqrdToHavSmlBizInsrnce, BackToPopular);
        public static FAQUserFlow WhatKindOfBizDoINeedFlow => new FAQUserFlow(PopularCategoryPage.WhatKndOfSmlBizInsrnceDoINeed, BackToPopular);
        public static FAQUserFlow KnownglyMisclassifyingWrkersFlow => new FAQUserFlow(PopularCategoryPage.KnownglyMisclassifyingWrkersIsFraud, BackToPopular);
        public static FAQUserFlow HowImportanrIsToIdentifyIndstryFlow => new FAQUserFlow(PopularCategoryPage.IndstryTypeAndDtrmningIndstryClssifction, BackToPopular2);

        public static List<FAQUserFlow> PopularFAQs => new List<FAQUserFlow>
        {
            DoesBbrkProvideBizInsrnceFlow,
            CanIBuyAndMngeMyPoliciesFlow,
            AmIReqrdToHavInsrnceFlow,
            WhatKindOfBizDoINeedFlow,
            KnownglyMisclassifyingWrkersFlow,
            HowImportanrIsToIdentifyIndstryFlow
        };
    }
}
