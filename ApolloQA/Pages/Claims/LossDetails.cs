using ApolloQA.Source.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class LossDetails
    {
        // Loss Details
        public static Element LossDetailsButton = new Element("//bh-left-navbar/mat-sidenav/div/mat-nav-list/*/a/*[contains(text(), ' Loss Details ')]");
        public static Element LossDetailsHeading = new Element("//h2[contains(text(), 'Loss Details')]");
        public static Element FirstPartyButton = new Element("//mat-radio-button//*[contains(text(), ' First Party ')]");
        public static Element ThirdPartyButton = new Element("//mat-radio-button//*[contains(text(), ' Third Party ')]");
        public static Element BodilyInjuryButton = new Element("//mat-radio-button//*[contains(text(), ' Bodily Injury ')]");
        public static Element PropertyDamageButton = new Element("//mat-radio-button//*[contains(text(), ' Property Damage ')]");
        public static Element FaultIndicatorDropdown = new Element("//mat-select[@name='faultIndicatorTypeId']");
        public static Element ClaimsAdjusterDropdown = new Element("//mat-select[@id='mat-select-48']");
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
        public static Element PointOfImpactDropdown = new Element("");
        public static Element VehicleDrivabletDropdown = new Element("");
        public static Element VehicleDispositionDropdown = new Element("");
        public static Element DamageSeenInput = new Element("");
        public static Element EstimateOfLossInput = new Element("");
        public static Element SubrogationReferralDropdown = new Element("");
        public static Element UsedWithPermissionDropdown = new Element("");

        // Vehicle Owner
        public static Element InsuredButton = new Element("");
        public static Element NotInsuredIndividualButton = new Element("");
        public static Element NotInsuredBusinessButton = new Element("");
        public static Element NotInsuredFirstNameInput = new Element("");
        public static Element NotInsuredMiddleNameInput = new Element("");
        public static Element NotInsuredLastNameInput = new Element("");
        public static Element NotInsuredEmailInput = new Element("");
        public static Element NotInsuredSuffixInput = new Element("");
        public static Element NotInsuredAddPhoneButton = new Element("");
        public static Element NotInsuredAddAddressButton = new Element("");

        // Vehicle Information
        public static Element VehicleOnPolicyButton = new Element("");
        public static Element VehicleNotOnPolicyButton = new Element("");

        //Driver Information
        public static Element DriverOnPolicyButton = new Element("");
        public static Element DriverNotOnPolicyButton = new Element("");
        public static Element NoDriverButton = new Element("");
        public static Element RelationshipToInsuredDropdown = new Element("");

        //Action buttons
        public static Element SaveButton = new Element("//button//*[contains(text(), ' Save ')]");
        public static Element CancelButton = new Element("//button//*[contains(text(), ' Cancel ')]");
        public static Element AddContactsButton = new Element("//button//*[contains(text(), ' Add Contacts ')]");
    }
}
