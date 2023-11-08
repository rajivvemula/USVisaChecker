using BiBerkLOB.Pages.CommAuto;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CACoverageDetailsAutomationFactory : IAutomationFactory<CACoverageDetailsAutomation>
{
    private readonly CASummaryObject _caSummaryObject;

    public CACoverageDetailsAutomationFactory(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public CACoverageDetailsAutomation CreateAutomation()
    {
        return new CACoverageDetailsAutomation(_caSummaryObject);
    }
}