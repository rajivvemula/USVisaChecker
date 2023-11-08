namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

public class VehicleType
{
    public VehicleCategory Category { get; private set; }
    public string SubCategory { get; private set; }

    public VehicleType(string code)
    {
        var splitCode = code.Split('-');
        Category = VehicleCategory.Parse(splitCode[0]);
        SubCategory = splitCode[1];
    }

    public override string ToString()
    {
        return $"{Category.Code}-{SubCategory}";
    }
}