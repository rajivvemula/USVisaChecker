using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Waffle.Administration
{
    [Binding]
    public class BillingSteps
    {
        SharedSteps sharedSteps = new SharedSteps();

        dynamic ratableObject;
        private string QuotedInsured = "";
        private static Data.Entity.Quote theQuote = Functions.GetQuotedQuoteThroughAPI();
        private int premium = theQuote.GetCurrentRatableObject()["Billing"]["Premium"];
        private String QuotedQuote = theQuote.ApplicationNumber.ToString();

        [When(@"user selects a valid quote to make a payment")]
        public void GivenUserSelectsAValidQuoteToMakeAPayment()
        {
            var QuoteNumberField = Shared.GetInputField("Quote Number");
            QuoteNumberField.setText(QuotedQuote);
            var options = QuoteNumberField.GetMatdropdownOptionsText();
            QuotedInsured = theQuote.Organization.Name;
            while (options.Count() == 1 && options.ElementAt(0).Trim() == "No results found")
            {
                Log.Debug("broken-> " + QuotedQuote);
                Data.Entity.Quote aQuote = Functions.GetQuotedQuoteThroughAPI();
                String aQuotedQuote = aQuote.ApplicationNumber.ToString();
                QuoteNumberField.setText(aQuotedQuote);
                QuotedInsured = aQuote.Organization.Name;
            }
            QuoteNumberField.SelectMatDropdownOptionContainingText($"Quote {QuotedQuote}");
            sharedSteps.WhenUserWaitsForSpinnerToLoad();
        }

        [Then(@"Named Insured field should be disabled and have valid value")]
        public void ThenNamedInsuredFieldShouldBeDisabledAndHaveValidValue()
        {
            Shared.GetInputField("Named Insured").assertTextFieldTextEquals(QuotedInsured);
        }

        [Then(@"Total Premium field should be disabled and have valid value")]
        public void ThenTotalPremiumFieldShouldBeDisabledAndHaveValidValue()
        {
            Shared.GetInputField("Total Premium").assertTextFieldTextEquals(premium.ToString("C"));
            Log.Debug("Premium: " + premium.ToString("C"));
        }

        [Then(@"Payment Plan can be updated successfully")]
        public void ThenPaymentPlanCanBeUpdatedSuccessfully()
        {
            //Used to check state of radio buttons
            var monthlyRadio = Shared.GetRadioButton("12 Monthly Payments");
            var fullRadio = Shared.GetRadioButton("Pay in Full");

            //Used to interact with radio buttons
            var monthlyButton = Shared.GetButton("12 Monthly Payments");
            var fullButton = Shared.GetButton("Pay in Full");
            if (monthlyRadio.IsRadioButtonSelected())
            {
                fullButton.Click();
            }
            else
            {
                monthlyButton.Click();
            }
            Shared.GetButton("Save").Click();
            sharedSteps.WhenUserWaitsForSpinnerToLoad();
            sharedSteps.ThenToastWithAMessageIsVisible("Policy billing saved.");
        }

        [Then(@"Make Payment Method form is displayed correctly")]
        public void ThenMakePaymentMethodFormIsDisplayedCorrectly(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                var methodButton = Pages.Shared.GetButton(row["Method"]);
                methodButton.Click();

                foreach(var column in row)
                {
                    var fieldName = column.Value;
                    if(column.Key.Contains("field") && !string.IsNullOrWhiteSpace(fieldName))
                    {
                        var fieldType = fieldTypes[fieldName];

                        Shared.GetField(fieldName, fieldType).assertElementIsVisible();
                    }
                }
            }
        }

        public static Dictionary<string, string> fieldTypes = new Dictionary<string, string>()
        {
            {"Amount",              "input" },
            {"Name on Card",        "input" },
            {"Card Number",         "input" },
            {"Exp. Date (MM/YY)",   "input" },
            {"CVC",                 "input" },
            {"Name on Account",     "input" },
            {"Bank Routing Number", "input" },
            {"Account Number",      "input" },
            {"Checking",            "Button" },
            {"Saving",              "Button" },
            {"Check Number",        "input" },
            {"Date",                "input" },
        };

        private Element GetField(string fieldName) => Shared.GetField(fieldName, fieldTypes[fieldName]);

        public String PaymentPlan;
        [When(@"user selects payment plan (.*)")]
        public void WhenUserSelectsPaymentPlan(string paymentPlan)
        {
            Shared.GetButton(PaymentPlan=paymentPlan);
        }

        [When(@"user enters payment information with (.*)")]
        public void WhenEntersPaymentInformationWith(string paymentMethod)
        {
            switch(paymentMethod)
            {
                case "Credit/Debit Card":
                    Shared.GetButton(paymentMethod).Click();
                    GetField("Amount").setText($"{(PaymentPlan == "Pay in Full" ? premium : Math.Round((decimal)premium / 12, 2))}");
                    GetField("Name on Card").setText("Automation Payer "+Functions.GetRandomInteger());
                    GetField("Card Number").setText(Functions.getValidCreditCardNumber());
                    GetField("Exp. Date (MM/YY)").setText("10"+"30");
                    GetField("CVC").setText("123");
                    break;

                case "EFT":
                    Shared.GetButton(paymentMethod).Click();
                    GetField("Amount").setText($"{(PaymentPlan == "Pay in Full" ? premium : Math.Round((decimal)premium / 12, 2))}");
                    GetField("Name on Account").setText("Automation Account " + Functions.GetRandomInteger());
                    GetField("Bank Routing Number").setText("12333322");
                    GetField("Account Number").setText("6654654123456");
                    GetField("Date").setText(DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"));
                    GetField("Checking").Click();
                    break;

                case "Check":
                    Shared.GetButton(paymentMethod).Click();
                    GetField("Amount").setText($"{(PaymentPlan == "Pay in Full" ? premium : Math.Round((decimal)premium / 12, 2))}");
                    GetField("Check Number").setText("13468");
                    GetField("Date").setText(DateTime.Now.ToString("MM/dd/yyyy"));
                    break;

                default:
                    throw Functions.handleFailure($"Payment Method: {paymentMethod} is not supported");
            }
        }

        [Then(@"user waits for Policy Issuance")]
        public void WhenUserWaitsForPolicyIssuance()
        {
            if (!Shared.GetToastContaining("Policy Issuance is complete for ratable object").assertElementIsVisible(20, true))
            {
                Functions.refreshPage();

                var statusField = Shared.GetQuoteHeaderField("Status");
                Assert.AreEqual(statusField.GetElementText(), "Issued");
            }
        }

        public String GetValidApplicationNumber()
        {
            //Get all tether Ids that don't yet have a policy Number. this mean they are prior issued or broken
            // This query needs to be updated to include "Risks.Vehicle.Vin IS NOT NULL" - unable to make payment where VIN == NULL
            var tetherCandidates = SQL.executeQuery("SELECT *  FROM [tether].[Tether] WHERE LineId = 7 and CurrentRatableObjectId>0 and PolicyNumber IS NULL order by Id desc;");

            //gather the Ratable Object Ids on a list
            IEnumerable<int> ratableObjectCandidates = tetherCandidates.Select(row => (int)row["CurrentRatableObjectId"]);

            if (ratableObjectCandidates.Any())
            {
                //in cosmos DB, filter out any ratable object which is not Quoted and have no premium
                var ratableValidCandidates = Cosmos.GetQuery("RatableObject", @$" SELECT * 
                                                                    FROM c 
                                                                    WHERE c.Id in ( {string.Join(", ", ratableObjectCandidates)} ) 
                                                                    AND c.RatableObjectStatusValue= 'Quoted'
                                                                    AND c.RatableObjectStatusKey= '3000'
                                                                    AND c.Billing.Premium !=null
                                                                    AND c.Billing.Premium !=0
                                                                    ORDER BY c.Id DESC");
                if(!ratableValidCandidates.Any())
                {
                   Functions.GetQuotedQuoteThroughAPI();
                   return GetValidApplicationNumber();
                }
                this.ratableObject = ratableValidCandidates.ElementAt(0);
                var quote = new Data.Entity.Quote(this.ratableObject["ApplicationId"].ToObject<int>());
                var vehicles = quote.GetVehicles();
                foreach(var vehicle in vehicles)
                {
                    if(string.IsNullOrWhiteSpace(vehicle.VinNumber))
                    {
                        vehicle.VinNumber = Functions.GetRandomVIN();
                    }
                }
                
            }
            else
            {
                Functions.GetQuotedQuoteThroughAPI();
                return GetValidApplicationNumber();
            }
            //get the first valid candidate and find it's tether object.
            var tether = tetherCandidates.Find(tether => (int)tether["CurrentRatableObjectId"] == (int)this.ratableObject.Id);

            //finally we get the Application Number of this tether object to return it
            return tether["ApplicationNumber"];
        }
    }
}
