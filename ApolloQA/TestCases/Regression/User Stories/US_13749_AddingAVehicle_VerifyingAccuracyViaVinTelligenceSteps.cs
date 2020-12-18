using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.User_Stories
{
    [Binding]
    public class US_13749_AddingAVehicle_VerifyingAccuracyViaVinTelligenceSteps
    {
        IWebDriver driver;
        Components components;
        Functions functions;
        FeatureContext featureContext;
        Grid grid;

        public US_13749_AddingAVehicle_VerifyingAccuracyViaVinTelligenceSteps(IWebDriver driver, FeatureContext featureContext)
        {
            this.driver = driver;
            this.featureContext = featureContext;
            components = new Components(driver);
            functions = new Functions(driver);
            grid = new Grid(driver);
        }

        [When(@"User enters following values")]
        public void WhenUserEntersFollowingValues(Table table)
        {
            foreach (var row in table.Rows)
            {
                string fieldName = row["Field Name"];
                string fieldType = row["Field Type"];
                string value = row["Value"];

                if (fieldType == "Input" && value == "Random")
                {
                    value = functions.GetRandom(fieldName);
                    featureContext.Add("Last Random " + fieldName, value);
                }

                if (!components.UpdateInputField(fieldName, fieldType, value))
                    System.Console.WriteLine("Unable to update field: " + fieldName);

            }
            
        }

        [Then(@"the following fields have values")]
        public void ThenTheFollowingFieldsHaveValues(Table table)
        {
            foreach (var row in table.Rows)
            {
                string fieldName = row["Field Name"];
                string fieldType = row["Field Type"];
                string value = row["Value"];

                string displayedValue = components.GetValueOfInputField(fieldName, fieldType);

                if (value == "Any")
                {
                    Assert.IsTrue(displayedValue.Length > 0);
                }
                else if (value.Contains("Last Random"))
                {
                    string lastRandom = featureContext.Get<string>("Last Random " + fieldName);
                    Assert.AreEqual(lastRandom, displayedValue);
                }
                else
                {
                    Assert.AreEqual(value, displayedValue);
                }
                    

            }
        }


        [Then(@"(.*) modal is visible")]
        public void ThenModalIsVisible(string title)
        {
            IWebElement modalTitle = functions.FindElementWait(10, By.XPath("//h1[normalize-space(text())='" + title + "']"));

            Assert.IsTrue(modalTitle.Displayed);
        }

        [Then(@"Verify Grid contains entry with column equals value")]
        public void ThenVerifyGridContainsEntryWithColumnEqualsValue(Table table)
        {

            foreach (var row in table.Rows)
            {
                string columnName = row["Column"];
                string value = row["Value"];

                if(value.Contains("Last Random"))
                {
                    string lastRandom = featureContext.Get<string>("Last Random " + columnName);
                    value = lastRandom;
                }

                // find which number column number we want
                IList<IWebElement> columnHeaders = driver.FindElements(By.XPath("//datatable-header-cell"));
                int totalColumns = columnHeaders.Count;
                int columnNumber = 0;

                foreach (IWebElement header in columnHeaders)
                {
                    columnNumber++;

                    if (header.Text == columnName)
                        break;
                }

                //need to start at first page of grid
                if (grid.firstPage.Enabled)
                    grid.firstPage.Click();

                while (true)
                {
                    try
                    {
                        //find if value is present
                        IWebElement targetCell = functions.FindElementWait(10, By.XPath("//datatable-body-row//datatable-body-cell[" + columnNumber + "]//*[normalize-space(text())='" + value + "']"));
                        Assert.IsTrue(true);
                        break;
                    }
                    catch
                    {
                        if (grid.nextPage.Enabled)
                        {
                            grid.nextPage.Click();
                        }
                        else
                        {
                            Assert.IsTrue(false, "Unable to locate value " + value + " in Grid column " + columnName);
                            break;
                        }
                    }

                }
                

            }

        }

        [When(@"User clicks Grid ellipsis option for entry with column equals value")]
        public void WhenUserClicksGridEllipsisOptionForEntryWithColumnEqualsValue(Table table)
        {
            foreach (var row in table.Rows)
            {
                string columnName = row["Column"];
                string value = row["Value"];
                string option = row["Option"];

                if (value.Contains("Last Random"))
                {
                    string lastRandom = featureContext.Get<string>("Last Random " + columnName);
                    value = lastRandom;
                }

                // find which number column number we want
                IList<IWebElement> columnHeaders = driver.FindElements(By.XPath("//datatable-header-cell"));
                int totalColumns = columnHeaders.Count;
                int columnNumber = 0;

                foreach (IWebElement header in columnHeaders)
                {
                    columnNumber++;

                    if (header.Text == columnName)
                        break;
                }

                //need to start at first page of grid
                if (grid.firstPage.Enabled)
                    grid.firstPage.Click();


                while (true)
                {
                    try
                    {
                        //find if value is present
                        IWebElement targetCell = functions.FindElementWait(10, By.XPath("//datatable-body-row//datatable-body-cell[" + columnNumber + "]//*[normalize-space(text())='" + value + "']"));
                        Assert.IsTrue(true);
                        break;
                    }
                    catch
                    {
                        if (grid.nextPage.Enabled)
                        {
                            grid.nextPage.Click();
                        }
                        else
                        {
                            Assert.IsTrue(false, "Unable to locate value " + value + " in Grid column " + columnName);
                            break;
                        }
                    }

                }

                //click the ellipsis for this entry
                IWebElement ellipsis = functions.FindElementWait(10, By.XPath("//datatable-body-row//datatable-body-cell[" + columnNumber + "]//*[normalize-space(text())='" + value + "']/../../../datatable-body-cell[" + totalColumns + "]//button"));
                ellipsis.Click();

                Console.WriteLine("//datatable-body-row//datatable-body-cell[" + columnNumber + "]//*[normalize-space(text())='" + value + "']/../../../datatable-body-cell[" + totalColumns + "]");

                //click the option
                IWebElement targetOption = functions.FindElementWait(10, By.XPath("//button[@role='menuitem' and normalize-space(text())='" + option + "']"));
                targetOption.Click();

                Console.WriteLine("//button[@role='menuitem' and normalize-space(text())='" + option + "']");
            }
        }

    }
}
