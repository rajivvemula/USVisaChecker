using System;
using System.Linq;
using System.Threading;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using Faker;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class IncidentPanelAutomation
{
    public const int INCIDENTS_UNRELIABILITY_WAIT_BUFFER_SECONDS = 6;
    public const int INCIDENTS_UNRELIABILITY_SLEEP_MILLISECONDS = 1200;

    private readonly int _panelIndex;
    private readonly DriverIncidentObject _incidentObj;

    private int _numViolationSections;

    public IncidentPanelAutomation(int panelIndex)
    {
        _panelIndex = panelIndex;
        _numViolationSections = 1;
        _incidentObj = new DriverIncidentObject()
        {
            PanelIndex = panelIndex
        };
    }

    public void SelectDriver(string driver)
    {
        CA_DriverIncidentsPage.DriverInvolvedInput(_panelIndex).AssertAllElements(8);
        CA_DriverIncidentsPage.DriverInvolvedInput(_panelIndex).EnterResponse(driver);
        _incidentObj.DriverInvolvedInIncident = driver;
    }

    public void EnterDateOfIncident(string date)
    {
        CA_DriverIncidentsPage.DateOfIncidentInput(_panelIndex).AssertAllElements(8);
        CA_DriverIncidentsPage.DateOfIncidentInput(_panelIndex).EnterResponse(date);
        _incidentObj.DateOfIncident = date;
    }

    public void SelectIncidentType(string incidentType)
    {
        CA_DriverIncidentsPage.TypeOfIncidentInput(_panelIndex).AssertAllElements(8);
        var incidentValue = MapIncidentTypeToAnswerValue(incidentType);
        CA_DriverIncidentsPage.TypeOfIncidentInput(_panelIndex).EnterResponse(incidentValue);
        _incidentObj.IncidentType = incidentType;
        // sleep here to account for temporary CA instability
        // remove with retries
        Thread.Sleep(5000);
    }

    private string MapIncidentTypeToAnswerValue(string incidentType)
    {
        switch (incidentType)
        {
            case "Accident": 
                return "Accident";
            case "Violation/Conviction": 
                return "Violation";
            case "Both": 
                return "Both";
        }

        throw new ArgumentException("Incident Types are 'Accident', 'Violation/Conviction', or 'Both'");
    }

    public void SelectAtFault(string yesOrNo)
    {
        CA_DriverIncidentsPage.WasDriverAtFaultInput(_panelIndex).AssertAllElements(8);
        
        var atFault = MapAtFaultYesNo(yesOrNo);
        CA_DriverIncidentsPage.WasDriverAtFaultInput(_panelIndex).EnterResponse(atFault);
        _incidentObj.AccidentAtFault = atFault;
    }

    private string MapAtFaultYesNo(string yesOrNo)
    {
        return Functions.ConvertYesOrNoStringToBool(yesOrNo) ? "At Fault" : "Not At Fault";
    }

    public void SelectCurrentViolationConviction(string violationConviction)
    {
        SelectViolationConviction(violationConviction, _numViolationSections);
    }
    
    public void SelectViolationConviction(string violationConviction, int oneIndexedVcNum)
    {
        var vcNum = IncidentViolationNumber.GetFromOneIndex(oneIndexedVcNum);
        CA_DriverIncidentsPage.WhatWasViolationConvictionInput(_panelIndex, vcNum).AssertAllElements(8);
        CA_DriverIncidentsPage.WhatWasViolationConvictionInput(_panelIndex, vcNum).EnterResponse(violationConviction);
        
        if (_incidentObj.VCList.Any(vc => ViolationNumberEquals(vc, vcNum)))
        {
            var index = _incidentObj.VCList.FindIndex(vc => ViolationNumberEquals(vc, vcNum));
            _incidentObj.VCList[index].Violation = violationConviction;
            return;
        }
        _incidentObj.VCList.Add(new CAViolation()
        {
            IncidentViolationNumber = vcNum,
            Violation = violationConviction
        });
    }

    public void EnterCurrentVCDescription(string description)
    {
        EnterVCDescription(description, _numViolationSections);
    }

    public void EnterVCDescription(string description, int oneIndexedVcNum)
    {
        var vcNum = IncidentViolationNumber.GetFromOneIndex(oneIndexedVcNum);
        CA_DriverIncidentsPage.DescribeViolationConvictionInput(_panelIndex, vcNum).AssertAllElements(8);
        CA_DriverIncidentsPage.DescribeViolationConvictionInput(_panelIndex, vcNum).EnterResponse(description);
        if (_incidentObj.VCList.Any(vc => ViolationNumberEquals(vc, vcNum)))
        {
            var index = _incidentObj.VCList.FindIndex(vc => ViolationNumberEquals(vc, vcNum));
            _incidentObj.VCList[index].Description = description;
            return;
        }
        
        _incidentObj.VCList.Add(new CAViolation()
        {
            IncidentViolationNumber = vcNum,
            Description = description
        });
    }

    public void SelectCurrentRecklessDrivingYesNo(string yesOrNo)
    {
        SelectRecklessDrivingYesNo(yesOrNo, _numViolationSections);
    }

    public void SelectRecklessDrivingYesNo(string yesOrNo, int oneIndexedVcNum)
    {
        var vcNum = IncidentViolationNumber.GetFromOneIndex(oneIndexedVcNum);
        CA_DriverIncidentsPage.RecklessSpeedingInput(_panelIndex, vcNum).AssertAllElements(8);
        CA_DriverIncidentsPage.RecklessSpeedingInput(_panelIndex, vcNum).EnterResponse(yesOrNo);
        if (_incidentObj.VCList.Any(vc => ViolationNumberEquals(vc, vcNum)))
        {
            var index = _incidentObj.VCList.FindIndex(vc => ViolationNumberEquals(vc, vcNum));
            _incidentObj.VCList[index].RecklessConviction = yesOrNo;
            return;
        }

        _incidentObj.VCList.Add(new CAViolation()
        {
            IncidentViolationNumber = vcNum,
            RecklessConviction = yesOrNo
        });
    }

    public void HandleCurrentAnotherVCYesNo(string yesOrNo)
    {
        HandleAnotherVCYesNo(yesOrNo, _numViolationSections);
    }

    public void HandleAnotherVCYesNo(string yesOrNo, int oneIndexedVcNum)
    {
        var currentVcNum = IncidentViolationNumber.GetFromOneIndex(oneIndexedVcNum);
        if (_incidentObj.VCList.Any(vc => ViolationNumberEquals(vc, currentVcNum)))
        {
            var index = _incidentObj.VCList.FindIndex(vc => ViolationNumberEquals(vc, currentVcNum));
            _incidentObj.VCList[index].AddAnotherVC = yesOrNo;
        }
        else
        {
            _incidentObj.VCList.Add(new CAViolation()
            {
                IncidentViolationNumber = currentVcNum,
                AddAnotherVC = yesOrNo
            });
        }

        var nextVcNum = IncidentViolationNumber.GetFromOneIndex(oneIndexedVcNum + 1);
        CA_DriverIncidentsPage.AnotherVCInput(_panelIndex, nextVcNum).AssertAllElements(8);

        if (Functions.ConvertYesOrNoStringToBool(yesOrNo))
        {
            AddAnotherVC(nextVcNum);
            return;
        }

        CA_DriverIncidentsPage.AnotherVCInput(_panelIndex, nextVcNum).EnterResponse(false);
    }

    private static bool ViolationNumberEquals(CAViolation vc, IncidentViolationNumber vcNum)
    {
        return vc.IncidentViolationNumber.ToString() == vcNum.ToString();
    }

    private void AddAnotherVC(IncidentViolationNumber nextVcNum)
    {
        CA_DriverIncidentsPage.AnotherVCInput(_panelIndex, nextVcNum).EnterResponse(true);
        _numViolationSections++;
    }

    public DriverIncidentObject GetIncidentObject()
    {
        return _incidentObj;
    }

    public void ExpandPanel()
    {
        var panelHeader = CA_DriverIncidentsPage.IncidentPanelHeader(_panelIndex);
        panelHeader.AssertElementIsVisible(1);
        if (!PanelIsExpanded(panelHeader))
        {
            panelHeader.Click(1);
        }
    }

    private static bool PanelIsExpanded(Element panelHeader)
    {
        return panelHeader.GetAttribute("class").Contains("mat-expanded");
    }
}