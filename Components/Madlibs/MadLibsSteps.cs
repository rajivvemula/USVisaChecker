using BiBerkLOB.Components;
using BiBerkLOB.Components.PL;
using BiBerkLOB.Pages;
using HitachiQA.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using HitachiQA;
using TechTalk.SpecFlow;
using NUnitAssert = NUnit.Framework.Assert;
using HitachiAssert = HitachiQA.Assert;

namespace BiBerkLOB.Features.CaseyTests
{
    [Binding]
    public class MadLibsSteps
    {

        [Given(@"user lands on biBerk homepage")]
        public void GivenUserLandsOnBiBerkHomepage()
        {
            UserActions.Navigate("/");
        }


        [Given(@"user lands on biBerk homepage with cleared cache")]
        public void GivenUserLandsOnBiBerkHomepageWithClearedCache()
        {
            UserActions.Navigate("/MUNCH");
            ClearCacheMunchPage.returnToHomePageButton.Click();
            HomePage.Logo.AssertElementIsVisible();
        }

        //steps can contain other already written steps
        [Given(@"user starts a new quote with below values")]
        public void GivenUserStartsANewQuoteWithBelowValues(Table table)
        {
            var row = table.Rows[0];

            string industry = row["Industry"];
            string employees = row["Employees"];
            string location = row["Location"];
            string zipCode = row["ZIP Code"];
            string lobName = row["LOB"];

            GivenUserLandsOnBiBerkHomepage();
            WhenUserClicksGetAQuote();

            /* Industry - try catch is due to issues with selection of autocomplete option failing intermittently */
            try
            {
                WhenUserEntersValueForAutoCompleteInputField(industry, "What's your industry?");
                WhenUserSelectsAutoCompleteOption(industry);
                WhenUserClicksButton("Let's Go!");
            }
            catch
            {
                WhenUserEntersValueForAutoCompleteInputField(industry, "What's your industry?");
                WhenUserSelectsAutoCompleteOption(industry);
                WhenUserClicksButton("Let's Go!");
            }

            /* Employees */
            int employeeCount = int.Parse(employees);
            if (employeeCount == 0)
            {
                WhenUserSelectsTileFor("No, just the owner(s)");
                WhenUserClicksButton("Next");
            }            
            else
            {
                WhenUserSelectsTileFor("Yes, I have employees");
                WhenUserClicksButton("Next");
                WhenUserEntersEmployeeCountOf(employeeCount);
                WhenUserClicksButton("Next");
            }

            /* Location */
            WhenUserSelectsTileFor(location);
            WhenUserClicksButton("Next");

            /* ZIP Code */
            int zip = int.Parse(zipCode);
            WhenUserEntersZIPCode(zip);
            WhenUserClicksButton("Next");

            /* LOB */
            WhenUserSelectsLOBAs(lobName);



        }

        [Given(@"user starts a new quote with (.*), (.*), (.*), (.*), (.*)")]
        public void GivenUserStartsANewQuoteWith(string industry, int employeeCount, string location, int zipCode, string lobName)
        {
            GivenUserLandsOnBiBerkHomepage();
            WhenUserClicksGetAQuote();

            /* Industry */
            WhenUserEntersValueForAutoCompleteInputField(industry, "What's your industry?");
            WhenUserSelectsAutoCompleteOption(industry);
            WhenUserClicksButton("Let's Go!");

            /* Employees */
            if (employeeCount == 0)
            {
                WhenUserSelectsTileFor("No, just the owner(s)");
                WhenUserClicksButton("Next");
            }
            else
            {
                WhenUserSelectsTileFor("Yes, I have employees");
                WhenUserClicksButton("Next");
                WhenUserEntersEmployeeCountOf(employeeCount);
                WhenUserClicksButton("Next");
            }

            /* Location */
            WhenUserSelectsTileFor(location);
            WhenUserClicksButton("Next");

            /* ZIP Code */
            WhenUserEntersZIPCode(zipCode);
            WhenUserClicksButton("Next");

            /* LOB */
            WhenUserSelectsLOBAs(lobName);
        }




        [When(@"user clicks Get a Quote")]
        public void WhenUserClicksGetAQuote()
        {
            UserActions.FindElementWaitUntilClickable(By.XPath("(//a[contains(@class, 'btn-large')][contains(@href, 'get-a-quote')])[1]")).Click();
        }



        [When(@"user clicks (.*) button")]
        public void WhenUserClicksButton(string buttonText)
        {
            Button button = new Button(buttonText);
            button.Click();
        }

        [Then(@"URL contains (.*)")]
        public void ThenURLContains(string urlContains)
        {
            NUnitAssert.That(() => UserActions.GetCurrentURL(), Does.Contain(urlContains).After(20).Seconds.PollEvery(250).MilliSeconds);
        }

        [When(@"user enters (.*) for AutoComplete input field (.*)")]
        public void WhenUserEntersValueForAutoCompleteInputField(string value, string displayText)
        {
            AutoCompleteInput autoInput = new AutoCompleteInput(displayText);
            autoInput.EnterInput(value);
        }


        [Then(@"AutoComplete input field displays following options")]
        public void ThenAutoCompleteInputFieldDisplaysFollowingOptions(Table table)
        {
            foreach (var row in table.Rows)
            {
                string optionText = row["Option Text"];

                NUnitAssert.That(() => AutoCompleteInput.OptionIsPresent(optionText), Is.EqualTo(true).After(5).Seconds.PollEvery(250).MilliSeconds);

            }
        }

