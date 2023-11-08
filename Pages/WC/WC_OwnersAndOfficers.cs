using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.WC
{
    [Binding]
    public sealed class WC_OwnersAndOfficers
    {
        /*
         * 2 officers, 1 excluded
         * NJ LLC = all are included or excluded
         * KS, LA, MA, MN, MS, NE = 10% rule 
         * AK, 10% for corp/llc
         * AZ; 50% for corp/llc
         */
        public static Element OwnersAndOfficers_Header => new Element(By.XPath("//h2[@data-qa='owner_officer_header']"));

        //How many owners/officers does your business have? (qstid 100) dropdown, used most the time
        //How many owners/officers does your business have? (qstid 108) textbox
        public static Element getHowManyOfficers_QST => new Element(By.XPath("//label[text()='how many owners/officers does your business have?']"));
        public static Element HowManyOfficers_QST(string qstID) => new Element(By.XPath($"//label[@data-qa='question_{qstID}_label']"));
        public static Element getHowManyOfficers_DD(string qstID) => new Element(By.XPath($"//bb-select[@data-qa='select_kickoff_questions_{qstID}']/span/select"));
        public static Element HowManyOfficers_DD => new Element(By.XPath("//bb-select[@data-qa='select_kickoff_questions_100']/span/select"));
        public static Element getManyOfficers_Txtbox(string qstID) => new Element(By.XPath($"//bb-number[@data-qa='number_kickoff_questions_{qstID}']/span/input"));
        public static Element HowManyOfficers_Txtbox => new Element(By.XPath("//bb-number[@data-qa='number_kickoff_questions_108']/span/input"));
        public static Element HowManyOfficersDrive_Txtbox => new Element(By.XPath($"//bb-select[@data-qa='select_are there included owner/officers that do not drive for your business?']/span/select"));

        //How many owners/officers do you want to cover with this policy? X (qstid 103, 109, 112) "getHowManyToCover_DD"
        //How many owners/officers do you want to cover with this policy? Z (qstid 114) "HowManyToCover_Txtbox"..N (qstid 101,104)
        public static Element getHowManyOfficersId => new Element(By.XPath("//label[text()='how many owners/officers do you want to cover with this policy?']"));
        public static Element getHowManyToCover_QST(string qstID) => new Element(By.XPath($"//label[@data-qa='question_{qstID}_label']"));
        public static Element HowManyToCover_Txtbox(string qstID) => new Element(By.XPath($"//bb-number[@data-qa='number_kickoff_questions_{qstID}']/span/input"));
        public static Element getHowManyToCover_DD(string qstID) => new Element(By.XPath($"//bb-select[@data-qa='select_kickoff_questions_{qstID}']/span/select"));
        public static Element getHowManyToCover_Helper(string qstID) => new Element(By.XPath($"//bb-tooltip[@data-qa='{qstID}']"));
        public static Element getHowManyToCover_HelperText(string qstID) => new Element(By.XPath($"//bb-tooltip[@data-qa='{qstID}']/button[starts-with(@aria-describedby,'popover')]"));

        //How many owners have less than 10% ownership? State law requires that they be covered.
        //How many owners have less than 50% ownership? State law requires that they be covered.
        public static Element HowManyPercentO_QSTX => new Element(By.XPath("//label[@data-qa='question_111_label']"));
        public static Element HowManyPercentO_QSTZ => new Element(By.XPath("//label[@data-qa='question_113_label']"));
        public static Element HowManyPercentO_DD => new Element(By.XPath("//bb-select[@data-qa='select_kickoff_questions_111']/span/select"));
        public static Element HowManyPercentO_TxtboxZ => new Element(By.XPath("//bb-number[@data-qa='number_kickoff_questions_113']/span/input"));
        public static Element HowManyPercentO_Helper(string qstID) => new Element(By.XPath($"//bb-tooltip[@data-qa='{qstID}']"));
        public static Element HowManyPercentO_HelperText(string qstID) => new Element(By.XPath($"//button[@data-qa='{qstID}_tooltip']"));

        //How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered.
        public static Element HowMany10PercentO_QST => new Element(By.XPath("//label[@data-qa='question_117_label' or @data-qa='question_118_label']"));
        public static Element HowMany10PercentO_DD => new Element(By.XPath("//bb-select[@data-qa='select_kickoff_questions_117' or @data-qa='select_kickoff_questions_118']/span/select"));
        public static Element HowMany10PercentO_TxtboxZ=> new Element(By.XPath("//bb-number[@data-qa='number_kickoff_questions_117' or @data-qa='number_kickoff_questions_118']/span/input"));
        public static Element HowMany10PercentO_Helper => new Element(By.XPath("//bb-tooltip[@data-qa='117' or @data-qa='118']"));
        public static Element HowMany10PercentO_HelperText => new Element(By.XPath("//button[@data-qa='117_tooltip' or @data-qa='118_tooltip']"));
        public static InputSection HowMany10PercentOInput => new HtmlDropdownInput(HowMany10PercentO_DD)
            .AsAQuestion(HowMany10PercentO_QST)
            .WithHelpText(HowMany10PercentO_Helper, HowMany10PercentO_HelperText);
        public static InputSection HowMany10PercentO_TxtboxInput => new TextBoxInput(HowMany10PercentO_TxtboxZ)
            .AsAQuestion(HowMany10PercentO_QST)
            .WithHelpText(HowMany10PercentO_Helper, HowMany10PercentO_HelperText);

        //How many owners/officers do you want to exclude from this policy? 105
        //How many owners/officers do you want to exclude from this policy? State law requires that they all be excluded. 102
        public static Element ExcludeOOQST102 => new Element(By.XPath("//label[@data-qa='question_102_label']"));
        public static Element ExcludeOOQST105 => new Element(By.XPath("//label[@data-qa='question_105_label']"));
        public static Element ExcludeOO_Txtbox(string qstID) => new Element(By.XPath($"//bb-number[@data-qa='number_kickoff_questions_{qstID}']/span/input"));

        //Are there any included owners/officers that never travel to job sites or do any construction work? 
        public static Element IncOONeverTravel_QST => new Element(By.XPath("//label[@data-qa='question_oocomp_are there any included owners/officers that never travel to job sites or do any construction work?_label']"));
        public static Element IncOONeverTravel_DD => new Element(By.XPath("//bb-select[@data-qa='select_are there any included owners/officers that never travel to job sites or do any construction work?']/span/select"));
        public static Element IncOONeverTravel_Helper => new Element(By.XPath("//bb-tooltip[@data-qa='are there any included owners/officers that never travel to job sites or do any construction work?']/button"));
        public static Element IncOONeverTravel_HelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any included owners/officers that never travel to job sites or do any construction work?']/button[starts-with(@aria-describedby,'popover')]"));

        //Are any included owners/officers licensed physicians, nurses, directors or administrators? 
        public static Element IncOOLicensedPhysicians_QST => new Element(By.XPath("//label[@data-qa='question_oocomp_are any included owners/officers licensed physicians, nurses, directors or administrators?_label']"));
        public static Element IncOOLicensedPhysicians_DD => new Element(By.XPath("//bb-select[@data-qa='select_are any included owners/officers licensed physicians, nurses, directors or administrators?']/span/select"));
        public static Element IncOOLicensedPhysicians_Helper => new Element(By.XPath("//bb-tooltip[@data-qa='are any included owners/officers licensed physicians, nurses, directors or administrators?']/button"));
        public static Element IncOOLicensedPhysicians_HelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are any included owners/officers licensed physicians, nurses, directors or administrators?']/button[starts-with(@aria-describedby,'popover')]"));

        public static InputSection IncOOLicensedPhysicians_Input =>
            new HtmlDropdownInput(IncOOLicensedPhysicians_DD)
            .WithHelpText(IncOOLicensedPhysicians_Helper, IncOOLicensedPhysicians_HelperText);

        //Do any included owners/officers only do general office work and rarely travel?
        public static Element IncOORarelyTravel_QST => new Element(By.XPath("//label[@data-qa='question_oocomp_do any included owners/officers only do general office work and rarely travel?_label']"));
        public static Element IncOORarelyTravel_DD => new Element(By.XPath("//bb-select[@data-qa='select_do any included owners/officers only do general office work and rarely travel?']/span/select"));
        public static Element IncOORarelyTravel_Helper => new Element(By.XPath("//bb-tooltip[@data-qa='do any included owners/officers only do general office work and rarely travel?']/button"));
        public static Element IncOORarelyTravel_HelperText => new Element(By.XPath("//bb-tooltip[@data-qa='do any included owners/officers only do general office work and rarely travel?']/button[starts-with(@aria-describedby,'popover')]"));
        public static InputSection IncOORarelyTravel_Input =>
            new HtmlDropdownInput(IncOORarelyTravel_DD)
            .WithHelpText(IncOORarelyTravel_Helper, IncOORarelyTravel_HelperText);

        //Do you want to buy coverage for the business owners?
        public static Element BuyCovBusinessOwn_QST => new Element(By.XPath("//label[@data-qa='question_106_label']"));
        public static Element BuyCovBusinessOwn_BTN(string answer) => new Element(By.XPath($"//bb-options[@data-qa='options_kickoff_questions_106']/div/button[text()='{answer}']"));

        //How many owners/officers are there? 107
        public static Element HowManyOOAreThereQST => new Element(By.XPath("//label[@data-qa='question_107_label']"));
        public static Element HowManyOOAreThereTxtbox => new Element(By.XPath("//bb-number[@data-qa='number_kickoff_questions_107']/span/input"));
        public static Element DoAnyOfficersTravelFrequently => new Element(By.XPath("//select[@id='oocc_0951']  | //select[@id='oocc_8742']"));
        public static Element AreAnyOfficersLeasingAgents => new Element(By.XPath("//select[@id='oocc_9012']"));

        //Covered Owner/Officer Questions
        public static Element CoveredOwnerHeader(string instance) => new Element(By.XPath($"//p[@data-qa='duty_oo_covered_label_{instance}']"));
        //Your state requires this information to provide a quote
        public static Element StateRequireInfo_QST(string instance) => new Element(By.XPath($"//p[@data-qa='duty_oo_state_info_label_{instance}']"));
        public static Element CoveredFirstName_QST(string instance) => new Element(By.XPath($"//label[@data-qa='included_oo_firstname_label_{instance}']"));
        public static Element CoveredFirstName_Txtbox(string instance) => new Element(By.XPath($"//input[@data-qa='included_oo_firstname_input_{instance}']"));
        public static Element CoveredLastName_QST(string instance) => new Element(By.XPath($"//label[@data-qa='included_oo_lastname_label_{instance}']"));
        public static Element CoveredLastName_Txtbox(string instance) => new Element(By.XPath($"//input[@data-qa='included_oo_lastname_input_{instance}']"));
        //Does this owner/officer receive W2 payroll from the company? 
        public static Element W2Payroll_QST(string instance) => new Element(By.XPath($"//label[@data-qa='oo_annual_payroll_isW2_label_{instance}']"));
        public static Element W2Payroll_Yes(string instance) => new Element(By.XPath($"//bb-options[@data-qa='oo_annual_payroll_isW2_{instance}']/div/button[1]"));
        public static Element W2Payroll_No(string instance) => new Element(By.XPath($"//bb-options[@data-qa='oo_annual_payroll_isW2_{instance}']/div/button[2]"));
        //What best describes this owner's job duty?
        //Annual Payroll
        public static Element AnnualPayroll_QST(string instance) => new Element(By.XPath($"//label[@data-qa='oo_annual_payroll_{instance}']"));
        public static Element AnnualPayroll_Txtbox(string instance) => new Element(By.XPath($"//bb-money[@data-qa='oo_annual_payroll_input_{instance}']/span/input"));
        // 10%/50% rule - MS, MN, NE, MA, LA, KS, AZ, AK
        // for AK rule above only applies to corp + llc
        //Does this covered owner/officer have less than 10%/50% ownership?
        public static Element PercentCoveredLessThan_QST(string instance) => new Element(By.XPath($"//label[@data-qa='duty_oo_percent_ownership_question_{instance}']"));
        public static Element PercentCoveredLessThan_Yes(string instance) => new Element(By.XPath($"//bb-options[@data-qa='duty_oo_percent_ownership_answer_{instance}']/div/button[1]"));
        public static Element PercentCoveredLessThan_No(string instance) => new Element(By.XPath($"//bb-options[@data-qa='duty_oo_percent_ownership_answer_{instance}']/div/button[2]"));
        //What best describes this owner's job duty?
        public static Element OwnerJobDuty_QST(string instance) => new Element(By.XPath($"//label[@data-qa='covered_oo_owner_duty_label_{instance}']"));
        public static Element OwnerJobDuty_DD(string instance) => new Element(By.XPath($"//bb-select[@data-qa='covered_oo_owner_duty_input_{instance}']/span/select"));

        //Are any included owners/officers cost estimators that wouldn't do any direct physical work?
        public static Element DirectPhysicalWork_QST => new Element(By.XPath("//label[@data-qa=\"question_oocomp_are any included owners/officers cost estimators that wouldn't do any direct physical work?_label\"]"));
        public static Element DirectPhysicalWork_Helper => new Element(By.XPath("//bb-tooltip[@data-qa=\"are any included owners/officers cost estimators that wouldn't do any direct physical work?\"]"));
        public static Element DirectPhysicalWork_HelperText => new Element(By.XPath("//bb-tooltip[@data-qa=\"are any included owners/officers cost estimators that wouldn't do any direct physical work?\"]/button[starts-with(@aria-describedby,'popover')]"));
        public static Element DirectPhysicalWork_DD => new Element(By.XPath("//bb-select[@data-qa=\"select_are any included owners/officers cost estimators that wouldn't do any direct physical work?\"]/span/select"));
        public static InputSection DirectPhysicalWork_Input =>
            new HtmlDropdownInput(DirectPhysicalWork_DD)
            .WithHelpText(DirectPhysicalWork_Helper, DirectPhysicalWork_HelperText);
        //Do any included owners/officers only do general office work and do not work a cash register?
        public static Element CashRegister_QST => new Element(By.XPath("//label[@data-qa=\"question_oocomp_do any included owners/officers only do general office work and do not work a cash register?_label\"]"));
        public static Element CashRegister_Helper => new Element(By.XPath("//bb-tooltip[@data-qa=\"do any included owners/officers only do general office work and do not work a cash register?\"]"));
        public static Element CashRegister_HelperText => new Element(By.XPath("//bb-tooltip[@data-qa=\"do any included owners/officers only do general office work and do not work a cash register?\"]/button[starts-with(@aria-describedby,'popover')]"));
        public static Element CashRegister_DD => new Element(By.XPath("//bb-select[@data-qa=\"select_do any included owners/officers only do general office work and do not work a cash register?\"]/span/select"));
        public static InputSection CashRegister_Input =>
            new HtmlDropdownInput(CashRegister_DD)
            .WithHelpText(CashRegister_Helper, CashRegister_HelperText);

        // Are there any included owners/officers that never interact with clients/patients?
        public static Element OONeverInteractWithClients_QST => new Element(By.XPath("//label[@data-qa='question_oocomp_are there any included owners/officers that never interact with clients/patients?_label']"));
        public static Element OONeverInteractWithClient_DD => new Element("//bb-select[@data-qa='select_are there any included owners/officers that never interact with clients/patients?']//select");
        public static InputSection OONeverInteractWithClient_Input =>
           new HtmlDropdownInput(OONeverInteractWithClient_DD);
        /*
         * Excluded Owner/Officer Questions
         */
        public static Element ExcludedOO_Header => new Element(By.XPath("//p[@data-qa='duty_oo_excluded_label']"));
        public static Element ExcludedOOStateReq_Header => new Element(By.XPath("//p[@data-qa='duty_oo_excluded_state_requires_info_label']"));
        public static Element ExcludedOOFirstName_QST(string instance) => new Element(By.XPath($"//label[@data-qa='excluded_oo_firstname_label_{instance}']"));
        public static Element ExcludedOOFirstName_Txtbox(string instance) => new Element(By.XPath($"//input[@data-qa='excluded_oo_firstname_input_{instance}']"));
        public static Element ExcludedOOLastName_QST(string instance) => new Element(By.XPath($"//label[@data-qa='excluded_oo_lastname_label_{instance}']"));
        public static Element ExcludedOOLastName_Txtbox(string instance) => new Element(By.XPath($"//input[@data-qa='excluded_oo_lastname_input_{instance}']"));
        //This excluded owner/officer has 10%/50% or more ownership 
        public static Element PercentCoveredMoreThan_Checkbox(string instance) => new Element(By.XPath($"//input[@data-qa='ownership_percentage_input_{instance}']"));

        /*
         * CTA Buttons
         */
        public static Element ContinueCTA => new Element(By.XPath("//button[@data-qa='oocompclass_continue_button']"));
        public static Element SaveForLaterCTA => new Element(By.XPath("//a[@data-qa='save_for_later_Save for Later']"));
        public static Element BackAndModifyCTA => new Element(By.XPath("//a[@data-qa='oocompclass_back_modify_button']"));
        public static Element OwnersAndOfficersContinue => new Element(By.XPath("//button[@data-qa='oocompclass_continue_button']"));
    }
}