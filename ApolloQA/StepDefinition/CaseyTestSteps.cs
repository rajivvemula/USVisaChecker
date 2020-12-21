using ApolloQA.Components;
using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using OpenQA.Selenium;
using System;
using System.Xml.XPath;
using TechTalk.SpecFlow;

namespace ApolloQA.Features
{
    [Binding]
    public class CaseyTestSteps
    {
        FeatureContext featureContext;

        public CaseyTestSteps(FeatureContext featureContext)
        {
            this.featureContext = featureContext;
        }

        [When(@"user clicks (.*) button")]
        public void WhenUserClicksSaveButton(string buttonName)
        {
            Button button = new Button(buttonName);
            button.Click();
        }


        [When(@"user clicks (.*) tab")]
        public void WhenUserClicksTab(string tabName)
        {
            NavigationBar navBar = new NavigationBar();
            navBar.ClickTab(tabName);
        }

        [When(@"user enters following values")]
        public void WhenUserEntersFollowingValues(Table table)
        {
            UserActions.WaitForSpinnerToDisappear();

            foreach (var row in table.Rows)
            {
                string displayName = row["Display Name"];
                string fieldType = row["Field Type"];
                string value = row["Value"];

                if (fieldType.ToLower() == "input")
                {
                    InputField inputField = new InputField(displayName);

                    if (displayName == "VIN" && value == "Random")
                    {
                        value = Functions.GetRandomVIN();
                        featureContext.Add("Last Random " + displayName, value);
                    }

                    inputField.SetValue(value);
                }
                else if (fieldType.ToLower() == "dropdown")
                {
                    Dropdown dropdown = new Dropdown(displayName);
                    if (value.ToLower() == "random")
                        dropdown.SetRandom();
                    else
                        dropdown.SetValue(value);
                }
                else if (fieldType.ToLower() == "autocomplete")
                {
                    AutocompleteInput autoInput = new AutocompleteInput(displayName);
                    autoInput.SetValue(value);
                }

            }
        }

        [When(@"user selects Organization")]
        public void WhenUserSelectsOrganization()
        {
            Shared.GetButton(" Smoke Test698 ").Click();
        }


        [Then(@"(.*) button is enabled")]
        public void ThenSaveButtonIsEnabled(string buttonText)
        {
            Button button = new Button(buttonText);
            Assert.IsTrue(button.IsEnabled());
        }

        [Then(@"the following fields have values")]
        public void ThenTheFollowingFieldsHaveValues(Table table)
        {
            UserActions.WaitForSpinnerToDisappear();

            foreach (var row in table.Rows)
            {
                string displayName = row["Display Name"];
                string fieldType = row["Field Type"];
                string value = row["Value"];

                string displayedValue = "";

                if (fieldType.ToLower() == "input")
                {
                    InputField inputField = new InputField(displayName);

                    if (displayName == "VIN" && value == "Last Random")
                        value = featureContext.Get<string>("Last Random " + displayName);

                    displayedValue = inputField.GetValue();
                }
                else if (fieldType.ToLower() == "dropdown")
                {
                    Dropdown dropdown = new Dropdown(displayName);
                    displayedValue = dropdown.GetValue();
                }
                else if (fieldType.ToLower() == "autocomplete")
                {
                    AutocompleteInput autoInput = new AutocompleteInput(displayName);
                    displayedValue = autoInput.GetValue();
                }
                else
                {
                    Console.WriteLine("Unexpected fieldType.");
                }

                if (value.ToLower() == "any")
                    Assert.IsTrue(displayedValue.Length > 0);
                else
                {
                    Console.WriteLine("displayed value: " + displayedValue + "    expected: " + value);
                    Assert.AreEqual(displayedValue, value);

                }
            }
        }

        [When(@"user clicks (.*) sidetab")]
        public void WhenUserClicksSidetab(string tabName)
        {
            LeftSidetab sidetab = new LeftSidetab(tabName);
            sidetab.Click();
        }

        [Then(@"(.*) sidetab is active")]
        public void ThenVehiclesSidetabIsActive(string tabName)
        {
            UserActions.WaitForSpinnerToDisappear();

            LeftSidetab sidetab = new LeftSidetab(tabName);
            Assert.AreEqual(tabName, sidetab.GetActiveSidetab());
        }

        [Then(@"URL contains (.*)")]
        public void ThenURLContains(string urlContains)
        {
            UserActions.WaitForSpinnerToDisappear();
            Assert.CurrentURLContains(urlContains);
        }

        [Then(@"(.*) modal is visible")]
        public void ThenModalIsVisible(string title)
        {
            // This can be split out into another file

            IWebElement modalTitle = UserActions.FindElementWaitUntilVisible(By.XPath("//h1[normalize-space(text())='" + title + "']"), 10);

            Assert.IsTrue(modalTitle.Displayed);
        }

        //[Then(@"toast message (.*) is displayed")]
        //public void ThenToastMessageIsDisplayed(string message)
        //{
        //    IWebElement toast = UserActions.FindElementWaitUntilVisible(By.ClassName("toast-title"), 20);
        //}

        [Then(@"Verify grid contains entry with column equals value")]
        public void ThenVerifyGridContainsEntryWithColumnEqualsValue(Table table)
        {
            Grid theGrid = new Grid();

            foreach (var row in table.Rows)
            {
                string columnName = row["Column"];
                string value = row["Value"];

                //if (value.Contains("Last Random"))
                //{
                //    string lastRandom = featureContext.Get<string>("Last Random " + columnName);
                //    value = lastRandom;
                //}

                if (columnName == "VIN" && value == "Last Random")
                    value = featureContext.Get<string>("Last Random " + columnName);

                if (!theGrid.GridContainsColumnWithValue(columnName, value))
                    NUnit.Framework.Assert.IsTrue(false, "Unable to locate value " + value + " in Grid column " + columnName);
                else
                    Console.WriteLine("Successfully located " + columnName + " = " + value + " in Grid.");

            }

        }

        [When(@"user clicks (.*) option for grid with column equals value")]
        public void WhenUserClicksOptionForGridWithColumnEqualsValue(string option, Table table)
        {
            Grid theGrid = new Grid();

            foreach (var row in table.Rows)
            {
                string columnName = row["Column"];
                string value = row["Value"];

                if (columnName == "VIN" && value == "Last Random")
                    value = featureContext.Get<string>("Last Random " + columnName);

                //if (value.Contains("Last Random"))
                //{
                //    string lastRandom = featureContext.Get<string>("Last Random " + columnName);
                //    value = lastRandom;
                //}

                if (!theGrid.GridClickRowOptionForColumnWithValue(columnName, value, option))
                    NUnit.Framework.Assert.IsTrue(false, "Unable to locate value " + value + " in Grid column " + columnName);
                else
                    Console.WriteLine("Successfully located " + columnName + " = " + value + " in Grid and clicked option " + option);

            }
        }

        [When(@"user enters search query: (.*)")]
        public void WhenUserEntersSearchQuery(string query)
        {
            NavigationBar navBar = new NavigationBar();
            navBar.SearchQuery(query);
        }

        [When(@"user clicks first search result")]
        public void WhenUserClicksFirstSearchResult()
        {
            NavigationBar navBar = new NavigationBar();
            navBar.ClickFirstSearchResult();
        }


    }
}
