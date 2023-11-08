using System.Collections.Generic;
using BiBerkLOB.Pages;

namespace BiBerkLOB.StepDefinition.General.PieChart;

public class PieChartAutomation
{
    public void AssertLOBHasCorrectOutcome(string lob, string outcome)
    {
        switch (outcome)
        {
            case "Available and Recommended":
                _namedPieCharts[lob].AssertAvailableAndRecommended();
                break;
            case "Available and Not Recommended":
                _namedPieCharts[lob].AssertAvailableAndNotRecommended();
                break;
            case "Not Available":
                _namedPieCharts[lob].AssertNotAvailable();
                break;
        }
    }

    public void SelectLOB(string lob)
    {
        PieChartPage.RecommendCoveragesTitle.AssertElementIsVisible();
        PieChartPage.RecommendCoveragesSubtitle.AssertElementIsVisible();
        
        //click using the LOBvalue, click the button to start the correct LOB path
        var success = PieChartPage.getLOBbutton(lob).TryClick(3);

        if(!success)
        {
            //if the accordian is not open you can't click the button, so click open the accordian and then click the button
            PieChartPage.getAccordianByLOB(lob).Click();
            PieChartPage.getLOBbutton(lob).Click(3);
        }
    }

    private readonly Dictionary<string, PieChartOutcomes> _namedPieCharts = new()
    {
        {"WC", WCPieChart},
        {"CA", CAPieChart},
        {"PL", PLPieChart},
        {"BP", BOPPieChart},
        {"GL", GLPieChart},
    };
    private static PieChartOutcomes WCPieChart => new()
    {
        AvailablePieSlice = PieChartPage.PieWCAvailable,
        UnavailablePieSlice = PieChartPage.PieWCNotAvailable,
        SelectedPieSlice = PieChartPage.PieWCSelected,
        WhatItIs = PieChartPage.WCWhatItIs,
        BestFor = PieChartPage.WCBestFor,
        Example = PieChartPage.WCExample,
        GoToPPBtn = PieChartPage.WCGetBTN,
        NotAMatchTxt = PieChartPage.WCNotMatch,
        NotAMatchButAvailableBtn = PieChartPage.WCNotMatchButAvailableBTN,
        ExpandedAvailableAccordion = PieChartPage.WCAccordianExpanded,
        ClosedAvailableAccordion = PieChartPage.WCAccordianClosed,
    };
    private static PieChartOutcomes PLPieChart => new()
    {
        AvailablePieSlice = PieChartPage.PiePLAvailable,
        UnavailablePieSlice = PieChartPage.PiePLNotAvailable,
        SelectedPieSlice = PieChartPage.PiePLSelected,
        WhatItIs = PieChartPage.PLWhatItIs,
        BestFor = PieChartPage.PLBestFor,
        Example = PieChartPage.PLExample,
        GoToPPBtn = PieChartPage.PLGetBTN,
        NotAMatchTxt = PieChartPage.PLNotMatch,
        ExpandedAvailableAccordion = PieChartPage.PLAccordianExpanded,
        ClosedAvailableAccordion = PieChartPage.PLAccordianClosed,
    };
    private static PieChartOutcomes CAPieChart => new()
    {
        AvailablePieSlice = PieChartPage.PieCAAvailable,
        UnavailablePieSlice = PieChartPage.PieCANotAvailable,
        SelectedPieSlice = PieChartPage.PieCASelected,
        WhatItIs = PieChartPage.CAWhatItIs,
        BestFor = PieChartPage.CABestFor,
        Example = PieChartPage.CAExample,
        GoToPPBtn = PieChartPage.CAGetBTN,
        NotAMatchTxt = PieChartPage.CANotMatch,
        ExpandedAvailableAccordion = PieChartPage.CAAccordianExpanded,
        ClosedAvailableAccordion = PieChartPage.CAAccordianClosed,
    };
    private static PieChartOutcomes BOPPieChart => new()
    {
        AvailablePieSlice = PieChartPage.PieBOPAvailable,
        UnavailablePieSlice = PieChartPage.PieBOPNotAvailable,
        SelectedPieSlice = PieChartPage.PieBOPSelected,
        WhatItIs = PieChartPage.BOPWhatItIs,
        BestFor = PieChartPage.BOPBestFor,
        Example = PieChartPage.BOPExample,
        GoToPPBtn = PieChartPage.BOPGetBTN,
        NotAMatchTxt = PieChartPage.BOPNotMatch,
        NotAMatchButAvailableBtn = PieChartPage.BOPNotMatchButAvailableBTN,
        ExpandedAvailableAccordion = PieChartPage.BOPAccordianExpanded,
        ClosedAvailableAccordion = PieChartPage.BOPAccordianClosed,
    };
    private static PieChartOutcomes GLPieChart => new()
    {
        AvailablePieSlice = PieChartPage.PieGLAvailable,
        UnavailablePieSlice = PieChartPage.PieGLNotAvailable,
        SelectedPieSlice = PieChartPage.PieGLSelected,
        WhatItIs = PieChartPage.GLWhatItIs,
        BestFor = PieChartPage.GLBestFor,
        Example = PieChartPage.GLExample,
        GoToPPBtn = PieChartPage.GLGetBTN,
        NotAMatchTxt = PieChartPage.GLNotMatch,
        NotAMatchButAvailableBtn = PieChartPage.GLNotMatchButAvailableBTN, /////////
        ExpandedAvailableAccordion = PieChartPage.GLAccordianExpanded,
        ClosedAvailableAccordion = PieChartPage.GLAccordianClosed,
    };
}