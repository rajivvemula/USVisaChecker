using BiBerkLOB.StepDefinition.General.Other.FAQs;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.FAQs.GL
{

    public class GLAnswers
    {
        //Back to Category Button
        public static Element BackToGL=> new Element(By.XPath("//a[@data-qa='general-liability']"));
       
        //Flow       
        public static FAQUserFlow ReqByLawFlow => new FAQUserFlow(GLCategoryPage.ReqByLaw, BackToGL);
        public static FAQUserFlow DoNeedGLFlow => new FAQUserFlow(GLCategoryPage.DoNeedGL, BackToGL);
        public static FAQUserFlow PrimaryVSGLFlow => new FAQUserFlow(GLCategoryPage.PrimaryVSGL, BackToGL);
        public static FAQUserFlow GLInMyStateFlow => new FAQUserFlow(GLCategoryPage.GLInMyState, BackToGL);
        public static FAQUserFlow GLCostFlow => new FAQUserFlow(GLCategoryPage.GLCost, BackToGL);
        public static FAQUserFlow EligibleForGLFlow => new FAQUserFlow(GLCategoryPage.EligibleForGL, BackToGL);
        public static FAQUserFlow GLCoverLawsuitsFlow => new FAQUserFlow(GLCategoryPage.GLCoverLawsuits, BackToGL);
        public static FAQUserFlow GLCoverPLFlow => new FAQUserFlow(GLCategoryPage.GLCoverPL, BackToGL);
        public static FAQUserFlow DiffGLAndPLFlow => new FAQUserFlow(GLCategoryPage.DiffGLAndPL, BackToGL);
        public static FAQUserFlow HoMuchGLFlow => new FAQUserFlow(GLCategoryPage.HoMuchGL, BackToGL);
        public static FAQUserFlow WhatIsGLFlow => new FAQUserFlow(GLCategoryPage.WhatIsGL, BackToGL);
        public static FAQUserFlow HowIProveGLFlow => new FAQUserFlow(GLCategoryPage.HowIProveGL, BackToGL);
        public static List<FAQUserFlow> GLAnswersFAQs => new List<FAQUserFlow>
        {
            ReqByLawFlow,
            DoNeedGLFlow ,
            PrimaryVSGLFlow,
            GLInMyStateFlow,
            GLCostFlow,
            EligibleForGLFlow,
            GLCoverLawsuitsFlow,
            GLCoverPLFlow,
            DiffGLAndPLFlow,
            HoMuchGLFlow,
            WhatIsGLFlow,
            HowIProveGLFlow

        };
    }
}
