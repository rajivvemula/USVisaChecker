using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.Source.Helpers;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.PL.Automation.Factories;

public class PLQuickIntroAutomationFactory : IAutomationFactory<PLQuickIntroAutomation>
{
    private readonly PLSummaryObject _plSummaryObject;
    private readonly MadLibsSummaryObject _MadLibsSummaryObject;
    private readonly QuoteIDRetriever _quoteIDRetriever;

    public PLQuickIntroAutomationFactory(PLSummaryObject plSummaryObject, MadLibsSummaryObject madLibsSummaryObject, QuoteIDRetriever quoteIDRetriever)
    {
        _plSummaryObject = plSummaryObject;
        _MadLibsSummaryObject = madLibsSummaryObject;
        _quoteIDRetriever = quoteIDRetriever;
    }

    public PLQuickIntroAutomation CreateAutomation()
    {
        return new PLQuickIntroAutomation(_plSummaryObject, _MadLibsSummaryObject, _quoteIDRetriever);
    }
}