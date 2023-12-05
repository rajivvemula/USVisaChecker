using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using HitachiQA.Helpers;
using OpenQA.Selenium;


namespace HitachiQA.Driver
{
    public class Element : IEquatable<Element>
    {
        public By locator;     

        public Element(string xpath)
        {
            XPathExpression.Compile(xpath);
            this.locator = By.XPath(xpath);
        }
        public Element(By locator)
        {
            if (locator.Mechanism != "xpath")
            {
                throw new Exception($"{locator} is not an XPath selector");
            }
            XPathExpression.Compile(Functions.GetElementXPath(locator));
            this.locator = locator;
        }

        public bool Equals(Element other)
        {
            return this.locator.ToString() == other?.locator.ToString();
        }

        public override int GetHashCode()
        {
            return locator.ToString().GetHashCode();
        }

        //
        //  General Element Actions
        //

        public void Click()
        {

            UserActions.Click(locator);
        }

        public void Click(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS, bool optional = false)
        {

            UserActions.Click(locator, wait_Seconds, optional);
        }

        public bool TryClick(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            try
            {
                this.Click(wait_Seconds);
                return true;
            }
            catch (Exception ex)
            {
                Log.Warn($"Try click failed: {ex.Message}");
                return false;
            }
        }

        public void ClickHack()
        {
            UserActions.ClickByAction(locator);
        }

        public void ScrollIntoView()
        {
            UserActions.ScrollView(locator);
        }

        public void HoverOver(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            try
            {
                var element = UserActions.FindElementWaitUntilVisible(locator, wait_Seconds);
                UserActions.HoverOverElement(element);
            }
            catch (Exception ex)
            {
                Functions.HandleFailure($"Could not locate the following element to hover over: {locator}", ex);
            }
        }

        public string GetAttribute(string attributeName)
        {
            return UserActions.GetAttribute(locator, attributeName);
        }

        public string GetCSSValue(string valueName)
        {
            return UserActions.GetCSSValue(locator, valueName);
        }

        public void ArrowDownEnter(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            UserActions.ArrowDownEnter(locator, wait_Seconds);
        }

        public string GetElementText(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            return UserActions.GetElementText(locator, wait_Seconds);
        }

        public string GetInnerText()
        {
            return string.Join("", this.GetInnerTexts());
        }

        public List<String> GetInnerTexts()
        {
            return UserActions.FindElementsWaitUntilVisible(locator).Select(it => it.Text.Trim()).ToList();
        }

        public bool AssertElementContainsText(string expectedText, bool optional = false)
        {
            string elementText = this.GetElementText();

            if (Assert.TextContains(elementText, expectedText, true))
            {
                return true;
            }

            var exception = new Exception($"Element {locator.ToString()} text did not contain '{expectedText}'\nactual: {elementText}");
            Functions.HandleFailure(exception, optional);
            return false;
        }
        public bool AssertElementTextEquals(string expectedText, bool optional = false)
        {
            string elementText = this.GetElementText();
            if (Assert.AreEqual(elementText, expectedText, true))
            {
                return true;
            }

            var exception = new Exception($"Element {locator.ToString()} text was not '{expectedText}'\nactual: {elementText}");
            Functions.HandleFailure(exception, optional);
            return false;
        }

        public bool AssertElementInnerTextEquals(string expectedInnerText, bool optional = false)
        {
            string elementInnerText = this.GetInnerText();
            if (Assert.AreEqual(elementInnerText, expectedInnerText, true))
            {
                return true;
            }

            var exception = new Exception($"Element {locator.ToString()} inner text was not '{expectedInnerText}'\nactual: {elementInnerText}");
            Functions.HandleFailure(exception, optional);
            return false;
        }



        /// <summary>
        ///  Waits for the element to be visible in the page
        /// </summary>
        /// <param name="optional">if set to true failure will be contained and no exception will be thrown </param>
        public bool AssertElementIsVisible(int wait_Seconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS, bool optional = false)
        {
            try
            {
                UserActions.FindElementWaitUntilVisible(locator, wait_Seconds);
                return true;
            }
            catch (Exception ex)
            {
                Functions.HandleFailure($"Element located {locator} was not visible in the UI", ex, optional);
            }
            return false;
        }

        /// <summary>
        ///  Waits for the element to be present in the page (an elements could be present and not visible)
        /// </summary>
        /// <param name="optional">if set to true failure will be contained and no exception will be thrown </param>
        public bool AssertElementIsPresent(int wait_Seconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS, bool optional = false)
        {
            try
            {
                UserActions.FindElementWaitUntilPresent(locator, wait_Seconds);
                return true;
            }
            catch (Exception ex)
            {
                Functions.HandleFailure($"Element located {locator} was not present in DOM", ex, optional);
            }
            return false;
        }



        /// <summary>
        ///  Waits for the element to disappear <br/>
        ///  note: if element was not present at the exact moment this function was called, true will be returned.
        /// </summary>
        /// <param name="optional">if set to true failure will be contained and no exception will be thrown </param>
        public bool AssertElementNotPresent(int wait_Seconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS, bool optional = false)
        {
            try
            {
                UserActions.WaitForElementToDisappear(locator, wait_Seconds);
                return true;
            }
            catch (Exception ex)
            {
                Functions.HandleFailure($"Element located {locator} was still visible in the UI when it should not be", ex, optional);
            }
            return false;
        }

