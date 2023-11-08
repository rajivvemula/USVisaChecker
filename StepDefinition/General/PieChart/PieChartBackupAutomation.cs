using System.Collections.Generic;
using System.Threading;
using BiBerkLOB.Pages;

namespace BiBerkLOB.StepDefinition.General.PieChart;

public class PieChartBackupAutomation
{
    public void AssertLOBHasCorrectOutcome(string lob, string outcome)
    {
        switch (outcome)
        {
            case "Available and Recommended":
                _namedPieChartBackups[lob].AssertAvailableAndRecommended();
                break;
            case "Available and Not Recommended":
                _namedPieChartBackups[lob].AssertAvailableAndNotRecommended();
                break;
            case "Not Available":
                _namedPieChartBackups[lob].AssertNotAvailable();
                break;

        }
    }

    public void SelectLOB(string lob)
    {
        PieChartBackupPage.RecommendCoveragesTitle.AssertElementIsVisible();
        PieChartBackupPage.RecommendCoveragesSubtitle.AssertElementIsVisible();

        //click using the LOB value, click the button to start the correct LOB path
        var clickSuccess = _namedPieChartBackups[lob].OfferedCTA.TryClick(3);
        if (!clickSuccess)
        {
            //if the LOB is not recommended, click the not recommended button.
            _namedPieChartBackups[lob].NotRecommendedCTA?.Click(3);
        }
    }

    //LOB PieChartBackup groupings
    private readonly Dictionary<string, PieChartBackupOutcomes> _namedPieChartBackups = new()
    {
        {"WC", WCPieChartBackup},
        {"PL", PLPieChartBackup},
        {"BP", BPPieChartBackup},
        {"GL", GLPieChartBackup},
        {"CA", CAPieChartBackup},
    };
    private static PieChartBackupOutcomes WCPieChartBackup => new()
    {
        OfferedCTA = PieChartBackupPage.WCOfferedCTA,
        NotOfferedTitle = PieChartBackupPage.WCNotMatchHeader,
        NotOfferedTxt = PieChartBackupPage.WCNotMatchTxt,
        NotRecommendedCTA = PieChartBackupPage.WCNotMatchCTA
    };
    private static PieChartBackupOutcomes PLPieChartBackup => new()
    {
        OfferedCTA = PieChartBackupPage.PLOfferedCTA,
        NotOfferedTitle = PieChartBackupPage.PLNotOfferedTitle,
        NotOfferedTxt = PieChartBackupPage.PLNotOfferedTxt
    };
    private static PieChartBackupOutcomes BPPieChartBackup => new()
    {
        OfferedCTA = PieChartBackupPage.BPOfferedCTA,
        NotOfferedTitle = PieChartBackupPage.BPNotOfferedTitle,
        NotOfferedTxt = PieChartBackupPage.BPNotOfferedTxt,
        NotRecommendedCTA = PieChartBackupPage.BPNotOfferedCTA
    };
    private static PieChartBackupOutcomes GLPieChartBackup => new()
    {
        OfferedCTA = PieChartBackupPage.GLOfferedCTA,
        NotOfferedTitle = PieChartBackupPage.GLNotMatchHeader,
        NotOfferedTxt = PieChartBackupPage.GLNotMAtchTxt,
        NotRecommendedCTA = PieChartBackupPage.GLNotMatchCTA
    };
    private static PieChartBackupOutcomes CAPieChartBackup => new()
    {
        OfferedCTA = PieChartBackupPage.CAOfferedCTA,
        NotOfferedTitle = PieChartBackupPage.CANotOfferedTitle,
        NotOfferedTxt = PieChartBackupPage.CANotOfferedTxt
    };
}