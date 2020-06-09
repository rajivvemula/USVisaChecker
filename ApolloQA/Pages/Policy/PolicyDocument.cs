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
        public PolicyDocument(IWebDriver driver)
        {
            policyDriver = driver;

        }

        public IWebElement newFileButton => policyDriver.FindElement(By.XPath("//mat-icon[@aria-label = 'add']"));
        public IWebElement uploadFileInput=> policyDriver.FindElement(By.Id("file"));
        public IWebElement fileStatus => policyDriver.FindElement(By.XPath("//div[@class='uploadProgress' normalize-space(text())='Upload Complete']"));
        public IWebElement moreOptionsButton => policyDriver.FindElement(By.XPath("//mat-icon[contains(text(),'more_vert')]"));
        public IWebElement deleteFileButton => policyDriver.FindElement(By.XPath("//button[contains(text(),'Delete')]"));
        public void ClickAddNew()
        {
            newFileButton.Click();
        }

        public void uploadFile()
        {
            uploadFileInput.SendKeys("C:/Users/Saeed.Malik/Desktop/TestFile.txt");
        }

        public void checkStatus()
        {
            //wait for the button to be clickable
            WebDriverWait wait = new WebDriverWait(policyDriver, TimeSpan.FromSeconds(20));
            IWebElement target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='uploadProgress' normalize-space(text())='Upload Complete']")));

            //click it
            target.Click();
        }

        public void OpenFile(string fileName)
        {
            policyDriver.FindElement(By.LinkText(fileName)).Click();
        }

        public void DeleteDocument()
        {
            moreOptionsButton.Click();
            moreOptionsButton.Click();
            deleteFileButton.Click();
        }
    }
}
