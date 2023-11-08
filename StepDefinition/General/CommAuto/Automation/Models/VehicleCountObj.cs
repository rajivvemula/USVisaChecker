using HitachiQA;
using System.ComponentModel;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

[ResettableContextObject]
public class VehicleCountObj
{
    [DefaultValue(1)] public int VehicleCount { get; private set; } = 1;

    public void Increment()
    {
        VehicleCount++;
    }

    public override string ToString()
    {
        return VehicleCount.ToString();
    }
}