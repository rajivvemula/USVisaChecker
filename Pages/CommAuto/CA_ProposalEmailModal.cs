using BiBerkLOB.Pages.Other;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.CommAuto;

[Mapping("CA Proposal Email")]
public class CA_ProposalEmailModal
{
    //Your QuoteID: #######
    public static Element QuoteIDTitle => new Element(By.XPath("//p[@data-qa='modal-preTitle']"));
    //Close Button - X
    public static Element ProposalClose => new Element(By.XPath("//button[@data-qa='close-modal']"));
    //Email Your Policy Quote
    public static Element ProposalModalHeader => new Element(By.XPath("//h2[@data-qa='Email Your Policy Quote-header']"));
    //Your Commercial Auto Plan
    public static Element ProposalModalTitle => new Element(By.XPath("//h3[@data-qa='proposal-subTitle']"));
    //$###,###.## 
    public static Element ProposalModalPaymentPaymentTitle => new Element(By.XPath("//h4[@data-qa='proposal-premium-amount']"));
    //12 monthly payments of ###.## OR 1 yearly payment of $###,###.##
    public static Element ProposalModalPaymentPaymentAmt => new Element(By.XPath("//p[@data-qa='proposal-payment-schedule']"));
    /*
     * Add On coverages
     */
    //TBD on how these will be mapped.
    //Bodily Injury and Property Damage Liability
    public static Element BIaPDLCheckIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-BI PD-check-icon']"));
    public static Element BIaPDLCacnelIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-BI PD-cancel-icon']"));
    public static Element BIaPDLLabel => new Element(By.XPath("//p[@data-qa='proposal-BI PD-label']"));
    //Uninsured/Underinsured Motorist
    public static Element UninsuredUnderinsuredCheckIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-UM UIM-check-icon']"));
    public static Element UninsuredUnderinsuredCancelIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-UM UIM-cancel-icon']"));
    public static Element UninsuredUnderinsuredLabel => new Element(By.XPath("//p[@data-qa='proposal-UM UIM-label']"));
    //Comp/Collision (One Vehicle)
    public static Element CompCollisionCheckIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-Comp Collision-check-icon']"));
    public static Element CompCollisionCancelIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-Comp Collision-cancel-icon']"));
    public static Element CompCollisionLabel => new Element(By.XPath("(//p[@data-qa='proposal-RentalReimbursement-label'])[1]"));
    //Cargo Liability
    public static Element CargoLiabilityCheckIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-Cargo-check-icon']"));
    public static Element CargoLiabilityCancelIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-Cargo-cancel-icon']"));
    public static Element CargoLiabilityLabel => new Element(By.XPath("//p[@data-qa='proposal-Cargo-label']"));
    //Medical Payments
    public static Element MedicalPaymentsCheckIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-Medical-check-icon']"));
    public static Element MedicalPaymentsCancelIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-Medical-cancel-icon']"));
    public static Element MedicalPaymentsLabel => new Element(By.XPath("//p[@data-qa='proposal-Medical-label']"));
    //Rental Reimbursement
    public static Element RentalReimbursementCheckIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-RentalReimbursement-check-icon']"));
    public static Element RentalReimbursementCancelIcon => new Element(By.XPath("//mat-icon[@data-qa='proposal-RentalReimbursement-cancel-icon']"));
    public static Element RentalReimbursementLabel => new Element(By.XPath("(//p[@data-qa='proposal-RentalReimbursement-label'])"));
    //Physical Damage coverage(One Vehicle)
    public static Element PhysicalDamageCheckIcon => new Element(By.XPath("//mat-icon[@data-qa='']"));
    public static Element PhysicalDamageCancelIcon => new Element(By.XPath("//mat-icon[@data-qa='']"));
    public static Element PhysicalDamageLabel => new Element(By.XPath("//p[@data-qa='']"));
    //Email my policy quote to the email address(es) below.
    public static Element ProposalModalEmailQST => new Element(By.XPath("//span[@data-qa='email-policy-quote-text']"));
    public static Element ProposalModalEmailTxtbox => new Element(By.XPath("//input[@data-qa='email-input']"));
    public static Element ProposalModalEmailError => new Element(By.XPath("//mat-error[@data-qa='email-error']"));

    //Email Your Policy Quote
    public static Element EmailPolicyCTA => new Element(By.XPath("//button[@data-qa='modal-primary-btn']"));

    //Toast for Successful Modal Submittal
    public static Element EmailPolicySuccessToast => new Element(By.XPath("//div[@id='toast-container']/div[contains(@class,'toast-success')]"));

}