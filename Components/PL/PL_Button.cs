using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components.PL
{
    class PL_Button
    {

        string xpath1, xpath2;

        public PL_Button(string buttonText)
        {
            //will match exact match and larger
            xpath1 = $"//button[contains(@class, 'btn-large')][contains(text(), \"{buttonText}\")]"; 
            //will match exact match and smaller, also doesn't need 'with-icon'
            xpath2 = $"//button[contains(@class, 'btn-large')][contains(\"{buttonText}\", text())]";
        }


        //IWebElement theButton => UserActions.FindElementWaitUntilClickable(By.XPath(xpath1), UserActions.DEFAULT_PAGE_WAIT_SECONDS);
        IWebElement theButton => GetButton();

        private IWebElement GetButton()
        {
            try
            {
                return UserActions.FindElementWaitUntilClickable(By.XPath(xpath1), 3);
            }
            catch
            {
                return UserActions.FindElementWaitUntilClickable(By.XPath(xpath2), 3);
            }
        }

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
