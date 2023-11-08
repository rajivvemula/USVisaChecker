using BiBerkLOB.Pages.WC;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.WC.Automation.Factories;

public class WCSummaryAutomationFactory : IAutomationFactory<WCSummaryAutomation>
{
    private WCSummaryObject _summaryObject;
    private readonly WCAdditionalInformationObject _localAIObject;
    private readonly WCYourQuoteObject _yourQuoteObject;

    public WCSummaryAutomationFactory(WCSummaryObject wCSummary, WCAdditionalInformationObject localAIObject, WCYourQuoteObject yourQuoteObject)
    {
        _localAIObject = localAIObject;
        _summaryObject = wCSummary;
        _yourQuoteObject = yourQuoteObject;
    }

    public WCSummaryAutomation CreateAutomation()
    {
        return new WCSummaryAutomation(_summaryObject, _localAIObject, _yourQuoteObject);
    }
}