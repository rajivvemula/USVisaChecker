using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components
{

    class Button
    {
        By locator;

        public Button(string buttonText)
        {
            //find me a button with 'buttontext' but also make sure it's in the in-view div (otherwise you'll find buttons from earlier/later in the madlibs)

            //string xpath = $"//div[contains(@class, 'in-view')]//button[text()[contains(., \"{buttonText}\")]]";

            string xpath = $"//div[contains(@class, 'in-view')]//button[contains(., \"{buttonText}\")]";

            locator = By.XPath(xpath);
        }


        IWebElement theButton => UserActions.FindElementWaitUntilVisible(locator);

        public bool IsEnabled()
        {
            return theButton.Enabled;
        }

        public void Click()
        {
            theButton.Click();
        }

    }
}
