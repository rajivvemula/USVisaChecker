using BiBerkLOB.Pages.PL;
using BiBerkLOB.Pages.WC;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Debugger;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.WC
{
    [Binding]
    public sealed class General_WC_PurchasePage
    {
        private readonly WCYourQuoteObject _yourQuoteObject;

        public General_WC_PurchasePage(WCYourQuoteObject yourQuoteObject)
        {
            _yourQuoteObject = yourQuoteObject;
        }

        [Then(@"user fills out the WC purchase page with these values:")]
        public void ThenUserFillsOutTheWCPurchasePageWithTheseValues(Table table)
        {
            AddStateSpecificFields(_yourQuoteObject.State);
            SetPaymentOption(table);
            // Use the table to fill out the fields depending on the type of input they are with the value provided.
            DefinePageDictionary(table);
            FillOutPurchasePage();
            WC_PurchaseYourPolicy.AgreeToTermsChkbox.Click();
            WC_PurchaseYourPolicy.PurchaseCTA.Click();
        }

        private void SetPaymentOption(Table table)
        {
            foreach (var row in table.Rows)
            {
                var field = row["Field"];
                var value = row["Value"];

                if (field == "Payment Option")
                {
                    _yourQuoteObject.PaymentOption = value;
                }
            }
        }

        private void AddStateSpecificFields(string state)
        {
            switch (state.ToLower())
            {
                case "fl":
                    PurchasePageElements.Add(new ElementInfoObj("Read Florida Applications?", "", "Checkbox"), WC_PurchaseYourPolicy.FloridaApplicationsChkBox);
                    PurchasePageElements.Add(new ElementInfoObj("Read Foregoing Application?", "", "Checkbox"), WC_PurchaseYourPolicy.FloridaForegoingChkBox);
                    break;
            }
        }

        // Validate that each element on the page is visible and assigned the correct value based on the type of element.
        private void FillOutPurchasePage()
        {
            WC_PurchaseYourPolicy.TotalPremiumAmt.AssertElementIsVisible();
            var PremiumValue = AutomationHelper.ParsePriceFromText(WC_PurchaseYourPolicy.TotalPremiumAmt);

            bool InstallmentVisible = true;
            foreach (var entry in PurchasePageElements)
            {
                if (!string.IsNullOrEmpty(entry.Key.Name))
                {
                    if (entry.Key.Name == "PerInstallmentTitle" || entry.Key.Name == "PerInstallmentAmt")
                    {
                        InstallmentVisible = entry.Value.AssertElementIsVisible(optional: true);
                    }
                    switch (entry.Key.Name)
                    {
                        case "PerInstallmentTitle": case "PerInstallmentAmt":
                            if (InstallmentVisible)
                            {
                                entry.Value.AssertElementIsVisible();
                            }
                            break;
                        case "MonthlyEnrollsYouInAutopayTxt":
                            if (PremiumValue >= 1000 || (entry.Key.Name == "Payment Option" && entry.Key.Value == "One Pay Plan"))
                            {
                                entry.Value.AssertElementIsVisible();
                            }
                            break;
                        case "MonthlyEnrollsYouInAutopayChkbox":
                            if (PremiumValue >= 1000 || (entry.Key.Name == "Payment Option" && entry.Key.Value == "One Pay Plan"))
                            {
                                entry.Value.AssertElementIsVisible();
                            }
                            break;
                        case "MonthlyEnrollsYouInAutopayTxtLowPremium":
                            if (PremiumValue < 1000 && (entry.Key.Name == "Payment Option" && entry.Key.Value != "One Pay Plan"))
                            {
                                entry.Value.AssertElementIsVisible();
                            }
                            break;
                    }
                }
                switch (entry.Key.Type)
                {
                    case "Dropdown":
                        if (entry.Key.Value != String.Empty)
                        {
                            SelectDropDownOption(entry.Value, entry.Key.Value);
                        }
                        break;
                    case "Input":
                        if (entry.Key.Value != String.Empty)
                        {
                            entry.Value.SetText(entry.Key.Value);
                        }
                        break;
                    case "Checkbox":
                        if (entry.Key.Value != String.Empty)
                        {
                            if (entry.Key.Value.ToLower() == "yes" && entry.Value.IsSelected() == false)
                            {
                                entry.Value.Click();
                            }
                            if (entry.Key.Value.ToLower() == "no" && entry.Value.IsSelected() == true)
                            {
                                entry.Value.Click();
                            }
                        }
                        break;
                    case "Button":
                        if (entry.Key.Value != String.Empty)
                        {
                            entry.Value.Click();
                        }
                        break;
                }

            }
        }

        // Reference the DependentElementChangeValues dictonary and if any entry matches the assigned element name and value,
        // remove the dependent elements associated with that entry (as defined in the DependentElements dictionary).
        private void EvaluateDictionaryElements(KeyValuePair<ElementInfoObj, Element> pageDictonaryEntry)
        {
            foreach (var changeValue in DependentElementChangeValues)
            {
                if (changeValue.Key == pageDictonaryEntry.Key.Name && changeValue.Value == pageDictonaryEntry.Key.Value)
                {
                    RemoveDependentPageDictionaryElements(pageDictonaryEntry.Key.Name);
                }
            }
        }

        private void RemoveDependentPageDictionaryElements(string potentiallyModifyingElement)
        {
            if (DependentElements.ContainsKey(potentiallyModifyingElement))
            {
                foreach (var element in DependentElements.GetValueOrDefault(potentiallyModifyingElement))
                {
                    foreach (var keyValue in PurchasePageElements)
                    {
                        if (keyValue.Key.Name == element) PurchasePageElements.Remove(keyValue.Key);
                    }
                }
            }
        }

        private void SelectDropDownOption(Element dropDown, string option)
        {
            Regex xpathRegex = new Regex("(?<=By.XPath: ).*");

            var dropDownLocator = dropDown.locator;
            var dropdownOptionPath = xpathRegex.Match(dropDownLocator.ToString()).ToString();

            dropDown.Click();

            var dropDownOption = new Element(By.XPath($"{dropdownOptionPath}/option[text()='{option}']"));

            dropDownOption.Click();
        }

        // Assigns values to each entry in the PurchasePageElements dictonary if a value is provided via the FF table.
        private void DefinePageDictionary(Table table)
        {
            foreach (var rowy in table.Rows)
            {
                var field = rowy["Field"];
                var value = rowy["Value"];

                foreach (var entry in PurchasePageElements)
                {
                    if (entry.Key.Name == field) entry.Key.Value = value;
                    EvaluateDictionaryElements(entry);
                }
            }
        }

        // Contains all elements that could potentially appear on the page and a corresponding elment object that stores the name of the element (to be referenced in the FF),
        // the value that should be assigned to the element (by default is blank but is also set in the FF), and the type of the element.
        private Dictionary<ElementInfoObj, Element> PurchasePageElements = new Dictionary<ElementInfoObj, Element>
        {
            { new ElementInfoObj("PurchaseYourPolicyTitle","","Text"), WC_PurchaseYourPolicy.PurchaseYourPolicyTitle },
            { new ElementInfoObj("PolicyStartDateWithDate","","Text"), WC_PurchaseYourPolicy.PolicyStartDateWithDate },
            { new ElementInfoObj("CoverageForOneYear","","Text"), WC_PurchaseYourPolicy.CoverageForOneYear },
            { new ElementInfoObj("COIAvailableOnline","","Text"), WC_PurchaseYourPolicy.COIAvailableOnline },
            { new ElementInfoObj("PaymentInformationTitle","","Text"), WC_PurchaseYourPolicy.PaymentInformationTitle },
            { new ElementInfoObj("OrderSummaryTitle","","Text"), WC_PurchaseYourPolicy.OrderSummaryTitle },
            { new ElementInfoObj("ProductTitle","","Text"), WC_PurchaseYourPolicy.ProductTitle },
            { new ElementInfoObj("ProductWC","","Text"), WC_PurchaseYourPolicy.ProductWC },
            { new ElementInfoObj("PolicyTermTitle","","Text"), WC_PurchaseYourPolicy.PolicyTermTitle },
            { new ElementInfoObj("PolicyTermAmt","","Text"), WC_PurchaseYourPolicy.PolicyTermAmt },
            { new ElementInfoObj("StartingDateTitle","","Text"), WC_PurchaseYourPolicy.StartingDateTitle },
            { new ElementInfoObj("StartingDateDate","","Text"), WC_PurchaseYourPolicy.StartingDateDate },
            { new ElementInfoObj("TotalPremiumTitle","","Text"), WC_PurchaseYourPolicy.TotalPremiumTitle },
            { new ElementInfoObj("TotalPremiumAmt","","Text"), WC_PurchaseYourPolicy.TotalPremiumAmt },
            { new ElementInfoObj("PaymentOptionTitle","","Text"), WC_PurchaseYourPolicy.PaymentOptionTitle },
            { new ElementInfoObj("Payment Option","","Dropdown"), WC_PurchaseYourPolicy.PaymentOptionDD },
            { new ElementInfoObj("DueNowTitle","","Text"), WC_PurchaseYourPolicy.DueNowTitle },
            { new ElementInfoObj("DueNowAmt","","Text"), WC_PurchaseYourPolicy.DueNowAmt },
            { new ElementInfoObj("FutureInstallmentTitle","","Text"), WC_PurchaseYourPolicy.FutureInstallmentTitle },
            { new ElementInfoObj("FutureInstallmentAmt","","Text"), WC_PurchaseYourPolicy.FutureInstallmentAmt },
            { new ElementInfoObj("PerInstallmentTitle","","Text"), WC_PurchaseYourPolicy.PerInstallmentTitle },
            { new ElementInfoObj("PerInstallmentAmt","","Text"), WC_PurchaseYourPolicy.PerInstallmentAmt },
            { new ElementInfoObj("PayUsingCreditCardTitle","","Text"), WC_PurchaseYourPolicy.PayUsingCreditCardTitle },
            { new ElementInfoObj("CCImgs_AllFour","","Image"), WC_PurchaseYourPolicy.CCImgs_AllFour },
            { new ElementInfoObj("NameOnCardQST","","Text"), WC_PurchaseYourPolicy.NameOnCardQST },
            { new ElementInfoObj("CC Name","","Input"), WC_PurchaseYourPolicy.NameOnCardTxtbox },
            { new ElementInfoObj("CreditCardNumQST","","Text"), WC_PurchaseYourPolicy.CreditCardNumQST },
            { new ElementInfoObj("CC Number","","Input"), WC_PurchaseYourPolicy.CreditCardNumTxtbox },
            { new ElementInfoObj("CC Expiration Month","","Input"), WC_PurchaseYourPolicy.CreditCardMonthTxtbox },
            { new ElementInfoObj("CC Expiration Year","","Input"), WC_PurchaseYourPolicy.CreditCardYearTxtbox },
            { new ElementInfoObj("ThisIsASecureSSLEncryptedPayment","","Text"), WC_PurchaseYourPolicy.ThisIsASecureSSLEncryptedPayment },
            { new ElementInfoObj("MonthlyEnrollsYouInAutopayTxt","","Text"), WC_PurchaseYourPolicy.MonthlyEnrollsYouInAutopayTxt },
            { new ElementInfoObj("MonthlyEnrollsYouInAutopayTxtLowPremium","","Text"), WC_PurchaseYourPolicy.MonthlyEnrollsYouInAutopayTxtLowPremium },
            { new ElementInfoObj("MonthlyEnrollsYouInAutopayChkbox","","Checkbox"), WC_PurchaseYourPolicy.MonthlyEnrollsYouInAutopayChkbox },
            { new ElementInfoObj("MonthlyEnrollsYouInAutopayHelper","","Button"), WC_PurchaseYourPolicy.MonthlyEnrollsYouInAutopayHelper },
            { new ElementInfoObj("ContactInfoTitle","","Text"), WC_PurchaseYourPolicy.ContactInfoTitle },
            { new ElementInfoObj("FirstNameQST","","Text"), WC_PurchaseYourPolicy.FirstNameQST },
            { new ElementInfoObj("First Name","","Input"), WC_PurchaseYourPolicy.FirstNameTxtbox },
            { new ElementInfoObj("LastNameQST","","Text"), WC_PurchaseYourPolicy.LastNameQST },
            { new ElementInfoObj("Last Name","","Input"), WC_PurchaseYourPolicy.LastNameTxtbox },
            { new ElementInfoObj("EmailQST","","Text"), WC_PurchaseYourPolicy.EmailQST },
            { new ElementInfoObj("Email","","Input"), WC_PurchaseYourPolicy.EmailTxtbox },
            { new ElementInfoObj("PhoneQST","","Text"), WC_PurchaseYourPolicy.PhoneQST },
            { new ElementInfoObj("Phone","","Input"), WC_PurchaseYourPolicy.PhoneTxtbox },
            { new ElementInfoObj("UseThisAsBillingContactQST","","Text"), WC_PurchaseYourPolicy.UseThisAsBillingContactQST },
            { new ElementInfoObj("Same Billing Info?","","Checkbox"), WC_PurchaseYourPolicy.UseThisAsBillingContactChkbox },
            { new ElementInfoObj("BillingFirstNameQST","","Text"), WC_PurchaseYourPolicy.BillingFirstNameQST },
            { new ElementInfoObj("Billing First Name","","Input"), WC_PurchaseYourPolicy.BillingFirstNameTxtbox },
            { new ElementInfoObj("BillingLastNameQST","","Text"), WC_PurchaseYourPolicy.BillingLastNameQST },
            { new ElementInfoObj("Billing Last Name","","Input"), WC_PurchaseYourPolicy.BillingLastNameTxtbox },
            { new ElementInfoObj("BillingEmailQST","","Text"), WC_PurchaseYourPolicy.BillingEmailQST },
            { new ElementInfoObj("Billing Email","","Input"), WC_PurchaseYourPolicy.BillingEmailTxtbox },
            { new ElementInfoObj("BillingPhoneQST","","Text"), WC_PurchaseYourPolicy.BillingPhoneQST },
            { new ElementInfoObj("Billing Phone","","Input"), WC_PurchaseYourPolicy.BillingPhoneTxtbox },
            { new ElementInfoObj("AgreeToTermsQST","","Text"), WC_PurchaseYourPolicy.AgreeToTermsQST },
            { new ElementInfoObj("AgreeToTermsChkbox","","Checkbox"), WC_PurchaseYourPolicy.AgreeToTermsChkbox },
            { new ElementInfoObj("AgreeToTermsLink","","Button"), WC_PurchaseYourPolicy.AgreeToTermsLink },
            { new ElementInfoObj("PurchaseCTA","","Button"), WC_PurchaseYourPolicy.PurchaseCTA },
            { new ElementInfoObj("ACOIIsAvailableParagraph","","Text"), WC_PurchaseYourPolicy.ACOIIsAvailableParagraph },
            { new ElementInfoObj("BBBImg","","Image"), WC_PurchaseYourPolicy.BBBImg },
            { new ElementInfoObj("AuthorizeNETImg","","Image"), WC_PurchaseYourPolicy.AuthorizeNETImg },
        };

        // Specifies what elements (via their names) in the PurchasePageElements dictionary that have dependent elements
        // that could cause certain elements to appear or disappear if the corresponding value is provided via the FF
        private Dictionary<string, string> DependentElementChangeValues = new Dictionary<string, string>
        {
            {"Payment Option","One Pay Plan"},
            {"Same Billing Info?","Yes"},
            {"Autopay","N/A"},
        };

        // Specifies the elements (via their names) that have dependent elements and a list of those dependent elements
        private Dictionary<string, List<string>> DependentElements = new Dictionary<string, List<string>>
        {
            { "Payment Option", new List<string>{ "FutureInstallmentTitle", "FutureInstallmentAmt", "PerInstallmentTitle", "PerInstallmentAmt" } },
            { "Same Billing Info?", new List<string>{ "BillingFirstNameQST", "Billing First Name", "BillingLastNameQST", "Billing Last Name", "BillingEmailQST", "Billing Email", "BillingPhoneQST", "Billing Phone", } },
            { "Autopay", new List<string>{ "MonthlyEnrollsYouInAutopayTxt", "Autopay", "MonthlyEnrollsYouInAutopayHelper"} }
        };
    }

    public class ElementInfoObj
    {
        public string Name;
        public string Value;
        public string Type;

        public ElementInfoObj(string name, string value, string type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
    }
}