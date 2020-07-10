using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Helpers
{
    class Functions
    {

        private IWebDriver driver;

        public Functions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElementWait(int seconds, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch(StaleElementReferenceException stale)
            {
                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }

            return target;
        }

    }
}
