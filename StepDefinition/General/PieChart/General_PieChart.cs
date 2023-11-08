using BiBerkLOB.Pages;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.PieChart
{
    [Binding]
    public sealed class General_PieChart
    {
        private readonly PieChartAutomation _pieChartAutomation;

        public General_PieChart()
        {
            _pieChartAutomation = new PieChartAutomation();
        }

        /*
         * Handle in depth evaluation of LOBs available and where they are present on the page
         */
        [Given(@"seeks to validate the Pie Chart Page with:")]
        public void GivenUserStartsQuoteToValidatePieChartPage(Table table)
        {
            //check the appearance of the title and subtitle on the page
            PieChartPage.RecommendCoveragesTitle.AssertElementIsVisible();
            PieChartPage.RecommendCoveragesSubtitle.AssertElementIsVisible();

            foreach (TableRow row in table.Rows)
            {
                var lob = row["LOB"];
                var status = row["Status"];
                _pieChartAutomation.AssertLOBHasCorrectOutcome(lob, status);
            }
        }
    }
}
