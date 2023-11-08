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

        IndustryQuestionPage.SmallBusInsuranceTitle.AssertElementIsVisible();
        IndustryQuestionPage.SaveUpTo20.AssertElementIsVisible();
        IndustryQuestionPage.IndustryQST.AssertElementIsVisible();
        IndustryQuestionPage.IndustryTxtbox.SetText(industryValue);
        
        if (IndustryQuestionPage.IndustrySpinner.AssertElementIsPresent(3, true))
        {
            IndustryQuestionPage.IndustrySpinner.AssertElementNotPresent();
        }
        
        IndustryQuestionPage.IndustryTxtbox.Click();
        IndustryQuestionPage.getIndustryDD(GetNormalized(industryValue)).Click();
        IndustryQuestionPage.LetsGoCTA.Click();
    }

    /// <summary>
    /// Verifies that an industry from the suggested dropdown is not present.
    /// </summary>
    /// <param name="industryValue"></param>
    public bool IsIndustryDiscontinued(string industryValue)
    {
        MadLibsSummaryObject.Keyword = industryValue;

        IndustryQuestionPage.SmallBusInsuranceTitle.AssertElementIsVisible();
        IndustryQuestionPage.SaveUpTo20.AssertElementIsVisible();
        IndustryQuestionPage.IndustryQST.AssertElementIsVisible();

        if (IndustryQuestionPage.IndustrySpinner.AssertElementIsPresent(5, true))
        {
            IndustryQuestionPage.IndustrySpinner.AssertElementNotPresent();
        }

        IndustryQuestionPage.IndustryTxtbox.SetText(industryValue);
        IndustryQuestionPage.IndustryTxtbox.Click();

        try
        {
              IndustryQuestionPage.getIndustryDD(industryValue).AssertElementIsVisible(2);
        }
        catch (System.Exception)
        {
            return true;
        }
            return false;
    }

    /// <summary>
    /// Fills out industry info for when industry is not in dropdown.
    /// </summary>
    /// <param name="industryValue"></param>
    public void EnterCustomIndustry(string industryValue)
    {
        IndustryQuestionPage.IndustryTxtbox.SetText(industryValue);
        Thread.Sleep(10000);
        if (IndustryQuestionPage.IndustrySpinner.AssertElementIsPresent(3, true))
        {
            IndustryQuestionPage.IndustrySpinner.AssertElementNotPresent();
        }
        IndustryQuestionPage.IndustryTxtbox.Click();
        IndustryQuestionPage.IndustryDD_CantFindBusiness.Click();
    }

    //for deleting their first query and tried another search; see US 102054
    public void EnterCustomSecondIndustry(string industryValue)
    {
        IndustryQuestionPage.IndustryTxtbox.SetText(industryValue);
        IndustryQuestionPage.IndustryTxtbox.ClearTextField();
        IndustryQuestionPage.IndustryTxtbox.SetText(industryValue);
        if (IndustryQuestionPage.IndustrySpinner.AssertElementIsPresent(3, true))
        {
            IndustryQuestionPage.IndustrySpinner.AssertElementNotPresent();
        }
        IndustryQuestionPage.IndustryTxtbox.Click();
        IndustryQuestionPage.IndustryDD_CantFindBusiness.Click();
    }

    public void EnterCustomIndustryDescription(string description)
    {
        //Answer the set of questions that appear once you answer you can't find your business:
        IndustryQuestionPage.WhatDoesYourBusinessDoQST.AssertElementIsVisible();
        IndustryQuestionPage.WhatDoesYourBusinessDoTxtBelow.AssertElementIsVisible();
        IndustryQuestionPage.WhatDoesYourBusinessDoTxtbox.SetText(description);
        IndustryQuestionPage.LetsGoCTA.Click();
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
        var numEmployees = int.TryParse(employeeValue, out int num) ? num : 0;
        MadLibsSummaryObject.NoOfEmp = numEmployees;
        HowManyEmpPage.HowManyEmployeesPath.AnswerForNumericResponse(numEmployees);
        if (numEmployees >= 1000) HowManyEmpPage.Over1000EmployeesModal.EnterResponse(true);
    }

    /// <summary>
    /// Chooses the location type for "Where does your business operate?"
    /// </summary>
    /// <param name="operateLocation"></param>
    public void SelectBusinessOperationLocation(string operateLocation)
    {
        MadLibsSummaryObject.Location = operateLocation;
        WhereDoesYourBusPage.WhereDoesYourBusQst.AssertElementIsVisible();
        WhereDoesYourBusPage.WhereDoesYourBusChoices.ClickChoice(operateLocation.ToLower());
        WhereDoesYourBusPage.NextCTA.Click(1000);
    }

    /// <summary>
    /// If business operates from home, answers yes/no if clients visits the home.
    /// </summary>
    /// <param name="yesOrNo">"Yes" or "No"</param>
    public void SpecifyIfClientVisitsHomeYesOrNo(string yesOrNo)
    {
        WhereDoesBus_ClientVisitHomePage.DoClientsVisitTitle.AssertElementIsVisible();
        WhereDoesBus_ClientVisitHomePage.DoClientsVisitQST.AssertElementIsVisible();

        var visitsHome = Functions.ConvertYesOrNoStringToBool(yesOrNo);
        WhereDoesBus_ClientVisitHomePage.DoClientsVisitBTNGroup.ClickChoiceFromCondition(visitsHome);
        
        WhereDoesBus_ClientVisitHomePage.NextCTA.Click();
    }

    /// <summary>
    /// Checks boxes for "Does your business own or lease any of the following?"
    /// </summary>
    /// <param name="propertyList">Semicolon-separated list of applicable options</param>
    public void ChooseOwnOrLeasedProperty(string propertyList)
    {
        WhereDoesBus_OwnLease.DoesBusOwnOrLeaseTitle.AssertElementIsVisible();
        WhereDoesBus_OwnLease.DoesBusOwnOrLeaseChboxLabel_Vehicles.AssertElementIsVisible();
        WhereDoesBus_OwnLease.DoesBusOwnOrLeaseChkboxLabel_Furniture.AssertElementIsVisible();
        WhereDoesBus_OwnLease.DoesBusOwnOrLeaseChkboxLabel_InventoryOrStock.AssertElementIsVisible();
        WhereDoesBus_OwnLease.DoesBusOwnOrLeaseChkboxLabel_ToolsOrEquip.AssertElementIsVisible();

        //if nothing is meant to be checked on this page
        if (!string.IsNullOrEmpty(propertyList))
        {
            var ownedOrLeased = Functions.ParseSemicolonSeparatedList(propertyList);
            foreach (var property in ownedOrLeased)
            {
                WhereDoesBus_OwnLease.DoesBusOwnOrLeaseChoices.ClickChoice(property);
            }
        }

        WhereDoesBus_OwnLease.NextCTA.Click();
    }

    public void EnterZipCode(string zipCodeValue)
    {
        MadLibsSummaryObject.ZipCode = zipCodeValue;
        BusinessLocationPage.WhereIsYourBusLocatedQst.AssertElementIsVisible();
        BusinessLocationPage.ZIPCodeTxtbox.SetText(zipCodeValue);
        BusinessLocationPage.NextCTA.Click();
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
        if (RecViewContext.RecommendationView == RecommendationView.Pie)
        {
            //Pie Chart page
            PieChartPage.DoesPieExist.AssertElementIsVisible();
            _pieChartAutomation.SelectLOB(lob);
        }
        else
        {
            //backup Pie Chart page
            PieChartBackupPage.RecommendCoveragesTitle.AssertElementIsVisible();
            _pieChartBackupAutomation.SelectLOB(lob);
        }
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