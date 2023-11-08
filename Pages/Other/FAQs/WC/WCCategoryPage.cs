using HitachiQA.Driver;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.FAQs.WC
{
    public class WCCategoryPage : CategoryBase
    {       

        //How is the cost of a workers compensation policy calculated?
        public static Element HowCostIsCalculated => new Element(By.XPath("//a[@data-qa='how-is-the-cost-of-a-workers-compensation-policy-calculated']"));

        //Can I elect to be included or excluded from coverage
        public static Element CanIElectIncluded => new Element(By.XPath("//a[@data-qa='can-i-elect-to-be-included-or-excluded-from-coverage']"));

        //If my spouse and I are sole owners of our business and we do not have any employees do we need workers compensation coverage?
        public static Element IfMySpouseSoleOwners => new Element(By.XPath("//a[@data-qa='owner-no-employees-do-we-need-workers-compensation']"));

        //What is a premium audit and why is this process necessary?
        public static Element WhatsPremiumAudit => new Element(By.XPath("//a[@data-qa='what-is-a-premium-audit-and-why-is-this-process-necessary']"));

        //What is covered in a workers comp policy?
        public static Element WhatsCoveredInWC => new Element(By.XPath("//a[@data-qa='what-is-covered-in-a-workers-comp-policy']"));

        //What is considered payroll remuneration?
        public static Element WhatsPayrollRemuneration => new Element(By.XPath("//a[@data-qa='what-is-considered-payroll-remuneration']"));

        //Does biBERK provide workers comp insurance in my state?
        public static Element DoesBiberkProvideWC => new Element(By.XPath("//a[@data-qa='does-biberk-provide-workers-comp-insurance-in-my-state']"));

        //What is an Experience Modification MOD? How is a MOD determined?
        public static Element WhatIsMOD => new Element(By.XPath("//a[@data-qa='what-is-an-experience-modification-mod-how-is-a-mod-determined']"));

        //What is Workers Compensation insurance?
        public static Element WhatsWC => new Element(By.XPath("//a[@data-qa='what-is-workers-compensation-insurance']"));

        //What is a workers comp audit and how does it work?
        public static Element WhatsWCAudit => new Element(By.XPath("//a[@data-qa='what-is-a-workers-comp-audit-and-how-does-it-work']"));

       //Why do I need workers comp insurance? ----
        public static Element YDoINeedWC => new Element(By.XPath("//a[@data-qa='why-do-i-need-workers-comp-insurance']"));
                            
        //What does workers compensation insurance cost? ---
        public static Element WhatDoesItCost => new Element(By.XPath("//a[@data-qa='what-does-workers-compensation-insurance-cost']"));
            
        //Did not comply with premium audit for my policy ----
        public static Element DidntComplyWithAudit => new Element(By.XPath("//a[@data-qa='did-not-comply-with-premium-audit-for-my-policy']"));
             
        //Are all on-the-job injuries covered by workers compensation coverage? ----
        public static Element AreAllInjuriesCovered => new Element(By.XPath("//a[@data-qa='are-all-on-the-job-injuries-covered-by-workers-compensation-coverage']"));

        //What is meant by Annual Employee Payroll? -----
        public static Element WhatIsMeant => new Element(By.XPath("//a[@data-qa='what-is-meant-by-annual-employee-payroll']"));
       
        //Why is workers compensation an auditable policy? ----
        public static Element YIsWCAuditible => new Element(By.XPath("//a[@data-qa='why-is-workers-compensation-an-auditable-policy']"));
            
        //What does workers’ compensation insurance not cover? -----
        public static Element WhatDoesWCnotCover => new Element(By.XPath("//a[@data-qa='what-does-workers-compensation-insurance-not-cover']"));

        //Use contractors do I need workers compensation ------
        public static Element UseContractors => new Element(By.XPath("//a[@data-qa='use-contractors-do-i-need-workers-compensation']"));

        //Do I Need Workers Comp as a Business Owner? ----
        public static Element DoINeedWC => new Element(By.XPath("//a[@data-qa='do-i-need-workers-comp-as-a-business-owner']"));

        //What information and records will be needed to complete the audit? ------
        public static Element WhatInfoWillBeNeeded => new Element(By.XPath("//a[@data-qa='what-information-and-records-will-be-needed-to-complete-the-audit']"));
    }
}
