using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Fnol
{
    class FNOLDetails
    {
        private IWebDriver fnolDriver;
        private Functions functions;

        public FNOLDetails(IWebDriver driver)
        {
            fnolDriver = driver;
            functions = new Functions(driver);
        }




    }
}
