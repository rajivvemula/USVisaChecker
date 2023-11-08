using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.FAQs.UM
{
    public class UMCategoryPage : CategoryBase
    {
        //Umbrella Header
        public static Element UmbrellaHeader => new Element(By.XPath("//h1[@data-qa='faq-category-list-header']"));

        //What is covered under an umbrella insurance policy?
        public static Element CoveredUnderUM => new Element(By.XPath("//a[@data-qa='what-is-covered-under-an-umbrella-insurance-policy']"));

        //What is not covered under an umbrella insurance policy?
        public static Element NotCoveredUnderUM=> new Element(By.XPath("//a[@data-qa='what-is-not-covered-under-an-umbrella-insurance-policy']"));

        //Do I need umbrella insurance?
        public static Element DoINeedUM => new Element(By.XPath("//a[@data-qa='do-i-need-umbrella-insurance']"));

        //How much umbrella insurance do I need?
        public static Element HowMuchUM => new Element(By.XPath("//a[@data-qa='how-much-umbrella-insurance-do-i-need']"));

        //What is umbrella insurance?
        public static Element WhatIsUM => new Element(By.XPath("//a[@data-qa='what-is-umbrella-insurance']"));

    }
}