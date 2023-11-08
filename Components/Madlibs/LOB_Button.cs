using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components
{
    class LOB_Button
    {
        By locator;

        public LOB_Button(string buttonText)
        {
            string xpath = $"//a/h5[text()[contains(., \"{buttonText}\")]]";

            locator = By.XPath(xpath);
        }


        IWebElement theButton => UserActions.FindElementWaitUntilVisible(locator, 10);

        public bool IsEnabled()
        {
            return theButton.Enabled;
        }

        public bool Click()
        {

            try
            {
                theButton.Click();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
