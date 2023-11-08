using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components.PL
{
    class PL_InputField
    {
        string baseXPath;

        public PL_InputField(string questionText)
        {
            //Base XPath of the Component - gets us the fieldset, matching on question label text
            baseXPath = $"//fieldset[.//label[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{questionText.ToLower()}\"]]";

        }

        /* The component's sub-elements - these are "expression-bodied members" which are like member variables 
            but they dynamically call the referenced => function/expression each time the variable is referenced (helps avoid stale elements). */
        IWebElement inputField => UserActions.FindElementWaitUntilClickable(By.XPath($"{baseXPath}//md-input//input"));
        IWebElement helpIcon => UserActions.FindElementWaitUntilClickable(By.XPath($"{baseXPath}//i[contains(@class, 'help-icon')]"));
        IWebElement helpText => UserActions.FindElementWaitUntilClickable(By.XPath($"{baseXPath}//div[contains(@class, 'helper-text')]//div"));
        IWebElement helpTextClose => UserActions.FindElementWaitUntilClickable(By.XPath($"{baseXPath}//span[contains(@class, 'close-icon')]"));
        IWebElement subtext => UserActions.FindElementWaitUntilClickable(By.XPath($"{baseXPath}//span[@class='info']"));
        IWebElement errorText => UserActions.FindElementWaitUntilClickable(By.XPath($"{baseXPath}//span[@class='error']"));


        /* Simple functions that encapsulate the actions available for interacting with the component */

        public string GetValue()
        {
            return inputField.GetAttribute("value");
        }

        public string GetSubtext()
        {
            return subtext.Text.Trim();
        }

        public string GetErrorText()
        {
            //have to click outside the input in order to prompt error text to appear
            //just click something
            UserActions.FindElementWaitUntilVisible(By.XPath("//h1")).Click();
            return errorText.Text.Trim();
        }

        public string GetHelpText()
        {
            helpIcon.Click();
            string result = helpText.Text.Trim();
            helpTextClose.Click();
            return result;
        }

        public void EnterInput(string value)
        {
            inputField.Click();
            inputField.SendKeys(Keys.Control + "a");
            inputField.SendKeys(Keys.Delete);
            inputField.SendKeys(value);
        }

    }
}
