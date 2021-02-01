using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using EntityQuote = ApolloQA.Data.Entity.Quote;
using ApolloQA.Data.Entity;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_Section_BusinessInformationSteps
    {
        public static EntityQuote Quote;
        public List<Address> addresses;

        public Quote_Section_BusinessInformationSteps()
        {
            Quote = Quote_GeneralSteps.Quote;
        }

        [When(@"User Navigates to Business Information Section")]
        public void WhenUserNavigatesToBusinessInfomrationSection()
        {
            Pages.Shared.GetLeftSideTab("Business Information").Click();
        }

        [When(@"user saves current Business Addresses")]
        public void WhenUserSavesCurrentBusinessAddresses()
        {
            this.addresses = Quote.Organization.Addresses;
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
            int? insurranceScore = Quote.Organization.InsuranceScore;
            String actual = Pages.Quote_BusinessInformation_Page.Score.GetElementText();

            String expected = insurranceScore == null ? "Score:" : $"Score: {insurranceScore}";
            Assert.AreEqual(expected, actual.Substring(0, actual.IndexOf("\nLast Checked")-1));
        }

        [Then(@"Dropdown should contain the previously entered address")]
        public void ThenDropdownShouldContainThePreviouslyEnteredAddress()
        {
            var currentAddresses = Quote.Organization.Addresses;
            var oldAddressIDs = this.addresses.Select(item => item.Id).ToList();
            var actualNewAddresses = currentAddresses.FindAll(it =>  !oldAddressIDs.Contains(it.Id));
            if(actualNewAddresses.Count >1)
            {
                Functions.handleFailure(new Exception($"More than one new address was added to the organization\n {String.Join("", actualNewAddresses.Select(it => $"\n{it.ToString()}"))}"));
            }
            if (actualNewAddresses.Count < 1)
            {
                Functions.handleFailure(new Exception($"No new addresses were added to the organization current Addresses: {String.Join("", currentAddresses.Select(it => $"\n{it.ToString()}"))}"));
            }

            var currentAddressesString = currentAddresses.Select(it => it.ToString()).ToList();

            currentAddressesString.Add("add Add Addressadd");
            Shared.GetDropdownField("Physical Address").AssertMatDropdownOptionsEqual(currentAddressesString);
        }

        public static Dictionary<String, String> Display_PropsNames = new Dictionary<String, String>()
        {

            { "Business Name",              "Name" },
            { "DBA",                        "DBA"},
            { "Organization Type",          "TypeName"},
            { "Tax ID Type",                "TaxIdType" },
            { "Tax ID No" ,                 "TaxId"},
            { "Description of Operations",  "Description"},
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
