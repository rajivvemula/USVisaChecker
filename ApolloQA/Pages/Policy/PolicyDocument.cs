using ApolloQA.Helpers;
using AutoIt;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Pages.Policy
{
    class PolicyDocument
    {

        private IWebDriver policyDriver;
        private Functions functions;

        //Upload and download file methood using AutoIT
        public void autoITFileUpload()
        {
            /*
            AutoItX autoIt = new AutoItX();
            autoIt.WinActivate("Open");
            Thread.Sleep(2000);
            autoIt.Send(@"C:\Users\agencer\Desktop\TestPNG.png");
            Thread.Sleep(1000);
            autoIt.Send("{ENTER}");*/
        }

        public PolicyDocument(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement documentsCTA => functions.FindElementWait(10, By.XPath("//div[contains(text(),'Documents')]"));
        public IWebElement newFileCTA => functions.FindElementWait(10, By.XPath("//span[contains(text(),'New File')]"));
        public IWebElement newFileButton => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label = 'add']"));
        public IWebElement BrowseYourComputerCTA => functions.FindElementWait(10, By.XPath("//label[contains(text(),'BROWSE YOUR')]"));
        public IWebElement verifyFile => functions.FindElementWait(30, By.XPath("//a[contains(text(),'TestPNG')]"));
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
            
            BrowseYourComputerCTA.SendKeys(@"C:\Users\agencer\Desktop\TestPNG.png");
            //uploadFileInput.SendKeys("C:/Users/Saeed.Malik/Desktop/TestFile.txt");
        }

        public bool checkStatus()
        {
            return verifyFile.Displayed;
            //return functions.FindElementWait(30, By.XPath("//div[@class='uploadProgress' normalize-space(text())='Upload Complete']")).Displayed;
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
