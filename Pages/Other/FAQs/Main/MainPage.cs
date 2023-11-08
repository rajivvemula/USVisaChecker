using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.FAQs.Main
{
    public class MainPage : BaseFAQPage
    {
        /*
        /* Popular
        */

        //Popular Title
        public static Element PopularTitle => new Element(By.XPath("//a[@data-qa='popular']"));

        //Can I buy and manage my policies from biberk online?
        public static Element CanIBuyAndMngeMyPoliciesFromBbrkOnline => new Element(By.XPath("//a[@data-qa='faq-category-list-link-can-i-buy-and-manage-my-policies-from-biberk-online']"));

        //Am I required to have small business insurance?
        public static Element AmIReqrdToHavSmlBizInsrnce => new Element(By.XPath("//a[@data-qa='faq-category-list-link-am-i-required-to-have-small-business-insurance']"));

        //Does biBERK provide business insurance in my state?
        public static Element DoesBbrkProvideBizInsrnceInMyState => new Element(By.XPath("//a[@data-qa='faq-category-list-link-does-biberk-provide-business-insurance-in-my-state']"));

        //What kind of small business insurance do I need?
        public static Element WhatKndOfSmlBizInsrnceDoINeed => new Element(By.XPath("//a[@data-qa='faq-category-list-link-what-kind-of-small-business-insurance-do-i-need']"));

        /*
        *Policyholder
        */

        //Policyholder Title
        public static Element PolicyholderTitle => new Element(By.XPath("//a[@data-qa='policyholder']"));

        //How do I get a certificate of liability insurance?
        public static Element HowDoIGetCLI => new Element(By.XPath("//a[@data-qa='faq-category-list-link-how-do-i-get-a-certificate-of-liability-insurance']"));

        //Can I manage my own certificates of insurance?
        public static Element CanIManageMyOwnCOI => new Element(By.XPath("//a[@data-qa='faq-category-list-link-can-i-manage-my-own-certificates-of-insurance']"));

        //How do I download my policy documents?
        public static Element HowDoIDownloadMy => new Element(By.XPath("//a[@data-qa='faq-category-list-link-how-do-i-download-my-policy-documents']"));

        //How can I see the coverages and limits included in my policy?
        public static Element HowCanISeeCoverages => new Element(By.XPath("//a[@data-qa='faq-category-list-link-how-can-i-see-the-coverages-and-limits-included-in-my-policy']"));

        /*
         * WorkersCompPage'Compensation
         */

        //WC Title
        public static Element WCTitle => new Element(By.XPath("//a[@data-qa='workers-compensation']"));

        //What is Workers Compensation insurance?
        public static Element WhatsWC => new Element(By.XPath("//a[@data-qa='what-is-workers-compensation-insurance']"));

        //Why do I need workers comp insurance?
        public static Element YDoINeedWC => new Element(By.XPath("//a[@data-qa='why-do-i-need-workers-comp-insurance']"));

        //What is covered in a workers comp policy?
        public static Element WhatsCoveredInWC => new Element(By.XPath("//a[@data-qa='what-is-covered-in-a-workers-comp-policy']"));

        //What is a workers comp audit and how does it work?
        public static Element WhatsWCAudit => new Element(By.XPath("//a[@data-qa='what-is-a-workers-comp-audit-and-how-does-it-work']"));

        /*
         * Business Owners Policy (BOP)
         */

        //BOP Title
        public static Element BOPTitle => new Element(By.XPath("//a[@data-qa='business-owners-policy']"));

        //What is liability insurance?
        public static Element WhatIsLiabilityInsurance => new Element(By.XPath("//a[@data-qa='faq-category-list-link-what-is-liability-insurance']"));

        //What types of businesses need BOP coverage?
        public static Element WhatTypesOfBisNeedBOP => new Element(By.XPath("//a[@data-qa='faq-category-list-link-what-types-of-businesses-need-bop-coverage'"));

        //Does biberk offer business owners policies in my state?
        public static Element DoesBiberkOfferBOP => new Element(By.XPath("//a[@data-qa='faq-category-list-link-does-biberk-offer-business-owners-policies-in-my-state']"));

        /*
         * Professional Liability (E&O)
         */

        //PL Title
        public static Element PLTitle => new Element(By.XPath("//a[@data-qa='professional-liability']"));

        //What is professional liability insurance?
        public static Element WhatIsPL => new Element(By.XPath("//a[@data-qa='what-is-professional-liability-insurance']"));

        //Who needs professional liability insurance?
        public static Element WhoNeedsPL => new Element(By.XPath("//a[@data-qa='who-needs-professional-liability-insurance']"));

        //Does biBERK offer professional liability insurance in my state?
        public static Element DoesBiberkOfferPL => new Element(By.XPath("//a[@data-qa='does-biberk-offer-professional-liability-insurance-in-my-state']"));

        /*
         * Commercial Auto
         */

        //CA Title
        public static Element CATitle => new Element(By.XPath("//a[@data-qa='commercial-auto']"));

        //What is commercial auto insurance for a small business?
        public static Element WhatISCA => new Element(By.XPath("//a[@data-qa='what-is-commercial-auto-insurance-for-a-small-business']"));

        //Who is covered by my small business auto insurance?
        public static Element WhoIsCovered => new Element(By.XPath("//a[@data-qa='who-is-covered-by-my-small-business-auto-insurance']"));

        //How much does commercial auto insurance cost on average?
        public static Element HowMuchDoesCACost => new Element(By.XPath("//a[@data-qa='how-much-does-commercial-auto-insurance-cost-on-average']"));

        /*
         * General Liability
         */

        //GL Title
        public static Element GLTitle => new Element(By.XPath("//a[@data-qa='general-liability']"));

        //What is GL?
        public static Element WhatIsGL => new Element(By.XPath("//a[@data-qa='what-is-general-liability-insurance']"));

        //How much does general liability insurance cost?
        public static Element HowMuchDoesGLCost => new Element(By.XPath("//a[@data-qa='how-much-does-general-liability-insurance-cost']"));

        //Do I need general liability insurance for my business?
        public static Element DoINeedGL => new Element(By.XPath("//a[@data-qa='do-i-need-general-liability-insurance-for-my-business']"));

        /*
         * Umbrella (CX)
         */

        //UM (CX) Title 
        public static Element UMTitle => new Element(By.XPath("//a[@data-qa='umbrella']"));

        //What is umbrella insurance?
        public static Element WhatIsUM => new Element(By.XPath("//a[@data-qa='what-is-umbrella-insurance']"));

        //What is covered under an umbrella insurance policy?
        public static Element WhatsCovered => new Element(By.XPath("//a[@data-qa=what-is-covered-under-an-umbrella-insurance-policy']"));

        //What is not covered under an umbrella insurance policy?
        public static Element WhatNotCovered => new Element(By.XPath("//a[@data-qa='what-is-not-covered-under-an-umbrella-insurance-policy'"));

        /*
         * Bottom of the screen
         */

        //Search Card Header
        public static Element SearchCardHeader => new Element(By.XPath("//h2[@data-qa = 'two-columns-with-search-card-header']"));

        //Search Card Text
        public static Element SearchCardText => new Element(By.XPath("//p[@data-qa = 'two-columns-with-search-card-text']"));

        //Dropdown Header
        public static Element DDHeader => new Element(By.XPath("//h4[@data-qa = 'two-columns-with-search-card-dropdown-header']"));

        //Search DD
        public static Element Dropdown => new Element(By.XPath("//select[@data-qa='two-columns-with-search-card-dropdown']//parent::div/input")); 

        //Search CTA
        public static Element SearchCTA => new Element(By.XPath("//buton[@data-qa='two-columns-with-search-card-button']")); 
    }
}
