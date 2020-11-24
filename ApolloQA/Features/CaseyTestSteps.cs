using ApolloQA.Components;
using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Xml.XPath;
using TechTalk.SpecFlow;

namespace ApolloQA.Features
{
    [Binding]
    public class CaseyTestSteps
    {

        [When(@"user clicks (.*) tab")]
        public void WhenUserClicksTab(string tabName)
        {
            NavigationBar navBar = new NavigationBar();
            navBar.ClickTab(tabName);
        }
        
        [When(@"user clicks (.*) button")]
        public void WhenUserClicksButton(string buttonText)
        {
            Button button = new Button(buttonText);
            button.Click();
        }

        [When(@"user enters following values")]
        public void WhenUserEntersFollowingValues(Table table)
        {
            foreach (var row in table.Rows)
            {
                string displayName = row["Display Name"];
                string fieldType = row["Field Type"];
                string value = row["Value"];

                if (fieldType.ToLower() == "input")
                {
                    InputField inputField = new InputField(displayName);
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

        [Then(@"(.*) button is enabled")]
        public void ThenSaveButtonIsEnabled(string buttonText)
        {
            Button button = new Button(buttonText);
            Assert.IsTrue(button.IsEnabled());
        }

        [Then(@"the following fields have values")]
        public void ThenTheFollowingFieldsHaveValues(Table table)
        {
            foreach (var row in table.Rows)
            {
                string displayName = row["Display Name"];
                string fieldType = row["Field Type"];
                string value = row["Value"];

                string displayedValue = "";

                if (fieldType.ToLower() == "input")
                {
                    InputField inputField = new InputField(displayName);
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

                if (value.ToLower() == "Any")
                    Assert.IsTrue(displayedValue.Length > 0);
                else
                    Assert.Equals(displayedValue, value);
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
            Assert.Equals(tabName, sidetab.GetActiveSidetab());
        }

        [Then(@"URL contains (.*)")]
        public void ThenURLContains(string urlContains)
        {
            UserActions.WaitForSpinnerToDisappear();
            Assert.IsTrue(UserActions.GetCurrentURL().Contains(urlContains));
        }

        [Then(@"(.*) modal is visible")]
        public void ThenNewVehicleModalIsVisible(string title)
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





    }
}
