using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages.Quote;
using ApolloQA.Source.Driver;
using EntityQuote = ApolloQA.Data.Entity.Quote;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_BusinessInformation
    {
        public static EntityQuote Quote;

        [When(@"User Navigates to Quote (.*)")]
        public void GivenUserNavigatesToQuote(string quote)
        {
            if (quote?.ToLower() == "recent" || quote?.ToLower() == "latest")
            {
                Quote = EntityQuote.GetLatestQuote();
            }
            else
            {
                Quote = new EntityQuote(int.Parse(quote));
            }
            Quote_Page.Navigate(Quote.Id);
        }
        [When(@"User Navigates to Business Information Section")]
        public void WhenUserNavigatesToBusinessInfomrationSection()
        {
            Pages.Shared.GetSideTab("Business Information").Click();
        }

        



        [Then(@"The following Organization Fields should be displayed")]
        public void ThenTheFollowingOrganizationFieldsShouldBeDisplayed(Table table)
        {
            var organization = Quote.Organization;
            foreach (var row in table.Rows)
            {
                var displayName = row["Display Name"];
                var fieldType = row["Field Type"];
                var propName = Display_PropsNames[displayName];
                var expectedValue = organization[propName];

                String actualValue;
                if (fieldType == "Input")
                {
                    var field = Pages.Shared.GetInputField(displayName);
                    actualValue = field.getTextFieldText();

                }
                else
                {
                    var field = Pages.Shared.GetDropdownField(displayName);
                    actualValue = field.GetInnerText();

                }
                Log.Info($"Display Name: {displayName} Expected: {expectedValue} Actual: {actualValue}");

                Assert.AreEqual(actualValue!, expectedValue! is string ? expectedValue! : expectedValue?.ToString());


            }
            
        }

        [Then(@"Physical Address field should be blank")]
        public void ThenPhysicalAddressFieldShouldBeBlank()
        {
            Assert.AreEqual("",Pages.Shared.GetDropdownField("Physical Address").GetInnerText());
        }

        [Then(@"National Credit Score should be displayed")]
        public void ThenNationalCreditScoreShouldBeDisplayed()
        {
            int? insurranceScore = Quote.Organization.InsurranceScore;
            String actual = Pages.Quote.Quote_BusinessInformation.Score.GetElementText();

            String expected = insurranceScore == null ? "Score:" : $"Score: {insurranceScore}";
            Assert.AreEqual(expected, actual.Substring(0, actual.IndexOf("\nLast Checked")-1));
        }

        [Then(@"Dropdown should contain the previously entered address")]
        public void ThenDropdownShouldContainThePreviouslyEnteredAddress()
        {
            IDictionary<String, String> fieldValues = new Dictionary<String, String>();


            foreach(var row in SharedSteps.previouslyEnteredAddress.Rows)
            {
                fieldValues.Add(row["Field Display Name"], row["Field Value"]);
            }
            StringBuilder address = new StringBuilder();
            address.Append(fieldValues["Street Address Line 1"])
                   .Append(fieldValues["Street Address Line 2"])
                   .Append(", ")
                   .Append(fieldValues["City"])
                   .Append(", ")
                   .Append(fieldValues["State / Province / Region"])
                   .Append(", ")
                   .Append(fieldValues["Zip / Postal Code"])
                   ;

            Pages.Shared.GetDropdownField("Physical Address").AssertMatDropdownOptionsContain(address.ToString());
        }

        
        public static Dictionary<String, String> Display_PropsNames = new Dictionary<String, String>()
        {

            { "Business Name",              "Name" },
            { "DBA",                        "DBA"},
            { "Organization Type",          "TypeName"},
            { "Tax ID Type",                "TaxIdType" },
            { "Tax ID No" ,                 "TaxId"},
            { "Description of Operations",  "DescriptionOfOperations"},
            { "Business Phone No" ,         "BusinessPhoneNumber"},
            { "Business Email Address",     "BusinessEmailAddress" },
            { "Business Website",           "BusinessWebsite" },
            { "Keyword",                    "KeywordName" },
            { "Class Taxonomy",             "ClassTaxonomyName" },
            { "Year Business Started",      "YearBusinessStarted" },
            { "Year Ownership Started",     "YearOwnershipStarted" } ,

        };


    }
}
