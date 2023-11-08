using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components
{
    class InputField
    {
        string forAttribute;
        By inputLocator;


        //THIS IS A WORK IN PROGRESS
        // THIS APPROACH IS MORE SUITED TO THE ACTUAL PATH, NOT THE MADLIBS

        public InputField(string questionText)
        {

            string labelXPath = $"//label[text()[contains(., \"{questionText}\")]]";

            IWebElement theLabel = UserActions.FindElementWaitUntilVisible(By.XPath(labelXPath));

            forAttribute = theLabel.GetAttribute("for"); 

            inputLocator = By.XPath("//input[@for=\"{forAttribute}\"]");

        }

        IWebElement inputField => UserActions.FindElementWaitUntilClickable(inputLocator);

        public string GetValue()
        {
            return inputField.GetAttribute("value");
        }

        public void SetValue(string value)
        {
            inputField.Click();
            inputField.SendKeys(Keys.Control + "a");
            inputField.SendKeys(Keys.Delete);
            inputField.SendKeys(value);
        }

        public bool IsReadOnly()
        {
            return inputField.GetAttribute("readonly") == "true";
        }

        public bool IsRequired()
        {
            return inputField.GetAttribute("aria-required") == "true";
        }

    }
}
