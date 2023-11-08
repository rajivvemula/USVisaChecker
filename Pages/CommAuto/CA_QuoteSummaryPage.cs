using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Your Quote")]
    public sealed class CA_QuoteSummaryPage
    {
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(YourQuoteTitle);

        /*
        * Headers----------------------------------------------------------
        */

        //Your Quote
        public static Element YourQuoteTitle => new Element(By.XPath("//h1[@data-qa='your-quote-header']"));

        //One year coverage starting on xx/xx/xx.
        public static Element CoverageStartingSubTitle => new Element(By.XPath("//h3[@data-qa='quote-details-subHeader']"));

        //Monthly Label
        public static Element MonthlyQST => new Element(By.XPath("//mat-label[@data-qa='quote-details-slide-selector-left']"));
        //Monthly/Yearly Toggle
        public static Element MonthlyYearlyToggle => new Element(By.XPath("//mat-slide-toggle[@data-qa='quote-details-slide-selector']"));
        //Yearly Save X% Label
        public static Element YearlyQST  => new Element(By.XPath("//mat-label[@data-qa='quote-details-slide-selector-right']"));
        public static Element SaveTenPercent => new Element(By.XPath("//mat-label[@data-qa='quote-details-slide-selector-right2']"));
        public static Element TwelveMnthlyPmtsTitle => new Element(By.XPath("//h6[@data-qa='quote-details-12 monthly payments of-text']"));
        public static Element YearlySaveTitle => new Element(By.XPath("//h6[@data-qa='quote-details-savings-label']"));
        public static Element PaymentDueTitle => new Element(By.XPath("//span[@data-qa='quote-details-payment-amount']"));

        /*
        * Questions----------------------------------------------------------
        */

        //Policy Coverages
        public static Element PolicyCoveragesTitle => new Element(By.XPath("//h3[@data-qa='quote-details-policy-coverage-header']"));
        public static Element PremiumTitle => new Element(By.XPath("//h6[@data-qa='quote-details-premium-subHeader']"));

        //Bodily Injury and Property Damage Liability
        public static Element BodilyInjuryAndPropertyDamageQST => new Element(By.XPath("//label[contains(@data-qa, 'policyCoverage') and contains(@data-qa, '-label')]"));
        public static Element BodilyInjuryAndPropertyDamageDD => new Element(By.XPath("//mat-select[@data-qa='quote-details-policyCoverage-selectedOption-0']"));
        public static InputSection BodilyInjuryAndPropertyDamageInput => new MatDropdownInput(BodilyInjuryAndPropertyDamageDD)
            .AsAQuestion(BodilyInjuryAndPropertyDamageQST);
        public static Element BodilyInjuryAndPropertyDamageHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-policyCoverage-0']"));
        public static Element BodilyInjuryAndPropertyDamageHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-policyCoverage-0-label']"));
        public static Element bodilyInjuryAndPropertyDamageHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-policyCoverage-0']"));
        //The number amount displayed in bold
        public static Element BodilyInjuryAndPropertyPremiumTitle => new Element(By.XPath("//label[@data-qa='quote-details-BI/PD0-premiumAmount']"));

        //Medical Payments
        public static Element PolicyMedQST => new Element(By.XPath("//label[starts-with(@data-qa,'policyCoverage-') and text()=' Medical Payments ']"));
        public static Element PolicyMedDD => new Element(By.XPath("(//mat-select[starts-with(@data-qa,'quote-details-policyCoverage-selectedOption')])[2]"));
        public static InputSection PolicyMedInput => new MatDropdownInput(PolicyMedDD)
            .AsAQuestion(PolicyMedQST);
        public static Element PolicyMedHelper => new Element(By.XPath("//button[starts-with(@data-qa,'buttonShowHelpToggle-policyCoverage')]"));
        public static Element PolicyMedHelperText => new Element(By.XPath("//p[starts-with(@data-qa,'bbHelpText-policyCoverage-') and text()='Medical payments coverage helps pay for medical expenses incurred by you or your passengers in an accident.']"));
        public static Element PolicyMedHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-policyCoverage-1']"));
        public static Element PolicyMedPremiumTitle => new Element(By.XPath("//label[@data-qa='quote-details-Medical1-premiumAmount']"));

        //Vehicle Coverage
        //Select the physical damage deductibles for each vehicle.  
        //These deductibles are required if you want damage to your vehicle from incidents like collision, fire, or theft to be covered.
        //You will still have liability coverage if you opt out.
        public static Element VehicleCoverageHeader => new Element(By.XPath("//h3[@data-qa='quote-details-vehicleCoverage-header']"));
        public static Element VehicleCoverageQST => new Element(By.XPath("//p[@data-qa='quote-details-vehicleCoverage-subHeader']"));
        //Each of these are tied to the specific covered vehicle
        //Number is ordered number added in Vehicles page
        public static Element VehicleLabel(int vehicleNumber) => new Element(By.XPath($"//p[starts-with(@data-qa,'quote-details-Comp/Collision') and contains(@data-qa,'-vehicle-{vehicleNumber}')]"));
        public static Element VehiclePremium(int vehicleNumber) => new Element(By.XPath($"//p[starts-with(@data-qa,'quote-details-Comp/Collision') and contains(@data-qa,'-premium-{vehicleNumber}')]"));
        public static Element VehicleLimitLabel(int vehicleNumber) => new Element(By.XPath($"//label[@data-qa='vehicleLimit-{vehicleNumber}-label']"));
        public static Element VehicleCoverageDD(int vehicleNumber) => new Element(By.XPath($"//mat-select[@data-qa='quote-details-vehicleCoverage-selectedOption-{vehicleNumber}']"));
        public static InputSection VehicleCoverageInput(int vehicleNumber) => new MatDropdownInput(VehicleCoverageDD(vehicleNumber))
                .AsAQuestion(VehicleCoverageQST)
                .WithExtraText(VehicleCoverageHeader, VehicleLabel(vehicleNumber), VehicleLimitLabel(vehicleNumber));
        public static Element VehicleLimitHelper(int vehicleNumber) => new Element(By.XPath($"//button[@data-qa='buttonShowHelpToggle-vehicleLimit-{vehicleNumber}']"));
        public static Element VehicleLimitHelperText(int vehicleNumber) => new Element(By.XPath($"//p[@data-qa='bbHelpText-vehicleLimit-{vehicleNumber}-label']"));
        public static Element VehicleLimitHelperX(int vehicleNumber) => new Element(By.XPath($"//button[@data-qa='buttonClose-bbHelpText-vehicleLimit-{vehicleNumber}']"));

        //Add-On Coverages
        public static Element AddOneCoveragesTitle => new Element(By.XPath("//h3[@data-qa='quote-details-addOnCoverages-header']"));
        //Check the box for each coverage you want added to your policy.
        public static Element AddOneCoveragesSubTitle => new Element(By.XPath("//p[@data-qa='quote-details-addOnCoverages-subHeader']"));

        //Uninsured/Underinsured Motorist
        public static Element UninsuredUnderInsMotoristQST => new Element(By.XPath("//p[@data-qa='quote-details-UM UIM-0-label']"));
        public static Element UninsuredUnderInsMotoristPremium => new Element(By.XPath("//span[@data-qa='quote-details-UM UIM-premium']"));
        public static Element UninsuredUnderInsMotoristChkbox => new Element(By.XPath("//mat-checkbox[@data-qa='quote-details-UM UIM-checkbox-0']"));
        public static Element UninsuredUnderInsMotoristHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-aoc-item-0']"));
        public static Element UninsuredUnderInsMotoristHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-aoc-item-0-label']"));
        public static Element UninsuredUnderInsMotoristHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-aoc-item-0']"));

        //Medical Payments
        public static Element MedicalPaymentsQST => new Element(By.XPath("//p[starts-with(@data-qa,'quote-details-Medical') and contains(@data-qa,'-label')]"));
        public static Element MedicalPaymentsChkbox => new Element(By.XPath("//mat-checkbox[starts-with(@data-qa,'quote-details-Medical-checkbox-')]"));
        public static Element MedicalPaymentsDD => new Element(By.XPath("//mat-select[@data-qa='quote-details-Medical-selectedOption']"));
        public static InputSection MedicalPaymentsInput => new CACoverageCheckboxDropdownInput(MedicalPaymentsChkbox, MedicalPaymentsDD)
            .AsAQuestion(MedicalPaymentsQST);
        public static Element MedicalPaymentsHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-aoc-item-1']"));
        public static Element MedicalPaymentsHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-aoc-item-1-label']"));
        public static Element MedicalPaymentsHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-aoc-item-1']"));
        public static Element MedicalPaymentsPremiumTitle => new Element(By.XPath("//span[@data-qa='quote-details-Medical-premium']"));

        //Cargo Liability
        public static Element CargoLiabilityQST => new Element(By.XPath("//p[starts-with(@data-qa,'quote-details-Cargo') and contains(@data-qa,'-label')]"));
        public static Element CargoLiabilityChkbox => new Element(By.XPath("//mat-checkbox[starts-with(@data-qa,'quote-details-Cargo-checkbox-')]"));
        public static Element CargoLiabilityDD => new Element(By.XPath("//mat-select[@data-qa='quote-details-Cargo-selectedOption']"));
        public static InputSection CargoLiabilityInput => new CACoverageCheckboxDropdownInput(CargoLiabilityChkbox, CargoLiabilityDD)
            .AsAQuestion(CargoLiabilityQST);
        public static Element CargoLiabilityHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-aoc-item-2']"));
        public static Element CargoLiabilityHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-aoc-item-2-label']"));
        public static Element CargoLiabilityHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-aoc-item-2']"));
        public static Element CargoLiabilityPremiumTitle => new Element(By.XPath("//span[@data-qa='quote-details-Cargo-premium']"));

        //TrailerInterchange
        public static Element TrailerInterchangeQST => new Element(By.XPath("//p[starts-with(@data-qa,'quote-details-TrailerInterchange') and contains(@data-qa,'-label')]"));
        public static Element TrailerInterchangeChkbox => new Element(By.XPath("//mat-checkbox[@data-qa='quote-details-TrailerInterchange-checkbox-4']"));
        public static Element TrailerInterchangeDD => new Element(By.XPath("//mat-select[@data-qa='quote-details-TrailerInterchange-selectedOption']"));
        public static InputSection TrailerInterchangeInput => new CACoverageCheckboxDropdownInput(TrailerInterchangeChkbox, TrailerInterchangeDD)
            .AsAQuestion(TrailerInterchangeQST);
        public static Element TrailerInterchangeHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-aoc-item-4']"));
        public static Element TrailerInterchangeHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-aoc-item-4-label']"));
        public static Element TrailerInterchangeX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-aoc-item-4']"));
        public static Element TrailerInterchangePremiumTitle => new Element(By.XPath("//span[@data-qa='quote-details-TrailerInterchange-premium']"));

        //In-Tow
        public static Element InTowQST => new Element(By.XPath("//p[starts-with(@data-qa,'quote-details-Intow') and contains(@data-qa,'-label')]"));
        public static Element InTowChkbox => new Element(By.XPath("//mat-checkbox[starts-with(@data-qa,'quote-details-Intow-')]"));
        public static Element InTowDD => new Element(By.XPath("//mat-select[@data-qa='quote-details-Intow-selectedOption']"));
        public static InputSection InTowInput => new CACoverageCheckboxDropdownInput(InTowChkbox, InTowDD)
            .AsAQuestion(InTowQST);
        public static Element InTowHelper => new Element(By.XPath("//button[contains(@data-qa,'buttonShowHelpToggle-aoc-item-4')]"));
        public static Element InTowHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-aoc-item-3-label']"));
        public static Element InTowHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-aoc-item-3']"));

        //Rental Reimbursement
        public static Element RentalReimbursementQST => new Element(By.XPath("//p[starts-with(@data-qa,'quote-details-RentalReimbursement') and contains(@data-qa,'-label')]"));
        public static Element RentalReimbursementChkbox => new Element(By.XPath("//mat-checkbox[starts-with(@data-qa,'quote-details-RentalReimbursement-')]"));
        public static Element RentalReimbursementDD => new Element(By.XPath("//mat-select[@data-qa='quote-details-RentalReimbursement-selectedOption']"));
        public static InputSection RentalReimbursementInput => new CACoverageCheckboxDropdownInput(RentalReimbursementChkbox, RentalReimbursementDD)
            .AsAQuestion(RentalReimbursementQST);
        public static Element RentalReimbursementHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-aoc-item-2']"));
        public static Element RentalReimbursementHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-aoc-item-5-label']"));
        public static Element RentalReimbursementHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-aoc-item-5']"));
        public static Element RentalReimbursementPremiumTitle => new Element(By.XPath("//span[@data-qa='quote-details-RentalReimbursement-premium']"));

        //Total Annual Premium
        public static Element TotalAnnualPremiumTitle => new Element(By.XPath("//h6[@data-qa='quote-details-totalPremium-header']"));
        //$#,###.##
        public static Element TotalAnnualPremiumAmount => new Element(By.XPath("//h6[@data-qa='quote-details-totalPremium-amount']"));

        //View Coverage Details
        public static Element ViewCoverageDetailsCTA => new Element(By.XPath("//button[@data-qa='viewCoverageDetail-btn']"));

        //Purchase
        public static Element PurchaseCTA => new Element(By.XPath("//button[@data-qa='purchaseCoverage-btn'] | //button[@data-qa='bbnav-navNext-tablet']"));
        //Update Quote CTA - Top Button
        public static Element UpdateQuoteTopCTA => new Element(By.XPath("//button[@data-qa='quote-details-updatequote-btn']"));
        //Update QUOTE CTA - Bottom Button
        public static Element UpdateQuoteBottomCTA => new Element(By.XPath("//button[@data-qa='bottomUpdateQuote-btn']"));
        //Toast that appears after clicking the Update Quote button (appears at same time as loading "b")
        public static Element UpdateQuoteInProgressToast => new Element(By.XPath("//simple-snack-bar/div[contains(text(), 'Recalculating your quote')]"));
        //After quote is successfully updated, it shows a toast modal saying it was successful
        public static Element UpdateQuoteSuccessfulToast => new Element(By.XPath("//simple-snack-bar/div[contains(text(), 'Your quote has been updated.')]"));


        //Update Your Quote Modal
        public static Element UpdateQuoteModal_YourQuoteID => new Element(By.XPath("//p[@data-qa='modal-preTitle']"));
        public static Element UpdateQuoteModalTitle => new Element(By.XPath("//h2[@data-qa='Update Your Quote-header']"));
        public static Element UpdateQuoteModalCopy => new Element(By.XPath("//div[@data-qa='email-link-later-text']"));
        public static Element UpdateQuoteModalUpdateQuoteBTN => new Element(By.XPath("//button[@data-qa='modal-primary-btn']"));
        public static Element UpdateQuoteModalCancelBTN => new Element(By.XPath("//button[@data-qa='modal-secondary-btn']"));
        public static Element UpdateQuoteModalHelperX => new Element(By.XPath("//a[@data-qa='close-modal']"));

        //Questions? Your license team is here to help.
        public static Element QuestionsHeader => new Element(By.XPath("//h3[@data-qa='contact-header']"));
        //You can contact us at:
        public static Element ContactUsSubHeader => new Element(By.XPath("//p[@data-qa='contact-subheader']"));
        //expert@biberk.com
        public static Element BiberkEmailAddress => new Element(By.XPath("//div[@data-qa='contact-email']"));
        //1-844-472-0967
        public static Element BiberkPhoneNumber => new Element(By.XPath("//a[@data-qa='contact-phone-link']"));
        //Mon-Fri, 8AM-9PM ET
        public static Element BiberkHelpHours => new Element(By.XPath("//p[@data-qa='contact-hours']"));
        //Customer Reviews
        public static Element CustomerReviews => new Element(By.XPath("//h3[@data-qa='customerReviews-header']"));
        //Average Stars **** 4.9/5
        public static Element AvgStars => new Element(By.XPath("//h3[@data-qa='averageRating-stars']"));
        //Calculated from ##### customer reviews over the last 12 months.
        public static Element CalculatedReviewsLabel => new Element(By.XPath("//p[@data-qa='calculatedCustomerReview-text']"));

        //Toast in progress
        public static Element InProgressToast => new Element(By.XPath("//div[contains(@class, 'toast-info')]"));
        //Toast Completed
        public static Element CompletedToast => new Element(By.XPath("//div[contains(@class,'toast-success')]"));

        //Email my quote
        public static Element EmailPolicyQuoteCTA => new Element(By.XPath("//button[@data-qa='sfl-link']"));

        //Certificat of Insurance
        public static Element COIHeader => new Element(By.XPath("//h3[@data-qa='coi-header']"));
        public static Element COIContent => new Element(By.XPath("//p[@data-qa='coi-content']"));
        
        public static List<Element> ErrorElements = new List<Element>
        {
            BodilyInjuryAndPropertyDamageHelper,
            UninsuredUnderInsMotoristHelper,
            MedicalPaymentsHelper,
            CargoLiabilityHelper,
            TrailerInterchangeHelper,
            InTowHelper,
            RentalReimbursementHelper,
        };
    }
}