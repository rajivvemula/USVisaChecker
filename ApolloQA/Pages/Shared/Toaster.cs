using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class Toaster
    {

        private IWebDriver Driver;
        private WebDriverWait wait;

        public Toaster(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        public string GetToastTitle()
        {
            IWebElement toast = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("toast-title")));
            string toastTitle = toast.Text;
            return toastTitle;
        }
    }
}
