using System;
using System.Collections.Generic;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CACoverageSection
{
    public string Name { get; init; }
    public Element Title { get; init; }
    public Element Icon { get; init; }
    public List<CACoverageDetail> Details { get; init; }

    public CACoverageSection(string name, Element title, Element icon)
    {
        Name = name;
        Title = title;
        Icon = icon;
        Details = new List<CACoverageDetail>();
    }

    public void Assert()
    {
        try
        {
            Icon.AssertElementIsVisible(1);
            Title.AssertElementIsVisible(1);
            foreach (var detail in Details)
            {
                detail.Assert();
            }
        }
        catch (Exception ex)
        {
            throw new AggregateException($"'{Name}' coverage section failed.", ex);
        }
    }
}