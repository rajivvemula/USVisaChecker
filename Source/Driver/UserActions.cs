using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HitachiQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Polly;

namespace HitachiQA.Driver
{
    class UserActions
    {
        // Max time to wait for web load times (page advancement, saving changes, etc)
        public const int DEFAULT_PAGE_WAIT_SECONDS = 2;
        // Max time to wait for changes within page (javascript interactions, pop up appears, click succeeds, etc)
        public const int DEFAULT_WAIT_SECONDS = 6;
        // Max time to wait for the browser to transition from server-side render to app fully loaded
        public const int DEFAULT_PP_APP_BROWSER_LOAD_WAIT_SECONDS = 15;

        public static bool HIGHLIGHTS_ON = Boolean.Parse(Environment.GetEnvironmentVariable("HIGHLIGHTS_ON", EnvironmentVariableTarget.Process));


        public static void GoHome()
        {
            Navigate("/");
        }

        public static void Navigate(string URL_OR_PATH, params (string key, string value)[] parameters)
        {
            var URL = Functions.ParseURL(URL_OR_PATH, parameters);
            Log.Info("Navigate to: " + URL);
            if (Setup.driver.Url != URL)
            {
                Setup.driver.Navigate().GoToUrl(URL);
            }
        }
        public static void Navigate(string URL_OR_PATH)
        {
            var URL = Functions.ParseURL(URL_OR_PATH);
            Log.Info("Navigate to: " + URL);
            if (Setup.driver.Url != URL)
            {
                Setup.driver.Navigate().GoToUrl(URL);
            }
        }
        public static string GetCurrentURL()
        {
            return Setup.driver.Url;
        }

        //
        // General Element Actions
        //
        public static string GetElementText(By ElementLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitUntilVisible(ElementLocator, wait_Seconds);
            return textField.Text.Trim();

        }

        public static void Click(By elementLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS, bool optional = false)
        {
            try
            {
                RetryAfterAction(elementLocator, () =>
                {
                    var target = FindElementWaitUntilClickable(elementLocator, wait_Seconds);
                    ScrollView(elementLocator);
                    target.Click();
                });
            }
            catch (Exception ex)
            {
                Functions.HandleFailure($"Failed to click element {elementLocator}", ex, optional);
            }
        }

        //Using class Action to perform the element click when the regular method Click() isn't effective (Checkbox on Autopay Enrollment page)
        //TODO: evaluate multiple click methods
        public static void ClickByAction(By elementLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS, bool optional = false)
        {
            try
            {
                RetryAfterAction(elementLocator, () =>
                {
                    new Actions(Setup.driver)
                        .Click(Setup.driver.FindElement(elementLocator))
                        .Perform();
                });
            }
            catch (Exception ex)
            {
                Functions.HandleFailure($"Failed to click element {elementLocator}", ex, optional);
            }
        }

        public static string GetAttribute(By ElementLocator, string attributeName)
        {
            return FindElementWaitUntilPresent(ElementLocator, 1).GetAttribute(attributeName);
        }

        public static string GetCSSValue(By ElementLocator, string valueName)
        {
            return FindElementWaitUntilClickable(ElementLocator).GetCssValue(valueName);
        }

