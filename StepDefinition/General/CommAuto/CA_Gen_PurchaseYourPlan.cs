using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using TechTalk.SpecFlow;
using HitachiQA.Driver;
using BiBerkLOB.StepDefinition.General.GenAutomation;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_PurchaseYourPlan
    {
        private readonly CAPurchasePageAutomation _automation;
        
        public CA_Gen_PurchaseYourPlan(CAPurchasePageAutomationFactory factory)
        {
            _automation = factory.CreateAutomation();
        }

        [Then(@"user goes to purchase a plan using the following information:")]
        public void ThenGoesToPurchase(Table table)
        {
            CA_PurchaseYourPlanPage.LoadingRequirements.Assert();

            //verifies URL is still on the correct environment
            General_SiteWide.AssertEnvironmentURL();

            _automation.VerifyPolicyDate();
            
            foreach (TableRow rowy in table.Rows)
            {
                var countOfColumns = rowy.Count;
                var listOfKeys = rowy.Keys;
                var orderedListOfKeys = listOfKeys.ToList();
                for (int i = 0; i < countOfColumns; i++)
                {
                    //get the Value of the Table header AND value
                    var valueOfKey = orderedListOfKeys[i];
                    var valueOfColumn = rowy[i];

                    HandleTableValue(valueOfKey, valueOfColumn);
                }
            }

            _automation.VerifyCardFormExtras();
            _automation.AgreeToTerms();
        }

        [Then(@"user clicks purchase")]
        public void ThenClicksPurchase()
        {
            _automation.ClickContinue();
        }

        private void HandleTableValue(string valueOfKey, string tableValue)
        {
            switch (valueOfKey)
            {
                case "Payment Plan":
                    _automation.VerifyPlanOptions();
                    HandlePaymentPlan(tableValue);
                    break;
                case "Card Type":
                    //Verify Payment Information
                    _automation.FillOutCreditCardInfo(Enum.Parse<TestCreditCards>(tableValue));
                    break;
                case "Autopay":
                    if (tableValue.Equals("Required")){
                        _automation.VerifyAutopayRequired();
                    }
                    else if (tableValue.Equals("Optional Choose Off"))//autopay optional, not chosen
                    {
                        _automation.VerifyAutopayOptional();
                        _automation.SelectAutopayOption(false);
                    }
                    else if (tableValue.Equals("Optional Choose On"))//autopay optional, chosen
                    {
                        _automation.VerifyAutopayOptional();
                        _automation.SelectAutopayOption(true);
                    }
                    break;
                default:
                    break;
            }
        }

        private void HandlePaymentPlan(string tableValue)
        {
            switch (tableValue)
            {
                case "12 Monthly":
                    _automation.SelectMonthlyPayment();
                    _automation.CheckPaymentsComparisonMath(PaymentSchedule.MONTHLY);
                    return;
                case "Yearly":
                    _automation.SelectYearlyPayment();
                    _automation.CheckPaymentsComparisonMath(PaymentSchedule.YEARLY);
                    return;
                default:
                    throw new ArgumentException($"'{tableValue}' is not a valid payment plan");
            }
        }
    }
}