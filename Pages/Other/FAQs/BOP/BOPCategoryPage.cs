using HitachiQA.Driver;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamitey;

namespace BiBerkLOB.Pages.Other.FAQs.BOP
{
    public class BOPCategoryPage : BaseFAQPage
    {
        //Business Owners Policy (BOP)
        public static Element BOPHeader => new Element(By.XPath("//h1[@data-qa='faq-category-list-header']"));

        //Purchased business owners do I need general liability too
        public static Element PurchasedBOPDoINeedGLToo => new Element(By.XPath("//a[@data-qa='purchased-business-owners-do-i-need-general-liability-too']"));

        //What type of coverage is provided under a business owners policy?
        public static Element WhatCoverageProvidedUnderBOP => new Element(By.XPath("//a[@data-qa='what-type-of-coverage-is-provided-under-a-business-owners-policy']"));

        //Insure building and business property for replacement value
        public static Element InsureBldngAndBizProperty => new Element(By.XPath("//a[@data-qa='insure-building-and-business-property-for-replacement-value']"));

        //Does bop include auto and workers compensation
        public static Element DoesBOPIncludeAutoAndWC => new Element(By.XPath("//a[@data-qa='does-bop-include-auto-and-workers-compensation']"));

        //What if I do not need coverage for business personal property?
        public static Element IfIDontNeedCoverageForBOP => new Element(By.XPath("//a[@data-qa='what-if-i-do-not-need-coverage-for-business-personal-property']"));

        //Whats the difference between a business owners policy and package policy?
        public static Element DiffernceBetweenBOPAndPackage => new Element(By.XPath("//a[@data-qa='the-difference-between-a-bop-and-package-policy']"));

        //How are a bop policy and general liability insurance different?
        public static Element HowAreBOPAndGLDifferent => new Element(By.XPath("//a[@data-qa='how-are-a-bop-policy-and-general-liability-insurance-different']"));

        //What is the minimum amount of liability insurance required?
        public static Element WhatsMinAmountOfLiability => new Element(By.XPath("//a[@data-qa='what-is-the-minimum-amount-of-liability-insurance-required']"));

        //What is liability insurance?
        public static Element WhatIsLiabilityInsurance => new Element(By.XPath("//a[@data-qa='what-is-liability-insurance']"));

        //How is my Business Owners Policy (BOP) premium determined?
        public static Element HowsMyBOPPremiumDetermined => new Element(By.XPath("//a[@data-qa='how-is-my-business-owners-policy-bop-premium-determined']"));

        //What does liability insurance cost?
        public static Element WhatDoesLiabilityCost => new Element(By.XPath("//a[@data-qa='what-does-liability-insurance-cost']"));

        //Whats covered by a business owners policy?
        public static Element WhatsCoveredByBOP => new Element(By.XPath("//a[@data-qa='whats-covered-by-a-business-owners-policy']"));

        //Does biberk offer business owners policies in my state?
        public static Element DoesBiberkOfferBOP => new Element(By.XPath("//a[@data-qa='does-biberk-offer-business-owners-policies-in-my-state']"));

        //How do I know how much property coverage to purchase?
        public static Element HowDoIKnowHowMuchPrperty => new Element(By.XPath("//a[@data-qa='how-do-i-know-how-much-property-coverage-to-purchase']"));

        //Coverages included in bop
        public static Element CoverageIncludedInBOP => new Element(By.XPath("//a[@data-qa='coverages-included-in-bop']"));

        //What is my TIV?
        public static Element WhatIsMyTIV => new Element(By.XPath("//a[@data-qa='what-is-my-tiv']"));

        //How much liability insurance do I need?
        public static Element HowMuchLiabilityDoINeed => new Element(By.XPath("//a[@data-qa='how-much-liability-insurance-do-i-need']"));

        //If I have a loss how does my bop help
        public static Element IfIHaveLoss => new Element(By.XPath("//a[@data-qa='if-i-have-a-loss-how-does-my-bop-help']"));

        //What if the building I own or occupy becomes vacant or partially vacant?
        public static Element WhatIfBldngIOwn => new Element(By.XPath("//a[@data-qa='what-if-the-building-i-own-or-occupy-becomes-vacant-or-partially-vacant']"));
               
        //What types of businesses need BOP coverage?
        public static Element WhatTypesOfBisNeedBOP => new Element(By.XPath("//a[@data-qa='what-types-of-businesses-need-bop-coverage']"));
    }
}
