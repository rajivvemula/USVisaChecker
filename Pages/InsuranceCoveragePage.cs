using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages
{
    
    class InsuranceCoveragePage : Reusable_PurchasePath
    {
        //Insurance Coverage
        public static Element TitleInsCover => new Element(By.XPath("//h1[@data-qa='header-label']"));

        /*
         * Grey Banner - Get the Insurance Coverage Your Business Needs
         */
        //Get the Insurance Coverage Your Business Needs
        public static Element SubTitleGetInsCovYrBusinessNeeds => new Element(By.XPath("//h2[@data-qa='insurance-coverage-header']"));
        public static Element SubTitleGetInsCovYrBusinessNeedsParagraph => new Element(By.XPath("//p[data-qa='insurance-coverage-subheader']"));

        //Workers' Compensation
        public static Element WorkersCompLink => new Element(By.XPath("//h6[@data-qa='workers-comp-label']"));
        public static Element WorkersCompImage => new Element(By.XPath("//img[@data-qa='coverage-image_1']"));

        //Professional Liability (E&O)
        public static Element ProfessionalLiabLink => new Element(By.XPath("//h6[@data-qa='professional-liability-label']"));
        public static Element ProfessionalLiabImage => new Element(By.XPath("//img[@data-qa='coverage-image_2']"));

        //Errors&Omissions
        public static Element ErrorOmiLink => new Element(By.XPath("//h6[@data-qa='errors-omissions-label']"));
        public static Element ErrorOmiImage => new Element(By.XPath("//img[@data-qa='coverage-image_3']"));

        //General Liability
        public static Element GeneralLiabLink => new Element(By.XPath("//h6[@data-qa='general-liability-label']"));
        public static Element GeneralLiabImage => new Element(By.XPath("//img[@data-qa='coverage-image_4']"));

        //Business Owners (BOP)
        public static Element PropLiabLink => new Element(By.XPath("//h6[@data-qa='property-liability-label']"));
        public static Element PropLiabImage => new Element(By.XPath("//img[@data-qa='coverage-image_5']"));

        //Commercial Auto
        public static Element CommAutoLink => new Element(By.XPath("//h6[@data-qa='commercial-auto-label']"));
        public static Element CommAutoImage => new Element(By.XPath("//img[@data-qa='coverage-image_6']"));

        //Umbrella
        public static Element UmbrellaLink => new Element(By.XPath("//h6[@data-qa='umbrella-label']"));
        public static Element UmbrellaImage => new Element(By.XPath("//img[@data-qa='coverage-image_7']"));

        //Cyber Liability
        public static Element CyberLink => new Element(By.XPath("//h6[@data-qa='cyber-label']"));
        public static Element CyberImage => new Element(By.XPath("//img[@data-qa='coverage-image_8']"));

        /*
         * White Banner - Why biBERK for Small Business Insurance?
         */
        public static Element WhybiBERK => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element WhybiBERKSubtitle => new Element(By.XPath("//p[@data-qa='subheader-text-label_2']"));

        //Mappings for Save Time, Save Money, Experienced are in Reusable_PurchasePath

        /*
         * Blue Banner - Get a Quote Today
         */
        public static Element GetAQuoteToday => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        public static Element TrustBiberk => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element GetAQuoteCTA => new Element(By.XPath("//a[@data-qa='get-a-quote-button']"));
    }
}
