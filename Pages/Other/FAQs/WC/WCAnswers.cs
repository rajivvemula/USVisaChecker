using BiBerkLOB.Pages.Other.FAQs.Policyholders;
using BiBerkLOB.StepDefinition.General.Other.FAQs;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.FAQs.WC
{
    [Binding]
    public sealed class WCAnswers
    {
        // Back Button
        public static Element BackToWorkerComp => new Element(By.XPath("//a[@data-qa='workers-compensation']"));
        // Flow
        public static FAQUserFlow DoesBiberkProvideWCFlow => new FAQUserFlow(WCCategoryPage.DoesBiberkProvideWC, BackToWorkerComp);
        public static FAQUserFlow UseContractorsFlow => new FAQUserFlow(WCCategoryPage.UseContractors, BackToWorkerComp);
        public static FAQUserFlow HowCostIsCalculatedFlow => new FAQUserFlow(WCCategoryPage.HowCostIsCalculated, BackToWorkerComp);
        public static FAQUserFlow CanIElectIncludedFlow => new FAQUserFlow(WCCategoryPage.CanIElectIncluded, BackToWorkerComp);
        public static FAQUserFlow IfMySpouseSoleOwnersFlow => new FAQUserFlow(WCCategoryPage.IfMySpouseSoleOwners, BackToWorkerComp);
        public static FAQUserFlow WhatsPremiumAuditFlow => new FAQUserFlow(WCCategoryPage.WhatsPremiumAudit, BackToWorkerComp);
        public static FAQUserFlow WhatsPayrollRemunerationFlow => new FAQUserFlow(WCCategoryPage.WhatsPayrollRemuneration, BackToWorkerComp);
        public static FAQUserFlow WhatIsMODFlow => new FAQUserFlow(WCCategoryPage.WhatIsMOD, BackToWorkerComp);
        public static FAQUserFlow WhatsWCFlow => new FAQUserFlow(WCCategoryPage.WhatsWC, BackToWorkerComp);
        public static FAQUserFlow WhatsWCAuditFlow => new FAQUserFlow(WCCategoryPage.WhatsWCAudit, BackToWorkerComp);
        public static FAQUserFlow YDoINeedWCFlow => new FAQUserFlow(WCCategoryPage.YDoINeedWC, BackToWorkerComp);
        public static FAQUserFlow WhatDoesItCostFlow => new FAQUserFlow(WCCategoryPage.WhatDoesItCost, BackToWorkerComp);
        public static FAQUserFlow DidntComplyWithAuditFlow => new FAQUserFlow(WCCategoryPage.DidntComplyWithAudit, BackToWorkerComp);
        public static FAQUserFlow AreAllInjuriesCoveredFlow => new FAQUserFlow(WCCategoryPage.AreAllInjuriesCovered, BackToWorkerComp);
        public static FAQUserFlow WhatIsMeantFlow => new FAQUserFlow(WCCategoryPage.WhatIsMeant, BackToWorkerComp);
        public static FAQUserFlow YIsWCAuditibleFlow => new FAQUserFlow(WCCategoryPage.YIsWCAuditible, BackToWorkerComp);
        public static FAQUserFlow WhatDoesWCnotCoverFlow => new FAQUserFlow(WCCategoryPage.WhatDoesWCnotCover, BackToWorkerComp);        
        public static FAQUserFlow DoINeedWCFlow => new FAQUserFlow(WCCategoryPage.DoINeedWC, BackToWorkerComp);
        public static FAQUserFlow WhatInfoWillBeNeededFlow => new FAQUserFlow(WCCategoryPage.WhatInfoWillBeNeeded, BackToWorkerComp);
        public static List<FAQUserFlow> WorkerCompFAQsFlow => new List<FAQUserFlow>
        {
            WhatsWCFlow,
            WhatIsMODFlow,
            WhatsPayrollRemunerationFlow,
            WhatsPremiumAuditFlow,
            IfMySpouseSoleOwnersFlow,
            CanIElectIncludedFlow,
            HowCostIsCalculatedFlow,
            DoesBiberkProvideWCFlow,
            WhatsWCAuditFlow,
            YDoINeedWCFlow,
            WhatDoesItCostFlow,
            DidntComplyWithAuditFlow,
            AreAllInjuriesCoveredFlow,
            WhatIsMeantFlow,
            YIsWCAuditibleFlow,
            WhatDoesWCnotCoverFlow,
            UseContractorsFlow,
            DoINeedWCFlow,
            WhatInfoWillBeNeededFlow,
        };
    }
}