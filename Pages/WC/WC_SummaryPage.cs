using System.Collections.Generic;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.WC
{
    public sealed class WC_SummaryPage
    {
        // Your Summary Header
        public static Element YourSummaryHeader => new(By.XPath("//h2[@data-qa='wc_summary_your_summary_header']"));
        public static Element HeresWhatYouToldUsTxt => new(By.XPath("//h2[@data-qa='wc_summary_your_summary_header']/following-sibling::p"));
        public static Element ViewQuoteBtn => new(By.XPath("//button[@data-qa='wc_summary_continue_button']"));

        //About You Section

        //Owners and Officers section
        public static Element OwnersAndOfficersTitle => new(By.XPath("//h6[@data-qa='wc_summary_owners_and_officers_title']"));
        public static Element OwnerAndOfficerEditBtn => new(By.XPath("//button[@click.trigger='GoToOwners()']"));
        // Total Owner Officers
        public static Element TotalOwnerOfficerTitle => new(By.XPath("//span[@data-qa='wc_summary_total_owners_officers_title']"));
        public static Element TotalOwnerOfficerResponse => new(By.XPath("//p[@data-qa='wc_summary_total_owners_officers']"));
        public static SummaryQAPair TotalOwnerOfficer => new(TotalOwnerOfficerTitle, TotalOwnerOfficerResponse);

        //Covered Owner Officers
        public static Element CoveredOwnerOfficerTitle => new(By.XPath("//span[@data-qa='wc_summary_covered_owners_officers_title']"));
        public static Element CoveredOwnerOfficerResponse => new(By.XPath("//p[@data-qa='wc_summary_covered_owners_officers']"));
        public static SummaryQAPair CoveredOwnerOfficer => new(CoveredOwnerOfficerTitle, CoveredOwnerOfficerResponse);

        // Included Officer
        public static Element IncludedOfficerTitle(int index) => new(By.XPath($"//span[@data-qa='wc_summary_included_oo_title_{index}']"));
        public static Element IncludedOfficerFullName(int index) => new(By.XPath($"//p[@data-qa='wc_summary_included_oo_name_{index}']"));
        public static SummaryQAPair IncludedOfficer(int index) => new(IncludedOfficerTitle(index), IncludedOfficerFullName(index));
        public static Element OfficerDoesntCollectPayroll(int index) => new(By.XPath($"//p[@data-qa='wc_summary_included_oo_no_payroll_{index}']"));
        public static Element TheirPayrollTitle(int index) => new(By.XPath($"//span[@data-qa='wc_summary_included_oo_payroll_title_{index}']"));
        public static Element TheirPayrollResponse(int index) => new(By.XPath($"//p[@data-qa='wc_summary_included_oo_payroll_amount_{index}']"));
        public static SummaryQAPair TheirPayroll(int index) => new(TheirPayrollTitle(index), TheirPayrollResponse(index));

        //Excluded Officer
        public static Element ExcludedOfficerTitle(int index) => new(By.XPath($"//span[@data-qa='wc_summary_excluded_oo_title_{index}']"));
        public static Element ExcludedOfficerFullName(int index) => new(By.XPath($"//p[@data-qa='wc_summary_excluded_oo_name_{index}']"));
        public static SummaryQAPair ExcludedOfficer(int index) => new(ExcludedOfficerTitle(index), ExcludedOfficerFullName(index));

        // For all the following questions the mapping is the same
        //Any Owner Officer Travel to Job Site
        // Do any included owners/officers only do general office work never writing up repair estimates?
        // Are there any included owners/officers that never interact with clients/patients?
        // Do any included owners/officers only do general office work and do not work a cash register?
        // Are there any included owners/officers that do not do any cleaning or maintenance work?
        // Are there any included owners/officers that never travel to job sites or do any construction work?
        public static Element AnyOOTravelToJobSiteTitle => new(By.XPath("//label[@data-qa='wc_summary_compclass_nocovered_text_8810']"));
        public static Element AnyOOTravelToJobSiteResponse => new(By.XPath("//p[@data-qa='wc_summary_compclass_nocovered_response_8810']"));
        public static SummaryQAPair AnyOOTravelToJobSite => new(AnyOOTravelToJobSiteTitle, AnyOOTravelToJobSiteResponse);

        // Any included Onwer Officer Licensed Physicians, Nurses, directors or administrators
        public static Element AnyOOLicensedPNDATitle => new(By.XPath("//label[@data-qa= 'wc_summary_compclass_nocovered_text_8833']"));
        public static Element AnyOOLicensedPNDAResponse => new(By.XPath("//p[@data-qa= 'wc_summary_compclass_nocovered_response_8833']"));
        public static SummaryQAPair AnyOOLicensedPNDA => new(AnyOOLicensedPNDATitle, AnyOOLicensedPNDAResponse);

        // Do any included owners/officers travel frequently for sales, consultation, or auditing?
        // Are any included owners/officers cost estimators that wouldn't do any direct physical work?
        public static Element AnyOOTravelForSCATitle => new(By.XPath("//label[@data-qa='wc_summary_compclass_nocovered_text_8742']"));
        public static Element AnyOOTravelForSCAResponse => new(By.XPath("//p[@data-qa='wc_summary_compclass_nocovered_response_8742']"));
        public static SummaryQAPair AnyOOTravelForSCA => new(AnyOOTravelForSCATitle, AnyOOTravelForSCAResponse);

        // Are any included owners/officers real estate/leasing agents?
        public static Element AnyOORealEstateAgentTitle => new(By.XPath("//label[@data-qa='wc_summary_compclass_nocovered_text_9012']"));
        public static Element AnyOORealEstateAgentResponse => new(By.XPath("//p[@data-qa= 'wc_summary_compclass_nocovered_response_9012']"));
        public static SummaryQAPair AnyOORealEstateAgent => new(AnyOORealEstateAgentTitle, AnyOORealEstateAgentResponse);

        // Are there included owner/officers that do not drive for your business?
        public static Element AnyOoDoNotDriveToBusinessTitle => new(By.XPath("//label[@data-qa='wc_summary_compclass_nocovered_text_0953']"));
        public static Element AnyOODoNotDriveToBusinessResponse => new(By.XPath("//p[@data-qa= 'wc_summary_compclass_nocovered_response_0953']"));
        public static SummaryQAPair AnyOODoNotDriveToBusiness => new(AnyOoDoNotDriveToBusinessTitle, AnyOODoNotDriveToBusinessResponse);

        // Do any included owners/officers only do general office work and rarely travel?
        public static Element AnyOODoGeneralOfficeWorkTitle => new(By.XPath("//label[@data-qa='wc_summary_compclass_nocovered_text_0951']"));
        public static Element AnyOODoGeneralOfficeWorkResponse => new(By.XPath("//p[@data-qa= 'wc_summary_compclass_nocovered_response_0951']"));
        public static SummaryQAPair AnyOODoGeneralOfficeWork => new(AnyOODoGeneralOfficeWorkTitle, AnyOODoGeneralOfficeWorkResponse);

        public static Dictionary<Element, SummaryQAPair> OOSummaryElementsAndPairs { get => oOSummaryElementsAndPairs; set => oOSummaryElementsAndPairs = value; }
        public static Dictionary<State, int> StateMinPayrollDictionary { get => stateMinPayrollDictionary; set => stateMinPayrollDictionary = value; }

        // Dictionary to store Summary Page Elements and it's corresponding SummaryQAPair
        private static Dictionary<Element, SummaryQAPair> oOSummaryElementsAndPairs = new()
        {
            { AnyOOTravelToJobSiteTitle, AnyOOTravelToJobSite},
            { AnyOOLicensedPNDATitle, AnyOOLicensedPNDA},
            { AnyOOTravelForSCATitle, AnyOOTravelForSCA},
            { AnyOORealEstateAgentTitle, AnyOORealEstateAgent},
            { AnyOoDoNotDriveToBusinessTitle, AnyOODoNotDriveToBusiness},
            { AnyOODoGeneralOfficeWorkTitle, AnyOODoGeneralOfficeWork}
        };

        // Dictionary to Compare State with the MinPayroll for Owner Officer W2 Payroll - US91982
        private static Dictionary<State, int> stateMinPayrollDictionary = new()
        {
            { State.Alabama, 54600},
            { State.Arizona, 7200},
            { State.Connecticut, 78000},
            { State.Florida, 57200},
            { State.Iowa, 26000},
            { State.Minnesota, 66924},
            { State.NewJersey, 41080},
            { State.Texas, 7800},
            { State.NewYork, 45500}
        };
    }
}
