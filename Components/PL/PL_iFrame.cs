using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components.PL
{
    class PL_iFrame
    {
        string baseXPath;
        string closeXPath;

        public PL_iFrame(string questionText)
        {
            baseXPath = "iframe[not(contains(@style, 'display: none;'))]";

            //first, check if iFrame is visible
            var frame = UserActions.FindElementWaitUntilVisible(By.XPath(baseXPath), 20);
            //then we have to switch to it
            Setup.driver.SwitchTo().Frame(frame);

            //gets us the specific elements we're interested in manipulating (inside the fieldset)
            closeXPath = $"{baseXPath}//p[@id='close_widget_form']";

        }

        IWebElement closeIcon => UserActions.FindElementWaitUntilClickable(By.XPath(closeXPath));


        public void Close()
        {
            closeIcon.Click();

            //need to switch back to DefaultContent
            Setup.driver.SwitchTo().DefaultContent();
        }
    }
}
