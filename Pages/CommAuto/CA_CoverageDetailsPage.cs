using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Coverage Details")]
    public sealed class CA_CoverageDetailsPage
    {
        /*
         * Headers---------------------------------------
         */

        //Details of Your Quote
        public static Element QuoteDetailsHeader => new Element(By.XPath("//h1[@data-qa='details-label']"));
        //One year coverage starting on [M/DD/YY].
        public static Element QuoteStartTitle => new Element(By.XPath("//h3[@data-qa='details-subLabel']"));
        //You can download the Certificate of Insurance (COI) and print your insurance cards as soon as your payment is processed.
        public static Element QuoteDetailsCopy => new Element(By.XPath("//p[@data-qa='details-content']"));
        //Return to Quote CTA
        public static Element ReturnToQuoteCTA => new Element(By.XPath("//button[@data-qa='return-button']"));

        /*
        * Coverages--------------------------------------
        */

        //Coverages
        public static Element CoveragesHeader => new Element(By.XPath("//h6[@data-qa='Coverages-section']"));
        //Specific events trigger coverage by this policy. 
        public static Element CoveragesSubHeader => new Element(By.XPath("//p[@data-qa='Coverages-text']"));

        //Auto Liability
        public static Element AutoLiabilityIcon => new Element(By.XPath("//mat-icon[@data-qa='Auto Liability-icon']"));
        public static Element AutoLiabilityHeader => new Element(By.XPath("//h6[@data-qa='Auto Liability-title']"));
        public static Element BIPDHeader => new Element(By.XPath("//ca-policy-coverage-descriptions//p[@data-qa='Bodily Injury Property Damage (BIPD)-header']"));
        public static Element BIPDCopy => new Element(By.XPath("//p[@data-qa='Bodily Injury Property Damage (BIPD)-text']"));

        //Cargo Liability
        public static Element CargoLiabIcon => new Element(By.XPath("//mat-icon[@data-qa='Cargo Liability-icon']"));
        public static Element CargoLiabHeader => new Element(By.XPath("//h6[@data-qa='Cargo Liability-title']"));
        public static Element CargoLiabTitle => new Element(By.XPath("//p[@data-qa='Cargo Coverage-header']"));
        public static Element CargoLiabCopy => new Element(By.XPath("//p[@data-qa='Cargo Coverage-text']"));

        //Medical Payments
        public static Element MedPaymentsIcon => new Element(By.XPath("//mat-icon[@data-qa='Medical Payments-icon']"));
        public static Element MedPaymentsHeader => new Element(By.XPath("//h6[@data-qa='Medical Payments-title']"));
        public static Element MedPaymentsTitle => new Element(By.XPath("//p[@data-qa='Medical Payments-header']"));
        public static Element MedPaymentsCopy => new Element(By.XPath("//p[@data-qa='Medical Payments-text']"));

        //Uninsured/Underinsured Motorist
        public static Element UnderUninsuredMotoristIcon => new Element(By.XPath("//mat-icon[@data-qa='Uninsured/Underinsured Motorist-icon']"));
        public static Element UnderUninsuredMotoristHeader => new Element(By.XPath("//h6[@data-qa='Uninsured/Underinsured Motorist-title']"));
        public static Element UnderinsuredHeader => new Element(By.XPath("//ca-policy-coverage-descriptions//p[@data-qa='Underinsured Motorists BI-header']"));
        public static Element UnderinsuredCopy => new Element(By.XPath("//p[@data-qa='Underinsured Motorists BI-text']"));
        public static Element UninsuredHeader => new Element(By.XPath("//ca-policy-coverage-descriptions//p[@data-qa='Uninsured Motorists BI-header']"));
        public static Element UninsuredBIPDHeader => new Element(By.XPath("//ca-policy-coverage-descriptions//p[@data-qa='Uninsured Motorists BIPD-header']"));
        public static Element UninsuredBIHeader => new Element(By.XPath("//ca-policy-coverage-descriptions//p[@data-qa='Uninsured Motorists BIPD-header']"));
        public static Element UninsuredCopy => new Element(By.XPath("//p[@data-qa='Uninsured Motorists BIPD-text']"));
        public static Element UninsuredBIPDCopy => new Element(By.XPath("//p[@data-qa='Uninsured Motorists BIPD-text']"));
        //Vehicle Coverage
        public static Element RentalReimbursementHeader => new Element(By.XPath("(//p[@data-qa='Rental Reimbursement-header'])[1]"));
        public static Element RentalReimbursementCopy => new Element(By.XPath("//p[@data-qa='Rental Reimbursement-text']"));
        public static Element VehicleCoverageIcon => new Element(By.XPath("//mat-icon[@data-qa='Vehicle Coverage-icon']"));
        public static Element VehicleCoverageHeader => new Element(By.XPath("(//h6[@data-qa='Vehicle Coverage-title'])[1]"));
        public static Element CollisionHeader => new Element(By.XPath("//p[@data-qa='Collision-header']"));
        public static Element CollisionCopy => new Element(By.XPath("//p[@data-qa='Collision-text']"));
        public static Element ComprehensiveHeader => new Element(By.XPath("//p[@data-qa='Comprehensive-header']"));
        public static Element ComprehensiveCopy => new Element(By.XPath("//p[@data-qa='Comprehensive-text']"));

        //Uncategorized
        public static Element UncategorizedIcon => new Element(By.XPath("//mat-icon[@data-qa='Uncategorized-icon']"));
        public static Element UncategorizedHeader => new Element(By.XPath("//h6[@data-qa='Uncategorized-title']"));
        public static Element TrailerInterHeader => new Element(By.XPath("//p[@data-qa='Trailer Interchange-header']"));
        public static Element TrailerInterCopy => new Element(By.XPath("//p[@data-qa='Trailer Interchange-text']"));
        public static Element InTowHeader => new Element(By.XPath("//p[@data-qa='In-Tow-header']"));
        public static Element InTowCopy => new Element(By.XPath("//p[@data-qa='In-Tow-text']"));

        //Coverages
        private static Element GetCoverageTitle(string coverageName) => new Element(By.XPath($"//h6[@data-qa='{coverageName}-title']"));
        private static Element GetCheckIcon(string coverageName) => new Element(By.XPath($"//mat-icon[@data-qa='{coverageName}-icon' and text()='check_circle']"));
        private static Element GetXIcon(string coverageName) => new Element(By.XPath($"//mat-icon[@data-qa='{coverageName}-icon' and text()='cancel icon']"));

        //Coverage Details
        private static Element GetDetailHeader(string detailName) => new Element(By.XPath($"//p[@data-qa='{detailName}-header']"));
        private static Element GetDetailText(string detailName) => new Element(By.XPath($"//p[@data-qa='{detailName}-text']"));

        public static CACoverageDetail GetCoverageDetail(string detailName) => new CACoverageDetail(GetDetailHeader(detailName), GetDetailText(detailName));
        public static CACoverageSection GetAppliedCoverageSection(string coverageName, params string[] detailNames)
        {
            var section = new CACoverageSection(coverageName, GetCoverageTitle(coverageName), GetCheckIcon(coverageName));
            section.Details.AddRange(detailNames.Select(GetCoverageDetail));
            return section;
        }
        
        public static CACoverageSection GetNotSelectedCoverageSection(string coverageName, params string[] detailNames)
        {
            var section = new CACoverageSection(coverageName, GetCoverageTitle(coverageName), GetXIcon(coverageName));
            section.Details.AddRange(detailNames.Select(GetCoverageDetail));
            return section;
        }

        /*
         * Drivers--------------------------------------
         */
        public static Element DriversHeader => new Element(By.XPath("//h6[@data-qa='Drivers-section']"));
        //Driver's Table
        //Header
        public static Element DriverNameHeader => new Element(By.XPath("//div[@data-qa='Name-column']"));
        public static Element DriverDOBHeader => new Element(By.XPath("//div[@data-qa='Date of Birth-column']"));
        public static Element DriverLicenseStateHeader => new Element(By.XPath("//div[@data-qa='Drivers License State-column']"));
        public static Element DriverLicenseNumberHeader => new Element(By.XPath("//div[@data-qa='Drivers License Number-column']"));
        //Contents
        //The values you can find from this are:
        // Full name, Date of Birth, Driver's License State, Driver's License Number
        public static Element GetDriverInfo(string valueExpectToSee) => new Element(By.XPath($"//ca-policy-details-centered-content//div[@data-qa='{valueExpectToSee}-columnValue']"));

        //Other Coverages Not Selected
        public static Element CoveragesNotSelectedHeader => new Element(By.XPath("//h6[@data-qa='Other Coverages Not Selected-section']"));
        //You did not choose to include these coverages in your policy.
        public static Element CoveragesNotSelectedSubHeader => new Element(By.XPath("//p[@data-qa='Other Coverages Not Selected-text']"));

        //All mappings here are done in relation to being after the "cancel icon" symbol
        //Collision/Comprehensive
        //Also has "NotVehicleCoverageIcon" and "NotVehicleCoverageHeader"
        public static Element NotCollisionHeader => new Element(By.XPath("//mat-icon[@data-qa='Vehicle Coverage-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Collision-header']"));
        public static Element NotCollisionCopy => new Element(By.XPath("//mat-icon[@data-qa='Vehicle Coverage-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Collision-text']"));
        public static Element NotComprehensiveHeader => new Element(By.XPath("//mat-icon[@data-qa='Vehicle Coverage-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Comprehensive-header']"));
        public static Element NotComprehensiveCopy => new Element(By.XPath("//mat-icon[@data-qa='Vehicle Coverage-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Comprehensive-text']"));
        //Medical
        public static Element NotMedPaymentsIcon => new Element(By.XPath("//mat-icon[@data-qa='Medical Payments-icon' and text()='cancel icon']"));
        public static Element NotMedPaymentsHeader => new Element(By.XPath("//mat-icon[@data-qa='Medical Payments-icon' and text()='cancel icon']//following-sibling::h6[@data-qa='Medical Payments-title']"));
        public static Element NotMedPaymentsTitle => new Element(By.XPath("//mat-icon[@data-qa='Medical Payments-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Medical Payments-header']"));
        public static Element NotMedPaymentsCopy => new Element(By.XPath("//mat-icon[@data-qa='Medical Payments-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Medical Payments-text']"));
        //Rental
        public static Element NotVehicleCoverageIcon => new Element(By.XPath("//mat-icon[@data-qa='Vehicle Coverage-icon' and text()='cancel icon']"));
        public static Element NotVehicleCoverageHeader => new Element(By.XPath("//mat-icon[@data-qa='Vehicle Coverage-icon' and text()='cancel icon']//following-sibling::h6[@data-qa='Vehicle Coverage-title']"));
        public static Element NotRentalReimbursementHeader => new Element(By.XPath("//mat-icon[@data-qa='Vehicle Coverage-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Rental Reimbursement-header']"));
        public static Element NotRentalReimbursementCopy => new Element(By.XPath("//mat-icon[@data-qa='Vehicle Coverage-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Rental Reimbursement-text']"));
        //Cargo
        public static Element NotCargoLiabIcon => new Element(By.XPath("//mat-icon[@data-qa='Cargo Liability-icon' and text()='cancel icon']"));
        public static Element NotCargoLiabHeader => new Element(By.XPath("//mat-icon[@data-qa='Cargo Liability-icon' and text()='cancel icon']//following-sibling::h6[@data-qa='Cargo Liability-title']"));
        public static Element NotCargoLiabTitle => new Element(By.XPath("//mat-icon[@data-qa='Cargo Liability-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Cargo Coverage-header']"));
        public static Element NotCargoLiabCopy => new Element(By.XPath("//mat-icon[@data-qa='Cargo Liability-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Cargo Coverage-text']"));
        //Trailer
        public static Element NotUncategorizedIcon => new Element(By.XPath("//mat-icon[@data-qa='Uncategorized-icon' and text()='cancel icon']"));
        public static Element NotUncategorizedHeader => new Element(By.XPath("//mat-icon[@data-qa='Uncategorized-icon' and text()='cancel icon']//following-sibling::h6[@data-qa='Uncategorized-title']"));
        public static Element NotTrailerInterHeader => new Element(By.XPath("//mat-icon[@data-qa='Uncategorized-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Trailer Interchange-header']"));
        public static Element NotTrailerInterCopy => new Element(By.XPath("//mat-icon[@data-qa='Uncategorized-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='Trailer Interchange-text']"));
        //In-Tow
        //Also has "NotUncategorizedIcon" and "NotUncategorizedHeader"
        public static Element NotInTowHeader => new Element(By.XPath("//mat-icon[@data-qa='Uncategorized-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='In-Tow-header']"));
        public static Element NotInTowCopy => new Element(By.XPath("//mat-icon[@data-qa='Uncategorized-icon' and text()='cancel icon']//ancestor::span//following-sibling::ul//p[@data-qa='In-Tow-text']"));

        /*
        * Risks Not Covered by Commercial Auto Insurance--------------------------------------
        */
        public static Element NotCoveredHeader => new Element(By.XPath("//h6[@data-qa='Risks Not Covered by Commercial Auto Insurance-section']"));
        public static Element NotCoveredCopy => new Element(By.XPath("//p[@data-qa='risks-not-covered-text']"));
        public static Element PropertyDamageHeader => new Element(By.XPath("//p[@data-qa='Intended-or-expected-prop-dmg-header']"));
        public static Element PropertyDamageCopy => new Element(By.XPath("//p[@data-qa='Intended-or-expected-prop-dmg-text']"));
        public static Element WCInjuriesHeader => new Element(By.XPath("//p[@data-qa='Injuries-under-WC-header']"));
        public static Element WCInjuriesCopy => new Element(By.XPath("//p[@data-qa='Injuries-under-WC-text']"));
        public static Element NonOwnedVehiclesHeader => new Element(By.XPath("//p[@data-qa='hired/non-owned-vehicles-header']"));
        public static Element NonOwnedVehiclesCopy => new Element(By.XPath("//p[@data-qa='hired/non-owned-vehicles-text']"));
        public static Element MobileEquipmentHeader => new Element(By.XPath("//p[@data-qa='mobile-equipment-operation-header']"));
        public static Element MobileEquipmentCopy => new Element(By.XPath("//p[@data-qa='mobile-equipment-operation-text']"));
        public static Element RacingHeader => new Element(By.XPath("//p[@data-qa='racing-header']"));
        public static Element RacingCopy => new Element(By.XPath("//p[@data-qa='racing-text']"));

        /*
         * Benefits---------------------------------------------------------
         */

        //Benefits
        public static Element BenefitsHeader => new Element(By.XPath("//h6[@data-qa='Benefits-section']"));
        public static Element BenefitsSubHeader => new Element(By.XPath("//p[@data-qa='Benefits-text']"));
        //Vehicle Table
        //Header
        public static Element VehicleVINHeader => new Element(By.XPath("//div[@data-qa='VIN-column']"));
        public static Element VehicleYMMHeader => new Element(By.XPath("//div[@data-qa='Year, Make, Model-column']"));
        public static Element CoverageHeader => new Element(By.XPath("//div[@data-qa='Coverage-column']"));
        public static Element VehicleLimitHeader => new Element(By.XPath("//div[@data-qa='Limit-column']"));
        public static Element VehicleDeductibleHeader => new Element(By.XPath("//div[@data-qa='Deductible-column']"));
        //Content
        //The values you can find from this are:
        //VIN, Year Make Model, Coverage, Limit, Deductible
        public static Element GetVehicleInfo(string valueExpectToSee) => new Element(By.XPath($"//div[@data-qa='{valueExpectToSee}-columnValue']"));

        //If a limit is shown above, the most we would pay for that vehicle or trailer...
        public static Element BenefitsCopy => new Element(By.XPath("//p[@data-qa='benefits-text']"));
        public static Element BenefitsBIPDHeader => new Element(By.XPath("(//p[@data-qa='Bodily Injury Property Damage (BIPD)-header'])[2]"));
        public static Element BenefitsBIPDCopy(string amount) => new Element(By.XPath($"//p[@data-qa='{amount}-text']"));
        public static Element BenefitsCargoHeader => new Element(By.XPath("//p[@data-qa='Cargo Coverage-header']"));
        //example: "$100,000 Limit / $1,000 Deductible"
        public static Element GetBenefitsCargoCopy(string expectedValue) => new Element(By.XPath($"//p[@data-qa='{expectedValue}-text']"));
        public static Element BenefitsMedicalPaymentsHeader => new Element(By.XPath("//p[@data-qa='Medical Payments-header']"));
        //example: "$500"
        public static Element GetBenefitsMedicalPaymentsCopy(string expectedValue) => new Element(By.XPath($"//p[@data-qa='{expectedValue}-text']"));
        public static Element BenefitsUnderinsuredHeader => new Element(By.XPath("(//p[@data-qa='Underinsured Motorists BI-header'])[2]"));
        public static Element BenefitsUnderinsuredCopy => new Element(By.XPath("(//p[@data-qa='Uninsured/Underinsured Motorist Coverage is Included-text'])[2]"));
        public static Element BenefitsUninsuredHeader => new Element(By.XPath("(//p[@data-qa='Uninsured Motorists BI-header'])[2]"));
        public static Element BenefitsUninsuredBIPDHeader => new Element(By.XPath("(//p[@data-qa='Uninsured Motorists BIPD-header'])"));
        public static Element BenefitsUninsuredCopy => new Element(By.XPath("(//p[@data-qa='Uninsured/Underinsured Motorist Coverage is Included-text'])[1]"));
        public static Element BenefitsRentalReinHeader => new Element(By.XPath("//p[@data-qa='Rental Reimbursement-header']"));
        //example: "$30 per day/30 days/$900 total"
        public static Element GetBenefitsRentalReinCopy(string expectedValue) => new Element(By.XPath($"//p[@data-qa='{expectedValue}-text']"));
        public static Element BenefitsRentalReinVehiclesIncluded => new Element(By.XPath("//span[@data-qa='vehicles-included-header']"));
        //example: "included-vehicle-FREIGHTLINER-CASCADIA 126"
        public static Element GetBenefitsRentalReinVehicle(string expectedValue) => new Element(By.XPath($"//li[starts-with(@data-qa,'included-vehicle-{expectedValue}_')]"));
        public static Element TrailerInterchangeHeader => new Element(By.XPath("//p[@data-qa='Trailer Interchange-header']"));
        //example: "$50,000 Limit / $1,000 Deductible"
        public static Element GetTrailerInterchangeCopy(string expectedValue) => new Element(By.XPath($"//p[@data-qa='{expectedValue}-text']"));
        /*
         * Premium-----------------------------------------------------------------------
         */
        public static Element PremiumHeader => new Element(By.XPath("//h6[@data-qa='Premium-section']"));
        public static Element PremiumCopy => new Element(By.XPath("//p[@data-qa='premium-text']"));
        public static Element PremiumMonthlyCopy => new Element(By.XPath("//p[@data-qa='premium-monthly-text']"));
        public static Element PremiumYearlyCopy => new Element(By.XPath("//p[@data-qa='premium-yearly-text']"));

        /*
         * Part of Berkshire Hathaway-------------------------------------------------
         */
        public static Element PartOfBHHeader => new Element(By.XPath("//h6[@data-qa='Part of Berkshire Hathaway-section']"));
        public static Element PartOfBHCopy => new Element(By.XPath("//p[@data-qa='part-of-BH-text']"));
        //Cancellation Policy
        public static Element CancellationHeader => new Element(By.XPath("//p[@data-qa='cancellation-policy-header']"));
        public static Element CancellationCopy => new Element(By.XPath("//p[@data-qa='cancellation-policy-text']"));
        //Terms and Conditions
        public static Element TACHeader => new Element(By.XPath("//p[@data-qa='t&c-header']"));
        public static Element TACCopyOne => new Element(By.XPath("//p[@data-qa='t&c-text1']"));
        public static Element TACCopyTwo => new Element(By.XPath("//p[@data-qa='t&c-text2']"));
        public static Element TACLink => new Element(By.XPath("//p[@data-qa='t&c-text2']//a"));

        //Get Plan CTA
        public static Element GetPlanCTA => new Element(By.XPath("//button[@data-qa='getPlan-button']"));
        //Return to Quote CTA
        public static Element FooterReturnToQuoteCTA => new Element(By.XPath("//button[@data-qa='return-button']"));
        //Proud to be part of Warren Buffett's Berkshire Hathaway Company
        public static Element ProudToBePart => new Element(By.XPath("//p[@data-qa='proud-to-be-section']"));
    }
}