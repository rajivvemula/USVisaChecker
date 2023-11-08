using System.Collections.Generic;
using System.ComponentModel;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA;

namespace BiBerkLOB.Pages.CommAuto
{
    [ResettableContextObject]
    public class CASummaryObject
    {
        private const double ZeroDecimalAmount = 0.0;
        
        //Let's Start Your Quote
        [DefaultValue("")] public string QuoteID { get; set; } = "";
        [DefaultValue("")] public string NameOfBusiness { get; set; } = "";
        [DefaultValue("")] public string DBAYesNo { get; set; } = "";
        [DefaultValue("")] public string DBAValue { get; set; } = "";
        [DefaultValue("")] public string PolicyStart { get; set; } = "";

        //A Quick Introduction
        [DefaultValue("")] public string YearBusStarted { get; set; } = "";
        [DefaultValue("")] public string HowBusStructured { get; set; } = "";
        [DefaultValue("")] public string GovEntityType { get; set; } = "";
        [DefaultValue(null)] public Address BusinessAddress { get; set; } = null;
        public bool BusinessAddressUsedSuggested { get; set; }
        [DefaultValue(true)] public bool UseBusinessAsMailingAddress { get; set; } = true;
        [DefaultValue(null)] public Address MailingAddress { get; set; } = null;
        public bool MailingAddressUsedSuggested { get; set; }

        //Vehicles
        [Clearable] public List<VehiclesObject> VehiclesList { get; set; } = new List<VehiclesObject>();

        //Drivers
        [Clearable] public List<DriversObject> DriversList { get; set; } = new List<DriversObject>();

        //Drivers Incidents
        [Clearable] public List<DriverIncidentObject> DriverIncidentList { get; set; } = new List<DriverIncidentObject>();

        //Operations
        //list of Questions pulled from the Feature file on the Operations page
        [Clearable] public List<OperationsQuestionObject> OpQuestions { get; set; } = new List<OperationsQuestionObject>();

        //Contact Details
        [DefaultValue("")] public string ContactFirstName { get; set; } = "";
        [DefaultValue("")] public string ContactLastName { get; set; } = "";
        [DefaultValue("")] public string BusinessEmail { get; set; } = "";
        [DefaultValue("")] public string BusinessPhone { get; set; } = "";
        [DefaultValue("")] public string BusinessExt { get; set; } = "";
        [DefaultValue("")] public string BusinessWebsite { get; set; } = "";
        [DefaultValue("No")] public string HasAccountManager { get; set; } = "No";
        [DefaultValue("")] public string ManagerFirstName { get; set; } = "";
        [DefaultValue("")] public string ManagerLastName { get; set; } = "";
        [DefaultValue("")] public string ManagerEmail { get; set; } = "";
        [DefaultValue("")] public string ManagerPhone { get; set; } = "";
        [DefaultValue("")] public string ManagerExt { get; set; } = "";
        [DefaultValue("")] public string PrimaryOwnerFirstName { get; set; } = "";
        [DefaultValue("")] public string PrimaryOwnerLastName { get; set; } = "";
        [DefaultValue(null)] public Address PrimaryOwnerAddress { get; set; } = null;
        public bool PrimaryOwnerAddressUsedSuggested { get; set; }
        public string VehicleRadiusAnswer { get; set; }

        //Your Quote Page
        [DefaultValue("")] public string QuoteChooseYearlyOrMonthly { get; set; } = "";
        [DefaultValue("")] public string AmountYouPayToday { get; set; } = "";
        [Clearable] public List<CACoverage> Coverages { get; set; } = new List<CACoverage>();

        //Purchase Page
        public decimal PaymentAmountMadeToday { get; set; }
        [DefaultValue("")] public string PaymentPlanChosen { get; set; } = "";

        public string ContactName() => $"{ContactFirstName} {ContactLastName}".Trim();
        public string ManagerName() => $"{ManagerFirstName} {ManagerLastName}".Trim();
        public string PrimaryOwnerName() => $"{PrimaryOwnerFirstName} {PrimaryOwnerLastName}".Trim();
    }
}
