using BiBerkLOB.Pages.PL;
using HitachiQA;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.PL.Automation;

public class PLCoverageDetailsAutomation
{
    private readonly PLSummaryObject _plSummaryObject;

    public PLCoverageDetailsAutomation(PLSummaryObject plSummaryObject)
    {
        _plSummaryObject = plSummaryObject;
    }

    public void SelectPolicyStartDate(string startDateString)
    {
        PL_CoverageDetails.PolicyStartQuestion.AssertAllElements();
        PL_CoverageDetails.PolicyStartQuestion.EnterResponse(startDateString);
    }

    public void VerifyDefaultPolicyStartDate() 
    {
        var expectedStartDate = Functions.GetNextDay("MM/dd/yyyy");
        var acutalStartDate = PL_CoverageDetails.PolicyStartDatePicker.GetDateString();

        Assert.AreEqual(expectedStartDate, acutalStartDate);
    }

    public void SelectCurrentlyHavePLPolicyYesOrNo(string yesOrNo)
    {
        PL_CoverageDetails.CurrentlyHavePLQuestion.AssertAllElements();
        PL_CoverageDetails.CurrentlyHavePLQuestion.EnterResponse(yesOrNo);
    }

    public void SelectCurrentRetroDateYesNoIdk(string answer)
    {
        PL_CoverageDetails.HaveRetroDateChoiceQuestion.AssertAllElements();
        PL_CoverageDetails.HaveRetroDateChoiceQuestion.EnterResponse(answer);
        SaveCurrentRetroDateYesNoIdkResponse(answer);
    }

    public void SpecifyRetroDate(string retroDate)
    {
        var dateToPick = retroDate;
        if (retroDate == "")
        {
            dateToPick = Functions.GetDifferentDateFromNow(-30, "d").ToString("MM/dd/yyyy");
        }
        
        PL_CoverageDetails.RetroDateDateQuestion.AssertAllElements();
        
        Log.Debug("before selecting Retro PL Date");
        PL_CoverageDetails.RetroDateInput.SetText(dateToPick);
        _plSummaryObject.RetroDate = dateToPick;
        Log.Debug($"Retro PL Date = '{_plSummaryObject.RetroDate}'");
    }

    public void SelectHaveYouHadPLYesOrNo(string yesOrNo)
    {
        PL_CoverageDetails.HaveHadPLInLast3YearsQuestion.AssertAllElements();
        PL_CoverageDetails.HaveHadPLInLast3YearsQuestion.EnterResponse(yesOrNo);
        if (yesOrNo == "Yes")
        {
            _plSummaryObject.PLIn3years = "Yes";
        }
    }

    public void ChooseOptionBestDescribesCurrentPolicy(string option)
    {
        _plSummaryObject.CurrentlyProLiability = "You currently have a Professional Liability (E&O) policy.";
        PL_CoverageDetails.CurrentPLPolicyQuestion.AssertAllElements();
        PL_CoverageDetails.CurrentPLPolicyQuestion.EnterResponse(option.Replace(".", ""));
    }

    public void SpecifyHowManyClaimsInLast3Years(string numClaims)
    {
        _plSummaryObject.HowManyClaims = numClaims;

        int numClaimsValue = GetNumFromChoice(numClaims);
        PL_CoverageDetails.HowManyPLClaimsQuestion.AssertAllElements();
        PL_CoverageDetails.HowManyPLClaimsQuestion.EnterResponse(numClaimsValue);
    }

    private static int GetNumFromChoice(string numClaims)
    {
        // if 5+, just parses the 5 without +
        return int.Parse(numClaims[0].ToString());
    }

    private void SaveCurrentRetroDateYesNoIdkResponse(string answer)
    {
        _plSummaryObject.CurrentRetroDate = answer;
        if (answer.Equals("Yes"))
        {
            PL_CoverageDetails.HaveRetroDateBTN_Yes.Click();
            _plSummaryObject.CurrentRetroDate = "Your current policy has a retroactive date.";
        }
        else if (answer.Equals("No"))
        {
            PL_CoverageDetails.HaveRetroDateBTN_No.Click();
            _plSummaryObject.CurrentRetroDate = "Your current policy has no retroactive date.";
        }
        else
        {
            PL_CoverageDetails.HaveRetroDateBTN_IDK.Click();
            _plSummaryObject.CurrentRetroDate = "You don't know if your policy has a retro date.";
        }
    }
}