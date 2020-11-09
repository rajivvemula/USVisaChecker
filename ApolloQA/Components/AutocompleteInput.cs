using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Components
{
    class AutocompleteInput
    {
        By locator;

        public AutocompleteInput(string fieldLabel)
        {
            string xpath = $"//mat-label[normalize-space(text())='{fieldLabel}']/../../preceding-sibling::bh-input-autocomplete/input";

            locator = By.XPath(xpath);
        }

        public AutocompleteInput(By locator)
        {
            this.locator = locator;
        }

        IWebElement autocompleteField => UserActions.FindElementWaitUntilVisible(locator, UserActions.DEFAULT_WAIT_SECONDS);

        public string GetValue()
        {
            return autocompleteField.Text;
        }

        public bool SetValue(string value)
        {
            autocompleteField.Click();
            autocompleteField.SendKeys(Keys.Control + "a");
            autocompleteField.SendKeys(Keys.Delete);
            autocompleteField.SendKeys(value);

            //clicks option matching value (ignoring case)
            IWebElement theSelection = UserActions.FindElementWaitUntilClickable(
                By.XPath("//mat-option[contains(@class,'provided') and .//div[@class='line-label' and translate(normalize-space(text()), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '" + value.ToLower() + "']]"),
                UserActions.DEFAULT_WAIT_SECONDS);

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

    }
}
