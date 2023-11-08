namespace BiBerkLOB.Source.Helpers.LegacyModels;

public class ZipCodeResponse
{
    public object TOperationStatus { get; set; }
    public CityStateZipModel[] TCityStateZipCodes { get; set; }
}

public class CityStateZipModel
{
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string FIPS { get; set; }
    public string Name { get; set; }
}