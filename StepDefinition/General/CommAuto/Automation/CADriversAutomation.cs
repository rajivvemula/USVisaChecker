using System.Collections.Generic;
using System.Linq;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Source.Driver;
using HitachiQA;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CADriversAutomation
{
    private CASummaryObject _caSummaryObject;
    private List<DriverPanelAutomation> _drivers;

    public CADriversAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
        _drivers = new List<DriverPanelAutomation>();
        Reset();
    }

    public void Reset()
    {
        _caSummaryObject.DriversList.Clear();
        _drivers.Clear();
        _drivers.Add(new DriverPanelAutomation(0));
    }

    public DriverPanelAutomation GetDriver(int index)
    {
        return _drivers[index];
    }

    public void SaveDriverObject(int driverIndex)
    {
        var driver = GetDriver(driverIndex);
        var driverObj = driver.GetDriverObject();
        if (_caSummaryObject.DriversList.Any(obj => obj.PanelIndex == driverIndex))
        {
            var listIndex = _caSummaryObject.DriversList.FindIndex(obj => obj.PanelIndex == driverIndex);
            _caSummaryObject.DriversList[listIndex] = driverObj;
            return;
        }
        _caSummaryObject.DriversList.Add(driverObj);
    }

    public void SaveCurrentDriverObject()
    {
        SaveDriverObject(_drivers.Count - 1);
    }

    public DriverPanelAutomation LastDriver => GetDriver(_drivers.Count - 1);

    public void AddAnotherDriver()
    {
        ClickAddDriverButton();
        var nextIndex = _drivers.Count;
        _drivers.Add(new DriverPanelAutomation(nextIndex));
    }

    public void ContinueToNextPage()
    {
        CA_DriversPage.LetsContinueCTA.Click();
    }

    public void ValidateStepper()
    {
        AutomationHelper.ValidateElements(new[]
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

    /// <summary>
    /// Driver add button has been eating clicks.
    /// This ensures that an enabled button clicks and adds a new driver
    /// </summary>
    private static void ClickAddDriverButton()
    {
        //make sure the button is enabled
        //wait for state changes
        AutomationHelper.RetryUntilSucceeded(() => Assert.AreNotEqual(CA_DriversPage.AddAnotherDriverButton.GetAttribute("disabled"), "true"), InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //click until button is disabled
        AutomationHelper.RetryUntilSucceeded(() => {
            CA_DriversPage.AddAnotherDriverButton.Click();
            return CA_DriversPage.AddAnotherDriverButton.GetAttribute("disabled") == "true";
        }, 4);
    }
}