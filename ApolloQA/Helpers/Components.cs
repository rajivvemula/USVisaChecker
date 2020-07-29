﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Helpers
{
    class Components
    {

        private IWebDriver cDriver;
        WebDriverWait wait;
        Functions functions;
        public Components(IWebDriver driver)
        {
            cDriver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            functions = new Functions(driver);
        }

        public IWebElement continueAnywayButton => functions.FindElementWait(10, By.XPath("//button[@color = 'warn']"));


        public bool CheckLabel(string label)
        {
            bool verify = cDriver.FindElement(By.XPath("//mat-label[contains(text(),'" + label + "')]")).Displayed;
            return verify;
        }

        public bool GetTitle(string titleToBeChecked)
        {
            bool title = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(titleToBeChecked));
            return title;
        }

        public string GetDialogTitle()
        {
            IWebElement title = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h1[@class='mat-dialog-title']")));
            string rTitle = title.Text;
            return rTitle;

        }

        public bool UpdateDropdown(string formcontrolname, string selection)
        {
            //locate the dropdown
            IWebElement dropdownField = functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='" + formcontrolname + "']"));
            //if dropdown is disabled OR if the selection is already selected, return false
            if (dropdownField.GetAttribute("aria-disabled").Equals("true") || dropdownField.Text.Equals(selection))
                return false;
            //otherwise, click the dropdown and make the selection
            dropdownField.Click();
            IWebElement theSelection = functions.FindElementWait(10, By.XPath("//mat-option/span[normalize-space(text())='" + selection + "']"));
            theSelection.Click();
            return true;
        }

    }
}

