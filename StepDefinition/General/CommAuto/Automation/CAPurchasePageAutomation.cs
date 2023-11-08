using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Helpers;
using System;
using HitachiQA;
using System.Text.RegularExpressions;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using DocumentFormat.OpenXml.Spreadsheet;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CAPurchasePageAutomation
{
    private readonly CASummaryObject _caSummaryObject;

    public CAPurchasePageAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public void ClickContinue()
    {
        CA_PurchaseYourPlanPage.PayCTA.Click();
        AutomationHelper.WaitForLoading();
    }

    public void VerifyPolicyDate()
    {
        Regex rgxPolicyStartDate = new Regex(@"[0-9]*/[0-9]*/[0-9]*");

        var dateCoverageStarts = CA_PurchaseYourPlanPage.OneYearCoverageStarting.GetInnerText();
        var yearValueFromUI = rgxPolicyStartDate.Match(dateCoverageStarts);
        DateTime coverageStartingOn = Convert.ToDateTime(yearValueFromUI.Value);
        var policyStartEntered = Convert.ToDateTime(_caSummaryObject.PolicyStart);
        Assert.IsTrue(coverageStartingOn == policyStartEntered);
    }

    public void CheckPaymentsComparisonMath(PaymentSchedule planType)
    {
        var paymentPerMonth = GetPriceFromElement(CA_PurchaseYourPlanPage.TwelveMonthlyPaymentsAmountPerMonth, ",", "$");
        var paymentPerYear = GetPriceFromElement(CA_PurchaseYourPlanPage.YearlyPaymentDueToday, ",", "$");

        //save the amount paid today to the summary object in order to check against the page after purchasing
        switch (planType)
        {
            case PaymentSchedule.YEARLY:
                _caSummaryObject.PaymentAmountMadeToday = paymentPerYear;
                _caSummaryObject.PaymentPlanChosen = "Yearly";
                break;
            case PaymentSchedule.MONTHLY:
                _caSummaryObject.PaymentAmountMadeToday = paymentPerMonth;
                _caSummaryObject.PaymentPlanChosen = "Monthly";
                break;
        }

        var yearlySavedAmount = GetPriceFromElement(CA_PurchaseYourPlanPage.YearlyPaymentSaveAmount, ",", "Save: $");

        //monthly amount paid might end up being slightly less than calculated (off by a few cents)
        //therefore, we just want to make sure that the saveByYearly is off by less than a dollar
        var marginOfError = CalculateMarginOfError(paymentPerMonth, paymentPerYear, yearlySavedAmount);
        Assert.IsTrue(marginOfError <= 1);
    }

    public void VerifyPlanOptions()
    {
        //handle Your Payment Terms and Payment Information
        CA_PurchaseYourPlanPage.PaymentTerms.AssertElementIsVisible();
    }

    public void SelectMonthlyPayment()
    {
        CA_PurchaseYourPlanPage.TwelveMonthlyPayments.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.TwelveMonthlyPaymentsAmountPerMonth.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.TwelveMonthlyPaymentsViewSchedule.Click();
        CA_PurchaseYourPlanPage.TwelveMonthlyPaymentsChkbox.Click();
    }

    public void SelectYearlyPayment()
    {
        CA_PurchaseYourPlanPage.YearlyPayment.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.YearlyPaymentSaveAmount.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.YearlyPaymentDueToday.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.YearlyPaymentChkbox.Click();
    }

    public void FillOutCreditCardInfo(TestCreditCards testCard)
    {
        CA_PurchaseYourPlanPage.PaymentInformationTitle.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.CCImg_Visa.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.CCImg_Mastercard.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.CCImg_Discover.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.CCImg_AmEx.AssertElementIsVisible();

        //Fill out card details
        CA_PurchaseYourPlanPage.CreditCardName.SetText(Functions.GetRandomStringWithRestrictions(12, "alpha"));
        CA_PurchaseYourPlanPage.CreditCardNumber.SetText(testCard.GetNumber());
        CA_PurchaseYourPlanPage.CreditCardMMYY.SetText("12/26");
    }

    public void VerifyAutopayRequired()
    {
        CA_PurchaseYourPlanPage.AutopayReqTitle.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.AutopayReqHelper.Click();
        CA_PurchaseYourPlanPage.AutopayReqHelperText.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.AutopayReqHelperX.Click();
        CA_PurchaseYourPlanPage.AutopayToggle.AssertElementNotPresent(2);
    }

    public void VerifyAutopayOptional()
    {
        CA_PurchaseYourPlanPage.AutopayTitle.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.AutopayToggle.AssertElementIsVisible();

        var autopayDefault = CA_PurchaseYourPlanPage.AutopayValue.GetAttribute("aria-checked");
        CA_PurchaseYourPlanPage.AutopayToggle.Click();
        UserActions.WaitUntil(() => CA_PurchaseYourPlanPage.AutopayValue.GetAttribute("aria-checked") != autopayDefault, 4);
        CA_PurchaseYourPlanPage.AutopayToggle.Click();
        UserActions.WaitUntil(() => CA_PurchaseYourPlanPage.AutopayValue.GetAttribute("aria-checked") == autopayDefault, 4);

        CA_PurchaseYourPlanPage.AutopayReqTitle.AssertElementNotPresent();
        CA_PurchaseYourPlanPage.AutopayReqHelper.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.AutopayReqHelper.Click();
        CA_PurchaseYourPlanPage.AutopayReqHelperText.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.AutopayReqHelperX.Click();
    }

    public void SelectAutopayOption(bool option)
    {
        var expectedAttribute = option.ToString().ToLower();
        if (CA_PurchaseYourPlanPage.AutopayValue.GetAttribute("aria-checked") != expectedAttribute)
        {
            CA_PurchaseYourPlanPage.AutopayToggle.Click();
        }
    }

    public void VerifyCardFormExtras()
    {
        //verify secure payment info displayed
        CA_PurchaseYourPlanPage.CreditCardLockImage.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.CreditCardSecurePayment.AssertElementIsVisible();

        //check for authorize.net icon
        CA_PurchaseYourPlanPage.AuthNetMerchantImg.AssertElementIsVisible();
    }

    public void AgreeToTerms()
    {
        //agree to terms of use
        CA_PurchaseYourPlanPage.AgreeToTermsOfUseHyperlink.AssertElementIsVisible();
        CA_PurchaseYourPlanPage.AgreeToTermsOfUseChkbox.Click();
    }
    
    private static decimal CalculateMarginOfError(decimal paymentPerMonth, decimal paymentPerYear, decimal yearlySavedAmount)
    {
        var totalPaidInYearIfMonthly = 12 * paymentPerMonth;
        var yearlyPaymentWithoutSavings = paymentPerYear + yearlySavedAmount;
        return Math.Abs(totalPaidInYearIfMonthly - yearlyPaymentWithoutSavings);
    }

    private decimal GetPriceFromElement(Element element, params string[] phrasesToRemove)
    {
        var priceText = element.GetInnerText();

        foreach (var phrase in phrasesToRemove)
        {
            priceText = priceText.Replace(phrase, "");
        }

        return Convert.ToDecimal(priceText);
    }
}