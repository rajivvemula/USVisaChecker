using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using HitachiQA;

namespace BiBerkLOB.Components
{
    class MadlibsTile
    {
        By inputLocator;
        By labelLocator;

        public MadlibsTile(string tileText)
        {

            string inputXPath = $"//input[following-sibling::label[contains(normalize-space(), \"{tileText}\")]]";

            string labelXPath = $"//label[contains(normalize-space(), \"{tileText}\")]";

            inputLocator = By.XPath(inputXPath);
            labelLocator = By.XPath(labelXPath);
        }

        //both are needed. we click the label, and then the input is selected...
        IWebElement theTileInput => UserActions.FindElementWaitUntilPresent(inputLocator);
        IWebElement theTileLabel => UserActions.FindElementWaitUntilClickable(labelLocator);

        public bool IsSelected()
        {
            Log.Info(inputLocator);
            return theTileInput.Selected;
        }

        public bool Click()
        {

            try
            {
                theTileLabel.Click();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
