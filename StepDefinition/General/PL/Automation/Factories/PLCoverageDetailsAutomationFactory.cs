using BiBerkLOB.Pages.PL;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.PL.Automation.Factories;

public class PLCoverageDetailsAutomationFactory : IAutomationFactory<PLCoverageDetailsAutomation>
{
    private readonly PLSummaryObject _plSummaryObject;

    public PLCoverageDetailsAutomationFactory(PLSummaryObject plSummaryObject)
    {
        _plSummaryObject = plSummaryObject;
    }

    public PLCoverageDetailsAutomation CreateAutomation()
    {
        return new PLCoverageDetailsAutomation(_plSummaryObject);
    }
}