using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CAYourQuoteAutomationFactory : IAutomationFactory<CAYourQuoteAutomation>
{
    private readonly CASummaryObject _caSummaryObject;
    
    public CAYourQuoteAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CAYourQuoteAutomation CreateAutomation()
    {
        return new CAYourQuoteAutomation(_caSummaryObject);
    }
}