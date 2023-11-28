using System.Collections.Generic;
using BiBerkLOB.Pages;

namespace BiBerkLOB.StepDefinition.General.PieChart;

public class PieChartAutomation
{
    public void AssertLOBHasCorrectOutcome(string lob, string outcome)
    {

    }

    public void SelectLOB(string lob)
    {
        PieChartPage.RecommendCoveragesTitle.AssertElementIsVisible();
        PieChartPage.RecommendCoveragesSubtitle.AssertElementIsVisible();

        //click using the LOBvalue, click the button to start the correct LOB path
        var success = PieChartPage.getLOBbutton(lob).TryClick(3);

        if (!success)
        {
            //if the accordian is not open you can't click the button, so click open the accordian and then click the button
            PieChartPage.getAccordianByLOB(lob).Click();
            PieChartPage.getLOBbutton(lob).Click(3);
        }

    }
}