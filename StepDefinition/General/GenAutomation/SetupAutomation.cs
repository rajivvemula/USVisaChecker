using System;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Pages.WC;
using BiBerkLOB.Source.Helpers.RetryPolicy;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.GenAutomation;

public class SetupAutomation
{
    private readonly RetryTestRunnerWrapper _retryTestRunner;
    private readonly PersistentQuoteIdObject _persistentQuoteId;
    private readonly PretestSettingsObject _pretestSettingsObject;
    private readonly RecommendationViewContext _recViewContext;

    public SetupAutomation(RetryTestRunnerWrapper retryTestRunner, PersistentQuoteIdObject persistentQuoteId, PretestSettingsObject pretestSettingsObject, RecommendationViewContext recViewContext)
    {
        _retryTestRunner = retryTestRunner;
        _persistentQuoteId = persistentQuoteId;
        _pretestSettingsObject = pretestSettingsObject;
        _recViewContext = recViewContext;
    }

    public void FlagNextStepAsUnstable()
    {
        _retryTestRunner.FlagNextStepAsUnstable();
    }

    public void SaveQuoteIdFromUI(Element quoteIdElement)
    {
        string quoteId = quoteIdElement.GetInnerText();
        quoteId = quoteId.Substring(quoteId.IndexOfAny("0123456789".ToCharArray()));
        SaveQuoteId(quoteId);
    }

    public void SaveQuoteId(string quoteId)
    {
        _persistentQuoteId.QuoteId = quoteId;
    }

    public void SaveQuoteLob(string lob)
    {
        _persistentQuoteId.LOB = lob;
    }

    public void SaveQuoteState(string state)
    {
        _persistentQuoteId.State = state;
    }

    public void SaveQuoteIndustry(string industry)
    {
        _persistentQuoteId.Industry = industry;
    }

    public void SetQuoteIdSaveReason(string reason)
    {
        _persistentQuoteId.SaveReason = reason;
    }

    public void SetAllQuestionsAsRequired()
    {
        _pretestSettingsObject.QuestionInTableShouldAppear = true;
    }

    public void SetAllQuestionsAsOptional()
    {
        _pretestSettingsObject.QuestionInTableShouldAppear = false;
    }

    public void SetExpectedRecommendationView(string recView)
    {
        _recViewContext.RecommendationView = Enum.Parse<RecommendationView>(recView);
    }
}