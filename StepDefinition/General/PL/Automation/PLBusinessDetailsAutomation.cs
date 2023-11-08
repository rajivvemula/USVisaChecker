using System;
using BiBerkLOB.Components.PL;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.PL.Automation;

public class PLBusinessDetailsAutomation
{
    private PLSummaryObject _plSummaryObject;

    public PLBusinessDetailsAutomation(PLSummaryObject plSummaryObject)
    {
        _plSummaryObject = plSummaryObject;
    }

    public void EnterBusinessYearStarted(string year)
    {
        PL_BusinessDetailsPage.WhatYearBusStartQuestion.AssertAllElements();
        PL_BusinessDetailsPage.WhatYearBusStartQuestion.EnterResponse(year);
        _plSummaryObject.YearBusStarted = year;
    }

    public void EnterGrossAnnualRevenue(string revenue)
    {
        PL_BusinessDetailsPage.EstGrossRevQuestion.AssertAllElements();
        PL_BusinessDetailsPage.EstGrossRevQuestion.EnterResponse(revenue);
        _plSummaryObject.GrossRev = revenue;
    }

    public void ChooseContractOption(string contractOption)
    {
        PL_BusinessDetailsPage.UseSOWQuestion.AssertAllElements();
        PL_BusinessDetailsPage.UseSOWQuestion.EnterResponse(contractOption);
        _plSummaryObject.SOW = contractOption;
    }

    public void EnterNumAttorneys(string numAttorneys)
    {
        PL_BusinessDetailsPage.HowManyAttorneysQuestion.AssertAllElements();
        PL_BusinessDetailsPage.HowManyAttorneysQuestion.EnterResponse(numAttorneys);
        _plSummaryObject.HowManyAttorneys = numAttorneys;
    }

    public void SpecifyCounselContractAttorneyYesOrNo(string yesOrNo)
    {
        PL_BusinessDetailsPage.UseCounselOrIndepContrAttorneysQuestion.AssertAllElements();
        var isYes = Functions.ConvertYesOrNoStringToBool(yesOrNo);
        PL_BusinessDetailsPage.UseCounselOrIndepContrAttorneysQuestion.EnterResponse(isYes);

        if (isYes)
        {
            _plSummaryObject.ContractAttorneys = "You currently use of counsel or independent contractor attorneys.";
        }
    }

    public void EnterNumFullTimeAttorneys(string numFullTime)
    {
        PL_BusinessDetailsPage.FullTimeCounselIndepContrAttorneysQuestion.AssertAllElements();
        PL_BusinessDetailsPage.FullTimeCounselIndepContrAttorneysQuestion.EnterResponse(numFullTime);
        _plSummaryObject.FTCounselIndepenAttorneys = numFullTime;
    }

    public void EnterNumPartTimeAttorneys(string numPartTime)
    {
        PL_BusinessDetailsPage.PartTimeCounselIndepContrAttorneysQuestion.AssertAllElements();
        PL_BusinessDetailsPage.PartTimeCounselIndepContrAttorneysQuestion.EnterResponse(numPartTime);
        _plSummaryObject.PTCounselIndepenAttorneys = numPartTime;
    }

    public void ChooseWhoSignsTermsAndConditions(string whoSigns)
    {
        PL_BusinessDetailsPage.WhoSignsSOWQuestion.AssertAllElements();
        PL_BusinessDetailsPage.WhoSignsSOWQuestion.EnterResponse(whoSigns);
        _plSummaryObject.SignOffWrittenContracts = GetSummaryStringForSignOff(whoSigns);
    }

    private static string GetSummaryStringForSignOff(string whoSigns)
    {
        switch (whoSigns)
        {
            case "Outside":
                return "Outside Legal Counsel";
            case "In House":
                return "In–house Legal Counsel";
            case "Legal":
                return "Legal Counsel is not required";
            default:
                throw new ArgumentException("not a valid option for 'Who signs off on the terms & conditions for written contracts or statements of work (SOW)?'");
        }
    }

    public void EnterNumHealthcareProfessionals(string numProfessionals)
    {
        PL_BusinessDetailsPage.HowManyHealthProfQuestion.AssertAllElements();
        PL_BusinessDetailsPage.HowManyHealthProfQuestion.EnterResponse(numProfessionals);
        _plSummaryObject.HowManyHealthProf = numProfessionals;
    }
    
    public void SpecifyNumHealthStudents(string numStudents)
    {
        var numberResponse = int.Parse(numStudents);
        PL_BusinessDetailsPage.AnyHealthStudentSection.AnswerForNumericResponse(numberResponse);
        
        if(numberResponse > 0)
        {
            _plSummaryObject.AnyHealthStudents = "You currently do have health students work for your business.";
            _plSummaryObject.NumOfHealthStudents = numStudents;
        }
        else
        {
            _plSummaryObject.AnyHealthStudents = "You currently do not have health students work for your business";
        }
    }

    public void ChooseIndependentContractorOrEmployee(string option)
    {
        PL_BusinessDetailsPage.ContractorOrEmployeeQuestion.AssertAllElements();
        PL_BusinessDetailsPage.ContractorOrEmployeeQuestion.EnterResponse(option);
        
        if (option == "Independent Contractor")
        {
            _plSummaryObject.HealthContractorOrEmployee = "You currently work as an independent contractor (paid via 1099).";
        }
        else
        {
            _plSummaryObject.HealthContractorOrEmployee = "You currently work as an employee of a health organization (paid via W-2).";
        }
    }

    public void ChooseHealthcareLastTwoYearsYesOrNo(string yesOrNo)
    {
        PL_BusinessDetailsPage.HealthCareDesignationQuestion.AssertAllElements();
        var isYes = Functions.ConvertYesOrNoStringToBool(yesOrNo);
        PL_BusinessDetailsPage.HealthCareDesignationQuestion.EnterResponse(isYes);
        var maybeNot = isYes ? " " : " not ";
        var designation = $"You currently have{maybeNot}obtained this professional healthcare designation within the last two years.";
        _plSummaryObject.HealthCareDesignationWithin2Years = designation;
    }

    public void PickDateForDesignation(string dateString)
    {
        string designationDate;
        if (dateString == "")
        {
            designationDate = Functions.GetDifferentDateFromNow(-1, "d").ToString("MM/dd/yyyy");
        }
        else
        {
            designationDate = dateString;
        }
        PL_BusinessDetailsPage.HCDesignationDateQuestion.AssertAllElements();
        PL_BusinessDetailsPage.HCDesignationDateQuestion.EnterResponse(designationDate);
        _plSummaryObject.HealthCareDesignationDate = designationDate;
    }
}