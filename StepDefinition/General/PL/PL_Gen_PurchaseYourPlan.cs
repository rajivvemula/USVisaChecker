using BiBerkLOB.Pages.PL;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BiBerkLOB.Source.Driver.Input;
using BiBerkLOB.Source.Helpers;
using TechTalk.SpecFlow;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;
using DocumentFormat.OpenXml.Drawing.Charts;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_PurchaseYourPlan
    {
        private readonly PLSummaryObject _plSummaryObject;

        public PL_Gen_PurchaseYourPlan(PLSummaryObject plSummaryObject)
        {
            _plSummaryObject = plSummaryObject;
        }

        [When(@"user fills out the PL purchase page with these values:")]
        public void WhenUserFillsOutThePLPurchasePageWithTheseValues(Table table)
        {
            AutomationHelper.LegacyWaitForLoading(120);

            foreach (var rowy in table.Rows)
            {
                var field = rowy["Field"];
                var value = rowy["Value"];

                var fieldTypeAndTargetElement = DetermineFieldType(field);
                SetFieldValue(fieldTypeAndTargetElement, value);
            }

            PL_PurchasePage.TermsConditionsChkbox.Click();
            PL_PurchasePage.PayAmountCTA.Click();
        }

        [Then(@"user verifies the PL purchase page appearance")]
        public void ThenUserVerifiesThePLPurchasePageAppearance()
        {
            // Verify the title and terms for your plan
            ValidateElements(PageTitleElements);
            PL_PurchasePage.PaymentTermsTitle.AssertElementIsVisible();

            decimal monthlyTotalPremium = 0;

            if (_plSummaryObject.YearlyOrMonthly.Equals("Monthly"))
            {
                // 12 month validation
                ValidateElements(MonthlyPayPlanElements);
                PL_PurchasePage.ViewPaymentScheduleAccordian.AssertElementIsVisible();
                PL_PurchasePage.ViewPaymentScheduleAccordian.Click();

                //pull total cost of monthly payments from within the accordian for future use in ValidatePurchasePageSavings() method
                monthlyTotalPremium = AutomationHelper.ParsePriceFromText(PL_PurchasePage.ViewPaymentScheduleTotalCost);

                ValidateElements(PaymentScheduleElements);
            }
            else
            {
                // Yearly payment
                PL_PurchasePage.YearlyPaymentChkbox.AssertElementIsVisible();
                ValidateElements(YearlyPayPlanElements);

                //click temporarily to Monthly to pull total cost of monthly payments within the accordian
                PL_PurchasePage.MonthlyPaymentChkbox.Click();
                PL_PurchasePage.ViewPaymentScheduleAccordian.Click();

                //pull total cost of monthly payments from within the accordian for future use in ValidatePurchasePageSavings() method
                monthlyTotalPremium = AutomationHelper.ParsePriceFromText(PL_PurchasePage.ViewPaymentScheduleTotalCost);

                //click back to Yearly
                PL_PurchasePage.YearlyPaymentChkbox.Click();
            }

            //Calculate policy's premium
            decimal price = AutomationHelper.ParsePriceFromText(PL_PurchasePage.PricePerMonthLabel);
            decimal PremiumAmount = price * 12;

            ValidatePurchasePageSavings(monthlyTotalPremium);

            // Verify autopay
            PL_PurchasePage.AutoPayHelper.Click();            
            if (PremiumAmount <= 1000 && _plSummaryObject.YearlyOrMonthly.Equals("Monthly"))
            {                
                ValidateElements(MandatoryAutoPayElements);        
            }
            else
            {                
                ValidateElements(AutoPayElements);
            }

            // Validate the payment information section
            PL_PurchasePage.SecurePaymentHelper.AssertElementIsVisible();
            PL_PurchasePage.SecurePaymentHelper.Click();
            ValidateElements(PaymentInfoElements);
            //Cause the relevant error messages to appear by clicking the corresponding inputs
            ClickElements(new List<Element> { PaymentInfoElements[5], PaymentInfoElements[6], PaymentInfoElements[7] });
            PL_PurchasePage.PaymentInformationTitle.Click(); // Causes the final error message to appear by clicking away from the final input
            ValidateElements(PaymentInfoErrorElements);

            // Validate the address section
            ValidateElements(AddressElements);
            //Cause the relevant error messages to appear by removing the placeholder text from each of the corresponding inputs
            SetTextOfElements(new List<Element> { AddressElements[0], AddressElements[2], AddressElements[5] }, "");
            PL_PurchasePage.PaymentInformationTitle.Click(); // Causes the final error message to appear by clicking away from the final input
            ValidateElements(AddressErrorElements);

            // Validate the terms section
            ValidateElements(TermsElements);

            // Validate the Pay button
            PL_PurchasePage.PayAmountCTA.AssertElementIsVisible();

            // Validate the Icons
            ValidateElements(FooterElements);
        }

        /*
         * This method is to provide additional checks between the actual yearly cost and actual monthly total cost
         * and the statement on UI saying how much you save.  This was added in regards to a billing issue discovered and recorded
         * on the Bug 125562
         */
        public void ValidatePurchasePageSavings(decimal monthlyTotalPremium)
        {
            //---Validate Yearly Save Cost is Accurate-----
       
            //pull in yearly cost
            decimal yearlypremium = AutomationHelper.ParsePriceFromText(PL_PurchasePage.YearlyPaymentLabel_PriceDueToday);
       
            //subtract monthly plan total - yearly plan total
            decimal totalCostDifferenceActual = monthlyTotalPremium - yearlypremium;
       
            //compare ACTUAL cost savings to what is reported on the UI
            var numberText = PL_PurchasePage.YearlyPaymentLabel_YearlySave.GetInnerText();
            var removedLettersFromSave = numberText.Split('$').Last();
       
            decimal reportedCostDifference = decimal.Parse(removedLettersFromSave, System.Globalization.NumberStyles.AllowCurrencySymbol | System.Globalization.NumberStyles.Number);
       
            //compare "Save $.." statement on UI to actual cost difference between the plans
            var finalComparedAmt = Math.Abs(reportedCostDifference - totalCostDifferenceActual);       
       
            //validate result is within 1 dollar
            Assert.IsTrue(finalComparedAmt < 1, false, $"Calculated savings between yearly and monthly {totalCostDifferenceActual} does not align with UI {reportedCostDifference}");
        }


        public void ValidateElements(List<Element> elements)
        {
            foreach (var element in elements)
                try
                {
                    element.AssertElementIsVisible();
                }
                catch
                {
                    throw new Exception($"The following element was not visible: {element.locator}");
                }
        }

        public void ClickElements(List<Element> elements)
        {
            foreach (var element in elements)
                try
                {
                    element.Click(1);
                }
                catch
                {
                    throw new Exception($"The following element could not be clicked: {element.locator}");
                }
        }

        public void SetTextOfElements(List<Element> elements, string value)
        {
            foreach (var element in elements)
                try
                {
                    element.SetText(value);
                }
                catch
                {
                    throw new Exception($"The following element could not have it's text changed: {element.locator}");
                }
        }

        public KeyValuePair<string, Element> DetermineFieldType(string field)
        {
            KeyValuePair<string, Element> fieldType = new KeyValuePair<string, Element>();

            foreach (var entry in InputFields)
            {
                if (entry.Key == field) fieldType = new KeyValuePair<string, Element>("InputField", entry.Value);
            }
            foreach (var entry in ToggleFields)
            {
                if (entry.Key == field) fieldType = new KeyValuePair<string, Element>("ToggleField", entry.Value);
            }
            foreach (var entry in DropDownFields)
            {
                if (entry.Key == field) fieldType = new KeyValuePair<string, Element>("DropDownField", entry.Value);
            }

            return fieldType;
        }

        public void SetFieldValue(KeyValuePair<string, Element> fieldKeyValuePair, string tableValue)
        {
            switch (fieldKeyValuePair.Key)
            {
                case "InputField":
                    fieldKeyValuePair.Value.AssertElementIsVisible();
                    fieldKeyValuePair.Value.SetText(tableValue);
                    break;
                case "ToggleField":
                    if (tableValue != "Mandatory")
                    {
                        fieldKeyValuePair.Value.AssertElementIsVisible();
                        fieldKeyValuePair.Value.Click();
                    }      
                    break;
                case "DropDownField":
                    SelectDropwDownOption(fieldKeyValuePair.Value, tableValue);
                    break;
                default:
                    break;
            }
        }

        private void SelectDropwDownOption(Element dropDown, string option)
        {
            var ddInput = new PLDropdownInput(dropDown);
            ddInput.EnterResponse(option);
        }

        //Element lists:

        public static List<Element> PageTitleElements = new List<Element>
        {
            PL_PurchasePage.PurchasePageTitle,
            PL_PurchasePage.PurchasePageSubTitle,
            PL_PurchasePage.COIAvailableOnlineStmt
        };

        public static List<Element> MonthlyPayPlanElements = new List<Element>
        {
            PL_PurchasePage.MonthlyPaymentChkbox,
            PL_PurchasePage.MonthlyPaymentLabel,
            PL_PurchasePage.PricePerMonthLabel
        };

        public static List<Element> PaymentScheduleElements = new List<Element>
        {
            PL_PurchasePage.ViewPaymentScheduleAccordian,
            PL_PurchasePage.ViewPaymentScheduleAccordian_DueDatePrice
        };

        public static List<Element> YearlyPayPlanElements = new List<Element>
        {
            PL_PurchasePage.YearlyPaymentChkbox,
            PL_PurchasePage.YearlyPaymentLabel_YearlySave,
            PL_PurchasePage.YearlyPaymentLabel_PriceDueToday
        };

        public static List<Element> AutoPayElements = new List<Element>
        {
            PL_PurchasePage.AutoPayLabel,
            PL_PurchasePage.AutoPayHelper,
            PL_PurchasePage.AutoPayChkbox,
            PL_PurchasePage.AutoPayHelperText,
            PL_PurchasePage.AutoPayHelperX
        };

        public static List<Element> MandatoryAutoPayElements = new List<Element>
        {
            PL_PurchasePage.MandatoryAutoPayPrgrph,
            PL_PurchasePage.AutoPayHelper,
            PL_PurchasePage.AutoPayHelperText,
            PL_PurchasePage.AutoPayHelperX
        };

        public static List<Element> PaymentInfoElements = new List<Element>
        {
            PL_PurchasePage.PaymentInformationTitle,
            PL_PurchasePage.PaymentInformationCCImage_Visa,
            PL_PurchasePage.PaymentInformationCCImage_MasterCard,
            PL_PurchasePage.PaymentInformationCCImage_Discover,
            PL_PurchasePage.PaymentInformationCCImage_AmericanExpress,
            PL_PurchasePage.PaymentInformationNameTxtbox,
            PL_PurchasePage.PaymentInformationCCNumberTxtbox,
            PL_PurchasePage.PaymentInformationCCExpirationTxtbox
        };

        public static List<Element> SSLElements = new List<Element>
        {
            PL_PurchasePage.SecurePaymentLockImage,
            PL_PurchasePage.SecurePaymentLabel,
            PL_PurchasePage.SecurePaymentHelper,
            PL_PurchasePage.SecurePaymentHelperText,
            PL_PurchasePage.SecurePaymentHelperX
        };

        public static List<Element> PaymentInfoErrorElements = new List<Element>
        {
            PL_PurchasePage.PaymentInformationNameError,
            PL_PurchasePage.PaymentInformationCCNumberError,
            PL_PurchasePage.PaymentInformationCCExpirationError
        };

        public static List<Element> AddressElements = new List<Element>
        {
            PL_PurchasePage.BillingStreetAddressTxtbox,
            PL_PurchasePage.BillingApartmentSuiteTxtbox,
            PL_PurchasePage.BillingZipCodeTxtbox,
            PL_PurchasePage.BillingCityDD,
            PL_PurchasePage.BillingStateTxtbox,
            PL_PurchasePage.BillingPhoneTxtbox,
            PL_PurchasePage.BillingPhoneExtensionTxtbox
        };

        public static List<Element> AddressErrorElements = new List<Element>
        {
            PL_PurchasePage.BillingStreetAddressError,
            PL_PurchasePage.BillingZipCodeError,
            PL_PurchasePage.BillingPhoneError
        };

        public static List<Element> TermsElements = new List<Element>
        {
            PL_PurchasePage.TermsConditionsChkbox,
            PL_PurchasePage.TermsConditionsLabel,
            PL_PurchasePage.TermsOfUseLink
        };

        public static List<Element> FooterElements = new List<Element>
        {
            PL_PurchasePage.BBBImage,
            PL_PurchasePage.AuthorizeNetImage,
            PL_PurchasePage.ProudToBeACopy
        };

        static Dictionary<string, Element> InputFields = new Dictionary<string, Element>
        {
                { "CC Name", PL_PurchasePage.PaymentInformationNameTxtbox},
                { "CC Number", PL_PurchasePage.PaymentInformationCCNumberTxtbox},
                { "CC Expiration", PL_PurchasePage.PaymentInformationCCExpirationTxtbox},
                { "Street Address", PL_PurchasePage.BillingStreetAddressTxtbox},
                { "ZIP Code", PL_PurchasePage.BillingZipCodeTxtbox},
                { "Phone", PL_PurchasePage.BillingPhoneTxtbox},
                { "Extension", PL_PurchasePage.BillingPhoneExtensionTxtbox}
        };

        static Dictionary<string, Element> ToggleFields = new Dictionary<string, Element>
        {
                { "Monthly", PL_PurchasePage.MonthlyPaymentChkbox},
                { "Yearly", PL_PurchasePage.YearlyPaymentChkbox},
                { "Autopay", PL_PurchasePage.AutoPayChkbox},
                { "Terms And Conditions", PL_PurchasePage.TermsConditionsChkbox}
        };

        static Dictionary<string, Element> DropDownFields = new Dictionary<string, Element>
        {
                { "City", PL_PurchasePage.BillingCityDD}
        };
    }
}