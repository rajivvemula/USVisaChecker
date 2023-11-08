using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using System;
using BiBerkLOB.Source.Driver.Input;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA.Helpers;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using System.Threading;
using BiBerkLOB.Source.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CAVehiclesAutomation
{
    private string _suggestedVin;
    private VehiclesObject _vehiclesObject;
    private YearMakeModel _yearMakeModel;

    private readonly CASummaryObject _caSummaryObject;
    private readonly VehicleCountObj _vehicleCount;
    private readonly ApolloGateway _apolloGateway;

    public CAVehiclesAutomation(CASummaryObject caSummaryObject, VehicleCountObj vehicleCount, ApolloGateway apolloGateway)
    {
        _caSummaryObject = caSummaryObject;
        _vehicleCount = vehicleCount;
        _apolloGateway = apolloGateway;
        ResetVehicleData();
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

    public void ResetVehicleData()
    {
        _suggestedVin = null;
        _vehiclesObject = new VehiclesObject();
        _yearMakeModel = new YearMakeModel();
    }

    public void SetSuggestedVin(string tableValue)
    {
        _suggestedVin = tableValue;
    }

    public void EnterVinForAutoFill(string vin)
    {
        CA_VehiclesPage.WantToUseVINInput.AssertAllElements();
        AutomationHelper.RetryUntilSucceeded(action: () =>
        {
            CA_VehiclesPage.WantToUseVINInput.EnterResponse(answer: "Yes", waitSeconds: 1);
            _vehiclesObject.VINQuestion = "Yes";

            CA_VehiclesPage.WhatIsVINInput.AssertAllElements(waitSeconds: 2);
        }, waitSeconds: 10);

        CA_VehiclesPage.WhatIsVINInput.EnterResponse(vin);
        _vehiclesObject.VIN = vin;

        if (string.IsNullOrEmpty(vin))
        {
            return;
        }

        //Handle suggested VIN
        if (_suggestedVin != null)
        {
            HandleSuggestedVin();
        }
        else
        {
            CA_VehiclesPage.VehicleDetails.AssertAllElements();
            _vehiclesObject.VehicleYrMkMdl = CA_VehiclesPage.VehicleYrMkMdl.GetInnerText();
        }
    }

    private void HandleSuggestedVin()
    {
        CA_VehiclesPage.SelectAVINInput.AssertAllElements();
        CA_VehiclesPage.SelectAVINInput.EnterResponse(_suggestedVin.ToLower());

        if (_suggestedVin.ToLower() == "suggested")
        {
            _vehiclesObject.VIN = CA_VehiclesPage.SuggestedVINValue.GetInnerText();
            _vehiclesObject.VehicleYrMkMdl = CA_VehiclesPage.VehicleYrMkMdl.GetInnerText();
        }
        else
        {
            _vehiclesObject.VIN = CA_VehiclesPage.OrignalVINValue.GetInnerText();
        }
    }

    public void DoNotUseVinToAutoFill(string vinForLater)
    {
        CA_VehiclesPage.WantToUseVINInput.AssertAllElements();
        CA_VehiclesPage.WantToUseVINInput.EnterResponse("No");
        _vehiclesObject.VINQuestion = "No";
        _vehiclesObject.NoVIN = vinForLater;
    }

    public void SelectParkingState(string state)
    {
        CA_VehiclesPage.StateParkingAddressStateInput.AssertAllElements();
        Assert.AreEqual(_caSummaryObject.BusinessAddress.State.Name, CA_VehiclesPage.StateParkingAddressStateDD.GetInnerText());

        if (state != _caSummaryObject.BusinessAddress.State.Name)
        {
            CA_VehiclesPage.StateParkingAddressStateInput.EnterResponse(state);
        }
        _vehiclesObject.ParkingAddress = state;
    }

    public void EnterVehicleWorth(string vehicleWorth)
    {
        CA_VehiclesPage.SoldVehicleTodayWorthInput.AssertAllElements();
        CA_VehiclesPage.SoldVehicleTodayWorthInput.EnterResponse(vehicleWorth);
        _vehiclesObject.VehicleWorth = int.Parse(vehicleWorth);
    }

    public void EnterGrossWeight(string grossWeight)
    {
        CA_VehiclesPage.GrossWeightInput.AssertAllElements();
        CA_VehiclesPage.GrossWeightInput.EnterResponse(grossWeight);
        _vehiclesObject.GrossWeight = grossWeight;
    }

    public void EnterTrailerWorth(string trailerWorth)
    {
        CA_VehiclesPage.SoldTrailerTodayWorthInput.AssertAllElements();
        CA_VehiclesPage.SoldTrailerTodayWorthInput.EnterResponse(trailerWorth);
        _vehiclesObject.TrailerWorth = int.Parse(trailerWorth);
    }

    public void SelectTrailerParkingState(string state)
    {
        CA_VehiclesPage.TrailerParkingAddressInput.AssertAllElements();
        Assert.AreEqual(_caSummaryObject.BusinessAddress.State.Name, CA_VehiclesPage.TrailerParkingAddressDD.GetInnerText());
        if (state != _caSummaryObject.BusinessAddress.State.Name)
        {
            CA_VehiclesPage.TrailerParkingAddressInput.EnterResponse(state);
        }
        _vehiclesObject.TrailerAddress = state;
    }

    public void ChooseEscortTrucks(string yesOrNo)
    {
        CA_VehiclesPage.EscortTrucksInput.AssertAllElements();
        CA_VehiclesPage.EscortTrucksInput.EnterResponse(yesOrNo);
        _vehiclesObject.EscortTrucks = yesOrNo;
    }

    public void ChooseHaulLandfills(string yesOrNo)
    {
        CA_VehiclesPage.VehicleHaulLandfillsInput.AssertAllElements();
        CA_VehiclesPage.VehicleHaulLandfillsInput.EnterResponse(yesOrNo);
        _vehiclesObject.Haul = yesOrNo;
    }

    public void ChooseDumpTrickHire(string yesOrNo)
    {
        CA_VehiclesPage.DumpTruckHireInput.AssertAllElements();
        CA_VehiclesPage.DumpTruckHireInput.EnterResponse(yesOrNo);
        _vehiclesObject.ForHire = yesOrNo;
    }

    public void ChooseDeliverGoods(string yesOrNo)
    {
        CA_VehiclesPage.DeliverGoodsMaterialsInput.AssertAllElements();
        CA_VehiclesPage.DeliverGoodsMaterialsInput.EnterResponse(yesOrNo);
        _vehiclesObject.DeliverGoods = yesOrNo;
    }

    public void ChooseFoodTruckLocations(string option)
    {
        CA_VehiclesPage.FoodTruckLocationsInput.AssertAllElements();
        CA_VehiclesPage.FoodTruckLocationsInput.EnterResponse(option);
        _vehiclesObject.FoodTruck = option;
    }

    public void ChooseHowUsed(string option)
    {
        CA_VehiclesPage.HowVehicleUsedInput.AssertAllElements();
        CA_VehiclesPage.HowVehicleUsedInput.EnterResponse(option);
        _vehiclesObject.HowUsed = option;
    }

    public void ChooseAutoRepo(string yesOrNo)
    {
        CA_VehiclesPage.AutoRepoInput.AssertAllElements();
        CA_VehiclesPage.AutoRepoInput.EnterResponse(yesOrNo);
         _vehiclesObject.AutoRepo = yesOrNo;
    }

    public void ChooseFareBoxDisplay(string yesOrNo)
    {
        CA_VehiclesPage.FareBoxDisplayedInput.AssertAllElements();
        CA_VehiclesPage.FareBoxDisplayedInput.EnterResponse(yesOrNo);
        _vehiclesObject.FareBox = yesOrNo;
    }

    public void ChooseSeatbelt(string yesOrNo)
    {
        CA_VehiclesPage.SeatbeltEveryoneInput.AssertAllElements();
        CA_VehiclesPage.SeatbeltEveryoneInput.EnterResponse(yesOrNo);
    }

    public void ChooseCommuterShuttle(string yesOrNo)
    {
        CA_VehiclesPage.CommuterShuttleInput.AssertAllElements();
        CA_VehiclesPage.CommuterShuttleInput.EnterResponse(yesOrNo);
        _vehiclesObject.Commuter = yesOrNo;
    }

    public void ChooseHowManySeat(string option)
    {
        CA_VehiclesPage.HowManyCanSeatInput.AssertAllElements();
        CA_VehiclesPage.HowManyCanSeatInput.EnterResponse(option);
        _vehiclesObject.PassengersSeat = option;
    }

    public void ChooseBusRoutes(string option)
    {
        CA_VehiclesPage.RoutesBusTakesInput.AssertAllElements();
        CA_VehiclesPage.RoutesBusTakesInput.EnterResponse(option);

        var text = GetSummaryTextForOption(option);
        _vehiclesObject.Routes = text;
    }

    private string GetSummaryTextForOption(string option)
    {
        switch (option)
        {
            case "Local":
                return "Local - multiple stops within cities";
            case "Regional":
                return "Regional/Charter - only city to city";
            case "Other":
                return option;
            default:
                throw new Exception("Option for Bus Routes question must be Local, Regional, or Other");
        }
    }

    public void ChooseTravelToClients(string yesOrNo)
    {
        CA_VehiclesPage.TravelToClientsInput.AssertAllElements();
        CA_VehiclesPage.TravelToClientsInput.EnterResponse(yesOrNo);
        _vehiclesObject.ClientLocation = yesOrNo;
    }

    public void ChooseOutpatientTransport(string yesOrNo)
    {
        CA_VehiclesPage.TransportMedicalOutpatientInput.AssertAllElements();
        CA_VehiclesPage.TransportMedicalOutpatientInput.EnterResponse(yesOrNo);
        _vehiclesObject.Outpatient = yesOrNo;
    }

    public void ChooseCamps(string yesOrNo)
    {
        CA_VehiclesPage.GroupsPplCampsInput.AssertAllElements();
        CA_VehiclesPage.GroupsPplCampsInput.EnterResponse(yesOrNo);
        _vehiclesObject.Camps = yesOrNo;
    }

    public void ChooseAirportShuttle(string yesOrNo)
    {
        CA_VehiclesPage.ShuttleTransportGuestsInput.AssertAllElements();
        CA_VehiclesPage.ShuttleTransportGuestsInput.EnterResponse(yesOrNo);
        _vehiclesObject.AirportShuttle = yesOrNo;
    }

    public void ChooseTours(string yesOrNo)
    {
        CA_VehiclesPage.TransportCustToursInput.AssertAllElements();
        CA_VehiclesPage.TransportCustToursInput.EnterResponse(yesOrNo);
        _vehiclesObject.Tours = yesOrNo;
    }

    public void SetYear(string year)
    {
        _yearMakeModel.Year = year;
    }

    public void SetMake(string make)
    {
        _yearMakeModel.Make = make;
    }

    public void SetModel(string model)
    {
        _yearMakeModel.Model = model.ToUpper();
        _yearMakeModel.EnterModelManually = false;
    }

    public void SetModelCannotFind(string model)
    {
        _yearMakeModel.Model = model;
        _yearMakeModel.EnterModelManually = true;
    }

    public void EnterYearMakeModel()
    {
        CA_VehiclesPage.YearMakeModelInput.EnterResponse(_yearMakeModel);
        _vehiclesObject.VehicleYrMkMdl = $"{_yearMakeModel.Year} {_yearMakeModel.Make} {_yearMakeModel.Model}";
        _vehiclesObject.VehicleYrMkMdl = _vehiclesObject.VehicleYrMkMdl.Trim();
    }

    public void ChooseTrim(string trimOption)
    {
        CA_VehiclesPage.WhatsTheTrimInput.AssertAllElements();
        CA_VehiclesPage.WhatsTheTrimInput.EnterResponse(trimOption);
    }

    public void ChooseSnowPlow(string yesOrNo)
    {
        CA_VehiclesPage.PlowingSnowInput.AssertAllElements();
        CA_VehiclesPage.PlowingSnowInput.EnterResponse(yesOrNo);
        _vehiclesObject.PlowingSnow = yesOrNo;
    }

    public void ChooseFifthWheel(string yesOrNo)
    {
        CA_VehiclesPage.FifthWheelInput.AssertAllElements();
        CA_VehiclesPage.FifthWheelInput.EnterResponse(yesOrNo);
    }

    public void ChooseTowingRoadside(string option)
    {
        CA_VehiclesPage.VehicleUsedForTowingInput.AssertAllElements();
        CA_VehiclesPage.VehicleUsedForTowingInput.EnterResponse(option);
    }

    public void SelectVehicleTypeInsure(string vehicleTypeName)
    {
        //find vehicle element button in list association with name entered as value
        var vehicleType = _apolloGateway.GetVehicleTypeFromButtonLabel(vehicleTypeName);

        if (IsVehicleTypeVisibleInTopFive(vehicleType))
        {
            SelectVehicleTypeFromDefaults(vehicleType);
        }
        else
        {
            SelectOtherVehicleType(vehicleType);
        }

        _vehiclesObject.TypeInsure = vehicleTypeName;
    }

    public void SelectOtherVehicleType(VehicleType vehicleType)
    {
        //you need to click Other button first to trigger modal
        CA_VehiclesPage.WhatWouldYouLikeToInsureInput.EnterResponse(VehicleTopFiveInput.OTHER_OPTION);

        CA_VehiclesPage.OtherVehicleModal.AssertAllElements();
        CA_VehiclesPage.OtherVehicleModal.EnterResponse(vehicleType, 3);
    }

    public void SelectVehicleTypeFromDefaults(VehicleType vehicleType)
    {
        CA_VehiclesPage.WhatWouldYouLikeToInsureInput.AssertAllElements();
        CA_VehiclesPage.WhatWouldYouLikeToInsureInput.EnterResponse(vehicleType);
    }

    public bool IsVehicleTypeVisibleInTopFive(string vehicleTypeName)
    {
        var vehicleType = _apolloGateway.GetVehicleTypeFromButtonLabel(vehicleTypeName);
        return IsVehicleTypeVisibleInTopFive(vehicleType);
    }

    public bool IsVehicleTypeVisibleInTopFive(VehicleType vehicleType)
    {
        return CA_VehiclesPage.GetVehicleButton(vehicleType.ToString()).AssertElementIsVisible(1, true);
    }

    //best way to determine the current other selection
    public void ValidateVehicleTypeOtherSelection(string vehicleTypeName)
    {
        //button is labeled for QA
        var vehicleType = _apolloGateway.GetVehicleTypeFromButtonLabel(vehicleTypeName);
        var otherBtnDataQa = CA_VehiclesPage.Other.GetAttribute("data-qa");
        Assert.TextContains(otherBtnDataQa, vehicleType.ToString());

        //button is labeled with alt text
        var otherVehicle = CA_VehiclesPage.OtherImage.GetAttribute("alt").ToLower();
        Assert.AreEqual(otherVehicle, vehicleTypeName.ToLower());
    }

    public void AddCurrentVehicleIntoSummaryObject()
    {
        _caSummaryObject.VehiclesList.Add(_vehiclesObject);
    }

    public void StartNewVehicle()
    {
        CloseAndSaveLastCompletedVehicle();

        //button sometimes takes some time to be enable
        AutomationHelper.RetryUntilSucceeded(CreateNewVehicle, 10);
        _vehicleCount.Increment();
    }

    private void CloseAndSaveLastCompletedVehicle()
    {
        //shrink the populated expanded vehicle panel
        //then wait for the vehicle to be saved on the back end
        CA_VehiclesPage.ExpandedVehiclePanel.Click();
        WaitForVehicleToSave();
    }

    public void WaitForVehicleToSave()
    {
        //assume the vehicle panel will take time to load the vehicle
        //if it isn't, then it finished loading before automation could find the disabled panel
        var wasFoundLoading = CA_VehiclesPage.DisabledVehiclePanel.AssertElementIsPresent(3, true);
        if (!wasFoundLoading && !CA_VehiclesPage.AnyError.AssertElementNotPresent(2, true))
        {
            NUnit.Framework.Assert.Fail($"There are unanswered questions in the vehicle #{_vehicleCount}");
        }

        //wait until disabled panel is re-enabled
        CA_VehiclesPage.DisabledVehiclePanel.AssertElementNotPresent();
    }

    private static void CreateNewVehicle()
    {
        CA_VehiclesPage.AddAnotherVehicleOrTrailer.AssertElementIsVisible(2);
        CA_VehiclesPage.AddAnotherVehicleOrTrailer.Click(2);

        //button should disappear while there is an unfinished vehicle
        var disabled = CA_VehiclesPage.AddAnotherVehicleOrTrailer.GetAttribute("disabled");
        Assert.IsTrue(disabled == "true");
    }
}