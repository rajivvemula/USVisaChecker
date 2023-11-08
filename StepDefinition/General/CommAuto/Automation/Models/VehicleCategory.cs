using System.Linq;
using System.Reflection;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

public class VehicleCategory
{
    public string Code { get; private set; }
    public string Label { get; private set; }

    private VehicleCategory(string code, string label)
    {
        Code = code;
        Label = label;
    }

    public static VehicleCategory Parse(string code)
    {
        var values = typeof(VehicleCategory).GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Select(prop => (VehicleCategory)prop.GetValue(null));

        return values.Single(cat => cat.Code == code);
    }

    public static VehicleCategory CS => new VehicleCategory("CS", "Cars or SUV");
    public static VehicleCategory TRK => new VehicleCategory("TRK", "Trucks");
    public static VehicleCategory VAN => new VehicleCategory("VAN", "Vans");
    public static VehicleCategory OTH => new VehicleCategory("OTH", "Other");
    public static VehicleCategory TRL => new VehicleCategory("TRL", "Trailers");
    public static VehicleCategory STRL => new VehicleCategory("STRL", "Trailers");
}