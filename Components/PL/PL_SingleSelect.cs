using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Components.PL
{
    class PL_SingleSelect
    {
        string fieldsetXPath;
        string helpIconXPath;
        string subtextXPath;
        string errorXPath;
        string helptextXPath;
        string helptextcloseXPath;

        public PL_SingleSelect(string questionText)
        {

            //gets us the fieldset, matching on question label text
            fieldsetXPath = $"//fieldset[.//label[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{questionText.ToLower()}\"]]";

            //gets us the specific elements we're interested in manipulating (inside the fieldset)
            helpIconXPath = $"{fieldsetXPath}//i[contains(@class, 'help-icon')]";
            helptextXPath = $"{fieldsetXPath}//div[contains(@class, 'helper-text')]//div";
            subtextXPath = $"{fieldsetXPath}//span[@class='info']";
            errorXPath = $"{fieldsetXPath}//span[@class='error']";
            helptextcloseXPath = $"{fieldsetXPath}//span[contains(@class, 'close-icon')]";

        }

        IWebElement helpIcon => UserActions.FindElementWaitUntilClickable(By.XPath(helpIconXPath));
        IWebElement helpText => UserActions.FindElementWaitUntilClickable(By.XPath(helptextXPath));
        IWebElement helpTextClose => UserActions.FindElementWaitUntilClickable(By.XPath(helptextcloseXPath));
        IWebElement subtext => UserActions.FindElementWaitUntilClickable(By.XPath(subtextXPath));
        IWebElement errorText => UserActions.FindElementWaitUntilClickable(By.XPath(errorXPath));


        public void SelectOption(string optionText)
        {
            string optionXPath = $"{fieldsetXPath}//label[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{optionText.ToLower()}\"]";
            IWebElement theOption = UserActions.FindElementWaitUntilClickable(By.XPath(optionXPath), 15);
            theOption.Click();
        }

        public string GetCurrentSelection()
        {
            try
            {
                string allOptionsXPath = $"{fieldsetXPath}//input[@type='radio']";

                IList<IWebElement> allOptions = Setup.driver.FindElements(By.XPath(allOptionsXPath));

                foreach(var option in allOptions)
                {

                    if(option.GetAttribute("checked")=="true")
                    {
                        //save the input's ID
                        string inputID = option.GetAttribute("id");

                        //find the associated label
                        string labelXPath = $"//label[@for='{inputID}']";
                        IWebElement label = UserActions.FindElementWaitUntilClickable(By.XPath(labelXPath));

                        return label.Text;

                    }
                }

                return null;

            }
            catch { return null; }
        }

        public string GetErrorText()
        {
            //have to click outside the input in order to prompt error text to appear
            //just click something
            UserActions.FindElementWaitUntilVisible(By.XPath("//h1")).Click();
            return errorText.Text.Trim();
        }

        public string GetHelpText()
        {
            string result = "";

            try
            {
                helpIcon.Click();
                result = helpText.Text.Trim();
                helpTextClose.Click();
            }
            catch { }         
            
            return result;
        }

    }
}
