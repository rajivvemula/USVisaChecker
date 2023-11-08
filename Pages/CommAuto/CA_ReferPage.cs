using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Pages.Other;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Referral")]
    public sealed class CA_ReferPage
    {
        /*
        * Headers----------------------------------------------------------
        */

        //Your Quote is Nearly Ready
        public static Element YourQuoteIsNearlyReadyTitle => new Element(By.XPath("//h1[@data-qa='refer-thankyou-title']"));
       
        //We're eager to provide your quote but need to get a little more information.
        public static Element EagerToProvideQuoteNeedInfo => new Element(By.XPath("//p[@data-qa='refer-subtitle']"));

        /*
         * Referral Reasons-------------------------------------------------
         */

        //Referral Reasons Header
        public static Element ReferralReasonsTitle => new Element(By.XPath("//h6[@data-qa='refer-reasons-header']"));

        //Referral Reasons List
        //There is already more than 1 claim
        public static Element MoreThanOneClaimReferReason => new Element(By.XPath("//h6[@data-qa='refer-reason-There is already more than 1 claim']"));
        //-How many auto insurance claims did your business file in the last 3 years? 
        public static Element HowManyAutoClaimsReferReason => new Element(By.XPath("//h6[starts-with(@data-qa,'refer-reason-- How many auto insurance claims did your business file in the last 3 years?')]"));
        //Established business with 6 or more power units requires loss run analysis
        public static Element SixOrMorePowerUnitsReferReason => new Element(By.XPath("//h6[@data-qa='refer-reason-Established business with 6 or more power units requires loss run analysis.']"));
        //Referred due to discrepancy between number of drivers and number of vehicles. Please explain.
        public static Element NumberOfDriversVehiclesReferReason => new Element(By.XPath("//h6[@data-qa='refer-reason-Referred due to discrepancy between number of drivers 1 and number of vehicles 6. Please explain.']"));
        //Single driver on policy doesn't match governing state
        public static Element DriverGoverningStateReferReason => new Element(By.XPath("//h6[@data-qa=\"refer-reason-There must be at least one driver in the same state as the quote or policy's governing state\"]"));
        //Referred due to no CDL but heavy truck. Are all drivers scheduled?
        public static Element NoCDLHeavyTruckReferReason => new Element(By.XPath("//h6[@data-qa='refer-reason-Referred due to no CDL but heavy truck. Are all drivers scheduled?']"));
        //USDOT Number Provided isn't active
        //sample USDOT: 355352
        public static Element USDOTNumberInactiveReferReason => new Element(By.XPath("//h6[@data-qa=\"refer-reason-USDOT Number Provided isn't active\"]"));
        //At least one vehicle on the policy has a stated amount of $0.
        public static Element VehicleStatedAmountReferReason => new Element(By.XPath("//h6[@data-qa='refer-reason-At least one vehicle on the policy has a stated amount of $0.']"));
        //Vehicle Schedule is blank.
        public static Element VehicleScheduleBlankReferReason => new Element(By.XPath("//h6[@data-qa='refer-reason-Vehicle Schedule is blank.']"));
        //Suspect higher actual radius than state on application. Less than 50 miles with federal filing. Federal
        //filing not needed not needed for intrastate transportation. Either increase radius or remove federal filing.
        public static Element HigherActualRadiusReferReason => new Element(By.XPath("//h6[@data-qa='refer-reason-Suspect higher actual radius than stated on application.  Less than 50 miles with federal filing.  Federal filing not needed for intrastate transportation.  Either increase radius or remove federal filing.']"));
        //Referral due to inconsistencies between U.S.DOT reported information and application. Number of trucks or
        //cost of hire expected to be around CAB_Trucks and scheduled trucks or cost of hire should be commesurate.
        public static Element InconsistenciesUSDOTReportedInfoReferReason => new Element(By.XPath("//h6[@data-qa='refer-reason-Referral due to inconsistencies between U.S. DOT reported information and application. Number of trucks or cost of hire expected to be around CAB_Trucks and scheduled trucks or cost of hire should be commensurate.']"));
        //Potential Preferred Trucking Class for this risk, please review and add if applicable.
        public static Element PreferredTruckingClassReferReason => new Element(By.XPath("//h6[@data-qa='refer-reason-Potential Preferred Trucking Class for this risk, please review and add if applicable.']"));

        /*
         * Details for UW Text box & Helper Text-------------------------------------
         */

        //Details for UW Text Box
        public static Element DetailsForUWTxtbox => new Element(By.XPath("//textarea[@data-qa='uwMessage']"));
        //Do not include confidential information (SSN, Account #, Routing #, etc)
        public static Element DetailsForUWTxtBelow => new Element(By.XPath("//mat-hint[@data-qa='uwMessage-hint']"));
        //Details for UW Character Count 0 / 2,000
        public static Element DetailsForUWTxtBelowCharCount => new Element(By.XPath("//mat-hint[@data-qa='uwMessage-count']"));
        public static Element DetailsForUWError => new Element(By.XPath("//mat-error[@data-qa='uwMessage-error']"));


        /*
        * Referral Page due to choosing "I can't find my business description" MadLibs-------------------------------------
        * this is mapped from the new path:  /get-a-quote-new
        */
        public static Element ThanksForYourInterest => new Element(By.XPath("//h1[@data-qa='page-title']"));
        public static Element ThanksForYourInterestParagraph => new Element(By.XPath("//h6[@data-qa='page-message']"));

        public static Element NameOfBusiness => new Element(By.XPath("//label[@data-qa='businessName-label']"));
        public static Element NameOfBusinessTxtbox => new Element(By.XPath("//input[@data-qa='businessName']"));
        public static Element NameOfBusinessTextBelow => new Element(By.XPath("//mat-hint[@data-qa='businessName-hint']"));
        public static Element NameOfBusinessError => new Element(By.XPath("//mat-error[@data-qa='businessName-error']"));

        public static Element DBA => new Element(By.XPath("//label[@data-qa='dbaName-label']"));
        public static Element DBATxtbox => new Element(By.XPath("//input[@data-qa='dbaName']"));
        public static Element DBATextBelow => new Element(By.XPath("//mat-hint[@data-qa='dbaName-hint']"));

        public static Element ContactFirstNameTxtbox => new Element(By.XPath("//input[@data-qa='firstName']"));
        public static Element ContactFirstNameTxtboxOverlay => new Element(By.XPath("//mat-label[contains(text(),'Contact First Name')]"));
        public static Element ContactFirstNameError => new Element(By.XPath("//mat-error[@data-qa='firstName-error']"));
        public static Element ContactLastNameTxtbox => new Element(By.XPath("//input[@data-qa='lastName']"));
        public static Element ContactLastNameTxtboxOverlay => new Element(By.XPath("//mat-label[contains(text(),'Contact Last Name')]"));
        public static Element ContactLastNameError => new Element(By.XPath("//mat-error[@data-qa='lastName-error']"));
        public static Element ContactEmailTxtbox => new Element(By.XPath("//input[@data-qa='email']"));
        public static Element ContactEmailError => new Element(By.XPath("//mat-error[@data-qa='email-error']"));
        public static Element ContactBusPhoneTxtbox => new Element(By.XPath("//input[@data-qa='phone']"));
        public static Element ContactBusPhoneError => new Element(By.XPath("//mat-error[@data-qa='phone-error']"));
        public static Element ContactBusWebsiteTxtbox => new Element(By.XPath("//input[@data-qa='url']"));
        public static Element ContactBusWebsiteTextBelow => new Element(By.XPath("//mat-hint[@data-qa='url-error']"));

        public static Element WellBeInTouchCTA => new Element(By.XPath("//button[@data-qa='next-button']"));


        /*
        * Page CTA----------------------------------------------------------
        */
        //Submit to Underwriting Button
        public static Element SubmitToUw => new Element(By.XPath("//button[@data-qa='uwsubmit']"));
    }
}
