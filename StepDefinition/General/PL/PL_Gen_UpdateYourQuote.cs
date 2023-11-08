using BiBerkLOB.Pages.PL;
using HitachiQA.Driver;
using TechTalk.SpecFlow;


namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_UpdateYourQuote
    {
        [Then(@"user verifies the PL Customize Your Plan modal appears")]

        public void ThenUserVerifiesThePLCustomizeYourPlanModalAppears()
        {
            PL_Quote_Summary.CustomizeTitle.AssertElementIsVisible();

            PL_Quote_Summary.CstmDeductibleTitle.AssertElementIsVisible();
            PL_Quote_Summary.CstmDeductPerOccurTitle.AssertElementIsVisible();
            PL_Quote_Summary.CstmDeductPerOccurHelper.Click();
            PL_Quote_Summary.CstmDeductPerOccurHelperText.AssertElementIsVisible();
            PL_Quote_Summary.CstmDeductPerOccurHelperX.AssertElementIsVisible();
            PL_Quote_Summary.CstmDeductPerOccurDDa.Click();
            PL_Quote_Summary.CstmDeductPerOccurDDb("$500").Click();

            PL_Quote_Summary.CstmLimits.AssertElementIsVisible();
            PL_Quote_Summary.CstmLimitsPerOccurTitle.AssertElementIsVisible();
            PL_Quote_Summary.CstmLimitsPerOccurHelper.Click();
            PL_Quote_Summary.CstmLimitsPerOccurHelperX.AssertElementIsVisible();
            PL_Quote_Summary.CstmLimitsPerOccurHelperText.AssertElementIsVisible();
            PL_Quote_Summary.CstmLimitsPerOccurDDa.Click();
            PL_Quote_Summary.CstmLimitsPerOccurDDb("$500,000").Click();

                  
            PL_Quote_Summary.CstmAggregateTitle.AssertElementIsVisible();
            PL_Quote_Summary.CstmAggregateHelper.Click();
            PL_Quote_Summary.CstmAggregateHelperText.AssertElementIsVisible();
            PL_Quote_Summary.CstmAggregateHelperX.AssertElementIsVisible();
            PL_Quote_Summary.CstmAggregateDDa.Click();
            PL_Quote_Summary.CstmAggregateDDb("$1,000,000").Click();

            PL_Quote_Summary.CstmUpdateCTA.AssertElementIsVisible();
        }
    }
}


