using BiBerkLOB.Pages.PL;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.PL.Automation.Factories;

public class PLBusinessDetailsAutomationFactory : IAutomationFactory<PLBusinessDetailsAutomation>
{
    private readonly PLSummaryObject _plSummaryObject;

    public PLBusinessDetailsAutomationFactory(PLSummaryObject plSummaryObject)
    {
        _plSummaryObject = plSummaryObject;
    }

    public PLBusinessDetailsAutomation CreateAutomation()
    {
        return new PLBusinessDetailsAutomation(_plSummaryObject);
    }
}