        [When(@"user selects AutoComplete option (.*)")]
        public void WhenUserSelectsAutoCompleteOption(string optionText)
        {
            AutoCompleteInput.SelectOption(optionText);
        }


        [When(@"user enters following values")]
        public void WhenUserEntersFollowingValues(Table table)
        {
            foreach (var row in table.Rows)
            {
                string displayText = row["Display Text"];
                string fieldType = row["Field Type"];
                string value = row["Value"];

                switch(fieldType.ToLower())
                {
                    case "autocomplete":
                        AutoCompleteInput autoInput = new AutoCompleteInput(displayText);
                        autoInput.SetValue(value);
                        break;
                    case "input":
                        InputField inputField = new InputField(displayText);
                        inputField.SetValue(value);
                        break;
                    case "pl-input":
                        PL_InputField plInput = new PL_InputField(displayText);
                        plInput.EnterInput(value);
                        break;
                    case "pl-singleselect":
                        PL_SingleSelect plSelect = new PL_SingleSelect(displayText);
                        plSelect.SelectOption(value);
                        break;
                    case "pl-multiselect":
                        PL_MultiSelect multiSelect = new PL_MultiSelect(displayText);
                        multiSelect.SelectOption(value);
                        break;
                    default:
                        Log.Warn("Unexpected FieldType.");
                        break;

                }

            }
        }

        [Then(@"the following fields have values")]
        public void ThenTheFollowingFieldsHaveValues(Table table)
        {

            foreach (var row in table.Rows)
            {
                string displayText = row["Display Text"];
                string fieldType = row["Field Type"];
                string value = row["Value"];

                string displayedValue = "";

                switch(fieldType.ToLower())
                {
                    case "autocomplete":
                        AutoCompleteInput autoInput = new AutoCompleteInput(displayText);
                        displayedValue = autoInput.GetValue();
                        break;
                    case "input":
                        InputField inputField = new InputField(displayText);
                        displayedValue = inputField.GetValue();
                        break;
                    case "pl-input":
                        PL_InputField plInput = new PL_InputField(displayText);
                        displayedValue = plInput.GetValue();
                        break;
                    case "pl-singleselect":
                        PL_SingleSelect plSelect = new PL_SingleSelect(displayText);
                        displayedValue = plSelect.GetCurrentSelection();
                        break;
                    default:
                        NUnitAssert.Fail("Unexpected Fieldtype");
                        break;
                }

                if (value.ToLower() == "any")
                {
                    HitachiAssert.IsTrue(displayedValue.Length > 0);
                }
                else
                {
                    HitachiAssert.AreEqual(value, displayedValue);
                }

            }
        }


        [Then(@"TileSet (.*) contains the following tiles")]
        public void ThenTileSetContainsTheFollowingTiles(string questionText, Table table)
        {
            TilesFieldset tilesSet = new TilesFieldset(questionText);

            foreach (var row in table.Rows)
            {
                string tileText = row["Tile Text"];

                NUnitAssert.That(() => tilesSet.TileIsPresent(tileText), Is.EqualTo(true).After(5).Seconds.PollEvery(250).MilliSeconds);

            }

        }

        [When(@"user selects tile for (.*)")]
        public void WhenUserSelectsTileFor(string tileText)
        {
            MadlibsTile mltile = new MadlibsTile(tileText);
            mltile.Click();
        }

        [Then(@"tile (.*) is selected")]
        public void ThenTileIsSelected(string tileText)
        {
            MadlibsTile mltile = new MadlibsTile(tileText);

            NUnitAssert.That(() => mltile.IsSelected(), Is.EqualTo(true).After(5).Seconds.PollEvery(250).MilliSeconds);
        }


        [When(@"user enters employee count of (.*)")]
        public void WhenUserEntersEmployeeCountOf(int employeeCount)
        {
            string inputXPath = "//input[@name='empCount']";
            IWebElement inputField = UserActions.FindElementWaitUntilClickable(By.XPath(inputXPath));
            inputField.Click();
            inputField.SendKeys(Keys.Control + "a");
            inputField.SendKeys(Keys.Delete);
            inputField.SendKeys(employeeCount.ToString());
        }

        [When(@"user enters ZIP code (.*)")]
        public void WhenUserEntersZIPCode(int zipCode)
        {
            string inputXPath = "//input[@name='zipCode']";
            IWebElement inputField = UserActions.FindElementWaitUntilClickable(By.XPath(inputXPath));
            inputField.Click();
            inputField.SendKeys(Keys.Control + "a");
            inputField.SendKeys(Keys.Delete);
            inputField.SendKeys(zipCode.ToString());
        }

        [Then(@"the following LOBs are available")]
        public void ThenTheFollowingLOBsAreAvailable(Table table)
        {
            foreach (var row in table.Rows)
            {
                string lobName = row["LOB Name"];

                LOB_Button lobButton = new LOB_Button(lobName);

                NUnitAssert.That(() => lobButton.IsEnabled(), Is.EqualTo(true), "LOB button not available for: " + lobName);

            }
        }

        [When(@"user selects LOB as (.*)")]
        public void WhenUserSelectsLOBAs(string lobName)
        {
            LOB_Button lobButton = new LOB_Button(lobName);
            NUnitAssert.That(() => lobButton.Click(), Is.EqualTo(true), "LOB button not available for: " + lobName);
        }







    }
}
