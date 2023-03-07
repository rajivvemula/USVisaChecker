using ApolloTests.Pages;
using HitachiQA.Source.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace ApolloTests.StepDefinitions
{
    [Binding]
    public class QuoteStepDefinitions
    {
        private QuotePage QuotePage;
        private IConfiguration Config;
        private SharedData SharedData;
        public QuoteStepDefinitions(QuotePage QP, IConfiguration config, SharedData SharedData)
        {
            this.QuotePage = QP;
            this.Config = config;
            this.SharedData = SharedData;
        }
        [Given(@"user is successfully logged into biberk")]
        public void GivenUserIsSuccessfullyLoggedIntoBiberk()
        {
            string Username = Config.GetVariable("API_USERNAME");
            string Password = Config.GetVariable("API_PASSWORD");
            QuotePage.UsernameTextField.SetFieldValue(Username);

            //Next button
            QuotePage.SubmitButton.Click();

            QuotePage.PasswordTextField.SetFieldValue(Password);

            //Sign in button
            QuotePage.SubmitButton.Click();

            //Yes (stay signed in)
            if (QuotePage.SubmitButton.GetAttribute("value") == "Sign in")
            {
                throw new Exception($"Sign In Failed, UI Message: {QuotePage.Element("//*[@id='passwordError']").GetElementText()}");
            }
            QuotePage.SubmitButton.Click();
        }
        [When(@"user navigates to '([^']*)' Page")]
        public void WhenUserNavigatesToPage(string pageName)
        {
            this.QuotePage.GetTopNavBarElement(pageName).Click();
            if(!this.QuotePage.GetCurrentURLPath().StartsWith(pageName.ToLower()))
            {
                this.QuotePage.GetTopNavBarElement(pageName).Click();

            }
        }


        [When(@"user clicks '([^']*)' Button")]
        public void WhenUserClicksButton(string displayName)
        {
            this.QuotePage.GetElementByText(displayName).Click();
        }

        [When(@"user enters the following field values on '([^']*)'")]
        public void WhenUserEntersTheFollowingFieldValuesOn(string parentArea, Table table)
        {
            foreach (var row in table.Rows)
            {
                var fieldName = row["FieldName"];
                var value = row["Value"];

                this.QuotePage.GetField(fieldName).SetFieldValue(value);
                SharedData.SetValue(parentArea, fieldName, value);
            }
        }

        [When(@"user fills out UI form with an address from '([^']*)'")]
        public void WhenUserFillsOutUIFormWithAnAddressFrom(string stateCode)
        {
            var streetField = this.QuotePage.GetField("Street Address Line 1");
            var street2Field = this.QuotePage.GetField("Street Address Line 2");
            var cityField = this.QuotePage.GetField("City");
            var stateField = this.QuotePage.GetField("State / Region");
            var zipField = this.QuotePage.GetField("Zip / Postal Code");

            String jsonString = new StreamReader($"Data/TestData/objects/OrgCreateAddress/{stateCode}.json").ReadToEnd();
            var addressObj = JObject.Parse(jsonString);

            streetField.SetFieldValue(addressObj.Value<string>("line1")??throw new Exception());
            street2Field.SetFieldValue(addressObj.Value<string>("line2") ?? throw new Exception());
            cityField.SetFieldValue(addressObj.Value<string>("majorMunicipality") ?? throw new Exception());
            stateField.SetFieldValue(stateCode);
            zipField.SetFieldValue(addressObj.Value<string>("postalCode") ?? throw new Exception());

            this.QuotePage.GetElementByText("//mat-dialog-container", "Save").Click();

        }

        [When(@"user navigates to '([^']*)' section")]
        public void WhenUserNavigatesToSection(string sectionName)
        {
            this.QuotePage.GetNavSection(sectionName).Click();
            this.QuotePage.GetElementByText("Continue anyway").TryClick(1);
        }
        [Then(@"user asserts the following '([^']*)' fields")]
        public void ThenUserAssertsTheFollowingFields(string parentArea, Table table)
        {
            foreach (var row in table.Rows)
            {
                var fieldName = row["FieldName"];
                var expectedValue = SharedData.GetValue<string>(parentArea, fieldName);

                //string actual = this.QuotePage.GetField(fieldName).GetFieldValue();
                //actual.Should().Be(expectedValue, $"Entered field from {parentArea} -> {fieldName}={actual} did not equal expected: {expectedValue} ");

            }
        }
        [Then(@"user asserts the following '([^']*)' fields")]
        public void ThenUserAssertsTheFollowingFields(string parentArea)
        {
           
            foreach (var entry in this.SharedData[parentArea])
            {
                var fieldName = entry.Key;
                var expectedValue = (string)entry.Value;

                if(fieldName =="Tax ID No")
                {
                    this.QuotePage.GetElementByText("visibility_off").Click();
                }
                if(fieldName.Contains("No"))
                {
                    var numbers = Regex.Replace(expectedValue, "[^0-9]", "");
                    //tax ID
                    if(numbers.Count()==9)
                    {
                        expectedValue = $"{numbers.Substring(0, 3)}-{numbers.Substring(3, 2)}-{numbers.Substring(5, 4)}";

                    }
                    //Phone Number
                    else if(numbers.Count()==10)
                    {
                        expectedValue = $"{numbers.Substring(0, 3)}-{numbers.Substring(3, 3)}-{numbers.Substring(6, 4)}";

                    }
                    else
                    {
                        throw new Exception(numbers.Count() + " digit count numbers formatting not implemented");
                    }

                }
                string actual = this.QuotePage.GetField(fieldName).GetFieldValue();
                actual.Should().Be(expectedValue, $"Entered field from {parentArea} -> {fieldName}={actual} did not equal expected: {expectedValue} ");
            }
        }


    }
}
