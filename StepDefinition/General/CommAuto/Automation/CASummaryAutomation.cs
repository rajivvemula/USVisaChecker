using System;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HitachiQA;
using BiBerkLOB.Source.Driver.Input;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using BiBerkLOB.Pages;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CASummaryAutomation
{
    private readonly CASummaryObject _caSummaryObject;

    public CASummaryAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public void VerifyStartYourQuoteSummary()
    {
        CA_SummaryPage.StartYourQuoteTitle.AssertElementIsVisible();
        CA_SummaryPage.NameOfBusiness.AssertPairExactAnswer(_caSummaryObject.NameOfBusiness);

        CA_SummaryPage.AnotherName.AssertPairExactAnswer(_caSummaryObject.DBAYesNo);
        if (Functions.ConvertYesOrNoStringToBool(_caSummaryObject.DBAYesNo))
        {
            CA_SummaryPage.OtherBusiness.AssertPairExactAnswer(_caSummaryObject.DBAValue);
        }

        CA_SummaryPage.PolicyStart.AssertPairExactAnswer(_caSummaryObject.PolicyStart);
    }

    public void VerifyQuickIntroSummary()
    {
        CA_SummaryPage.AQuickIntroTitle.AssertElementIsVisible();
        CA_SummaryPage.YearOfBusinessStart.AssertPairExactAnswer(_caSummaryObject.YearBusStarted);
        CA_SummaryPage.BusinessStructured.AssertPairExactAnswer(_caSummaryObject.HowBusStructured);

        CA_SummaryPage.BusinessAddress.AssertQuestionVisible();
        //skip if use suggested, automation doesn't capture suggested address
        if (!_caSummaryObject.BusinessAddressUsedSuggested)
        {
            CA_SummaryPage.BusinessAddress.AssertAnsweredExactly(_caSummaryObject.BusinessAddress.ToString());
        }

        CA_SummaryPage.UseBusinessAsMailingAddress.AssertPairExactAnswer(Functions.ConvertBoolToYesNoString(_caSummaryObject.UseBusinessAsMailingAddress));
        if (!_caSummaryObject.UseBusinessAsMailingAddress)
        {
            CA_SummaryPage.MailingAddress.AssertQuestionVisible();
            //skip if use suggested, automation doesn't capture suggested address
            if (!_caSummaryObject.MailingAddressUsedSuggested)
            {
                CA_SummaryPage.MailingAddress.AssertAnsweredExactly(_caSummaryObject.MailingAddress.ToString());
            }
        }
    }

    public void VerifyVehiclesSummary()
    {
        var vehicles = _caSummaryObject.VehiclesList.ToList();
        
        for (int i = 0; i < vehicles.Count; i++)
        {
            var vehicle = vehicles[i];
            var yearMakeModel = vehicle.VehicleYrMkMdl;

            CA_SummaryPage.VehicleYrMkMdl(yearMakeModel).AssertElementInnerTextEquals(yearMakeModel);
            
            CA_SummaryPage.WantToUseVIN(yearMakeModel).AssertPairExactAnswer(vehicle.VINQuestion);
            if (vehicle.VINQuestion == "No")
            {
                //the type displayed for a vehicle entered with no vin is no longer like "SUV"
                //now it appears with "Body Category - Body Subcategory" ex: "Cars or SUVs - SUV" 
                //and therefore the easiest way to verify correctness
                //is that the type we select (via the button text) is contained on the webpage
                CA_SummaryPage.WhatWouldYouLikeToInsure(yearMakeModel).AssertPairAnswerContains(vehicle.TypeInsure);
                
                //check if vehicle or trailer
                if (vehicle.IsTrailer) //if trailer
                {
                    CA_SummaryPage.WhatsYearMake(yearMakeModel).AssertPairExactAnswer(vehicle.VehicleYrMkMdl);
                }
                else //else it's a vehicle 
                {
                    CA_SummaryPage.WhatsYearMakeModel(yearMakeModel).AssertAnsweredExactly(yearMakeModel);
                }
            }
            else //else it's vehicle/trailer WITH VIN
            {
                CA_SummaryPage.WhatIsVIN(yearMakeModel).AssertPairExactAnswer(vehicle.VIN);
            }

            AssertQAPairIfAnswerProvided(vehicle.ParkingAddress, CA_SummaryPage.ParkingAddressState(i));
            AssertQAPairIfAnswerProvided(vehicle.TrailerAddress, CA_SummaryPage.TrailerAddressState(i));
            AssertQAPairIfAnswerProvided(vehicle.VehicleWorth, CA_SummaryPage.SoldVehicleTodayWorth(i), vehicle.VehicleWorth.ToString("C0"));
            AssertQAPairIfAnswerProvided(vehicle.TrailerWorth, CA_SummaryPage.SoldTrailerTodayWorth(i), vehicle.TrailerWorth.ToString("C0"));
            AssertQAPairIfAnswerProvided(vehicle.AutoRepo, CA_SummaryPage.AutoRepo(i));
            AssertQAPairIfAnswerProvided(vehicle.GrossWeight, CA_SummaryPage.GrossWeight(i));
            AssertQAPairIfAnswerProvided(vehicle.EscortTrucks, CA_SummaryPage.EscortTrucks(i));
            AssertQAPairIfAnswerProvided(vehicle.Haul, CA_SummaryPage.VehicleHaulLandfills(i));
            AssertQAPairIfAnswerProvided(vehicle.ForHire, CA_SummaryPage.DumpTruckHire(i));
            AssertQAPairIfAnswerProvided(vehicle.DeliverGoods, CA_SummaryPage.DeliverGoodsMaterials(i));
            AssertQAPairIfAnswerProvided(vehicle.HowUsed, CA_SummaryPage.HowVehicleUsed(yearMakeModel));
            AssertQAPairIfAnswerProvided(vehicle.FoodTruck, CA_SummaryPage.FoodTruckLocations(i), vehicle.FoodTruck.ToLower());
            AssertQAPairIfAnswerProvided(vehicle.FareBox, CA_SummaryPage.FareBoxDisplayed(i));
            AssertQAPairIfAnswerProvided(vehicle.Seatbelt, CA_SummaryPage.SeatbeltEveryone(i));
            AssertQAPairIfAnswerProvided(vehicle.Routes, CA_SummaryPage.RoutesBusTakes(i));
            AssertQAPairIfAnswerProvided(vehicle.ClientLocation, CA_SummaryPage.TravelToClients(i));
            AssertQAPairIfAnswerProvided(vehicle.Camps, CA_SummaryPage.GroupsPplCamps(i));
            AssertQAPairIfAnswerProvided(vehicle.AirportShuttle, CA_SummaryPage.AirportShuttle(i));
            AssertQAPairIfAnswerProvided(vehicle.Commuter, CA_SummaryPage.CommuterShuttle(i));
            AssertQAPairIfAnswerProvided(vehicle.Tours, CA_SummaryPage.TransportCustTours(i));
            AssertQAPairIfAnswerProvided(vehicle.PassengersSeat, CA_SummaryPage.HowManyCanSeat(i));
            AssertQAPairIfAnswerProvided(vehicle.Outpatient, CA_SummaryPage.TransportMedicalOutpatient(i));
            AssertQAPairIfAnswerProvided(vehicle.PlowingSnow, CA_SummaryPage.PlowingSnow(i));
        }
    }

    public void VerifyDriversSummary()
    {
        var drivers = _caSummaryObject.DriversList.ToList();
        
        //Iterates through each driver
        for (int i = 0; i < drivers.Count; i++)
        {
            //combines data pulled from the driver's page to create the full name
            var driver = drivers[i];
            var fullName = driver.DriverFullName;
            //Driver's section title starts with "DRIVER - "
            var driverNameTitle = "DRIVER - " + fullName;
            
            //mandatory questions
            CA_SummaryPage.DriverNameTitle(driverNameTitle).AssertElementInnerTextEquals(driverNameTitle);
            CA_SummaryPage.DriverName(i).AssertPairExactAnswer(fullName);
            CA_SummaryPage.DLState(i).AssertPairExactAnswer(driver.DriversLicenseState.Name);
            CA_SummaryPage.DateofBirth(i).AssertPairExactAnswer(driver.DateOfBirth);

            AssertQAPairIfAnswerProvided(driver.DriverCDL, CA_SummaryPage.DriverCDL(i));

            if (driver.DriversLicenseState == State.Illinois)
            {
                VerifyILPrecautionsIfDriver55OrOlder(driver, i);
            }
            CA_SummaryPage.AccidentPastFiveYears(i).AssertPairExactAnswer(driver.AccidentOrVIolation);
            CA_SummaryPage.DriverLicenseNumber(i, driver.DriversLicenseState).AssertPairExactAnswer(driver.DriverLicenseNumber);
        }
    }

    public void VerifyIncidentsSummaryIfAny()
    {
        //check if there are any driver incidents
        if (!_caSummaryObject.DriverIncidentList.Any())
        {
            return;
        }

        //iterate through driver incidents
        //incidents numbering is zero-indexed
        for (int incidentIndex = 0; incidentIndex < _caSummaryObject.DriverIncidentList.Count(); incidentIndex++)
        {
            var incident = _caSummaryObject.DriverIncidentList[incidentIndex];

            //check fields that will always appear
            CA_SummaryPage.DriverInvolved(incidentIndex).AssertPairExactAnswer(incident.DriverInvolvedInIncident);
            CA_SummaryPage.DateOfIncident(incidentIndex).AssertPairExactAnswer(incident.DateOfIncident);
            CA_SummaryPage.TypeOfIncident(incidentIndex).AssertPairExactAnswer(incident.IncidentType);

            if (incident.IncidentType is "Accident" or "Both")
            {
                CA_SummaryPage.DriverAtFault(incidentIndex).AssertPairExactAnswer(incident.AccidentAtFault);
            }
            if (incident.IncidentType is "Violation/Conviction" or "Both")
            {
                VerifyEachViolation(incident, incidentIndex);
            }
        }
    }

    public void VerifyOperationsSummary()
    {
        foreach (var opQuest in _caSummaryObject.OpQuestions)
        {
            // summary responses use the same question alias stored in the question definition
            var alias = opQuest.QuestionDefinition.QuestionAlias;
            
            //operations responses for these question types differ from usual q/a pair
            var isCheckboxList = opQuest.QuestionDefinition.QuestionType == "multiselection";
            var isSoloCheckbox = opQuest.QuestionDefinition.QuestionType == "checkbox-label";
            
            //This particular alias doesn't have OperationsQuestion
            if (!alias.Equals("SubmitProofOfInsuranceClaimsHistory"))
            {
                CA_SummaryPage.OperationsQAPair(alias).AssertQuestionVisible();
            }
            
            //checkbox lists will need to verify each choice is present
            if (isCheckboxList)
            {
                var answerTextList = Functions.ParseSemicolonSeparatedList(opQuest.QuestionAnswer);
                var answerValues = answerTextList.Select(ans => opQuest.QuestionDefinition.GetAnswerFromText(ans).AnswerValue);
                VerifyListOfCheckedBoxes(answerValues.ToArray());
            }
            //Only Question Response is displayed for SoloCheckboxLabels
            else if (isSoloCheckbox)
            {
                CA_SummaryPage.OperationsQAPair(alias).AssertAnswerVisible();
            }
            else
            {
                CA_SummaryPage.OperationsQAPair(alias).AssertAnsweredExactly(opQuest.QuestionAnswer);
            }
        }
    }
    
    public void VerifyContactDetails()
    {
        CA_SummaryPage.ContactDetailsHeader.AssertElementIsVisible();
        CA_SummaryPage.ContactsName.AssertPairExactAnswer(_caSummaryObject.ContactName());
        CA_SummaryPage.BusinessEmail.AssertPairExactAnswer(_caSummaryObject.BusinessEmail);

        var businessPhone = _caSummaryObject.BusinessExt == string.Empty
            ? _caSummaryObject.BusinessPhone
            : $"{_caSummaryObject.BusinessPhone}   x{_caSummaryObject.BusinessExt}";
        CA_SummaryPage.BusinessPhone.AssertPairExactAnswer(businessPhone);
       
        AssertQAPairIfAnswerProvided(_caSummaryObject.BusinessWebsite, CA_SummaryPage.BusinessWebsite);
        CA_SummaryPage.DiffAcctManager.AssertPairExactAnswer(_caSummaryObject.HasAccountManager);
        
        if (Functions.ConvertYesOrNoStringToBool(_caSummaryObject.HasAccountManager))
        {
            VerifyAccountManagerDetails();
        }

        if (_caSummaryObject.PrimaryOwnerName() != string.Empty)
        {
            VerifyOwnerDetails();
        }
    }

    public void ReverifySummary()
    {
        AutomationHelper.ValidateElements(new List<Element>
        {
            CA_SummaryPage.StartYourQuoteTitle,
            CA_SummaryPage.AQuickIntroTitle,
            CA_SummaryPage.YourVehicles,
            CA_SummaryPage.DriversTitle,
            CA_SummaryPage.YourOperationsTitle,
            CA_SummaryPage.ContactDetailsHeader,
        });
    }

    public void ValidateStepper()
    {
        Reusable_PurchasePath.CAStepper_1Coverage_Current.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_1Coverage_Past.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_2Operations_Before.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_2Operations_Current.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_2Operations_Past.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_3AboutYou_Before.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_3AboutYou_Current.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_3AboutYou_Past.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_4Summary_Before.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_4Summary_Current.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_5Quote_Before.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_6Purchase_Before.AssertElementIsVisible();
    }

    public void ClickNavigation(string buttonDescription)
    {
        var button = buttonDescription switch
        {
            "continue" => CA_SummaryPage.FooterViewQuoteCTA,
            "back" => CA_SummaryPage.BackCTA,
            "edit Let's Start Your Quote" => CA_SummaryPage.StartYourQuoteEdit,
            "edit A Quick Introduction" => CA_SummaryPage.AQuickIntroEdit,
            "edit Your Vehicles" => CA_SummaryPage.YourVehiclesEdit,
            "edit Your Drivers" => CA_SummaryPage.YourDriversEdit,
            "edit Driver Incidents" => CA_SummaryPage.DriversIncidentsEdit,
            "edit Your Operations" => CA_SummaryPage.YourOperationsEdit,
            "edit Contact Details" => CA_SummaryPage.ContactDetailsEdit,
            _ => throw new ArgumentException($"'{buttonDescription}' is not a clickable button on the Summary page")
        };
        button.Click();
        AutomationHelper.WaitForLoading();
    }

    private void VerifyAccountManagerDetails()
    {
        CA_SummaryPage.ManagersName.AssertPairExactAnswer(_caSummaryObject.ManagerName());
        CA_SummaryPage.ManagerEmail.AssertPairExactAnswer(_caSummaryObject.ManagerEmail);

        var managerPhone = _caSummaryObject.ManagerExt == string.Empty
            ? _caSummaryObject.ManagerPhone
            : $"{_caSummaryObject.ManagerPhone}   x{_caSummaryObject.ManagerExt}";
        CA_SummaryPage.ManagerPhone.AssertPairExactAnswer(managerPhone);
    }

    private void VerifyOwnerDetails()
    {
        CA_SummaryPage.OwnersName.AssertPairExactAnswer(_caSummaryObject.PrimaryOwnerName());
        CA_SummaryPage.OwnersAddress.AssertQuestionVisible();

        var address = _caSummaryObject.PrimaryOwnerAddress.ToString();
        if (!_caSummaryObject.PrimaryOwnerAddressUsedSuggested)
        {
            CA_SummaryPage.OwnersAddress.AssertAnsweredExactly(address);
        }
    }

    //This is to handle reading in the string to verify the list of answers checked for these questions:
    // - Do you haul any of these?  (Check all that apply):
    // - Which types of authority from FMCSA do you have?
    private void VerifyListOfCheckedBoxes(string[] answerList)
    {
        foreach (var checkboxValue in answerList)
        {
            if (checkboxValue != "")
            {
                CA_SummaryPage.OperationsCheckboxResponseListItem(checkboxValue).AssertElementIsVisible();
            }
        }
    }

    private void VerifyEachViolation(DriverIncidentObject incident, int incidentIndex)
    {
        var incidentVCList = incident.VCList;
        //iterate through violations
        //violation numbering is one-indexed
        for (int vcIndex = 1; vcIndex <= incidentVCList.Count(); vcIndex++)
        {
            var violation = incidentVCList[vcIndex - 1];

            CA_SummaryPage.WhatWasViolation(incidentIndex, vcIndex).AssertPairExactAnswer(violation.Violation);
            AssertQAPairIfAnswerProvided(violation.RecklessConviction, CA_SummaryPage.Reckless(incidentIndex, vcIndex));
            AssertQAPairIfAnswerProvided(violation.Description, CA_SummaryPage.ViolationConviction(incidentIndex, vcIndex));

            //data-qa attribute references what the NEXT index of the violation
            //is going to be (first question is DriverIncident2Flag, etc.)
            CA_SummaryPage.AnotherViolation(incidentIndex, vcIndex + 1).AssertPairExactAnswer(violation.AddAnotherVC);
        }
    }

    private static void VerifyILPrecautionsIfDriver55OrOlder(DriversObject driver, int driverIndex)
    {
        var dob = DateTime.Parse(driver.DateOfBirth);
        var over55BeforeNow = DateTime.Now.AddYears(-55);
        if (dob <= over55BeforeNow)
        {
            CA_SummaryPage.ILDefensiveDriving(driverIndex).AssertPairExactAnswer(driver.DriverDefDrivingCourse);
            VerifyILViolationsIfNoDrivingCourse(driver, driverIndex);
        }
    }

    private static void VerifyILViolationsIfNoDrivingCourse(DriversObject driver, int driverIndex)
    {
        if (!Functions.ConvertYesOrNoStringToBool(driver.DriverDefDrivingCourse))
        {
            CA_SummaryPage.ILDriverViolations(driverIndex).AssertPairExactAnswer(driver.DriverILViolations);
            VerifyILRevokedIfNoViolations(driver, driverIndex);
        }
    }

    private static void VerifyILRevokedIfNoViolations(DriversObject driver, int driverIndex)
    {
        if (!Functions.ConvertYesOrNoStringToBool(driver.DriverILViolations))
        {
            CA_SummaryPage.ILLicenseRevoked(driverIndex).AssertPairExactAnswer(driver.DriverILDLRevoked);
        }
    }

    private void AssertQAPairIfAnswerProvided(string answer, SummaryQAPair pair, string altFormat = null)
    {
        if (!string.IsNullOrEmpty(answer))
        {
            pair.AssertPairExactAnswer(altFormat ?? answer);
        }
    }

    private void AssertQAPairIfAnswerProvided(int answer, SummaryQAPair pair, string altFormat = null)
    {
        if (answer != 0)
        {
            pair.AssertPairExactAnswer(altFormat ?? answer.ToString());
        }
    }
}