using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.PieChart;

public class PieChartBackupOutcomes
{
    public Element OfferedCTA { get; init; }
    public Element NotOfferedTitle { get; init; }
    public Element NotOfferedTxt { get; init; }
    public Element? NotRecommendedCTA { get; init; }

    public void AssertAvailableAndRecommended()
    {
        OfferedCTA.AssertElementIsVisible();
    }

    public void AssertAvailableAndNotRecommended()
    {
        NotOfferedTitle.AssertElementIsVisible();
        NotOfferedTxt.AssertElementIsVisible();
        NotRecommendedCTA?.AssertElementIsVisible();
    }

    public void AssertNotAvailable()
    {
        NotOfferedTitle.AssertElementIsVisible();
        NotOfferedTxt.AssertElementIsVisible();
        NotRecommendedCTA?.AssertElementNotPresent(2);
    }
}