using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages
{
    class UnderwritersQuestionPage
    {
        public static Element TitleWC => new Element(By.XPath("//h5[contains(text(),'workers')]"));
        // When do you want your policy to start?
        public static Element WhenDoYouWantYourPolicyStartQst => new Element(By.XPath("//h5[contains(text(),'workers')]"));
        // Policy Start Date field
        public static Element PolicyStartDate => new Element(By.XPath("//input[@id='InceptionDate']"));
        // When did you start your business?
        public static Element WhenDidStartYourBusQST => new Element(By.XPath("//label[contains(text(),'when did you start')]"));
        // When did you start your business? - Dropdown(DD)
        public static Element YearsBusinessDD => new Element(By.XPath("//select[@id='YearsInBusiness']"));
        // How is your business structured?
        public static Element BusinessStructuredQst => new Element(By.XPath("//label[contains(text(),'how is your business')]"));
        // How is your business structured? - Dropdown(DD)
        public static Element BusinessTypeDD => new Element(By.XPath("//select[(@id='BusinessType')]"));
        // Do you want to include coverage for any owners/officers?
        public static Element IncludedCoverageForAnyOwnersOfficersQst => new Element(By.XPath("//label[contains(text(),'include coverage for any owners/officer')]"));
        // Do you want to include coverage for any owners/officers? - Dropdown(DD)
        public static Element IncludedCoverageForAnyOwnersOfficersDD => new Element(By.XPath("//select[@id='BusinessOwners']"));

        // Question - What is the total annual payroll for W-2 employees? (exclude business owners/officers) 
        public static Element PayrollW2Qst => new Element(By.XPath("//label[contains(text(),'payroll for W-2')]"));
        // Link - More about Payroll Info
        public static Element MoreAboutPayrollInfo => new Element(By.XPath("//span[contains(text(),'More about')]"));
        /* info1 - Please give us your best estimate of what you'll pay to employees, using IRS form W-2, over the next 12 months. 
         * This includes salaries, hourly/sick/holiday/vacation pay, commissions, and bonuses paid to employees that are covered under the policy. 
         * Don't include tips, or pay to the business owner(s) or officers.*/
        public static Element Info1 => new Element(By.XPath("//p[contains(text(),'Please give us')]"));
        // Info 2 - Do not include pay to 1099 workers.
        public static Element Info2 => new Element(By.XPath("//p[contains(text(),'Do not include')]"));
        // info 3 - We only need your best estimate because next year, we will work with you in an audit to get the actual number.
        public static Element Info3 => new Element(By.XPath("//p[contains(text(),'get the actual number')]"));
        // Link - Less about Payroll Info
        public static Element LessAboutPayrollInfo => new Element(By.XPath("//span[contains(text(),'Less about')]"));
        // Input - What is the total annual payroll for W-2 employees? (exclude business owners/officers)
        public static Element PayrollAmount => new Element(By.XPath("//input[@id='Payroll']"));
        // Title - Tax ID type
        public static Element TitleTaxIdType => new Element(By.XPath("//label[contains(text(),'tax')]"));
        // Your Tax ID is linked to your claims history, so we use it to price your policy by checking to see if there is a published Experience Modification Factor or XMOD for your business.
        public static Element YourTaxIdIsLinkedToYourClaims => new Element(By.XPath("//p[contains(text(),'Your Tax ID is linked to your claims')]"));
        // FEIN - In put field
        public static Element FEIN => new Element(By.XPath("//input[@id='TaxId']"));
        // Question - In the past 3 years how many Workers' Compensation claims were reported?
        public static Element PastThreeYearsWCClaimsRepotedQst => new Element(By.XPath("//label[contains(text(),'in the past 3 years')]"));
        // Dropdown(DD) - In the past 3 years how many Workers' Compensation claims were reported?
        public static Element ClaimWereReportedDD => new Element(By.XPath("//select[@id='uq76']"));
        // Question - When was your last policy in effect?
        public static Element WhenWasYourPolInEffectQst => new Element(By.XPath("//label[contains(text(),'when was your last policy in effect')]"));
        // Dropdown - When was your last policy in effect?
        public static Element WhenWasYourPolInEffectDD => new Element(By.XPath("//select[@id='uq226']"));
        // Question - Do you have multiple locations in more than one state?
        public static Element DoYouHaveMultLocationQst => new Element(By.XPath("//label[contains(text(),'do you have multiple locations')]"));
        // Yes - Do you have multiple locations in more than one state?
        public static Element DoYouHaveMultLocationYes => new Element(By.XPath("//label[contains(text(),'do you have multiple locations')]//following::button[1]"));
        // No - Do you have multiple locations in more than one state?
        public static Element DoYouHaveMultLocationNo => new Element(By.XPath("//label[contains(text(),'do you have multiple locations')]//following::button[2]"));
        // Business name
        public static Element BusinessName => new Element(By.XPath("//input[(@id='BusinessName')]"));
        // Doing business as (optional)
        public static Element DoingBusinessAs => new Element(By.XPath("//input[(@id='DBA_0')]"));
        // Business website (optional)
        public static Element BusinessWebsite => new Element(By.XPath("//input[(@id='WebAddr')]"));
        // Business address line 1
        public static Element BusinessAddressLine1 => new Element(By.XPath("//input[(@id='Addr1')]"));
        // Business address line 2
        public static Element BusinessAddressLine2 => new Element(By.XPath("//input[(@id='Addr2')]"));
        // City - State - ZIP Code - ContactFirstName - ContactLastName - ContactEmail - ContactPhone
        public static Element CityDD => new Element(By.XPath("//select[(@id='City')]"));
        public static Element State => new Element(By.XPath("//label[contains(text(),'state')]//following-sibling::div"));
        public static Element ZipCode => new Element(By.XPath("//label[contains(text(),'zip code')]//following-sibling::div"));
        public static Element ContactFirstName => new Element(By.XPath("//input[@id='FirstName']"));
        public static Element ContactLastName => new Element(By.XPath("//input[@id='LastName']"));
        public static Element ContactEmail => new Element(By.XPath("//input[@type='email']"));
        public static Element ContactPhone => new Element(By.XPath("//input[contains(@id,'Phone')]"));

        // Submit CTA
        public static Element SubmitCTA => new Element(By.XPath("//button[@click.delegate='save()']"));

        // Taxicab More than one vehicle------------------------------------------------------------------------
        // Title - Do any included owners/officers only do general office work and rarely travel? 
        public static Element TitleIncluded => new Element(By.XPath("//button[contains(text(),'submit')]"));

        // Do any included owners/officers travel for sales and are not involved in the manufacturing process? 
        public static Element AreNotInvolvedMnfcProcessQST => new Element(By.XPath("//label[contains(text(),'are not involved at all in the manufacturing process')]"));
        public static Element AreNotInvolvedMnfcProcessDD => new Element(By.XPath("//select[@id='oocc_8742']"));
        public static Element Yes_1 => new Element(By.XPath("//label[contains(text(),'are not involved in the manufacturing process')]//following::option[3]"));
        public static Element AreNotInvolvedMnfcPrcNoCTA => new Element(By.XPath("//input[@id='cc_8742']//following::button[2]"));

        // Do any owners/officers only do general office work and rarely travel
        public static Element OwnerOfficerRarelyTravelQST => new Element(By.XPath("//label[contains(text(),'rarely travel')]"));
        public static Element OwnerOfficerRarelyTravelDD => new Element(By.XPath("//label[contains(text(),'officers only do general office work and rarely')]//following::select[contains(@id, 'oocc_')]"));

        public static Element OwnerOfficerGeneralRarelyTravelDD => new Element(By.XPath("//select[@id='oocc_0953']"));
        public static Element Yes_1RarelyTravel => new Element(By.XPath("//select[@id='oocc_0953']//child::option[2]"));
        public static Element RarelyTravelNoCTA => new Element(By.XPath("//label[contains(text(),'rarely travel')]//following::button[2]"));

        //Are there included owner/officers that do not drive for your business?
        public static Element OwnerOfficersDoNotDriveForBusinessQST => new Element(By.XPath("//label[contains(text(), 'are there included owner/officers that do not drive for your business?')]"));
        public static Element OwnerOfficersDoNotDriveForBusinessDD => new Element(By.XPath("//label[contains(text(), 'are there included owner/officers that do not drive for your business?')]//following::select[contains(@id, 'oocc_')]"));


        //Are there any travelling sales staff that are not involved at all in the manufacturing process?
        public static Element StufInvolvedMFProcessQST => new Element(By.XPath("//label[contains(text(),'not involved at all in the manufacturing process?')]"));
        public static Element MFProcessYesCTA => new Element(By.XPath("//label[contains(text(),'not involved at all in the manufacturing process?')]//following::button[1]"));
        public static Element MFProcessNoCTA => new Element(By.XPath("//label[contains(text(),'not involved at all in the manufacturing process?')]//following::button[2]"));
        public static Element StufInvolvedMFProcessAmount => new Element(By.XPath("//input[@id='cc_8742_Payroll']"));

        // Are there any delivery drivers on staff? 
        public static Element DeliveryDriversStaffQST => new Element(By.XPath("//label[contains(text(),'are there any delivery drivers on staff')]"));
        public static Element DeliverDriversStaffYesCTA => new Element(By.XPath("//label[contains(text(),'are there any delivery drivers on staff')]//following::button[1]"));
        public static Element DeliverDriversStaffNoCTA => new Element(By.XPath("//label[contains(text(),'are there any delivery drivers on staff')]//following::button[2]"));
        public static Element DeliveryDriversStaffAmount => new Element(By.XPath("//input[@id='cc_7380_Payroll']"));

        //Do any employees only do general office work and rarely travel?
        public static Element EmployeeTravelQST => new Element(By.XPath("//label[contains(text(),'do any employees only do general office work and rarely travel')]"));
        public static Element EmployeeTravelYesCTA => new Element(By.XPath("//label[contains(text(),'do any employees only do general office work and rarely travel')]//following::button[1]"));
        public static Element EmployeeTravelNoCTA => new Element(By.XPath("//label[contains(text(),'do any employees only do general office work and rarely travel')]//following::button[2]"));
        public static Element EmployeeTravelAmount => new Element(By.XPath("//label[contains(text(), 'Enter their total annual payroll')]//following::input[contains(@id,'_Payroll')]"));

        //laundry questions
        public static Element laundryServicesQST => new Element(By.XPath("//label[contains(text(),'do you offer contract laundry services to businesses?')]"));
        public static Element laundryServicesYesCTA => new Element(By.XPath("//label[contains(text(),'do you offer contract laundry services to businesses?')]//following::button[1]"));
        public static Element laundryServicesNoCTA => new Element(By.XPath("//label[contains(text(),'do you offer contract laundry services to businesses?')]//following::button[2]"));

        // Does your business have a state-issued experience modification factor (XMOD)?
        public static Element XMODQST => new Element(By.XPath("//label[contains(text(),'XMOD')]"));
        public static Element XMODYesCTA => new Element(By.XPath("//label[contains(text(),'XMOD')]//following::button[1]"));
        public static Element XMODNoCTA => new Element(By.XPath("//label[contains(text(),'XMOD')]//following::button[2]"));
        public static Element XMODDontKnowCTA => new Element(By.XPath("//label[contains(text(),'XMOD')]//following::button[3]"));
        public static Element TitleEnterValueForExperienceXMOD => new Element(By.XPath("//label[contains(text(),'enter the value for experience modification factor')]"));
        public static Element XMODInput => new Element(By.XPath("//input[@id='XModValue']"));

        // Do you have a written lockout/tagout procedure in place?
        public static Element LockoutTagoutInPlaceQST => new Element(By.XPath("//label[contains(text(),'lockout/tagout procedure in place?')]"));
        public static Element LockoutTagoutInPlaceYesCTA => new Element(By.XPath("//label[contains(text(),'lockout/tagout procedure in place?')]//following::button[1]"));
        public static Element LockoutTagoutInPlaceNoCTA => new Element(By.XPath("//label[contains(text(),'lockout/tagout procedure in place?')]//following::button[2]"));

        //Do your employees deliver any of your finished product?
        public static Element DeliverFinishedProductQST => new Element(By.XPath("//label[contains(text(),'finished product')]"));
        // Dropdown - Do your employees deliver any of your finished product?
        public static Element DeliverFinishedProductDD => new Element(By.XPath("//select[@id='uq383']"));
        public static Element ValueForExperienceXMODInput => new Element(By.XPath("//input[@id='XModValue']"));

        // Are any employees required to physically lift/move more than 50 lbs?
        public static Element EmpLiftMoreThan50QST => new Element(By.XPath("//label[contains(text(),'physically lift/move more than 50 lbs')]"));
        public static Element EmpLiftMoreThan50YesCTA => new Element(By.XPath("//label[contains(text(),'physically lift/move more than 50 lbs')]//following::button[1]"));
        public static Element EmpLiftMoreThan50NoCTA => new Element(By.XPath("//label[contains(text(),'physically lift/move more than 50 lbs')]//following::button[2]"));

        // Do any employees do any maintenance, repair, or service on motor vehicles?
        public static Element ServiceOrDMVQST => new Element(By.XPath("//label[contains(text(),'maintenance, repair')]"));
        public static Element ServiceOrDMVYesCTA => new Element(By.XPath("//label[contains(text(),'maintenance, repair')]//following::button[1]"));
        public static Element ServiceOrDMVNoCTA => new Element(By.XPath("//label[contains(text(),'maintenance, repair')]//following::button[2]"));
        public static Element ServiceOrDMVAmount => new Element(By.XPath("//input[@id='cc_8385_Payroll']"));

        // How many vehicles do you own that are operated by employees?
        public static Element HowManyVehiclesOprtByEmpQST => new Element(By.XPath("//label[contains(text(),'how many vehicles')]"));
        public static Element HowManyVehiclesOprtByEmpAmount => new Element(By.XPath("//input[@id='uq371']"));

        // Do you lease or rent out any vehicles to any non-employees?
        public static Element LeaseOrRentNonEmpQST => new Element(By.XPath("//label[contains(text(),'rent out any vehicles to any non-employees?')]"));
        public static Element LeaseOrRentNonEmpYes => new Element(By.XPath("//label[contains(text(),'rent out any vehicles to any non-employees?')]//following::button[1]"));
        public static Element LeaseOrRentNonEmpNo => new Element(By.XPath("//label[contains(text(),'rent out any vehicles to any non-employees?')]//following::button[2]"));

        // Do you pay any drivers via 1099 that use their own vehicle? 
        public static Element Via1099QST => new Element(By.XPath("//label[contains(text(),'1099')]"));
        public static Element Via1099YesCTA => new Element(By.XPath("//label[contains(text(),'1099')]//following::button[1]"));
        public static Element Via1099NoCTA => new Element(By.XPath("//label[contains(text(),'1099')]//following::button[2]"));

        // Do any employees only do general office work and do not work a cash register?
        public static Element RegisterCashQST => new Element(By.XPath("//label[contains(text(),'do any employees only do general office work and do not work a cash register?')]"));
        public static Element RegisterCashYesCTA => new Element(By.XPath("//label[contains(text(),'do any employees only do general office work and do not work a cash register?')]//following::button[1]"));
        public static Element RegisterCashNoCTA => new Element(By.XPath("//label[contains(text(),'do any employees only do general office work and do not work a cash register?')]//following::button[2]"));
        // Enter their total annual payroll 
        public static Element RegisterCashTAPQST => new Element(By.XPath("//label[contains(text(), 'Enter their total annual payroll')]"));
        public static Element RegisterCashTAP => new Element(By.XPath("//label[contains(text(),'do any employees only do general office work and do not work a cash register')]//following::input[2]"));

        public static Element generalOfficeWorkTravelYes => new Element(By.XPath("//input[@id='cc_8810']//following::button[1]"));

        public static Element generalOfficeWorkTravelNo => new Element(By.XPath("//input[@id='cc_8810']//following::button[2]"));

        // What percentage of your overall sales involve delivery?
        public static Element SalesInvolveDeliveryQST => new Element(By.XPath("//label[contains(text(),'sales involve delivery')]"));
        public static Element PercentageSalesInvolveDelivery => new Element(By.XPath("//input[@id='uq9']"));
        public static Element PlusCTASalesInvolveDelivery => new Element(By.XPath("//input[@id='uq9']//following-sibling::button"));
        public static Element MinusCTASalesInvolveDelivery => new Element(By.XPath("//input[@id='uq9']//preceding-sibling::button"));


        // Do you currently have a Workers Compensation insurance policy in effect?
        public static Element WCInsurancePolicyInEffectQst => new Element(By.XPath("//label[contains(text(),'policy in effect')]"));
        public static Element WCInsurancePolicyInEffectYes => new Element(By.XPath("//input[@id='uq225']//following::button[1]"));
        public static Element WCInsurancePolicyInEffectNo => new Element(By.XPath("//input[@id='uq225']//following::button[2]"));
        public static Element WhenWasYourPolicyInEffectDD => new Element(By.XPath("//select[@id='uq226']"));
        // Enter their total annual payroll 
        public static Element RegisterCashTTLAnnualPayroll => new Element(By.XPath("//input[@id='cc_8810_Payroll']"));

        // Do you use any volunteers or donated labor?
        public static Element VolunteersOrDonatedQST => new Element(By.XPath("//label[contains(text(),'donated labor')]"));
        public static Element VolunteersOrDonatedYesCTA => new Element(By.XPath("//label[contains(text(),'donated labor')]//following::button[1]"));
        public static Element VolunteersOrDonatedNoCTA => new Element(By.XPath("//label[contains(text(),'donated labor')]//following::button[2]"));
        // What percentage of workers are volunteers or donated labor?
        public static Element VolunteersOrDonatedMinusCTA => new Element(By.XPath("//input[@id='uq207']//preceding-sibling::button"));
        public static Element VolunteersOrDonatedPlusCTA => new Element(By.XPath("//input[@id='uq207']//following-sibling::button"));

        // Question - Percentage - What percentage of workers are volunteers or donated labor?
        public static Element PercentageOfWorkersAreVolunteersOrDonatedLaborQST => new Element(By.XPath("//label[contains(text(),'what percentage of workers')]"));

        // Input - What percentage of workers are volunteers or donated labor?
        public static Element VolunteersOrDonatedInput => new Element(By.XPath("//input[@id='uq207']"));

        // Has there been any worker injuries or accidents since the last policy was in effect?
        public static Element HasThereBeenWorkersInjuriesQST => new Element(By.XPath("//label[contains(text(),'has there been any worker injuries')]"));
        //public static Element HasThereBeenWorkersInjuriesDD => new Element(By.XPath("//select[@id='uq258']"));
        public static Element HasThereBeenWorkersInjuriesDD => new Element(By.XPath("//option[contains(text(),'Yes there has been injuries or accidents')]//parent::select"));
        
        public static Element WorkersInjuriesYes => new Element(By.XPath("//option[contains(text(),'Yes there has been injuries or accidents')]"));
        public static Element WorkersInjuriesNo => new Element(By.XPath("//option[contains(text(),'No to the best of my knowledge')]"));


        // Fence Contractor.......................................................................................................//
        // Are there owners/officers that do not do any actual physical work but travel to job sites?
        public static Element OwnersOfficersPhysicalWorkTravelToJobSitesQST => new Element(By.XPath("//label[contains(text(),'owners/officers that do not do any actual physical work but travel to job sites')]"));
        public static Element OwnersOfficersPhysicalWorkTravelToJobSitesDD => new Element(By.XPath("//label[contains(text(),'owners/officers that do not do any actual physical work but travel to job sites')]//following::select[1]"));

        // Concrete worker No Pour......................................................................................................./
        // Do you ever transport six or more workers in the same vehicle?
        public static Element SixOrMoreWorkersQST => new Element(By.XPath("//label[contains(text(),'six or more')]"));
        public static Element SixOrMoreWorkersYes => new Element(By.XPath("//input[@id='uq242']//following::button[1]"));
        public static Element SixOrMoreWorkersNo => new Element(By.XPath("//input[@id='uq242']//following::button[2]"));

        // Do you use any subcontractors or pay any workers using IRS Form 1099?
        public static Element IRSFormQST => new Element(By.XPath("//label[contains(text(),'IRS Form')]"));
        public static Element IRSFormYes => new Element(By.XPath("//label[contains(text(),'IRS Form')]//following::button[1]"));
        public static Element IRSFormNo => new Element(By.XPath("//label[contains(text(),'IRS Form')]//following::button[2]"));
        // Question - Do you require all subcontractors/1099 workers to have certificates of insurance?
        public static Element RequireAllSubcontractorQST => new Element(By.XPath("//label[contains(text(),'require all subcontractors/1099')]"));
        public static Element RequireAllSubcontractorDD => new Element(By.XPath("//select[@id='uq448']"));


        // Do you perform any work in excess of 5 feet underground or 30 feet above ground? 
        public static Element WorkEcessFeetQST => new Element(By.XPath("//label[contains(text(),'work in excess')]"));
        public static Element WorkEcessFeetYes => new Element(By.XPath("(//label[contains(text(),'work in excess')]//following::button)[2]"));
        public static Element WorkEcessFeetNo => new Element(By.XPath("(//label[contains(text(),'work in excess')]//following::button)[3]"));
        // Question - What is the max depth in feet you work underground?
        public static Element MaxDepthInFeetYouWorkUnderGroundQST => new Element(By.XPath("//label[contains(text(),'max depth in feet')]"));
        public static Element MaxDepthInFeetYouWorkUnderGroundInput => new Element(By.XPath("//input[@id='uq356']"));
        // Question - What is the max height in feet you work above ground level
        public static Element MaxHeightInFeetYouWorkAboveGroundQST => new Element(By.XPath("//label[contains(text(),'max depth in feet')]"));
        public static Element MaxHeightInFeetYouWorkAboveGroundInput => new Element(By.XPath("//input[@id='uq355']"));



        // Do you do any demolition or wrecking of entire buildings or homes? 
        public static Element DemolitionOrWreckingQST => new Element(By.XPath("//label[contains(text(),'demolition or wrecking')]"));
        public static Element DemolitionOrWreckingYes => new Element(By.XPath("//label[contains(text(),'demolition or wrecking')]//following::button[1]"));
        public static Element DemolitionOrWreckingNO => new Element(By.XPath("//label[contains(text(),'demolition or wrecking')]//following::button[2]"));

        // Does any work involve the handling of barbed wire?
        public static Element BarbedWireQST => new Element(By.XPath("//label[contains(text(),'barbed')]"));
        public static Element BarbedWireYes => new Element(By.XPath("//label[contains(text(),'barbed')]//following::button[1]"));
        public static Element BarbedWireNo => new Element(By.XPath("//label[contains(text(),'barbed')]//following::button[2]"));
        //...............................................................................................................................................

        // Bagel Shop: Retail....................................................................................................
        // Question - Do any employees only work at a retail store where no baking is done on premises? 
        public static Element BakingIsDoneQST => new Element(By.XPath("//label[contains(text(),'baking is done on premises')]"));
        // Yes - Do any employees only work at a retail store where no baking is done on premises? 
        public static Element BakingIsDoneYes => new Element(By.XPath("//input[@id='cc_8017']//following::button[text()='yes'][1]"));
        // No - Do any employees only work at a retail store where no baking is done on premises? 
        public static Element BakingIsDoneNo => new Element(By.XPath("//input[@id='cc_8017']//following::button[text()='no'][1]"));
        // Enter their total annual payroll - Do any employees only work at a retail store where no baking is done on premises?
        public static Element PayrollBakingIsDoneYes => new Element(By.XPath("//input[@id='cc_8017_Payroll']"));
        // Question - Do any included owners/officers only do general office work and do not work a cash register? 
        public static Element IncludedOwnerOfficerDoNOtWorkCashRegisterQST => new Element(By.XPath("//label[contains(text(),'owners/officers only do general office work and do not work a cash register')]"));
        // Dropdown Options - Do any included owners/officers only do general office work and do not work a cash register?
        public static Element IncludedOwnerOfficerDoNOtWorkCashRegisterDD => new Element(By.XPath("//select[@id='oocc_8810']"));
        // Bagel Shop: Retail....................................................................................................

        // Electrical Work ------------------------------------------------------------------------------------------------------
        // Question - What is the maximum voltage that you are exposed to?
        public static Element MaxVoltageQST => new Element(By.XPath("//label[contains(text(),'maximum voltage')]"));
        // Field - What is the maximum voltage that you are exposed to?
        public static Element MaxVoltageField => new Element(By.XPath("//input[@id='uq53']"));
        // Question - Do you climb on any utility poles?
        public static Element ClimbOnUtilityPolesQST => new Element(By.XPath("//label[contains(text(),'utility poles')]"));
        // Option Yes - Do you climb on any utility poles?
        public static Element ClimbOnUtilityPolesYes => new Element(By.XPath("//input[@id='uq401']//following::button[text()='yes'][1]"));
        // Option No - Do you climb on any utility poles?
        public static Element ClimbOnUtilityPolesNo => new Element(By.XPath("//input[@id='uq401']//following::button[text()='yes'][1]"));
        // Question - Are you engaged in any solar panel work?
        public static Element SolarPanelQST => new Element(By.XPath("//label[contains(text(),'solar')]"));
        // Option Yes - Are you engaged in any solar panel work?
        public static Element SolarPanelYesCTA => new Element(By.XPath("//input[@id='uq120']//following::button[text()='yes'][1]"));
        // Option No - Are you engaged in any solar panel work?
        public static Element SolarPanelNoCTA => new Element(By.XPath("//input[@id='uq120']//following::button[text()='no'][1]"));


        // Yoga Studio----------------------------------------------------------------------------------------------------------------
        // Question - Do you offer any live fun such as archery or axes, batting cages, driving ranges, or ice skating?
        public static Element YogaLiveFunQST => new Element(By.XPath("//label[contains(text(),'live fun')]"));
        public static Element YogaLiveFunYes => new Element(By.XPath("//input[@id='uq348']//following::button[1]"));
        public static Element YogaLiveFunNo => new Element(By.XPath("//input[@id='uq348']//following::button[2]"));

        // Question - Do you provide any boxing, martial arts, climbing, or gymnastics training/classes?
        public static Element TrainingQST => new Element(By.XPath("//label[contains(text(),'training')]"));
        public static Element TrainingYes => new Element(By.XPath("//input[@id='uq163']//following::button[1]"));
        public static Element TrainingNo => new Element(By.XPath("//input[@id='uq163']//following::button[2]"));

        // Question - Do you pay any class instructors or personal trainers using 1099s?
        public static Element InstructorsTrainers1099QST => new Element(By.XPath("//label[contains(text(),'class instructors or personal trainers using 1099')]"));
        public static Element InstructorsTrainers1099Yes => new Element(By.XPath("//input[@id='uq164']//following::button[1]"));
        public static Element InstructorsTrainers1099No => new Element(By.XPath("//input[@id='uq164']//following::button[2]"));

        // Question - Do you make any payments to workers using IRS Form 1099?
        public static Element DoYouMakeAnyPaymentsToWorkersUsingIRSFormQST => new Element(By.XPath("//label[contains(text(),'IRS Form 1099')]"));
        public static Element DoYouMakeAnyPaymentsToWorkersUsingIRSFormYes => new Element(By.XPath("(//label[contains(text(),'IRS Form 1099')]//following::button[text()='yes'])[1]"));
        public static Element DoYouMakeAnyPaymentsToWorkersUsingIRSFormNo => new Element(By.XPath("(//label[contains(text(),'IRS Form 1099')]//following::button[text()='no'])[1]"));
        // Do you require all workers paid with 1099 to have certificates of insurance? 
        public static Element PaidWith1099HaveCertificatesOfInsuranceQST => new Element(By.XPath("//label[contains(text(),'paid with 1099 to have certificates of insurance')]"));
        public static Element PaidWith1099HaveCertificatesOfInsuranceDD => new Element(By.XPath("//label[contains(text(),'paid with 1099 to have certificates of insurance')]//following::select[1]"));
        // What percentage of workers are paid with 1099?
        public static Element PercentageOfWorkersArePaidWith1099QST => new Element(By.XPath("//label[contains(text(),'workers are paid with 1099')]"));
        public static Element PercentageOfWorkersArePaidWith1099DD => new Element(By.XPath("//label[contains(text(),'workers are paid with 1099')]//following::select[1]"));
        // What is the total annual pay estimate to workers with 1099?
        public static Element TTLAnnualPayEstimate1099QST => new Element(By.XPath("//label[contains(text(),'What is the total annual pay')]"));
        public static Element TTLAnnualPayEstimate1099Input => new Element(By.XPath("//label[contains(text(),'what is the total annual pay')]//following::input[1]"));

        // Comedy Club ----------------------------------------------------------------------------------------------------------------------
        // Question - Are any owners/officers actors, entertainers, or musicians? 
        public static Element OwnerOfficerActorsMusiciansQST => new Element(By.XPath("//label[contains(text(),'entertainers')]"));
        // Dropdown - Are any owners/officers actors, entertainers, or musicians? 
        public static Element OwnerOfficerActorsMusiciansDD => new Element(By.XPath("//select[@id='oocc_9156']"));

        // Question -  Do you use pyrotechnics?
        public static Element PyrotechnicsQST => new Element(By.XPath("//label[contains(text(),'pyrotechnics')]"));
        public static Element PyrotechnicsYes => new Element(By.XPath("//input[@id='uq567']//following::button[1]"));
        public static Element PyrotechnicsNo => new Element(By.XPath("//input[@id='uq567']//following::button[2]"));

        // Questions - Do you perform acts with knives, other sharp objects, fire, or live ammunition?
        public static Element SharpObjectsQST => new Element(By.XPath("//label[contains(text(),'sharp objects')]"));
        public static Element SharpObjectsYes => new Element(By.XPath("//input[@id='uq569']//following::button[1]"));
        public static Element SharpObjectsNo => new Element(By.XPath("//input[@id='uq569']//following::button[2]"));

        // Question - Do you do any work higher than 30 feet above ground?
        public static Element WorkHigerThan30FeetQST => new Element(By.XPath("//label[contains(text(),'higher than 30')]"));
        public static Element WorkHigerThan30FeetYes => new Element(By.XPath("//input[@id='uq208']//following::button[1]"));
        public static Element WorkHigerThan30FeetNo => new Element(By.XPath("//input[@id='uq208']//following::button[2]"));

        // Question - Do you help set up furniture or install any sound/lighting at events?
        public static Element SetUpFurnitureQST => new Element(By.XPath("//label[contains(text(),'furniture')]"));
        public static Element SetUpFurnitureYes => new Element(By.XPath("//input[@id='uq151']//following::button[1]"));
        public static Element SetUpFurnitureNo => new Element(By.XPath("//input[@id='uq151']//following::button[2]"));

        // Question - Do you work with lions, tigers, leopards, bears, elephants, or venomous reptiles?
        public static Element VenomusQST => new Element(By.XPath("//label[contains(text(),'venomous')]"));
        public static Element VenomusYes => new Element(By.XPath("//input[@id='uq572']//following::button[1]"));
        public static Element VenomusNo => new Element(By.XPath("//input[@id='uq572']//following::button[2]"));

        // What is the total annual pay to 1099 workers?
        public static Element ComedyClubTTLAnnualPayTo1099WorkersQST => new Element(By.XPath("//label[text()='what is the total annual pay to 1099 workers?']"));
        public static Element ComedyClubTTLAnnualPayTo1099WorkersAnnualPay => new Element(By.XPath("//input[@id='uq615']"));


        // HotTubOrSpaStore_Retail -------------------------------------------------------------------------------------------------
        // Question - Do you do any work lower than 10 feet below ground?
        public static Element WorkLowerThan10FeetBelow => new Element(By.XPath("//label[contains(text(),'10 feet below')]"));
        // Yes CTA - Do you do any work lower than 10 feet below ground?
        public static Element WorkLowerThan10FeetBelowYesCTA => new Element(By.XPath("//input[@id='uq209']//following::button[1]"));
        // No CTA - Do you do any work lower than 10 feet below ground?
        public static Element WorkLowerThan10FeetBelowNoCTA => new Element(By.XPath("//input[@id='uq209']//following::button[2]"));

        // Country Club --------------------------------------------------------------------------------------------------------------
        // Question - Do you want to buy coverage for the business owners?
        public static Element DoYouWantCoverageForBusOwnersQST => new Element(By.XPath("//label[contains(text(),'buy coverage')]"));
        // Dropdown - Do you want to buy coverage for the business owners?
        public static Element DoYouWantCoverageForBusOwnersDD => new Element(By.XPath("//select[@id='BusinessOwnersYN']"));
        // Question - How many owners/officers are there?
        public static Element HowManyOwnersOfficersAreThereQST => new Element(By.XPath("//label[contains(text(),'how many owners')]"));
        // Dropdown - How many owners/officers are there?
        public static Element HowManyOwnersOfficersAreThereDD => new Element(By.XPath("//select[@id='BusinessOwners']"));


        // Nutritionist -------------------------------------------------------------------------------------------------------------
        // Question - Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? 
        public static Element EmergencyResponseQST => new Element(By.XPath("//label[contains(text(),'emergency response')]"));
        // Yes CTA - Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? 
        public static Element EmergencyResponseYesCTA => new Element(By.XPath("//input[@id='uq651']//following::button[1]"));
        // No CTA - Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? 
        public static Element EmergencyResponseNoCTA => new Element(By.XPath("//input[@id='uq651']//following::button[2]"));

        // Flower Arrangements ------------------------------------------------------------------------------------------------------
        public static Element OnlyDoGeneralOfficeWorkDoNotWorkCashRegNoCTA => new Element(By.XPath("//input[@id='cc_8810']//following::button[2]"));
        public static Element OnlyDoGeneralOfficeWorkDoNotWorkCashRegYesCTA => new Element(By.XPath("//input[@id='cc_8810']//following::button[1]"));

        // Enter their total annual payroll - Are there any delivery drivers on staff (includes bicycles)? 
        public static Element DeliveryStaffIncludedBcycTTLAnnualPayroll => new Element(By.XPath("//input[@id='cc_7380_Payroll']"));
        // Bar and Grill ------------------------------------------------------------------------------------------------------
        // Question - Are there any delivery drivers on staff (includes bicycles)? 
        public static Element DeliveryStaffIncludedBcycQST => new Element(By.XPath("//label[contains(text(),'delivery drivers on staff')]"));
        // Yes CTA - Are there any delivery drivers on staff (includes bicycles)?
        public static Element DeliveryStaffIncludedBcycYesCTA => new Element(By.XPath("//input[@id='cc_7380']//following::button[1]"));
        // No CTA - Are there any delivery drivers on staff (includes bicycles)?
        public static Element DeliveryStaffIncludedBcycNoCTA => new Element(By.XPath("//input[@id='cc_7380']//following::button[2]"));

        // Question - What percentage of your overall sales involve alcohol?
        public static Element OverallSalesInvolveAlcoholQST => new Element(By.XPath("//label[contains(text(),'involve alcohol')]"));
        // Input percentage - What percentage of your overall sales involve alcohol?
        public static Element OverallSalesInvolveAlcoholInput => new Element(By.XPath("//input[@id='uq410']"));

        // Question - What percentage of your overall sales involve off-premises catering, lunch wagons, or food trucks?
        public static Element OffPremisesCateringQST => new Element(By.XPath("//label[contains(text(),'off-premises')]"));
        // Input - What percentage of your overall sales involve off-premises catering, lunch wagons, or food trucks?
        public static Element OffPremisesCateringInput => new Element(By.XPath("//input[@id='uq8']"));

        // Question - What percentage of your overall sales involve delivery?
        public static Element PercentageOfYourOverallSalesInvolveDeliveryQST => new Element(By.XPath("//label[contains(text(),'what percentage of your overall sales involve delivery?')]"));
        // Input - What percentage of your overall sales involve delivery?
        public static Element PercentageOfYourOverallSalesInvolveDeliveryInput => new Element(By.XPath("//input[@id='uq9']"));

        // Question - Do you use bouncers or security guards?
        public static Element UseBouncersSecurityGuardsQST => new Element(By.XPath("//label[contains(text(),'security')]"));
        // Dropdown - Do you use bouncers or security guards?
        public static Element UseBouncersSecurityGuardsDD => new Element(By.XPath("//select[@id='uq365']"));

        // Question - Are you open after 2 A.M.?
        public static Element OpenAfter2PMQST => new Element(By.XPath("//label[contains(text(),'are you open after 2 A.M.?')]"));
        // Yes CTA - Are you open after 2 A.M.?
        public static Element OpenAfter2PMYesCTA => new Element(By.XPath("//input[@id='uq126']//following::button[1]"));
        // No CTA - Are you open after 2 A.M.?
        public static Element OpenAfter2PMNoCTA => new Element(By.XPath("//input[@id='uq126']//following::button[2]"));

        // Masonry Contractor ------------------------------------------------------------------------------------------------------
        // Qusetion - Do any employee contractors make at least $28/hr?
        public static Element Contractorsmake28QST => new Element(By.XPath("//label[contains(text(),'28/hr')]"));
        // Yes CTA - Do any employee contractors make at least $28/hr?
        public static Element Contractorsmake28YesCTA => new Element(By.XPath("//input[@id='cc_5028']//following::button[1]"));
        // No CTA - Do any employee contractors make at least $28/hr?
        public static Element Contractorsmake28NoCTA => new Element(By.XPath("//input[@id='cc_5028']//following::button[2]"));
        public static Element Contractorsmake28NoPayrollAmount => new Element(By.XPath("//input[@id='cc_5028']//following::input[1]"));

        // Question - Are there employees that do not do any actual physical work but travel to job sites? 
        public static Element DoNotDoPhysicalWorkTravelJobSitesQST => new Element(By.XPath("//label[contains(text(),'employees that do not do any actual physical work but travel to job sites')]"));
        // Yes CTA - Are there employees that do not do any actual physical work but travel to job sites?
        public static Element DoNotDoPhysicalWorkTravelJobSitesYesCTA => new Element(By.XPath("//label[contains(text(),'employees that do not do any actual physical work but travel to job sites')]//following::button[1]"));
        // No CTA - Are there employees that do not do any actual physical work but travel to job sites?
        public static Element DoNotDoPhysicalWorkTravelJobSitesNoCTA => new Element(By.XPath("//label[contains(text(),'employees that do not do any actual physical work but travel to job sites')]//following::button[2]"));
        public static Element DoNotDoPhysicalWorkTravelJobSitesAnnualPayroll => new Element(By.XPath("//label[contains(text(),'employees that do not do any actual physical work but travel to job sites')]//following::input[1]"));

        // Quetion - Are you engaged in any chimney work?
        public static Element EngagedChimneyWorkQST => new Element(By.XPath("//label[contains(text(),'chimney')]"));
        // Yes CTA - Are you engaged in any chimney work?
        public static Element EngagedChimneyWorkYesCTA => new Element(By.XPath("//input[@id='uq134']//following::button[1]"));
        // No CTA - Are you engaged in any chimney work?
        public static Element EngagedChimneyWorkNoCTA => new Element(By.XPath("//input[@id='uq134']//following::button[2]"));

        // Siding Intallation ------------------------------------------------------------------------------------------------
        // What percentage of work done is water damage, fire damage, or mold restoration?
        public static Element WaterFireDamageQST => new Element(By.XPath("//label[contains(text(),'water damage')]"));
        // Input - What percentage of work done is water damage, fire damage, or mold restoration?
        public static Element WaterFireDamageInput => new Element(By.XPath("//input[@id='uq197']"));
        // Question - What percentage of work done is framing (rough carpentry)?
        public static Element WorkDoneIsFramingQST => new Element(By.XPath("//label[contains(text(),'framing')]"));
        // Input - What percentage of work done is framing (rough carpentry)?
        public static Element WorkDoneIsFramingInput => new Element(By.XPath("//input[@id='uq219']"));
        // Question - Do you do roofing work?
        public static Element RoofingWorkQST => new Element(By.XPath("//label[contains(text(),'roofing')]"));
        // Yes - Do you do roofing work?
        public static Element RoofingWorkYesCTA => new Element(By.XPath("//input[@id='uq629']//following::button[1]"));
        // No - Do you do roofing work?
        public static Element RoofingWorkNoCTA => new Element(By.XPath("//input[@id='uq629']//following::button[2]"));

        // Concrete Walls ------------------------------------------------------------------------------------------------
        public static Element loadBearingConcreteWallsYesCTA => new Element(By.XPath("//input[@id='uq399']//following::button[1]"));
        public static Element loadBearingConcreteWallsNoCTA => new Element(By.XPath("//input[@id='uq399']//following::button[2]"));

        public static Element masonryWorkSuchAsManualBrickYesCTA => new Element(By.XPath("//input[@id='uq409']//following::button[1]"));
        public static Element masonryWorkSuchAsManualBrickNoCTA => new Element(By.XPath("//input[@id='uq409']//following::button[2]"));

        public static Element residentialFoundationYesCTA => new Element(By.XPath("//input[@id='uq630']//following::button[1]"));
        public static Element residentialFoundationNoCTA => new Element(By.XPath("//input[@id='uq630']//following::button[2]"));


        // Family Medicine-----------------------------------------------------------------------------------------------------------
        // Qusetion - What type of care do you provide?
        public static Element TypeOfCareQST => new Element(By.XPath("//label[contains(text(),'type of care')]"));
        // Dropdown - What type of care do you provide?
        public static Element TypeOfCareDD => new Element(By.XPath("//select[@id='uq341']"));
        // Question - Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters?
        public static Element EmergencyResponseWorkersQST => new Element(By.XPath("//label[contains(text(),'emergency')]"));
        // Yes - Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters?
        public static Element EmergencyResponseWorkersYesCTA => new Element(By.XPath("//input[@id='uq651']//following::button[1]"));
        // NO - Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters?
        public static Element EmergencyResponseWorkersNoCTA => new Element(By.XPath("//input[@id='uq651']//following::button[2]"));
        // Insured first name and last name
        public static Element InsuredFirstNameQST => new Element(By.XPath("//label[contains(text(),'insured first name')]"));
        public static Element InsuredLastNameQST => new Element(By.XPath("//label[contains(text(),'insured last name')]"));
        // Input  - Insured first name and last name
        public static Element InsuredFirstNameInput => new Element(By.XPath("//input[@id='InsuredFirstName']"));
        public static Element InsuredLastNameInput => new Element(By.XPath("//input[@id='InsuredLastName']"));

        // Are any owners/officers actors, entertainers, or musicians? 
        public static Element getownersOfficersActorsEntOrMusician(string textSelect)
        {
            return new Element(By.XPath("//select[@id='oocc_9156']//child::option['" + textSelect + "']"));
        }
        // Do any owners/officers only do general office work and rarely travel
        public static Element getDoGeneralOfficeWorkButTravelDD(string index)
        {
            return new Element(By.XPath("//select[@id='oocc_8810']//child::option['" + index + "']"));
        }

        // Do you review MVRs for all employees with a driving exposure? 
        public static Element ReviewMVRQST => new Element(By.XPath("//label[contains(text(),'do you review MVRs for all employees with a driving exposure?')]"));
        // Dopdown - Do you review MVRs for all employees with a driving exposure? 
        public static Element ReviewMVRDD => new Element(By.XPath("//select[@id='uq265']"));
        /// <summary>
        /// Do you review MVRs for all employees with a driving exposure? DD data
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Element getReviewMVR(string index)
        {
            return new Element(By.XPath("//select[@id='uq265']//child::option['" + index + "']"));
        }

        //What is the maximum number of miles your employees travel as part of their job duties? 
        public static Element MaxNumberOfMilesEmployeesTravelQST => new Element(By.XPath("//label[text()='what is the maximum number of miles your employees travel as part of their job duties?']"));
        public static Element MaxNumberOfMilesEmployeesTravelTextBox => new Element(By.XPath("//label[text()='what is the maximum number of miles your employees travel as part of their job duties?']//following::input[@type='number']"));

        // Do drivers assist any handicapped passengers with entering or exiting the vehicle?
        public static Element AssistHandicappedPassengersQST => new Element(By.XPath("//label[text()='do drivers assist any handicapped passengers with entering or exiting the vehicle?']"));
        public static Element AssistHandicappedPassengersYes => new Element(By.XPath("//label[text()='do drivers assist any handicapped passengers with entering or exiting the vehicle?']//following::button[1]"));
        public static Element AssistHandicappedPassengersNo => new Element(By.XPath("//label[text()='do drivers assist any handicapped passengers with entering or exiting the vehicle?']//following::button[2]"));

        // // Are your employees engaged in the unloading/loading of any passenger luggage?
        public static Element UnloadingLoadingOfPassengerLuggageQST => new Element(By.XPath("//label[text()='are your employees engaged in the unloading/loading of any passenger luggage?']"));
        public static Element UnloadingLoadingOfPassengerLuggageYes => new Element(By.XPath("//label[text()='are your employees engaged in the unloading/loading of any passenger luggage?']//following::button[1]"));
        public static Element UnloadingLoadingOfPassengerLuggageNo => new Element(By.XPath("//label[text()='are your employees engaged in the unloading/loading of any passenger luggage?']//following::button[2]"));
        //Do you mainly transport customers to, from, or within an airport such as a shuttle service?
        public static Element TransportCustomersAirportLikeShuttleServiceQST => new Element(By.XPath("//label[text()='do you mainly transport customers to, from, or within an airport such as a shuttle service?']"));
        public static Element TransportCustomersAirportLikeShuttleServiceYes => new Element(By.XPath("//label[text()='do you mainly transport customers to, from, or within an airport such as a shuttle service?']//following::button[1]"));
        public static Element TransportCustomersAirportLikeShuttleServiceNo => new Element(By.XPath("//label[text()='do you mainly transport customers to, from, or within an airport such as a shuttle service?']//following::button[2]"));


        // Do any owners/officers travel for sales and are not involved in the manufacturing process? 
        public static Element getTravelForSales(string option1)
        {
            return new Element(By.XPath("//label[contains(text(),'are not involved in the manufacturing process')]//following::option['" + option1 + "']"));
        }

        // Question: Do your employees deliver any of your finished product?
        public static Element getFinishedProductOption(string finishedProduct)
        {
            return new Element(By.XPath("//option[contains(text(),'" + finishedProduct + "')]"));
        }

        // When was your last policy in effect?
        public static Element getLastPolicyInEffect(string lastPolicyInEffect)
        {
            return new Element(By.XPath("//option[contains(text(),'" + lastPolicyInEffect + "')]"));
        }
        public static Element getCoverageForAnyOwnersOfficers(string coverageForAnyOwnersOfficers)
        {
            return new Element(By.XPath("//option[contains(text(),'" + coverageForAnyOwnersOfficers + "')]"));
        }

        // In the past 3 years how many Workers' Compensation claims were reported
        public static Element getpastThreeYearsClaimsReported(string claimsWereReported)
        {
            return new Element(By.XPath("//option[contains(text(),'" + claimsWereReported + "')]"));
        }

        // How is your business structured?
        public static Element getBusinessStructured(string busStrucOption)
        {
            return new Element(By.XPath("//option[contains(text(),'" + busStrucOption + "')]"));
        }

        // When did you start your business?
        public static Element getYearsBusinessOption(string yearOption)
        {
            return new Element(By.XPath("//option[contains(text(),'" + yearOption + "')]"));
        }

        // Pest Control --------------------------------------------------------------------------------------------------------
        public static Element pestControlLicenseQST => new Element(By.XPath("//label[text()='do you have a pest control license?']"));
        public static Element getPestControlLicenseYes => new Element(By.XPath("//label[text()='do you have a pest control license?']//following::button[1]"));
        public static Element getPestControlLicenseNo => new Element(By.XPath("//label[text()='do you have a pest control license?']//following::button[2]"));
        public static Element fumigateQST => new Element(By.XPath("//label[text()='do you fumigate?']"));
        public static Element getfumigateYes => new Element(By.XPath("//label[text()='do you fumigate?']//following::button[1]"));
        public static Element getfumigateNo => new Element(By.XPath("//label[text()='do you fumigate?']//following::button[2]"));

        // AutoParts Retail -------------------------------------------------------------------------------------------------------
        // Do any included owners/officers only do general office work never writing up repair estimates?
        public static Element ownerRepairEstQST => new Element(By.XPath("//label[text()='do any included owners/officers only do general office work never writing up repair estimates?']"));
        public static Element ownerRepairEst => new Element(By.XPath("//select[@id='oocc_8810']"));
        public static Element staffTravelDeliverQST => new Element(By.XPath("//label[text()='do you have any staff that travel to deliver parts to customers or transfer them between locations?']"));
        public static Element staffTravelDeliverYes => new Element(By.XPath("//label[text()='do you have any staff that travel to deliver parts to customers or transfer them between locations?']//following::button[1]"));
        public static Element staffTravelDeliverNo => new Element(By.XPath("//label[text()='do you have any staff that travel to deliver parts to customers or transfer them between locations?']//following::button[2]"));
        public static Element roadsideTowingQST => new Element(By.XPath("//label[text()='do you provide towing or roadside assistance?']"));
        public static Element roadsideTowingDD =>  new Element(By.XPath("//label[text()='do you provide towing or roadside assistance?']//following::select[@id='uq709']"));
        // Do you sell or service large commercial vehicles, motorcycles, or recreational vehicles?
        public static Element sellServiceRVsMotorcyclesQST => new Element(By.XPath("//label[text()='do you sell or service large commercial vehicles, motorcycles, or recreational vehicles?']"));
        public static Element sellServiceRVsMotorcyclesYes => new Element(By.XPath("//label[text()='do you sell or service large commercial vehicles, motorcycles, or recreational vehicles?']//following::button[1]"));
        public static Element sellServiceRVsMotorcyclesNo => new Element(By.XPath("//label[text()='do you sell or service large commercial vehicles, motorcycles, or recreational vehicles?']//following::button[2]"));
        // Do employees ever test drive large commercial vehicles, motorcycles, or recreational vehicles? 
        public static Element DoEmpsEverTestDriveLargeCommercialVehiclesQST => new Element(By.XPath("//label[contains(text(),'do employees ever test drive large commercial vehicles')]"));
        public static Element DoEmpsEverTestDriveLargeCommercialVehiclesYesCTA => new Element(By.XPath("//label[contains(text(),'do employees ever test drive large commercial vehicles')]//following::button[1]"));
        public static Element DoEmpsEverTestDriveLargeCommercialVehiclesNoCTA => new Element(By.XPath("//label[contains(text(),'do employees ever test drive large commercial vehicles')]//following::button[2]"));

        // Are there any included owners/officers that do not do any cleaning or maintenance work?
        public static Element CleaningOrMaintenanceWorkQST => new Element(By.XPath("//label[@data-qa='question_oocomp_are there any included owners/officers that do not do any cleaning or maintenance work?_label']"));
        public static Element CleaningOrMaintenanceWork => new Element(By.XPath("//select[@id='oocc_8810']"));

        // How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered.
        public static Element HowManyOwnLessThan10QST => new Element(By.XPath("//label[@data-qa='question_117_label']"));
        public static Element HowManyOwnLessThan10 => new Element(By.XPath("//bb-select[@data-qa='select_kickoff_questions_117']//select"));

        // Title - Federal Employer Identification Number (FEIN)
        public static Element FEINTitle => new Element(By.XPath("//input[@id='FEINType']//parent::label"));
        // FEIN - Input field
        public static Element FEINOrSSN => new Element(By.XPath("//input[@id='TaxId']"));
        // Title - Social Security Number (SSN)
        public static Element SSNTitle => new Element(By.XPath("//input[@value='S']//parent::label"));
        // SSN - Radio button
        public static Element SSNRadioButton => new Element(By.XPath("//input[@value='S']"));

        // More about XMOD - Manual Show
        public static Element MoreAboutXMODCTA => new Element(By.XPath("//a[contains(@href,'#XMod')]"));
        // Information - More about XMOD 
        public static Element MoreAboutXMODInfo => new Element(By.XPath("//p[contains(@id,'XMod')]"));
        // Less about XMOD
        public static Element LessAboutXMODCTA => new Element(By.XPath("//a[contains(@href,'#XMod')]"));

        //// More about XMOD - AutoShow
        //public static Element AutoShowMoreAboutXMODCTA => new Element(By.XPath("//a[@href='#XModAutoShow']"));
        //// Information - More about XMOD 
        //public static Element AutoShowMoreAboutXMODInfo => new Element(By.XPath("//p[@id='XModAutoShow']"));
        //// Less about XMOD
        //public static Element AutoShowLessAboutXMODCTA => new Element(By.XPath("//a[@href='#XModAutoShow']"));

        //  Window Treatment Installation --------------------------------------------------------------------------------------------
        // Question - Are any owners/officers cost estimators that wouldn't do any direct physical work? 
        public static Element CostEstimatorsQST => new Element(By.XPath("//label[contains(text(),'cost estimator')]"));
        // Dropdown - Are any owners/officers cost estimators that wouldn't do any direct physical work? 
        public static Element CostEstimatorsDD => new Element(By.XPath("//select[@id='oocc_8742']"));

        // Ecommerce --------------------------------------------------------------------------------------------
        // Question - Do any employees deliver or warehouse any goods or run a retail store?
        public static Element DeliverOrWarehouseQST => new Element(By.XPath("//label[contains(text(),'retail store')]"));
        // Yes CTA - Do any employees deliver or warehouse any goods or run a retail store?
        public static Element DeliverOrWarehouseYesCTA => new Element(By.XPath("//input[@id='cc_8018']//following::button[1]"));
        // No CTA - Do any employees deliver or warehouse any goods or run a retail store?
        public static Element DeliverOrWarehouseNoCTA => new Element(By.XPath("//input[@id='cc_8018']//following::button[2]"));
        // Question - Do your employees deliver any of your goods or merchandise?
        public static Element DeliveryGoodsOrMerchandiseQST => new Element(By.XPath("//label[contains(text(),'goods or merchandise')]"));
        // Dropdown - Do your employees deliver any of your goods or merchandise?
        public static Element DeliveryGoodsOrMerchandiseDD => new Element(By.XPath("//select[@id='uq435']"));
        // Question - Were you looking to buy insurance, in case of an injury, for your volunteers?
        public static Element BuyInsuranceForYourVolunteersQST => new Element(By.XPath("//label[contains(text(),'for your volunteers')]"));
        // Dropdown - Were you looking to buy insurance, in case of an injury, for your volunteers?
        public static Element BuyInsuranceForYourVolunteersDD => new Element(By.XPath("//select[@id='uq378']"));

        // Furniture moving and Storage --------------------------------------------------------------------------------------------------------
        // Question - Are there any travelling sales staff that never load, unload or drive moving trucks? 
        public static Element TravellingStaffNeverLoadUnloadOrDriveMovingTrucksQST => new Element(By.XPath("//label[contains(text(),'are there any travelling sales staff that never load')]"));
        // Yes CTA - Are there any travelling sales staff that never load, unload or drive moving trucks? 
        public static Element TravellingStaffNeverLoadUnloadOrDriveMovingTrucksYesCTA => new Element(By.XPath("//input[@id='cc_8742']//following::button[1]"));
        // No CTA - Are there any travelling sales staff that never load, unload or drive moving trucks? 
        public static Element TravellingStaffNeverLoadUnloadOrDriveMovingTrucksNoCTA => new Element(By.XPath("//input[@id='cc_8742']//following::button[2]"));
        // Enter their payroll amount
        public static Element TravellingStaffNeverLoadUnloadOrDriveMovingTrucksPayrollAmount => new Element(By.XPath("//input[@id='cc_8742_Payroll']"));

        // Question - Do you provide written guidelines and training on proper lifting techniques?
        public static Element WrittenGuidelinesAndTrainingOnProperLiftingQST => new Element(By.XPath("//label[contains(text(),'lifting')]"));
        // Yes CTA - Do you provide written guidelines and training on proper lifting techniques?
        public static Element WrittenGuidelinesAndTrainingOnProperLiftingYesCTA => new Element(By.XPath("//input[@id='uq235']//following::button[1]"));
        // No CTA - Do you provide written guidelines and training on proper lifting techniques?
        public static Element WrittenGuidelinesAndTrainingOnProperLiftingNoCTA => new Element(By.XPath("//input[@id='uq235']//following::button[2]"));

        // Question - Are there any drivers that drive trucks you own or lease but pay via 1099?
        public static Element AnyDriversDriveTrucksYouOwnPayVia1099QST => new Element(By.XPath("//label[contains(text(),'drivers that drive trucks you own or lease but pay via 1099')]"));
        // Yes CTA - Are there any drivers that drive trucks you own or lease but pay via 1099?
        public static Element AnyDriversDriveTrucksYouOwnPayVia1099YesCTA => new Element(By.XPath("//input[@id='uq462']//following::button[1]"));
        // No CTA - Are there any drivers that drive trucks you own or lease but pay via 1099?
        public static Element AnyDriversDriveTrucksYouOwnPayVia1099NoCTA => new Element(By.XPath("//input[@id='uq462']//following::button[2]"));
        // Question - What is the annual 1099 pay to drivers that drive your trucks?
        public static Element AnnualPayToDriversDriveYourTrucksQST => new Element(By.XPath("//label[contains(text(),'what is the annual 1099 pay to drivers that drive your trucks')]"));
        // Input - What is the annual 1099 pay to drivers that drive your trucks?
        public static Element AnnualPayToDriversDriveYourTrucksInput => new Element(By.XPath("//input[@id='uq614']"));

        // Question - Do any owner operators or sub-haulers transport goods on your behalf? 
        public static Element SubHaulersTransportQST => new Element(By.XPath("//label[contains(text(),'do any owner operators or sub-haulers transport goods on your behalf')]"));
        // Yes CTA - Do any owner operators or sub-haulers transport goods on your behalf? 
        public static Element SubHaulersTransportYesCTA => new Element(By.XPath("//label[contains(text(),'do any owner operators or sub-haulers transport goods on your behalf')]//following::button[1]"));
        // No CTA - Do any owner operators or sub-haulers transport goods on your behalf? 
        public static Element SubHaulersTransportNoCTA => new Element(By.XPath("//label[contains(text(),'do any owner operators or sub-haulers transport goods on your behalf')]//following::button[2]"));
        // Question - Do you require all owner operators or sub-haulers to have certificates of insurance?
        public static Element DoYouRequireAllOwnerOpreratorsHaveCertfInsuranceQST => new Element(By.XPath("//label[contains(text(),'have certificates of insurance')]"));
        // Dropdown - Do you require all owner operators or sub-haulers to have certificates of insurance?
        public static Element DoYouRequireAllOwnerOpreratorsHaveCertfInsuranceDD => new Element(By.XPath("//select[@id='uq454']"));
        // Question - What is the total annual pay to owner operators that drive on your behalf?
        public static Element TTLPayOwnerOperatorsDriveOnYourBehalfQST => new Element(By.XPath("//label[contains(text(),'what is the total annual pay to owner operators that drive on your behalf')]"));
        // Input - What is the total annual pay to owner operators that drive on your behalf?
        public static Element TTLPayOwnerOperatorsDriveOnYourBehalfInput => new Element(By.XPath("//input[@id='uq392']"));
        // Invalid tax ID 
        public static Element InvalidTaxID => new Element(By.XPath("//p[contains(text(),'Federal Tax ID')]"));

        // Day CAre --------------------------------------------------------------------------------------------------------------------------------
        // Question - Are there any licensed or certified teachers on staff?
        public static Element AreThereLicensedOrCertifiedTeachersOnStaffQST => new Element(By.XPath("//label[contains(text(),'are there any licensed or certified teachers on staff')]"));
        // Yes CTA - Are there any licensed or certified teachers on staff?
        public static Element AreThereLicensedOrCertifiedTeachersOnStaffYesCTA => new Element(By.XPath("//input[@id='cc_8868']//following::button[1]"));
        // No CTA - Are there any licensed or certified teachers on staff?
        public static Element AreThereLicensedOrCertifiedTeachersOnStaffNoCTA => new Element(By.XPath("//input[@id='cc_8868']//following::button[2]"));
        // Question - Do you require any staff to be licensed or certified as a teacher?
        public static Element DoYouRequireAnyStaffToBeLicensedQST => new Element(By.XPath("//label[contains(text(),'do you require any staff to be licensed')]"));
        // Yes CTA - Do you require any staff to be licensed or certified as a teacher?
        public static Element DoYouRequireAnyStaffToBeLicensedYesCTA => new Element(By.XPath("//input[@id='uq459']//following::button[1]"));
        // No CTA - Do you require any staff to be licensed or certified as a teacher?
        public static Element DoYouRequireAnyStaffToBeLicensedNoCTA => new Element(By.XPath("//input[@id='uq459']//following::button[2]"));
        // Total Annual Payroll - Are there any licensed or certified teachers on staff?
        public static Element AreThereLicensedOrCertifiedTeachersOnStaffTTLAnnualPayroll => new Element(By.XPath("//input[@id='cc_8868_Payroll']"));
        // Question - Are any included owners licensed or certified teachers?
        public static Element AreAnyIncludedOwnersLicensedOrCertifiedTeachersQST => new Element(By.XPath("//label[contains(text(),'are any included owners licensed or certified teachers')]"));
        // Drop down - Are any included owners licensed or certified teachers?
        public static Element AreAnyIncludedOwnersLicensedOrCertifiedTeachersDD => new Element(By.XPath("//select[@id='oocc_8868']"));


        // Retail Store: Electrical Lighting / Supplies ----------------------------------------------------------------------------------------
        // Question - Do you do (or arrange for subcontractors to do) any installation services for your customers? 
        public static Element DoYouDoInstallationServiceForYourCustomersQST => new Element(By.XPath("//label[contains(text(),'any installation services for your customers')]"));
        // Yes CTA - Do you do (or arrange for subcontractors to do) any installation services for your customers? 
        public static Element DoYouDoInstallationServiceForYourCustomersYesCTA => new Element(By.XPath("//input[@id='uq264']//following::button[1]"));
        // No CTA - Do you do (or arrange for subcontractors to do) any installation services for your customers? 
        public static Element DoYouDoInstallationServiceForYourCustomersNoCTA => new Element(By.XPath("//input[@id='uq264']//following::button[2]"));


        // Question - Do any employees only do clerical office tasks and does not write up repair estimates? 
        public static Element DoClericalOfficeTasksQST => new Element(By.XPath("//label[contains(text(),'do clerical office')]"));
        public static Element DoClericalOfficeTasksYesCTA => new Element(By.XPath("//input[@id='cc_8810']//following::button[1]"));
        public static Element DoClericalOfficeTasksNoCTA => new Element(By.XPath("//input[@id='cc_8810']//following::button[2]"));
        public static Element DoClericalOfficeTasksAnnualPayroll => new Element(By.XPath("//input[@id='cc_8810_Payroll']"));

        // Car Wash: Self Service ----------------------------------------------------------------------------------------------------------------
        // Question - Do you engage in the repossession of vehicles?
        public static Element EngageRespossessionQST => new Element(By.XPath("//label[contains(text(),'repossession')]"));
        public static Element EngageRespossessionYesCTA => new Element(By.XPath("//input[@id='uq33']//following::button[1]"));
        public static Element EngageRespossessionNoCTA => new Element(By.XPath("//input[@id='uq33']//following::button[2]"));

        // Exeminator or Pest Control
        // Question - Do any included owners/officers only do general office work and rarely travel? 
        public static Element IncludedOwnerOfficersRarelyTravelQST => new Element(By.XPath("//label[contains(text(),'included owners/officers only do general office work and rarely travel')]"));
        // Drop down - Do any included owners/officers only do general office work and rarely travel?
        public static Element IncludedOwnerOfficersRarelyTravelDD => new Element(By.XPath("//label[contains(text(),'included owners/officers only do general office work and rarely travel')]//following::select[1]"));


        // ActuarialServices------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------
        // Do any employees travel frequently for sales, consultation, or auditing?
        public static Element TravelFreqForSalesConsQST => new Element(By.XPath("//label[text()='do any employees travel frequently for sales, consultation, or auditing?']"));
        public static Element TravelFreqForSalesConsYes => new Element(By.XPath("//label[text()='do any employees travel frequently for sales, consultation, or auditing?']//following::button[1]"));
        // if Yes, it asks "Enter their total annual payroll"
        public static Element TravelFreqForSalesConsYesPayrollQST => new Element(By.XPath("//label[contains(text(), 'Enter their total annual payroll')]"));
        public static Element TravelFreqForSalesConsYesPayroll => new Element(By.XPath("//label[contains(text(), 'Enter their total annual payroll')]//following::input[@class='money input-flair au-target']"));
        public static Element TravelFreqForSalesConsNo => new Element(By.XPath("//label[text()='do any employees travel frequently for sales, consultation, or auditing?']//following::button[2]"));
        // Do you do any direct physical work such as construction, landscaping, or farming?
        public static Element DirectPhysicalWorkConstLandsFarmQST => new Element(By.XPath("//label[text()='do you do any direct physical work such as construction, landscaping, or farming?']"));
        public static Element DirectPhysicalWorkConstLandsFarmYes => new Element(By.XPath("//label[text()='do you do any direct physical work such as construction, landscaping, or farming?']//following::button[1]"));
        public static Element DirectPhysicalWorkConstLandsFarmNo => new Element(By.XPath("//label[text()='do you do any direct physical work such as construction, landscaping, or farming?']//following::button[2]"));
        // Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters?
        public static Element EmerResponWorkersToAreasWithDiseaseCatastropheDisasterQST => new Element(By.XPath("//label[text()='do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters?']"));
        public static Element EmerResponWorkersToAreasWithDiseaseCatastropheDisasterYes => new Element(By.XPath("//label[text()='do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters?']//following::button[1]"));
        public static Element EmerResponWorkersToAreasWithDiseaseCatastropheDisasterNo => new Element(By.XPath("//label[text()='do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters?']//following::button[2]"));
        // Do you provide any staffing services?
        public static Element ProvideStaffingServicesQST => new Element(By.XPath("//label[text()='do you provide any staffing services?']"));
        public static Element ProvideStaffingServicesYes => new Element(By.XPath("//label[text()='do you provide any staffing services?']//following::button[1]"));
        public static Element ProvideStaffingServicesNo => new Element(By.XPath("//label[text()='do you provide any staffing services?']//following::button[2]"));
        // Question - What is the compensation arrangement for your staffing services?
        public static Element CompensationArrangementForYourStaffingServicesQST => new Element(By.XPath("//label[contains(text(),'compensation arrangement')]"));
        public static Element CompensationArrangementForYourStaffingServicesDD => new Element(By.XPath("//select[@id='uq413']"));
        // Question - Are you looking to buy coverage for the workers you help staff in case of an on-the-job injury? 
        public static Element AreYouLookingBuyCoverageForTheWorkersYouHelpStaffQST => new Element(By.XPath("//label[contains(text(),'are you looking to buy coverage for the workers')]"));
        public static Element AreYouLookingBuyCoverageForTheWorkersYouHelpStaffYesCTA => new Element(By.XPath("//input[@id='uq414']//following::button[1]"));
        public static Element AreYouLookingBuyCoverageForTheWorkersYouHelpStaffNoCTA => new Element(By.XPath("//input[@id='uq414']//following::button[2]"));


        // Limo Company
        // Question -  What is the maximum number of miles your employees travel as part of their job duties?
        public static Element MaxNumberOfMilesQST => new Element(By.XPath("//label[contains(text(),'what is the maximum number of miles')]"));
        // Input -  What is the maximum number of miles your employees travel as part of their job duties?
        public static Element MaxNumberOfMilesInput => new Element(By.XPath("//input[@id='uq31']"));

        // Carpet Store: Retail; No Installation
        // Do you do (or arrange for subcontractors to do) any installation services for your customers? //input[@id="uq264"]//following::button[1]
        public static Element DoYouDoAnyInstallationServicesForYourCustomerQST => new Element(By.XPath("//label[contains(text(),'installation services for your customers')]"));
        public static Element DoYouDoAnyInstallationServicesForYourCustomerYesCTA => new Element(By.XPath("//input[@id='uq264']//following::button[1]"));
        public static Element DoYouDoAnyInstallationServicesForYourCustomerNoCTA => new Element(By.XPath("//input[@id='uq264']//following::button[2]"));

        // What percentage of delivery is done by a third party or independent contractors?
        public static Element WhatPercentOfDeliveryIsDoneByThirdPartyOrIndpContrctQST => new Element(By.XPath("//label[contains(text(),'what percentage of delivery is done by a third party or independent contractors')]"));
        public static Element WhatPercentOfDeliveryIsDoneByThirdPartyOrIndpContrctInput => new Element(By.XPath("//input[@id='uq172']"));

        // Are certificates of insurance kept for all third parties that deliver on your behalf? 
        public static Element AreCertificatesOfInsuranceKeptAllThirdPartiesQST => new Element(By.XPath("//label[contains(text(),'are certificates of insurance kept for all third parties')]"));
        public static Element AreCertificatesOfInsuranceKeptAllThirdPartiesDD => new Element(By.XPath("//select[@id='uq255']"));

        // What is the annual pay to third parties that deliver on your behalf?
        public static Element WhatIsAnnualPayToThirdPartiesQST => new Element(By.XPath("//label[@data-qa='question_385']"));
        public static Element WhatIsAnnualPayToThirdPartiesInput => new Element(By.XPath("//input[@id='uq385']"));

        // Movin Company 
        // Question - Do any included owners/officers travel for sales and never load, unload or drive moving trucks? 
        public static Element DoAnyIncluedOwnerOfficersNeverLoadAndUnloadQST => new Element(By.XPath("//label[contains(text(),'sales and never load, unload or drive moving trucks')]"));
        public static Element DoAnyIncluedOwnerOfficersNeverLoadAndUnloadDD => new Element(By.XPath("//select[@id='oocc_8742']"));

        // Question - How much of total goods transportation is done by owner operators or sub-haulers?
        public static Element TTLGoodsTransportIsDoneByOwnerOperatorsOrSubHaulersQST => new Element(By.XPath("//label[contains(text(),'total goods transportation')]"));
        public static Element TTLGoodsTransportIsDoneByOwnerOperatorsOrSubHaulersDD => new Element(By.XPath("//select[@id='uq455']"));

        // Keyword: Hotel: With Restaurant 
        // Question - If you run a restaurant open to the general public, do any employees only work at the restaurant? 
        public static Element IfYouRunRestaurantOpenPublicQST => new Element(By.XPath("//label[contains(text(),'run a restaurant open to the general public')]"));
        public static Element IfYouRunRestaurantOpenPublicYesCTA => new Element(By.XPath("//label[contains(text(),'run a restaurant open to the general public')]//following::button[1]"));
        public static Element IfYouRunRestaurantOpenPublicNoCTA => new Element(By.XPath("//label[contains(text(),'run a restaurant open to the general public')]//following::button[2]"));
        public static Element IfYouRunRestaurantOpenPublicAnnualPayroll => new Element(By.XPath("//input[@id='cc_9058_Payroll']"));

        // Keyword: Jewelry Store: Retail 
        // Question - Do you use armed security officers?
        public static Element DoYouUseArmedSecurityOfficersQST => new Element(By.XPath("//label[contains(text(),'do you use armed security officers')]"));
        public static Element DoYouUseArmedSecurityOfficersYesCTA => new Element(By.XPath("//input[@id='uq25']//following::button[1]"));
        public static Element DoYouUseArmedSecurityOfficersNoCTA => new Element(By.XPath("//input[@id='uq25']//following::button[2]"));

        // Adult Living Facility: No Medical Care 
        // Question - Do any owners/officers only do general office work and wouldn't interact with residents?
        public static Element OwnerOfficersWouldntInteractWithResidentQST => new Element(By.XPath("//label[contains(text(),'interact with residents')]"));
        public static Element OwnerOfficersWouldntInteractWithResidentDD => new Element(By.XPath("//select[@id='oocc_8810']"));

        //Question - Do any employees only do general office work and would never interact with any residents?
        public static Element AnyEmpWouldNeverInteractWithAnyResidentQST => new Element(By.XPath("//label[contains(text(),'would never interact with any residents')]"));
        public static Element AnyEmpWouldNeverInteractWithAnyResidentYesCTA => new Element(By.XPath("//input[@id='cc_8810']//following::button[1]"));
        public static Element AnyEmpWouldNeverInteractWithAnyResidentNoCTA => new Element(By.XPath("//input[@id='cc_8810']//following::button[2]"));
        public static Element AnyEmpWouldNeverInteractWithAnyResidentAnnualPayroll => new Element(By.XPath("//input[@id='cc_8810_Payroll']"));

        // Question - Do you accept clients that have been diagnosed with a form of dementia?
        public static Element ClientsHaveBeenDiagnosedFromDementiaQST => new Element(By.XPath("//label[contains(text(),'form of dementia')]"));
        public static Element ClientsHaveBeenDiagnosedFromDementiaDD => new Element(By.XPath("//select[@id='uq352']"));

        // Do you provide any alcohol or drug abuse counseling?
        public static Element DrugAbuseCounselingQST => new Element(By.XPath("//label[contains(text(),'drug abuse counseling')]"));
        public static Element DrugAbuseCounselingDD => new Element(By.XPath("//select[@id='uq422']"));

        // What percentage of residents or clients are ambulatory? 
        public static Element PercentageOfResidentOrClientsAreAmbulatoryQST => new Element(By.XPath("//label[contains(text(),'clients are ambulatory')]"));
        public static Element PercentageOfResidentOrClientsAreAmbulatoryPercentage => new Element(By.XPath("//input[@id='uq183']"));

        // Adult Living Facility: With Medical Care //label[contains(text(),'included owners/officers licensed physicians, nurses, directors or administrators')]
        // Are any included owners/officers licensed physicians, nurses, directors or administrators?
        public static Element IncludedOwnerOfficersLicensedPyhsiciansNursesQST => new Element(By.XPath("//label[contains(text(),'included owners/officers licensed physicians, nurses, directors or administrators')]"));
        public static Element IncludedOwnerOfficersLicensedPyhsiciansNursesDD => new Element(By.XPath("//select[@id='oocc_8824']"));

        // Are there any licensed employee physicians, RNs, practical nurses, directors or administrators? //input[@id="cc_8824_Payroll"]
        public static Element LicensedEmployeePhysiciansRNsQST => new Element(By.XPath("//label[contains(text(),'RNs, practical nurses')]"));
        public static Element LicensedEmployeePhysiciansRNsYesCTA => new Element(By.XPath("//label[contains(text(),'RNs, practical nurses')]//following::button[1]"));
        public static Element LicensedEmployeePhysiciansRNsNoCTA => new Element(By.XPath("//label[contains(text(),'RNs, practical nurses')]//following::button[2]"));
        public static Element LicensedEmployeePhysiciansRNsPayroll => new Element(By.XPath("//input[@id='cc_8824_Payroll']"));

        // Alarm Monitoring Services
        // Question - Are any included owners/officers cost estimators that wouldn't do any direct physical work?
        public static Element OwnerOfficersCostEstimatorsQST => new Element(By.XPath("//label[contains(text(),'owners/officers cost estimators')]"));
        public static Element OwnerOfficersCostEstimatorsDD => new Element(By.XPath("//select[@id='oocc_8742']"));

        // Question - Are there any cost estimators on staff that wouldn't do any direct physical work?
        public static Element CostEstimatorOnStaffWouldntDoDirectPhysicalWorkQST => new Element(By.XPath("//label[contains(text(),'cost estimators on staff')]"));
        public static Element CostEstimatorOnStaffWouldntDoDirectPhysicalWorkYesCTA => new Element(By.XPath("//label[contains(text(),'cost estimators on staff')]//following-sibling::bb-options//button[text()='yes']"));
        public static Element CostEstimatorOnStaffWouldntDoDirectPhysicalWorkNoCTA => new Element(By.XPath("//input[@id='cc_8742']//following::button[2]"));
        public static Element CostEstimatorOnStaffWouldntDoDirectPhysicalWorkPayroll => new Element(By.XPath("//input[@id='cc_8742_Payroll']"));

        // Do you install, repair, or do maintenance on satellite dishes or antennae?
        public static Element InstallRepairAntennaeQST => new Element(By.XPath("//label[contains(text(),'satellite dishes or antennae')]"));
        public static Element InstallRepairAntennaeYesCTA => new Element(By.XPath("//input[@id='uq148']//following::button[1]"));
        public static Element InstallRepairAntennaeNoCTA => new Element(By.XPath("//input[@id='uq148']//following::button[2]"));

        // Question - Do you perform any work on chemical and/or foam sprinklers?
        public static Element ChemicalFoamSprinklersQST => new Element(By.XPath("//label[contains(text(),'chemical and/or foam sprinklers')]"));
        public static Element ChemicalFoamSprinklersYesCTA => new Element(By.XPath("//input[@id='uq59']//following::button[1]"));
        public static Element ChemicalFoamSprinklersNoCTA => new Element(By.XPath("//input[@id='uq59']//following::button[2]"));

        // Question - How much of total work is done by subcontractors/1099 workers? 
        public static Element HowMuchTotalWorkDoneBySubcontractorsQST => new Element(By.XPath("//label[contains(text(),'how much of total work is done by subcontractors')]"));
        public static Element HowMuchTotalWorkDoneBySubcontractorsDD => new Element(By.XPath("//select[@id='uq449']"));


        // Attorney 
        // Question - What percentage of work involves Bankruptcy, Corporate, Intellectual Property, or Real Estate law?
        public static Element WhatPercentageOfWorkWorkBankruptcyCorIntelRealEstateQST => new Element(By.XPath("//label[contains(text(),'Bankruptcy, Corporate, Intellectual Property')]"));
        public static Element WhatPercentageOfWorkWorkBankruptcyCorIntelRealEstatePercentage => new Element(By.XPath("//input[@id='uq224']"));

        // Babysitting
        // Question - Do any workers perform property maintenance or landscaping duties
        public static Element DoAnyWorkersPerformPropertyMaintenanceQST => new Element(By.XPath("//label[contains(text(),'workers perform property maintenance or landscaping duties')]"));
        public static Element DoAnyWorkersPerformPropertyMaintenanceYesCTA => new Element(By.XPath("//input[@id='uq199']//following::button[1]"));
        public static Element DoAnyWorkersPerformPropertyMaintenanceNoCTA => new Element(By.XPath("//input[@id='uq199']//following::button[2]"));

        // Question - Is housing provided for any of the workers
        public static Element IsHousingProvidedForAnyOfTheWorkersQST => new Element(By.XPath("//label[contains(text(),'is housing provided for any of the workers')]"));
        public static Element IsHousingProvidedForAnyOfTheWorkersYesCTA => new Element(By.XPath("//input[@id='uq200']//following::button[1]"));
        public static Element IsHousingProvidedForAnyOfTheWorkersNoCTA => new Element(By.XPath("//input[@id='uq200']//following::button[2]"));

        // Brine Hauling: Over 200 Miles
        // Question - How many miles at most do drivers go from their base location
        public static Element HowManyMilesMostDoDriversGoFromTheirBaseLocationQST => new Element(By.XPath("//label[contains(text(),'most do drivers go from their base location')]"));
        public static Element HowManyMilesMostDoDriversGoFromTheirBaseLocationInput => new Element(By.XPath("//input[@id='uq283']"));

        // Question - Do you do manual tarping
        public static Element ManualTarpingQST => new Element(By.XPath("//label[contains(text(),'tarping')]"));
        public static Element ManualTarpingYesCTA => new Element(By.XPath("//input[@id='uq112']//following::button[1]"));
        public static Element ManualTarpingNoCTA => new Element(By.XPath("//input[@id='uq112']//following::button[2]"));

        // Question - Do you transport any hazardous materials? 
        public static Element TransportHazardousMeterialsQST => new Element(By.XPath("//label[contains(text(),'transport any hazardous materials')]"));
        public static Element TransportHazardousMeterialsYesCTA => new Element(By.XPath("//input[@id='uq125']//following::button[1]"));
        public static Element TransportHazardousMeterialsNoCTA => new Element(By.XPath("//input[@id='uq125']//following::button[2]"));

        // Question - In the past 3 years has the DOT cited you for any out of service HazMat violations? 
        public static Element HazMatViolationsQST => new Element(By.XPath("//label[contains(text(),'HazMat violations')]"));
        public static Element HazMatViolationsYesCTA => new Element(By.XPath("//label[contains(text(),'HazMat violations')]//following::button[1]"));
        public static Element HazMatViolationsNoCTA => new Element(By.XPath("//label[contains(text(),'HazMat violations')]//following::button[2]"));

        // Question - Do you haul any explosives, radioactives, or corrosives (DOT Hazard Classes 1, 7, or 8)?
        public static Element DOTHazardClassesQST => new Element(By.XPath("//label[contains(text(),'DOT Hazard Classes')]"));
        public static Element DOTHazardClassesYesCTA => new Element(By.XPath("//input[@id='uq395']//following::button[1]"));
        public static Element DOTHazardClassesNoCTA => new Element(By.XPath("//input[@id='uq395']//following::button[2]"));

        // Question - Do your drivers do any manual loading/unloading of materials?
        public static Element DriversDoManualLoadingUnloadingMetrialQST => new Element(By.XPath("//label[contains(text(),'drivers do any manual loading/unloading of materials')]"));
        public static Element DriversDoManualLoadingUnloadingMetrialYesCTA => new Element(By.XPath("//input[@id='uq404']//following::button[1]"));
        public static Element DriversDoManualLoadingUnloadingMetrialNoCTA => new Element(By.XPath("//input[@id='uq404']//following::button[2]"));

        // Question - Do drivers use chains to secure equipment, logs, or other large loads for transport?
        public static Element UseChainsToSecureEquipmentQST => new Element(By.XPath("//label[contains(text(),'chains to secure equipment')]"));
        public static Element UseChainsToSecureEquipmentYesCTA => new Element(By.XPath("//input[@id='uq586']//following::button[1]"));
        public static Element UseChainsToSecureEquipmentNoCTA => new Element(By.XPath("//input[@id='uq586']//following::button[2]"));

        // Fulfillment Center
        // Question - Is your business in charge of getting any goods to their final destination?
        public static Element IsYourBizInChargeOfGettingAnyGoodsFinalDestinationQST => new Element(By.XPath("//label[contains(text(),'getting any goods to their final destination')]"));
        public static Element IsYourBizInChargeOfGettingAnyGoodsFinalDestinationDD => new Element(By.XPath("//select[@id='uq359']"));
        // Question - How much goods transportation is directly done by your business?
        public static Element HowMuchGoodsTransportationIsDirectlyDoneByYourBizQST => new Element(By.XPath("//label[text()='how much goods transportation is directly done by your business?']"));
        public static Element HowMuchGoodsTransportationIsDirectlyDoneByYourBizDD => new Element(By.XPath("//select[@id='uq361']"));

        // Question - Do you load or unload any goods?
        public static Element DoYouLoadOrUnloadAnyGoodsQST => new Element(By.XPath("//label[text()='do you load or unload any goods?']"));
        public static Element DoYouLoadOrUnloadAnyGoodsYesCTA => new Element(By.XPath("//input[@id='uq360']//following::button[1]"));
        public static Element DoYouLoadOrUnloadAnyGoodsNoCTA => new Element(By.XPath("//input[@id='uq360']//following::button[2]"));
        // Question - Do you load or unload any furniture?
        public static Element DoYouLoadOrUnloadAnyFurnitureQST => new Element(By.XPath("//label[text()='do you load or unload any goods?']"));
        public static Element DoYouLoadOrUnloadAnyFurnitureYesCTA => new Element(By.XPath("//input[@id='uq362']//following::button[1]"));
        public static Element DoYouLoadOrUnloadAnyFurnitureNoCTA => new Element(By.XPath("//input[@id='uq362']//following::button[2]"));


        // Auto Dealership: New and Used
        // Do you have any mechanics on staff
        public static Element DoYouhaveAnyMechanicsOnStaffQST => new Element(By.XPath("//label[contains(text(),'do you have any mechanics on staff')]"));
        public static Element DoYouhaveAnyMechanicsOnStaffYesCTA => new Element(By.XPath("//label[contains(text(),'do you have any mechanics on staff')]//following::button[1]"));
        public static Element DoYouhaveAnyMechanicsOnStaffNoCTA => new Element(By.XPath("//label[contains(text(),'do you have any mechanics on staff')]//following::button[2]"));
        public static Element DoYouhaveAnyMechanicsOnStaffInput => new Element(By.XPath("//input[@id='cc_8380_Payroll']"));

        // Do any employees do any roadside assistance or towing?
        public static Element AnyEmpDoAnyRoadsideAssitanceOrTowingQST => new Element(By.XPath("//label[contains(text(),'do any employees do any roadside assistance or towing')]"));
        public static Element AnyEmpDoAnyRoadsideAssitanceOrTowingYesCTA => new Element(By.XPath("(//label[contains(text(),'do any employees do any roadside assistance or towing')]//following::button)[2]"));
        public static Element AnyEmpDoAnyRoadsideAssitanceOrTowingNoCTA => new Element(By.XPath("(//label[contains(text(),'do any employees do any roadside assistance or towing')]//following::button)[3]"));
        public static Element AnyEmpDoAnyRoadsideAssitanceOrTowingInput => new Element(By.XPath("//input[@id='cc_7225_Payroll']"));

        // What % of revenue is from sales or service of Truck Tractors/Trailers or Recreational Vehicles? //input[@id='uq259']
        public static Element RevenueIsFromSalesOrServiceOfTruckQST => new Element(By.XPath("//label[contains(text(),'of revenue is from sales')]"));
        public static Element RevenueIsFromSalesOrServiceOfTruckInput => new Element(By.XPath("//input[@id='uq259']"));

        // Music Instructor
        // Are any children or students younger than five years old?
        public static Element AreAnyStudentsYoungerThanFiveYearsOldQST => new Element(By.XPath("//label[contains(text(),'younger than five years old')]"));
        public static Element AreAnyStudentsYoungerThanFiveYearsOldDD => new Element(By.XPath("//select[@id='uq419']"));

        // Concrete Construction-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
        // Are there any employees that never travel to job sites or do any construction work? 
        public static Element AnyEmployeesNeverTrvlToJobSitesOrConstrWorkQST => new Element(By.XPath("//label[text()='are there any employees that never travel to job sites or do any construction work?']"));
        public static Element AnyEmployeesNeverTrvlToJobSitesOrConstrWorkYes => new Element(By.XPath("(//label[text()='are there any employees that never travel to job sites or do any construction work?']//following::button)[2]"));
        public static Element AnyEmployeesNeverTrvlToJobSitesOrConstrWorkNo => new Element(By.XPath("(//label[text()='are there any employees that never travel to job sites or do any construction work?']//following::button)[3]"));

        // Do you build any load-bearing concrete walls?
        public static Element BuildLoadBearingConcreteWallsQST => new Element(By.XPath("//label[text()='do you build any load-bearing concrete walls?']"));
        public static Element BuildLoadBearingConcreteWallsYes => new Element(By.XPath("//label[text()='do you build any load-bearing concrete walls?']//following::button[1]"));
        public static Element BuildLoadBearingConcreteWallsNo => new Element(By.XPath("//label[text()='do you build any load-bearing concrete walls?']//following::button[2]"));

        // Do you do any masonry work such as manual brick or stone laying?
        public static Element MasonryWorkSuchManualBrickOrStoneLayingQST => new Element(By.XPath("//label[text()='do you do any masonry work such as manual brick or stone laying?']"));
        public static Element MasonryWorkSuchManualBrickOrStoneLayingYes => new Element(By.XPath("//label[text()='do you do any masonry work such as manual brick or stone laying?']//following::button[1]"));
        public static Element MasonryWorkSuchManualBrickOrStoneLayingNo => new Element(By.XPath("//label[text()='do you do any masonry work such as manual brick or stone laying?']//following::button[2]"));

        // Do you do residential foundation work?
        public static Element ResidentialFoundationWorkQST => new Element(By.XPath("//label[text()='do you do residential foundation work?']"));
        public static Element ResidentialFoundationWorkYes => new Element(By.XPath("//label[text()='do you do residential foundation work?']//following::button[1]"));
        public static Element ResidentialFoundationWorkNo => new Element(By.XPath("//label[text()='do you do residential foundation work?']//following::button[2]"));

        // Football Camp
        // Do any included owners/officers only do general office work and don't go to any camps? 
        public static Element IncludedOwnersOfficersDontGoToAnyCampsQST => new Element(By.XPath("//label[contains(text(),'go to any camps')]"));
        public static Element IncludedOwnersOfficersDontGoToAnyCampsDD => new Element(By.XPath("//select[@id='oocc_8810']"));

        // Do any employees only do general office work and don't travel to the actual camp location? 
        public static Element AnyEmployeesTravelToTheActualCampLocationQST => new Element(By.XPath("//label[contains(text(),'travel to the actual camp location')]"));
        public static Element AnyEmployeesTravelToTheActualCampLocationYesCTA => new Element(By.XPath("//label[contains(text(),'travel to the actual camp location')]//following::button[1]"));
        public static Element AnyEmployeesTravelToTheActualCampLocationNoCTA => new Element(By.XPath("//label[contains(text(),'travel to the actual camp location')]//following::button[2]"));
        public static Element AnyEmployeesTravelToTheActualCampLocationPayrollAmount => new Element(By.XPath("//input[@id='cc_8810_Payroll']"));

        // Do you do any caving, rock climbing, or white water rafting? 
        public static Element CavingRockClimbingOrWhiteWaterRaftingQST => new Element(By.XPath("//label[contains(text(),'any caving, rock climbing, or white water rafting')]"));
        public static Element CavingRockClimbingOrWhiteWaterRaftingYesCTA => new Element(By.XPath("//label[contains(text(),'any caving, rock climbing, or white water rafting')]//following::button[1]"));
        public static Element CavingRockClimbingOrWhiteWaterRaftingNoCTA => new Element(By.XPath("//label[contains(text(),'any caving, rock climbing, or white water rafting')]//following::button[2]"));

        // Media Commercial Production
        // Do you film choreographed fight scenes?
        public static Element DoYouFilmChoreographedFightScenesQST => new Element(By.XPath("//label[text()='do you film choreographed fight scenes?']"));
        public static Element DoYouFilmChoreographedFightScenesYesCTA => new Element(By.XPath("//label[text()='do you film choreographed fight scenes?']//following::button[1]"));
        public static Element DoYouFilmChoreographedFightScenesNoCTA => new Element(By.XPath("//label[text()='do you film choreographed fight scenes?']//following::button[2]"));

        // Do you film car, motorcycle, or ATV stunts or chase scenes?
        public static Element FilmCarOrATVQST => new Element(By.XPath("//label[contains(text(),'do you film car, motorcycle')]"));
        public static Element FilmCarOrATVYesCTA => new Element(By.XPath("//label[contains(text(),'do you film car, motorcycle')]//following::button[1]"));
        public static Element FilmCarOrATVNoCTA => new Element(By.XPath("//label[contains(text(),'do you film car, motorcycle')]//following::button[2]"));


        // Greenhouse Grower
        // Do you have any grain elevators or silos on site? 
        public static Element GrainElevatorsOrSilosOnSiteQST => new Element(By.XPath("//label[contains(text(),'grain elevators or silos on site')]"));
        public static Element GrainElevatorsOrSilosOnSiteYesCTA => new Element(By.XPath("//label[contains(text(),'grain elevators or silos on site')]//following::button[1]"));
        public static Element GrainElevatorsOrSilosOnSiteNoCTA => new Element(By.XPath("//label[contains(text(),'grain elevators or silos on site')]//following::button[2]"));

        // Do you grow any fruit tree or nut tree crops?
        public static Element GrowAnyFruitTreeOrNutTreeCropsQST => new Element(By.XPath("//label[contains(text(),'grow any fruit tree or nut tree crops')]"));
        public static Element GrowAnyFruitTreeOrNutTreeCropsYesCTA => new Element(By.XPath("//label[contains(text(),'grow any fruit tree or nut tree crops')]//following::button[1]"));
        public static Element GrowAnyFruitTreeOrNutTreeCropsNoCTA => new Element(By.XPath("//label[contains(text(),'grow any fruit tree or nut tree crops')]//following::button[2]"));

        // Do you provide any farm labor contractor services?
        public static Element ProvideFarmLaborContractorServicesQST => new Element(By.XPath("//label[contains(text(),'you provide any farm labor contractor services')]"));
        public static Element ProvideFarmLaborContractorServicesYesCTA => new Element(By.XPath("//label[contains(text(),'you provide any farm labor contractor services')]//following::button[1]"));
        public static Element ProvideFarmLaborContractorServicesNoCTA => new Element(By.XPath("//label[contains(text(),'you provide any farm labor contractor services')]//following::button[2]"));

        // Do you transport any sold livestock or harvested crops more than 50 miles?
        public static Element TransportSoldLivestockMoreThan50MilesQST => new Element(By.XPath("//label[contains(text(),'transport any sold livestock or harvested crops more than 50 miles')]"));
        public static Element TransportSoldLivestockMoreThan50MilesYesCTA => new Element(By.XPath("//label[contains(text(),'transport any sold livestock or harvested crops more than 50 miles')]//following::button[1]"));
        public static Element TransportSoldLivestockMoreThan50MilesNoCTA => new Element(By.XPath("//label[contains(text(),'transport any sold livestock or harvested crops more than 50 miles')]//following::button[2]"));

        // Do you do any logging work? 
        public static Element DoYouDoLoggingWorkQST => new Element(By.XPath("//label[contains(text(),'do any logging work')]"));
        public static Element DoYouDoLoggingWorkYesCTA => new Element(By.XPath("//label[contains(text(),'do any logging work')]//following::button[1]"));
        public static Element DoYouDoLoggingWorkNoCTA => new Element(By.XPath("//label[contains(text(),'do any logging work')]//following::button[2]"));

        // Private Tutor
        // Are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?
        public static Element SecurityPersonnelMaintenanceJanitorialBusDriversOrFoodServiceWorkersQST => new Element(By.XPath("//label[text()='are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?']"));
        public static Element SecurityPersonnelMaintenanceJanitorialBusDriversOrFoodServiceWorkersYesCTA => new Element(By.XPath("//label[text()='are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?']//following::button[1]"));
        public static Element SecurityPersonnelMaintenanceJanitorialBusDriversOrFoodServiceWorkersNoCTA => new Element(By.XPath("//label[text()='are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?']//following::button[2]"));
        public static Element SecurityPersonnelMaintenanceJanitorialBusDriversOrFoodServiceWorkersPayrollAmount => new Element(By.XPath("//label[text()='are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?']"));

        // Cosmetics Manufacturing
        // Other than hand-held power tools, do you use any equipment or machinery?
        public static Element OtherHandHeldPowerToolsDoYouUseANyEquipmentQST => new Element(By.XPath("//label[contains(text(),'other than hand-held power tools')]"));
        public static Element OtherHandHeldPowerToolsDoYouUseANyEquipmentYesCTA => new Element(By.XPath("//label[contains(text(),'other than hand-held power tools')]//following::button[1]"));
        public static Element OtherHandHeldPowerToolsDoYouUseANyEquipmentNoCTA => new Element(By.XPath("//label[contains(text(),'other than hand-held power tools')]//following::button[2]"));

        // Do you handle, store, or transport any hazardous corrosive substances?
        public static Element HandleStoreOrTransportAnyHazardousQCorrosiveQST => new Element(By.XPath("//label[contains(text(),'handle, store, or transport any hazardous corrosive substances')]"));
        public static Element HandleStoreOrTransportAnyHazardousQCorrosiveYesCTA => new Element(By.XPath("//label[contains(text(),'handle, store, or transport any hazardous corrosive substances')]//following::button[1]"));
        public static Element HandleStoreOrTransportAnyHazardousQCorrosiveNoCTA => new Element(By.XPath("//label[contains(text(),'handle, store, or transport any hazardous corrosive substances')]//following::button[2]"));

        // Do you handle, store, or transport any explosives or blasting agents?
        public static Element HandleStoreOrTransportExplosivesOrBlastingAgentsQST => new Element(By.XPath("//label[contains(text(),'explosives or blasting agents')]"));
        public static Element HandleStoreOrTransportExplosivesOrBlastingAgentsYesCTA => new Element(By.XPath("//label[contains(text(),'explosives or blasting agents')]//following::button[1]"));
        public static Element HandleStoreOrTransportExplosivesOrBlastingAgentsNoCTA => new Element(By.XPath("//label[contains(text(),'explosives or blasting agents')]//following::button[2]"));

        // Do you handle, store, or transport any ammonium nitrate?
        public static Element HandleStoreOrTransportAmmoniumNitrateQST => new Element(By.XPath("//label[contains(text(),'ammonium nitrate')]"));
        public static Element HandleStoreOrTransportAmmoniumNitrateYesCTA => new Element(By.XPath("//label[contains(text(),'ammonium nitrate')]//following::button[1]"));
        public static Element HandleStoreOrTransportAmmoniumNitrateNoCTA => new Element(By.XPath("//label[contains(text(),'ammonium nitrate')]//following::button[2]"));

        // Swimming Pool Cleaning: With Installation
        // Do any employees clean or maintain pools at customer's locations? 
        public static Element CleanOrMaintainPoolsAtCustomersLocationsQST => new Element(By.XPath("//label[contains(text(),'clean or maintain pools')]"));
        public static Element CleanOrMaintainPoolsAtCustomersLocationsYesCTA => new Element(By.XPath("//label[contains(text(),'clean or maintain pools')]//following::button[1]"));
        public static Element CleanOrMaintainPoolsAtCustomersLocationsNoCTA => new Element(By.XPath("//label[contains(text(),'clean or maintain pools')]//following::button[2]"));
        public static Element CleanOrMaintainPoolsAtCustomersLocationsAnnualPayroll => new Element(By.XPath("//input[@id='cc_9014_Payroll']"));

        // Elevator Repair or Installation
        // Do you do new construction of elevators or escalators?
        public static Element DoYouDoNewConstructionOfElevatorsOrEscalatorsQST => new Element(By.XPath("//label[text()='do you do new construction of elevators or escalators?']"));
        public static Element DoYouDoNewConstructionOfElevatorsOrEscalatorsDD => new Element(By.XPath("//select[@id='uq574']"));

        // What is the highest in feet above ground level you work?
        public static Element WhatIsTheHighestFeetAboveGroundLevelYouWorkQST => new Element(By.XPath("//label[text()='what is the highest in feet above ground level you work?']"));
        public static Element WhatIsTheHighestFeetAboveGroundLevelYouWorkInput => new Element(By.XPath("//input[@id='uq357']"));

        // Auto Body Repair Shop
        // Do you dismantle, salvage, or junk vehicles?
        public static Element DoYouDismantleSalvageOrJunkVehiclesQST => new Element(By.XPath("//label[text()='do you dismantle, salvage, or junk vehicles?']"));
        public static Element DoYouDismantleSalvageOrJunkVehiclesYesCTA => new Element(By.XPath("//label[text()='do you dismantle, salvage, or junk vehicles?']//following::button[1]"));
        public static Element DoYouDismantleSalvageOrJunkVehiclesNoCTA => new Element(By.XPath("//label[text()='do you dismantle, salvage, or junk vehicles?']//following::button[2]"));

        // Auto Recycling
        // State requires that you buy coverage for officers that own less than 10% of the business.
        public static Element StateRequiresCoverageForOfficers => new Element(By.XPath("//p[contains(text(),'requires that you buy coverage for officers')]"));
        // Do any included owners/officers work only in sales? 
        public static Element IncludedOwnersOfficersWorkOnlySalesQST => new Element(By.XPath("//label[text()='do any included owners/officers work only in sales?']"));
        public static Element IncludedOwnersOfficersWorkOnlySalesDD => new Element(By.XPath("//label[text()='do any included owners/officers work only in sales?']//following::select[1]"));

        // Do any staff work only in sales?
        public static Element DoAnyStaffWorkOnlyInSalesQST => new Element(By.XPath("//label[text()='do any staff work only in sales?']"));
        public static Element DoAnyStaffWorkOnlyInSalesYesCTA => new Element(By.XPath("(//label[text()='do any staff work only in sales?']//following::button)[2]"));
        public static Element DoAnyStaffWorkOnlyInSalesNoCTA => new Element(By.XPath("(//label[text()='do any staff work only in sales?']//following::button)[3]"));
        public static Element DoAnyStaffWorkOnlyInSalesAnnualPayroll => new Element(By.XPath("//input[@id='cc_8046_Payroll']"));

        // Do you require all 3rd parties or 1099 workers doing work for you to have certificates of insurance? 
        public static Element DoYouRequireAll3rdPartiesOr1099DoingWorkHaveCertificateOfInsuarnceQST => new Element(By.XPath("//label[starts-with(text(),'do you require all 3rd parties/1099')]"));
        public static Element DoYouRequireAll3rdPartiesOr1099DoingWorkHaveCertificateOfInsuarnceDD => new Element(By.XPath("//label[starts-with(text(),'do you require all 3rd parties/1099')]//following::select[1]"));

        // What is the annual pay to 3rd parties or 1099 workers doing work for you?
        public static Element WhatIsTheAnnualPayyTo3rdPartiesOr1099WorkersDoingWorkForYouQST => new Element(By.XPath("//label[starts-with(text(),'what is the annual pay to 3rd parties or 1099 workers for towing')]"));
        public static Element WhatIsTheAnnualPayyTo3rdPartiesOr1099WorkersDoingWorkForYouAnnualPay => new Element(By.XPath("//label[starts-with(text(),'what is the annual pay to 3rd parties or 1099 workers for towing')]//following::input[1]"));

        // With Dropdown option - Do any included owners/officers only do general office work never writing up repair estimates?
        public static Element IncludedOwnersOfficersOnlyDoGeneralOfficeWorkNverWritingUpRepairEstimatesQST => new Element(By.XPath("//label[contains(text(),'included owners/officers only do general office work never writing up repair estimates')]"));
        public static Element IncludedOwnersOfficersOnlyDoGeneralOfficeWorkNverWritingUpRepairEstimatesDD => new Element(By.XPath("//label[contains(text(),'included owners/officers only do general office work never writing up repair estimates')]//following::select[1]"));

        //Transportation of Livestock, Equine, or Animals
        //Are there any employees that do not drive and do not load/unload goods?
        public static Element EmployeesDoNotDriveAndDoNotUnloadGoodsQST => new Element(By.XPath("//label[contains(text(), 'are there any employees that do not drive and do not load/unload goods?')]"));
        public static Element EmployeesDoNotDriveAndDoNotUnloadGoodsYes => new Element(By.XPath("//label[contains(text(), 'are there any employees that do not drive and do not load/unload goods?')]//following::button[1]"));
        public static Element EmployeesDoNotDriveAndDoNotUnloadGoodsNo => new Element(By.XPath("//label[contains(text(), 'are there any employees that do not drive and do not load/unload goods?')]//following::button[2]"));

        //Fuel Oil Dealer
        //Do you do any exploration, extraction, or refining of oil or oil related products?
        public static Element ExplorationExtractionOrRefiningOilQST => new Element(By.XPath("//label[contains(text(), 'do you do any exploration, extraction, or refining of oil or oil related products?')]"));
        public static Element ExplorationExtractionOrRefiningOilYes => new Element(By.XPath("//label[contains(text(), 'do you do any exploration, extraction, or refining of oil or oil related products?')]//following::button[1]"));
        public static Element ExplorationExtractionOrRefiningOilNo => new Element(By.XPath("//label[contains(text(), 'do you do any exploration, extraction, or refining of oil or oil related products?')]//following::button[2]"));

        //Amazon Delivery Service--------------------------------------------
        // Do you participate in a delivery service on behalf of Amazon.com, Inc.?
        public static Element AmazonDeliveryServiceQST => new Element(By.XPath("//label[contains(text(), 'do you participate in a delivery service on behalf of Amazon.com, Inc.?')]"));
        public static Element AmazonDeliveryServiceYes => new Element(By.XPath("//label[contains(text(), 'do you participate in a delivery service on behalf of Amazon.com, Inc.?')]//following::button[1]"));
        public static Element AmazonDeliveryServiceNo => new Element(By.XPath("//label[contains(text(), 'do you participate in a delivery service on behalf of Amazon.com, Inc.?')]//following::button[2]"));
        // Do you have a contract to haul for FedEx Corporation?
        public static Element ContractToHaulForFedExQST => new Element(By.XPath("//label[contains(text(),'do you have a contract to haul for FedEx Corporation?')]"));
        public static Element ContractToHaulForFedExYes => new Element(By.XPath("//label[contains(text(),'do you have a contract to haul for FedEx Corporation?')]//following::button[1]"));
        public static Element ContractToHaulForFedExNo => new Element(By.XPath("//label[contains(text(),'do you have a contract to haul for FedEx Corporation?')]//following::button[2]"));

        // What type of vehicle is primarily used for your business?
        public static Element TypeOfVehiclePrimarilyUsedQST => new Element(By.XPath("//label[contains(text(), 'what type of vehicle is primarily used for your business?')]"));
        public static Element TypeOfVehiclePrimarilyUsedDD => new Element(By.XPath("//label[contains(text(), 'what type of vehicle is primarily used for your business?')]//following::select[1]"));
        // What is the maximum weight (in lbs.) of any item being handled or delivered?
        public static Element MaximumWeightInLbsOfAnyItemBeingHandledOrDeliveredQST => new Element(By.XPath("//label[contains(text(),'what is the maximum weight (in lbs.) of any item being handled or delivered?')]"));
        public static Element MaximumWeightInLbsOfAnyItemBeingHandledOrDeliveredTxtBox => new Element(By.XPath("//label[contains(text(),'what is the maximum weight (in lbs.) of any item being handled or delivered?')]//following::input[1]"));

    }
}

