using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BiBerkLOB.Components
{
    class AutoCompleteInput
    {
        By fieldLocator;

        public AutoCompleteInput(string questionText)
        {

            //find me a fieldset (containing a label with lowercase text equal to 'question text') then give me back the input contained within a bb-auto-complete
            string inputXPath = $"//fieldset[.//label[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{questionText.ToLower()}\"]]//bb-auto-complete//input";

            fieldLocator = By.XPath(inputXPath);
        }

        IWebElement autocompleteField => UserActions.FindElementWaitUntilClickable(fieldLocator);

        public string GetValue()
        {
            return autocompleteField.GetAttribute("value");
        }

        public void EnterInput(string value)
        {
            autocompleteField.Click();
            autocompleteField.SendKeys(Keys.Control + "a");
            autocompleteField.SendKeys(Keys.Delete);
            autocompleteField.SendKeys(value);
        }

        public void SetValue(string value)
        {
            autocompleteField.Click();
            autocompleteField.SendKeys(Keys.Control + "a");
            autocompleteField.SendKeys(Keys.Delete);
            autocompleteField.SendKeys(value);
            SelectOption(value);
        }

        public static IWebElement GetOption(string optionText)
        {

            //finds and returns the webelement of the option we seek

            string optionXPath = $"//ul[contains(@class, 'auto-complete-results')]//li[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{optionText.ToLower()}\"]";

            return UserActions.FindElementWaitUntilClickable(By.XPath(optionXPath), 15);

        }

        public static bool OptionIsPresent(string optionText)
        {
            try
            {
                return GetOption(optionText).Displayed;

            }
            catch
            {
                return false;
            }
        }

        public static void SelectOption(string optionText)
        {
            GetOption(optionText).Click();
        }
    }
}
