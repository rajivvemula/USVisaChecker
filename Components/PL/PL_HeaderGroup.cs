using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components.PL
{
    class PL_HeaderGroup
    {

        /* This class could possibly be made static. */

        public PL_HeaderGroup()
        {

        }

        IWebElement header => UserActions.FindElementWaitUntilVisible(By.XPath("//h1[contains(@class, 'bright-blue-text')]"));
        IWebElement subheader => UserActions.FindElementWaitUntilVisible(By.XPath("//h6[@class='m-none']"));
        IWebElement currentStep => UserActions.FindElementWaitUntilVisible(By.XPath("//div[contains(@class, 'step-current')]"));
        IWebElement pageErrorText => UserActions.FindElementWaitUntilVisible(By.XPath("//div[@class='validation-state']"));


        public string GetHeaderText()
        {
            return header.Text;
        }

        public string GetSubheaderText()
        {
            return subheader.Text;
        }

        public string GetCurrentStep()
        {
            return currentStep.GetAttribute("title");
        }
        public string GetPageErrorText()
        {
            return pageErrorText.Text;
        }

    }
}
