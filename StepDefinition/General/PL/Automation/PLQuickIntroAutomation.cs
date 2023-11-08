using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.Source.Helpers;
using HitachiQA;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.PL.Automation;

public class PLQuickIntroAutomation
{
    public PLSummaryObject PLSummaryObject { get; private set; }
    private readonly MadLibsSummaryObject _MadLibsSummaryObject;
    private readonly QuoteIDRetriever _quoteIDRetriever;

    public PLQuickIntroAutomation(PLSummaryObject plSummaryObject, MadLibsSummaryObject madLibsSummaryObject, QuoteIDRetriever quoteIDRetriever)
    {
        PLSummaryObject = plSummaryObject;
        _MadLibsSummaryObject = madLibsSummaryObject;
        _quoteIDRetriever = quoteIDRetriever;
    }

    public void SaveQuoteID()
    {
        PLSummaryObject.QuoteID = _quoteIDRetriever.CaptureQuoteIdFromRibbonText();
    }

    public void SelectBusinessStructureButton(string businessStruct)
    {
        PLSummaryObject.BusinessStruct = businessStruct;
        var pattern = new Regex(@"[^.()/-]+");
        var match = pattern.Match(businessStruct);
        var busStructAnswer = string.Empty;

        while (match.Success)
        {
            busStructAnswer += match.Value;
            match = match.NextMatch();
        }

        if (businessStruct == "Individual/Sole Proprietor")
        {
            PLSummaryObject.IsBusinessIndividual = true;
            PLSummaryObject.BusinessNameLabel = "IndiBusName";
        }
        PL_IntroductionPage.BusStructQuestion.EnterResponse(busStructAnswer);
    }

    public void EnterBusinessName(string name)
    {
        PLSummaryObject.BusinessName = name;
        if (!PLSummaryObject.IsBusinessIndividual)
            PL_IntroductionPage.NameOfBusinessQuestion.EnterResponse(name);
        else throw new Exception($"Business Name textbox not found. Test is Incorrectly Designed");
    }

    public void EnterInsuredFirstName(string name)
    {
        PLSummaryObject.InsuredFirstName = name;
        if (PLSummaryObject.IsBusinessIndividual)
            PL_IntroductionPage.InsuredFirstTxtbox.SetText(name);
        else throw new Exception($"FirstName textbox not found. Test is Incorrectly Designed");
    }

    public void EnterInsuredLastName(string name)
    {
        PLSummaryObject.InsuredLastName = name;
        if (PLSummaryObject.IsBusinessIndividual)
            PL_IntroductionPage.InsuredLastTxtbox.SetText(name);
        else throw new Exception($"Lastname textbox not found. Test is Incorrectly Designed");
    }

    public void SpecifyBusinessUnderAnotherName(string dba)
    {
        PL_IntroductionPage.DoDBAQuestion.AssertAllElements();
        bool hasAnotherName = !dba.Equals("No");
        PL_IntroductionPage.DoDBAQuestion.EnterResponse(hasAnotherName);

        if (hasAnotherName)
        {
            PLSummaryObject.DBA = dba;
            PL_IntroductionPage.WhatIsDBAQuestion.AssertAllElements();
            PL_IntroductionPage.WhatIsDBAQuestion.EnterResponse(dba);
        }
    }

    public void ChooseLLCIfDBAHasLLCInName(string llc)
    {
        bool hasLlcInBusinessName = PLSummaryObject.BusinessName.ToLower().Contains("llc");
        bool hasLlcInOtherName = PLSummaryObject.DBA.ToLower().Contains("llc");
        if (hasLlcInBusinessName || hasLlcInOtherName)
        {
            PL_IntroductionPage.AreYouSureLLCQuestion.AssertAllElements();
            var yesCond = Functions.ConvertYesOrNoStringToBool(llc);
            PL_IntroductionPage.AreYouSureLLCQuestion.EnterResponse(yesCond);
        }
    }

    public async Task EnterPLQuickIntroBusinessAddress(string address)
    {
        var stateFromZipCode = await LegacyPortalApiHelper.GetStateFromZipCode(_MadLibsSummaryObject.ZipCode);
        var keyword = _MadLibsSummaryObject.Keyword.ToLower();

        bool homeBasedOccupancyCond = _MadLibsSummaryObject.Location.Equals("I Run My Business Out of My Home");

         PL_IntroductionPage.InsuredAddressTxtbox.SetText(address);

        // TODO - Once US 75995 moves to Done 

        //bool newJerseyCond = finalState.Equals(State.NewJersey) &&
        //        (keyword.Equals("home inspection") || keyword.Equals("lawyer"));

        //if (!PLStateSpecifications.StatesWithoutBusinessAddress().Contains(finalState))
        //{
        //    if (newJerseyCond || keyword.Equals("home inspection"))
        //    {
        //        if (!homeBasedOccupancyCond && PLSummaryObject.IsBusinessIndividual)
        //        {
        //            PL_IntroductionPage.InsuredAddressTxtbox.AssertElementIsVisible();
        //        }
        //        else if (!homeBasedOccupancyCond && !PLSummaryObject.IsBusinessIndividual)
        //        {
        //            PL_IntroductionPage.InsuredAddressTxtbox.SetText(address);
        //        }
        //    }
        //}
    }
}