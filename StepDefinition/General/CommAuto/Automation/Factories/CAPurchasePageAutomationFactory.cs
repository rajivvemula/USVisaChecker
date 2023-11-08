using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CAPurchasePageAutomationFactory : IAutomationFactory<CAPurchasePageAutomation>
{
    private readonly CASummaryObject _caSummaryObject;

    public CAPurchasePageAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CAPurchasePageAutomation CreateAutomation()
    {
        return new CAPurchasePageAutomation(_caSummaryObject);
    }
}