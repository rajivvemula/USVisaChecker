using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.PieChart;

public class PieChartBackupAutomationFactory : IAutomationFactory<PieChartBackupAutomation>
{
    public PieChartBackupAutomation CreateAutomation()
    {
        return new PieChartBackupAutomation();
    }
}