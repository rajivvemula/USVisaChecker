using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Driver;
using HitachiQA.Helpers;

namespace BiBerkLOB.Source.Driver.SimpleInteractions;

public class AccordionSection : IStaticInteraction
{
    private Element _label;
    private Element _dropDown;
    private Element[] _sectionElements;

    public AccordionSection(Element label, Element dropDown, params Element[] sectionElements)
    {
        _label = label;
        _dropDown = dropDown;
        _sectionElements = sectionElements;
    }

    public void ValidateInteraction(int waitSeconds = StaticConstants.DEFAULT_INTERACTION_SECONDS)
    {
        _label.AssertElementIsVisible(waitSeconds);
        _dropDown.AssertElementIsVisible(waitSeconds);
        _dropDown.Click(waitSeconds);
        AutomationHelper.ValidateElements(_sectionElements, waitSeconds);
    }
}