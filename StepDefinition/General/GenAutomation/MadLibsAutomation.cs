using BiBerkLOB.Pages;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.PieChart;
using HitachiQA;
using HitachiQA.Helpers;
using System.Threading;
using System.Text.RegularExpressions;

namespace BiBerkLOB.StepDefinition.General.GenAutomation;

public class MadLibsAutomation
{
    private readonly PieChartAutomation _pieChartAutomation;
    private readonly PieChartBackupAutomation _pieChartBackupAutomation;

    public MadLibsSummaryObject MadLibsSummaryObject { get; set; }
    public RecommendationViewContext RecViewContext { get; set; }

    public MadLibsAutomation(MadLibsSummaryObject madLibsSummaryObject, RecommendationViewContext recViewContext, 
        PieChartAutomation pieChartAutomation, PieChartBackupAutomation pieChartBackupAutomation)
    {
        MadLibsSummaryObject = madLibsSummaryObject;
        RecViewContext = recViewContext;
        _pieChartAutomation = pieChartAutomation;
        _pieChartBackupAutomation = pieChartBackupAutomation;
    }

    private string GetNormalized(string unNormolized)
    {
        //Looking for words non-profit, non profit,  non emergency and non-emergency in an indusrty name 
        //and replacing them with Nonprofit and Nonemergency
        string result = Regex.Replace(unNormolized, "^[N,n]on[\\s|-][P,p]rofit", "Nonprofit:");
        result = Regex.Replace(result, "^[N,n]on[\\s|-][E,e]mergency", "Nonemergency");

        return result;
    }

    /// <summary>
    /// Picks an industry from the suggested dropdown.
    /// </summary>
    /// <remarks>
    /// If the industry is not in the dropdown, use EnterCustomIndustry()
    /// </remarks>
    /// <param name="industryValue"></param>
    public void SelectIndustry(string industryValue)
    {
        MadLibsSummaryObject.Keyword = industryValue;                 

        
    }

    /// <summary>
    /// Verifies that an industry from the suggested dropdown is not present.
    /// </summary>
    /// <param name="industryValue"></param>
    public bool IsIndustryDiscontinued(string industryValue)
    {
        MadLibsSummaryObject.Keyword = industryValue;
        return true;
    }

    /// <summary>
    /// Fills out industry info for when industry is not in dropdown.
    /// </summary>
    /// <param name="industryValue"></param>
    public void EnterCustomIndustry(string industryValue)
    {
       
    }

    //for deleting their first query and tried another search; see US 102054
    public void EnterCustomSecondIndustry(string industryValue)
    {
        
    }

    public void EnterCustomIndustryDescription(string description)
    {
        
    }

    /// <summary>
    /// Answers the yes/no to "Do you have any employees?"<br/>
    /// and specified number of employees.
    /// </summary>
    /// <param name="employeeValue">
    /// The number of employees
    /// </param>
    public void SelectNumberOfEmployees(string employeeValue)
    {
        
    }

    /// <summary>
    /// Chooses the location type for "Where does your business operate?"
    /// </summary>
    /// <param name="operateLocation"></param>
    public void SelectBusinessOperationLocation(string operateLocation)
    {
    }

    /// <summary>
    /// If business operates from home, answers yes/no if clients visits the home.
    /// </summary>
    /// <param name="yesOrNo">"Yes" or "No"</param>
    public void SpecifyIfClientVisitsHomeYesOrNo(string yesOrNo)
    {
    }

    /// <summary>
    /// Checks boxes for "Does your business own or lease any of the following?"
    /// </summary>
    /// <param name="propertyList">Semicolon-separated list of applicable options</param>
    public void ChooseOwnOrLeasedProperty(string propertyList)
    {
    }

    public void EnterZipCode(string zipCodeValue)
    {
    }

    /// <summary>
    /// Selects LOB at end of quote path and navigates to their purchase path.
    /// </summary>
    /// <param name="lob">
    /// LOB value needs to be a two letter abbreviation of the lob<br/>
    /// so BOP should be entered as "BP"
    /// </param>
    public void SelectLOB(string lob)
    {
        MadLibsSummaryObject.LOB = lob;
    }

    /// <summary>
    /// Verifies the Madlibs path
    /// For some Landing pages we assert backup pie chart and for few we assert regular pie chart
    /// </summary>
    public void VerifyMadlibsPathWithRecommendationViewByLOB(string view, string availability, string lob)
    {
        switch (view.ToLower())
        {
            case "pie":
                _pieChartAutomation.AssertLOBHasCorrectOutcome(availability, lob);
                break;
            case "simple":
                _pieChartBackupAutomation.AssertLOBHasCorrectOutcome(availability, lob);
                break;
            default:
                Log.Info($"User landed on Incorrect View: {view}");
                break;
        }
    }
}