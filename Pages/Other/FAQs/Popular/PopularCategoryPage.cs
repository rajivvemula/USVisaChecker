using OpenQA.Selenium;
using HitachiQA.Driver;

namespace BiBerkLOB.Pages.Other.FAQs.Popular
{
    public class PopularCategoryPage : CategoryBase
    {        
        //What kind of small business insurance do I need?
        public static Element WhatKndOfSmlBizInsrnceDoINeed => new Element(By.XPath("//a[@data-qa='what-kind-of-small-business-insurance-do-i-need']"));

        //Knowingly misclassifying workers is fraud
        public static Element KnownglyMisclassifyingWrkersIsFraud => new Element(By.XPath("//a[@data-qa='knowingly-misclassifying-workers-is-fraud']"));

        //Am I required to have small business insurance?
        public static Element AmIReqrdToHavSmlBizInsrnce => new Element(By.XPath("//a[@data-qa='am-i-required-to-have-small-business-insurance']"));

        //Industry type and determining industry classification
        public static Element IndstryTypeAndDtrmningIndstryClssifction => new Element(By.XPath("//a[@data-qa='industry-type-and-determining-industry-classification']"));

        //Can I buy and manage my policies from biberk online?
        public static Element CanIBuyAndMngeMyPoliciesFromBbrkOnline => new Element(By.XPath("//a[@data-qa='can-i-buy-and-manage-my-policies-from-biberk-online']"));

        //Does biBERK provide business insurance in my state?
        public static Element DoesBbrkProvideBizInsrnceInMyState => new Element(By.XPath("//a[@data-qa='does-biberk-provide-business-insurance-in-my-state']"));
    }
}
