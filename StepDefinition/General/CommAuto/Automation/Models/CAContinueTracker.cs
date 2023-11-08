using HitachiQA;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

[ResettableContextObject]
public class CAContinueTracker
{
    public Element CurrentContinueButton { get; set; }
}