using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.PieChart;

public class PieChartAutomationFactory : IAutomationFactory<PieChartAutomation>
{
    public PieChartAutomation CreateAutomation()
    {
        return new PieChartAutomation();
    }
}