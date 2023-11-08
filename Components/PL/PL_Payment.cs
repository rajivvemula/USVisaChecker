using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using HitachiQA;

namespace BiBerkLOB.Components.PL
{
    class PL_Payment
    {
        string baseXPath;

        public PL_Payment(string questionText)
        {
            baseXPath = $"//section[.//h3[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{questionText.ToLower()}\"]]";
        }

        public void EnterInput(string placeholderText, string value)
        {
            string inputXPath = $"{baseXPath}//input[@placeholder=\"{placeholderText}\"]";
            Log.Info(inputXPath);
            IWebElement theField = UserActions.FindElementWaitUntilClickable(By.XPath(inputXPath));
            theField.Click();
            theField.SendKeys(Keys.Control + "a");
            theField.SendKeys(Keys.Delete);
            theField.SendKeys(value);

        }
    }
}
