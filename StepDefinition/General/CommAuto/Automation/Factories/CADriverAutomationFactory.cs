using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CADriverAutomationFactory : IAutomationFactory<CADriversAutomation>
{
    private CASummaryObject _caSummaryObject;

    public CADriverAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CADriversAutomation CreateAutomation()
    {
        return new CADriversAutomation(_caSummaryObject);
    }
}