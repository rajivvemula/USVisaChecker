using System;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

public class IncidentViolationNumber
{
    private string _numSuffix;

    private IncidentViolationNumber(string numSuffix)
    {
        _numSuffix = numSuffix;
    }

    public override string ToString()
    {
        return _numSuffix;
    }

    public static IncidentViolationNumber GetFromZeroIndex(int zeroIndex)
    {
        switch (zeroIndex)
        {
            case 0:
                return First;
            case 1:
                return Second;
            case 2:
                return Third;
            case 3:
                return Fourth;
            case 4:
                return Fifth;
            case 5:
                return Sixth;
            default: throw new ArgumentException("There can only be a max of 6 violations");
        }
    }

    public static IncidentViolationNumber GetFromOneIndex(int oneIndex)
    {
        switch (oneIndex)
        {
            case 1:
                return First;
            case 2:
                return Second;
            case 3:
                return Third;
            case 4:
                return Fourth;
            case 5:
                return Fifth;
            case 6:
                return Sixth;
            default: throw new ArgumentException("There can only be a max of 6 violations");
        }
    }

    public int OrderByValue => _numSuffix == "" ? 1 : int.Parse(_numSuffix);

    public static IncidentViolationNumber First => new IncidentViolationNumber("");
    public static IncidentViolationNumber Second => new IncidentViolationNumber("2");
    public static IncidentViolationNumber Third => new IncidentViolationNumber("3");
    public static IncidentViolationNumber Fourth=> new IncidentViolationNumber("4");
    public static IncidentViolationNumber Fifth => new IncidentViolationNumber("5");
    public static IncidentViolationNumber Sixth => new IncidentViolationNumber("6");
}