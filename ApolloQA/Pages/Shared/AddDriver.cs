using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class AddDriver
    {

        private IWebDriver Driver;
        Functions functions;
        public AddDriver(IWebDriver driver)
        {
            Driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement inputFirst => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='firstName']"));
        public IWebElement inputMiddle => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='middleName']"));

        public IWebElement inputLast => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='lastName']"));

        public IWebElement inputSuffix => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='nameSuffix']"));

        public IWebElement inputBirth => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='dateOfBirth']"));

        public IWebElement inputLicenseNumber => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='licenseNo']"));



    }


}
