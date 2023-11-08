using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using HitachiQA.Helpers;
using OpenQA.Selenium;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class DriverPanelAutomation
{
    private readonly int _panelIndex;
    private readonly DriversObject _localDriversObject;

    private State _dlState;

    public DriverPanelAutomation(int panelIndex)
    {
        _localDriversObject = new DriversObject();
        _panelIndex = panelIndex;
    }

    public void EnterFirstName(string firstName)
    {
        CA_DriversPage.FirstNameInput(_panelIndex).AssertAllElements();
        CA_DriversPage.FirstNameInput(_panelIndex).EnterResponse(firstName);
        _localDriversObject.DriverFirstName = firstName;
    }

    public void EnterLastName(string lastName)
    {
        CA_DriversPage.LastNameInput(_panelIndex).AssertAllElements();
        CA_DriversPage.LastNameInput(_panelIndex).EnterResponse(lastName);
        _localDriversObject.DriverLastName = lastName;
    }

    public void SelectState(string tableValue)
    {
        CA_DriversPage.DriversLicenseStateInput(_panelIndex).AssertAllElements();
        _dlState = State.FromAny(tableValue);
        CA_DriversPage.DriversLicenseStateInput(_panelIndex).EnterResponse(_dlState.Name);
        _localDriversObject.DriversLicenseState = _dlState;
    }

    public void EnterDateOfBirth(string dob)
    {
        CA_DriversPage.DOBInput(_panelIndex).AssertAllElements();
        CA_DriversPage.DOBInput(_panelIndex).EnterResponse(dob);
        _localDriversObject.DateOfBirth = dob;
    }

    public void SelectCDL(string hasCdl)
    {
        CA_DriversPage.DriverHaveCDLInput(_panelIndex).AssertAllElements();
        CA_DriversPage.DriverHaveCDLInput(_panelIndex).EnterResponse(hasCdl);
        _localDriversObject.DriverCDL = hasCdl;
    }

    public void SaveNSCDrivingCourseYesOrNo(string yesOrNo)
    {
        CA_DriversPage.NSCDDCourseInput(_panelIndex).AssertAllElements();
        CA_DriversPage.NSCDDCourseInput(_panelIndex).EnterResponse(yesOrNo);
        _localDriversObject.DriverDefDrivingCourse = yesOrNo;
    }

    public void SaveILViolationsYesOrNo(string yesOrNo)
    {
        CA_DriversPage.ILViolationInput(_panelIndex).AssertAllElements();
        CA_DriversPage.ILViolationInput(_panelIndex).EnterResponse(yesOrNo);
        _localDriversObject.DriverILViolations = yesOrNo;
    }

    public void SaveILRevokedYesOrNo(string yesOrNo)
    {
        CA_DriversPage.ILDLRevokedInput(_panelIndex).AssertAllElements();
        CA_DriversPage.ILDLRevokedInput(_panelIndex).EnterResponse(yesOrNo);
        _localDriversObject.DriverILDLRevoked = yesOrNo;
    }

    public void SelectAccidentViolationConvictionYesNo(string yesOrNo)
    {
        CA_DriversPage.DriverHaveAccidentOrViolationInput(_panelIndex).AssertAllElements();
        CA_DriversPage.DriverHaveAccidentOrViolationInput(_panelIndex).EnterResponse(yesOrNo);
        _localDriversObject.AccidentOrVIolation = yesOrNo;
    }

    public void EnterDLN(string dln)
    {
        _localDriversObject.DriverLicenseNumber = dln;
        CA_DriversPage.DriversLicenseNumberInput(_dlState.Abbreviation, _panelIndex).AssertAllElements();
        CA_DriversPage.DriversLicenseNumberInput(_dlState.Abbreviation, _panelIndex).EnterResponse(dln);
    }

    public DriversObject GetDriverObject()
    {
        return _localDriversObject;
    }
}