using Faker;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.MakeAPayment
{
    [Binding]
    public sealed class BaseMakeAPayment
    {

        /// <summary>
        /// if there is a second instance of any policy, this will need to be updated to accommodate
        /// </summary>
        /// 
   
        //------------------------------------Base Make A Payment----------------------------------------
        //Insurance Billing
        public static Element InsuranceBillingHeader => new Element(By.XPath("//h1[@data-qa='dashboard-title-text']"));
        //Welcome
        public static Element WelcomeTitle => new Element(By.XPath("//h3[@data-qa='dashboard-inured-name-text']"));
        //On this page you can review the payment due dates for any of your biBERK policies, make payments, and check policy renewal dates.
        public static Element OnThisPageSubText => new Element(By.XPath("//h6[@data-qa='dashboard-description-text']"));
        public static Element EnrolledInAutopay => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-has-autopay-text')]"));
        public static Element MakeAPayment => new Element(By.XPath("//a[contains(@data-qa, 'dashboard-goto-payment-link')]"));
        public static Element PaidConfirmationNumber => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-payment-transaction-id-text')]"));

        //------------------------------------Current policy card elements----------------------------------------
        public static Element PolicyNumberHeader => new Element(By.XPath("//legend[contains(@data-qa, 'dashboard-legend')]"));
        public static Element CurrentDue => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-current-due-text')]"));
        public static Element CurrentDueAmount => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-current-amount-text')]"));
        public static Element NextPaymentDue => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-due-date-text')]"));
        public static Element MakeAPayment_BTN => new Element(By.XPath("//a[contains(@data-qa, 'dashboard-make-payment-link')]"));
        //Please note that you can enroll in autopay on the payment page.
        public static Element PleaseNote => new Element(By.XPath("//p[contains(@data-qa, 'dashboard-autopay-enroll-text')]"));

        //--------------------------------------Policy cancelled page elements-------------------------------------------
        public static Element PastDueHeader => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-past-due-text')]"));
        public static Element PastDueAmount => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-past-due-amount-text')]"));
        public static Element PastDueCancelledText => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-canceled-date-text')]"));

        //-----------------------------------Renewal policy card elements--------------------------------------------
        public static Element DatedPaid => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-last-paid-date-text')]"));
        public static Element LastPaidAmount => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-last-paid-amount-text')]"));
        public static Element RenewalPolicyHeader => new Element(By.XPath("//p[contains(@data-qa, 'dashboard-policy-renewal-text')]"));
        public static Element RenewalPolicyText => new Element(By.XPath("//p[contains(@data-qa, 'dashboard-renewal-notice-text')]"));

        //------------------------------- Pending audit policy card elements-------------------------------------------
        public static Element AuditPendingHeader => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-audit-pending-text')]"));
        //Please note that any payment for a Workers’ Compensation policy is based on your payroll estimate and is subject to audit, after which you might receive a refund or be required to pay an additional amount.
        public static Element AuditPendingText => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-audit-wc-text')]"));
        //Enrolled in Autopay
        public static Element EnrolledInAutopaySubtext => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-alert-text']')]"));

        //--------------------------------Cancelled policy card elements -------------------------------------------------
        public static Element PolicyCancelled => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-policy-canceled-text')]"));
        //We're sorry, but this policy was cancelled on 05/06/23 and is no longer accessible. If you need assistance, please contact us at 1-844-472-0967.
        public static Element PolicyCancelledText => new Element(By.XPath("//p[contains(@data-qa, 'dashboard-policy-end-date-text')]"));

        //---------------------------------- Policy Renwal card elements--------------------------------------------------
        public static Element PolicyRenewal => new Element(By.XPath("//div[@data-qa='dashboard-renewal-text']"));
        //Your policy is up for renewal. To continue your insurance coverage click Renew Policy below and make a payment by 05/27/23.
        public static Element PolicyRenewalText => new Element(By.XPath("//div[@data-qa='dashboard-renewal-subtext']"));
        public static Element DonwPaymentText => new Element(By.XPath("//div[@data-qa='dashboard-renewal-downpayment-text']"));
        public static Element InstallmentPaymentText => new Element(By.XPath("//div[@data-qa='dashboard-renewal-installment-text']"));
        public static Element TotalCostText => new Element(By.XPath("//div[@data-qa='dashboard-renewal-totalpremium-text']"));
        public static Element PolicyRenewal_BTN => new Element(By.XPath("//span[@data-qa='dashboard-renew-button-text']"));
        //After you have renewed your policy you will receive an email with your new policy number. A copy of your policy will be emailed and mailed to you.
        public static Element PolicyRenewal_Text => new Element(By.XPath("//div[@data-qa='dashboard-renewal-instructions-text']"));

        //----------------------------- Payment processed card elements-------------------------------------------
        public static Element PaidHeader => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-last-paid-date-text')]"));
        public static Element PaidAmount => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-last-paid-amount-text')]"));        

        //--------------------------- Overdue payment modal elements--------------------------------------------
        public static Element OverDue => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-past-due-text')]"));
        public static Element OverDueAmount => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-past-due-amount-text')]"));
        public static Element PleaseResolveBy => new Element(By.XPath("//div[contains(@data-qa, 'dashboard-pay-by-date-text')]"));

        //--------------------------- Expired Payment page--------------------------------------------
         public static Element ExpiredHeader => new Element(By.XPath("//h2[contains(@data-qa, 'nopayment-header-text')]"));
        public static Element ExpiredText => new Element(By.XPath("//p[contains(@data-qa, 'nopayment-info-text-2')]"));

        //----------------------------------------- Modal---------------------------------------------------
        public static Element ModalHeader => new Element(By.XPath("//span[@data-qa='dashboard-alert-header-text_1']"));
        public static Element ModalText => new Element(By.XPath("//h6[@data-qa='dashboard-alert-text']"));
        public static Element Modal_XBTN => new Element(By.XPath("//a[@data-qa='dashboard-alert-close-button']"));
    }
}