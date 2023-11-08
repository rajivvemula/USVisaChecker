using OpenQA.Selenium;
using HitachiQA.Driver;

namespace BiBerkLOB.Pages.Other.FAQs.Policyholders
{
    public class PolicyholdersCategoryPage : CategoryBase
    {
        //Do you offer temporary coverage?
        public static Element DoYouOfferTemporary => new Element(By.XPath("//a[@data-qa='do-you-offer-temporary-coverage']"));

        //Can I manage my own certificates of insurance?
        public static Element CanIManageMyOwnCOI => new Element(By.XPath("//a[@data-qa='can-i-manage-my-own-certificates-of-insurance']"));

        //How can I see the coverages and limits included in my policy?
        public static Element HowCanISeeCoverages => new Element(By.XPath("//a[@data-qa='how-can-i-see-the-coverages-and-limits-included-in-my-policy']"));

        //How do I get a certificate of insurance?
        public static Element HowDoIGetCOI => new Element(By.XPath("//a[@data-qa='how-do-i-get-a-certificate-of-insurance']"));

        //How can I make policy changes?
        public static Element HowCanIMakePolicyChanges => new Element(By.XPath("//a[@data-qa='how-can-i-make-policy-changes']"));

        //I paid yearly for my coverage or I have no remaining payments on my payment plan.How will my payments be affected by the policy change?
        public static Element IPaidYearlyForMyCovrge => new Element(By.XPath("//a[@data-qa='i-paid-yearly-for-my-coverage-or-i-have-no-remaining-payments-on-my-payment-plan-how-will-my-payments-be-affected-by-the-policy-change']"));

        //What is an endorsement?
        public static Element WhatIsEndorsement => new Element(By.XPath("//a[@data-qa='what-is-an-endorsement']"));

        //How do I cancel my policy?
        public static Element HowDoICancelMyPolicy => new Element(By.XPath("//a[@data-qa='how-do-i-cancel-my-policy']"));

        //Will my monthly payment be affected by the policy change?
        public static Element WillMyMothlyPmentBeAffcted => new Element(By.XPath("//a[@data-qa='will-my-monthly-payment-be-affected-by-the-policy-change']"));

        //How do I file a claim?
        public static Element HowDoIFileClaim => new Element(By.XPath("//a[@data-qa='how-do-i-file-a-claim']"));

        //How do I download my policy documents?
        public static Element HowDoIDownloadMy => new Element(By.XPath("//a[@data-qa='how-do-i-download-my-policy-documents']"));

        //Will my policy automatically renew?
        public static Element WillMyPolicyRenew => new Element(By.XPath("//a[@data-qa='will-my-policy-automatically-renew']"));
    }
}
