using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Articles
{
    [Binding]
    class DoesYourBusinessNeedWCPage
    {
        //Header
        public static Element DoesYourBusinessNeedWCHeader => new Element(By.XPath("//h1[@data-qa='what-does-bonded-and-insured-mean']"));
        //Date
        public static Element DoesYourBusinessNeedWCDate => new Element(By.XPath("//span[@data-qa='blogpost-meta-date']"));
        //Category
        public static Element DoesYourBusinessNeedWCCategory => new Element(By.XPath("//span[@data-qa='blogpost-meta-category']"));
        public static Element DoesYourBusinessNeedWCText => new Element(By.XPath("//p[@data-qa='article-main-header-and-text-text-0']"));
        public static Element ShakingHands_Image => new Element(By.XPath("(//img[@data-qa='article-main-image'])[1]"));
        public static Element WhatIsWC => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[1]"));
        public static Element WCCoveresCosts => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[1]"));
        public static Element MedicalCare => new Element(By.XPath("//p[@data-qa='article-secondary-header-and-text-section-text-2'][1]"));
        public static Element LostWages => new Element(By.XPath("//p[@data-qa='article-secondary-header-and-text-section-text-3'][1]"));
        public static Element FuneralCosts => new Element(By.XPath("//p[@data-qa='article-secondary-header-and-text-section-text-4'][1]"));
        public static Element IfYouHaveAnyQuestions => new Element(By.XPath("//p[@data-qa='article-secondary-header-and-text-section-text-6'][1]"));
        public static Element WhyGetWCFromUs => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[2]"));
        public static Element WhenItComesToSomething => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[2]"));
        public static Element BiberkIsApartOf => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[2]"));
        public static Element InShortYouCanTrust => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[2]"));
        public static Element WhatDoesCoverageCost => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[3]"));
        public static Element WhatWillItCost => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[3]"));
        public static Element ToGiveYouAGeneral => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[3]"));
        public static Element IfYouChoose => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[3]"));
        public static Element HowQuicklyCanIGetWC => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[4]"));
        public static Element EverySituationIsDifferent => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[4]"));
        public static Element IsWCProvidedInMyState => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[5]"));
        public static Element IsWCProvidedInMyStateText => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[5]"));
        public static Element FAQsAboutWC => new Element(By.XPath("//h2[@data-qa='article-faqs-header']"));
        public static Element FAQsAboutWCText => new Element(By.XPath("//p[@data-qa='article-faqs-lead-text-0']"));
        public static Element WhatDoesWCNotCover => new Element(By.XPath("//h3[@data-qa='article-faqs-question-one-header']"));
        public static Element WhatDoesWCNotCoverText => new Element(By.XPath("//p[@data-qa='article-faqs-question-one-text']"));
        public static Element WCAudit => new Element(By.XPath("//h3[@data-qa='article-faqs-question-two-header']"));
        public static Element WCAuditText => new Element(By.XPath("//p[@data-qa='article-faqs-question-two-text']"));
        public static Element BizRequiredToHaveWC => new Element(By.XPath("//h3[@data-qa='article-faqs-question-three-header']"));
        public static Element BizRequiredToHaveWCText => new Element(By.XPath("//p[@data-qa='article-faqs-question-three-text']"));
        public static Element ImSelfEmployed => new Element(By.XPath("//h3[@data-qa='article-faqs-question-four-header']"));
        public static Element ImSelfEmployedText => new Element(By.XPath("//p[@data-qa='article-faqs-question-four-text']"));
        public static Element PeaceOfMind => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[6]"));
        public static Element PeaceOfMindText => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[6]"));
        public static Element RelatedArticles => new Element(By.XPath("//h1[@data-qa='related-articles-heading']"));
        public static Element WhatIsWCPayrollAudit => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[1]"));
        public static Element WhatIsWCPayrollAuditText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[1]"));
        public static Element WhatIsWCPayrollAudit_image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[1]"));
        public static Element RelatedWhatIsWC => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[2]"));
        public static Element RelatedWhatIsWCText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[2]"));
        public static Element RelatedWhatIsWC_image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[2]"));
        public static Element EngineeringInsurance => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[3]"));
        public static Element EngineeringInsuranceText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[3]"));
        public static Element EngineeringInsurance_image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[3]"));
    }
}