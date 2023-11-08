using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.FAQs.GL
{
    public class GLCategoryPage : CategoryBase
    {
        //General Liability Header
        public static Element GLHeader => new Element(By.XPath("//h1[@data-qa='faq-category-list-header']"));

        //General liability required by law?
        public static Element ReqByLaw => new Element(By.XPath("//a[@data-qa='is-general-liability-insurance-required-by-law']"));

        //Do I need general liability insurance for my business?
        public static Element DoNeedGL => new Element(By.XPath("//a[@data-qa='do-i-need-general-liability-insurance-for-my-business']"));

        //What is primary insurance versus excess insurance?
        public static Element PrimaryVSGL => new Element(By.XPath("//a[@data-qa='what-is-primary-insurance-versus-excess-insurance']"));

        //Does biBERK provide general liability insurance in my state?
        public static Element GLInMyState => new Element(By.XPath("//a[@data-qa='does-biberk-provide-general-liability-insurance-in-my-state']"));

        //How much does general liability insurance cost?
        public static Element GLCost => new Element(By.XPath("//a[@data-qa='how-much-does-general-liability-insurance-cost']"));

        //Is my business eligible for general liability insurance?
        public static Element EligibleForGL => new Element(By.XPath("//a[@data-qa='is-my-business-eligible-for-general-liability-insurance']"));

        //Does general liability insurance cover lawsuits?
        public static Element GLCoverLawsuits => new Element(By.XPath("//a[@data-qa='does-general-liability-insurance-cover-lawsuits']"));

        //Does general liability insurance cover professional liability (E&O)?
        public static Element GLCoverPL => new Element(By.XPath("//a[@data-qa='does-general-liability-insurance-cover-professional-liability-e-o']"));

        //What is the difference between general liability and professional liability (E&O)?
        public static Element DiffGLAndPL => new Element(By.XPath("//a[@data-qa='what-is-the-difference-between-general-liability-and-professional-liability-e-o']"));

        //How much general liability insurance do I need?
        public static Element HoMuchGL => new Element(By.XPath("//a[@data-qa='how-much-general-liability-insurance-do-i-need']"));

        //What is general liability insurance?
        public static Element WhatIsGL => new Element(By.XPath("//a[@data-qa='what-is-general-liability-insurance']"));

        //How do I prove I have general liability insurance?
        public static Element HowIProveGL => new Element(By.XPath("//a[@data-qa='how-do-i-prove-i-have-general-liability-insurance']"));

    }
}
