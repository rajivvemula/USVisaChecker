using BiBerkLOB.StepDefinition.General.Other.FAQs;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.FAQs.Policyholders
{
    public class PolicyholdersAnswers
    {
        // Back Button
        public static Element BackToPolicyHolders => new Element(By.XPath("//a[@data-qa='policyholder']"));

        // Flow
        public static FAQUserFlow DoYouOfferTemporaryFlow => new FAQUserFlow(PolicyholdersCategoryPage.DoYouOfferTemporary, BackToPolicyHolders);
        public static FAQUserFlow CanIManageMyOwnCOIFlow => new FAQUserFlow(PolicyholdersCategoryPage.CanIManageMyOwnCOI, BackToPolicyHolders);
        public static FAQUserFlow HowCanISeeCoveragesFlow => new FAQUserFlow(PolicyholdersCategoryPage.HowCanISeeCoverages, BackToPolicyHolders);
        public static FAQUserFlow HowDoIGetCOIFlow => new FAQUserFlow(PolicyholdersCategoryPage.HowDoIGetCOI, BackToPolicyHolders);
        public static FAQUserFlow HowCanIMakePolicyChangesFlow => new FAQUserFlow(PolicyholdersCategoryPage.HowCanIMakePolicyChanges, BackToPolicyHolders);
        public static FAQUserFlow IPaidYearlyForMyCovrgeFlow => new FAQUserFlow(PolicyholdersCategoryPage.IPaidYearlyForMyCovrge, BackToPolicyHolders);
        public static FAQUserFlow WhatIsEndorsementFlow => new FAQUserFlow(PolicyholdersCategoryPage.WhatIsEndorsement, BackToPolicyHolders);
        public static FAQUserFlow HowDoICancelMyPolicyFlow => new FAQUserFlow(PolicyholdersCategoryPage.HowDoICancelMyPolicy, BackToPolicyHolders);
        public static FAQUserFlow WillMyMothlyPmentBeAffctedFlow => new FAQUserFlow(PolicyholdersCategoryPage.WillMyMothlyPmentBeAffcted, BackToPolicyHolders);
        public static FAQUserFlow HowDoIFileClaimFlow => new FAQUserFlow(PolicyholdersCategoryPage.HowDoIFileClaim, BackToPolicyHolders);
        public static FAQUserFlow HowDoIDownloadMyFlow => new FAQUserFlow(PolicyholdersCategoryPage.HowDoIDownloadMy, BackToPolicyHolders);
        public static FAQUserFlow WillMyPolicyRenewFlow => new FAQUserFlow(PolicyholdersCategoryPage.WillMyPolicyRenew, BackToPolicyHolders);

        public static List<FAQUserFlow> PolicyholderFAQs => new List<FAQUserFlow>
        {
            DoYouOfferTemporaryFlow,
            CanIManageMyOwnCOIFlow,
            HowCanISeeCoveragesFlow,
            HowDoIGetCOIFlow,
            HowCanIMakePolicyChangesFlow,
            IPaidYearlyForMyCovrgeFlow,
            WhatIsEndorsementFlow,
            HowDoICancelMyPolicyFlow,
            WillMyMothlyPmentBeAffctedFlow,
            HowDoIFileClaimFlow,
            HowDoIDownloadMyFlow,
            WillMyPolicyRenewFlow
        };
    }
}
