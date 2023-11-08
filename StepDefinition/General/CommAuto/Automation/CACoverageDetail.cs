using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CACoverageDetail
{
    public Element Header { get; init; }
    public Element Body { get; init; }

    public CACoverageDetail(Element header, Element body)
    {
        Header = header;
        Body = body;
    }

    public void Assert()
    {
        Header.AssertElementIsVisible(1);
        Body.AssertElementIsVisible(1);
    }
}