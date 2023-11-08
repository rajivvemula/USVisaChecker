using System;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.StepDefinition.General;
using HitachiQA.Driver;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace BiBerkLOB
{
    [Binding]
    public class PL_Gen_YourQuote
    {
        private readonly PLSummaryObject _plSummaryObject;
        private Dictionary<string, QuoteValueObj> DeductiblesAndCoverages = new Dictionary<string, QuoteValueObj>();

        public PL_Gen_YourQuote(PLSummaryObject plSummaryObject)
        {
            _plSummaryObject = plSummaryObject;
        }

        [Then(@"user selects their (.*) - (.*) Quote")]
        public void ThenUserSelectsTheirQuote(string yearlyMonthly, string standardPlus)
        {
            //Quick easy for selecting yearly/monthly and a standard/plus policy
            PL_Quote_Summary.YourQuotePageTitle.AssertElementIsVisible();
            //clicking the Monthly/Yearly toggle depending on what is selected.
            YearlyToggle(yearlyMonthly);
            //Selecting the Standard or Plus policy depending on what is selected.
            AutomationHelper.LegacyWaitForLoading();
            StandardOrPlus(standardPlus);
        }

        [Then(@"user adjusts their (.*) - (.*) quote with these values:")]
        public void ThenUserAdjustsTheirQuoteWithTheseValues(string yearlyMonthly, string standardPlus, Table table)
        {
            DeductiblesAndCoverages.Clear();
            var row = table.Rows[0];
            PL_Quote_Summary.YourQuotePageTitle.AssertElementIsVisible();
            if (yearlyMonthly != "")
            {
                YearlyToggle(yearlyMonthly);
                AutomationHelper.LegacyWaitForLoading();
            }
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                //checks to make sure value entered is different than value displayed.  Then opens the customization menu.
                if (!string.IsNullOrEmpty(theAnswer))
                {
                    HandleTableValue(theQuestion, theAnswer);
                }
            }
        }

        [Then(@"user verifies the following defualt PL quote values: (.*)")]
        public void ThenUserValidatesTheDefaultValueOfEachOfTheFollowingPLCoverageLimits(string valueString)
        {
            var valuesToValidate = CreateListOfValues(valueString);

            ValidateDefaultQuoteValues(valuesToValidate);
        }

        [Then(@"user verifies that the following deductible or coverage values are displayed on the Quote page:")]
        public void ThenUserVerifiesThatTheFollowingDeductibleOrCoverageValuesAreDisplayedOnTheQuotePage(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var deductibleOrCoverage = rowy["DeductibleOrCoverage"];
                var value = rowy["Value"];

                ValidateQuoteValue(deductibleOrCoverage, value);
            }
        }

        void HandleTableValue(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Deductible PO":
                    DeductiblesAndCoverages.Add(theQuestion, new QuoteValueObj(PL_Quote_Summary.DeductiblePerOccAmt, $"{theAnswer}"));
                    if (!theAnswer.Equals(PL_Quote_Summary.DeductiblePerOccAmt.GetInnerText()))
                    {
                        PL_Quote_Summary.DeductiblePerOccEdit.Click();
                        PL_Quote_Summary.CustomizeTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductibleTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductPerOccurTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductPerOccurHelper.Click();
                        PL_Quote_Summary.CstmDeductPerOccurHelperText.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductPerOccurHelperX.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductPerOccurDDa.Click();
                        PL_Quote_Summary.CstmDeductPerOccurDDb(theAnswer).Click();
                        Customizeclose();
                    }
                    break;
                case "Limits PO":
                    DeductiblesAndCoverages.Add(theQuestion, new QuoteValueObj(PL_Quote_Summary.LimitsPerOccurrenceAmt, $"{theAnswer}"));
                    if (!theAnswer.Equals(PL_Quote_Summary.LimitsPerOccurrenceAmt.GetInnerText()))
                    {
                        PL_Quote_Summary.LimitsPerOccurrenceEdit.Click();
                        PL_Quote_Summary.CustomizeTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimits.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimitsPerOccurTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimitsPerOccurHelper.Click();
                        PL_Quote_Summary.CstmLimitsPerOccurHelperX.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimitsPerOccurHelperText.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimitsPerOccurDDa.Click();
                        PL_Quote_Summary.CstmLimitsPerOccurDDb(theAnswer).Click();
                        Customizeclose();
                    }
                    break;
                case "Limits Agg":
                    DeductiblesAndCoverages.Add(theQuestion, new QuoteValueObj(PL_Quote_Summary.LimitsAggregateAmt, $"{theAnswer}"));
                    if (!theAnswer.Equals(PL_Quote_Summary.LimitsAggregateAmt.GetInnerText()))
                    {
                        PL_Quote_Summary.LimitsAggregateEdit.Click();
                        PL_Quote_Summary.CustomizeTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmAggregateTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmAggregateHelper.Click();
                        PL_Quote_Summary.CstmAggregateHelperText.AssertElementIsVisible();
                        PL_Quote_Summary.CstmAggregateHelperX.AssertElementIsVisible();
                        PL_Quote_Summary.CstmAggregateDDa.Click();
                        PL_Quote_Summary.CstmAggregateDDb(theAnswer).Click();
                        Customizeclose();
                    }
                    break;
                case "Plus Deductible PO":
                    DeductiblesAndCoverages.Add(theQuestion, new QuoteValueObj(PL_Quote_Summary.PlusDeductPerOccurAmt, $"{theAnswer}"));
                    if (!theAnswer.Equals(PL_Quote_Summary.PlusDeductPerOccurAmt.GetInnerText()))
                    {
                        PL_Quote_Summary.DeductiblePerOccEdit.Click();
                        PL_Quote_Summary.CustomizeTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductibleTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductPerOccurTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductPerOccurHelper.Click();
                        PL_Quote_Summary.CstmDeductPerOccurHelperText.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductPerOccurHelperX.AssertElementIsVisible();
                        PL_Quote_Summary.CstmDeductPerOccurDDa.Click();
                        PL_Quote_Summary.CstmDeductPerOccurDDb(theAnswer).Click();
                        Customizeclose();
                    }
                    break;
                case "Plus Limits PO":
                    DeductiblesAndCoverages.Add(theQuestion, new QuoteValueObj(PL_Quote_Summary.PlusLimitsPerOccurAmt, $"{theAnswer}"));
                    if (!theAnswer.Equals(PL_Quote_Summary.PlusLimitsPerOccurAmt.GetInnerText()))
                    {
                        PL_Quote_Summary.LimitsPerOccurrenceEdit.Click();
                        PL_Quote_Summary.CustomizeTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimits.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimitsPerOccurTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimitsPerOccurHelper.Click();
                        PL_Quote_Summary.CstmLimitsPerOccurHelperX.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimitsPerOccurHelperText.AssertElementIsVisible();
                        PL_Quote_Summary.CstmLimitsPerOccurDDa.Click();
                        PL_Quote_Summary.CstmLimitsPerOccurDDb(theAnswer).Click();
                        Customizeclose();
                    }
                    break;
                case "Plus Limits Agg":
                    DeductiblesAndCoverages.Add(theQuestion, new QuoteValueObj(PL_Quote_Summary.PlusLimitsAggregateAmt, $"{theAnswer}"));
                    if (!theAnswer.Equals(PL_Quote_Summary.PlusLimitsAggregateAmt.GetInnerText()))
                    {
                        PL_Quote_Summary.LimitsAggregateEdit.Click();
                        PL_Quote_Summary.CustomizeTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmAggregateTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmAggregateHelper.Click();
                        PL_Quote_Summary.CstmAggregateHelperText.AssertElementIsVisible();
                        PL_Quote_Summary.CstmAggregateHelperX.AssertElementIsVisible();
                        PL_Quote_Summary.CstmAggregateDDa.Click();
                        PL_Quote_Summary.CstmAggregateDDb(theAnswer).Click();
                        Customizeclose();
                    }
                    break;
                case "Plus CL Agg":
                    DeductiblesAndCoverages.Add(theQuestion, new QuoteValueObj(PL_Quote_Summary.PlusCyberLiabAmt, $"{theAnswer}"));
                    if (!theAnswer.Equals(PL_Quote_Summary.PlusCyberLiabAmt.GetInnerText()))
                    {
                        PL_Quote_Summary.PlusCyberLiabEdit.Click();
                        PL_Quote_Summary.CustomizeTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmCybLiabHelper.AssertElementIsVisible();
                        PL_Quote_Summary.CstmCybLiabHelper.Click();
                        PL_Quote_Summary.CstmCybLiabHelperText.AssertElementIsVisible();
                        PL_Quote_Summary.CstmCybLiabHelperX.AssertElementIsVisible();
                        PL_Quote_Summary.CstmCybLiabDDa.Click();
                        PL_Quote_Summary.CstmCybLiabDDb(theAnswer).Click();
                        Customizeclose();
                    }
                    break;
                case "Plus PL Agg":
                    DeductiblesAndCoverages.Add(theQuestion, new QuoteValueObj(PL_Quote_Summary.PlusLimitsAggregateAmt, $"{theAnswer}"));
                    if (!theAnswer.Equals(PL_Quote_Summary.PlusPollAggregateAmt.GetInnerText()))
                    {
                        PL_Quote_Summary.PlusPollAggregateEdit.Click();
                        PL_Quote_Summary.CustomizeTitle.AssertElementIsVisible();
                        PL_Quote_Summary.CstmPollLiabHelper.AssertElementIsVisible();
                        PL_Quote_Summary.CstmPollLiabHelper.Click();
                        PL_Quote_Summary.CstmPollLiabHelperText.AssertElementIsVisible();
                        PL_Quote_Summary.CstmPollLiabHelperX.AssertElementIsVisible();
                        PL_Quote_Summary.CstmPollLiabDDa.Click();
                        PL_Quote_Summary.CstmPollLiabDDb(theAnswer).Click();
                        Customizeclose();
                    }
                    break;
            }
        }

        void Customizeclose()
        {
            //closes the customize modal and ensures quote has stopped loading.
            PL_Quote_Summary.CstmUpdateCTA.Click();
            AutomationHelper.LegacyWaitForLoading();
            PL_Quote_Summary.CustomizeTitle.AssertElementNotPresent();
        }

        void YearlyToggle(string toggle)
        {
            switch (toggle.ToLower())
            {
                case "monthly":
                    // if set to yearly now, set it back to monthly
                    if (PL_Quote_Summary.ToggleIsSetToYearly.AssertElementIsVisible(1, true))
                    {
                        PL_Quote_Summary.ToggleIsSetToYearly.Click();
                    }
                    _plSummaryObject.YearlyOrMonthly = toggle;
                    break;
                case "yearly":
                    // if set to monthly now, set it back to yearly
                    if (PL_Quote_Summary.ToggleIsSetToMonthly.AssertElementIsVisible(1, true))
                    {
                        PL_Quote_Summary.ToggleIsSetToMonthly.Click();
                    }
                    _plSummaryObject.YearlyOrMonthly = toggle;
                    break;
                default:
                    throw new Exception("Must be either Yearly or Monthly");
            }
        }

        void StandardOrPlus(string p1)
        {
            if (p1.Equals("Standard"))
            {
                PL_Quote_Summary.PurchaseCTA.Click();
            }
            else if (p1.Equals("Plus"))
            {
                PL_Quote_Summary.PlusPurchaseCTA.Click();
            }
            else
            {
                throw new Exception("Must be Standard or Plus only");
            }
        }

        private List<string> CreateListOfValues(string valueString)
        {
            List<string> listOfValues = new List<string>();
            Regex rgx = new Regex(@"\w+");
            var result = rgx.Match(valueString);

            while (result.Success)
            {
                listOfValues.Add(result.Value);
                result = result.NextMatch();
            }
            return listOfValues;
        }

        private void ValidateDefaultQuoteValues(List<string> quoteValues)
        {
            foreach (var quoteValue in quoteValues)
            {
                if (DefaultDeductibleAndCoverageValues.ContainsKey(quoteValue))
                {
                    var quoteValueObj = DefaultDeductibleAndCoverageValues.GetValueOrDefault(quoteValue);

                    quoteValueObj.ValueAmountElement.AssertElementInnerTextEquals(quoteValueObj.Value);
                }
            }
        }

        public void ValidateQuoteValue(string deductibleOrCoverage, string value)
        {
            if (DeductiblesAndCoverages.ContainsKey(deductibleOrCoverage))
            {
                DeductiblesAndCoverages.GetValueOrDefault(deductibleOrCoverage).ValueAmountElement.AssertElementInnerTextEquals(value);
            }
            else
            {
                ValidateDefaultQuoteValue(deductibleOrCoverage);
            }
        }

        private void ValidateDefaultQuoteValue(string deductibleOrCoverage)
        {
            foreach (var entry in DefaultDeductibleAndCoverageValues)
            {
                if (entry.Key == deductibleOrCoverage)
                {
                    entry.Value.ValueAmountElement.AssertElementInnerTextEquals(entry.Value.Value);
                }
            }
        }

        private Dictionary<string, QuoteValueObj> DefaultDeductibleAndCoverageValues = new Dictionary<string, QuoteValueObj>
        {
                { "Deductible PO", new QuoteValueObj(PL_Quote_Summary.DeductiblePerOccAmt, "$2,500") },
                { "Plus Deductible PO", new QuoteValueObj(PL_Quote_Summary.PlusDeductPerOccurAmt, "$2,500") },
                { "Limits PO", new QuoteValueObj(PL_Quote_Summary.LimitsPerOccurrenceAmt, "$1,000,000") },
                { "Limits Agg", new QuoteValueObj(PL_Quote_Summary.LimitsAggregateAmt, "$1,000,000") },
                { "Plus Limits PO", new QuoteValueObj(PL_Quote_Summary.PlusLimitsPerOccurAmt, "$1,000,000") },
                { "Plus Limits Agg", new QuoteValueObj(PL_Quote_Summary.PlusLimitsAggregateAmt, "$1,000,000") },
                { "Plus CL Agg", new QuoteValueObj(PL_Quote_Summary.PlusCyberLiabAmt, "$100,000") },
                { "SAbuse Agg", new QuoteValueObj(PL_Quote_Summary.SAbuseAggregateAmt, "$250,000") },
        };

        public class QuoteValueObj
        {
            public Element ValueAmountElement;
            public string Value;

            public QuoteValueObj(Element valueAmountElement, string value)
            {
                ValueAmountElement = valueAmountElement;
                Value = value;
            }
        }
    }
}