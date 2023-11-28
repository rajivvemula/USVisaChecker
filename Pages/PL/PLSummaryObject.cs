using System.Collections.Generic;
using System.ComponentModel;
using HitachiQA;

namespace BiBerkLOB.Pages.PL
{
    [ResettableContextObject]
    public sealed class PLSummaryObject
    {
        //A Quick Introduction----------------------------------------------
        [DefaultValue("")] public string QuoteID { get; set; } = "";
        [DefaultValue("")] public string DBA { get; set; } = "";
        [DefaultValue("")] public string BusinessStruct { get; set; } = "";
        [DefaultValue("")] public string BusinessName { get; set; } = "";
        [DefaultValue("")] public string BusinessNameLabel { get; set; } = "BusName";
        [DefaultValue(false)] public bool IsBusinessIndividual { get; set; } = false;
        [DefaultValue("")] public string InsuredFirstName { get; set; } = "";
        [DefaultValue("")] public string InsuredLastName { get; set; } = "";
        //Business details----------------------------------------------
        [DefaultValue("")] public string YearBusStarted { get; set; } = "";
        [DefaultValue("")] public string GrossRev { get; set; } = "";
        [DefaultValue("")] public string SOW { get; set; } = "";
        [DefaultValue("")] public string HowManyAttorneys { get; set; } = "";
        [DefaultValue("")] public string ContractAttorneys { get; set; } = "";
        [DefaultValue("")] public string FTCounselIndepenAttorneys { get; set; } = "";
        [DefaultValue("")] public string PTCounselIndepenAttorneys { get; set; } = "";
        [DefaultValue("")] public string SignOffWrittenContracts { get; set; } = "";
        [DefaultValue("")] public string HowManyHealthProf { get; set; } = "";
        [DefaultValue("")] public string AnyHealthStudents { get; set; } = "";
        [DefaultValue("")] public string NumOfHealthStudents { get; set; } = "";
        [DefaultValue("")] public string HealthContractorOrEmployee { get; set; } = "";
        [DefaultValue("")] public string HealthCareDesignationWithin2Years { get; set; } = "";
        [DefaultValue("")] public string HealthCareDesignationDate { get; set; } = "";

        //Coverage Details----------------------------------------------
        [DefaultValue("")] public string DateCovStarts { get; set; } = "";
        [DefaultValue("")] public string RetroDate { get; set; } = "";
        [DefaultValue("")] public string PLIn3years { get; set; } = "";
        [DefaultValue("")] public string CurrentRetroDate { get; set; } = "";
        [DefaultValue("")] public string CurrentlyHavePL { get; set; } = "";
        [DefaultValue("")] public string HowManyClaims { get; set; } = "";
        [DefaultValue("")] public string CurrentlyProLiability { get; set; } = "";

        //About You----------------------------------------------
        [DefaultValue("")] public string ContactFirstName { get; set; } = "";
        [DefaultValue("")] public string ContactLastName { get; set; } = "";
        //Address info
        //Use Bus Address regardless of if there is a mailing address
        [DefaultValue("")] public string BusAddress { get; set; } = "";
        [DefaultValue("")] public string BusAddress2 { get; set; } = "";
        [DefaultValue("")] public string BusCity { get; set; } = "";
        [DefaultValue("")] public string BusState { get; set; } = "";
        [DefaultValue("")] public string BusZipCode { get; set; } = "";
        [DefaultValue("")] public string BusEmail { get; set; } = "";
        [DefaultValue("")] public string BusPhone { get; set; } = "";
        [DefaultValue("")] public string BusExtPhone { get; set; } = "";
        [DefaultValue("")] public string BusWebSocialPage { get; set; } = "";
        //Manager Contact Info
        [DefaultValue("")] public string HaveBrokerAccount { get; set; } = "";
        [DefaultValue("")] public string ManagerFirstName { get; set; } = "";
        [DefaultValue("")] public string ManagerLastName { get; set; } = "";
        [DefaultValue("")] public string ManagerPhone { get; set; } = "";
        [DefaultValue("")] public string ManagerPhoneExt { get; set; } = "";
        [DefaultValue("")] public string ManagerEmail { get; set; } = "";

        //Your Quote----------------------------------------------
        [DefaultValue("Monthly")] public string YearlyOrMonthly { get; set; } = "Monthly";
    }
}