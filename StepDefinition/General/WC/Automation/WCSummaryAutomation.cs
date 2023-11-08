using System;
using BiBerkLOB.Pages.WC;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA.Driver;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.WC.Automation;

public class WCSummaryAutomation
{
    private WCSummaryObject _summaryObject;
    private readonly WCAdditionalInformationObject _localAIObject;
    private readonly WCYourQuoteObject _yourQuoteObject;
    private bool includedExcludedOfficersVerified = false;

    public WCSummaryAutomation(WCSummaryObject summaryObject, WCAdditionalInformationObject wcAIObject, WCYourQuoteObject yourQuoteObject)
    {
        _summaryObject = summaryObject;
        _localAIObject = wcAIObject;
        _yourQuoteObject = yourQuoteObject;
    }

    public void WaitForLoading()
    {
        AutomationHelper.WaitForWCLoading();
        WC_SummaryPage.YourSummaryHeader.AssertElementIsVisible();
    }

    public void VerifyAboutYou()
    {

    }

    public void VerifyOwnerOfficers()
    {
        WC_SummaryPage.OwnersAndOfficersTitle.AssertElementIsVisible();
        WC_SummaryPage.OwnerAndOfficerEditBtn.AssertElementIsVisible();

        foreach (var ooQuestion in _localAIObject.OwnerOfficerQuestions)
        {
            switch (ooQuestion.QuestionText)
            {
                case "How many owners/officers does your business have?":
                case "How many owners/officers are there?":
                    var totalNoOfOO = _localAIObject.NoOfOOForBusiness == 0 ? (_localAIObject.CoveredOOList.Count + _localAIObject.ExcludedOOList.Count) : _localAIObject.NoOfOOForBusiness; // Handling OO scenarios which doesn't specify Include/Excluded Officers
                    WC_SummaryPage.TotalOwnerOfficer.AssertPairExactAnswer(totalNoOfOO.ToString());
                    break;
                case "How many owners/officers do you want to cover with this policy?":
                case "How many owners/officers do you want to cover with this policy? State law requires that they all be covered.":
                case "How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered.":
                    VerifyIncludedAndExcludedOfficers();
                    break;
                case "Do you want to buy coverage for the business owners?":
                case "How many owners/officers do you want to exclude from this policy?":
                case "How many owners/officers do you want to exclude from this policy? State law requires that they all be excluded.":
                case "How many owners have less than 50% ownership? State law requires that they be covered.":
                    //We Don't display excluded OO question
                    break;
                default:
                    VerifyOOSummaryBooleanTypeQuestions(ooQuestion.QuestionText).AssertPairExactAnswer(ooQuestion.QuestionAnswer);
                    break;
            }
        }
        // For few of the scenarios the Included Officer is added without asking for the question(How many officers do you cover) in the OO Page
        if (!includedExcludedOfficersVerified)
        {
            VerifyIncludedAndExcludedOfficers();
        }
    }

    private void VerifyIncludedAndExcludedOfficers()
    {
        WC_SummaryPage.CoveredOwnerOfficer.AssertPairExactAnswer(_localAIObject.CoveredOOList.Count.ToString());

        VerifyIncludedOfficers();
        VerifyExcludedOfficers();
        includedExcludedOfficersVerified = true;
    }

    private void VerifyIncludedOfficers()
    {
        var coveredOOList = _localAIObject.CoveredOOList;

        foreach (var coveredOfficer in coveredOOList)
        {
            int officerIndex = coveredOOList.IndexOf(coveredOfficer);

            if (!string.IsNullOrWhiteSpace(coveredOfficer.OfficerFullName))
            {
                WC_SummaryPage.IncludedOfficer(officerIndex).AssertPairExactAnswer(coveredOfficer.OfficerFullName);

                if (coveredOfficer.DoesOfficerReceieveW2Payroll)
                {
                    var formattedPayroll = GetOwnerOfficerPayroll(coveredOfficer.OfficerPayroll);
                    WC_SummaryPage.TheirPayroll(officerIndex).AssertPairExactAnswer(formattedPayroll);
                }
                else
                {
                    WC_SummaryPage.OfficerDoesntCollectPayroll(officerIndex).AssertElementIsPresent();
                }
            }
        }
    }

    // For some of the States, when the amount is less than the Min Payroll then Summary Page will display the threshold amount - US91982
    private string GetOwnerOfficerPayroll(string officerPayroll)
    {
        var payrollAmt = int.Parse(officerPayroll);
        var state = State.FromAny(_yourQuoteObject.State);
        if (WC_SummaryPage.StateMinPayrollDictionary.TryGetValue(state, out var minPayroll))
        {
            payrollAmt = payrollAmt > minPayroll ? payrollAmt : minPayroll;
        }

        return payrollAmt.ToString("C");
    }

    private void VerifyExcludedOfficers()
    {
        var excludedOOList = _localAIObject.ExcludedOOList;

        foreach (var excludedOfficer in excludedOOList)
        {
            if (!string.IsNullOrWhiteSpace(excludedOfficer.OfficerFullName))
            {
                int officerIndex = excludedOOList.IndexOf(excludedOfficer);
                WC_SummaryPage.ExcludedOfficer(officerIndex).AssertPairExactAnswer(excludedOfficer.OfficerFullName);
            }
        }
    }

    private static SummaryQAPair VerifyOOSummaryBooleanTypeQuestions(string ooQuestion)
    {
        foreach (var ele in WC_SummaryPage.OOSummaryElementsAndPairs)
        {
            try
            {
                if (ele.Key.GetElementText(1).Contains(ooQuestion.ToLower())) // Traverse through Dictionary of Elements and waits for a second, if element not found then continues the loop
                    return ele.Value;
            }
            catch (Exception)
            {
                //Continue to next iteration in the logic
                continue;
            }
        }
        throw new Exception("The following question: " + ooQuestion + " is not mapped in the OOSummaryElementsAndPairs Dictionary");
    }

    public void VerifyYourServices()
    {

    }

    public void ClickContinue()
    {
        // todo: move element to mapping
        var continueBtn = new Element("//button[@data-qa='wc_summary_continue_button']");
        continueBtn.Click();
    }
}
