using ApolloQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyDocument
    {

        private IWebDriver policyDriver;
        private Functions functions;

        public PolicyDocument(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }


        public IWebElement newFileButton => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label = 'add']"));
        public IWebElement uploadFileInput=> functions.FindElementWait(30, By.XPath("//input[@id='file']"));
        public IWebElement fileStatus => functions.FindElementWait(10, By.XPath("//div[@class='uploadProgress' normalize-space(text())='Upload Complete']"));
        public IWebElement moreOptionsButton => functions.FindElementWait(10, By.XPath("//mat-icon[contains(text(),'more_vert')]"));
        public IWebElement deleteFileButton => functions.FindElementWait(10, By.XPath("//button[contains(text(),'Delete')]"));
        public void ClickAddNew()
        {
            newFileButton.Click();
        }

        public void uploadFile()
        {
            uploadFileInput.SendKeys("C:/Users/Saeed.Malik/Desktop/TestFile.txt");
        }

        public bool checkStatus()
        {
            return functions.FindElementWait(30, By.XPath("//div[@class='uploadProgress' normalize-space(text())='Upload Complete']")).Displayed;
        }

        public void OpenFile(string fileName)
        {
            functions.FindElementWait(10, By.LinkText(fileName)).Click();
        }

        public void DeleteDocument()
        {
            moreOptionsButton.Click();
            moreOptionsButton.Click();
            deleteFileButton.Click();
        }
    }
}
