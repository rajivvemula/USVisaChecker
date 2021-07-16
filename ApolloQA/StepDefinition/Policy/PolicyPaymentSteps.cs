using ApolloQA.Pages;
using ApolloQA.Source.Helpers;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Policy
{
    [Binding]
    public class PolicyPaymentSteps
    {
        [When(@"user enters payment information via (.*)")]
        public void WhenUserEntersPaymentInformationViaCreditDebitCard(string paymentMethod)
        {
            switch (paymentMethod)
            {
                case "Credit/Debit Card":
                    Shared.GetButton(paymentMethod).Click();
                    Shared.GetInputField("Amount").setText("400");
                    Shared.GetInputField("Name on Card").setText("Test Sample");
                    Shared.GetInputField("Card Number").setText(Functions.getValidCreditCardNumber());
                    Shared.GetInputField("Exp. Date (MM/YY)").setText("10" + "30");
                    Shared.GetInputField("CVC").setText("123");

                    break;
                case "EFT":
                    Shared.GetButton(paymentMethod).Click();

                    Shared.GetInputField("Amount").setText("400");
                    Shared.GetInputField("Name on Account").setText("Automation Account " + Functions.GetRandomInteger());
                    Shared.GetInputField("Bank Routing Number").setText("12333322");
                    Shared.GetInputField("Account Number").setText("6654654123456");
                    Shared.GetInputField("Date").setText(DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"));
                    Shared.GetButton("Checking").Click();


                    break;
                case "Check":
                    Shared.GetButton(paymentMethod).Click();
                    Shared.GetInputField("Amount").setText("400");

                    Shared.GetInputField("Check Number").setText("13468");
                    Shared.GetInputField("Date").setText(DateTime.Now.ToString("MM/dd/yyyy"));
                    break;
                default:
                    throw Functions.handleFailure($"Payment Method: {paymentMethod} is not supported");
            }
        }
        
        [Then(@"User Clicks on Ellipsis and Selects Make A Payment")]
        public void ThenUserClicksOnEllipsisAndSelectsMakeAPayment()
        {
            Home.ellipsisButton.Click();
            Shared.GetButton("Make a Payment").Click();
        }
    }
}
