using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Bogus;
using Bogus.DataSets;
using OpenQA.Selenium.Chrome;

namespace ApolloQA.Helpers
{
    class Functions
    {

        private IWebDriver driver;

        public Functions(IWebDriver driver)
        {
            this.driver = driver;
        }


        //Find Element - Wait Until Visible
        public IWebElement FindElementWait(int seconds, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch(StaleElementReferenceException stale)
            {
                Thread.Sleep(5000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch(ElementClickInterceptedException clickintercepted)
            {
                Thread.Sleep(5000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }

            //highlight
            if(Defaults.highlightingOn)
            {
                JavaScriptExecutor.highlight(driver, target);
                Thread.Sleep(250);

                try
                {
                    JavaScriptExecutor.highlight(driver, target, 0);
                }
                catch
                {
                    //do nothing
                }
            }
            

            return target;
        }


        //Find Element - Wait Until Clickable
        public IWebElement FindElementWaitUntilClickable(int seconds, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (StaleElementReferenceException stale)
            {
                Thread.Sleep(2000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (ElementClickInterceptedException clickintercepted)
            {
                Thread.Sleep(5000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }

            JavaScriptExecutor.highlight(driver, target);
            Thread.Sleep(250);
            try
            {
                JavaScriptExecutor.highlight(driver, target, 0);
            }
            catch
            {
                //do nothing
            }

            return target;
        }


        public static Dictionary<string, string> TableToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public string GenerateValidVIN()
        {
            /* Bogus library does not generate Valid VINs, need to seek another approach */
            //Vehicle bogusVehicle = new Vehicle();
            //return bogusVehicle.Vin();

            //grabs random vin via randomvin.com
            IWebDriver vinDriver = new ChromeDriver();
            vinDriver.Navigate().GoToUrl("https://randomvin.com/");
            Thread.Sleep(2000);
            string randomVin = vinDriver.FindElement(By.XPath("//span[@id='Result']/h2")).Text;
            Console.WriteLine("the random vin is: " + randomVin);
            vinDriver.Quit();
            return randomVin;

        }

        public dynamic GetRandom(string fieldName)
        {
            switch(fieldName)
            {
                case "VIN": return GenerateValidVIN();
                default: return null;
            }
        }

    }
}
