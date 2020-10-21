﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ApolloQA.Helpers;
using System.Linq;

namespace ApolloQA.Pages.Shared
{
    class RatingWorksheet
    {

        IWebDriver driver;
        Functions functions;


        public RatingWorksheet(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
        }

        public List<IWebElement> resultList
        {
            get
            {
                By by = By.XPath("//mat-label/b[contains(text(), 'Risk')]/../..");
                functions.FindElementWait(60, by);
                return this.driver.FindElements(by).ToList<IWebElement>();
            }
        }

        public IEnumerable<Dictionary<String, String>> getResultTable(String risk, String ratingAlgorithm)
        {
            return Functions.parseUITable(findResult(risk, ratingAlgorithm).FindElements(By.XPath("//ngx-datatable")).First());
        }

        public IWebElement findResult(String risk, String ratingAlgorithm)
        {
            IWebElement result = resultList.Find(result => result.FindElements(By.XPath($"//mat-label[contains(text(), '{risk}')]")).Count>0  && 
                                                           result.FindElements(By.XPath($"//mat-label[contains(text(), '{ratingAlgorithm}')]")).Count > 0);

            if(result == null)
            {
                throw new ElementNotVisibleException($"There was no result with Risk: {risk} & Rating Algorithm: {ratingAlgorithm}");
            }
            return result;
        }



        
    }
}
