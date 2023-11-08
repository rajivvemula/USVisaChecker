using System.Collections.Generic;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Source.Driver.SimpleInteractions;

public class InsuranceProductsTabs : IStaticInteraction
{
    private Dictionary<Element, Element[]> _sections;
    public InsuranceProductsTabs(params Element[] tabs)
    {
        _sections = new Dictionary<Element, Element[]>();
        foreach (var tab in tabs)
        {
            _sections.Add(tab, null);
        }
    }

    public InsuranceProductsTabs SetTabSections(Element tab, params Element[] elements)
    {
        _sections[tab] = elements;
        return this;
    }

    public void ValidateInteraction(int waitSeconds = StaticConstants.DEFAULT_INTERACTION_SECONDS)
    {
        foreach (var (tab, elements) in _sections)
        {
            tab.AssertElementIsVisible(waitSeconds);
            tab.Click(waitSeconds);

            foreach (var element in elements)
            {
                element.AssertElementIsVisible(waitSeconds);
            }
        }
    }
}