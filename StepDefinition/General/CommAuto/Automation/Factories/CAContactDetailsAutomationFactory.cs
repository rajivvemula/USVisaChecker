using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CAContactDetailsAutomationFactory : IAutomationFactory<CAContactDetailsAutomation>
{
    private readonly CASummaryObject _caSummaryObject;

    public CAContactDetailsAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CAContactDetailsAutomation CreateAutomation()
    {
        return new CAContactDetailsAutomation(_caSummaryObject);
    }
}