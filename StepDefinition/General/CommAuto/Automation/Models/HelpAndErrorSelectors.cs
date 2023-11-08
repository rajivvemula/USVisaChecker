using System;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

public class HelpAndErrorSelectors
{
    public Func<string, Element> ErrorTextSelector { get; set; }
    public Func<string, Element> HelpIconSelector { get; set; }
    public Func<string, Element> HelpTextSelector { get; set; }
    public Func<string, Element> HelpExitSelector { get; set; }
}