        public void WaitForElementToAppearThenDisappear(int waitSeconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS)
        {
            UserActions.WaitForElementToDisappear2(locator, waitSeconds);
        }

        public void SetValue(string fieldType, string value)
        {
            switch (fieldType.ToLower())
            {
                case "input":
                    this.SetText(value);
                    break;
                case "dropdown":
                    this.SelectMatDropdownOptionByText(value);
                    break;
                default:
                    Functions.HandleFailure(new NotImplementedException($"Field type: {fieldType} is not implemented"));
                    break;

            }
        }

        //
        //  Text Fields Actions
        //
        public void SetTextSlow(string textToEnter, int waitSeconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            UserActions.SetTextSlow(locator, textToEnter, waitSeconds);
        }

        public void SetText(string textToEnter, int waitSeconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            UserActions.SetText(locator, textToEnter, waitSeconds);
        }

        public void SetTextAndUnfocus(string textToEnter, int waitSeconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            UserActions.SetText(locator, textToEnter + Keys.Tab, waitSeconds);

        }

        public string GetTextFieldValue(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            return UserActions.GetTextFieldValue(locator, wait_Seconds);

        }
        public void ClearTextField(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            UserActions.GetTextFieldAndClear(locator);
        }
        public bool AssertTextFieldValueEquals(string expectedValue, bool optional = false)
        {
            string textFieldValue = this.GetTextFieldValue();
            if (Assert.AreEqual(textFieldValue, expectedValue, true))
            {
                return true;
            }

            var exception = new Exception($"Text Field {locator.ToString()} expected '{expectedValue}' but was '{textFieldValue}'");
            Functions.HandleFailure(exception, optional);
            return false;
        }

        //
        // Reg Dropdown actions
        //
        public void SelectDropdownOptionByText(string optionDisplayText)
        {
            UserActions.SelectDropdownOptionByText(locator, optionDisplayText);
        }

        public bool AssertSelectDropdownOptionsEqual(List<string> optionsText, bool optional = false)
        {
            List<string> dropdownOptions = UserActions.GetAllSelectDropdownOptions(locator).ToList();

            return Assert.AreEqual(dropdownOptions, optionsText, optional);
        }

        public string GetSelectDropdownSelection()
        {
            return UserActions.GetDropdownSelection(locator);
        }

        // 
        // Mat Dropdown actions 
        // 
        public void SelectMatDropdownOptionByText(string optionDisplayText)
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
        public bool AssertMatDropdownOptionsContain(string optionText, bool optional = false)
        {
            List<string> dropdownOptions = UserActions.GetAllMatDropdownOptions(locator).ToList();

            return Assert.Contains(dropdownOptions, optionText, optional);
        }
        public bool AssertMatDropdownOptionsEqual(List<String> optionsText, bool optional = false)
        {
            List<String> dropdownOptions = UserActions.GetAllMatDropdownOptions(locator).ToList();

            return Assert.AreEqual(dropdownOptions, optionsText, optional);
        }

        public bool AssertMatDropdownCurrentlySelected(string expectedOptionText)
        {
            var currentSelection = GetInnerText();
            return Assert.AreEqual(currentSelection, expectedOptionText);
        }

        public int GetCountOfMatDropdownOptions()
        {
            List<String> dropdownOptions = UserActions.GetAllMatDropdownOptions(locator).ToList();
            return dropdownOptions.Count;
        }
        //Checkbox Validations
        public bool IsSelected(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            return UserActions.IsSelected(locator, wait_Seconds);
        }
        public bool IsDisplayed(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            return UserActions.IsDisplayed(locator, wait_Seconds);
        }
        public bool IsEnabled(int wait_Seconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            return UserActions.IsEnabled(locator, wait_Seconds);
        }

        public void ClickIfSelected(int waitSeconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            if (IsSelected(waitSeconds))
            {
                Click(waitSeconds);
            }
        }

        public void ClickIfNotSelected(int waitSeconds = UserActions.DEFAULT_WAIT_SECONDS)
        {
            if (!IsSelected(waitSeconds))
            {
                Click(waitSeconds);
            }
        }
        
        // angular buttons
        public bool IsSelectedAngular()
        {
            try
            {
                var clicked = UserActions.GetAttribute(locator, "aria-selected");

                return clicked == "true";
            }
            catch
            {
                // fail-safe if element doesn't exist
                return false;
            }
        }

        public bool AssertIsSelectedAngular()
        {
            try
            {
                return Assert.IsTrue(IsSelectedAngular());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int GetCountOfElements()
        {
            return UserActions.GetCountOfElements(locator);
        }

        public bool IsElementVisibleInViewport()
        {
            return UserActions.IsElementVisibleInViewport(locator);
        }

        public bool AssertIsElementVisibleInViewport()
        {
            try
            {
                return Assert.IsTrue(IsElementVisibleInViewport());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}