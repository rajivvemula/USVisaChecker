﻿using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Helpers;
using OpenQA.Selenium;

namespace ApolloQA.Pages.Application
{
    class BusinessInformation
    {
        private IWebDriver driver;
        private Functions functions;
        private Components components;

        public BusinessInformation(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
            components = new Components(driver);
        }

        public IWebElement businessName => functions.FindElementWait(10, By.XPath("//input[@name='businessName']"));
        public IWebElement taxNo => functions.FindElementWait(10, By.XPath("//input[@name='taxId']"));

        public IWebElement appIDNo => functions.FindElementWait(10, By.XPath("//div[text()=' Application Number ']/../div/strong"));

        public IWebElement selectMailing => functions.FindElementWait(10, By.XPath("//mat-label[@class='ng-star-inserted' and normalize-space(text())='Mailing Address']"));
        public IWebElement nextButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Next']"));



        public void UpdateMailingAddress(string selection)
        {
            //click the mailing address drop-down
            IWebElement mailingAddress = functions.FindElementWaitUntilClickable(10, By.XPath("//mat-select[@formcontrolname='mailingAddressId']"));
            mailingAddress.Click();

            //find and click the target (ignores case differences)
            IWebElement theSelection = functions.FindElementWaitUntilClickable(5,
                By.XPath("//mat-option[*//div[@class='address-info' and translate(normalize-space(text()), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '" + selection.Trim().ToLower() + "']]"));
            theSelection.Click();
        }


        public void UpdatePhysicalAddress(string selection)
        {
            //first, make sure physical address checkbox is checked
            IWebElement checkbox = functions.FindElementWaitUntilClickable(10, By.XPath("//input[@name='differentMailingAddress']"));
            if (checkbox.GetAttribute("aria-checked").Equals("false"))
            {
                //have to click the mat-checkbox not the input
                IWebElement matCheckbox = functions.FindElementWaitUntilClickable(10, By.XPath("//mat-checkbox[@name='differentMailingAddress']"));
                matCheckbox.Click();
            }               

            //click the phsyical address drop-down
            IWebElement physicalAddress = functions.FindElementWaitUntilClickable(10, By.XPath("//mat-select[@formcontrolname='physicalAddressId']"));
            physicalAddress.Click();

            //find and click the target (ignores case differences)
            IWebElement theSelection = functions.FindElementWaitUntilClickable(5,
                By.XPath("//mat-option[*//div[@class='address-info' and translate(normalize-space(text()), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '" + selection.Trim().ToLower() + "']]"));
            theSelection.Click();
        }




    }
}
