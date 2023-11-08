using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CAOperationsAutomationFactory : IAutomationFactory<CAOperationsAutomation>
{
    private readonly CASummaryObject _caSummaryObject;
    private readonly ApolloGateway _apolloGateway;
    
    public CAOperationsAutomationFactory(CASummaryObject caSummaryObject, ApolloGateway apolloGateway)
    {
        _caSummaryObject = caSummaryObject;
        _apolloGateway = apolloGateway;
    }

    public CAOperationsAutomation CreateAutomation()
    {
        return new CAOperationsAutomation(_caSummaryObject, _apolloGateway);
    }
}