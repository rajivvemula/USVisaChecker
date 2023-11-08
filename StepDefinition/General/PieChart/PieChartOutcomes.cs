using BiBerkLOB.Pages;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.PieChart;

public class PieChartOutcomes
{
    public Element AvailablePieSlice { get; set; }
    public Element UnavailablePieSlice { get; set; }
    public Element SelectedPieSlice { get; set; }
    public Element WhatItIs { get; set; }
    public Element BestFor { get; set; }
    public Element Example { get; set; }
    public Element GoToPPBtn { get; set; }
    public Element NotAMatchTxt { get; set; }
    public Element? NotAMatchButAvailableBtn { get; set; }
    public Element ExpandedAvailableAccordion { get; set; }
    public Element ClosedAvailableAccordion { get; set; }
    
    public void AssertAvailableAndRecommended()
    {
        try
        {
            ExpandedAvailableAccordion.AssertElementIsVisible(2);
        }
        catch
        {
            ClosedAvailableAccordion.Click();
        }
        WhatItIs.AssertElementIsVisible();
        BestFor.AssertElementIsVisible();
        Example.AssertElementIsVisible();
    }

    public void AssertAvailableAndNotRecommended()
    {
        AssertShownInOtherSection();
        NotAMatchButAvailableBtn?.AssertElementIsVisible();
    }

    public void AssertNotAvailable()
    {
        AssertShownInOtherSection();
        NotAMatchButAvailableBtn?.AssertElementNotPresent(2);
    }

    private void AssertShownInOtherSection()
    {
        SelectedPieSlice.AssertElementNotPresent(2);
        AvailablePieSlice.AssertElementNotPresent(2);
        UnavailablePieSlice.AssertElementIsVisible();

        ExpandAndVerifyOtherSection();

        NotAMatchTxt.AssertElementIsVisible();
    }

    private static void ExpandAndVerifyOtherSection()
    {
        try
        {
            // if no issue, panel expands and renders section
            PieChartPage.NotAMatchAccordianClosed.TryClick(2);
            PieChartPage.UnableToOfferCopy.AssertElementIsVisible(4);
        }
        catch
        {
            // if here, expansion bugged out and didn't render the section
            PieChartPage.NotAMatchAccordianExpanded.TryClick(2);
            PieChartPage.NotAMatchAccordianClosed.TryClick(2);
            PieChartPage.UnableToOfferCopy.AssertElementIsVisible(8);
        }
    }
}