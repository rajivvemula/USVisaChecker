﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using ApolloQA.Source.Helpers;
using System.Linq;

namespace ApolloQA.Source.Driver
{
    class UserActions
    {
        public const int DEFAULT_WAIT_SECONDS = 60;
        public static void Navigate(string URL_OR_PATH, params (string key, string value)[] parameters)
        {
            foreach (var param in parameters)
            {
                URL_OR_PATH = URL_OR_PATH.Replace("{" + param.key + "}", param.value);
            }
            string URL;
            if (URL_OR_PATH.StartsWith("http"))
            {
                URL = URL_OR_PATH;
            }
            else
            {
                URL = Environment.GetEnvironmentVariable("HOST") + (URL_OR_PATH.StartsWith('/') ? URL_OR_PATH : "/"+URL_OR_PATH);
            }
             
            Log.Info("Navigate to: " + URL);
            if (Setup.driver.Url != URL)
            {
                Setup.driver.Navigate().GoToUrl(URL);
            }
        }

        //
        // General Element Actions
        //
        public static string getElementText(By ElementLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitUntilVisible(ElementLocator, wait_Seconds);
            return textField.Text;

        }


        public static void Click(By ElementLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            FindElementWaitUntilClickable(ElementLocator, wait_Seconds).Click();
        }
        public static bool assertElementContainsText(By ElementLocator, string text, bool optional = false)
        {
            if (FindElementWaitUntilVisible(ElementLocator).Text.Contains(text))
            {
                return true;
            }

            Functions.handleFailure(new Exception($"Element {ElementLocator.ToString()} did not contain text: {text}"), optional);

            return false;
           
        }
        public static bool assertElementTextEquals(By ElementLocator, string text, bool optional = false)
        {
            if (FindElementWaitUntilVisible(ElementLocator).Text == text)
            {
                return true;
            }

            Functions.handleFailure(new Exception($"Element {ElementLocator.ToString()} text did not equal text: {text}"), optional);
            
            return false;
            
        }

        public static bool assert(By ElementLocator, string text)
        {
            return FindElementWaitUntilVisible(ElementLocator).Text.Contains(text);
        }

        public static IWebElement FindElementWaitUntilVisible(By by, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(5000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(2000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }

            highlight(target);


            return target;
        }

        public static List<IWebElement> FindElementsWaitUntilVisible(By by, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(5000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(2000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }

            highlight(target);

            return Setup.driver.FindElements(by).ToList();

        }

        //Find Element - Wait until element is present (different from vissible)
        public static IWebElement FindElementWaitUntilPresent(By by, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(5000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(2000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }

            highlight(target);


            return target;
        }

        //Find Element - Wait Until Clickable
        public static IWebElement FindElementWaitUntilClickable(By by, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(2000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(2000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }

            highlight(target);

            return target;
        }
        public static void WaitForElementToDisappear(By by, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));

        }


        //
        //  Text Fields Actions
        //
        public static void setText(By TextFieldLocator, String TextToEnter, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitUntilVisible(TextFieldLocator, wait_Seconds);
            textField.Click();
            textField.SendKeys(Keys.Control + "a");
            textField.SendKeys(Keys.Delete);
            textField.SendKeys(TextToEnter);

        }
        public static string getTextFieldText(By TextFieldLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitUntilVisible(TextFieldLocator, wait_Seconds);
            return textField.GetAttribute("value"); 

        }
        public static void clearTextField(By TextFieldLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitUntilVisible(TextFieldLocator, wait_Seconds);
            textField.Clear();
        }


        // 
        // Dropdown actions 
        // 
        public static void SelectMatDropdownOptionByText(By DropdownLocator, string optionDisplayText)
        {
            var dropdown = FindElementWaitUntilClickable(DropdownLocator);
            dropdown.Click();
            var option = FindElementWaitUntilClickable(By.XPath($"//mat-option[normalize-space(*//text())='{optionDisplayText}']"));
            option.Click();

        }


        public static void SelectMatDropdownOptionByIndex(By DropdownLocator, int LogicalIndex)
        {
            var dropdown = FindElementWaitUntilClickable(DropdownLocator);
            dropdown.Click();
            var option = FindElementsWaitUntilVisible(By.XPath($"//mat-option"));
            option[LogicalIndex].Click();

        }
        public static void SelectMatDropdownOptionByIndex(By DropdownLocator, int LogicalIndex, out string selectionDisplayName)
        {
            var dropdown = FindElementWaitUntilClickable(DropdownLocator);
            dropdown.Click();
            var option = FindElementsWaitUntilVisible(By.XPath($"//mat-option"));
            selectionDisplayName = string.Join("", option[0].FindElements(By.XPath($"(//mat-option)[{LogicalIndex + 1}]/descendant::*")).Select(it => it.Text.Trim()).Distinct());

            option[LogicalIndex].Click();

        }
        



        //
        //  Javascript
        //
        private static void highlight(IWebElement target)
        {
            JSExecutor.highlight(target);
            Thread.Sleep(250);
            try
            {
                JSExecutor.highlight(target, 0);
            }
            catch
            {
                //do nothing
            }
        }


        

    }
}
