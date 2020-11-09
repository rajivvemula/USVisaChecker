using ApolloQA.Components;
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

                if (fieldType == "input")
                {
                    InputField inputField = new InputField(displayName);
                    inputField.SetValue(value);
                }
                else if (fieldType == "Dropdown")
                {
                    Dropdown dropdown = new Dropdown(displayName);
                    dropdown.SetValue(value);
                }
                else if (fieldType == "Autocomplete")
                {
                    AutocompleteInput autoInput = new AutocompleteInput(displayName);
                    autoInput.SetValue(value);
                }

            }
        }

    }
}
