using ApolloQA.Source.Driver;

namespace ApolloQA.Pages
{
    class LossDetails
    {
        // Loss Details
        public static Element LossDetailsButton = new Element("//bh-left-navbar/mat-sidenav/div/mat-nav-list/*/a/*[contains(text(), ' Loss Details ')]");
        public static Element LossDetailsHeading = new Element("//h2[contains(text(), 'Loss Details')]");
        public static Element CoverageTypeDropdown = new Element("//mat-select[@name='claimCoverageTypeIds']");
        public static Element CauseOfLossDropdown = new Element("//mat-select[@name='causeOfLossTypeId']");
        public static Element FaultIndicatorDropdown = new Element("//mat-select[@name='faultIndicatorTypeId']");
        public static Element ClaimsAdjusterDropdown = new Element("(//mat-select)[3]");
        public static Element ComplexityDropdown = new Element("//mat-select[@formcontrolname='complexityId']");
        public static Element SupervisorNotesInput = new Element("//textarea[@formcontrolname='supervisoryNotes']");

        // Other Insurer
        public static Element OtherInsurerInput = new Element("//input[@name='otherInsurer']");
        public static Element InsurerPolicyNumInput = new Element("//input[@name='otherInsurerPolicy']");
        public static Element InsurerClaimNumInput = new Element("//input[@name='otherInsurerClaim']");
        public static Element OtherInsurerAdjusterInput = new Element("//input[@name='otherInsurerAdjuster']");
        public static Element SuitFiledDropdown = new Element("//mat-select[@formcontrolname='isSuitFiled']");
        public static Element AttorneyAuthRepDropdown = new Element("//mat-select[@formcontrolname='authorizedRep']");
        public static Element ReportOnlyDropdown = new Element("//mat-select[@formcontrolname='isReportOnly']");

        // Vehicle Damage Info
        public static Element PointOfImpactDropdown = new Element("//mat-select[@name='pointOfImpactTypeId']");
        public static Element VehicleDrivabletDropdown = new Element("//mat-select[@formcontrolname='vehicleDrivableId']");
        public static Element VehicleDispositionDropdown = new Element("//mat-select[@name='vehicleDispositionId']");
        public static Element DamageSeenInput = new Element("(//textarea[@name='damageLocated'])[2]");
        public static Element EstimateOfLossInput = new Element("//input[@name='estimateOfLoss']");
        public static Element SubrogationReferralDropdown = new Element("//mat-select[@formcontrolname='subrogationReferralId']");
        public static Element UsedWithPermissionDropdown = new Element("//mat-select[@formcontrolname='usedWithPermissionId']");

        // Vehicle Owner
        public static Element InsuredButton = new Element("(//mat-radio-button//*[contains(text(), ' Insured ')])[1]");
        public static Element NotInsuredIndividualButton = new Element("//mat-radio-button//*[contains(text(), ' Not Insured - Individual ')]");
        public static Element NotInsuredBusinessButton = new Element("//mat-radio-button//*[contains(text(), ' Not Insured - Business ')]");
        public static Element NotInsuredFirstNameInput = new Element("//input[@name='firstName']");
        public static Element NotInsuredMiddleNameInput = new Element("//input[@name='middleName']");
        public static Element NotInsuredLastNameInput = new Element("//input[@name='lastName']");
        public static Element NotInsuredEmailInput = new Element("//input[@name='firstName']");
        public static Element NotInsuredSuffixInput = new Element("//input[@name='suffix']");
        public static Element NotInsuredAddPhoneButton = new Element("(//button//*[contains(text(), ' Add Phone ')])[2]");
        public static Element NotInsuredAddAddressButton = new Element("(//button//*[contains(text(), ' Add Address ')])[2]");

        // Vehicle Information
        public static Element VehicleOnPolicyButton = new Element("//mat-radio-button//*[contains(text(), 'Vehicle on Policy')]");
        public static Element SelectVehicleOnPolicyDropdown = new Element("//mat-select[@name='vehicleOnPolicyId']");
        public static Element VinNumberInput = new Element("//input[@name='vehicleVin']");
        public static Element MakeInput = new Element("//input[@name='vehicleMake']");
        public static Element ModelInput = new Element("//input[@name='vehicleModel']");
        public static Element ModelYearInput = new Element("//input[@name='vehicleYearOfManufacture']");
        public static Element LicensePlateStateDropdown = new Element("//mat-select[@name='plateStateProvinceId']");
        public static Element LicensePlateNumberInput = new Element("//input[@name='plateNumber']");
        public static Element VehicleNotOnPolicyButton = new Element("//mat-radio-button//*[contains(text(), ' Vehicle Not on Policy ')]");
        public static Element SearchVintelligenceButton = new Element("//button//*[contains(text(), ' Search Vintelligence ')]");

        //Driver Information
        public static Element DriverOnPolicyButton = new Element("//mat-radio-button//*[contains(text(), ' Driver on Policy ')]");
        public static Element DriverInfoFirstNameInput = new Element("(//input[@name='firstName'])[3]");
        public static Element DriverInfoMiddleNameInput = new Element("(//input[@name='middleName'])[3]");
        public static Element DriverInfoLastNameInput = new Element("(//input[@name='lastName'])[3]");
        public static Element DriverInfoSuffixInput = new Element("(//input[@name='suffix'])[3]");
        public static Element DriverNotOnPolicyButton = new Element("//mat-radio-button//*[contains(text(), ' Driver Not on Policy ')]");
        public static Element DriverDateOfBirthInput = new Element("//input[@name='driverDateOfBirth']");
        public static Element DriversLicenseStateDropdown = new Element("//mat-select[@name='driverStateProvinceId']");
        public static Element DriverLicenseNumberInput = new Element("//input[@formcontrolname='driverLicenseNo']");
        public static Element NoDriverButton = new Element("//mat-radio-button//*[contains(text(), ' No Driver ')]");
        public static Element UnknownDriverButton = new Element("//mat-radio-button//*[contains(text(), ' Unknown ')]");
        public static Element RelationshipToInsuredDropdown = new Element("//mat-select[@formcontrolname='relationshipTypeId']");

        //Action buttons
        public static Element SaveButton = new Element("//button//*[contains(text(), ' Save ')]");
        public static Element CancelButton = new Element("//button//*[contains(text(), ' Cancel ')]");
        public static Element AddContactsButton = new Element("//button//*[contains(text(), ' Add Contacts ')]");
    }
}
