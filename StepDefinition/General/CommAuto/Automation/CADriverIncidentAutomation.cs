using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Helpers;
using System.Collections.Generic;
using System.Linq;
using BiBerkLOB.Pages;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CADriverIncidentAutomation
{
    private readonly CASummaryObject _caSummaryObject;
    private List<IncidentPanelAutomation> _incidents;

    public CADriverIncidentAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
        _incidents = new List<IncidentPanelAutomation>();
        Reset();
    }

    public void Reset()
    {
        _caSummaryObject.DriverIncidentList.Clear();
        _incidents.Clear();
        _incidents.Add(new IncidentPanelAutomation(0));
    }

    public IncidentPanelAutomation GetIncident(int index)
    {
        return _incidents[index];
    }

    public void SaveIncidentObject(int incidentIndex)
    {
        var incident = GetIncident(incidentIndex);
        var incidentObj = incident.GetIncidentObject();
        if (_caSummaryObject.DriverIncidentList.Any(obj => obj.PanelIndex == incidentIndex))
        {
            var listIndex = _caSummaryObject.DriverIncidentList.FindIndex(obj => obj.PanelIndex == incidentIndex);
            _caSummaryObject.DriverIncidentList[listIndex] = incidentObj;
            return;
        }
        _caSummaryObject.DriverIncidentList.Add(incidentObj);
    }

    public void SaveCurrentIncidentObject()
    {
        SaveIncidentObject(_incidents.Count - 1);
    }

    public void ContinueToNextPage()
    {
        CA_DriverIncidentsPage.LetsContinueCTA.Click();
        AutomationHelper.WaitForLoading();
    }

    public void AddAnotherIncident()
    {
        CA_DriverIncidentsPage.AddAccidentViolationConvictionBTN.Click();
        var nextIncidentIndex = _incidents.Count;
        _incidents.Add(new IncidentPanelAutomation(nextIncidentIndex));
    }

    public void ValidateStepper()
    {
        AutomationHelper.ValidateElements(new []
        {
            Reusable_PurchasePath.CAStepper_1Coverage_Current,
            Reusable_PurchasePath.CAStepper_2Operations_Before,
            Reusable_PurchasePath.CAStepper_3AboutYou_Before,
            Reusable_PurchasePath.CAStepper_4Summary_Before,
            Reusable_PurchasePath.CAStepper_5Quote_Before,
            Reusable_PurchasePath.CAStepper_6Purchase_Before
        }, 2);

        AutomationHelper.ValidateElementsNotPresent(new[]
        {
            Reusable_PurchasePath.CAStepper_1Coverage_Past,
            Reusable_PurchasePath.CAStepper_2Operations_Current,
            Reusable_PurchasePath.CAStepper_2Operations_Past,
            Reusable_PurchasePath.CAStepper_3AboutYou_Current,
            Reusable_PurchasePath.CAStepper_3AboutYou_Past,
            Reusable_PurchasePath.CAStepper_4Summary_Current
        }, 2);
    }

    public IncidentPanelAutomation LastIncident => GetIncident(_incidents.Count - 1);
}