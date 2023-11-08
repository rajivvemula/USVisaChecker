using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;
using System.Linq.Expressions;

namespace BiBerkLOB.Pages.WC
{
    public sealed class WC_AboutYouPage
    {

        // Stepper
        public static Element Stepper_1 => new Element(By.XPath("//span[@data-qa='stepper_1']"));
        public static Element StepperAboutYou => new Element(By.XPath("//div[@data-qa='stepper_About You']"));
        public static Element Stepper_2 => new Element(By.XPath("//span[@data-qa='stepper_2']"));
        public static Element StepperOwners => new Element(By.XPath("//div[@data-qa='stepper_Owners']"));
        public static Element Stepper_3 => new Element(By.XPath("//span[@data-qa='stepper_3']"));
        public static Element StepperServices => new Element(By.XPath("//div[@data-qa='stepper_Services']"));
        public static Element Stepper_4 => new Element(By.XPath("//span[@data-qa='stepper_4']"));
        public static Element StepperQuote => new Element(By.XPath("//div[@data-qa='stepper_Quote']"));
        public static Element Stepper_5 => new Element(By.XPath("//span[@data-qa='stepper_5']"));
        public static Element StepperPurchase => new Element(By.XPath("//div[@data-qa='stepper_Purchase']"));

        // About You header
        public static Element AboutYouHeader => new Element(By.XPath("//h2[@data-qa='wc_about_you_header']"));

        // When do you want your policy to start?
        public static Element WhenDoYouWantToStartQST => new Element(By.XPath("//label[@data-qa='question_policy_start_label']"));
        public static Element WhenDoYouWantToStartTxtbox => new Element(By.XPath("//input[@data-qa='select_date_policy_start_input']"));

        // The following elements are created by a third-party component and therefore cannot be assigned a data-qa attribute by the devs.
        // I've added the blank elements in case we decide to select them using other means.
        public static Element DatePickerLeftArrow => new Element((""));
        public static Element DatePickerRightArrow => new Element((""));
        public static Element DayOfMonth(int index) => new Element((""));

        // When did you start your business?
        public static Element WhenDidYouStartQST => new Element(By.XPath("//label[@data-qa='question_years_in_business_label']"));
        public static Element WhenDidYouStartDD => new Element(By.XPath("//bb-select[@data-qa='years_in_business_select']//select"));
        public static Element WhenDidYourBusinessStartError => new Element(By.XPath($"//p[@data-qa='error-{WhenDidYouStartDD.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // How is your business structured?
        public static Element HowIsYourBusinessStructuredQST => new Element(By.XPath("//label[@data-qa='question_business_structure_label']"));
        public static Element HowIsYourBusinessStructuredHelper => new Element(By.XPath("//button[@data-qa='business_structure_helptext_tooltip']"));
        public static Element HowIsYourBusinessStructuredHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='business_structure_helptext']"));
        public static Element HowIsYourBusinessStructuredDD => new Element(By.XPath("//bb-select[@data-qa='business_type_select']//select"));
        public static Element HowIsYourBusinessStructuredError => new Element(By.XPath($"//p[@data-qa='error-{HowIsYourBusinessStructuredDD.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // What is the total annual payroll for W-2 employees? (exclude business owners/officers)
        public static Element WhatIsTheTotalAnnualPayrollQST => new Element(By.XPath("//label[@data-qa='question_payroll_label']"));
        public static Element WhatIsTheTotalAnnualPayrollTxtbox => new Element(By.XPath("//bb-money[@data-qa='wc_about_you_payroll_input']//input"));
        public static Element WhatIsTheTotalAnnualPayrollHelper => new Element(By.XPath("//button[@data-qa='w2_payroll_helptext_tooltip']"));
        public static Element WhatIsTheTotalAnnualPayrollHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='w2_payroll_helptext']"));

        //Do any employees only do general office work and would never interact with any residents?
        public static Element DoAnyEmployeesOnlyDoGeneralOfficeWorkQST => new Element(By.XPath("//bb-options[@data-qa='select_do any employees only do general office work and would never interact with any residents?']"));
        public static Element DoAnyEmployeesOnlyDoGeneralOfficeWorkAnswer(string button) => new Element(By.XPath($"//bb-options[@data-qa='select_do any employees only do general office work and would never interact with any residents?']//button[text()='{button}']"));
        public static YesOrNoGroup DoAnyEmployeesOnlyDoGeneralOfficeWorkGroup => new YesOrNoGroup(DoAnyEmployeesOnlyDoGeneralOfficeWorkAnswer("yes"), DoAnyEmployeesOnlyDoGeneralOfficeWorkAnswer("no"));
        public static InputSection DoAnyEmployeesOnlyDoGeneralOfficeWork =>
            new YesOrNoInput(DoAnyEmployeesOnlyDoGeneralOfficeWorkGroup)
            .AsAQuestion(DoAnyEmployeesOnlyDoGeneralOfficeWorkQST);

        // Are there any delivery drivers on staff? 
        public static Element AreThereAnyDeliveryDriversLabel => new Element(By.XPath("//label[@data-qa='question_are there any delivery drivers on staff?_label']"));
        public static Element AreThereAnyDeliveryDriversHelper => new Element(By.XPath("//button[@data-qa='are there any delivery drivers on staff?_tooltip']"));
        public static Element AreThereAnyDeliveryDriversHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any delivery drivers on staff?']"));
        public static Element AreThereAnyDelivertDriversAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any delivery drivers on staff?']//button[text()='{answer}']"));

        //Do any staff work only in sales?
        public static Element DoAnyStaffWorkOnlyInSalesLabel => new Element(By.XPath("//label[@data-qa='question_do any staff work only in sales?_label']"));
        public static Element DoAnyStaffWorkOnlyInSalesHelper => new Element(By.XPath("//button[@data-qa='do any staff work only in sales?_tooltip']"));
        public static Element DoAnyStaffWorkOnlyInSalesHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='do any staff work only in sales?']"));
        public static Element DoAnyStaffWorkOnlyInSalesAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_do any staff work only in sales?']//button[text()='{answer}']"));

        //Are there any travelling sales staff that are not involved at all in the manufacturing process?
        public static Element AreThereAnyTravellingSalesStaffLabel => new Element(By.XPath("//label[@data-qa='question_are there any travelling sales staff that are not involved at all in the manufacturing process?_label']"));
        public static Element AreThereAnyTravellingSalesStaffHelper => new Element(By.XPath("//button[@data-qa='are there any travelling sales staff that are not involved at all in the manufacturing process?_tooltip']"));
        public static Element AreThereAnyTravellingSalesStaffHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any travelling sales staff that are not involved at all in the manufacturing process?']"));
        public static Element AreThereAnyTravellingSalesStaffAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any travelling sales staff that are not involved at all in the manufacturing process?']//button[text()='{answer}']"));

        //Are there any administrative or back office employees that are not involved at all in the manufacturing process?
        public static Element AreThereAnyAdminstrativeEmployeesLabel => new Element(By.XPath("//label[@data-qa='question_are there any administrative or back office employees that are not involved at all in the manufacturing process?_label']"));
        public static Element AreThereAnyAdminstrativeEmployeesHelper => new Element(By.XPath("//button[@data-qa='are there any administrative or back office employees that are not involved at all in the manufacturing process?_tooltip']"));
        public static Element AreThereAnyAdminstrativeEmployeesHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any administrative or back office employees that are not involved at all in the manufacturing process?']"));
        public static Element AreThereAnyAdminstrativeEmployeeAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any administrative or back office employees that are not involved at all in the manufacturing process?']//button[text()='{answer}']"));

        //Potential additional questions (based on keyword)---------------------------------------------------------------------------------------------------      
        //Do you have any auto salespersons on staff? 
        public static Element AutoSalesperOnStaffQST => new Element(By.XPath("//label[@data-qa='question_do you have any auto salespersons on staff?_label']"));

        //By default the element is NOT disabled, @disabled attribute isn't present
        public static Element AutoSalesperOnStaffYes(string status = "not") => new Element(By.XPath($"(//bb-options[@data-qa='select_do you have any auto salespersons on staff?']//button[text()='yes' and {status}(@disabled)])"));
        public static Element AutoSalesperOnStaffNo(string status = "not") => new Element(By.XPath($"(//bb-options[@data-qa='select_do you have any auto salespersons on staff?']//button[text()='no' and {status}(@disabled)])"));        
        public static Element AutoSalesperOnStaffHelper => new Element(By.XPath("//button[@data-qa='do you have any auto salespersons on staff?_tooltip']"));
        public static Element AutoSalesperOnStaffHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='do you have any auto salespersons on staff?']"));
        public static InputSection AutoSalesperOnStaffInput(string status = "not") => new YesOrNoInput(AutoSalesperOnStaffYes(status), AutoSalesperOnStaffNo(status))
            .AsAQuestion(AutoSalesperOnStaffQST)
            .WithHelpText(AutoSalesperOnStaffHelper, AutoSalesperOnStaffHelperText);
        //IF YOU SAY YES
        //Enter their total annual payroll
        public static Element AutoSalesperOnStaffPayrollQST => new Element(By.XPath("//label[@data-qa='enter_employee_payroll_label']"));
        public static Element AutoSalesperOnStaffPayrollTxtbox(string status = "not") => new Element(By.XPath($"(//bb-money[@data-qa='do you have any auto salespersons on staff?_employee_annual_payroll_input']//input[{status}(@disabled)])"));
       

