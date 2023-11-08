using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.BSP
{
    public class BSP_CoveragePageCA
    {

        [Binding]
        public sealed class CoveragePageCA
        {
            /*Policy Start Date Text*/
            public static Element PolicyStartDate => new Element(By.XPath("//p[@data-qa='policy-start-date-text']"));

            /*Medical payments Fields*/
            public static Element MedicalText => new Element(By.XPath("//p[@data-qa='coverage-medical-payments-text']"));
            public static Element MedicalValueText => new Element(By.XPath("//ul[@data-qa='coverage-medical-payments-value-text']"));

            /*Rental Reimbursement Fields*/
            public static Element RentalText => new Element(By.XPath("//p[@data-qa='coverage-rental-reimbursement-text']"));
            public static Element RentalValueText => new Element(By.XPath("//ul[@data-qa='coverage-rental-reimbursement-value-text']"));

            /*In-Tow Fields*/
            public static Element InTowText => new Element(By.XPath("//p[@data-qa='coverage-intow-text']"));
            public static Element InTowValueText => new Element(By.XPath("//ul[@data-qa='coverage-intow-value-text']"));

            /*Bodily Injury Coverage*/
            public static Element BodilyInjuryText => new Element(By.XPath("//p[@data-qa='coverage-bodily-injury-text']"));

            /*Bodily Injury Value Text*/
            public static Element BodilyInjuryValueText => new Element(By.XPath("//ul[@data-qa='coverage-bodily-injury-value-text']"));

            /*Uninsured Motorist*/
            public static Element UninsuredMotoristText => new Element(By.XPath("//p[@data-qa='coverage-uninsured-motorists-text']"));

            /*Uninsured Motorist Value Text*/
            public static Element UninsuredMotoristValueText => new Element(By.XPath("//ul[@data-qa='coverage-uninsured-motorists-value-text']"));

            /*Comprehensive Coverage*/
            public static Element ComprehensiveCoverageText => new Element(By.XPath("//p[@data-qa='coverage-comprehensive-text']"));

            /*Comprehensive Coverage Value Text*/
            public static Element ComprehensiveCoverageValueText => new Element(By.XPath("//ul[@data-qa='coverage-comprehensive-value-text']"));

            /*CollisionCoverage*/
            public static Element CollisionCoverageText => new Element(By.XPath("//p[@data-qa='coverage-collision-text']"));

            /*Collision Value Text*/
            public static Element CollisionCoverageValueText => new Element(By.XPath("//ul[@data-qa='coverage-collision-value-text']"));

            /*Personal Injury*/
            public static Element PersonalInjuryText => new Element(By.XPath("//p[@data-qa='coverage-personal-injury-text']"));

            /*Personal Injury Value Text*/
            public static Element PersonalInjuryValueText => new Element(By.XPath("//ul[@data-qa='coverage-personal-injury-value-text']"));

            /*Trailer Interchange Fields*/
            public static Element TrailerInterchangeText => new Element(By.XPath("//p[@data-qa='coverage-trailer-interchange-text']"));
            public static Element TrailerInterchangeValueText => new Element(By.XPath("//ul[@data-qa='coverage-trailer-interchange-value-text']"));

            /*Cargo Coverage Fields*/
            public static Element CargoCoverageText => new Element(By.XPath("//p[@data-qa='coverage-cargo-coverage-text']"));
            public static Element CargoCoverageValueText => new Element(By.XPath("//ul[@data-qa='coverage-cargo-coverage-value-text']"));

            /*Benefits Header*/
            public static Element BenefitsHeaderText => new Element(By.XPath("//p[@data-qa='benefits-header-text']"));

            /*Vehicle Subheader*/
            public static Element VehicleSubheaderText => new Element(By.XPath("//ul[@data-qa='vehicle-subheader-text']"));

            /*VIN Column Head*/
            public static Element VINColumnText => new Element(By.XPath("//p[@data-qa='benefits-vin-text']"));

            /*Year, Make, Model Column Head*/
            public static Element MMYColumnText => new Element(By.XPath("//p[@data-qa='benefits-ymm-text']"));

            /*CoverageColumnHead*/
            public static Element CoverageColumnText => new Element(By.XPath("//p[@data-qa='benefits-coverage-text']"));

            /*Limit Column Head*/
            public static Element LimitColumnText => new Element(By.XPath("//p[@data-qa='benefits-limit-text']"));

            /*DeductibleColumnHead*/
            public static Element DeductibleColumnText => new Element(By.XPath("//p[@data-qa='benefits-deductible-text']"));


        }/*Benefits VIN Text fields*/
        public static Element VINTextValue(int index) => new Element(By.XPath($"//td[@data-qa='benefits-vin-text-value-{index}']"));
       

        /*MMY Value Fields*/
        public static Element MMYTextValue_(int index) => new Element(By.XPath($"//td[@data-qa='benefits-ymm-text-value-{index}']"));

        /*Coverage Value Text Fields*/
        public static Element CoverageTextValue_(int index) => new Element(By.XPath($"//td[@data-qa='benefits-coverage-text-value-{index}']"));

        /*Limits Text Value Fields*/
        public static Element LimitsTextValue_(int index) => new Element(By.XPath($"//td[@data-qa='benefits-limit-text-value-{index}']"));

        /*Deductible Text Value Fields*/
        public static Element DeductibleTextValue_(int index) => new Element(By.XPath($"//td[@data-qa='benefits-deductible-text-value-{index}']"));

        /*Driver Subheader*/
        public static Element DriverSubheader => new Element(By.XPath("//p[@data-qa='driver-subheader-text']"));

        /*Driver Column Text*/
        public static Element DriverColumnText => new Element(By.XPath("//p[@data-qa='driver-name-text']"));

        /*DOB Column Text*/
        public static Element DOBColumnText => new Element(By.XPath("//p[@data-qa='driver-dob-text']"));

        /*State DL Number Text*/
        public static Element DLStateColumnText => new Element(By.XPath("//p[@data-qa='driver-license-number-text']"));

        /*CDL Text*/
        public static Element CDLColumnText => new Element(By.XPath("//p[@data-qa='driver-cdl-text']"));

        /*Violation Text*/
        public static Element ViolationColumnText => new Element(By.XPath("//p[@data-qa='driver-violation-text']"));


        /*Driver Value Text Fields*/
        public static Element NameValueText_(int index) => new Element(By.XPath($"//td[@data-qa='driver-name-value-text-{index}']"));

        /*DOB Value Text Fields*/
        public static Element DOBValueText_(int index) => new Element(By.XPath($"//td[@data-qa='driver-dob-value-text-{index}']"));

        /*DL Text Value Fields*/
        public static Element DLValueText_(int index) => new Element(By.XPath($"//td[@data-qa='driver-license-state-value-text-{index}']"));

        /*DL Number Text Value Fields*/
        public static Element DLNumberValueText_(int index) => new Element(By.XPath($"//td[@data-qa='driver-license-number-value-text-{index}']"));

        /*CDL Value Text Fields*/
        public static Element CDLValueText_(int index) => new Element(By.XPath($"//td[@data-qa='driver-cdl-value-text-{index}']"));

        /*Violations Text Value Fields*/
        public static Element ViolationsValueText_(int index) => new Element(By.XPath($"//td[@data-qa='driver-violation-value-text-{index}']"));

        /*Limits Subheader*/
        public static Element LimitsColumnText => new Element(By.XPath("//h4[@data-qa='limit-subheader-text']"));

        /*Limit Bodily Injury Header*/
        public static Element BodilyLimitsText => new Element(By.XPath("//p[@data-qa='limit-bodily-injury-text']"));

        /*Bodily Limit Value Text*/
        public static Element BodilyLimitsValueText => new Element(By.XPath("//li[@data-qa='limit-bodily-injury-value-text']"));

        /*Uninsured Motorist Header*/
        public static Element UninsuredText => new Element(By.XPath("//p[@data-qa='limit-uninsured-motorists-text']"));

        /*Uninsured Motorist Value Text*/
        public static Element UninsuredValueText => new Element(By.XPath("//li[@data-qa='limit-uninsured-motorists-value-text']"));

        /*PIP Header Text*/
        public static Element PIPText => new Element(By.XPath("//p[@data-qa='limit-personal-injury-text']"));

        /*PIP Value Text*/
        public static Element PIPValueText => new Element(By.XPath("//ul[@data-qa='limit-personal-injury-value-text']"));
    }
}
