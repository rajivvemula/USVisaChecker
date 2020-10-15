﻿using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.Helpers
{
    class Functions
    {

        private IWebDriver driver;

        public Functions(IWebDriver driver)
        {
            this.driver = driver;
        }


        //Find Element - Wait Until Visible
        public IWebElement FindElementWait(int seconds, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch(StaleElementReferenceException stale)
            {
                Thread.Sleep(5000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch(ElementClickInterceptedException clickintercepted)
            {
                Thread.Sleep(2000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }

            JavaScriptExecutor.highlight(driver, target);
            Thread.Sleep(250);
            try
            {
                JavaScriptExecutor.highlight(driver, target, 0);
            } 
            catch
            {
                //do nothing
            }

            return target;
        }


        //Find Element - Wait Until Clickable
        public IWebElement FindElementWaitUntilClickable(int seconds, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement target;

            try
            {
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (StaleElementReferenceException stale)
            {
                Thread.Sleep(2000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (ElementClickInterceptedException clickintercepted)
            {
                Thread.Sleep(2000);

                //retry finding the element
                target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }

            JavaScriptExecutor.highlight(driver, target);
            Thread.Sleep(250);
            try
            {
                JavaScriptExecutor.highlight(driver, target, 0);
            }
            catch
            {
                //do nothing
            }

            return target;
        }
        public static IEnumerable<Dictionary<String, String>> parseUITable(IWebElement ngxDatatableElement)
        {
            List<String> columnNames = ngxDatatableElement.FindElements(By.XPath("//datatable-header-cell//span[contains(@class,'datatable-header-cell-label')]")).Select(element => element.Text).ToList<String>();

            foreach(var row in ngxDatatableElement.FindElements(By.XPath("//datatable-body-row")))
            {
                List<IWebElement> cells = row.FindElements(By.XPath("//datatable-body-cell")).ToList<IWebElement>();
                var rowDict = new Dictionary<String, String>();

                for(int i=0; i<columnNames.Count(); i++)
                {
                    String cellText = string.Join("", cells[i].FindElements(By.XPath("/descendant::*/text()")).Select(child => child.Text));
                    rowDict.Add(columnNames[i], cellText);
                }
                yield return rowDict;
            }
        }

        public static Dictionary<string, string> TableToDictionary(TechTalk.SpecFlow.Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static IEnumerable<Dictionary<String, String>> parseCSV(String filePath, int headerRow=0)
        {

            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = doc.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                Row[] sheetData = worksheetPart.Worksheet.Elements<SheetData>().First().Elements<Row>().ToArray<Row>();

                var header = sheetData[0].Elements<Cell>().Select(cell =>cell.CellValue.Text ).ToArray<string>();

                for (int rowIndex = 1; rowIndex < sheetData.Length; rowIndex++)
                {
                    
                    var cells = sheetData[rowIndex].Elements<Cell>().ToArray<Cell>();

                    var dict = new Dictionary<String, String>();
                    for (int i = 0; i < header.Length; i++)
                    {
                        dict.Add(header[i], cells[i].CellValue.Text);
                    }
                    yield return dict;
                }
            }

           
        }
        public static dynamic parseRatingFactorNumericalValues(String value)
        {
            if (value.Contains("+"))
            {
                return int.MaxValue;
            }
            else if(int.TryParse(value, out int intValue))
            {
                return intValue;
            }
            else
            {
                return null;
            }
        }

    }
}
