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
        


        public void ClickSubmit()
        {
            SubmitButton.Click();
        }



    }
}
