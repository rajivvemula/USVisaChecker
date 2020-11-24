using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Components
{
    class Dropdown
    {
        By locator;

        public Dropdown(string fieldLabel)
        {
            string xpath = $"//mat-label[normalize-space(text())='{fieldLabel}']/../../preceding-sibling::mat-select";

            locator = By.XPath(xpath);
        }

        public Dropdown(By locator)
        {
            this.locator = locator;
        }

        IWebElement dropdownField => UserActions.FindElementWaitUntilVisible(locator, UserActions.DEFAULT_WAIT_SECONDS);

        public string GetValue()
        {
            return dropdownField.Text;
        }

        public bool SetValue(string value)
        {
            if (dropdownField.GetAttribute("aria-disabled") == "true")
                return false;

            dropdownField.Click();

            IWebElement theSelection = UserActions.FindElementWaitUntilClickable(By.XPath("//mat-option/span[normalize-space(text())='" + value + "']"), UserActions.DEFAULT_WAIT_SECONDS);

            try
            {
                theSelection.Click();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool SetRandom()
        {
            if (dropdownField.GetAttribute("aria-disabled") == "true")
                return false;

            dropdownField.Click();

            IList<IWebElement> options = UserActions.FindElementsWaitUntilVisible(By.XPath("//mat-option"), 5);
            //get random
            Random r = new Random();
            int rInt = r.Next(0, options.Count);
            IWebElement theSelection = options[rInt];

            theSelection.Click();
            return true;
        }

        public bool IsDisabled()
        {
            return dropdownField.GetAttribute("aria-disabled") == "true";
        }

        public bool IsRequired()
        {
            return dropdownField.GetAttribute("aria-required") == "true";
        }
    }
}
