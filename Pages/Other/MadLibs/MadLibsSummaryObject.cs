using HitachiQA;

namespace BiBerkLOB.Pages.Other.MadLibs;

[ResettableContextObject]
public class MadLibsSummaryObject
{ 
    public string Keyword { get; set; }
    public int NoOfEmp { get; set; }
    public string LOB { get; set; }
    public string ZipCode { get; set; }
    public string Location { get; set; }
}