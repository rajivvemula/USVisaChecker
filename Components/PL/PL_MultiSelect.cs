using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components.PL
{
    class PL_MultiSelect
    {
        string fieldsetXPath;

        public PL_MultiSelect(string questionText)
        {
            fieldsetXPath = $"//fieldset[.//label[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{questionText.ToLower()}\"]]";
        }


        public void SelectOption(string optionText)
        {
            string optionLabelXPath = $"{fieldsetXPath}//label[.//span[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{optionText.ToLower()}\"]]";
            string optionInputXPath = $"{optionLabelXPath}//input";
            string optionSpanXPath = $"{optionLabelXPath}//span";
            IWebElement theOptionLabel = UserActions.FindElementWaitUntilClickable(By.XPath(optionLabelXPath));
            IWebElement theOptionInput = UserActions.FindElementWaitUntilPresent(By.XPath(optionInputXPath));

            if (theOptionInput.GetAttribute("checked") != "true")
            {
                theOptionLabel.Click();
            }
        }

     
    }
}