        public static IWebElement FindElementWaitUntilVisible(By by, int wait_Seconds = DEFAULT_PAGE_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (StaleElementReferenceException)
            {
                Log.Warn("Element wait-until-visible reference was stale, retrying criteria: " + by.Criteria);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (ElementClickInterceptedException)
            {
                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            Highlight(target);
            return target;
        }

        // this was created to scroll to an element that is hidden in the css until that section of the page is exposed
        // (the css setting would be "Display None" on the element until the user is on that section of the page and then it appears)
        // due to its implementation, it also acts as an on hover for an element (so it activates any behavior expected on mouse over)
        public static IWebElement FindElementWaitUntilVisibleForSmokeTest(By by, int wait_Seconds = DEFAULT_PAGE_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                HoverOverElement(target);
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (StaleElementReferenceException)
            {
                Log.Warn("Element wait-until-visible-for-smoketest reference was stale, retrying criteria: " + by.Criteria);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (ElementClickInterceptedException)
            {
                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            Highlight(target);
            return target;
        }

        public static IList<IWebElement> FindElementsWaitUntilVisible(By by, int wait_Seconds = DEFAULT_PAGE_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (StaleElementReferenceException)
            {
                Log.Warn("Elements wait-until-visible reference was stale, retrying criteria: " + by.Criteria);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (ElementClickInterceptedException)
            {
                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }

            return Setup.driver.FindElements(by).ToList();
        }

        //Find Element - Wait until element is present (different from visible)
        public static IWebElement FindElementWaitUntilPresent(By by, int wait_Seconds = DEFAULT_PAGE_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (StaleElementReferenceException)
            {
                Log.Warn("Element wait-until-present reference was stale, retrying criteria: " + by.Criteria);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (ElementClickInterceptedException)
            {
                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }

            Highlight(target);


            return target;
        }

        //Find Element - Wait Until Clickable
        public static IWebElement FindElementWaitUntilClickable(By by, int wait_Seconds = DEFAULT_PAGE_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (StaleElementReferenceException)
            {
                Log.Warn("Element wait-until-clickable reference was stale, retrying criteria: " + by.Criteria);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (ElementClickInterceptedException)
            {
                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (ElementNotInteractableException)
            {
                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }


            Highlight(target);

            return target;
        }

        public static void WaitForElementToDisappear(By by, int wait_Seconds = DEFAULT_PAGE_WAIT_SECONDS)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public static void WaitForElementToDisappear2(By by, int wait_Seconds = DEFAULT_PAGE_WAIT_SECONDS)
        {
            WebDriverWait waitAppear = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(3));
            WebDriverWait waitDisappear = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(wait_Seconds));

            //wait until visible, need try in case spinner doesn't appear
            try
            {
                waitAppear.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch { return; }

            //at this point, spinner appeared, wait until invisible
            waitDisappear.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }


        //
        //  Text Fields Actions
        //
        public static void ArrowDownEnter(By TextFieldLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitUntilVisible(TextFieldLocator, wait_Seconds);
            // textField.SendKeys(Keys.ArrowDown); //commented this out because some keywords with a colon don't appear at the top and the arrow down messes it up
            textField.SendKeys(Keys.Enter);
        }


        public static void SetText(By textFieldLocator, string textToEnter, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            var textField = GetTextFieldAndClear(textFieldLocator, wait_Seconds);
            textField.SendKeys(textToEnter);
        }

        public static void SetTextSlow(By textFieldLocator, string textToEnter, int wait_Seconds = DEFAULT_WAIT_SECONDS )
        {
            var textField = GetTextFieldAndClear(textFieldLocator, wait_Seconds);

            //iterating through the text character by character
            foreach (var character in textToEnter)
            {
                textField.SendKeys(character.ToString());
                Thread.Sleep(100); //a short pause needed for code to be stable, for decimal point to be entered
            }
        }

        public static string GetTextFieldValue(By textFieldLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            var textField = FindElementWaitUntilVisible(textFieldLocator, wait_Seconds);
            return textField.GetAttribute("value");
        }

        public static IWebElement GetTextFieldAndClear(By TextFieldLocator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            IWebElement textField = FindElementWaitUntilVisible(TextFieldLocator, wait_Seconds);
            textField.SendKeys(Keys.Control + "a");
            textField.SendKeys(Keys.Delete);

            return textField;
        }

        //
        // Reg Dropdown Actions
        //
        public static void SelectDropdownOptionByText(By dropDownLocator, string optionDisplayText)
        {
            var dropDownSelect = new SelectElement(FindElementWaitUntilClickable(dropDownLocator));
            var optionXpath = By.XPath($"{Functions.GetElementXPath(dropDownLocator)}//option[contains(normalize-space(.), \"{optionDisplayText}\")]");

            try
            {
                FindElementWaitUntilClickable(optionXpath);
                dropDownSelect.SelectByText(optionDisplayText);
            }
            catch
            {
                FindElementWaitUntilClickable(optionXpath);
                dropDownSelect.SelectByText(optionDisplayText);
            }
        }

        public static string GetDropdownSelection(By dropDownLocator)
        {
            var dropDownSelect = new SelectElement(FindElementWaitUntilClickable(dropDownLocator));
            return dropDownSelect.SelectedOption.Text;
        }

        // 
        // Mat Dropdown actions 
        // 
        public static void SelectMatDropdownOptionByText(By DropdownLocator, string optionDisplayText)
        {
            var dropdown = FindElementWaitUntilClickable(DropdownLocator, 1);
            dropdown.Click();
            var option = FindElementWaitUntilClickable(By.XPath($"//mat-option[normalize-space(*//text())=\"{optionDisplayText}\"]"), 1);
            try
            {
                UserActions.HoverOverElement(option);
                option.Click();
            }
            catch (StaleElementReferenceException)
            {
                option = FindElementWaitUntilClickable(By.XPath($"//mat-option[normalize-space(*//text())=\"{optionDisplayText}\"]"), 1);
                UserActions.HoverOverElement(option);
                option.Click();
            }
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
            var options = FindElementsWaitUntilVisible(By.XPath($"//mat-option"));
            selectionDisplayName = string.Join("", options[0].FindElements(By.XPath($"(//mat-option)[{LogicalIndex + 1}]/descendant::*")).Select(it => it.Text.Trim()).Distinct());

            options[LogicalIndex].Click();

        }

        public static List<string> GetAllSelectDropdownOptions(By DropdownLocator)
        {
            var dropdown = FindElementWaitUntilClickable(DropdownLocator);
            var dropdownXpath = Functions.GetElementXPath(DropdownLocator);
            var dropdownOptions = new List<string>();
            var options = FindElementsWaitUntilVisible(By.XPath($"{dropdownXpath}//option"));

            dropdown.Click();

            foreach (var option in options)
            {
                dropdownOptions.Add(option.Text);
            }

            return dropdownOptions;
        }

        public static IEnumerable<String> GetAllMatDropdownOptions(By DropdownLocator)
        {
            var dropdown = FindElementWaitUntilClickable(DropdownLocator);
            dropdown.Click();
            var options = FindElementsWaitUntilVisible(By.XPath($"//mat-option"));

            int currentOption = 1;
            foreach (var option in options)
            {
                List<string> innerText = option.FindElements(By.XPath($"(//mat-option)[{currentOption}]/descendant::*")).Select(it => it.Text.Trim()).Distinct().ToList();
                currentOption++;
                yield return string.Join("", innerText);
            }
        }

        //
        //  Javascript
        //
        private static void Highlight(IWebElement target)
        {
            if (!HIGHLIGHTS_ON)
            {
                return;
            }

            //grabs the executing test's thread local driver
            var driver = Setup.driver;
            Task.Run(() =>
            {
                var jsExecutor = new JSExecutor(driver);
                jsExecutor.Highlight(target);
                Thread.Sleep(100);
                jsExecutor.Highlight(target, 0);
            });
        }

        public static void SwitchToFrame(string Frame)
        {
            var frame = FindElementWaitUntilVisible(By.XPath("//iframe[@id ='sff_127__form__iframe']"), 60);
            Setup.driver.SwitchTo().Frame(frame);
        }

        public static void SwitchToDefaultContent()
        {
            Setup.driver.SwitchTo().DefaultContent();
        }

        public static IAlert GetBrowserAlert()
        {
            return Setup.driver.SwitchTo().Alert();
        }

        public static void ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Setup.driver;
            js.ExecuteScript("window.scrollTo(0, 550)");
        }

        public static void ScrollWithCount(int number)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Setup.driver;
            string result = (number * 500).ToString();
            string fullString = "window.scrollTo(0, " + result + ")";
            js.ExecuteScript(fullString);

        }

        public static void HoverOverElement(IWebElement element)
        {
            Actions actions = new Actions(Setup.driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void ScrollDownHomePage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Setup.driver;
            js.ExecuteScript("window.scrollTo(0, 1200)");
        }

        public static void ScrollUp()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Setup.driver;
            js.ExecuteScript("window.scrollTo(1200, 0)");
        }

        public static void DatePicker()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Setup.driver;
            js.ExecuteScript("document.querySelector(#datepicker1).value = '10/20/1980'");
        }

        public static void GetPressKeywordEnter()
        {
            Actions action = new Actions(Setup.driver);
            action.SendKeys(Keys.Enter).Build().Perform();
        }

        public static void GetPressKeywordSpace()
        {
            //Actions action = new Actions(Setup.driver);
            //action.SendKeys(Keys.Space).Build().Perform();
            IWebElement textbox = Setup.driver.FindElement(By.XPath("//input[contains(@placeholder,'Type here')]"));
            textbox.SendKeys(Keys.Space);
        }

        public static void ScrollView(By locator)
        {
            RetryAfterAction(locator, () =>
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Setup.driver;
                js.ExecuteScript("arguments[0].scrollIntoView(false);",
                    FindElementWaitUntilPresent(locator, 1));
            }
            );
        }

        private static void RetryAfterAction(By locator, Action action)
        {
            try
            {
                action();
            }
            catch (StaleElementReferenceException)
            {
                Log.Warn($"Got stale element exception acting on element using xpath {locator.Criteria}, trying again..");
                action();
            }
            catch (ElementClickInterceptedException)
            {
                Log.Warn($"The Element that would have received the click using locater {locator.Criteria}, was intercepted by another element, trying again..");
                action();
            }
        }

        // Checkbox Validations
        public static bool IsSelected(By locator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            return FindElementWaitUntilPresent(locator, wait_Seconds).Selected;
        }
        public static bool IsDisplayed(By locator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            return FindElementWaitUntilPresent(locator, wait_Seconds).Displayed;
        }
        public static bool IsEnabled(By locator, int wait_Seconds = DEFAULT_WAIT_SECONDS)
        {
            return FindElementWaitUntilPresent(locator, wait_Seconds).Enabled;
        }

        public static string GetBackgroundColorOfElement(By locator)
        {
            var xpath = Functions.GetElementXPath(locator);
            var js = new JSExecutor(Setup.driver);
            var script = $"return getComputedStyle(document.evaluate(\"{xpath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue).backgroundColor";
            var result = js.Execute(script);
            return (string)result;
        }

        public static string GetValueFromSessionStorage(string key)
        {
            var js = new JSExecutor(Setup.driver);
            return js.GetValueFromSessionStorage(key);
        }

        public static TResult WaitUntil<TResult>(Func<TResult> condition, int maxSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(maxSeconds));
            return wait.Until(_ => condition());
        }

        public static void WaitUntil(Action action, int maxSeconds)
        {
            WaitUntil(() =>
            {
                action();
                return true;
            }, maxSeconds);
        }

        public static ReadOnlyCollection<string> GetTabs()
        {
            return Setup.driver.WindowHandles;
        }

        public static void SwitchToTab(string tabHandle)
        {
            Setup.driver.SwitchTo().Window(tabHandle);
        }

        public static bool IsElementVisibleInViewport(By locator)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Setup.driver;
            IWebElement ele = Setup.driver.FindElement(locator);
            FindElementWaitUntilVisible(locator);
            Thread.Sleep(1000);

            var script = @"
                var rect = arguments[0].getBoundingClientRect();
                return (
                    rect.top >= 0 &&
                    rect.left >= 0 &&
                    rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
                    rect.right <= (window.innerWidth || document.documentElement.clientWidth)
                );";

            bool isElementVisible = (bool)js.ExecuteScript(script, ele);

            return isElementVisible;
        }

        public static int GetCountOfElements(By locator)
        {
            return Setup.driver.FindElements(locator).Count();
        }

        public static void BumpScreenDownABit()
        {
            var jsExecutor = new JSExecutor(Setup.driver);
            jsExecutor.Execute("window.scrollBy(0, 120)");
        }

        // Check for the bottom of the page
        public static bool HasReachedPageEnd()
        {
            var jsExecutor = new JSExecutor(Setup.driver);
            return (bool)jsExecutor.Execute("return (window.innerHeight + window.scrollY) >= document.body.scrollHeight;");
        }

        public static void WaitForNetworkIdle(int timeoutSeconds = 120, int idleTimeMilis = 2000)
        {
            Policy.HandleResult(result: false).WaitAndRetry(timeoutSeconds * 5, (int _) => TimeSpan.FromMilliseconds(200.0)).Execute(delegate
            {
                bool flag = (bool)((IJavaScriptExecutor)Setup.driver).ExecuteScript("return document.readyState == 'complete'");
                bool flag2 = (bool)((IJavaScriptExecutor)Setup.driver).ExecuteScript("return performance.getEntriesByType('resource').map(x => x.startTime + x.duration).every(x => x < performance.now() - arguments[0])", idleTimeMilis);
                return flag && flag2;
            });
        }
    }
}