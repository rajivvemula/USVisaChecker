using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CAQuickIntroAutomationFactory : IAutomationFactory<CAQuickIntroAutomation>
{
    private readonly CASummaryObject _caSummaryObject;

    public CAQuickIntroAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CAQuickIntroAutomation CreateAutomation()
    {
        return new CAQuickIntroAutomation(_caSummaryObject);
    }
}