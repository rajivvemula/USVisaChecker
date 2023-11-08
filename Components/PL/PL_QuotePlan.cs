using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components.PL
{
    class PL_QuotePlan
    {
        string baseXPath;

        public PL_QuotePlan(string planName)
        {
            baseXPath = $"//fieldset[.//legend[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{planName.ToLower()}\"]]";
        }

        public IWebElement purchaseButton => UserActions.FindElementWaitUntilClickable(By.XPath($"{baseXPath}//a[text()[contains(., 'Purchase')]]"));

    }
}
