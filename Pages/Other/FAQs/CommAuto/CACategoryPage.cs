using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.FAQs.CA
{
    public class CACategoryPage : CategoryBase
    {
        //Commercial Auto Header
        public static Element CAHeader => new Element(By.XPath("//h1[@data-qa='faq-category-list-header']"));

        //Is business vehicle covered when used for personal activities
        public static Element IsBisVehicleCovered => new Element(By.XPath("//a[@data-qa='is-business-vehicle-covered-when-used-for-personal-activities']"));

        //How much does commercial auto insurance cost on average?
        public static Element HowMuchDoesCACost => new Element(By.XPath("//a[@data-qa='how-much-does-commercial-auto-insurance-cost-on-average']"));

        //Who is covered by my small business auto insurance?
        public static Element WhoIsCovered => new Element(By.XPath("//a[@data-qa='who-is-covered-by-my-small-business-auto-insurance']"));

        //Does my small business car insurance cover items stolen from my vehicle?
        public static Element DoesMyBizInsuranceCover => new Element(By.XPath("//a[@data-qa='does-my-small-business-car-insurance-cover-items-stolen-from-my-vehicle']"));

        //Is my trailer covered if the vehicle pulling it is
        public static Element IsMyTrailerCovered => new Element(By.XPath("//a[@data-qa='is-my-trailer-covered-if-the-vehicle-pulling-it-is']"));

        //Will my cost increase if I get in an accident
        public static Element WillMyCostIncrease => new Element(By.XPath("//a[@data-qa='will-my-cost-increase-if-i-get-in-an-accident']"));

        //What is combined single limit (CSL) versus split limit coverage?
        public static Element WhatIsCSL => new Element(By.XPath("//a[@data-qa='what-is-combined-single-limit-csl-versus-split-limit-coverage']"));

        //What is commercial auto insurance for a small business?
        public static Element WhatISCA => new Element(By.XPath("//a[@data-qa='what-is-commercial-auto-insurance-for-a-small-business']"));
    }
}