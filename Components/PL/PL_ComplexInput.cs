using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components.PL
{
    class PL_ComplexInput
    {
        string baseXPath;

        public PL_ComplexInput(string questionText)
        {
            baseXPath = $"//fieldset[.//label[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{questionText.ToLower()}\"]]";
        }

        public void EnterInput(string placeholderText, string value)
        {
            string inputXPath = $"{baseXPath}//input[@placeholder=\"{placeholderText}\"]";
            IWebElement theField = UserActions.FindElementWaitUntilClickable(By.XPath(inputXPath));
            theField.Click();
            theField.SendKeys(Keys.Control + "a");
            theField.SendKeys(Keys.Delete);
            theField.SendKeys(value);

        }

    }
}
