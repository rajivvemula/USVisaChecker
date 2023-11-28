using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Source.Helpers;
using HitachiQA;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CAStartYourQuoteAutomation
{
    private readonly CASummaryObject _caSummaryObject;

    public CAStartYourQuoteAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public void EnterNameOfBusiness(string nameOfBusiness)
    {
        CA_PreIntroductionPage.NameOfBusinessInput.AssertAllElements();
        //adds random name if table is empty or has Random as the value
        if (nameOfBusiness is "" or "Random")
        {
            nameOfBusiness = Functions.GetRandomStringWithRestrictions(14, "alpha");
        }

        CA_PreIntroductionPage.NameOfBusinessInput.EnterResponse(nameOfBusiness);
        _caSummaryObject.NameOfBusiness = nameOfBusiness;
    }

    public void SelectDBAYesNo(string yesOrNo)
    {
        CA_PreIntroductionPage.DoesBusinessAnotherNameInput.AssertAllElements();
        CA_PreIntroductionPage.DoesBusinessAnotherNameInput.EnterResponse(yesOrNo);
        _caSummaryObject.DBAYesNo = yesOrNo;
    }

    public void EnterDBAIfDefined(string otherName)
    {
        CA_PreIntroductionPage.DoesBusinessAnotherNameInput.AssertAllElements();
        if (otherName.Equals(""))
        {
            SelectDBAYesNo("No");
        }
        else
        {
            SelectDBAYesNo("Yes");
            
            var randomName = Functions.GetRandomStringWithRestrictions(14, "alpha");
            otherName = otherName == "Random" ? randomName : otherName;
            CA_PreIntroductionPage.OtherBusinessNameInput.AssertAllElements();
            CA_PreIntroductionPage.OtherBusinessNameInput.EnterResponse(otherName);
        }

        _caSummaryObject.DBAValue = otherName;
    }

    public void SetPolicyStartDate(string dateFromTable)
    {
        //handle specified Policy Start Date OR default of tomorrow

        CA_PreIntroductionPage.PolicyStartInput.AssertAllElements();
        if (dateFromTable.Equals(""))
        {
            dateFromTable = Functions.GetNextDay("MM/dd/yyyy");
            Assert.IsTrue(CA_PreIntroductionPage.PolicyStartInput.IsResponseCurrentlyEqualTo(dateFromTable));
        }
        else
        {
            CA_PreIntroductionPage.PolicyStartInput.EnterResponse(_caSummaryObject.PolicyStart);
        }

        _caSummaryObject.PolicyStart = dateFromTable;
    }

    public void SaveQuoteId(QuoteIDRetriever quoteIDRetriever)
    {
        _caSummaryObject.QuoteID = quoteIDRetriever.CaptureQuoteIdFromRibbonText();
    }
}