using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Driver.Input;
using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages
{
    [Mapping("CA Vehicles")]
    public sealed class CA_VehiclesPage
    {
        public static LoadingRequirements LoadingRequirements =>
            new LoadingRequirements(YourVehiclesTitle, PleaseShareSomeDetails);

        /*
        * Headers----------------------------------------------------------
        */

        // Your Commercial Auto Quote ID: ######
        public static Element CAQuoteID => new Element(By.XPath("//div[@data-qa='quoteID-ribbon']"));

        // Your Vehicles
        public static Element YourVehiclesTitle => new Element(By.XPath("//h1[@data-qa='Vehicles-label']"));

        // Please share some details about your vehicles.
        public static Element PleaseShareSomeDetails => new Element(By.XPath("//p[@data-qa='Vehicles-sub-label']"));

        //Expanded Vehicle Panel (click after it is fully filled out)
        public static Element ExpandedVehiclePanel => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='true']"));

        //Disabled Vehicle Panel (after expanded completed vehicle panel is collapsed, it becomes disabled for a bit)
        public static Element DisabledVehiclePanel => new Element(By.XPath("//bb-expansion-panel[starts-with(@style,'transition: background-color 1.5s')]"));

        //Unexpanded vehicle panel
        public static Element UnexpandedVehiclePanel => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']"));

        /*
        * Questions----------------------------------------------------------
        */

        // Do you want to use your vehicle identification number (VIN) to autofill your vehicle data?
        public static Element WantToUseVINQST => new Element(By.XPath("(//label[starts-with(@data-qa,'isVinTelligence-')])[last()]"));
        public static Element WantToUseVINYes => new Element(By.XPath("(//button[contains(@data-qa,'vin') and contains(@data-qa,'-yes-button')])[last()]"));
        public static Element WantToUseVINNo => new Element(By.XPath("(//button[contains(@data-qa,'vin') and contains(@data-qa,'-no-button')]/div)[last()]"));
        public static YesOrNoGroup WantToUseVINGroup => new YesOrNoGroup(WantToUseVINYes, WantToUseVINNo);
        public static InputSection WantToUseVINInput => new YesOrNoInput(WantToUseVINGroup)
            .AsAQuestion(WantToUseVINQST);

        //What is your vehicle identification number (VIN)?
        public static Element WhatIsVINQST => new Element(By.XPath("(//label[starts-with(@data-qa,'vin-')])[last()]"));
        public static Element WhatIsVINTxtbox => new Element(By.XPath("(//div/ca-vin-input/input[contains(@data-qa,'vin-')])[last()]"));
        public static Element WhatIsVIN_HelperSymbol => new Element(By.XPath("(//button[starts-with(@data-qa,'buttonShowHelpToggle-vin-')])[last()]"));
        public static Element WhatIsVIN_HelperText => new Element(By.XPath("//p[starts-with(@data-qa,'bbHelpText-vin-')]"));
        public static Element WhatIsVIN_HelperX => new Element(By.XPath("//button[starts-with(@data-qa,'buttonClose-bbHelpText-vin-')]"));
        public static Element WhatIsVINError => new Element(By.XPath("//mat-error[@data-qa='vinNumber-error']"));
        public static InputSection WhatIsVINInput => new TextBoxInput(WhatIsVINTxtbox)
            .AsAQuestion(WhatIsVINQST)
            .WithHelpText(WhatIsVIN_HelperSymbol, WhatIsVIN_HelperText, WhatIsVIN_HelperX)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Select a VIN (Suggested VIN Example: JH4DA1745GP002661)
        public static Element SelectAVINTitle => new Element(By.XPath("//div[@data-qa='vin-select-panel-title']"));
        public static Element ConfirmYourVehicleTxt => new Element(By.XPath("//p[@data-qa='vin-select-panel-title-info']"));
        public static Element OrignalVINTitle => new Element(By.XPath("//p[@data-qa='vin-select-card-original-card-title']"));
        public static Element OrignalVINValue => new Element(By.XPath("//p[@data-qa='vin-select-card-original-card-value']"));
        public static Element SuggestedVINTitle => new Element(By.XPath("//p[@data-qa='vin-select-card-suggested-card-title']"));
        public static Element SuggestedVINValue => new Element(By.XPath("//p[@data-qa='vin-select-card-suggested-card-value']"));
        public static ChoiceGroup SelectAVINGroup => 
            new ChoiceGroup(choice => new Element(By.XPath($"//button[@data-qa='vin-select-card-{choice}-btn']")));
        public static InputSection SelectAVINInput => new SingleChoiceGroupInput(SelectAVINGroup)
            .AsAQuestion(ConfirmYourVehicleTxt)
            .WithExtraText(SelectAVINTitle, OrignalVINTitle, OrignalVINValue, SuggestedVINTitle, SuggestedVINValue);

        //Vehicle Details
        public static Element VehicleDetailsHeader => new Element(By.XPath("(//label[starts-with(@data-qa,'details-')])[last()]"));
        public static Element VehicleYrMkMdl => new Element(By.XPath("(//div[starts-with(@data-qa,'makemodel-')])[last()]"));
        public static Element VehicleTrim => new Element(By.XPath("(//div[starts-with(@data-qa,'trim-')])[last()]"));
       
        public static InputSection VehicleDetails => new NoInput(VehicleDetailsHeader, VehicleYrMkMdl, VehicleTrim);

        //Trim Dropdown
        //appears ONLY if you insert a VIN that has multiple Trim types, one will be automatically populated
        public static Element WhatsTheTrimDD => new Element(By.XPath("(//mat-select[starts-with(@data-qa,'vehicle-trim-')])[last()]"));
        public static InputSection WhatsTheTrimInput => new MatDropdownInput(WhatsTheTrimDD);

        /*
         * Vehicle Buttons-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */

        // What would you like to insure?
        public static Element WhatWouldYouLikeToInsureQST => new Element(By.XPath("(//label[starts-with(@data-qa,'VehicleCategory-')])[last()]"));
        public static Element GetVehicleButton(string vehicleCode) => new Element($"(//button[contains(@data-qa, '{vehicleCode}-button')])[last()]");
        // Holds the "selected" value of the button
        public static Element GetVehicleValue(string vehicleCode) => new Element($"(//ca-vehicle-buttonlist-item[label/button[contains(@data-qa, '{vehicleCode}-button')]]/input)[last()]");
        public static Element Other => new Element(By.XPath("(//button[contains(@data-qa, '-VehicleCategory') and span[contains(text(), 'Other')]])[last()]"));
        public static Element OtherImage => new Element(By.XPath("(//button[contains(@data-qa, '-VehicleCategory') and span[contains(text(), 'Other')]]/img)[last()]"));
        public static ChoiceGroup VehicleBtnChoices => new ChoiceGroup(GetVehicleButton);
        public static ChoiceGroup VehicleBtnValues => new ChoiceGroup(GetVehicleValue);
        public static InputSection WhatWouldYouLikeToInsureInput => new VehicleTopFiveInput(VehicleBtnChoices, VehicleBtnValues, Other)
            .AsAQuestion(WhatWouldYouLikeToInsureQST);
        
        //These are the vehicle buttons and accordion menus
        //Vehicle Modal (once you click "Other")
        public static Element VehicleTypeHeader => new Element(By.XPath("(//h2[contains(@data-qa,'vehicleType-label')])[last()]"));
        public static Element VehicleTypeSubheader => new Element(By.XPath("(//p[contains(@data-qa,'vehicleType-subtext')])[last()]"));
        public static Element OtherVehicleModalExit => new Element(By.XPath("//button[@data-qa='close-otherVehicles-button']"));
        public static Element GetVehicleTypePopUpCategoryButton(string displayName) => new Element($"(//h6[normalize-space(text())='{displayName}'])[last()]");
        public static ChoiceGroup OtherVehicleModalAccordion => new ChoiceGroup(GetVehicleTypePopUpCategoryButton);
        public static InputSection OtherVehicleModal => new VehicleModalInput(OtherVehicleModalExit, OtherVehicleModalAccordion, VehicleBtnChoices, VehicleBtnValues)
            .WithExtraText(VehicleTypeHeader, VehicleTypeSubheader);

        // What's the year, make, and model?
        //mapped the question with just Year and Make so it handles checking for both the Trailer question "What's the year and make?" and the 
        //powered vehicles question "What's the year, make, and model?"
        public static Element WhatsYearMakeModelStyleQST => new Element(By.XPath("(//label[contains(@data-qa, 'year-make-') and contains(@data-qa,'-label')])[last()]"));
        public static Element WhatsTheYearTxtbox => new Element(By.XPath("(//input[contains(@data-qa,'-yearOfManufacture')])[last()]"));
        public static Element WhatsTheMakeDD => new Element(By.XPath("(//mat-select[contains(@data-qa,'-dropdownMake')])[last()]"));
        public static Element WhatsTheModelDD => new Element(By.XPath("(//mat-select[contains(@data-qa,'-dropdownModel')])[last()]"));
        public static Element YearAndMakeSpinner => new Element(By.XPath("(//mat-spinner[@data-qa='spinner'])[last()]"));
        //If you select for Model "I can't find my model" there is a textbox you fill out
        public static Element WhatsTheModelTxtbox => new Element(By.XPath("//input[starts-with(@data-qa,'vehicle') and contains(@data-qa,'-textModel')]"));
        public static InputSection YearMakeModelInput => 
            new YearMakeModelInput(WhatsTheYearTxtbox, WhatsTheMakeDD, WhatsTheModelDD, WhatsTheModelTxtbox, YearAndMakeSpinner)
                .AsAQuestion(WhatsYearMakeModelStyleQST);

        //What state is this vehicle's parking address in?
        public static Element StateParkingAddressStateQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_VehicleParkingAddrsIn_')])[last()]"));
        public static Element StateParkingAddressStateDD => new Element(By.XPath("(//mat-select[starts-with(@data-qa,'_apollo_VehicleParkingAddrsIn_')])[last()]"));
        public static Element StateParkingAddressHelper => new Element(By.XPath("buttonShowHelpToggle-_apollo_VehicleValue_1"));
        public static Element StateParkingAddressHelperText => new Element(By.XPath("(//p[starts-with(@data-qa,'bbHelpText-details-')])[last()]"));
        public static Element StateParkingAddressHelperX => new Element(By.XPath("(//button[starts-with(@data-qa,'buttonClose-bbHelpText-details-')])[last()]"));
        public static Element StateParkingAddressStateTextBelow => new Element(By.XPath("(//mat-hint[starts-with(@data-qa,'_apollo_VehicleParkingAddrsIn_')])[last()]"));
        public static InputSection StateParkingAddressStateInput => new MatDropdownInput(StateParkingAddressStateDD)
            .AsAQuestion(StateParkingAddressStateQST)
            .WithExtraText(StateParkingAddressStateTextBelow);

        //Is this trailer's parking address in a state other than []?
        public static Element TrailerParkingAddressQST => new Element(By.XPath("(//label[contains(@data-qa,'_apollo_TrailerParkingAddrsIn_') and contains(@data-qa,'-label')])[last()]"));
        public static Element TrailerParkingAddressDD => new Element(By.XPath("(//mat-select[starts-with(@data-qa,'_apollo_TrailerParkingAddrsIn_')])[last()]"));
        public static Element TrailerParkingAddressTextBelow => new Element(By.XPath("(//mat-hint[starts-with(@data-qa,'_apollo_TrailerParkingAddrsIn_')])[last()]"));
        public static InputSection TrailerParkingAddressInput => new MatDropdownInput(TrailerParkingAddressDD)
            .AsAQuestion(TrailerParkingAddressQST)
            .WithExtraText(TrailerParkingAddressTextBelow);

        //If you sold this vehicle today, how much would it be worth?
        public static Element SoldVehicleTodayWorthQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_VehicleValue_')])[last()]"));
        public static Element SoldVehicleTodayWorthTxtbox => new Element(By.XPath("(//input[starts-with(@data-qa,'_apollo_VehicleValue_')])[last()]"));
        public static Element SoldVehicleTodayWorth_HelperSymbol => new Element(By.XPath("(//button[starts-with(@data-qa,'buttonShowHelpToggle-_apollo_VehicleValue_')])[last()]"));
        public static Element SoldVehicleTodayWorth_HelperText => new Element(By.XPath("(//p[starts-with(@data-qa,'bbHelpText-_apollo_VehicleValue_')])[last()]"));
        public static Element SoldVehicleTodayWorth_HelperX => new Element(By.XPath("(//button[starts-with(@data-qa,'buttonClose-bbHelpText-_apollo_VehicleValue_')])[last()]"));
        public static InputSection SoldVehicleTodayWorthInput => new TextBoxInput(SoldVehicleTodayWorthTxtbox)
            .AsAQuestion(SoldVehicleTodayWorthQST)
            .WithHelpText(SoldVehicleTodayWorth_HelperSymbol, SoldVehicleTodayWorth_HelperText, SoldVehicleTodayWorth_HelperX);

        //If you sold this trailer today, how much would it be worth?
        public static Element SoldTrailerTodayWorthQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_TrailerValue_')and contains (@data-qa,'-label')])[last()]"));
        public static Element SoldTrailerTodayWorthTxtbox => new Element(By.XPath("(//input[contains(@data-qa,'_apollo_TrailerValue_')])[last()]"));
        public static Element SoldTrailerTodayWorthHelper => new Element(By.XPath("(//button[starts-with(@data-qa,'buttonShowHelpToggle-details-') or starts-with(@data-qa,'buttonShowHelpToggle-_apollo_TrailerValue')])[last()]"));
        public static Element SoldTrailerTodayWorthHelperText => new Element(By.XPath("(//p[starts-with(@data-qa,'bbHelpText-_apollo_TrailerValue')])[last()]"));
        public static Element SoldTrailerTodayWorthHelperX => new Element(By.XPath("(//button[starts-with(@data-qa,'buttonClose-bbHelpText-_apollo_TrailerValue')])[last()]"));
        public static InputSection SoldTrailerTodayWorthInput => new TextBoxInput(SoldTrailerTodayWorthTxtbox)
            .AsAQuestion(SoldTrailerTodayWorthQST);
            

        // What is the gross vehicle weight rating (GVWr) of the vehicle?
        public static Element GrossWeightQST => new Element(By.XPath("//label[starts-with(@data-qa,'_apollo_GVWr_')][last()]"));
        public static Element GrossWeightDD => new Element(By.XPath("//div/mat-select[starts-with(@data-qa, '_apollo_GVWr_')][last()]"));
        public static Element GrossWeightHelperIcon => new Element(By.XPath("//button[starts-with(@data-qa, 'buttonShowHelpToggle-_apollo_GVWr_')][last()]"));
        public static Element GrossWeightHelperText => new Element(By.XPath("//p[starts-with(@data-qa, 'bbHelpText-_apollo_GVWr_')][last()]"));
        public static Element GrossWeightHelperX => new Element(By.XPath("//button[starts-with(@data-qa, 'buttonClose-bbHelpText-_apollo_GVWr_')][last()]"));

        /// <summary>
        /// These are the available options to choose:
        /// 1-5000 lbs
        /// 5001-10000 lbs
        /// 10001-15000 lbs
        /// 15001-20000 lbs
        /// 20001-26000 lbs
        /// 26001-30000 lbs
        /// 30001-40000 lbs
        /// 40001-45000 lbs
        /// 45001+ lbs
        /// </summary>
        public static InputSection GrossWeightInput => new MatDropdownInput(GrossWeightDD)
            .AsAQuestion(GrossWeightQST)
            .WithHelpText(GrossWeightHelperIcon, GrossWeightHelperText, GrossWeightHelperX);
            

        // Is this vehicle used to escort trucks with large loads or guide them through road construction?
        public static Element EscortTrucksQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_EscortConstruction_')])[last()]"));
        public static Element EscortTrucksYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_EscortConstruction_') and contains(@data-qa,'yes-button')])[last()]"));
        public static Element EscortTrucksNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_EscortConstruction_') and contains(@data-qa,'no-button')])[last()]"));
        public static InputSection EscortTrucksInput => new YesOrNoInput(EscortTrucksYes, EscortTrucksNo)
            .AsAQuestion(EscortTrucksQST)            
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, 5);


        //How many locations at most does this food truck visit in 1 day?
        public static Element FoodTruckLocationsQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_FoodTruckLocations_')])[last()]"));
        public static Element FoodTruckLocations_SpecificLocation => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_FoodTruckLocations') and contains(@data-qa,'We park it at a specific location for the day-button')])[last()]"));
        public static Element FoodTruckLocations_UsualSpots => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_FoodTruckLocations') and contains(@data-qa,'We have usual spots, but sometimes may take it to another location-button')])[last()]"));
        public static Element FoodTruckLocations_3OrMore => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_FoodTruckLocations') and contains(@data-qa,'We drive it around all day-button')])[last()]"));
        public static ChoiceGroup FoodTruckLocationChoices => new ChoiceGroup(new Dictionary<string, Element>()
        {
            {"SpecificLocation", FoodTruckLocations_SpecificLocation},
            {"UsualSpots", FoodTruckLocations_UsualSpots},
            {"3OrMore", FoodTruckLocations_3OrMore}
        });
        public static InputSection FoodTruckLocationsInput => new SingleChoiceGroupInput(FoodTruckLocationChoices)
            .AsAQuestion(FoodTruckLocationsQST);

        //Does this vehicle haul to landfills?
        public static Element VehicleHaulLandfillsQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_Landfills_')])[last()]"));
        public static Element VehicleHaulLandfillsYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_Landfills') and contains(@data-qa,'-yes-button')])[last()]"));
        public static Element VehicleHaulLandfillsNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_Landfills') and contains(@data-qa,'-no-button')])[last()]"));
        public static InputSection VehicleHaulLandfillsInput => new YesOrNoInput(VehicleHaulLandfillsYes, VehicleHaulLandfillsNo)
            .AsAQuestion(VehicleHaulLandfillsQST);

        //Is this dump truck For Hire?
        public static Element DumpTruckHireQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_DumpTruckHire_')])[last()]"));
        public static Element DumpTruckHireYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_DumpTruckHire') and contains(@data-qa,'-Yes For Hire-button')])[last()]"));
        public static Element DumpTruckHireNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_DumpTruckHire') and contains(@data-qa,'-No Not For Hire-button')])[last()]"));
        public static Element DumpTruckHire_HelperSymbol => new Element(By.XPath("(//button[starts-with(@data-qa,'buttonShowHelpToggle-_apollo_DumpTruckHire_')])[last()]"));
        public static Element DumpTruckHire_HelperText => new Element(By.XPath("(//p[starts-with(@data-qa,'bbHelpText-_apollo_DumpTruckHire_')])[last()]"));
        public static Element DumpTruckHire_HelperX => new Element(By.XPath("(//button[starts-with(@data-qa,'buttonClose-bbHelpText-_apollo_DumpTruckHire_')])[last()]"));
        public static InputSection DumpTruckHireInput => new YesOrNoInput(DumpTruckHireYes, DumpTruckHireNo)
            .AsAQuestion(DumpTruckHireQST)
            .WithHelpText(DumpTruckHire_HelperSymbol, DumpTruckHire_HelperText, DumpTruckHire_HelperX);

        //Does this vehicle have a seatbelt for every passenger?
        public static Element SeatbeltEveryoneQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_Seatbelts_')])[last()]"));
        public static Element SeatbeltEveryoneYes => new Element(By.XPath("(//button[starts-with(@data-qa, '_apollo_Seatbelts') and contains(@data-qa, 'yes-button')])[last()]"));
        public static Element SeatbeltEveryoneNo => new Element(By.XPath("(//button[starts-with(@data-qa, '_apollo_Seatbelts') and contains(@data-qa, 'no-button')])[last()]"));
        public static InputSection SeatbeltEveryoneInput => new YesOrNoInput(SeatbeltEveryoneYes, SeatbeltEveryoneNo)
            .AsAQuestion(SeatbeltEveryoneQST)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //How many passengers can this vehicle seat (exclude the driver)?
        public static Element HowManyCanSeatQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_VehicleSeatCount_')])[last()]"));
        public static Element HowManyCanSeatDD => new Element(By.XPath("(//mat-select[starts-with(@data-qa,'_apollo_VehicleSeatCount_')])[last()]"));
        public static InputSection HowManyCanSeatInput => new MatDropdownInput(HowManyCanSeatDD)
            .AsAQuestion(HowManyCanSeatQST)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Is this vehicle used for auto reposession?
        public static Element AutoRepoQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_Repossession_')])[last()]"));
        public static Element AutoRepoResponse(string response) => new Element(By.XPath($"(//button[contains(@data-qa,'_apollo_Repossession') and contains(@data-qa,'{response}-button')])[last()]"));
        public static InputSection AutoRepoInput => new YesOrNoInput(AutoRepoResponse("yes"), AutoRepoResponse("no"))
            .AsAQuestion(AutoRepoQST)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //What route(s) does this bus take?
        public static Element RoutesBusTakesQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_BusRoutes_')])[last()]"));
        public static Element RoutesBusTakes_Local => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_BusRoutes') and contains(@data-qa, 'Local')])[last()]"));
        public static Element RoutesBusTakes_Regional => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_BusRoutes') and contains(@data-qa, 'Regional')])[last()]"));
        public static Element RoutesBusTakes_Other => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_BusRoutes') and contains(@data-qa, 'Other')])[last()]"));
        public static ChoiceGroup RoutesBusTakesChoices => new ChoiceGroup(new Dictionary<string, Element>()
        {
            {"Local", RoutesBusTakes_Local},
            {"Regional", RoutesBusTakes_Regional},
            {"Other", RoutesBusTakes_Other}
        });
        public static InputSection RoutesBusTakesInput => new SingleChoiceGroupInput(RoutesBusTakesChoices)
            .AsAQuestion(RoutesBusTakesQST);

        //How is this vehicle used?
        public static Element HowVehicleUsedQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_VehicleUse') and contains(@data-qa,'-label')])[last()]"));
        public static Element HowVehicleUsedOption(string optionText) => new Element(By.XPath($"(//button[starts-with(@data-qa,'_apollo_VehicleUse') and contains(@data-qa,'-{optionText}-button')])[last()]"));
        public static ChoiceGroup HowVehicleUsedChoices => new ChoiceGroup(HowVehicleUsedOption);
        public static InputSection HowVehicleUsedInput => new SingleChoiceGroupInput(HowVehicleUsedChoices)
            .AsAQuestion(HowVehicleUsedQST)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Is this vehicle used to deliver goods or materials?
        public static Element DeliverGoodsMaterialsQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_GoodsOrMaterials')])[last()]"));
        public static Element DeliverGoodsMaterialsYes => new Element(By.XPath("//button[starts-with(@data-qa,'_apollo_GoodsOrMaterials') and contains(@data-qa,'yes-button')]"));
        public static Element DeliverGoodsMaterialsNo => new Element(By.XPath("(//button[starts-with(@data-qa,'_apollo_GoodsOrMaterials') and contains(@data-qa,'no-button')])[last()]"));
        public static InputSection DeliverGoodsMaterialsInput => new YesOrNoInput(DeliverGoodsMaterialsYes, DeliverGoodsMaterialsNo)
            .AsAQuestion(DeliverGoodsMaterialsQST);

        //Is this vehicle used to travel to client locations?
        public static Element TravelToClientsQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_TravelClient')])[last()]"));
        public static Element TravelToClientsYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_TravelClient') and contains(@data-qa,'yes-button')])[last()]"));
        public static Element TravelToClientsNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_TravelClient') and contains(@data-qa,'no-button')])[last()]"));
        public static InputSection TravelToClientsInput => new YesOrNoInput(TravelToClientsYes, TravelToClientsNo)
            .AsAQuestion(TravelToClientsQST);

        //Does this vehicle have a fare box or meter that's on display for passengers during the ride?
        public static Element FareBoxDisplayedQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_TaxiMeter') and contains(@data-qa, '-label')])[last()]"));
        public static Element FareBoxDisplayedYes => new Element(By.XPath("(//button[starts-with(@data-qa,'_apollo_TaxiMeter') and contains(@data-qa, 'yes-button')])[last()]"));
        public static Element FareBoxDisplayedNo => new Element(By.XPath("(//button[starts-with(@data-qa,'_apollo_TaxiMeter') and contains(@data-qa, 'no-button')])[last()]"));
        public static InputSection FareBoxDisplayedInput => new YesOrNoInput(FareBoxDisplayedYes, FareBoxDisplayedNo)
            .AsAQuestion(FareBoxDisplayedQST);

        //Is this vehicle used as a commuter shuttle to transport workers between their office and a public transport hub or their homes?
        public static Element CommuterShuttleQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_CommuterShuttle_')])[last()]"));
        public static Element CommuterShuttleYes => new Element(By.XPath("(//button[contains(@data-qa, '_apollo_CommuterShuttle_') and contains(@data-qa, '-yes-button')])[last()]"));
        public static Element CommuterShuttleNo => new Element(By.XPath("(//button[contains(@data-qa, '_apollo_CommuterShuttle_') and contains(@data-qa, '-no-button')])[last()]"));
        public static InputSection CommuterShuttleInput => new YesOrNoInput(CommuterShuttleYes, CommuterShuttleNo)
            .AsAQuestion(CommuterShuttleQST)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Is this vehicle used as a shuttle to transport guests to/from the airport or other destinations?
        public static Element ShuttleTransportGuestsQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_AirportShuttle_')])[last()]"));
        public static Element ShuttleTransportGuestsYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_AirportShuttle') and contains(@data-qa,'yes-button')])[last()]"));
        public static Element ShuttleTransportGuestsNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_AirportShuttle') and contains(@data-qa,'no-button')])[last()]"));
        public static InputSection ShuttleTransportGuestsInput => new YesOrNoInput(ShuttleTransportGuestsYes, ShuttleTransportGuestsNo)
            .AsAQuestion(ShuttleTransportGuestsQST);

        //Is this vehicle used to take groups of people to and/or from camps or activities?
        public static Element GroupsPplCampsQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_SummerCamp')])[last()]"));
        public static Element GroupsPplCampsYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_SummerCamp') and contains(@data-qa,'yes-button')])[last()]"));
        public static Element GroupsPplCampsNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_SummerCamp') and contains(@data-qa,'no-button')])[last()]"));
        public static InputSection GroupsPplCampsInput => new YesOrNoInput(GroupsPplCampsYes, GroupsPplCampsNo)
            .AsAQuestion(GroupsPplCampsQST);

        //Is this vehicle used to transport customers on tours or to other activities?
        public static Element TransportCustToursQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_TransportTours')])[last()]"));
        public static Element TransportCustToursYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_TransportTours') and contains(@data-qa,'yes-button')])[last()]"));
        public static Element TransportCustToursNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_TransportTours') and contains(@data-qa,'no-button')])[last()]"));
        public static InputSection TransportCustToursInput => new YesOrNoInput(TransportCustToursYes, TransportCustToursNo)
            .AsAQuestion(TransportCustToursQST);

        //Do you use this vehicle to transport any patients/clients to medical outpatient visits?
        public static Element TransportMedicalOutpatientQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_Outpatient_')])[last()]"));
        public static Element TransportMedicalOutpatientYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_Outpatient') and contains(@data-qa,'yes-button')])[last()]"));
        public static Element TransportMedicalOutpatientNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_Outpatient') and contains(@data-qa,'no-button')])[last()]"));
        public static InputSection TransportMedicalOutpatientInput => new YesOrNoInput(TransportMedicalOutpatientYes, TransportMedicalOutpatientNo)
            .AsAQuestion(TransportMedicalOutpatientQST);

        //Is this vehicle used for plowing snow?
        public static Element PlowingSnowQST => new Element(By.XPath("(//label[starts-with(@data-qa, '_apollo_PlowingSnow_')])[last()]"));
        public static Element PlowingSnowYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_PlowingSnow_') and contains(@data-qa,'yes-button')])[last()]"));
        public static Element PlowingSnowNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_PlowingSnow_') and contains(@data-qa,'no-button')])[last()]"));
        public static InputSection PlowingSnowInput => new YesOrNoInput(PlowingSnowYes, PlowingSnowNo)
            .AsAQuestion(PlowingSnowQST);

        //Is this vehicle equipped with a fifth wheel or goose neck coupling device?
        public static Element FifthWheelQST => new Element(By.XPath("(//label[starts-with(@data-qa,'_apollo_FifthWheel')])[last()]"));
        public static Element FifthWheelYes => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_FifthWheel') and contains(@data-qa,'yes-button')])[last()]"));
        public static Element FifthWheelNo => new Element(By.XPath("(//button[contains(@data-qa,'_apollo_FifthWheel') and contains(@data-qa,'no-button')])[last()]"));
        public static InputSection FifthWheelInput => new YesOrNoInput(FifthWheelYes, FifthWheelNo)
            .AsAQuestion(FifthWheelQST)
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Is this vehicle used for towing or roadside assistance?
        public static Element VehicleUsedForTowingDD => new Element(By.XPath("(//mat-select[contains(@data-qa,'TowingAssistance')])[last()]"));
        public static InputSection VehicleUsedForTowingInput => new MatDropdownInput(VehicleUsedForTowingDD);

        //Remove button
        public static Element RemoveButton => new Element(By.XPath("//bb-remove-panel[@data-qa='VEHICLE/TRAILER-Remove-button']"));
                
        /*
         * Help and Error Text
         */
        public static Element GetFrontEndErrorText(string questionAlias) => new Element(By.XPath($"(//mat-error[@data-qa='{questionAlias}-error'])[last()]"));
        public static Element GetFrontEndHelpIcon(string questionAlias) => new Element(By.XPath($"(//button[starts-with(@data-qa,'buttonShowHelpToggle-{questionAlias}')])[last()]"));
        public static Element GetFrontEndHelpText(string questionAlias) => new Element(By.XPath($"(//p[starts-with(@data-qa,'bbHelpText-{questionAlias}')])[last()]"));
        public static Element GetFrontEndHelpExit(string questionAlias) => new Element(By.XPath($"(//button[starts-with(@data-qa,'buttonClose-bbHelpText-{questionAlias}')])[last()]"));

        public static Element GetApolloErrorText(string questionAlias) => new Element(By.XPath($"(//bb-error-message[contains(@data-qa,'_apollo_{questionAlias}') and contains(@data-qa, '-errorMessage')])[last()]"));
        public static Element GetApolloHelpIcon(string questionAlias) => new Element(By.XPath($"(//button[starts-with(@data-qa,'buttonShowHelpToggle-_apollo_{questionAlias}')])[last()]"));
        public static Element GetApolloHelpText(string questionAlias) => new Element(By.XPath($"(//p[starts-with(@data-qa,'bbHelpText-_apollo_{questionAlias}')])[last()]"));
        public static Element GetApolloHelpExit(string questionAlias) => new Element(By.XPath($"(//button[starts-with(@data-qa,'buttonClose-bbHelpText-_apollo_{questionAlias}')])[last()]"));

        public static Element AnyError => new Element(By.XPath("//bb-error-message"));
        //These are the error messages that appear when the page is left blank and try to continue forward. 
        public static Element PleaseFixFollowingError => new Element(By.XPath("(//div[contains(@data-qa,'bbnav-error-title')])[last()]"));
        public static Element OneOrMoreQuestionError => new Element(By.XPath("(//div[contains(@data-qa,'bbnav-error-message')])[last()]"));

        /*
        * Page CTA----------------------------------------------------------
        */

        //Add Another Vehicle or Trailer
        public static Element AddAnotherVehicleOrTrailer => new Element(By.XPath("//bb-add-panel[@data-qa='Vehicle-addPanel']/button"));

        //Let's Continue
        public static Element LetsContinueCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

        //Back
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));
    }
}
