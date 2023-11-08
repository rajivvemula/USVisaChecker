using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CADriverIncidentAutomationFactory : IAutomationFactory<CADriverIncidentAutomation>
{
    private CASummaryObject _caSummaryObject;

    public CADriverIncidentAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CADriverIncidentAutomation CreateAutomation()
    {
        return new CADriverIncidentAutomation(_caSummaryObject);
    }
}