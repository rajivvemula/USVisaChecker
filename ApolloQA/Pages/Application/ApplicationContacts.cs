using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Application
{
    class ApplicationContacts
    {

        private IWebDriver driver;
        private Functions functions;
        private Components components;

        public ApplicationContacts(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
            components = new Components(driver);
        }

        public IWebElement contactButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Contact']"));

        //This button is inside the select 
        public IWebElement addContactButton => functions.FindElementWait(5, By.XPath("//button[@aria-label='Add Contact']"));
        public IWebElement addAddressButton => functions.FindElementWait(5, By.XPath("//button[@aria-label='Add Policy']"));

        //Inputs
        public IWebElement primaryPhone => functions.FindElementWaitUntilClickable(10, By.XPath("//input[@formcontrolname='phone1']"));
        public IWebElement emailInput => functions.FindElementWaitUntilClickable(10, By.XPath("//input[@formcontrolname='email']"));
        public IWebElement secondaryPhone => functions.FindElementWaitUntilClickable(10, By.XPath("//input[@formcontrolname='phone2']"));

        //Checkboxes
        public IWebElement checkboxPrimaryOfficer => functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='Primary Officer']"));
        public IWebElement checkboxLossControl => functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='Loss Control Inspector']"));
        public IWebElement checkboxPrimaryOwner => functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='Primary Owner']"));
        public IWebElement checkboxAuditClerk => functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='Audit Clerk']"));
        public IWebElement checkboxOpManager => functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='Operations Manager']"));
        public IWebElement checkboxAccClerk => functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='Accounating Clerk']"));
        public IWebElement checkboxAuthUser => functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='Authorized User']"));
        public IWebElement checkboxFMCSA => functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='FMCSA']"));

        //Selects
        public IWebElement selectContact => functions.FindElementWait(10, By.XPath("//mat-label[@class='ng-star-inserted' and normalize-space(text())='Contact Name']"));
        public IWebElement selectAddress => functions.FindElementWait(10, By.XPath("//mat-label[@class='ng-star-inserted' and normalize-space(text())='Address']"));

    }
}
