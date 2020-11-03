using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using ApolloQA.Source.Helpers;
using System.Linq;

namespace ApolloQA.Source.Driver
{
    public class Element
    {
        public By locator;

        public Element(string xpath)
        {
            this.locator = By.XPath(xpath);
        }
        public Element(By locator)
        {
            this.locator = locator;
        }


        //
        //  General Element Actions
        //
 
        public void Click()
        {
           
            UserActions.Click(locator);
        }
        public void Click(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {

            UserActions.Click(locator, wait_Seconds);
        }

        public bool TryClick(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            try
            {
                this.Click(wait_Seconds);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public string GetElementText()
        {
            return UserActions.getElementText(locator);
        }

        public string getElementsText()
        {
            var elements = UserActions.FindElementsWaitUntilVisible(locator);
            return string.Join("",elements.Select(it => it.Text).Distinct());
        }
        public List<String> getElementsTexts()
        {
            return UserActions.FindElementsWaitUntilVisible(locator).Select(it => it.Text).ToList();
            
        }




        /// <summary>
        ///  Waits for the element to be vissible in the page
        /// </summary>
        /// <param name="optional">if set to true failure will be contained and no exception will be thrown </param>
        public bool assertElementIsVisible(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS, bool optional = false)
        {
            try { UserActions.FindElementWaitUntilVisible(locator, wait_Seconds);
                return true;
            }
            catch (Exception ex)
            {
                Functions.handleFailure($"Element located {locator.ToString()} was not vissible in the UI", ex, optional);
            }
            return false;
        }

        /// <summary>
        ///  Waits for the element to be present in the page (an elements could be present and not visible)
        /// </summary>
        /// <param name="optional">if set to true failure will be contained and no exception will be thrown </param>
        public bool assertElementIsPresent(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS, bool optional = false)
        {
            try { UserActions.FindElementWaitUntilPresent(locator, wait_Seconds);
                return true;
            }
            catch (Exception ex)
            {
                Functions.handleFailure($"Element located {locator.ToString()} was not vissible in the UI", ex, optional);
            }
            return false;
        }


        public bool assertElementContainsText(string text, bool optional = false)
        {
           return UserActions.assertElementContainsText(locator, text, optional);
        }
        public bool assertElementTextEquals(string text, bool optional = false)
        {
            return UserActions.assertElementTextEquals(locator, text, optional);
        }

        /// <summary>
        ///  Waits for the element to disappear <br/>
        ///  note: if element was not present at the exact moment this function was called, true will be returned.
        /// </summary>
        /// <param name="optional">if set to true failure will be contained and no exception will be thrown </param>
        public bool assertElementNotPresent(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS, bool optional = false)
        {
            try { UserActions.WaitForElementToDisappear(locator, wait_Seconds);
                return true;
            }
            catch (Exception ex)
            {
                Functions.handleFailure($"Element located {locator.ToString()} was still vissible in the UI after {wait_Seconds} seconds", ex, optional);
            }
            return false;
        }



        //
        //  Text Fields Actions
        //
        public void setText(String TextToEnter, int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
        
            UserActions.setText(locator, TextToEnter, wait_Seconds);
        }
        public string getTextFieldText(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
           return  UserActions.getTextFieldText(locator, wait_Seconds);

        }
        public void clearTextField(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            UserActions.clearTextField(locator);
        }



        // 
        // Dropdown actions 
        // 
        public void SelectMatDropdownOptionByText( string optionDisplayText)
        {
            UserActions.SelectMatDropdownOptionByText(locator, optionDisplayText);
        }
        public void SelectMatDropdownOptionByIndex(int LogicalIndex, out string selectionDisplayName)
        {
            UserActions.SelectMatDropdownOptionByIndex(locator, LogicalIndex, out selectionDisplayName);
          
        }
        public void SelectMatDropdownOptionByIndex(int LogicalIndex)
        {
            UserActions.SelectMatDropdownOptionByIndex(locator, LogicalIndex);

        }



    }
}