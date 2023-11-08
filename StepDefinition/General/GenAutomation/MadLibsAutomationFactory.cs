using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.StepDefinition.General.PieChart;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.GenAutomation;

public class MadLibsAutomationFactory : IAutomationFactory<MadLibsAutomation>
{
    private MadLibsSummaryObject _madLibsSummaryObject;
    private RecommendationViewContext _recViewContext;
    private PieChartAutomationFactory _pieChartFactory;
    private PieChartBackupAutomationFactory _pieChartBackupFactory;

    public MadLibsAutomationFactory(MadLibsSummaryObject madLibsSummaryObject, RecommendationViewContext recViewContext, 
        PieChartAutomationFactory pieChartFactory, PieChartBackupAutomationFactory pieChartBackupFactory)
    {
        _madLibsSummaryObject = madLibsSummaryObject;
        _recViewContext = recViewContext;
        _pieChartFactory = pieChartFactory;
        _pieChartBackupFactory = pieChartBackupFactory;
    }

    public MadLibsAutomation CreateAutomation()
    {
        return new MadLibsAutomation(_madLibsSummaryObject, _recViewContext, _pieChartFactory.CreateAutomation(), _pieChartBackupFactory.CreateAutomation());
    }
}