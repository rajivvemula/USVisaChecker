using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Source.Driver
{
    class UserActions
    {

        //
        // General Element Actions
        //
        public static string getElementText(By ElementLocator, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWait(ElementLocator, wait_Seconds);
            return textField.Text;

        }
        public static void Click(By ElementLocator)
        {
            FindElementWaitUntilClickable(ElementLocator).Click();
        }
        public static bool assertElementContainsText(By ElementLocator, string text)
        {
            return FindElementWait(ElementLocator).Text.Contains(text);
        }

        public static IWebElement FindElementWait(By by, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
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
            catch (Exception ex)
            {

                handleFailure($"Element not found, located By {by.ToString()}, fail scenario");
                throw ex;
            }

            highlight(target);


            return target;
        }
        //Find Element - Wait Until Clickable
        public static IWebElement FindElementWaitUntilClickable(By by, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
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
        public static void WaitForElementToDisappear(By by, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));

        }


        //
        //  Text Fields Actions
        //
        public static void setText(By TextFieldLocator, String TextToEnter, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWait(TextFieldLocator, wait_Seconds);
            textField.Click();
            textField.Clear();
            textField.SendKeys(TextToEnter);

        }
        public static string getTextFieldText(By TextFieldLocator, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWait(TextFieldLocator, wait_Seconds);
            return textField.GetAttribute("value"); 

        }
        public static void clearTextField(By TextFieldLocator, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWait(TextFieldLocator, wait_Seconds);
            textField.Clear();
        }


       
        //
        //  Javascript
        //
        private static void highlight(IWebElement target)
        {
            JavaScriptExecutor.highlight(target);
            Thread.Sleep(250);
            try
            {
                JavaScriptExecutor.highlight(target, 0);
            }
            catch
            {
                //do nothing
            }
        }


        //
        //  Log Handling
        //
        public static void handleFailure(string message, Exception ex = null, bool optional=false)
        {
            Log.Error(message);

            if(ex != null)
            {
                if (optional)
                {
                    Log.Error(ex.Message);
                }
                else
                {
                    throw ex;
                }

            }
        }
        
    }
}
