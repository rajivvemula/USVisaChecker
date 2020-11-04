using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages.Quote;
using ApolloQA.Source.Driver;
using EntityQuote = ApolloQA.Data.Entity.Quote;
using System.Collections.Generic;

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
        [When(@"User Navigates to Business Infomration Section")]
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
