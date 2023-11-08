using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using OpenQA.Selenium;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;
using NUnit.Framework.Constraints;
using BiBerkLOB.Source.Driver;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_Vehicles
    {
        private readonly QuestionErrorHandler _questionErrorHandler;
        private readonly CAVehiclesAutomation _automation;

        public CA_Gen_Vehicles(QuestionErrorHandler questionErrorHandler, CAVehiclesAutomationFactory factory)
        {
            _questionErrorHandler = questionErrorHandler;
            _automation = factory.CreateAutomation();
        }

        [Then(@"user verifies the appearance of the Vehicles page")]
        public void ThenUserVerifiesVehiclesPage()
        {
            CA_VehiclesPage.LoadingRequirements.Assert();
        }

        [Then(@"user checks the stepper appearance on the Vehicles page")]
        public void ThenUserChecksStepperVehiclesPage()
        {
            _automation.ValidateStepper();
        }

        [Then(@"user creates a vehicle or trailer with variable values:")]
        public void ThenUserCreatesVehicleOrTrailer(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                _automation.ResetVehicleData();
                var countOfColumns = rowy.Count;
                var keys = rowy.Keys.ToList();
                for (int i = 0; i < countOfColumns; i++)
                {
                    //get the Value of the Table header AND value
                    //NOTE: the tag used in the table is NOT necessarily the question alias held in back end
                    var questionTag = keys[i];
                    var answer = rowy[i];

                    try
                    {
                        AutomateVehicleQuestion(questionTag, answer);
                    }
                    catch (Exception ex)
                    {
                        _questionErrorHandler.ThrowErrorIfQuestionShouldAppear(ex);
                    }
                }
                _automation.AddCurrentVehicleIntoSummaryObject();
            }
        }

        [Then(@"user adds another vehicle or trailer")]
        public void ThenUserAddsANewVehicle()
        {
            _automation.StartNewVehicle();
        }

        [Then(@"user clicks on Remove Vehicle button")]
        public void ThenUserClicksOnRemoveVehicleButton()
        {
            CA_VehiclesPage.RemoveButton.Click();
        }

        [Then(@"user clicks Let's Continue")]
        public void ThenUserClicksContinue()
        {
            _automation.WaitForVehicleToSave();
            CA_VehiclesPage.LetsContinueCTA.Click();
            AutomationHelper.WaitForLoading(120);

            _questionErrorHandler.IsErrorVisible();
        }

        [When(@"user navigates back to the previous CA page")]
        public void WhenUserNavigatesBackToThePreviousCAPage()
        {
            Reusable_PurchasePath.CABackCTA.Click();
            AutomationHelper.WaitForLoading(120);
        }

        [Then(@"user verifies that the following other vehicle type is still selected: (.*)")]
        public void ThenUserVerifiesThatTheFollowingOtherVehicleTypeIsStillSelected(string vehicleType)
        {
            _automation.ValidateVehicleTypeOtherSelection(vehicleType);
        }

        [Then(@"(.*) is in the top five")]
        public void ThenFuelTruckIsInTheTopFive(string vehicleType)
        {
            _automation.DoNotUseVinToAutoFill("");

            //find vehicle element button in list association with name entered as value
            CA_VehiclesPage.WhatWouldYouLikeToInsureInput.AssertAllElements();
            Assert.IsTrue(_automation.IsVehicleTypeVisibleInTopFive(vehicleType), false, $"{vehicleType} was not in default vehicle type selection");
        }

        private void AutomateVehicleQuestion(string tableColumn, string tableValue)
        {
            switch (tableColumn)
            {
                //Suggested VIN
                case "Suggested VIN":
                    _automation.SetSuggestedVin(tableValue);
                    break;
                //VIN - first clicks Yes to Do you want to use your vehicle identification number (VIN) to autofill your vehicle data?, then enters VIN
                case "VIN":
                    _automation.EnterVinForAutoFill(tableValue);
                    break;
                //Parking Address
                case "Parking Address":
                    _automation.SelectParkingState(tableValue);
                    break;
                //Vehicle
                case "Vehicle Worth":
                    _automation.EnterVehicleWorth(tableValue);
                    break;
                //Gross Vehicle Weight
                //Potential answers: "1-5000 lbs", "5001-10000 lbs", "10001-15000 lbs", "15001-20000 lbs", "20001-26000 lbs", "26001-30000 lbs", "30001-40000 lbs", "40001-45000 lbs", "45001+ lbs"
                case "Gross Weight":
                    _automation.EnterGrossWeight(tableValue);
                    break;
                //Trailer Worth
                case "Trailer Worth":
                    _automation.EnterTrailerWorth(tableValue);
                    break;
                //Trailer Address
                case "Trailer Address":
                    _automation.SelectTrailerParkingState(tableValue);
                    break;
                //Escort Trucks with Large Loads or Guide Through Road Construction
                case "Escort Trucks":
                    _automation.ChooseEscortTrucks(tableValue);
                    break;
                //Haul to Landfills
                case "Haul":
                    _automation.ChooseHaulLandfills(tableValue);
                    break;
                //Dump Truck for Hire
                case "For Hire":
                    _automation.ChooseDumpTrickHire(tableValue);
                    break;
                //Deliver Goods
                case "Deliver Goods":
                    _automation.ChooseDeliverGoods(tableValue);
                    break;
                //Food Truck
                case "Food Truck":
                    _automation.ChooseFoodTruckLocations(tableValue);
                    break;
                //How is this vehicle used?
                case "How Used":
                    _automation.ChooseHowUsed(tableValue);
                    break;
                //Auto Repo?
                case "Auto Repo":
                    _automation.ChooseAutoRepo(tableValue);
                    break;
                //Fare Box
                case "Fare Box":
                    _automation.ChooseFareBoxDisplay(tableValue);
                    break;
                //Seatbelt
                case "Seatbelt":
                    _automation.ChooseSeatbelt(tableValue);
                    break;
                //Commuter
                case "Commuter":
                    _automation.ChooseCommuterShuttle(tableValue);
                    break;
                //Passengers Seat
                //Potential answers: "5 or less", "6 - 9", "10 - 20", "21 - 40", "41 - 60", "61+"
                case "Passengers Seat":
                    _automation.ChooseHowManySeat(tableValue);
                    break;
                //Routes
                case "Routes":
                    _automation.ChooseBusRoutes(tableValue);
                    break;
                //Client Locations
                case "Client Locations":
                    _automation.ChooseTravelToClients(tableValue);
                    break;
                //Medical Outpatient Visits
                case "Outpatient":
                    _automation.ChooseOutpatientTransport(tableValue);
                    break;
                //Camps or Other Activities
                case "Camps":
                    _automation.ChooseCamps(tableValue);
                    break;
                //Airport Shuttle
                case "Airport Shuttle":
                    _automation.ChooseAirportShuttle(tableValue);
                    break;
                //Tours
                case "Tours":
                    _automation.ChooseTours(tableValue);
                    break;
                //No VIN
                case "No VIN":
                    _automation.DoNotUseVinToAutoFill(tableValue);
                    break;
                //Type Insure
                case "Type Insure":
                    _automation.SelectVehicleTypeInsure(tableValue);
                    break;
                //Year
                case "Year":
                    _automation.SetYear(tableValue);
                    break;
                //Make
                case "Make":
                    _automation.SetMake(tableValue);
                    break;
                //Model
                case "Model":
                    _automation.SetModel(tableValue);
                    _automation.EnterYearMakeModel();
                    break;
                //No Model - enter model name manually if not in model dropdown
                case "No Model":
                    _automation.SetModelCannotFind(tableValue);
                    _automation.EnterYearMakeModel();
                    break;
                case "Enter Year Make Model":
                    _automation.EnterYearMakeModel();
                    break;
                //Trim
                case "Trim":
                    _automation.ChooseTrim(tableValue);
                    break;
                //Plowing Snow
                case "Plowing Snow":
                    _automation.ChooseSnowPlow(tableValue);
                    break;
                //Fifth Wheel
                case "Fifth Wheel":
                    _automation.ChooseFifthWheel(tableValue);
                    break;
                //Is this vehicle used for towing or roadside assistance?
                case "Towing Or Roadside":
                    _automation.ChooseTowingRoadside(tableValue);
                    break;
                default: throw new Exception($"Table value '{tableValue}' for table '{tableColumn}' is not currently mapped or is misspelled.");
            }
        }
    }
}
