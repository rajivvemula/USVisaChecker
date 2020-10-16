using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Fnol
{
    class FNOLReview
    {
        private IWebDriver fnolDriver;
        private Functions functions;

        public FNOLReview(IWebDriver driver)
        {
            fnolDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement selectComplexity => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='complexityId']"));
        public IWebElement selectThirdParty => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='thirdPartyAdminId']"));
        public IWebElement inputNotes => functions.FindElementWait(10, By.XPath("//text-area[@formcontrolname='supervisoryNotes']"));

    }
}