        //Are there any actors, entertainers, or musicians on staff? 
        public static Element AnyActorsEntertainersQST => new Element(By.XPath("//label[@data-qa='question_are there any actors, entertainers, or musicians on staff?_label']"));
        public static Element AnyActorsEntertainersAnswer(string button) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any actors, entertainers, or musicians on staff?']//button[text()='{button}']"));
        public static YesOrNoGroup AnyActorsEntertainersAnswerGroup => new YesOrNoGroup(AnyActorsEntertainersAnswer("yes"), AnyActorsEntertainersAnswer("no"));
        public static InputSection AnyActorsEntertainers =>
            new YesOrNoInput(AnyActorsEntertainersAnswerGroup)
            .AsAQuestion(AnyActorsEntertainersQST);

        //Do any employees do any roadside assistance or towing?
        public static Element RoadsideTowingQST => new Element(By.XPath("//label[@data-qa='question_do any employees do any roadside assistance or towing?_label']"));

        //By default the element is NOT disabled, @disabled attribute isn't present
        public static Element RoadsideTowingYes(string status = "not") => new Element(By.XPath($"(//bb-options[@data-qa='select_do any employees do any roadside assistance or towing?']//button[text()='yes' and {status}(@disabled)])"));
        public static Element RoadsideTowingNo(string status = "not") => new Element(By.XPath($"(//bb-options[@data-qa='select_do any employees do any roadside assistance or towing?']//button[text()='no' and {status}(@disabled)])"));
        public static Element RoadsideTowingHelper => new Element(By.XPath("//button[@data-qa='do any employees do any roadside assistance or towing?_tooltip']"));
        public static Element RoadsideTowingHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='do any employees do any roadside assistance or towing?']"));
        public static InputSection RoadSideTowingInput(string status = "not") => new YesOrNoInput(RoadsideTowingYes(status), RoadsideTowingNo(status))
            .AsAQuestion(RoadsideTowingQST)
            .WithHelpText(RoadsideTowingHelper, RoadsideTowingHelperText);
        //IF YOU SAY YES
        //Enter their total annual payroll
        public static Element RoadsideTowingPayrollQST => new Element(By.XPath("//label[@data-qa='enter_employee_payroll_label']"));
        public static Element RoadsideTowingPayrollTxtbox(string status = "not") => new Element(By.XPath($"(//bb-money[@data-qa='do any employees do any roadside assistance or towing?_employee_annual_payroll_input']//input[{status}(@disabled)])"));

        //Do any employees only do clerical office tasks and does not write up repair estimates? 
        public static Element EmpOfficeNotRepairEstQST => new Element(By.XPath("//label[@data-qa='question_do any employees only do clerical office tasks and does not write up repair estimates?_label']"));

