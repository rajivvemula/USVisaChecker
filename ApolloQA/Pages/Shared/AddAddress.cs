using ApolloQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class AddAddress
    {

        IWebDriver driver;
        Functions functions;


        public AddAddress(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement inputAddressLine1 => functions.FindElementWait(10, By.XPath("//input[@name='line1']"));
        public IWebElement inputAddressLine2 => functions.FindElementWait(10, By.XPath("//input[@name='line2']"));
        public IWebElement inputCity => functions.FindElementWait(10, By.XPath("//input[@name='city']"));
        public IWebElement inputZipCode => functions.FindElementWait(10, By.XPath("//input[@name='postalCode']"));
        public IWebElement selectState => functions.FindElementWait(10, By.XPath("//mat-select[@name='state']"));
        public IWebElement SubmitButton => functions.FindElementWait(10, By.XPath("//button//span[normalize-space(text())='Submit']"));
        public IWebElement useSelectedButton => functions.FindElementWait(30, By.XPath("//span[contains(text(),'Use selected')]"));
        public IWebElement defaultAddressInfo => functions.FindElementWait(30, By.XPath("//div[@class = 'address-info']"));
        public IWebElement saveButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));
        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "add1": return inputAddressLine1;
                case "add2": return inputAddressLine2;
                case "city": return inputCity;
                case "zip": return inputZipCode;
                case "state": return selectState;
                default: return null;

            }
        }
        public void EnterInput(string locator, string value)
        {
            getElementFromFieldname(locator).SendKeys(value);

        }

        public void EnterSelect(string locator, string value)
        {
            getElementFromFieldname(locator).Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Click();
        }

        public void SelectAddressType(string type)
        {
            //types: Billing, Location, Mailing, Shipping

            IWebElement typeDropdown = functions.FindElementWait(10, By.XPath("//mat-select[@name='addressTypeId']"));
            typeDropdown.Click();

            //click selection
            IWebElement target = functions.FindElementWait(10, By.XPath("//mat-option//span[normalize-space(text())='" + type + "']"));
            target.Click();
        }

        public void SelectState(string state)
        {
        
            IWebElement typeDropdown = functions.FindElementWait(10, By.XPath("(//*[contains(@id,'mat-select')])[3]"));
            typeDropdown.Click();


            IWebElement target = functions.FindElementWait(10, By.XPath("//mat-option//span[normalize-space(text())='" + state + "']"));
            target.Click();
        }

        public void SelectCountry(string country)
        {
            IWebElement typeDropdown = functions.FindElementWait(10, By.XPath("//mat-select[@name='countryId']"));
            typeDropdown.Click();

            IWebElement target = functions.FindElementWait(10, By.XPath("//mat-option//span[normalize-space(text())='" + country + "']"));
            target.Click();
        }


        public void ClickSubmit()
        {
            SubmitButton.Click();
        }



    }
}
