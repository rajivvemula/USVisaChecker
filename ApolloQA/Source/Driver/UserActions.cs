﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using ApolloQA.Source.Helpers;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Utf8Json.Formatters;
using OpenQA.Selenium.Interactions;

namespace ApolloQA.Source.Driver
{
    class UserActions
    {
        public const int DEFAULT_WAIT_SECONDS = 30;
        private static bool HIGHLIGHT_ON = Boolean.Parse(Environment.GetEnvironmentVariable("HIGHLIGHT_ON") ?? "false");

        //Most applications have some sort of loading screen, please allow this variable to hold the that locator. please set this xpath in your .env.json file
        private static readonly String LOADING_SCREEN_XPATH = Environment.GetEnvironmentVariable("LOADING_SCREEN_XPATH");
        public static void waitForPageLoad()
        {
            if(LOADING_SCREEN_XPATH != null)
            {
                By locator = By.XPath(LOADING_SCREEN_XPATH);
                //this is optional
                try
                {
                    FindElementWaitUntilVisible(locator, 1);
                    WaitForElementToDisappear(locator, 120);
                }
                catch(Exception)
                {
                    //do nothing
                }
            }
        }
  

        public static void Navigate(string URL_OR_PATH, params (string key, string value)[] parameters)
        {
            var URL = Functions.ParseURL(URL_OR_PATH, parameters);
            Log.Info("Navigate to: " + URL);

            Navigate(URL);
            
        }
        
        public static void Navigate(string URL_OR_PATH)
        {
            var URL = Functions.ParseURL(URL_OR_PATH);
            Log.Info("Navigate to: " + URL);
           
            Setup.driver.Navigate().GoToUrl(URL);
            
        }

        public static string GetCurrentURL()
        {
            return Setup.driver.Url;
        }

        public static void Refresh()
        {
            Setup.driver.Navigate().Refresh();
        }

        public static void Back()
        {
            Setup.driver.Navigate().Back();
        }

        //
        // General Element Actions
        //

        public static string getElementText(By ElementLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitUntilVisible(ElementLocator, wait_Seconds);
            return textField.Text.Trim();
        }

        public static void Click(By ElementLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS, bool optional = false)
        {
            try
            {
                FindElementWaitUntilClickable(ElementLocator, wait_Seconds).Click();
            }
            catch(StaleElementReferenceException)
            {
                Thread.Sleep(1000);
                FindElementWaitUntilClickable(ElementLocator, wait_Seconds).Click();

            }
            catch(ElementClickInterceptedException)
            {
                waitForPageLoad();
                FindElementWaitUntilClickable(ElementLocator, wait_Seconds).Click();
            }
            catch (Exception ex)
            {
                Functions.handleFailure($"Locator: {ElementLocator}",ex, optional);
            }
        }

        public static string GetAttribute(By ElementLocator, string attributeName)
        {
          return FindElementWaitUntilClickable(ElementLocator).GetAttribute(attributeName);
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

            ScrollIntoView(target);
            if(HIGHLIGHT_ON)
                highlight(target);

            target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
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

            ScrollIntoView(target);
            if (HIGHLIGHT_ON)
                highlight(target);
            target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return target;
        }

