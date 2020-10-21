using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            functions = new Functions(driver);
        }

        public IWebElement continueAnywayButton => functions.FindElementWait(10, By.XPath("//button[@color = 'warn']"));


        public bool CheckLabel(string label)
        {
            bool verify = cDriver.FindElement(By.XPath("//mat-label[contains(text(),'" + label + "')]")).Displayed;
            return verify;
        }

        public bool CheckError(string label)
        {
            bool verify = cDriver.FindElement(By.XPath("//mat-error[contains(text(),'" + label + "')]")).Displayed;
            return verify;
        }

        public bool CheckSelectValue(string value)
        {
            IWebElement valueToBeChecked = functions.FindElementWaitUntilClickable(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']"));
            return valueToBeChecked.Displayed;
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

        public string Geth3()
        {
            IWebElement currenth3 = functions.FindElementWait(10, By.XPath("//h3"));
            string h3tobesent = currenth3.Text;
            return h3tobesent;
        }


        /* UpdateDropdown - used for updating mat-select dropdown lists */
        public bool UpdateDropdown(string formcontrolname, string selection)
        {
            //locate the dropdown
            IWebElement dropdownField = functions.FindElementWaitUntilClickable(10, By.XPath("//mat-select[@formcontrolname='" + formcontrolname + "']"));
            //if dropdown is disabled OR if the selection is already selected, return false
            if (dropdownField.GetAttribute("aria-disabled").Equals("true") || dropdownField.Text.Equals(selection))
                return false;
            //otherwise, click the dropdown and make the selection
            dropdownField.Click();
            IWebElement theSelection = functions.FindElementWaitUntilClickable(10, By.XPath("//mat-option/span[normalize-space(text())='" + selection + "']"));
            theSelection.Click();
            return true;
        }

        /* UpdateAutoCompleteInput - used for updating bh-input-autocomplete fields (magnifying glass) 
                - Requires that search string matches exactly to selection (NOT case sensitive however)
         */
        public void UpdateAutoCompleteInput(string formcontrolname, string selection)
        {
            IWebElement inputField = functions.FindElementWaitUntilClickable(15, By.XPath("//bh-input-autocomplete[@formcontrolname='" + formcontrolname + "']/input"));

            inputField.Click();
            //inputField.Clear();
            inputField.SendKeys(selection);

            //REQUIRED - OTHERWISE CLICKING AUTOCOMPLETED SELECTION HAPPENS TOO QUICKLY 
            // issue notced when creating new Application and selecting business name, taxonomy field is missing without this sleep
            Thread.Sleep(2000);

            IWebElement theSelection = functions.FindElementWaitUntilClickable(10, 
                By.XPath("//mat-option[contains(@class,'provided') and .//div[@class='line-label' and translate(normalize-space(text()), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '" + selection.ToLower() + "']]"));

            theSelection.Click();

        }

        public string GetValueFromHeaderField(string fieldLabel)
        {
            IWebElement theField = functions.FindElementWait(10, By.XPath("//div[contains(@class, 'header-column')]/div[normalize-space(text())='" + fieldLabel + "']/preceding-sibling::div/strong[string-length(text()) > 0]"));

            return theField.Text;
        }

        public string GetValueFromInputFieldByNameAttribute(string name)
        {
            IWebElement theField = functions.FindElementWait(10, By.XPath("//*[@name='" + name + "']"));

            return theField.GetAttribute("value");
        }


        public bool CheckIfDialogPresent()
        {
            try
            {
                IWebElement dialogCheck = functions.FindElementWait(10, By.XPath("//bh-unsaved-changes-confirmation-dialog[@class = 'component']"));
                return dialogCheck.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        public bool CheckIfTabPresent(string tabName)
        {
            IWebElement tabLink = functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='" + tabName + "']"));
            bool verifyTab = tabLink.Displayed;
            return verifyTab;
        }

        public void ClickSideTab(string tabName)
        {
            IWebElement tabLink = functions.FindElementWait(60, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='" + tabName + "']"));
            tabLink.Click();
        }

        // Below EnterInput, EnterSelect, GetRequired, GetValue replace switch case in POMs
        public void EnterInput(IWebElement locator, string value)
        {
            locator.SendKeys(value);
        }
        public void EnterSelect(IWebElement locator, string value)
        {
            locator.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Click();
        }
        public void ClickSelect(string locator)
        {
            IWebElement select = functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='" + locator + "']"));
            select.Click();
            //add a body click
        }
        public string GetRequired(IWebElement locator)
        {
            return locator.GetAttribute("aria-required");
        }
        public string GetValue(IWebElement locator)
        {
            return locator.GetAttribute("value");
        }

        public void CheckIfHome()
        {
            // !cDriver.Url.Contains(Defaults.QA_URLS["Home"]) but for now we might need some action in if
            if (cDriver.Url.Contains(Defaults.QA_URLS["Home"]))
            {
                //home 
            }
            else
            {
                cDriver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
            }
        }

        public bool CheckIfRadioExists(string radioValue)
        {
            //IWebElement checkbox = functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='" + radioValue + "']"));
            IWebElement checkbox = functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and text() = ' " + radioValue + " '])"));
            return checkbox.Displayed;
        }

        public void SelectRadioOption(string radio)
        {
            IWebElement checkbox = functions.FindElementWait(10, By.XPath("//div[@class='mat-radio-label-content' and text() = ' " + radio + " '])"));
            checkbox.Click();

        }

        public string CheckInputRequirement(string name)
        {
            //*[@formcontrolname='subrogationReferralId']
            IWebElement input = functions.FindElementWait(10, By.XPath("//*[@formcontrolname='" + name + "'])"));
            return input.GetAttribute("aria-required");
        }
        //public void UpdateResourceSelectDropdown()
        //{

        //}

    }
}

