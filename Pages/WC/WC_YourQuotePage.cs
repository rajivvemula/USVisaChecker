using System.Collections.Generic;
using TechTalk.SpecFlow;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.WC
{
    [Binding]
    public class WC_YourQuotePage
    {
        //Base
        public static Element WCQuoteID => new Element(By.XPath("//div[@data-qa='wc_your_quoteId_header']"));
        public static Element WCQuoteHeader => new Element(By.XPath("//h2[@data-qa='wc_your_quote_header']"));
        public static Element ProvidingProtectionTxt => new Element(By.XPath("//p[@data-qa='providing_protection_info']"));
        public static Element YourPlanHeader => new Element(By.XPath("//h4[@data-qa='your_plan_single_bundle_header']"));

        //Due Today
        public static Element GetPlanButton => new Element(By.XPath("//button[@data-qa='get_plan_button']"));
        public static Element CancelCoverageAnytime => new Element(By.XPath("(//div[starts-with(@data-qa, 'cancel_anytime_label')])[1]"));
        public static Element DueTodayTxt => new Element(By.XPath("//div[starts-with(@data-qa,'monthly_allowed_due_today')] | //div[starts-with(@data-qa,'flat_payments_due_today')]"));
        public static Element DownPaymentAmountTxt => new Element(By.XPath("//div[starts-with(@data-qa,'monthly_allowed_downpayment_amount')] | //div[starts-with(@data-qa,'flat_payments_monthly_installment')]"));
        public static Element FollowingPaymentTxt => new Element(By.XPath("//div[starts-with(@data-qa,'monthly_allowed_following_payments')] | //div[starts-with(@data-qa,'flat_payments_following_amounts')]"));
        public static Element YearlyPremiumTxt => new Element(By.XPath("//div[starts-with(@data-qa,'monthly_allowed_yearly_premium')] | //div[starts-with(@data-qa,'flat_payments_yearly_premium')]"));
        public static Element CoverageStartingLabel => new Element(By.XPath("//div[starts-with(@data-qa,'monthly_allowed_one_year_coverage_starting_label')] | //div[starts-with(@data-qa,'flat_payments_one_year_coverage_starting_label')]"));

        //Coverages Box
        public static Element CoveragesTxt => new Element(By.XPath("//div[@data-qa='coverages_header_OO']"));
        public static Element CoveragesHelperBttn => new Element(By.XPath("//button[starts-with(@data-qa,'coverages_oo')]"));
        public static Element WC_CoverageLabel => new Element(By.XPath("//li[@data-qa='coverages_workers_comp_label']"));
        public static Element WC_SingleOwnerOfficer => new Element(By.XPath("//li[@data-qa='coverages_1_oo_covered_label']"));
        public static Element WC_MultipleOwnerOfficer => new Element(By.XPath("//li[@data-qa='coverages_multiple_oo_covered_label']"));
        public static Element WC_CheckBox => new Element(By.XPath("//i[@data-qa='coverages_workers_comp_icon']"));
        public static Element SingleOwnerOfficerCheckBox => new Element(By.XPath("//i[@data-qa='coverages_1_oo_covered_icon']"));
        public static Element MultiOwnerOfficerCheckBox => new Element(By.XPath("//i[@data-qa='coverages_multiple_oo_covered_icon']"));

        //Employee Limits section
        public static Element EmployerLiabilityLimits => new Element(By.XPath("//div[starts-with(@data-qa, 'employer_liability_limits')]"));
        public static Element LiabilityLimitsHelperTxt => new Element(By.XPath("//button[@data-qa='employer_liability_limits_info2_tooltip']"));
        public static Element EachAccidentTxt => new Element(By.XPath("//div[starts-with(@data-qa, 'multiple_limits_each_accident')][not(contains(@data-qa, 'amount'))]"));
        public static Element EachAccidentAmount => new Element(By.XPath("//div[starts-with(@data-qa, 'multiple_limits_each_accident_amount')]"));
        public static Element EachAccidentEditBttn => new Element(By.XPath("//button[@data-qa='multiple_limits_each_accident_customize_button']"));
        public static Element PolicyTotalTxt => new Element(By.XPath("//div[starts-with(@data-qa, 'multiple_limits_policy_total')]"));
        public static Element PolicyTotaltAmount => new Element(By.XPath("//div[starts-with(@data-qa, 'multiple_limits_policy_amount')]"));
        public static Element PolicyTotalEditBttn => new Element(By.XPath("//button[starts-with(@data-qa, 'multiple_limits_customize_plan_button')]"));
        public static Element EachEmployeeTxt => new Element(By.XPath("//div[starts-with(@data-qa, 'multiple_limits_each_employee')][not(contains(@data-qa, 'amount'))]"));
        public static Element EachEmployeeAmount => new Element(By.XPath("//div[starts-with(@data-qa, 'multiple_limits_each_employee_amount')]"));
        public static Element EachEmployeeEditBttn => new Element(By.XPath("//button[starts-with(@data-qa, 'multiple_limits_each_employee_customize_plan_button')]"));

        // Deductible 
        public static Element DeductibleLabel => new Element(By.XPath("//div[@data-qa='mandatory_deductible_label']"));
        public static Element DeductibleHelpBttn => new Element(By.XPath("//button[@data-qa='mandatory_deductible_info_tooltip']"));
        public static Element DeductibleHelpToolTip => new Element(By.XPath("//bb-tooltip[@data-qa='mandatory_deductible_info']"));
        public static Element DeductiblePerClaimLabel => new Element(By.XPath("//div[@data-qa='mandatory_deductible_per_claim_label']"));
        public static Element DeductibleAmmountNone => new Element(By.XPath("//div[@data-qa='mandatory_deductible_none']"));
        public static Element DeductibleAmmount => new Element(By.XPath("//div[@data-qa='mandatory_deductible_amount']"));
        public static Element DeductibleEditBttn => new Element(By.XPath("//button[@data-qa='mandatory_deductible_customize_plan_button']"));

        //Questions? Your licensed team is here to help. Section
        public static Element QuestionsTxt => new Element(By.XPath("//h4[@data-qa='licensed_team_info_label']"));
        public static Element YouCanContactUsTxt => new Element(By.XPath("//p[@data-qa='contact_us_label']"));
        public static Element ContactEmailLink => new Element(By.XPath("//a[@data-qa='contact_biberk_email_link']"));
        public static Element ContactEmailLinkBttn => new Element(By.XPath("//i[@data-qa='contact_mail_button']"));
        public static Element ContactPhoneNumberLink => new Element(By.XPath("//a[@data-qa='call_biberk_phone_number']"));
        public static Element ContactPhoneNumberBttn => new Element(By.XPath("//i[@data-qa='call_biberk_phone_icon']"));
        public static Element ContactBiberkHours => new Element(By.XPath("//span[@data-qa='contact_biberk_hours']"));
        public static Element CertificateOfInsuranceHeaderTxt => new Element(By.XPath("//h4[@data-qa='COI_text_header']"));
        public static Element COIParagraphTxt => new Element(By.XPath("//p[@data-qa='COI_info_text']"));

        //Footer section
        public static Element ProudToBePartOfTxt => new Element(By.XPath("//h5[@data-qa='BH_info_text']"));
        public static Element AsIsIndustryStandardTxt => new Element(By.XPath("//p[@data-qa='industry_standard_info_text']"));

        //Customize Your Plan Modal:
        public static Element CustomizeYourPlanTitle => new Element(By.XPath("//h3[@data-qa='wc_customize_your_plan_header']"));

        // Employer Liability Limits
        public static Element MdlEmployerLiabilityLimitsLabel => new Element(By.XPath("//div[@data-qa='wc_customize_employer_liability_limits']"));
        public static Element MdlEachAccidentTotalLabel => new Element(By.XPath("//div[@data-qa='wc_customize_accident_policy_employee_label']"));
        public static Element MdlEachAccidentTotalHelpBttn => new Element(By.XPath("//button[@data-qa='wc_customize_helptext_tooltip']"));
        public static Element MdlEachAccidentTotalHelpToolTip => new Element(By.XPath("//bb-tooltip[@data-qa='wc_customize_helptext']"));
        public static Element MdlEachAccidentTotalDD => new Element(By.XPath("//select[@data-qa='wc_customize_limits_dropdown']"));

        // Modal Deductible Elements:
        public static Element MdlDeductibleLabel => new Element(By.XPath("//div[@data-qa='wc_customize_deductible']"));
        public static Element MdlPerClaimLabel => new Element(By.XPath("//div[@data-qa='wc_customize_perclaim']"));
        public static Element MdlPerClaimHelpBttn => new Element(By.XPath("//button[@data-qa='wc_customize_deductible_helptext_tooltip']"));
        public static Element MdlPerClaimToolTip => new Element(By.XPath("//bb-tooltip[@data-qa='wc_customize_deductible_helptext']"));
        public static Element MdlPerClaimDD => new Element(By.XPath("//select[@data-qa='wc_customize_deductible_dropdown']"));
        public static Element MdlCancelBttn => new Element(By.XPath("//a[@data-qa='wc_customize_cancel_button']"));
        public static Element MdlCloseBttn => new Element(By.XPath("//button[@data-qa='wc_customize_close_modal_button']"));
        public static Element MdlUpdateBttn => new Element(By.XPath("//button[@data-qa='wc_customize_update_button']"));
        public static Element MdlLoadingWindow => new Element(By.XPath("//label[@data-qa='retrieving_plan_header']"));


        //Multiple Bundle Plan Elements:
        public static Element MultiPlanHeader(int planID) => new Element(By.XPath($"(//h4[@data-qa='wc_header_standard' or @data-qa='wc_header_plus'])[{planID}]"));
        public static Element MultiPlanDueTodayLabel(int planID) => new Element(By.XPath($"//div[@data-qa='monthly_due_today_{planID}' or @data-qa='non_monthly_due_today_{planID}']"));
        public static Element MultiPlanDueTodayAmount(int planID) => new Element(By.XPath($"//div[@data-qa='monthly_bundle_down_payment_{planID}' or @data-qa='non_monthly_bundle_down_payment_{planID}']"));
        public static Element MultiPlanFollwedBy(int planID) => new Element(By.XPath($"//div[@data-qa='monthly_bundle_following_installments_{planID}' or @data-qa='non_monthly_bundle_following_installments_{planID}']"));
        public static Element MultiPlanYearlyAmount(int planID) => new Element(By.XPath($"//div[@data-qa='monthly_yearly_premium_{planID}' or @data-qa='non_monthly_yearly_premium_{planID}']"));
        public static Element MultiPlanCoverageStartDate(int planID) => new Element(By.XPath($"//div[@data-qa='monthly_coverage_starting_on_{planID}' or @data-qa='non_monthly_coverage_starting_{planID}']"));
        public static Element MultiPlanCoveragesHeader(int planID) => new Element(By.XPath($"//div[@data-qa='coverages_header_{planID}']"));
        public static Element MultiPlanCoveragesHelpBttn(int planID) => new Element(By.XPath($"(//button[@data-qa='workers_comp_info_standard_tooltip' or @data-qa='workers_comp_info_plus_tooltip'])[{planID}]"));
        public static Element MultiPlanWCLabel(int planID) => new Element(By.XPath($"//li[@data-qa='coverage_type_wc_label_{planID}']"));
        public static Element MultiPlanWCCheckbox(int planID) => new Element(By.XPath($"//i[@data-qa='coverage_type_wc_label_icon_{planID}']"));
        public static Element MultiPlanELLLabel(int planID) => new Element(By.XPath($"//div[@data-qa='employer_liability_limits_label_{planID}']"));
        public static Element MultiPlanELLLHelpBttn(int planID) => new Element(By.XPath($"//button[@data-qa='employer_liability_limits_{planID}_tooltip']"));
        public static Element MultiPlanEachAccidentLabel(int planID) => new Element(By.XPath($"//div[@data-qa='multiple_limits_each_accicent_{planID}']"));
        public static Element MultiPlanEachAccidentAmount(int planID) => new Element(By.XPath($"//div[@data-qa='multiple_limits_deductible_accident_limit_{planID}']"));
        public static Element MultiPlanEachAccidentEditBttn(int planID) => new Element(By.XPath($"//button[@data-qa='multiple_limits_each_accident_button_{planID}']"));
        public static Element MultiPlanPolicyTotalLabel(int planID) => new Element(By.XPath($"//div[@data-qa='multiple_limits_policy_total_{planID}']"));
        public static Element MultiPlanPolicyTotalAmount(int planID) => new Element(By.XPath($"//div[@data-qa='multiple_limits_policy_amount_{planID}']"));
        public static Element MultiPlanPolicyTotalEditBttn(int planID) => new Element(By.XPath($"//button[@data-qa='multiple_limits_policy_total_button_{planID}']"));
        public static Element MultiPlanEachEmployeeLabel(int planID) => new Element(By.XPath($"//div[@data-qa='multiple_limits_each_employee_{planID}']"));
        public static Element MultiPlanEachEmployeeAmount(int planID) => new Element(By.XPath($"//div[@data-qa='multiple_limits_each_employee_amount_{planID}']"));
        public static Element MultiPlanEachEmployeeEditBttn(int planID) => new Element(By.XPath($"//button[@data-qa='multiple_limits_each_employee_button_{planID}']"));
        public static Element MultiPlanDeductibleLabel(int planID) => new Element(By.XPath($"//div[@data-qa='deductible_label_{planID}']"));
        public static Element MultiPlanDeductibleHelpBttn(int planID) => new Element(By.XPath($"//button[@data-qa='deductible_{planID}_tooltip']"));
        public static Element MultiPlanPerClaimLabel(int planID) => new Element(By.XPath($"//div[@data-qa='deductible_per_claim_label_{planID}']"));
        public static Element MultiPlanPerClaimAmountNone(int planID) => new Element(By.XPath($"//div[@data-qa='deductible_none_{planID}']"));
        public static Element MultiPlanPerClaimAmount(int planID) => new Element(By.XPath($"//h4[@data-qa='selected_deductible_{planID}']"));
        public static Element MultiPlanPerClaimEditBttn(int planID) => new Element(By.XPath($"//button[@data-qa='deductible_customize_plan_button_{planID}']"));
        public static Element MultiPlanBttn(int planID) => new Element(By.XPath($"(//button[starts-with(@data-qa, 'get')][contains(@data-qa,'plan_button_')])[{planID}]"));
        public static Element MultiPlanCancelCoverage(int planID) => new Element(By.XPath($"//div[@data-qa='cancel_anytime_label_{planID}']"));

        // Plus Plan Specific Elements :
        public static Element PlusPlanWCMultiOwnersAndOfficersLabel => new Element(By.XPath("//li[@data-qa='multiple_oo_label']"));
        public static Element PlusPlanWCSingleOwnerAndOfficerLabel => new Element(By.XPath("//li[@data-qa='1_oo_label']"));
        public static Element PlusPlanWCMultiOwnersAndOfficersLabelCheckbox => new Element(By.XPath("//i[@data-qa='multiple_oo_label_icon']"));
        public static Element PlusPlanWCSingleOwnersAndOfficersLabelCheckbox => new Element(By.XPath("//i[@data-qa='1_oo_label_icon']"));

        // Florida Premium Estimate Disclosure table
        public static Element FLPEDTitle => new Element(By.XPath("//h4[@data-qa='flTable_title']"));
        public static Element FLPEDSubTitle => new Element(By.XPath("//p[@data-qa='flTable_subtitle']"));
        public static Element FLPEDTable => new Element(By.XPath("//table[@data-qa='flTable']"));
        public static Element FLPEDHeaderByIndex(int index) => new Element(By.XPath($"(//table[@data-qa='flTable']//tr[1])//th[{index}]"));
        public static Element FLPEDCellByPos(int rowIndex, int columnIndex) => new Element(By.XPath($"(//table[@data-qa='flTable']//tr[{rowIndex}])//th[{columnIndex}]"));
        public static Element FLPEDHelpText => new Element(By.XPath("//p[@data-qa='flTable_helptext']"));

        public static List<Element> FLPEDBaseElements = new List<Element>
        {
            FLPEDTitle,
            FLPEDSubTitle,
            FLPEDHelpText,
            FLPEDTable
        };
    }
}