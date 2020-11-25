using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Components
{
    class InputField
    {

        By locator;

        public InputField (string fieldLabel)
        {
            string xpath = $"//mat-label[normalize-space(text())='{fieldLabel}']/../../preceding-sibling::input | " +
                           $"//mat-label[normalize-space(text())='{fieldLabel}']/../../preceding-sibling::textarea |" +
                           $"//mat-label[normalize-space(text())='{fieldLabel}']/../../preceding-sibling::*/input";

            locator = By.XPath(xpath);
        }

        public InputField(By locator)
        {
           this.locator = locator;
        }

        IWebElement inputField => UserActions.FindElementWaitUntilClickable(locator, UserActions.DEFAULT_WAIT_SECONDS);

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
