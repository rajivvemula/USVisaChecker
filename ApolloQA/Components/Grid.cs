using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Components
{
    class Grid
    {

        IWebElement nextPage => UserActions.FindElementWaitUntilVisible(By.XPath("//a[@aria-label = 'go to next page']"), 10);
        IWebElement firstPage => UserActions.FindElementWaitUntilVisible(By.XPath("//a[@aria-label = 'go to first page']"), 10);
        IWebElement prevPage => UserActions.FindElementWaitUntilVisible(By.XPath("//a[@aria-label = 'go to previous page']"), 10);
        IWebElement lastPage => UserActions.FindElementWaitUntilVisible(By.XPath("//a[@aria-label = 'go to last page']"), 10);



        public List<string> GetColumnHeaders()
        {
            List<string> columnHeaderNames = new List<string>();

            IList<IWebElement> columnHeaders = UserActions.FindElementsWaitUntilVisible(By.XPath("//datatable-header-cell"));

            foreach(IWebElement header in columnHeaders)
            {
                columnHeaderNames.Add(header.Text);
            }

            return columnHeaderNames;
        }

        public bool GridContainsColumnWithValue(string column, string value)
        {
            IList<IWebElement> columnHeaders = UserActions.FindElementsWaitUntilVisible(By.XPath("//datatable-header-cell"));
            int totalColumns = columnHeaders.Count;
            int columnNumber = 0;

            foreach (IWebElement header in columnHeaders)
            {
                columnNumber++;

                if (header.Text == column)
                    break;
            }

            //need to start at first page of grid
            try
            {
                if (firstPage.Enabled)
                    firstPage.Click();
            }
            catch { }

            while (true)
            {
                try
                {
                    //find if value is present
                    IWebElement targetCell = UserActions.FindElementWaitUntilVisible(By.XPath("//datatable-body-row//datatable-body-cell[" + columnNumber + "]//*[normalize-space(text())='" + value + "']"));

                    return true;
                }
                catch
                {
                    try
                    {
                        if (nextPage.Enabled)
                        {
                            nextPage.Click();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch { }
                }

            }
        }


        public bool GridClickRowOptionForColumnWithValue(string column, string value, string option)
        {
                IList<IWebElement> columnHeaders = UserActions.FindElementsWaitUntilVisible(By.XPath("//datatable-header-cell"));
                int totalColumns = columnHeaders.Count;
                int columnNumber = 0;

                foreach (IWebElement header in columnHeaders)
                {
                    columnNumber++;

                    if (header.Text == column)
                        break;
                }

                //need to start at first page of grid
                try
                {
                    if (firstPage.Enabled)
                        firstPage.Click();
                }
                catch { }

                while (true)
                {
                    try
                    {
                        //find if value is present
                        IWebElement targetCell = UserActions.FindElementWaitUntilVisible(By.XPath("//datatable-body-row//datatable-body-cell[" + columnNumber + "]//*[normalize-space(text())='" + value + "']"));

                        //if value present, click ellipsis
                        IWebElement ellipsis = UserActions.FindElementWaitUntilVisible(By.XPath("//datatable-body-row//datatable-body-cell[" + columnNumber + "]//*[normalize-space(text())='" + value + "']/../../../datatable-body-cell[" + totalColumns + "]//button"));
                        ellipsis.Click();

                        //click the option
                        IWebElement targetOption = UserActions.FindElementWaitUntilClickable(By.XPath("//button[@role='menuitem' and normalize-space(text())='" + option + "']"));
                        targetOption.Click();

                        return true;
                    }
                    catch
                    {
                        try
                        {
                            if (nextPage.Enabled)
                            {
                                nextPage.Click();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        catch { }
                    }

                }


         }


    }
}
