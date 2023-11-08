namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

public class CACoverage
{
    public string CoverageName { get; init; }
    public string CoverageDetails { get; init; }

    public CACoverage(string coverageName, string coverageDetails)
    {
        CoverageName = coverageName;
        CoverageDetails = coverageDetails;
    }
}