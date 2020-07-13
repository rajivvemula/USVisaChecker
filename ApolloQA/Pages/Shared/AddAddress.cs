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

        public IWebElement AddressLine1 => functions.FindElementWait(10, By.XPath("//input[@name='line1']"));
        public IWebElement AddressLine2 => functions.FindElementWait(10, By.XPath("//input[@name='line2']"));
        public IWebElement AddressCity => functions.FindElementWait(10, By.XPath("//input[@name='city']"));
        public IWebElement AddressZipCode => functions.FindElementWait(10, By.XPath("//input[@name='postalCode']"));
        public IWebElement SubmitButton => functions.FindElementWait(10, By.XPath("//button//span[normalize-space(text())='Submit']"));

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
