using System;
using BiBerkLOB.Pages.WC;
using BiBerkLOB.Pages;
using BiBerkLOB.Source.Helpers.RetryPolicy;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Driver;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General;

/*
 * For steps that are manipulating things within the test suite
 * as setup for later or as a configuration step
 */

[Binding]
public sealed class TestingSetupSteps
{
    private readonly SetupAutomation _automation;

    public TestingSetupSteps(SetupAutomationFactory factory)
    {
        _automation = factory.CreateAutomation();
    }

    [Given(@"next step is unstable and should retry if failed")]
    public void GivenNextStepUnstable()
    {
        _automation.FlagNextStepAsUnstable();
    }

    [When(@"user saves their (\w\w) quote ID")]
    public void WhenUserSavesQuoteId(string lob, Table table)
    {
        _automation.SaveQuoteLob(lob);

        var dataRow = table.Rows[0];
        _automation.SaveQuoteIndustry(dataRow["Industry"]);
        _automation.SaveQuoteState(dataRow["State"]);
        if (dataRow.ContainsKey("Save Reason"))
        {
            _automation.SetQuoteIdSaveReason(dataRow["Save Reason"]);
        }

        switch (lob)
        {
            case "PL":
                _automation.SaveQuoteIdFromUI(Reusable_PurchasePath.YourPLQuoteID);
                break;
            case "CA":
                _automation.SaveQuoteIdFromUI(Reusable_PurchasePath.YourCommAutoQuoteID);
                break;
            case "WC":
                AutomationHelper.WaitForWCLoading(120);
                _automation.SaveQuoteId(UserActions.GetValueFromSessionStorage("QuoteId"));
                break;
        }
    }

    [Given(@"Question (.*) skipped")]
    public void GivenQuestionSkipped(string questionCanBeSkipped)
    {
        if (questionCanBeSkipped.ToLower() == "should not be")
        {
            _automation.SetAllQuestionsAsRequired();
        }
        else if (questionCanBeSkipped.ToLower() == "should be")
        {
            _automation.SetAllQuestionsAsOptional();
        }
    }

    [Given(@"user will land on path with recommendation view: (Simple|Pie)")]
    public void GivenUserLandsOnRecView(string recView)
    {
        _automation.SetExpectedRecommendationView(recView);
    }
}