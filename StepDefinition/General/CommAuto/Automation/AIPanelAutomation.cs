using System;
using System.Linq;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Source.Driver;
using HitachiQA;
using System.Threading;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Spreadsheet;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using CAAI = BiBerkLOB.Pages.CommAuto.CA_AdditionalInformationPage;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class AIPanelAutomation
{
    private const string OWNED = "Owned";
    private const string FINANCED = "Financed";
    private const string LEASED = "Leased";

    private static readonly string[] NO_INFO_OWNERS = { "Myself", "The Business" };

    private readonly CASummaryObject _caSummaryObject;
    private readonly int _panelIndex;
    
    public AIPanelAutomation(CASummaryObject caSummaryObject, int panelIndex)
    {
        _caSummaryObject = caSummaryObject;
        _panelIndex = panelIndex;
    }

    public void ExpandPanel()
    {
        var panelHeader = CA_AdditionalInformationPage.VehiclePanelHeader(_panelIndex);
        if (panelHeader.GetAttribute("aria-expanded") != "true")
        {
            panelHeader.Click();
        }
    }

    public void CollapsePanel()
    {
        //wait for all state changes to apply
        //panel immediately reopens otherwise, even if all question answered
        WaitForNetworkCalls();

        var panelHeader = CA_AdditionalInformationPage.VehiclePanelHeader(_panelIndex);
        if (panelHeader.GetAttribute("aria-expanded") == "true")
        {
            panelHeader.Click();
            //wait for vehicle to save and ensure collapse succeeded
            CA_AdditionalInformationPage.AnyGreyedOutPanel.WaitForElementToAppearThenDisappear();
            Assert.IsTrue(panelHeader.GetAttribute("aria-expanded") != "true");
        }
    }

    private static void WaitForNetworkCalls()
    {
        var status = new InflightStatusChecker(CA_ReusableElements.InflightStatusElement);
        UserActions.WaitUntil(() => !status.IsInflight(), 10);
    }

    public void VerifyVehicleDetails()
    {

        //Year Make should be formatted like: 2009 Hyundai Blah
        Regex rgxYearMakeModel = new Regex(@"[0-9]{4} [A-z]*");
        
        //Vehicle value should be formatted like: $1,000.00
        Regex rgxVehicleValue = new Regex(@"\$[0-9,.]*");

        //Vehicle Details Title and Vehicle Details Info is Displayed
        CA_AdditionalInformationPage.VehicleDetailsQST(_panelIndex).AssertElementIsVisible();
        var savedYearMakeModel = CA_AdditionalInformationPage.VehicleDetailsPopulated(_panelIndex).GetInnerText();
        Assert.IsTrue(rgxYearMakeModel.IsMatch(savedYearMakeModel));

        //Vehicle Value and $#,####.## is Displayed
        CA_AdditionalInformationPage.VehicleValueQST(_panelIndex).AssertElementIsVisible();
        var savedVehicleValue = CA_AdditionalInformationPage.VehicleValuePopulated(_panelIndex).GetInnerText();
        if (!savedVehicleValue.Equals("Actual Cash Value"))
        {
            Assert.IsTrue(rgxVehicleValue.IsMatch(savedVehicleValue));
        }
    }

    public void VerifyVINMatch()
    {
        var savedVinIsCorrect = CA_AdditionalInformationPage.VINInput(_panelIndex).IsResponseCurrentlyEqualTo(_caSummaryObject.VehiclesList[_panelIndex].VIN);
        Assert.IsTrue(savedVinIsCorrect);
    }

    public void EnterVIN(string vin)
    {
        CA_AdditionalInformationPage.VINInput(_panelIndex).AssertAllElements();
        CA_AdditionalInformationPage.VINInput(_panelIndex).EnterResponse(vin);
    }

    public void SelectTrim(string trim)
    {
        CA_AdditionalInformationPage.TrimInput(_panelIndex).AssertAllElements();
        CA_AdditionalInformationPage.TrimInput(_panelIndex).EnterResponse(trim);
    }

    public void SelectOwnedFinancedLeased(string option)
    {
        CommonRetry("SelectOwnedFinancedLeased",
            Functions.SetMethodForRetry(CAAI.IsVehicleOwnedFinancedOrLeasedInput(_panelIndex).EnterResponse, option, 1),
            Functions.SetMethodForRetry(CAAI.IsVehicleOwnedFinancedOrLeasedInput(_panelIndex).IsResponseCurrentlyEqualTo, option));

        //use this once a better stability fix is discovered
        //CA_AdditionalInformationPage.IsVehicleOwnedFinancedOrLeasedInput(_panelIndex).EnterResponse(option);
    }

    public void SelectWhoHoldsTitle(string choice)
    {
        CommonRetry("SelectTitleHolder",
            Functions.SetMethodForRetry(CAAI.VehicleTitleInput(_panelIndex).EnterResponse, choice, 1),
            Functions.SetMethodForRetry(CAAI.VehicleTitleInput(_panelIndex).IsResponseCurrentlyEqualTo, choice));

        //use this once a better stability fix is discovered
        //CA_AdditionalInformationPage.VehicleTitleInput(_panelIndex).EnterResponse(choice);
    }

    public void EnterOwnerName(string firstName, string lastName)
    {
        CA_AdditionalInformationPage.OwnerVehicleFirstNameInput(_panelIndex).AssertAllElements();
        Thread.Sleep(500);
        CA_AdditionalInformationPage.OwnerVehicleFirstNameInput(_panelIndex).EnterResponse(firstName);

        CA_AdditionalInformationPage.OwnerVehicleLastNameInput(_panelIndex).AssertAllElements();
        Thread.Sleep(500);
        CA_AdditionalInformationPage.OwnerVehicleLastNameInput(_panelIndex).EnterResponse(lastName);
    }

    public void EnterLienholderName(string fullName)
    {
        CA_AdditionalInformationPage.LienholderNameInput(_panelIndex).AssertAllElements();

        CommonRetry("Lienholder",
            Functions.SetMethodForRetry(CAAI.LienholderNameInput(_panelIndex).EnterResponse, fullName, 1),
            Functions.SetMethodForRetry(CAAI.LienholderNameInput(_panelIndex).IsResponseCurrentlyEqualTo, fullName));

        //CA_AdditionalInformationPage.LienholderNameInput(_panelIndex).EnterResponse(fullName);
    }

    public void EnterLessorName(string fullName)
    {
        CA_AdditionalInformationPage.LessorNameInput(_panelIndex).AssertAllElements();
        CommonRetry("Lessor",
            Functions.SetMethodForRetry(CAAI.LessorNameInput(_panelIndex).EnterResponse, fullName, 1),
            Functions.SetMethodForRetry(CAAI.LessorNameInput(_panelIndex).IsResponseCurrentlyEqualTo, fullName));

        //CA_AdditionalInformationPage.LessorNameInput(_panelIndex).EnterResponse(fullName);
    }

    /// <summary>
    /// Auto-generates an address to fill out
    /// </summary>
    public void EnterContactAddress()
    {
        CA_AdditionalInformationPage.VehicleContactAddressInput(_panelIndex).EnterResponse(new SmartyStreetsInputResponse()
        {
            Address = GetValidAddress(),
            Suggestion = SmartyStreetsSuggestion.NoAction
        });
    }

    public void SetVehicleAsOwned(string ownerOption, string firstName, string lastName)
    {
        SelectOwnedFinancedLeased(OWNED);
        SelectWhoHoldsTitle(ownerOption);
        if (NO_INFO_OWNERS.Contains(ownerOption))
        {
            return;
        }
        EnterOwnerName(firstName, lastName);
        EnterContactAddress();
    }

    public void SetVehicleFinanced(string lienholderName)
    {
        SelectOwnedFinancedLeased(FINANCED);
        EnterLienholderName(lienholderName);
        EnterContactAddress();
    }

    public void SetVehicleLeased(string lessorName)
    {
        SelectOwnedFinancedLeased(LEASED);
        EnterLessorName(lessorName);
        EnterContactAddress();
    }

    // assumption: this address is considered valid by smarty streets
    private Address GetValidAddress()
    {
        var address = new Address()
        {
            Line1 = "175 N Arlington Heights Rd",
            ZipCode  = "60007",
            City = "Elk Grove Village",
            State = State.FromName("Illinois"),
        };
        return address;
    }

    private void CommonRetry(string name, Action action, Func<bool> expectation)
    {
        var retry = AutomationRetryInstructions.Init(name)
            .First(action)
            .ThenSleepFor(2000)
            .ThenShould(expectation);

        AutomationHelper.RetryUntilSucceeded(retry);
    }
}