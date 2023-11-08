using System;

namespace BiBerkLOB.Pages.Other;

/// <summary>
/// Identifies a mapping with a name for the page to be used by the Scenario
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class MappingAttribute : Attribute
{
    public string Name { get; private set; }

    public MappingAttribute(string name)
    {
        Name = name;
    }
}


/// <summary>
/// Identifies a mapping with a name for the static pages
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class StaticPageNameAttribute : MappingAttribute
{
    public StaticPageNameAttribute(string name) : base(name)
    { }
}

/// <summary>
/// Identifies a method in static page that can map an integer to an element with indexed data-qa attributes
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
class IndexRangeAttribute : Attribute
{
    public int Minimum { get; private set; }
    public int Maximum { get; private set; }

    public IndexRangeAttribute(int minimum, int maximum)
    {
        Minimum = minimum;
        Maximum = maximum;
    }
}