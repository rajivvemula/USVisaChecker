using BiBerkLOB.Pages.Other;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.CommAuto;

[Mapping("CA Reusable")]
public class CA_ReusableElements
{
    public static Element InflightStatusElement => new Element(By.XPath("//bb-inflight-status/div"));
    
    //progress bar after entering an address with smarty streets integration
    public static Element AddressProgressBar => new Element(By.XPath("//div[starts-with(@class,'mat-progress-bar-primary')]"));

    // error message 
    public static Element OneOrMoreQuestionsTxt => new Element(By.XPath("//div[@data-qa='bbnav-error-message']"));
    public static Element FirstErrorMsg => new Element(By.XPath("(//mat-error)[1]"));
    }