        //By default the element is NOT disabled, @disabled attribute isn't present
        public static Element EmpOfficeNotRepairEstYes(string status = "not") => new Element(By.XPath($"(//bb-options[@data-qa='select_do any employees only do clerical office tasks and does not write up repair estimates?']//button[text()='yes' and {status}(@disabled)])"));
        public static Element EmpOfficeNotRepairEstNo(string status = "not") => new Element(By.XPath($"(//bb-options[@data-qa='select_do any employees only do clerical office tasks and does not write up repair estimates?']//button[text()='no' and {status}(@disabled)])"));
        public static Element EmpOfficeNotRepairEstHelper => new Element(By.XPath("//button[@data-qa='do any employees only do clerical office tasks and does not write up repair estimates?_tooltip']"));
        public static Element EmpOfficeNotRepairEstHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='do any employees only do clerical office tasks and does not write up repair estimates?']"));
        public static InputSection EmpOfficeNotRepairEstInput(string status = "not") => new YesOrNoInput(EmpOfficeNotRepairEstYes(status), EmpOfficeNotRepairEstNo(status))
            .AsAQuestion(EmpOfficeNotRepairEstQST)
            .WithHelpText(EmpOfficeNotRepairEstHelper, EmpOfficeNotRepairEstHelperText);
        //IF YOU SAY YES
        //Enter their total annual payroll
        public static Element EmpOfficeNotPayrollQST => new Element(By.XPath("//label[@data-qa='enter_employee_payroll_label']"));
        public static Element EmpOfficeNotPayrollTxtbox(string status = "not") => new Element(By.XPath($"(//bb-money[@data-qa='do any employees only do clerical office tasks and does not write up repair estimates?_employee_annual_payroll_input']//input[{status}(@disabled)])"));

        //Are there any employees that never travel to job sites or do any construction work?
        public static Element EmpNeverTravelJobSiteConstQST => new Element(By.XPath("//label[@data-qa='question_are there any employees that never travel to job sites or do any construction work?_label']"));
        public static Element EmpNeverTravelJobSiteConstAnswer(string button) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any employees that never travel to job sites or do any construction work?']//button[text()='{button}']"));
        public static Element EmpNeverTravelJobSiteConstHelper => new Element(By.XPath("//button[@data-qa='are there any employees that never travel to job sites or do any construction work?_tooltip']"));
        public static Element EmpNeverTravelJobSiteConstHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any employees that never travel to job sites or do any construction work?']"));
        //Do any employees only do electrical work?
        public static Element DoAnyEmployeesDoElectricalWorkQST => new Element(By.XPath("//label[@data-qa='question_do any employees only do electrical work?_label']"));
        public static Element DoAnyEmployeesDoElectricalWorkAnswer(string button) => new Element(By.XPath($"//bb-options[@data-qa='select_do any employees only do electrical work?']//button[text()='{button}']"));
        //Are there any licensed employee physicians, RNs, practical nurses, directors or administrators?
        public static Element LicensedEmployeePhysiciansQST => new Element(By.XPath("//label[@data-qa='question_are there any licensed employee physicians, RNs, practical nurses, directors or administrators?_label']"));
        public static Element LicensedEmployeePhysiciansAnswer(string button) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any licensed employee physicians, RNs, practical nurses, directors or administrators?']//button[text()='{button}']"));
        public static Element LicensedEmployeePhysiciansHelper => new Element(By.XPath("//button[@data-qa='are there any licensed employee physicians, RNs, practical nurses, directors or administrators?_tooltip']"));
        public static Element LicensedEmployeePhysiciansHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any licensed employee physicians, RNs, practical nurses, directors or administrators?']"));
        public static YesOrNoGroup LicensedEmployeePhysiciansGroup => new YesOrNoGroup(LicensedEmployeePhysiciansAnswer("yes"), LicensedEmployeePhysiciansAnswer("no"));
        public static InputSection LicensedEmployeePhysiciansInput =>
            new YesOrNoInput(LicensedEmployeePhysiciansGroup)
            .AsAQuestion(LicensedEmployeePhysiciansQST)
            .WithHelpText(LicensedEmployeePhysiciansHelper, LicensedEmployeePhysiciansHelperText);

        //Do you make any payments to workers using IRS Form 1099?
        public static Element PaymentsToWorkersUsingIRSQST => new Element(By.XPath("//label[@data-qa='question_439']"));
        public static Element PaymentsToWorkersUsingIRSAnswer(string button) => new Element(By.XPath($"//bb-options[@data-qa='response_439']//button[text()='{button}']"));
        public static YesOrNoGroup PaymentsToWorkersUsingIRSGroup => new YesOrNoGroup(PaymentsToWorkersUsingIRSAnswer("yes"), PaymentsToWorkersUsingIRSAnswer("no"));
        public static InputSection PaymentsToWorkersUsingIRSInput =>
            new YesOrNoInput(PaymentsToWorkersUsingIRSGroup)
            .AsAQuestion(PaymentsToWorkersUsingIRSQST);

        //Do you use any subcontractors or pay any workers using IRS Form 1099?
        public static Element PayIRSForm1099QST => new Element(By.XPath("//label[@data-qa='question_447']"));
        public static Element PayIRSForm1099Answer(string button) => new Element(By.XPath($"//bb-options[@data-qa='response_447']//button[text()='{button}']"));

        //Do you require all subcontractors/1099 workers to have certificates of insurance?
        public static Element ReqWorkCOIQST => new Element(By.XPath("//label[@data-qa='question_448']"));
        public static Element ReqWorkCOIDD => new Element(By.XPath("//bb-select[@data-qa='select_448']/span/select"));
        public static Element ReqWorkCOIHelper => new Element(By.XPath("//button[@data-qa='448_tooltip']"));
        public static Element ReqWorkCOIHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='448']"));
        //How much of total work is done by subcontractors/1099 workers?
        public static Element HowMuchTotalWorkDoneQST => new Element(By.XPath("//label[@data-qa='question_449']"));
        public static Element HowMuchTotalWorkDoneDD => new Element(By.XPath("//bb-select[@data-qa='select_449']/span/select"));

        //Are there any cost estimators on staff that wouldn't do any direct physical work?
        public static Element CostEstOnStaffNoDirectPhysicalQST => new Element(By.XPath("//label[@data-qa=\"question_are there any cost estimators on staff that wouldn't do any direct physical work?_label\"]"));
        public static Element CostEstOnStaffNoDirectPhysicalAnswer(string button) => new Element(By.XPath($"//label[@data-qa=\"question_are there any cost estimators on staff that wouldn't do any direct physical work?_label\"]//following-sibling::bb-options//button[text()='{button}']"));
        public static Element CostEstOnStaffNoDirectPhysicalHelper => new Element(By.XPath("//button[@data-qa=\"are there any cost estimators on staff that wouldn't do any direct physical work?_tooltip\"]"));
        public static Element CostEstOnStaffNoDirectPhysicalHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any cost estimators on staff that wouldn't do any direct physical work?']"));

        //Do any employees only do general office work and rarely travel?
        public static Element EmpGeneralWorkRarelyTravelQST => new Element(By.XPath("//label[@data-qa='question_do any employees only do general office work and rarely travel?_label']"));
        public static Element EmpGeneralWorkRarelyTravelAnswer(string button) => new Element(By.XPath($"//label[@data-qa='question_do any employees only do general office work and rarely travel?_label']//following-sibling::bb-options//button[text()='{button}']"));
        public static Element EmpGeneralWorkRarelyTravelHelper => new Element(By.XPath("//button[@data-qa='do any employees only do general office work and rarely travel?_tooltip']"));
        public static Element EmpGeneralWorkRarelyTravelHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='do any employees only do general office work and rarely travel?']"));

        //Are there any employees that do not drive and do not load/unload goods?
        public static Element EmpDoNotDriveUnloadGoodsQst => new Element(By.XPath("//label[@data-qa='question_are there any employees that do not drive and do not load/unload goods?_label']"));
        public static Element EmpDoNotDriveUnloadGoodsAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any employees that do not drive and do not load/unload goods?']//button[text()='{answer}']"));
        public static Element EmpDoNotDriveUnloadGoodsHelper => new Element(By.XPath("//button[@data-qa='are there any employees that do not drive and do not load/unload goods?_tooltip']"));
        public static Element EmpDoNotDriveUnloadGoodsHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any employees that do not drive and do not load/unload goods?']"));
        public static YesOrNoGroup EmpDoNotDriveUnloadGoodsGroup => new YesOrNoGroup(EmpDoNotDriveUnloadGoodsAnswer("yes"), EmpDoNotDriveUnloadGoodsAnswer("no"));
        public static InputSection EmpDoNotDriveUnloadGoodsInput => new YesOrNoInput(EmpDoNotDriveUnloadGoodsGroup).AsAQuestion(EmpDoNotDriveUnloadGoodsQst).WithHelpText(EmpDoNotDriveUnloadGoodsHelper, EmpDoNotDriveUnloadGoodsHelperText);

        //Do any owner operators or sub-haulers transport goods on your behalf?
        public static Element OOTransportGoodsBehalfQST => new Element(By.XPath("//label[@data-qa='question_453']"));
        public static Element OOTransportGoodsBehalfAnswer(string button) => new Element(By.XPath($"//label[@data-qa='question_453']//following-sibling::bb-options//button[text()='{button}']"));
        public static Element OOTransportGoodsBehalfHelper => new Element(By.XPath("//button[@data-qa='453_tooltip']"));
        public static Element OOTransportGoodsBehalfHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='453']"));
        public static YesOrNoGroup OOTransportGoodsBehalfGroup => new YesOrNoGroup(OOTransportGoodsBehalfAnswer("yes"), OOTransportGoodsBehalfAnswer("no"));
        public static InputSection OOTransportGoodsBehalfInput => new YesOrNoInput(OOTransportGoodsBehalfGroup).AsAQuestion(OOTransportGoodsBehalfQST).WithHelpText(OOTransportGoodsBehalfHelper, OOTransportGoodsBehalfHelperText);

        // Are there any delivery drivers on staff (includes bicycles)?
        public static Element AreThereAnyDeliveryDriversOnStaffQST => new Element(By.XPath("//label[@data-qa='question_are there any delivery drivers on staff (includes bicycles)?_label']"));
        public static Element AreThereAnyDeliveryDriversOnStaffHelper=> new Element(By.XPath("//button[@data-qa='are there any delivery drivers on staff (includes bicycles)?_tooltip']"));
        public static Element AreThereAnyDeliveryDriversOnStaffHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any delivery drivers on staff (includes bicycles)?']"));
        public static Element AreThereAnyDeliveryDriversOnStaffAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any delivery drivers on staff (includes bicycles)?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup AreThereAnyDeliveryDriversOnStaffGroup => new YesOrNoGroup(AreThereAnyDeliveryDriversOnStaffAnswer("yes"), AreThereAnyDeliveryDriversOnStaffAnswer("no"));
        public static InputSection AreThereAnyDeliveryDriversOnStaffInput => new YesOrNoInput(AreThereAnyDeliveryDriversOnStaffGroup)
            .AsAQuestion(AreThereAnyDeliveryDriversOnStaffQST)
            .WithHelpText(AreThereAnyDeliveryDriversOnStaffHelper, AreThereAnyDeliveryDriversOnStaffHelperText);

        //Is housing provided for any of the workers?
        public static Element IsHousingProvidedForAnyWorkersQST => new Element(By.XPath("//label[@data-qa='question_200']"));
        public static Element IsHousingProvidedForAnyWorkersAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='response_200']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup IsHousingProvidedForAnyWorkersGroup => new YesOrNoGroup(IsHousingProvidedForAnyWorkersAnswer("yes"), IsHousingProvidedForAnyWorkersAnswer("no"));
        public static InputSection IsHousingProvidedForAnyWorkersInput => new YesOrNoInput(IsHousingProvidedForAnyWorkersGroup)
            .AsAQuestion(IsHousingProvidedForAnyWorkersQST);

        //Are there employees that do not do any actual physical work but travel to job sites?
        public static Element EmployeesDoNotWorkAndTravelQST => new Element(By.XPath("//label[@data-qa='question_are there employees that do not do any actual physical work but travel to job sites?_label']"));
        public static Element EmployeesDoNotWorkAndTravelAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there employees that do not do any actual physical work but travel to job sites?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup EmployeesDoNotWorkAndTravelGroup => new YesOrNoGroup(EmployeesDoNotWorkAndTravelAnswer("yes"), EmployeesDoNotWorkAndTravelAnswer("no"));
        public static InputSection EmployeesDoNotWorkAndTravelInput => new YesOrNoInput(EmployeesDoNotWorkAndTravelGroup)
            .AsAQuestion(EmployeesDoNotWorkAndTravelQST);
        //Do any employees do any maintenance, repair, or service on motor vehicles?
        public static Element MaintenanceRepairOrServiceVehiclesQST => new Element(By.XPath("//label[@data-qa='question_do any employees do any maintenance, repair, or service on motor vehicles?_label']"));
        public static Element MaintenanceRepairOrServiceVehiclesAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_do any employees do any maintenance, repair, or service on motor vehicles?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup MaintenanceRepairOrServiceVehiclesGroup => new YesOrNoGroup(MaintenanceRepairOrServiceVehiclesAnswer("yes"), MaintenanceRepairOrServiceVehiclesAnswer("no"));
        public static InputSection MaintenanceRepairOrServiceVehiclesInput => new YesOrNoInput(MaintenanceRepairOrServiceVehiclesGroup)
            .AsAQuestion(MaintenanceRepairOrServiceVehiclesQST);

        //Do any employees deliver goods but wouldn't help set up or install anything?
        public static Element HelpSetUpOrInstallAnythingQST => new Element(By.XPath("//label[@data-qa=\"question_do any employees deliver goods but wouldn't help set up or install anything?_label\"]"));
        public static Element HelpSetUpOrInstallAnythingAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa=\"select_do any employees deliver goods but wouldn't help set up or install anything?\"]//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup HelpSetUpOrInstallAnythingGroup => new YesOrNoGroup(HelpSetUpOrInstallAnythingAnswer("yes"), HelpSetUpOrInstallAnythingAnswer("no"));
        public static InputSection HelpSetUpOrInstallAnythingInput => new YesOrNoInput(HelpSetUpOrInstallAnythingGroup)
            .AsAQuestion(HelpSetUpOrInstallAnythingQST);

        //Are there any retail store employees that do not do any installation, maintenance, or contracting work?
        public static Element EmployeesThatDoInstallationQST => new Element(By.XPath("//label[@data-qa='question_are there any retail store employees that do not do any installation, maintenance, or contracting work?_label']"));
        public static Element EmployeesThatDoInstallationAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa=\"select_are there any retail store employees that do not do any installation, maintenance, or contracting work?\"]//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup EmployeesThatDoInstallationGroup => new YesOrNoGroup(EmployeesThatDoInstallationAnswer("yes"), EmployeesThatDoInstallationAnswer("no"));
        public static InputSection EmployeesThatDoInstallationInput => new YesOrNoInput(EmployeesThatDoInstallationGroup)
            .AsAQuestion(EmployeesThatDoInstallationQST);

        //Do any employees only do general office work and do not work a cash register?
        public static Element WorkACashRegisterQST => new Element(By.XPath("//label[@data-qa='question_do any employees only do general office work and do not work a cash register?_label']"));
        public static Element WorkACashRegisterAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa=\"select_do any employees only do general office work and do not work a cash register?\"]//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup WorkACashRegisterGroup => new YesOrNoGroup(WorkACashRegisterAnswer("yes"), WorkACashRegisterAnswer("no"));
        public static InputSection WorkACashRegisterInput => new YesOrNoInput(WorkACashRegisterGroup)
            .AsAQuestion(WorkACashRegisterQST);

        //Do any employee contractors make at least $32/hr?
        public static Element DoAnyEmployeeMake32QST => new Element(By.XPath("//label[@data-qa='question_do any employee contractors make at least $32/hr?_label']"));
        public static Element DoAnyEmployeeMake32Answer(string button) => new Element(By.XPath($"//bb-options[@data-qa='select_do any employee contractors make at least $32/hr?']//button[text()='{button}']"));
        public static Element DoAnyEmployeeMake32Helper => new Element(By.XPath("//button[@data-qa='do any employee contractors make at least $32/hr?_tooltip']"));
        public static Element DoAnyEmployeeMake32HelperText => new Element(By.XPath("//bb-tooltip[@data-qa='do any employee contractors make at least $32/hr?']"));
        public static YesOrNoGroup DoAnyEmployeeMake32Group => new YesOrNoGroup(DoAnyEmployeeMake32Answer("yes"), DoAnyEmployeeMake32Answer("no"));
        public static InputSection DoAnyEmployeeMake32Input =>
            new YesOrNoInput(DoAnyEmployeeMake32Group)
            .AsAQuestion(DoAnyEmployeeMake32QST)
            .WithHelpText(DoAnyEmployeeMake32Helper, DoAnyEmployeeMake32HelperText);

        //Are there any back office employees that would never assist with moves, handle any goods, or drive any trucks?
        public static Element OfficeEmployeesQST => new Element(By.XPath("//label[@data-qa='question_are there any back office employees that would never assist with moves, handle any goods, or drive any trucks?_label']"));
        public static Element OfficeEmployeesAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa=\"select_are there any back office employees that would never assist with moves, handle any goods, or drive any trucks?\"]//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup OfficeEmployeesGroup => new YesOrNoGroup(OfficeEmployeesAnswer("yes"), OfficeEmployeesAnswer("no"));
        public static InputSection OfficeEmployeesInput => new YesOrNoInput(OfficeEmployeesGroup)
            .AsAQuestion(OfficeEmployeesQST);

        //Are there any drivers that drive trucks you own or lease but pay via 1099?
        public static Element DriversPaidVia1099QST => new Element(By.XPath("//label[@data-qa='question_462']"));
        public static Element DriversPaidVia1099Answer(string answer) => new Element(By.XPath($"//bb-options[@data-qa=\"response_462\"]//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup DriversPaidVia1099Group => new YesOrNoGroup(DriversPaidVia1099Answer("yes"), DriversPaidVia1099Answer("no"));
        public static InputSection DriversPaidVia1099Input => new YesOrNoInput(DriversPaidVia1099Group)
            .AsAQuestion(DriversPaidVia1099QST);

        //Do any owner operators or sub-haulers transport goods on your behalf?
        public static Element SubHaulersQST => new Element(By.XPath("//label[@data-qa='question_453']"));
        public static Element SubHaulersAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa=\"response_453\"]//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup SubHaulersGroup => new YesOrNoGroup(SubHaulersAnswer("yes"), SubHaulersAnswer("no"));
        public static InputSection SubHaulersInput => new YesOrNoInput(SubHaulersGroup)
            .AsAQuestion(SubHaulersQST);

        //Do any employees travel frequently for sales or consultation?
        public static Element DoEmployeesTravelQST => new Element(By.XPath("//label[@data-qa='question_do any employees travel frequently for sales or consultation?_label']"));
        public static Element DoEmployeesTravelAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa=\"select_do any employees travel frequently for sales or consultation?\"]//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup DoEmployeesTravelGroup => new YesOrNoGroup(DoEmployeesTravelAnswer("yes"), DoEmployeesTravelAnswer("no"));
        public static InputSection DoEmployeesTravelInput => new YesOrNoInput(DoEmployeesTravelGroup)
            .AsAQuestion(DoEmployeesTravelQST);

        //Are there any scouts or traveling recruiters on staff?
        public static Element ScoutsOrRecruitersQST => new Element(By.XPath("//label[@data-qa='question_are there any scouts or traveling recruiters on staff?_label']"));
        public static Element ScoutsOrRecruitersHelper => new Element(By.XPath("//button[@data-qa='are there any scouts or traveling recruiters on staff?_tooltip']"));
        public static Element ScoutsOrRecruitersHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any scouts or traveling recruiters on staff?']"));
        public static Element ScoutsOrRecruitersAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any scouts or traveling recruiters on staff?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup ScoutsOrRecruitersGroup => new YesOrNoGroup(ScoutsOrRecruitersAnswer("yes"), ScoutsOrRecruitersAnswer("no"));
        public static InputSection ScoutsOrRecruitersInput => new YesOrNoInput(ScoutsOrRecruitersGroup)
            .AsAQuestion(ScoutsOrRecruitersQST);

        //Are there any clerical office staff? 
        public static Element ClericalStaffQST => new Element(By.XPath("//label[@data-qa='question_are there any clerical office staff?_label']"));
        public static Element ClericalStaffHelper => new Element(By.XPath("//button[@data-qa='are there any clerical office staff?_tooltip']"));
        public static Element ClericalStaffHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any clerical office staff?']"));
        public static Element ClericalStaffAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any clerical office staff?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup ClericalStaffGroup => new YesOrNoGroup(ClericalStaffAnswer("yes"), ClericalStaffAnswer("no"));
        public static InputSection ClericalStaffInput => new YesOrNoInput(ClericalStaffGroup)
            .AsAQuestion(ClericalStaffQST)
            .WithHelpText(ClericalStaffHelper, ClericalStaffHelperText);

        //Are there any clerical office workers or real estate/leasing agents on staff?
        public static Element ClericalOrOfficeWorkersQST => new Element(By.XPath("//label[@data-qa='question_are there any clerical office workers or real estate/leasing agents on staff?_label']"));
        public static Element ClericalOrOfficeWorkersHelper => new Element(By.XPath("//button[@data-qa='are there any clerical office workers or real estate/leasing agents on staff?_tooltip']"));
        public static Element ClericalOrOfficeWorkersHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any clerical office workers or real estate/leasing agents on staff?']"));
        public static Element ClericalOrOfficeWorkersAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any clerical office workers or real estate/leasing agents on staff?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup ClericalOrOfficeWorkersGroup => new YesOrNoGroup(ClericalOrOfficeWorkersAnswer("yes"), ClericalOrOfficeWorkersAnswer("no"));
        public static InputSection ClericalOrOfficeWorkersInput => new YesOrNoInput(ClericalOrOfficeWorkersGroup)
            .AsAQuestion(ClericalOrOfficeWorkersQST)
            .WithHelpText(ClericalOrOfficeWorkersHelper, ClericalOrOfficeWorkersHelperText);

        // Do you pay any subcontractors/1099 workers to do installation of machines/equipment on your behalf?
        public static Element WorkersInstallMachinesQST => new Element(By.XPath("//label[@data-qa='question_654']"));
        public static Element WorkersInstallMachinesAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa=\"response_654\"]//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup WorkersInstallMachinesGroup => new YesOrNoGroup(WorkersInstallMachinesAnswer("yes"), WorkersInstallMachinesAnswer("no"));
        public static InputSection WorkersInstallMachinesInput => new YesOrNoInput(WorkersInstallMachinesGroup)
            .AsAQuestion(WorkersInstallMachinesQST);

        // Do you provide any boxing, martial arts, climbing, or gymnastics training/classes? 
        public static Element ProvideMartialArtTrainingQST => new Element(By.XPath("//label[@data-qa='question_163']"));
        public static Element ProvideMartialArtTrainingAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='response_163']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup ProvideMartialArtTrainingGroup => new YesOrNoGroup(ProvideMartialArtTrainingAnswer("yes"), ProvideMartialArtTrainingAnswer("no"));
        public static InputSection ProvideMartialArtTrainingInput => new YesOrNoInput(ProvideMartialArtTrainingGroup)
            .AsAQuestion(ProvideMartialArtTrainingQST);

        // Do you pay any class instructors or personal trainers using 1099s? 
        public static Element PayPersonalInstructorsQST => new Element(By.XPath("//label[@data-qa='question_164']"));
        public static Element PayPersonalInstructorsAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='response_164']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup PayPersonalInstructorsGroup => new YesOrNoGroup(PayPersonalInstructorsAnswer("yes"), PayPersonalInstructorsAnswer("no"));
        public static InputSection PayPersonalInstructorsInput => new YesOrNoInput(PayPersonalInstructorsGroup)
            .AsAQuestion(PayPersonalInstructorsQST);

        //Are there any travelling salespersons on staff that do not interact with clients?
        public static Element DoNotInteractWithClientsQST => new Element(By.XPath("//label[@data-qa='question_are there any travelling salespersons on staff that do not interact with clients?_label']"));
        public static Element DoNotInteractWithClientsAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any travelling salespersons on staff that do not interact with clients?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup DoNotInteractWithClientsGroup => new YesOrNoGroup(DoNotInteractWithClientsAnswer("yes"), DoNotInteractWithClientsAnswer("no"));
        public static InputSection DoNotInteractWithClientsInput => new YesOrNoInput(DoNotInteractWithClientsGroup)
            .AsAQuestion(DoNotInteractWithClientsQST);

        //Are there any administrative staff that do not interact with clients and never travel? 
        public static Element DoNotInteractWithClientsNeverTravelQST => new Element(By.XPath("//label[@data-qa='question_are there any administrative staff that do not interact with clients and never travel?_label']"));
        public static Element DoNotInteractWithClientsNeverTravelAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any administrative staff that do not interact with clients and never travel?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup DoNotInteractWithClientsNeverTravelGroup => new YesOrNoGroup(DoNotInteractWithClientsNeverTravelAnswer("yes"), DoNotInteractWithClientsNeverTravelAnswer("no"));
        public static InputSection DoNotInteractWithClientsNeverTravelInput => new YesOrNoInput(DoNotInteractWithClientsNeverTravelGroup)
            .AsAQuestion(DoNotInteractWithClientsNeverTravelQST);

        // Are there any administrative staff that never interact with clients/patients?
        public static Element AdminStaffNeverInteractWithClientsQST => new Element(By.XPath("//label[@data-qa='question_are there any administrative staff that never interact with clients/patients?_label']"));
        public static Element AdminStaffNeverInteractWithClientAnswer(string answer) => new Element($"//bb-options[@data-qa='select_are there any administrative staff that never interact with clients/patients?']//button[text()='{answer}']");
        public static YesOrNoGroup AdminStaffNeverInteractWithClientAnswerGroup => new YesOrNoGroup(AdminStaffNeverInteractWithClientAnswer("yes"), AdminStaffNeverInteractWithClientAnswer("no"));
        public static InputSection AdminStaffNeverInteractWithClientInput => new YesOrNoInput(AdminStaffNeverInteractWithClientAnswerGroup)
            .AsAQuestion(AdminStaffNeverInteractWithClientsQST);

        //Are there any actors, entertainers, or musicians on staff?
        public static Element AreThereAnyActorsQST => new Element(By.XPath("//label[@data-qa='question_are there any actors, entertainers, or musicians on staff?_label']"));
        public static Element AreThereAnyActorsHelper => new Element(By.XPath("//button[@data-qa='are there any actors, entertainers, or musicians on staff?_tooltip']"));
        public static Element AreThereAnyActorsHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any actors, entertainers, or musicians on staff?']"));
        public static Element AreThereAnyActorsAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any actors, entertainers, or musicians on staff?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup AreThereAnyActorsGroup => new YesOrNoGroup(AreThereAnyActorsAnswer("yes"), AreThereAnyActorsAnswer("no"));
        public static InputSection AreThereAnyActorsInput => new YesOrNoInput(AreThereAnyActorsGroup)
            .AsAQuestion(AreThereAnyActorsQST)
            .WithHelpText(AreThereAnyActorsHelper, AreThereAnyActorsHelperText);

        // Business information--------------------------------------------------------------------------------------------------------------------------------
        // Business name
        public static Element BusinessNameQST => new Element(By.XPath("//label[@data-qa='business_name_label']"));
        public static Element BusinessNameTxtbox => new Element(By.XPath("//input[@data-qa='business_name_input']"));
        public static Element BusinessNameError => new Element(By.XPath($"//p[@data-qa='error-{BusinessNameTxtbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // Doing business as (optional)
        public static Element DoingBusinessAsQst => new Element(By.XPath("//label[@data-qa='DBA_label']"));
        public static Element DoingBusinessAsTxtbox => new Element(By.XPath("//input[@data-qa='DBA_input']"));

        // Business address line 1
        public static Element BusinessAddressLine1QST => new Element(By.XPath("//label[@data-qa='business_address_1_label']"));
        public static Element BusinessAddressLine1Txtbox => new Element(By.XPath("//input[@data-qa='business_address_1_input']"));
        public static Element BusinessAddressLine1Error => new Element(By.XPath($"//p[@data-qa='error-{BusinessAddressLine1Txtbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // Business address line 2
        public static Element BusinessAddressLine2QST => new Element(By.XPath("//label[@data-qa='business_address_2_label']"));
        public static Element BusinessAddressLine2Txtbox => new Element(By.XPath("//input[@data-qa='business_address_2_input']"));

        // City
        public static Element CityQST => new Element(By.XPath("//label[@data-qa='city_label']"));
        public static Element CityDD => new Element(By.XPath("//bb-select[@data-qa='city_select']//select"));
        public static Element CityError => new Element(By.XPath($"//p[@data-qa='error-{CityDD.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // State
        public static Element StateQST => new Element(By.XPath("//label[@data-qa='state_label']"));
        public static Element getState => new Element(By.XPath("//div[starts-with(@data-qa,'state_')]"));
        public static Element State(string state) => new Element(By.XPath($"//div[@data-qa='state_{state}']"));
        public static Element StateError(string state) => new Element(By.XPath($"//p[@data-qa='error-{State(state).GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // ZIP Code
        public static Element zipCodeQST => new Element(By.XPath("//label[@data-qa='zip_label']"));
        public static Element zipCode(int zip) => new Element(By.XPath($"//div[@data-qa='zip_{zip}']"));

        // Contact Information
        // Contact first name
        public static Element ContactFirstNameQST => new Element(By.XPath("//label[@data-qa='contact_firstname_label']"));
        public static Element ContactFirstNameTxtbox => new Element(By.XPath("//input[@data-qa='contact_firstname_input']"));
        public static Element ContactFirstNameError => new Element(By.XPath($"//p[@data-qa='error-{ContactFirstNameTxtbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // Contact last name
        public static Element ContactLastNameQST => new Element(By.XPath("//label[@data-qa='contact_lastname_label']"));
        public static Element ContactLastNameTxtbox => new Element(By.XPath("//input[@data-qa='contact_lastname_input']"));
        public static Element ContactLastNameError => new Element(By.XPath($"//p[@data-qa='error-{ContactLastNameTxtbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // Insured first name
        public static Element InsuredFirstNameQST => new Element(By.XPath("//label[@data-qa='insured_firstname_label']"));
        public static Element InsuredFirstNameTxtbox => new Element(By.XPath("//input[@data-qa='insured_firstname_input']"));
        public static Element InsuredFirstNameError => new Element(By.XPath($"//p[@data-qa='error-{InsuredFirstNameTxtbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // Insured last name
        public static Element InsuredLastNameQST => new Element(By.XPath("//label[@data-qa='insured_lastname_label']"));
        public static Element InsuredLastNameTxtbox => new Element(By.XPath("//input[@data-qa='insured_lastname_input']"));
        public static Element InsuredLastNameError => new Element(By.XPath($"//p[@data-qa='error-{InsuredLastNameTxtbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // Contact email
        public static Element ContactEmailQST => new Element(By.XPath("//label[@data-qa='contact_email_label']"));
        public static Element ContactEmailTxtbox => new Element(By.XPath("//bb-email[@data-qa='contact_email_input']//input"));
        public static Element ContactEmailError => new Element(By.XPath($"//p[@data-qa='error-{ContactEmailTxtbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // Contact phone
        public static Element ContactPhoneQST => new Element(By.XPath("//label[@data-qa='contact_phone_label']"));
        public static Element ContactPhoneTxtbox => new Element(By.XPath("//bb-phone[@data-qa='contact_phone_input']//input"));
        public static Element ContactPhoneError => new Element(By.XPath($"//p[@data-qa='error-{ContactPhoneTxtbox.GetAttribute("bb-validation-id")}']/preceding-sibling::p"));

        // Business website
        public static Element BusinessWebsiteQST => new Element(By.XPath("//label[@data-qa='business_website_label']"));
        public static Element BusinessWebsiteTxtbox => new Element(By.XPath("//input[@data-qa='business_website_input']"));

        // Continue
        public static Element ContinueCTA => new Element(By.XPath("//button[@data-qa='about_you_continue_button']"));

        //Do you use any volunteers or donated labor?
        public static Element AnyVolunteers => new Element(By.XPath("//label[@data-qa='question_186']"));
        public static Element AnyVolunteersYesBtn => new Element(By.XPath("//bb-options[@data-qa='response_186']//button[text()='yes']"));
        public static Element AnyVolunteersNoBtn => new Element(By.XPath("//bb-options[@data-qa='response_186']//button[text()='no']"));
        public static YesOrNoGroup AnyVolunteersGroup => new YesOrNoGroup(AnyVolunteersYesBtn, AnyVolunteersNoBtn);
        public static InputSection AnyVolunteers_Input =>
          new YesOrNoInput(AnyVolunteersGroup)
           .AsAQuestion(AnyVolunteers);

        //Do any employees travel frequently for sales, consultation, or auditing?
        public static Element AnyEmployeeSalesConsultationQST => new Element(By.XPath("//label[@data-qa='question_do any employees travel frequently for sales, consultation, or auditing?_label']"));
        public static Element AnyEmployeeSalesConsultationAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_do any employees travel frequently for sales, consultation, or auditing?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup AnyEmployeeSalesConsultationGroup => new YesOrNoGroup(AnyEmployeeSalesConsultationAnswer("yes"), AnyEmployeeSalesConsultationAnswer("no"));
        public static InputSection AnyEmployeeSalesConsultationInput => new YesOrNoInput(AnyEmployeeSalesConsultationGroup)
            .AsAQuestion(AnyEmployeeSalesConsultationQST);

        //Do you provide any staffing services?
        public static Element StaffingServicesQST => new Element(By.XPath("//label[@data-qa='question_251']"));
        public static Element StaffingServicesAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='response_251']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup StaffingServicesGroup => new YesOrNoGroup(StaffingServicesAnswer("yes"), StaffingServicesAnswer("no"));
        public static InputSection StaffingServicesInput => new YesOrNoInput(StaffingServicesGroup)
            .AsAQuestion(StaffingServicesQST);
        public static Element StaffingServicesCompensation => new Element(By.XPath("//bb-select[@data-qa='select_413']//select"));
        public static Element TemporaryWorkersPay => new Element(By.XPath("//input[@data-qa='text_input_416']"));


        //Do any employees help set up/install items such as furniture, lighting, stages, or tents?
        public static Element EmployeesInstallItemsQST => new Element(By.XPath("//label[@data-qa='question_do any employees help set up/install items such as furniture, lighting, stages, or tents?_label']"));
        public static Element EmployeesInstallItemsHelper => new Element(By.XPath("//button[@data-qa='do any employees help set up/install items such as furniture, lighting, stages, or tents?_tooltip']"));
        public static Element EmployeesInstallItemsHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='do any employees help set up/install items such as furniture, lighting, stages, or tents?']"));
        public static Element EmployeesInstallItemsAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_do any employees help set up/install items such as furniture, lighting, stages, or tents?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup EmployeesInstallItemsGroup => new YesOrNoGroup(EmployeesInstallItemsAnswer("yes"), EmployeesInstallItemsAnswer("no"));
        public static InputSection EmployeesInstallItemsInput => new YesOrNoInput(EmployeesInstallItemsGroup)
            .AsAQuestion(EmployeesInstallItemsQST)
          .WithHelpText(EmployeesInstallItemsHelper, EmployeesInstallItemsHelperText);

        //Are there any employees that do not do any cleaning or maintenance work?
        public static Element CleaningOrMaintenanceWork => new Element(By.XPath("//label[@data-qa='question_are there any employees that do not do any cleaning or maintenance work?_label']"));
        public static Element CleaningOrMaintenanceWorkAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any employees that do not do any cleaning or maintenance work?']/descendant::button[text()='{answer}']"));

        //Do any employees do any maintenance or repair work on aircraft?
        public static Element EmployeesMaintenanceRepairAircraftQST => new Element(By.XPath("//label[@data-qa='question_do any employees do any maintenance or repair work on aircraft?_label']"));
        public static Element EmployeesMaintenanceRepairAircraftAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_do any employees do any maintenance or repair work on aircraft?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup EmployeesMaintenanceRepairAircraftAnswerGroup => new YesOrNoGroup(EmployeesMaintenanceRepairAircraftAnswer("yes"), EmployeesMaintenanceRepairAircraftAnswer("no"));
        public static InputSection EmployeesMaintenanceRepairAircraftAnswerInput => new YesOrNoInput(EmployeesMaintenanceRepairAircraftAnswerGroup)
            .AsAQuestion(EmployeesMaintenanceRepairAircraftQST);

        //Are there any licensed or certified teachers on staff?
        public static Element LicensedOrCertifiedTeachersQST => new Element(By.XPath("//label[@data-qa='question_are there any licensed or certified teachers on staff?_label']"));

        public static Element LicensedOrCertifiedTeachersAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any licensed or certified teachers on staff?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup LicensedOrCertifiedTeachersAnswerGroup => new YesOrNoGroup(LicensedOrCertifiedTeachersAnswer("yes"), LicensedOrCertifiedTeachersAnswer("no"));
        public static InputSection LicensedOrCertifiedTeachersAnswerInput => new YesOrNoInput(LicensedOrCertifiedTeachersAnswerGroup)
            .AsAQuestion(LicensedOrCertifiedTeachersQST);
        public static Element LicensedOrCertifiedTeachersAnnualPayrollQST => new Element(By.XPath("//label[@data-qa='enter_employee_payroll_label']"));
        public static Element LicensedOrCertifiedTeachersAnnualPayrollTxtBox => new Element(By.XPath("//bb-money[@data-qa='are there any licensed or certified teachers on staff?_employee_annual_payroll_input']//input"));


        //Are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?
        public static Element SecurityPersonnelOrOtherWorkersQST => new Element(By.XPath("//label[@data-qa='question_are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?_label']"));
        public static Element SecurityPersonnelOrOtherWorkersHelper => new Element(By.XPath("//button[@data-qa='are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?_tooltip']"));
        public static Element SecurityPersonnelOrOtherWorkersHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?']"));
        public static Element SecurityPersonnelOrOtherWorkersAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='select_are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup SecurityPersonnelOrOtherWorkersAnswerGroup => new YesOrNoGroup(SecurityPersonnelOrOtherWorkersAnswer("yes"), SecurityPersonnelOrOtherWorkersAnswer("no"));
        public static InputSection SecurityPersonnelOrOtherWorkersAnswerInput => new YesOrNoInput(SecurityPersonnelOrOtherWorkersAnswerGroup)
            .AsAQuestion(SecurityPersonnelOrOtherWorkersQST);


        //Do any employees only do clerical office work or operate a retail store?
        public static Element ClericalOfficeWorkOrOperateRetailStoreQST => new Element(By.XPath("//label[@data-qa='question_do any employees only do clerical office work or operate a retail store?_label']"));
        public static Element ClericalOfficeWorkOrOperateRetailStoreAnswer(string button) => new Element(By.XPath($"//label[@data-qa='question_do any employees only do clerical office work or operate a retail store?_label']//following-sibling::bb-options//button[text()='{button}']"));
        public static Element ClericalOfficeWorkOrOperateRetailStoreHelper => new Element(By.XPath("//button[@data-qa='do any employees only do clerical office work or operate a retail store?_tooltip']"));
        public static Element ClericalOfficeWorkOrOperateRetailStoreAnswerlHelperText => new Element(By.XPath("//bb-tooltip[@data-qa='do any employees only do clerical office work or operate a retail store?_tooltip']"));
        public static YesOrNoGroup ClericalOfficeWorkOrOperateRetailStoreAnswerGroup => new YesOrNoGroup(ClericalOfficeWorkOrOperateRetailStoreAnswer("yes"), ClericalOfficeWorkOrOperateRetailStoreAnswer("no"));
        public static InputSection ClericalOfficeWorkOrOperateRetailStoreAnswerInput => new YesOrNoInput(ClericalOfficeWorkOrOperateRetailStoreAnswerGroup)
            .AsAQuestion(ClericalOfficeWorkOrOperateRetailStoreQST);

    }
}