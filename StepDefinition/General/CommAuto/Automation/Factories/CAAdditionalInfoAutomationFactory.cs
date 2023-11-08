using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CAAdditionalInfoAutomationFactory : IAutomationFactory<CAAdditionalInfoAutomation>
{
    private readonly CASummaryObject _caSummaryObject;

    public CAAdditionalInfoAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CAAdditionalInfoAutomation CreateAutomation()
    {
        return new CAAdditionalInfoAutomation(_caSummaryObject);
    }
}