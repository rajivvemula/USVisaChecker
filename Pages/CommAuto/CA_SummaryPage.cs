using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Summary")]
    public sealed class CA_SummaryPage
    {
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(YourSummaryTitle, HeresWhatYouveToldUs);
        /*
        * Headers----------------------------------------------------------
        */

        //Your Summary
        public static Element YourSummaryTitle => new Element(By.XPath("//h1[@data-qa='summary-name']"));
        
        //Here's what you've told us.  You may review or edit your answers below.
        public static Element HeresWhatYouveToldUs => new Element(By.XPath("//p[@data-qa='summary-subheader-name']"));

        //View Quote >
        public static Element HeaderViewQuoteCTA => new Element(By.XPath("//button[@data-qa='viewQuote']"));


        /*
        * Sections----------------------------------------------------------
        */

        /*
         * Lets Start Your Quote--------------------------------------------
         */

        //Lets Start Your Quote
        public static Element StartYourQuoteTitle => new Element(By.XPath("//h3[@data-qa='start-quote-header-name']"));
        public static Element StartYourQuoteEdit => new Element(By.XPath("//mat-icon[@data-qa='start-quote-button']"));
        //What's the name of your business?
        public static Element NameOfBusinessQST => new Element(By.XPath("//p[@data-qa='businessName-question']"));
        public static Element NameofBusinessAnswer => new Element(By.XPath("//p[@data-qa='businessName-response']"));
        public static SummaryQAPair NameOfBusiness => new SummaryQAPair(NameOfBusinessQST, NameofBusinessAnswer);
        //Do you do business under another name?
        public static Element AnotherNameQST => new Element(By.XPath("//p[@data-qa='hasDba-question']"));
        public static Element AnotherNameAnswer => new Element(By.XPath("//p[@data-qa='hasDba-response']"));
        public static SummaryQAPair AnotherName => new SummaryQAPair(AnotherNameQST, AnotherNameAnswer);
        //What's the other business name?
        public static Element OtherBusinessQST => new Element(By.XPath("//p[@data-qa='dbaName-question']"));
        public static Element OtherBusinessAnswer => new Element(By.XPath("//p[@data-qa='dbaName-response']"));
        public static SummaryQAPair OtherBusiness => new SummaryQAPair(OtherBusinessQST, OtherBusinessAnswer);
        //When should your policy start?
        public static Element PolicyStartQST => new Element(By.XPath("//p[@data-qa='policyStart-question']"));
        public static Element PolicyStartAnswer => new Element(By.XPath("//p[@data-qa='policyStart-response']"));
        public static SummaryQAPair PolicyStart => new SummaryQAPair(PolicyStartQST, PolicyStartAnswer);
        /*
         * A Quick Introduction--------------------------------------------
         */

        //A Quick Introduction
        public static Element AQuickIntroTitle => new Element(By.XPath("//h3[@data-qa='Introduction-header']"));
        //A Quick Introduction - Pencil/Edit
        public static Element AQuickIntroEdit => new Element(By.XPath("//button[@data-qa='Introduction-edit']"));
        //What year was your business started?
        public static Element YearOfBusinessStartQST => new Element(By.XPath("//p[@data-qa='YearBusinessStarted-label']"));
        public static Element YearOfBusinessStartAnswer => new Element(By.XPath("//p[@data-qa='YearBusinessStarted-response']"));
        public static SummaryQAPair YearOfBusinessStart => new SummaryQAPair(YearOfBusinessStartQST, YearOfBusinessStartAnswer);
        //How is your business structured?
        public static Element BusinessStructuredQST => new Element(By.XPath("//p[@data-qa='BusinessStructure-label']"));
        public static Element BusinessStructuredAnswer => new Element(By.XPath("//p[@data-qa='BusinessStructure-response']"));
        public static SummaryQAPair BusinessStructured => new SummaryQAPair(BusinessStructuredQST, BusinessStructuredAnswer);
        //What type of government entity is it?
        public static Element TypeGovEntityQST => new Element(By.XPath("//p[@data-qa='GovernmentEntityType-label']"));
        public static Element TypeGovEntityAnswer => new Element(By.XPath("//p[@data-qa='GovernmentEntityType-response']"));
        //Business Address
        public static Element BusinessAddressQST => new Element(By.XPath("//p[@data-qa='PhysicalBusinessAddress-label']"));
        public static Element BusinessAddressAnswer => new Element(By.XPath("//p[@data-qa='PhysicalBusinessAddress-response']"));
        public static SummaryQAPair BusinessAddress => new SummaryQAPair(BusinessAddressQST, BusinessAddressAnswer);
        //Use Different Mailing Address?
        public static Element UseBusinessAsMailingAddressQST => new Element(By.XPath("//p[@data-qa='MailingAddressDifferent-label']"));
        public static Element UseBusinessAsMailingAddressAnswer => new Element(By.XPath("//p[@data-qa='MailingAddressDifferent-response']"));
        public static SummaryQAPair UseBusinessAsMailingAddress => new SummaryQAPair(UseBusinessAsMailingAddressQST, UseBusinessAsMailingAddressAnswer);
        //Mailing Address
        public static Element MailingAddressQST => new Element(By.XPath("//p[@data-qa='MailingBusinessAddress-label']"));
        public static Element MailingAddressAnswer => new Element(By.XPath("//p[@data-qa='MailingBusinessAddress-response']"));
        public static SummaryQAPair MailingAddress => new SummaryQAPair(MailingAddressQST, MailingAddressAnswer);

        /*
         * Your Vehicles---------------------------------------------------
         */
        //Your Vehicles
        public static Element YourVehicles => new Element(By.XPath("//h3[@data-qa='Vehicles-header']"));
        //Your Vehicles - Pencil/Edit
        public static Element YourVehiclesEdit => new Element(By.XPath("//button[@data-qa='Vehicles-edit']"));
        //Vehicle/Trailer Year Make Model
        public static Element VehicleYrMkMdl(string yearMakeModel) => new Element(By.XPath($"(//ca-vehicle-summary/h6[text()='{yearMakeModel}'])"));
        // Do you want to use your vehicle identification number (VIN) to autofill your vehicle data?
        public static Element WantToUseVINQST(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[contains(@data-qa,'-usingVin-question')]"));
        public static Element WantToUseVINAnswer(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[contains(@data-qa,'-usingVin-response')]"));
        public static SummaryQAPair WantToUseVIN(string yearMakeModel) => new SummaryQAPair(WantToUseVINQST(yearMakeModel), WantToUseVINAnswer(yearMakeModel));        public static SummaryQAPair WantToUseVin(string yearMakeModel) => new SummaryQAPair(WantToUseVINQST(yearMakeModel), WantToUseVINAnswer(yearMakeModel));

        //What is your vehicle identification number (VIN)?
        public static Element WhatIsVINQST(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[contains(@data-qa,'-vinNumber-question')]"));
        public static Element WhatIsVINAnswer(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[contains(@data-qa,'-vinNumber-response')]"));
        public static SummaryQAPair WhatIsVIN(string yearMakeModel) => new SummaryQAPair(WhatIsVINQST(yearMakeModel), WhatIsVINAnswer(yearMakeModel));

        // What would you like to insure? - Submitted without VIN
        public static Element WhatWouldYouLikeToInsureQST(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[contains(@data-qa,'-vehicleType-question')]"));
        public static Element WhatWouldYouLikeToInsureAnswer(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[contains(@data-qa,'-vehicleType-response')]"));
        public static SummaryQAPair WhatWouldYouLikeToInsure(string yearMakeModel) => new SummaryQAPair(WhatWouldYouLikeToInsureQST(yearMakeModel), WhatWouldYouLikeToInsureAnswer(yearMakeModel));

        // Year, make, and model - Vehicle submitted without VIN
        public static Element WhatsYearMakeModelQST(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[starts-with(@data-qa,'vehicle-powered') and contains(@data-qa,'-vehicleMakeModel-question')]"));
        public static Element WhatsYearMakeModelAnswer(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[starts-with(@data-qa,'vehicle-powered') and contains(@data-qa,'-vehicleMakeModel-response')]"));
        public static SummaryQAPair WhatsYearMakeModel(string yearMakeModel) => new SummaryQAPair(WhatsYearMakeModelQST(yearMakeModel), WhatsYearMakeModelAnswer(yearMakeModel));

        // Year, make - Trailer submitted without VIN
        public static Element WhatsYearMakeQST(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[starts-with(@data-qa,'vehicle-nonpowered') and contains(@data-qa,'-vehicleMakeModel-question')]"));
        public static Element WhatsYearMakeAnswer(string yearMakeModel) => new Element(By.XPath($"//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following-sibling::p[starts-with(@data-qa,'vehicle-nonpowered') and contains(@data-qa,'-vehicleMakeModel-response')]"));
        public static SummaryQAPair WhatsYearMake(string yearMakeModel) => new SummaryQAPair(WhatsYearMakeQST(yearMakeModel), WhatsYearMakeAnswer(yearMakeModel));

        // What state is this vehicle's parking address in?
        public static Element ParkingAddressStateQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='VehicleParkingAddrsIn-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element ParkingAddressStateAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='VehicleParkingAddrsIn-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair ParkingAddressState(int vehicleIndexNum) => new SummaryQAPair(ParkingAddressStateQST(vehicleIndexNum), ParkingAddressStateAnswer(vehicleIndexNum));

        // Is this trailer's parking address in a state other than __?
        public static Element TrailerAddressStateQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'TrailerParkingAddrsIn-label{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static Element TrailerAddressStateAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'TrailerParkingAddrsIn-response{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static SummaryQAPair TrailerAddressState(int vehicleIndexNum) => new SummaryQAPair(TrailerAddressStateQST(vehicleIndexNum), TrailerAddressStateAnswer(vehicleIndexNum));

        //If you sold this vehicle today, how much would it be worth?
        public static Element SoldVehicleTodayWorthQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'VehicleValue-label{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static Element SoldVehicleTodayWorthAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'VehicleValue-response{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static SummaryQAPair SoldVehicleTodayWorth(int vehicleIndexNum) => new SummaryQAPair(SoldVehicleTodayWorthQST(vehicleIndexNum), SoldVehicleTodayWorthAnswer(vehicleIndexNum));

        // If you sold this trailer today, how much would it be worth?
        public static Element SoldTrailerTodayWorthQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'TrailerValue-label_')])[{vehicleIndexNum}]"));
        public static Element SoldTrailerTodayWorthAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'TrailerValue-response_')])[{vehicleIndexNum}]"));
        public static SummaryQAPair SoldTrailerTodayWorth(int vehicleIndexNum) => new SummaryQAPair(SoldTrailerTodayWorthQST(vehicleIndexNum), SoldTrailerTodayWorthAnswer(vehicleIndexNum));

        // What is the gross vehicle weight rating (GVWr) of the vehicle?
        public static Element GrossWeightQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='GVWr-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element GrossWeightAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='GVWr-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair GrossWeight(int vehicleIndexNum) => new SummaryQAPair(GrossWeightQST(vehicleIndexNum), GrossWeightAnswer(vehicleIndexNum));

        // Is this vehicle used to escort trucks with large loads or guide them through road construction?
        public static Element EscortTrucksQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='EscortConstruction-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element EscortTrucksAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='EscortConstruction-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair EscortTrucks(int vehicleIndexNum) => new SummaryQAPair(EscortTrucksQST(vehicleIndexNum), EscortTrucksAnswer(vehicleIndexNum));
        //How many locations at most does this food truck visit in 1 day?
        public static Element FoodTruckLocationsQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='FoodTruckLocations-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element FoodTruckLocationsAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='FoodTruckLocations-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair FoodTruckLocations(int vehicleIndexNum) => new SummaryQAPair(FoodTruckLocationsQST(vehicleIndexNum), FoodTruckLocationsAnswer(vehicleIndexNum));
        //Does this vehicle haul to landfills?
        public static Element VehicleHaulLandfillsQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='Landfills-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element VehicleHaulLandfillsAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='Landfills-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair VehicleHaulLandfills(int vehicleIndexNum) => new SummaryQAPair(VehicleHaulLandfillsQST(vehicleIndexNum), VehicleHaulLandfillsAnswer(vehicleIndexNum));
        //Is this dump truck For Hire?
        public static Element DumpTruckHireQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='DumpTruckHire-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element DumpTruckHireAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='DumpTruckHire-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair DumpTruckHire(int vehicleIndexNum) => new SummaryQAPair(DumpTruckHireQST(vehicleIndexNum), DumpTruckHireAnswer(vehicleIndexNum));
        //Does this vehicle have a seatbelt for every passenger?
        public static Element SeatbeltEveryoneQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='Seatbelts-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element SeatbeltEveryoneAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='Seatbelts-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair SeatbeltEveryone(int vehicleIndexNum) => new SummaryQAPair(SeatbeltEveryoneQST(vehicleIndexNum), SeatbeltEveryoneAnswer(vehicleIndexNum));
        //How many passengers can this vehicle seat (exclude the driver)?
        // sample refactoring: public static Element HowManyCanSeatQST(string yearMakeModel) => new Element(By.XPath($"//h6[text()='{yearMakeModel}']//ancestor::mat-card/descendant::p[@data-qa='VehicleSeatCount-label']"));
        public static Element HowManyCanSeatQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='VehicleSeatCount-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element HowManyCanSeatAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='VehicleSeatCount-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair HowManyCanSeat(int vehicleIndexNum) => new SummaryQAPair(HowManyCanSeatQST(vehicleIndexNum), HowManyCanSeatAnswer(vehicleIndexNum));
        //Is this vehicle used for auto reposession?
        public static Element AutoRepoQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='Repossession-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element AutoRepoAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='Repossession-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair AutoRepo(int vehicleIndexNum) => new SummaryQAPair(AutoRepoQST(vehicleIndexNum), AutoRepoAnswer(vehicleIndexNum));
        //What route(s) does this bus take?
        public static Element RoutesBusTakesQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='BusRoutes-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element RoutesBusTakesAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='BusRoutes-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair RoutesBusTakes(int vehicleIndexNum) => new SummaryQAPair(RoutesBusTakesQST(vehicleIndexNum), RoutesBusTakesAnswer(vehicleIndexNum));
        //How is this vehicle used?
        public static Element HowVehicleUsedQST(string yearMakeModel) => new Element(By.XPath($"(//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following::p[@data-qa='VehicleUseRetail-label'])"));
        public static Element HowVehicleUsedAnswer(string yearMakeModel) => new Element(By.XPath($"(//ca-vehicle-summary/h6[text()='{yearMakeModel}']/following::p[@data-qa='VehicleUseRetail-response'])"));
        public static SummaryQAPair HowVehicleUsed(string yearMakeModel) => new SummaryQAPair(HowVehicleUsedQST(yearMakeModel), HowVehicleUsedAnswer(yearMakeModel));
        //Is this vehicle used to deliver goods or materials?
        public static Element DeliverGoodsMaterialsQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'GoodsOrMaterials') and contains(@data-qa,'-label{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static Element DeliverGoodsMaterialsAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'GoodsOrMaterials') and contains(@data-qa,'-response{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static SummaryQAPair DeliverGoodsMaterials(int vehicleIndexNum) => new SummaryQAPair(DeliverGoodsMaterialsQST(vehicleIndexNum), DeliverGoodsMaterialsAnswer(vehicleIndexNum));
        //Is this vehicle used to travel to client locations?
        public static Element TravelToClientsQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='TravelClient-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element TravelToClientsAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='TravelClient-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair TravelToClients(int vehicleIndexNum) => new SummaryQAPair(TravelToClientsQST(vehicleIndexNum), TravelToClientsAnswer(vehicleIndexNum));
        //Does this vehicle have a fare box or meter that's on display for passengers during the ride?
        public static Element FareBoxDisplayedQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'TaxiMeter') and contains(@data-qa,'-label{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static Element FareBoxDisplayedAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'TaxiMeter') and contains(@data-qa,'-response{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static SummaryQAPair FareBoxDisplayed(int vehicleIndexNum) => new SummaryQAPair(FareBoxDisplayedQST(vehicleIndexNum), FareBoxDisplayedAnswer(vehicleIndexNum));
        //Is this vehicle used as a commuter shuttle to transport workers between their office and a public transport hub or their homes?
        public static Element CommuterShuttleQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='CommuterShuttle-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element CommuterShuttleAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='CommuterShuttle-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair CommuterShuttle(int vehicleIndexNum) => new SummaryQAPair(CommuterShuttleQST(vehicleIndexNum), CommuterShuttleAnswer(vehicleIndexNum));
        //Is this vehicle used as a shuttle to transport guests to/from the airport or other destinations?
        public static Element AirportShuttleQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='AirportShuttle-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element AirportShuttleAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='AirportShuttle-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair AirportShuttle(int vehicleIndexNum) => new SummaryQAPair(AirportShuttleQST(vehicleIndexNum), AirportShuttleAnswer(vehicleIndexNum));
        //Is this vehicle used to take groups of people to and/or from camps or activities?
        public static Element GroupsPplCampsQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='SummerCamp-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element GroupsPplCampsAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='SummerCamp-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair GroupsPplCamps(int vehicleIndexNum) => new SummaryQAPair(GroupsPplCampsQST(vehicleIndexNum), GroupsPplCampsAnswer(vehicleIndexNum));
        //Is this vehicle used to transport customers on tours or to other activities?
        public static Element TransportCustToursQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='TransportTours-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element TransportCustToursAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='TransportTours-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair TransportCustTours(int vehicleIndexNum) => new SummaryQAPair(TransportCustToursQST(vehicleIndexNum), TransportCustToursAnswer(vehicleIndexNum));
        //Do you use this vehicle to transport any patients/clients to medical outpatient visits?
        public static Element TransportMedicalOutpatientQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='Outpatient-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element TransportMedicalOutpatientAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='Outpatient-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair TransportMedicalOutpatient(int vehicleIndexNum) => new SummaryQAPair(TransportMedicalOutpatientQST(vehicleIndexNum), TransportMedicalOutpatientAnswer(vehicleIndexNum));
        //Is this vehicle used for plowing snow?
        public static Element PlowingSnowQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='PlowingSnow-label{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static Element PlowingSnowAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[@data-qa='PlowingSnow-response{MultipleIncidentsSuffix(vehicleIndexNum)}'])"));
        public static SummaryQAPair PlowingSnow(int vehicleIndexNum) => new SummaryQAPair(PlowingSnowQST(vehicleIndexNum), PlowingSnowAnswer(vehicleIndexNum));
        
        public static Element HaulLandfillsQST(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'Landfills-label{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static Element HaulLandfillsAnswer(int vehicleIndexNum) => new Element(By.XPath($"(//p[starts-with(@data-qa,'Landfills-response{MultipleIncidentsSuffix(vehicleIndexNum)}')])"));
        public static SummaryQAPair HaulLandfills(int vehicleIndexNum) => new SummaryQAPair(HaulLandfillsQST(vehicleIndexNum), HaulLandfillsAnswer(vehicleIndexNum));
        /*
         * Your Drivers-----------------------------------------------------
         */

        //Drivers
        public static Element DriversTitle => new Element(By.XPath("//h3[@data-qa='Drivers-header']"));
        //Your Drivers - Pencil/Edit
        public static Element YourDriversEdit => new Element(By.XPath("//button[@data-qa='Drivers-edit']"));

        //Driver - [Driver name]
        public static Element DriverNameTitle(string driverNameTitle) =>  new Element(By.XPath($"(//div/h6[text()='{driverNameTitle}'])"));
        //Driver Name
        public static Element DriverNameQST(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='Drivers-label{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static Element DriverNameAnswer(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='Drivers-response{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static SummaryQAPair DriverName(int driverIndexNum) => new SummaryQAPair(DriverNameQST(driverIndexNum), DriverNameAnswer(driverIndexNum));
        //Driver's License State
        public static Element DLStateQST(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='DriverLicenseState-label{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static Element DLStateAnswer(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='DriverLicenseState-response{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static SummaryQAPair DLState(int driverIndexNum) => new SummaryQAPair(DLStateQST(driverIndexNum), DLStateAnswer(driverIndexNum));
        //Date of Birth
        public static Element DateofBirthQST(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='DriverDOB-label{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static Element DateofBirthAnswer(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='DriverDOB-response{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static SummaryQAPair DateofBirth(int driverIndexNum) => new SummaryQAPair(DateofBirthQST(driverIndexNum), DateofBirthAnswer(driverIndexNum));
        //Does this driver have a Commercial Driver's License (CDL)?
        public static Element DriverCDLQST(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='CDL-label{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static Element DriverCDLAnswer(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='CDL-response{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static SummaryQAPair DriverCDL(int driverIndexNum) => new SummaryQAPair(DriverCDLQST(driverIndexNum), DriverCDLAnswer(driverIndexNum));
        //Has this driver completed the National Safety Council's Defensive Driving Course or
        //a motor vehicle accident prevention course approved by IL in the last 3 years?
        public static Element ILDefensiveDrivingQST(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='IL-DefensiveDriving-label{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static Element ILDefensiveDrivingAnswer(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='IL-DefensiveDriving-response{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static SummaryQAPair ILDefensiveDriving(int driverIndexNum) => new SummaryQAPair(ILDefensiveDrivingQST(driverIndexNum), ILDefensiveDrivingAnswer(driverIndexNum));
        //In the last year, has the driver had any violation of IL motor vehicle laws?
        public static Element ILDriverViolationsQST(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='IL-LastYearViolation-label{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static Element ILDriverViolationsAnswer(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='IL-LastYearViolation-response{MultipleIncidentsSuffix(driverIndexNum)}]"));
        public static SummaryQAPair ILDriverViolations(int driverIndexNum) => new SummaryQAPair(ILDriverViolationsQST(driverIndexNum), ILDriverViolationsAnswer(driverIndexNum));
        //In the last 3 years, has the driver had their driver's license revoked or suspended?
        public static Element ILLicenseRevokedQST(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='IL-Last3YearsLicenseSuspended-label{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static Element ILLicenseRevokedAnswer(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='IL-Last3YearsLicenseSuspended-response{MultipleIncidentsSuffix(driverIndexNum)}]"));
        public static SummaryQAPair ILLicenseRevoked(int driverIndexNum) => new SummaryQAPair(ILLicenseRevokedQST(driverIndexNum), ILLicenseRevokedAnswer(driverIndexNum));
        //Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years?
        public static Element AccidentPastFiveYearsQST(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='AccidentOrViolation-label{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static Element AccidentPastFiveYearsAnswer(int driverIndexNum) => new Element(By.XPath($"//p[@data-qa='AccidentOrViolation-response{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static SummaryQAPair AccidentPastFiveYears(int driverIndexNum) => new SummaryQAPair(AccidentPastFiveYearsQST(driverIndexNum), AccidentPastFiveYearsAnswer(driverIndexNum));
        //Driver's License Number
        public static Element DriverLicenseNumberQST(int driverIndexNum, State driverState) => new Element(By.XPath($"//p[@data-qa='DriverLicenseNumber_{driverState.Abbreviation}-label{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static Element DriverLicenseNumberAnswer(int driverIndexNum, State driverState) => new Element(By.XPath($"//p[@data-qa='DriverLicenseNumber_{driverState.Abbreviation}-response{MultipleIncidentsSuffix(driverIndexNum)}']"));
        public static SummaryQAPair DriverLicenseNumber(int driverIndexNum, State driverState) => new SummaryQAPair(DriverLicenseNumberQST(driverIndexNum, driverState), DriverLicenseNumberAnswer(driverIndexNum, driverState));
        /*
         * Drivers Incidents
         */
        //Driver's Incidents
        public static Element DriversIncidentsTitle => new Element(By.XPath("//h3[@data-qa='Driver Incidents-header']"));
        public static Element DriversIncidentsEdit => new Element(By.XPath("//button[@data-qa='Driver Incidents-edit']"));
        private static string MultipleIncidentsSuffix(int num) => num == 0 ? "" : $"_{num}";
        private static string MultipleViolationsInSameIncidentSuffix(int num) => num == 1 ? "" : num.ToString();
        //Which driver was involved in this incident?
        public static Element DriverInvolvedQST(int incidentNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidents-label{MultipleIncidentsSuffix(incidentNum)}']"));
        public static Element DriverInvolvedAnswer(int incidentNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidents-response{MultipleIncidentsSuffix(incidentNum)}']"));
        public static SummaryQAPair DriverInvolved(int incidentNum) => new SummaryQAPair(DriverInvolvedQST(incidentNum), DriverInvolvedAnswer(incidentNum));
        //What was the date of the incident?
        public static Element DateOfIncidentQST(int incidentNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidentDate-label{MultipleIncidentsSuffix(incidentNum)}']"));
        public static Element DateOfIncidentAnswer(int incidentNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidentDate-response{MultipleIncidentsSuffix(incidentNum)}']"));
        public static SummaryQAPair DateOfIncident(int incidentNum) => new SummaryQAPair(DateOfIncidentQST(incidentNum), DateOfIncidentAnswer(incidentNum));
        //What type of incident was it?
        public static Element TypeOfIncidentQST(int incidentNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidentType-label{MultipleIncidentsSuffix(incidentNum)}']"));
        public static Element TypeOfIncidentAnswer(int incidentNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidentType-response{MultipleIncidentsSuffix(incidentNum)}']"));
        public static SummaryQAPair TypeOfIncident(int incidentNum) => new SummaryQAPair(TypeOfIncidentQST(incidentNum), TypeOfIncidentAnswer(incidentNum));
        //Was the driver at fault?
        public static Element DriverAtFaultQST(int incidentNum) => new Element(By.XPath($"//p[@data-qa='DriverAccidentDetermination-label{MultipleIncidentsSuffix(incidentNum)}']"));
        public static Element DriverAtFaultAnswer(int incidentNum) => new Element(By.XPath($"//p[@data-qa='DriverAccidentDetermination-response{MultipleIncidentsSuffix(incidentNum)}']"));
        public static SummaryQAPair DriverAtFault(int incidentNum) => new SummaryQAPair(DriverAtFaultQST(incidentNum), DriverAtFaultAnswer(incidentNum));
        //What was the violation / conviction?
        public static Element WhatWasViolationQST(int incidentNum, int vcNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidentViolation{MultipleViolationsInSameIncidentSuffix(vcNum)}-label{MultipleIncidentsSuffix(incidentNum)}']"));
        public static Element WhatWasViolationAnswer(int incidentNum, int vcNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidentViolation{MultipleViolationsInSameIncidentSuffix(vcNum)}-response{MultipleIncidentsSuffix(incidentNum)}']"));
        public static SummaryQAPair WhatWasViolation(int incidentNum, int vcNum) => new SummaryQAPair(WhatWasViolationQST(incidentNum, vcNum), WhatWasViolationAnswer(incidentNum, vcNum));
        //Describe the violation / conviction:
        public static Element ViolationConvictionQST(int incidentNum, int vcNum) => new Element(By.XPath($"//p[@data-qa='DriverViolationDescription{MultipleViolationsInSameIncidentSuffix(vcNum)}-label{MultipleIncidentsSuffix(incidentNum)}']"));
        public static Element ViolationConvictionAnswer(int incidentNum, int vcNum) => new Element(By.XPath($"//p[@data-qa='DriverViolationDescription{MultipleViolationsInSameIncidentSuffix(vcNum)}-response{MultipleIncidentsSuffix(incidentNum)}']"));
        public static SummaryQAPair ViolationConviction(int incidentNum, int vcNum) => new SummaryQAPair(ViolationConvictionQST(incidentNum, vcNum), ViolationConvictionAnswer(incidentNum, vcNum));
        //Did this speeding violation also result in a reckless/careless driving conviction? (Y/N)
        public static Element RecklessQST(int incidentNum, int vcNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidentRecklessConviction{MultipleViolationsInSameIncidentSuffix(vcNum)}-label{MultipleIncidentsSuffix(incidentNum)}']"));
        public static Element RecklessAnswer(int incidentNum, int vcNum) => new Element(By.XPath($"//p[@data-qa='DriverIncidentRecklessConviction{MultipleViolationsInSameIncidentSuffix(vcNum)}-response{MultipleIncidentsSuffix(incidentNum)}']"));
        public static SummaryQAPair Reckless(int incidentNum, int vcNum) => new SummaryQAPair(RecklessQST(incidentNum, vcNum), RecklessAnswer(incidentNum, vcNum));
        //Was there another violation / conviction associated with this incident?
        public static Element AnotherViolationQST(int incidentNum, int nextVcNum) => new Element(By.XPath($"//p[@data-qa='DriverIncident{nextVcNum}Flag-label{MultipleIncidentsSuffix(incidentNum)}']"));
        public static Element AnotherViolationAnswer(int incidentNum, int nextVcNum) => new Element(By.XPath($"//p[@data-qa='DriverIncident{nextVcNum}Flag-response{MultipleIncidentsSuffix(incidentNum)}']"));
        public static SummaryQAPair AnotherViolation(int incidentNum, int nextVcNum) => new SummaryQAPair(AnotherViolationQST(incidentNum, nextVcNum), AnotherViolationAnswer(incidentNum, nextVcNum));

        /*
         * Your Operations==================================================
         */
        //Your Operations
        public static Element YourOperationsTitle => new Element(By.XPath("//h3[@data-qa='Operations-header']"));
        //Your Operations - Pencil/Edit
        public static Element YourOperationsEdit => new Element(By.XPath("//button[@data-qa='Operations-edit']"));

        public static Element OperationsQuestion(string questionAlias) => new Element($"//p[@data-qa='{questionAlias}-label']");
        public static Element OperationsResponse(string questionAlias) => new Element($"//p[@data-qa='{questionAlias}-response']");
        public static Element OperationsCheckboxResponseListItem(string bulletValue) => new Element($"//li[@data-qa='{bulletValue}']");
        public static SummaryQAPair OperationsQAPair(string questionAlias) => new SummaryQAPair(OperationsQuestion(questionAlias), OperationsResponse(questionAlias));

        /*
         * Your Contact Details-------------------------------+-------------
         */

        //Contact Details Header
        public static Element ContactDetailsHeader => new Element(By.XPath("//mat-card-header/h3[@data-qa='Contacts-header']"));
        //Contact Details - Pencil/Edit
        public static Element ContactDetailsEdit => new Element(By.XPath("//button[@data-qa='Contacts-edit']"));

        //Contacts
        public static Element ContactsNameQST => new Element(By.XPath("//div/p[@data-qa='Contacts-label']"));
        public static Element ContactsNameAnswer => new Element(By.XPath("//div/p[@data-qa='Contacts-response']"));
        public static SummaryQAPair ContactsName => new SummaryQAPair(ContactsNameQST, ContactsNameAnswer);
        //Business Email
        public static Element BusinessEmailQST => new Element(By.XPath("//div/p[@data-qa='BusinessEmail-label']"));
        public static Element BusinessEmailAnswer => new Element(By.XPath("//div/p[@data-qa='BusinessEmail-response']"));
        public static SummaryQAPair BusinessEmail => new SummaryQAPair(BusinessEmailQST, BusinessEmailAnswer);
        //Business Phone
        public static Element BusinessPhoneQST => new Element(By.XPath("//div/p[@data-qa='BusinessPhoneAndExt-label']"));
        public static Element BusinessPhoneAnswer => new Element(By.XPath("//div/p[@data-qa='BusinessPhoneAndExt-response']"));
        public static SummaryQAPair BusinessPhone => new SummaryQAPair(BusinessPhoneQST, BusinessPhoneAnswer);
        //Business Website
        public static Element BusinessWebsiteQST => new Element(By.XPath("//div/p[@data-qa='BusinessWebsite-label']"));
        public static Element BusinessWebsiteAnswer => new Element(By.XPath("//div/p[@data-qa='BusinessWebsite-response']"));
        public static SummaryQAPair BusinessWebsite => new SummaryQAPair(BusinessWebsiteQST, BusinessWebsiteAnswer);
        //Manager's
        public static Element ManagersNameQST => new Element(By.XPath("//div/p[@data-qa='AccountManagerName-label']"));
        public static Element ManagersNameAnswer => new Element(By.XPath("//div/p[@data-qa='AccountManagerName-response']"));
        public static SummaryQAPair ManagersName => new SummaryQAPair(ManagersNameQST, ManagersNameAnswer);
        //Business has an account manager with different contact information
        public static Element DiffAcctManagerQST => new Element(By.XPath("//div/p[@data-qa='IsAccountManagerDifferent-label']"));
        public static Element DiffAcctManagerAnswer => new Element(By.XPath("//div/p[@data-qa='IsAccountManagerDifferent-response']"));
        public static SummaryQAPair DiffAcctManager => new SummaryQAPair(DiffAcctManagerQST, DiffAcctManagerAnswer);
        //Account Manager/Broker's Email
        public static Element ManagerEmailQST => new Element(By.XPath("//div/p[@data-qa='AccountManagerEmail-label']"));
        public static Element ManagerEmailAnswer => new Element(By.XPath("//div/p[@data-qa='AccountManagerEmail-response']"));
        public static SummaryQAPair ManagerEmail => new SummaryQAPair(ManagerEmailQST, ManagerEmailAnswer);
        //Account Manager/Broker's Phone
        public static Element ManagerPhoneQST => new Element(By.XPath("//div/p[@data-qa='AccountManagerPhoneAndExt-label']"));
        public static Element ManagerPhoneAnswer => new Element(By.XPath("//div/p[@data-qa='AccountManagerPhoneAndExt-response']"));
        public static SummaryQAPair ManagerPhone => new SummaryQAPair(ManagerPhoneQST, ManagerPhoneAnswer);
        //Primary Owner's Name
        public static Element OwnersNameQST => new Element(By.XPath("(//div/p[@data-qa='PrimaryOwnerName-label'])"));
        public static Element OwnersNameAnswer => new Element(By.XPath("(//div/p[@data-qa='PrimaryOwnerName-response'])"));
        public static SummaryQAPair OwnersName => new SummaryQAPair(OwnersNameQST, OwnersNameAnswer);
        //Primary Owner's Home Address
        public static Element OwnersAddressQST => new Element(By.XPath("(//div/p[@data-qa='PrimaryOwnerAddress-label'])"));
        public static Element OwnersAddressAnswer => new Element(By.XPath("(//div/p[@data-qa='PrimaryOwnerAddress-response'])"));
        public static SummaryQAPair OwnersAddress => new SummaryQAPair(OwnersAddressQST, OwnersAddressAnswer);


        /*
        * Page CTA----------------------------------------------------------
        */
        //Let's Continue
        public static Element FooterViewQuoteCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

        //Back
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));

    }
}
