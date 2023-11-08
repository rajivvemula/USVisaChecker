using HitachiQA.Driver;
using OpenQA.Selenium;


namespace BiBerkLOB.Pages.Other.FAQs.PL
{
    public class PLCategoryPage : CategoryBase
    {
        //Professional Liability (E&O) Header
        public static Element PLHeader => new Element(By.XPath("//h1[@data-qa='faq-category-list-header']"));

        //Def professional liability premium audit
        public static Element DefPLAudit => new Element(By.XPath("//a[@data-qa='def-professional-liability-premium-audit']"));

        //What is professional liability insurance?
        public static Element WhatIsPL => new Element(By.XPath("//a[@data-qa='what-is-professional-liability-insurance']"));

        //What is considered payroll/remuneration?
        public static Element WhatsPayrollRemuneration => new Element(By.XPath("//a[@data-qa='what-is-considered-payroll-remuneration']"));

        //Info to complete a professional liability payroll audit
        public static Element InfoToCompleteAudit => new Element(By.XPath("//a[@data-qa='info-to-complete-a-professional-liability-payroll-audit']"));

        //Who needs professional liability insurance?
        public static Element WhoNeedsPL => new Element(By.XPath("//a[@data-qa='who-needs-professional-liability-insurance']"));

        //Are professional liability and errors and omissions insurance the same thing?
        public static Element ArePLAndEOSame => new Element(By.XPath("//a[@data-qa='are-professional-liability-and-e-o-insurance-the-same']"));

        //Professional liability versus general liability
        public static Element PLVSGL => new Element(By.XPath("//a[@data-qa='professional-liability-versus-general-liability']"));

        //What is the minimum amount of liability insurance required?
        public static Element WhatsTheMinRequired => new Element(By.XPath("//a[@data-qa='what-is-the-minimum-amount-of-liability-insurance-required']"));

        //What does professional liability insurance cost?
        public static Element WhatDoesPLCost => new Element(By.XPath("//a[@data-qa='what-does-professional-liability-insurance-cost']"));

        //Does biBERK offer professional liability insurance in my state?
        public static Element DoesBiberkOfferPL => new Element(By.XPath("//a[@data-qa='does-biberk-offer-professional-liability-insurance-in-my-state']"));

        //What is a professional liability audit and how does it work?
        public static Element WhatsPLAudit => new Element(By.XPath("//a[@data-qa='what-is-a-professional-liability-audit-and-how-does-it-work']"));

        //Professional liability cover a baseless lawsuit
        public static Element PLCoversBaselessLawsuit => new Element(By.XPath("//a[@data-qa='professional-liability-cover-a-baseless-lawsuit']"));

        //How much liability insurance do I need?
        public static Element HowMuchPLDoINeed => new Element(By.XPath("//a[@data-qa='how-much-liability-insurance-do-i-need']"));

        //Did not comply with premium audit for professional liability policy
        public static Element DidntComplyWithAudit => new Element(By.XPath("//a[@data-qa='did-not-comply-with-premium-audit-for-professional-liability-policy']"));
    }
}
