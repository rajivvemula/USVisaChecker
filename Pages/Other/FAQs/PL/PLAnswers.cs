using BiBerkLOB.StepDefinition.General.Other.FAQs;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BiBerkLOB.Pages.Other.FAQs.PL
{
    public sealed class PLAnswers
    {
        // Back Button
        public static Element BackToPL => new Element(By.XPath("//a[@data-qa='professional-liability']"));

        // Flow
        public static FAQUserFlow DefPLAuditFlow => new FAQUserFlow(PLCategoryPage.DefPLAudit, BackToPL);
        public static FAQUserFlow WhatIsPLFlow => new FAQUserFlow(PLCategoryPage.WhatIsPL, BackToPL);
        public static FAQUserFlow WhatsPayrollRemunerationFlow => new FAQUserFlow(PLCategoryPage.WhatsPayrollRemuneration, BackToPL);
        public static FAQUserFlow InfoToCompleteAuditFlow => new FAQUserFlow(PLCategoryPage.InfoToCompleteAudit, BackToPL);
        public static FAQUserFlow WhoNeedsPLFlow => new FAQUserFlow(PLCategoryPage.WhoNeedsPL, BackToPL);
        public static FAQUserFlow ArePLAndEOSameFlow => new FAQUserFlow(PLCategoryPage.ArePLAndEOSame, BackToPL);
        public static FAQUserFlow PLVSGLFlow => new FAQUserFlow(PLCategoryPage.PLVSGL, BackToPL);
        public static FAQUserFlow WhatsTheMinRequiredFlow => new FAQUserFlow(PLCategoryPage.WhatsTheMinRequired, BackToPL);
        public static FAQUserFlow WhatDoesPLCostFlow => new FAQUserFlow(PLCategoryPage.WhatDoesPLCost, BackToPL);
        public static FAQUserFlow DoesBiberkOfferPLFlow => new FAQUserFlow(PLCategoryPage.DoesBiberkOfferPL, BackToPL);
        public static FAQUserFlow WhatsPLAuditFlow => new FAQUserFlow(PLCategoryPage.WhatsPLAudit, BackToPL);
        public static FAQUserFlow PLCoversBaselessLawsuitFlow => new FAQUserFlow(PLCategoryPage.PLCoversBaselessLawsuit, BackToPL);
        public static FAQUserFlow HowMuchPLDoINeedFlow => new FAQUserFlow(PLCategoryPage.HowMuchPLDoINeed, BackToPL);
        public static FAQUserFlow DidntComplyWithAuditFlow => new FAQUserFlow(PLCategoryPage.DidntComplyWithAudit, BackToPL);

        public static List<FAQUserFlow> PLAnswersFAQs => new List<FAQUserFlow>
        {
            DefPLAuditFlow,
            WhatIsPLFlow,
            WhatsPayrollRemunerationFlow,
            InfoToCompleteAuditFlow,
            WhoNeedsPLFlow,
            ArePLAndEOSameFlow,
            PLVSGLFlow,
            WhatsTheMinRequiredFlow,
            WhatDoesPLCostFlow,
            DoesBiberkOfferPLFlow,
            WhatsPLAuditFlow,
            PLCoversBaselessLawsuitFlow,
            HowMuchPLDoINeedFlow,
            DidntComplyWithAuditFlow
        };
    }
}