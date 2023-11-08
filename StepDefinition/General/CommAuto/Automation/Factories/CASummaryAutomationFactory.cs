using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CASummaryAutomationFactory : IAutomationFactory<CASummaryAutomation>
{
    private readonly CASummaryObject _caSummaryObject;

    public CASummaryAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CASummaryAutomation CreateAutomation()
    {
        return new CASummaryAutomation(_caSummaryObject);
    }
}