        //Find Element - Wait Until Clickable
        public static IWebElement FindElementWaitUntilClickable(By by, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;



            target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            ScrollIntoView(target);

            if (HIGHLIGHT_ON)
                highlight(target);

            //upon scroll and highlight to the element, the element would become stale for clicking
            target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));

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
            var textField = FindElementWaitUntilClickable(TextFieldLocator, wait_Seconds);
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
            textField.SendKeys(Keys.Control + "a");
            textField.SendKeys(Keys.Delete);
        }

        // 
        // Dropdown actions 
        // 

        public static void SelectMatDropdownOptionByText(By DropdownLocator, string optionDisplayText)
        {
            Click(DropdownLocator);
            Click(By.XPath($"//mat-option[descendant::*[normalize-space(text())= '{optionDisplayText}']]"));
        }
        public static void SelectMatDropdownOptionContainingText(By DropdownLocator, string optionDisplayText)
        {
            Click(DropdownLocator);
            Click(By.XPath($"//mat-option[descendant::*[contains(normalize-space(text()), '{optionDisplayText}')]]"));
        }

        public static void SelectMatDropdownOptionByIndex(By DropdownLocator, int LogicalIndex)
        {
            Click(DropdownLocator);
            Click(By.XPath($"//mat-option[{LogicalIndex + 1}]"));
        }

        public static void SelectMatDropdownOptionByIndex(By DropdownLocator, int LogicalIndex, out string selectionDisplayName)
        {
            Click(DropdownLocator);
            try
            {
                WaitForElementToDisappear(By.XPath("//mat-option[descendant::*[normalize-space(text())= 'Searching...']]"));
            }catch(Exception)
            {

            }
            var options = FindElementsWaitUntilVisible(By.XPath($"//mat-option"));
            selectionDisplayName = string.Join("", Setup.driver.FindElements(By.XPath($"(//mat-option)[{LogicalIndex + 1}]/descendant::*")).Select(it => it.Text.Trim()).Distinct());
            Click(By.XPath($"//mat-option[{LogicalIndex + 1}]"));

        }

        public static IEnumerable<String> GetAllMatDropdownOptions(By DropdownLocator)
        {
            var dropdown = FindElementWaitUntilClickable(DropdownLocator);
            dropdown.Click();
            var options = FindElementsWaitUntilVisible(By.XPath($"//mat-option"));


            int currentOption = 1;
            foreach(var option in options)
            {
                List<string> innerText = option.FindElements(By.XPath($"(//mat-option)[{currentOption}]/descendant::*")).Select(it => it.Text.Trim()).Distinct().ToList();
                currentOption++;
                yield return string.Join("", innerText);
            }
        }

        // Scroll

        public static void ScrollIntoView(IWebElement element)
        {
            JSExecutor.execute($"arguments[0].scrollIntoView();", element);
        }

        //
        //  Javascript
        //

        private static void highlight(IWebElement target)
        {
            JSExecutor.highlight(target);
            Thread.Sleep(200);
            try
            {
                JSExecutor.highlight(target, 0);
            }
            catch
            {
                //do nothing
            }
        }

        //spinner
        public static void WaitForSpinnerToDisappear()
        {
            WebDriverWait waitAppear = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(5));
            WebDriverWait waitDisappear = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(DEFAULT_WAIT_SECONDS));

            By spinnerBy = By.XPath("//bh-mat-spinner-overlay");

            //wait until visible, need try in case spinner doesn't appear
            try
            {
                waitAppear.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(spinnerBy));
            }
            catch { return; }

            //at this point, spinner appeared, wait until invisible
            waitDisappear.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(spinnerBy));

        }


        public static IEnumerable<Dictionary<String, String>> parseUITable(string datatableXpath)
        {
            FindElementWaitUntilPresent(By.XPath(datatableXpath));
            List<String> columnNames = Setup.driver.FindElements(By.XPath(datatableXpath + "//datatable-header-cell//span[contains(@class,'datatable-header-cell-label')]")).Select(element => element.Text).ToList<String>();

            int rowCount = Driver.Setup.driver.FindElements(By.XPath(datatableXpath + "//datatable-body-row")).Count;
            for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
            {

                var rowDict = new Dictionary<String, String>();

                for (int i = 0; i < columnNames.Count(); i++)
                {
                    // String cellText = string.Join("", cells[i].FindElements(By.XPath("/descendant::*"))
                    String cellText = string.Join("", Driver.Setup.driver
                                                      .FindElements(By.XPath($"(({datatableXpath} //datatable-body-row)[{rowIndex}] //datatable-body-cell)[{i + 1}]/descendant::*"))
                                                      .Select(child => child.Text).Distinct());

                    rowDict.Add(columnNames[i], cellText.Trim());
                }
                yield return rowDict;
            }
        }
    }
}