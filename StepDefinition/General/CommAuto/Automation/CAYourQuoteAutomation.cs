using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Helpers;
using System.Text.RegularExpressions;
using System;
using HitachiQA;
using System.Globalization;
using System.Linq;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CAYourQuoteAutomation
{
    private const int ASSERT_WAIT_SECONDS = 1;
    private readonly CASummaryObject _caSummaryObject;

    public CAYourQuoteAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    // table value is | Yearly | Yes/No |
    // if yes, set to yearly, otherwise, should be monthly
    public void SetYearlyOrMonthly(string yesOrNo)
    {
        var isYes = Functions.ConvertYesOrNoStringToBool(yesOrNo);
        if (isYes)
        {
            CA_QuoteSummaryPage.MonthlyYearlyToggle.Click();
            _caSummaryObject.QuoteChooseYearlyOrMonthly = "yearly";
        }
        else
        {
            _caSummaryObject.QuoteChooseYearlyOrMonthly = "monthly";
        }
    }

    public void SelectPolicyCoverages(string tableAnswer)
    {
        CA_QuoteSummaryPage.BodilyInjuryAndPropertyDamageInput.AssertAllElements(ASSERT_WAIT_SECONDS);
        CA_QuoteSummaryPage.BodilyInjuryAndPropertyDamageInput.EnterResponse(tableAnswer);

        _caSummaryObject.Coverages.Add(new CACoverage("BIPD", tableAnswer));
        
        if (CAStateSpecifications.StatesWithUMBI().Contains(_caSummaryObject.BusinessAddress.State))
        {
            _caSummaryObject.Coverages.Add(new CACoverage("UMBI", ""));
        }
        if (CAStateSpecifications.StatesWithUIMBI().Contains(_caSummaryObject.BusinessAddress.State))
        {
            _caSummaryObject.Coverages.Add(new CACoverage("UIMBI", ""));
        }
        if (CAStateSpecifications.StatesWithUMBIPD().Contains(_caSummaryObject.BusinessAddress.State))
        {
            _caSummaryObject.Coverages.Add(new CACoverage("UMBIPD", ""));
        }
        if (CAStateSpecifications.StatesWithVehicleUMAndUIM().Contains(_caSummaryObject.BusinessAddress.State))
        {
            _caSummaryObject.Coverages.Add(new CACoverage("VUM", ""));
        }
    }

    public void SelectVehicleCoverage(string tableAnswer, int vehicleIndex)
    {
        CA_QuoteSummaryPage.VehicleCoverageInput(vehicleIndex).AssertAllElements(ASSERT_WAIT_SECONDS);
        CA_QuoteSummaryPage.VehicleCoverageInput(vehicleIndex).EnterResponse(tableAnswer);

        if (!tableAnswer.Equals("No Physical Damage Coverage"))
        {
            AddCoverageOnlyIfNotExists("Collision/Comprehensive", "");
        }

        // vehicle specific details will be in the associated vechicle
        _caSummaryObject.VehiclesList[vehicleIndex].CoverageDetails = tableAnswer;
    }

    public void SelectMedicalPaymentCoverage(string tableAnswer)
    {
        CA_QuoteSummaryPage.MedicalPaymentsInput.AssertAllElements(ASSERT_WAIT_SECONDS);
        CA_QuoteSummaryPage.MedicalPaymentsInput.EnterResponse(tableAnswer);
        _caSummaryObject.Coverages.Add(new CACoverage("Medical", tableAnswer));
    }

    public void SelectCargoCoverage(string tableAnswer)
    {
        CA_QuoteSummaryPage.CargoLiabilityInput.AssertAllElements(ASSERT_WAIT_SECONDS);
        CA_QuoteSummaryPage.CargoLiabilityInput.EnterResponse(tableAnswer);
        _caSummaryObject.Coverages.Add(new CACoverage("Cargo", tableAnswer));
    }

    public void SelectTrailerCoverage(string tableAnswer)
    {
        CA_QuoteSummaryPage.TrailerInterchangeInput.AssertAllElements(ASSERT_WAIT_SECONDS);
        CA_QuoteSummaryPage.TrailerInterchangeInput.EnterResponse(tableAnswer);
        _caSummaryObject.Coverages.Add(new CACoverage("Trailer", tableAnswer));
    }

    public void SelectRentalCoverage(string tableAnswer)
    {
        CA_QuoteSummaryPage.RentalReimbursementInput.AssertAllElements(ASSERT_WAIT_SECONDS);
        CA_QuoteSummaryPage.RentalReimbursementInput.EnterResponse(tableAnswer);
        _caSummaryObject.Coverages.Add(new CACoverage("Rental", tableAnswer));
    }

    public void SelectInTowCoverage(string tableAnswer)
    {
        CA_QuoteSummaryPage.InTowInput.AssertAllElements(ASSERT_WAIT_SECONDS);
        CA_QuoteSummaryPage.InTowInput.EnterResponse(tableAnswer);
        _caSummaryObject.Coverages.Add(new CACoverage("In-Tow", tableAnswer));
    }

    public void SelectPolicyMedicalCoverage(string tableAnswer)
    {
        CA_QuoteSummaryPage.PolicyMedInput.AssertAllElements(ASSERT_WAIT_SECONDS);
        CA_QuoteSummaryPage.PolicyMedInput.EnterResponse(tableAnswer);

        _caSummaryObject.Coverages.Add(new CACoverage("Medical", tableAnswer));
    }

    public void SaveUpdatesIfAny()
    {
        if (CA_QuoteSummaryPage.UpdateQuoteBottomCTA.AssertElementIsVisible(3, true))
        {
            CA_QuoteSummaryPage.UpdateQuoteBottomCTA.Click();
            CA_QuoteSummaryPage.UpdateQuoteModalUpdateQuoteBTN.Click();
            CA_QuoteSummaryPage.UpdateQuoteInProgressToast.AssertElementIsVisible(5, true);
            AutomationHelper.WaitForLoading(120);
            CA_QuoteSummaryPage.UpdateQuoteSuccessfulToast.AssertElementIsVisible(5, true);
            CA_QuoteSummaryPage.UpdateQuoteSuccessfulToast.AssertElementNotPresent();
        }

        AutomationHelper.WaitForLoading();
    }

    public void ValidateUnInsuredUnderInsuredSection()
    {
        CA_QuoteSummaryPage.UninsuredUnderInsMotoristChkbox.IsEnabled().Equals(false); //It is disabled
        CA_QuoteSummaryPage.UninsuredUnderInsMotoristHelper.Click();
        CA_QuoteSummaryPage.UninsuredUnderInsMotoristHelperText.AssertElementIsVisible();
        CA_QuoteSummaryPage.UninsuredUnderInsMotoristHelperX.Click();
    }

    public void ValidateStepper()
    {
        Reusable_PurchasePath.CAStepper_1Coverage_Current.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_1Coverage_Past.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_2Operations_Before.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_2Operations_Current.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_2Operations_Past.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_3AboutYou_Before.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_3AboutYou_Current.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_3AboutYou_Past.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_4Summary_Before.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_4Summary_Current.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_5Quote_Before.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
        Reusable_PurchasePath.CAStepper_6Purchase_Before.AssertElementNotPresent(ASSERT_WAIT_SECONDS);
    }

    public void VerifyPriceComparison(string moreOrLessTxt, decimal valueToCompareTo)
    {
        //convert actual value of price on the page to decimal for easy comparison
        var theUIPrice = CA_QuoteSummaryPage.TotalAnnualPremiumAmount.GetInnerText();
        var convertedUIPrice = decimal.Parse(theUIPrice, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);

        var comparison = decimal.Compare(convertedUIPrice, valueToCompareTo);

        Assert.IsTrue(moreOrLessTxt switch
        {
            "more" => comparison > 0,
            "less" => comparison < 0,
            _ => throw new ArgumentException($"can't determine a comparison from text '{moreOrLessTxt}'")
        });
    }

    public void SaveExpectedPaymentToday()
    {
        _caSummaryObject.AmountYouPayToday = CA_QuoteSummaryPage.PaymentDueTitle.GetInnerText();
    }

    public void ClickContinue()
    {
        CA_QuoteSummaryPage.PurchaseCTA.Click();
        AutomationHelper.WaitForLoading();
    }

    // only adds coverage if the name doesn't appear
    private void AddCoverageOnlyIfNotExists(string covName, string covDetail)
    {
        if (_caSummaryObject.Coverages.All(cov => cov.CoverageName != covName))
        {
            _caSummaryObject.Coverages.Add(new CACoverage(covName, covDetail));
        }
    }
}