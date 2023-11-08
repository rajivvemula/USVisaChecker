using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CAStartYourQuoteAutomationFactory : IAutomationFactory<CAStartYourQuoteAutomation>
{
    private readonly CASummaryObject _caSummaryObject;

    public CAStartYourQuoteAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CAStartYourQuoteAutomation CreateAutomation()
    {
        return new CAStartYourQuoteAutomation(_caSummaryObject);
    }
}