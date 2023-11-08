using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components.PL
{
    class PL_ComplexInputMultiple
    {
        string baseXPath;
        string numberedXPath;

        public PL_ComplexInputMultiple(string questionText, int index = 1)
        {
            baseXPath = $"//fieldset//div[@class='row'][.//label[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{questionText.ToLower()}\"]]";
            numberedXPath = $"{baseXPath}[{index}]";

        }

        public void EnterInput(string placeholderText, string value)
        {
            string inputXPath = $"{numberedXPath}//input[@placeholder=\"{placeholderText}\"]";
            IWebElement theField = UserActions.FindElementWaitUntilClickable(By.XPath(inputXPath));
            theField.Click();
            theField.SendKeys(Keys.Control + "a");
            theField.SendKeys(Keys.Delete);
            theField.SendKeys(value);

        }
    }
}
