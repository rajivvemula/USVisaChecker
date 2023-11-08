using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Helpers.RetryPolicy;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.GenAutomation;

public class SetupAutomationFactory : IAutomationFactory<SetupAutomation>
{
    private readonly RetryTestRunnerWrapper _retryTestRunner;
    private readonly PersistentQuoteIdObject _persistentQuoteId;
    private readonly PretestSettingsObject _pretestSettingsObject;
    private readonly RecommendationViewContext _recViewContext;

    public SetupAutomationFactory(RetryTestRunnerWrapper retryTestRunner, PersistentQuoteIdObject persistentQuoteId, PretestSettingsObject pretestSettingsObject, RecommendationViewContext recViewContext)
    {
        _retryTestRunner = retryTestRunner;
        _persistentQuoteId = persistentQuoteId;
        _pretestSettingsObject = pretestSettingsObject;
        _recViewContext = recViewContext;
    }

    public SetupAutomation CreateAutomation()
    {
        return new SetupAutomation(_retryTestRunner, _persistentQuoteId, _pretestSettingsObject, _recViewContext);
    }
}