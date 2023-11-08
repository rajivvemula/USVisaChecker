using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components
{
    class TilesFieldset
    {
        string fieldsetXPath;

        public TilesFieldset(string questionText)
        {
            fieldsetXPath = $"//fieldset[//label[contains(normalize-space(), \"{questionText}\")]]";
        }


        public bool TileIsPresent(string tileText)
        {
            string labelXPath = $"//label[contains(normalize-space(), \"{tileText}\")]";
            string combinedXPath = fieldsetXPath + labelXPath;
            IWebElement theTile = UserActions.FindElementWaitUntilPresent(By.XPath(combinedXPath));
            return theTile.Displayed;
        }

        public bool TileIsSelected(string tileText)
        {
            string inputXPath = $"//input[following-sibling::label[contains(normalize-space(), \"{tileText}\")]]";
            string combinedXPath = fieldsetXPath + inputXPath;
            IWebElement theTile = UserActions.FindElementWaitUntilPresent(By.XPath(combinedXPath));
            return theTile.Selected;

        }

        public bool ClickTile(string tileText)
        {
            string inputXPath = $"//input[following-sibling::label[normalize-space()=\"{tileText}\"]]";
            string combinedXPath = fieldsetXPath + inputXPath;
            IWebElement theTile = UserActions.FindElementWaitUntilPresent(By.XPath(combinedXPath));

            try
            {
                theTile.Click();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
