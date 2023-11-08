using BiBerkLOB.Pages;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.PieChart
{
    [Binding]
    class General_PieChartBackup
    {
        private readonly PieChartBackupAutomation _pieChartBackupAutomation;
        public General_PieChartBackup()
        {
            _pieChartBackupAutomation = new PieChartBackupAutomation();
        }

        /*
         * Handle in depth evaluation of LOBs available and where they are present on the page
         */
        [Given(@"seeks to validate the backup Pie Chart Page with:")]
        public void GivenUserStartsQuoteToValidateBackupPieChartPage(Table table)
        {
            //check the appearance of the title and subtitle on the page
            PieChartBackupPage.RecommendCoveragesTitle.AssertElementIsVisible();
            PieChartBackupPage.RecommendCoveragesSubtitle.AssertElementIsVisible();

            foreach (TableRow rowy in table.Rows)
            {
                var lob = rowy["LOB"];
                var status = rowy["Status"];
                _pieChartBackupAutomation.AssertLOBHasCorrectOutcome(lob, status);
            }
        }
    }
}
