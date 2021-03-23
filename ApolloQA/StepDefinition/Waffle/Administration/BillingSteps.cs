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

        [When(@"user selects a valid quote to make a payment")]
        public void GivenUserSelectsAValidQuoteToMakeAPayment()
        {
            String ApplicationNumber = GetValidApplicationNumber();

            var QuoteNumberField = Pages.Shared.GetInputField("Quote Number");

            QuoteNumberField.setText(ApplicationNumber);

            var options = QuoteNumberField.GetMatdropdownOptionsText();
            QuoteNumberField.SelectMatDropdownOptionByIndex(options.Count()-1);

            //BUG 33878
            // QuoteNumberField.SelectMatDropdownOptionContainingText($"Quote {ApplicationNumber}");
            sharedSteps.WhenUserWaitsForSpinnerToLoad();

        }

        [Then(@"Named Insured field should be disabled and have valid value")]
        public void ThenNamedInsuredFieldShouldBeDisabledAndHaveValidValue()
        {
            var org = new Data.Entity.Organization((int)ratableObject["InsuredId"]);

            Pages.Shared.GetInputField("Named Insured").assertTextFieldTextEquals(org.Name);
        }

        [Then(@"Total Premium field should be disabled and have valid value")]
        public void ThenTotalPremiumFieldShouldBeDisabledAndHaveValidValue()
        {
            int premium = (int)ratableObject["Billing"]["Premium"];

            Pages.Shared.GetInputField("Total Premium").assertTextFieldTextEquals(premium.ToString("C"));
            Log.Debug("Premium: " + premium.ToString("C"));
        }


        [Then(@"Payment Plan can be updated successfully")]
        public void ThenPaymentPlanCanBeUpdatedSuccessfully()
        {
            //Used to check state of radio buttons
            var monthlyRadio = Pages.Shared.GetRadioButton("12 Monthly Payments");
            var fullRadio = Pages.Shared.GetRadioButton("Pay in Full");

            //Used to interact with radio buttons
            var monthlyButton = Pages.Shared.GetButton("12 Monthly Payments");
            var fullButton = Pages.Shared.GetButton("Pay in Full");



            if (monthlyRadio.IsRadioButtonSelected())
            {
                fullButton.Click();
            }
            else
            {
                monthlyButton.Click();
            }
            Pages.Shared.GetButton("Save").Click();
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

                        Pages.Shared.GetField(fieldName, fieldType).assertElementIsVisible();
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
        private Element GetField(string fieldName) => Pages.Shared.GetField(fieldName, fieldTypes[fieldName]);

        public String PaymentPlan;
        [When(@"user selects payment plan (.*)")]
        public void WhenUserSelectsPaymentPlan(string paymentPlan)
        {
            Pages.Shared.GetButton(PaymentPlan=paymentPlan);
        }

        [When(@"user enters payment information with (.*)")]
        public void WhenEntersPaymentInformationWith(string paymentMethod)
        {
            Decimal premium = (Decimal)ratableObject["Billing"]["Premium"];

            switch(paymentMethod)
            {
                case "Credit/Debit Card":
                    Pages.Shared.GetButton(paymentMethod).Click();
                    GetField("Amount").setText($"{(PaymentPlan == "Pay in Full" ? premium : Math.Round(premium / 12, 2))}");

                    GetField("Name on Card").setText("Automation Payer "+Functions.GetRandomInteger());
                    GetField("Card Number").setText(Functions.getValidCreditCardNumber());
                    GetField("Exp. Date (MM/YY)").setText("10"+"30");
                    GetField("CVC").setText("123");

                    break;
                case "EFT":
                    Pages.Shared.GetButton(paymentMethod).Click();
                    GetField("Amount").setText($"{(PaymentPlan == "Pay in Full" ? premium : Math.Round(premium / 12, 2))}");

                    GetField("Name on Account").setText("Automation Account " + Functions.GetRandomInteger());
                    GetField("Bank Routing Number").setText("12333322");
                    GetField("Account Number").setText("6654654123456");
                    GetField("Date").setText(DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"));
                    GetField("Checking").Click();


                    break;
                case "Check":
                    Pages.Shared.GetButton(paymentMethod).Click();
                    GetField("Amount").setText($"{(PaymentPlan == "Pay in Full" ? premium : Math.Round(premium / 12, 2))}");

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
            if (!Shared.GetToastContaining("Policy Issuance is complete for ratable object").assertElementIsVisible(20, true)) ;
            {
                Functions.refreshPage();

                var statusField = Shared.GetQuoteHeaderField("Status");
                Assert.AreEqual(statusField.GetElementText(), "Issued");
            }
        }



        public String GetValidApplicationNumber()
        {
            //Get all tether Ids that don't yet have a policy Number. this mean they are prior issued or broken
            var tetherCandidates = SQL.executeQuery("SELECT *  FROM [tether].[Tether] WHERE LineId = 7 and CurrentRatableObjectId>0 and PolicyNumber IS NULL order by Id desc ;");

            //gather the Ratable Object Ids on a list
            IEnumerable<int> ratableObjectCandidates = tetherCandidates.Select(row => (int)row["CurrentRatableObjectId"]);

            if (ratableObjectCandidates.Any())
            {
                //in cosmos DB, filter out any ratable object which is not Quoted and have no premium
                var ratableValidCandidates = Cosmos.GetQuery("RatableObject", @$" SELECT * 
                                                                    FROM c 
                                                                    WHERE c.Id in ( {string.Join(", ", ratableObjectCandidates)} ) 
                                                                    AND c.RatableObjectStatusValue= 'Quoted'
                                                                    AND c.Billing.Premium !=null
                                                                    AND c.Billing.Premium !=0
                                                                    ORDER BY c.Id DESC").Result;
            

                if(ratableValidCandidates.Count ==0)
                {
                   Functions.GetQuotedQuoteThroughAPI();
                   return GetValidApplicationNumber();
                }
                this.ratableObject = ratableValidCandidates[0];
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
