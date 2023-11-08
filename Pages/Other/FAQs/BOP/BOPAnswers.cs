using BiBerkLOB.StepDefinition.General.Other.FAQs;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BiBerkLOB.Pages.Other.FAQs.BOP
{
    public class BOPAnswers
    {
        public static Element BackToBOP => new Element(By.XPath("//a[@data-qa='business-owners-policy']"));

        public static FAQUserFlow PurchasedBOPDoINeedGLToo => new FAQUserFlow(BOPCategoryPage.PurchasedBOPDoINeedGLToo, BackToBOP);
        public static FAQUserFlow WhatCoverageProvidedUnderBOP => new FAQUserFlow(BOPCategoryPage.WhatCoverageProvidedUnderBOP, BackToBOP);
        public static FAQUserFlow InsureBldngAndBizProperty => new FAQUserFlow(BOPCategoryPage.InsureBldngAndBizProperty, BackToBOP);
        public static FAQUserFlow DoesBOPIncludeAutoAndWC => new FAQUserFlow(BOPCategoryPage.DoesBOPIncludeAutoAndWC, BackToBOP);
        public static FAQUserFlow IfIDontNeedCoverageForBOP => new FAQUserFlow(BOPCategoryPage.IfIDontNeedCoverageForBOP, BackToBOP);
        public static FAQUserFlow DiffernceBetweenBOPAndPackage => new FAQUserFlow(BOPCategoryPage.DiffernceBetweenBOPAndPackage, BackToBOP);
        public static FAQUserFlow HowAreBOPAndGLDifferent => new FAQUserFlow(BOPCategoryPage.HowAreBOPAndGLDifferent, BackToBOP);
        public static FAQUserFlow WhatsMinAmountOfLiability => new FAQUserFlow(BOPCategoryPage.WhatsMinAmountOfLiability, BackToBOP);
        public static FAQUserFlow WhatIsLiabilityInsurance => new FAQUserFlow(BOPCategoryPage.WhatIsLiabilityInsurance, BackToBOP);
        public static FAQUserFlow HowsMyBOPPremiumDetermined => new FAQUserFlow(BOPCategoryPage.HowsMyBOPPremiumDetermined, BackToBOP);

        public static List<FAQUserFlow> BOPFAQs => new List<FAQUserFlow>
        {
            PurchasedBOPDoINeedGLToo,
            WhatCoverageProvidedUnderBOP,
            InsureBldngAndBizProperty,
            DoesBOPIncludeAutoAndWC,
            IfIDontNeedCoverageForBOP,
            DiffernceBetweenBOPAndPackage,
            HowAreBOPAndGLDifferent,
            WhatsMinAmountOfLiability,
            WhatIsLiabilityInsurance,
            HowsMyBOPPremiumDetermined,
        };
    }
}
