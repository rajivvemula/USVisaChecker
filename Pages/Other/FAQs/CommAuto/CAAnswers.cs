using BiBerkLOB.Pages.Other.FAQs.CA;
using BiBerkLOB.StepDefinition.General.Other.FAQs;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BiBerkLOB.Pages.Other.FAQs.CommAuto
{
    public class CAAnswers
    {
        // Back Button
        public static Element BackToCA => new Element(By.XPath("//a[@data-qa='commercial-auto']"));

        // Flow
        public static FAQUserFlow IsBisVehicleCoveredFlow => new FAQUserFlow(CACategoryPage.IsBisVehicleCovered, BackToCA);
        public static FAQUserFlow HowMuchDoesCACostFlow => new FAQUserFlow(CACategoryPage.HowMuchDoesCACost, BackToCA);
        public static FAQUserFlow WhoIsCoveredFlow => new FAQUserFlow(CACategoryPage.WhoIsCovered, BackToCA);
        public static FAQUserFlow DoesMyBizInsuranceCoverFlow => new FAQUserFlow(CACategoryPage.DoesMyBizInsuranceCover, BackToCA);
        public static FAQUserFlow IsMyTrailerCoveredFlow => new FAQUserFlow(CACategoryPage.IsMyTrailerCovered, BackToCA);
        public static FAQUserFlow WillMyCostIncreaseFlow => new FAQUserFlow(CACategoryPage.WillMyCostIncrease, BackToCA);
        public static FAQUserFlow WhatIsCSLFlow => new FAQUserFlow(CACategoryPage.WhatIsCSL, BackToCA);
        public static FAQUserFlow WhatISCAFlow => new FAQUserFlow(CACategoryPage.WhatISCA, BackToCA);

        public static List<FAQUserFlow> CAFAQ => new List<FAQUserFlow>
        {
            IsBisVehicleCoveredFlow,
            HowMuchDoesCACostFlow,
            WhoIsCoveredFlow,
            DoesMyBizInsuranceCoverFlow,
            IsMyTrailerCoveredFlow,
            WillMyCostIncreaseFlow,
            WhatIsCSLFlow,
            WhatISCAFlow,
        };
    }
}