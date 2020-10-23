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
            var textField = FindElementWaitVisible(ElementLocator, wait_Seconds);
            return textField.Text;

        }
        public static void Click(By ElementLocator)
        {
            FindElementWaitVisibleUntilClickable(ElementLocator).Click();
        }
        public static bool assertElementContainsText(By ElementLocator, string text, bool optional = false)
        {
            if (FindElementWaitVisible(ElementLocator).Text.Contains(text))
            {
                return true;
            }

            Functions.handleFailure(new Exception($"Element {ElementLocator.ToString()} did not contain text: {text}"), optional);

            return false;
           
        }
        public static bool assertElementTextEquals(By ElementLocator, string text, bool optional = false)
        {
            if (FindElementWaitVisible(ElementLocator).Text == text)
            {
                return true;
            }

            Functions.handleFailure(new Exception($"Element {ElementLocator.ToString()} text did not equal text: {text}"), optional);
            
            return false;
            
        }

        public static bool assert(By ElementLocator, string text)
        {
            return FindElementWaitVisible(ElementLocator).Text.Contains(text);
        }

        public static IWebElement FindElementWaitVisible(By by, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
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

        //Find Element - Wait until element is present (different from vissible)
        public static IWebElement FindElementWaitPresent(By by, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
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
        public static IWebElement FindElementWaitVisibleUntilClickable(By by, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
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
            var textField = FindElementWaitVisible(TextFieldLocator, wait_Seconds);
            textField.Click();
            textField.Clear();
            textField.SendKeys(TextToEnter);

        }
        public static string getTextFieldText(By TextFieldLocator, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitVisible(TextFieldLocator, wait_Seconds);
            return textField.GetAttribute("value"); 

        }
        public static void clearTextField(By TextFieldLocator, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitVisible(TextFieldLocator, wait_Seconds);
            textField.Clear();
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
