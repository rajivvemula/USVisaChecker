using BiBerkLOB.Pages.WC;
using HitachiQA.Driver;
using System.Collections.Generic;
using BiBerkLOB.Source.Helpers;
using TechTalk.SpecFlow;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.WC
{
    [Binding]
    public sealed class General_WCYourQuote
    {
        private readonly WCYourQuoteObject _wcYourQuoteObject;
        private readonly WCAdditionalInformationObject _localAIObject;

        public General_WCYourQuote(WCYourQuoteObject wcYourQuoteObject, WCAdditionalInformationObject wcAIObject)
        {
            _wcYourQuoteObject = wcYourQuoteObject;
            _localAIObject = wcAIObject;
        }

        [When(@"user selects a (.*) plan quote with the following customizations from the WC your quote page:")]
        public void WhenUserSelectsAPlanQuoteWithTheFollowingCustomizationsFromTheWCYourQuotePage(string planType, Table table)
        {
            var customizationOption = table.Rows[0]["Customization"].ToString();

            // standard multi-bundle should be used in situations where both standard and plus plans are offerd, standard single-bundle if only the standard plan is offered.
            switch (planType.ToLower())
            {
                case "plus":
                    CustomizePlanWithValues(planType, table);
                    break;
                case "standard multi-bundle":
                    CustomizePlanWithValues("standard", table);
                    break;
                case "standard single-bundle":
                    if (customizationOption != "N/A")
                    {
                        WC_YourQuotePage.EachEmployeeEditBttn.Click();
                        CustomizePlan(table);
                        WC_YourQuotePage.GetPlanButton.Click();
                    }
                    else
                    {
                        WC_YourQuotePage.GetPlanButton.Click();
                    }
                    break;
            }   
        }

        [Then(@"user verifies the WC your quote page appearance")]
        public void ThenUserVerifiesTheWCYourQuotePageAppearance()
        {
            AutomationHelper.LegacyWaitForLoading();
            AutomationHelper.ValidateElements(BasePageElements);
            ValidateQuotePlanCards();
            ValidateCustomizationModalElements();
        }

        [Then(@"user verifies that the Florida Premium Estimate Disclosure table contains these values:")]
        public void ThenUserVerifiesThatTheFloridaPremiumEstimateDisclosureTableContainsTheseValues(Table table)
        {
            AutomationHelper.ValidateElements(WC_YourQuotePage.FLPEDBaseElements);

            ValidateFLPEDTableHeaders(table);
            ValidateFLPEDTableRows(table);
        }

        private void ValidateQuotePlanCards()
        {
            if (WC_YourQuotePage.MultiPlanHeader(WCPlans["Plus"]).AssertElementIsVisible(1, true))
            {
                AutomationHelper.ValidateElements(StandardPlanElements);
                if (StatesWithDeductibles.Contains(_wcYourQuoteObject.State)) AutomationHelper.ValidateElements(StandardPlanDeductibleElements);
                AutomationHelper.ValidateElements(PlusPlanElements);
                if (StatesWithDeductibles.Contains(_wcYourQuoteObject.State)) AutomationHelper.ValidateElements(PlusPlanDeductibleElements);
                AutomationHelper.ValidateElements(CreateOfficerElementsList(_localAIObject.CoveredOOList.Count, _localAIObject.ExcludedOOList.Count));
            }
            else
            {
                AutomationHelper.ValidateElements(SingleBundlePlanElements);
                AutomationHelper.ValidateElements(CreateCoveragesElementList(_localAIObject.CoveredOOList.Count));
            }
        }

        private void ValidateCustomizationModalElements()
        {
            if (WC_YourQuotePage.MultiPlanHeader(WCPlans["Plus"]).AssertElementIsVisible(1, true))
            {
                WC_YourQuotePage.MultiPlanEachEmployeeEditBttn(WCPlans["Plus"]).Click();
            }
            else
            {
                WC_YourQuotePage.EachEmployeeEditBttn.Click();
            }

            AutomationHelper.ValidateElements(CusomizationModalElements);
            if (StatesWithDeductibles.Contains(_wcYourQuoteObject.State)) AutomationHelper.ValidateElements(CusomizationModalDeductibleElements);
            WC_YourQuotePage.MdlCloseBttn.Click();
        }

        private void WaitForCustomizeYourPlanWindow()
        {
            WC_YourQuotePage.MdlLoadingWindow.AssertElementIsVisible();
            WC_YourQuotePage.MdlLoadingWindow.AssertElementNotPresent();
        }

        private void CustomizePlanWithValues(string planType, Table table)
        {
            switch (planType?.ToLower())
            {
                case "standard":
                    WC_YourQuotePage.MultiPlanEachEmployeeEditBttn(WCPlans["Standard"]).Click();
                    CustomizePlan(table);
                    WC_YourQuotePage.MultiPlanBttn(WCPlans["Standard"]).Click();
                    break;
                case "plus":
                    WC_YourQuotePage.MultiPlanEachEmployeeEditBttn(WCPlans["Plus"]).Click();
                    CustomizePlan(table);
                    WC_YourQuotePage.MultiPlanBttn(WCPlans["Plus"]).Click();
                    break;
                default:
                    CustomizePlan(table);
                    WC_YourQuotePage.GetPlanButton.Click();
                    break;
            }
        }

        private void CustomizePlan(Table table)
        {
            foreach (var rowy in table.Rows)
            {
                foreach (var entry in CustomizeYourPlanDDs)
                {
                    if (entry.Key == rowy["Customization"]) entry.Value.SelectDropdownOptionByText(rowy["Value"]);
                }
            }

            WC_YourQuotePage.MdlUpdateBttn.Click();
            WaitForCustomizeYourPlanWindow();
        }

        private bool IsDeductibleState(string quoteState)
        {
            foreach (var state in StatesWithDeductibles)
            {
                if (state == quoteState) return true;
            }
            return false;
        }

        private List<Element> CreateCoveragesElementList(int numOfOfficers)
        {
            var coveragesBaseElements = new List<Element> { WC_YourQuotePage.CoveragesTxt, WC_YourQuotePage.WC_CoverageLabel, WC_YourQuotePage.WC_CheckBox };

            if (numOfOfficers == 1)
            {
                coveragesBaseElements.Add(WC_YourQuotePage.WC_SingleOwnerOfficer);
                coveragesBaseElements.Add(WC_YourQuotePage.SingleOwnerOfficerCheckBox);
                coveragesBaseElements.Add(WC_YourQuotePage.CoveragesHelperBttn);
            }
            else if (numOfOfficers >= 1)
            {
                coveragesBaseElements.Add(WC_YourQuotePage.WC_MultipleOwnerOfficer);
                coveragesBaseElements.Add(WC_YourQuotePage.MultiOwnerOfficerCheckBox);
                coveragesBaseElements.Add(WC_YourQuotePage.CoveragesHelperBttn);
            }
            return coveragesBaseElements;
        }

        private List<Element> CreateOfficerElementsList(int includedOfficers, int excludedOfficers)
        {
            var WCOfficerElements = new List<Element>();

            if (includedOfficers > 1)
            {
                WCOfficerElements.Add(WC_YourQuotePage.PlusPlanWCMultiOwnersAndOfficersLabel);
                WCOfficerElements.Add(WC_YourQuotePage.PlusPlanWCMultiOwnersAndOfficersLabelCheckbox);
            }
            else
            {
                WCOfficerElements.Add(WC_YourQuotePage.PlusPlanWCSingleOwnerAndOfficerLabel);
                WCOfficerElements.Add(WC_YourQuotePage.PlusPlanWCSingleOwnersAndOfficersLabelCheckbox);
            }

            return WCOfficerElements;
        }

        private void ValidateFLPEDTableHeaders(Table table)
        {
            var expectedHeaders = new List<string>(table.Header);

            for (int i = 0; i < expectedHeaders.Count; i++)
            {
                WC_YourQuotePage.FLPEDHeaderByIndex(i + 1).AssertElementIsVisible();
                WC_YourQuotePage.FLPEDHeaderByIndex(i + 1).AssertElementInnerTextEquals(expectedHeaders[i]);
            }
        }

        private void ValidateFLPEDTableRows(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var expectedRowCells = new List<string>(table.Rows[i].Values);

                for (int c = 0; c < expectedRowCells.Count; c++)
                {
                    WC_YourQuotePage.FLPEDCellByPos(i + 2, c + 1).AssertElementIsVisible();
                    WC_YourQuotePage.FLPEDCellByPos(i + 2, c + 1).AssertElementInnerTextEquals(expectedRowCells[c]);
                }
            }
        }

        private List<Element> BasePageElements = new List<Element>
        {
            //Header
            WC_YourQuotePage.WCQuoteID,
            WC_YourQuotePage.WCQuoteHeader,
            WC_YourQuotePage.ProvidingProtectionTxt,
            //Contact
            WC_YourQuotePage.QuestionsTxt,
            WC_YourQuotePage.YouCanContactUsTxt,
            WC_YourQuotePage.ContactEmailLink,
            WC_YourQuotePage.ContactEmailLinkBttn,
            WC_YourQuotePage.ContactPhoneNumberLink,
            WC_YourQuotePage.ContactPhoneNumberBttn,
            WC_YourQuotePage.ContactBiberkHours,
            //Certificate of Insurance 
            WC_YourQuotePage.CertificateOfInsuranceHeaderTxt,
            WC_YourQuotePage.COIParagraphTxt,
            //Footer
            WC_YourQuotePage.ProudToBePartOfTxt,
            WC_YourQuotePage.AsIsIndustryStandardTxt
        };

        private List<Element> SingleBundlePlanElements = new List<Element>
        {
            WC_YourQuotePage.ProvidingProtectionTxt,
            WC_YourQuotePage.YourPlanHeader,
            //Due Today Box
            WC_YourQuotePage.DueTodayTxt,
            WC_YourQuotePage.DownPaymentAmountTxt,
            WC_YourQuotePage.FollowingPaymentTxt,
            WC_YourQuotePage.YearlyPremiumTxt,
            WC_YourQuotePage.CoverageStartingLabel,
            WC_YourQuotePage.GetPlanButton,
            WC_YourQuotePage.CancelCoverageAnytime,
            //Employer Liability Limits
            WC_YourQuotePage.EmployerLiabilityLimits,
            WC_YourQuotePage.LiabilityLimitsHelperTxt,
            WC_YourQuotePage.EachAccidentTxt,
            WC_YourQuotePage.EachAccidentAmount,
            WC_YourQuotePage.EachAccidentEditBttn,
            WC_YourQuotePage.PolicyTotalTxt,
            WC_YourQuotePage.PolicyTotaltAmount,
            WC_YourQuotePage.PolicyTotalEditBttn,
            WC_YourQuotePage.EachEmployeeTxt,
            WC_YourQuotePage.EachEmployeeAmount,
            WC_YourQuotePage.EachEmployeeEditBttn,
        };

        private List<Element> BasicPlanDeductibleElements = new List<Element>
        {
            WC_YourQuotePage.DeductibleLabel,
            WC_YourQuotePage.DeductibleHelpBttn,
            WC_YourQuotePage.DeductiblePerClaimLabel,
            WC_YourQuotePage.DeductibleAmmountNone,
            WC_YourQuotePage.DeductibleEditBttn
        };

        private List<Element> StandardPlanElements = new List<Element>
        {
            WC_YourQuotePage.MultiPlanDueTodayLabel(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanDueTodayAmount(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanFollwedBy(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanYearlyAmount(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanCoverageStartDate(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanCoveragesHeader(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanCoveragesHelpBttn(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanWCLabel(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanWCCheckbox(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanELLLabel(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanELLLHelpBttn(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanEachAccidentLabel(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanEachAccidentAmount(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanEachAccidentEditBttn(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanPolicyTotalLabel(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanPolicyTotalAmount(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanPolicyTotalEditBttn(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanEachEmployeeLabel(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanEachEmployeeAmount(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanEachEmployeeEditBttn(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanBttn(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanCancelCoverage(WCPlans["Standard"])
        };

        private List<Element> StandardPlanDeductibleElements = new List<Element>
        {
            WC_YourQuotePage.MultiPlanDeductibleLabel(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanDeductibleHelpBttn(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanPerClaimLabel(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanPerClaimAmountNone(WCPlans["Standard"]),
            WC_YourQuotePage.MultiPlanPerClaimEditBttn(WCPlans["Standard"]),
        };

        private List<Element> PlusPlanElements = new List<Element>
        {
            WC_YourQuotePage.MultiPlanDueTodayLabel(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanDueTodayAmount(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanFollwedBy(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanYearlyAmount(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanCoverageStartDate(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanCoveragesHeader(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanCoveragesHelpBttn(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanWCLabel(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanWCCheckbox(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanELLLabel(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanELLLHelpBttn(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanEachAccidentLabel(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanEachAccidentAmount(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanEachAccidentEditBttn(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanPolicyTotalLabel(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanPolicyTotalAmount(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanPolicyTotalEditBttn(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanEachEmployeeLabel(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanEachEmployeeAmount(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanEachEmployeeEditBttn(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanBttn(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanCancelCoverage(WCPlans["Plus"])
        };

        private List<Element> PlusPlanDeductibleElements = new List<Element>
        {
            WC_YourQuotePage.MultiPlanDeductibleLabel(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanDeductibleHelpBttn(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanPerClaimLabel(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanPerClaimAmountNone(WCPlans["Plus"]),
            WC_YourQuotePage.MultiPlanPerClaimEditBttn(WCPlans["Plus"]),
        };

        private List<Element> CusomizationModalElements = new List<Element>{
            //Employer Liability Limits
            WC_YourQuotePage.MdlEmployerLiabilityLimitsLabel,
            WC_YourQuotePage.MdlEachAccidentTotalLabel,
            WC_YourQuotePage.MdlEachAccidentTotalHelpBttn,
            WC_YourQuotePage.MdlEachAccidentTotalDD,
            //Buttons
            WC_YourQuotePage.MdlCancelBttn,
            WC_YourQuotePage.MdlCloseBttn,
            WC_YourQuotePage.MdlUpdateBttn
        };

        private List<Element> CusomizationModalDeductibleElements = new List<Element>
        {
            WC_YourQuotePage.MdlDeductibleLabel,
            WC_YourQuotePage.MdlPerClaimLabel,
            WC_YourQuotePage.MdlPerClaimHelpBttn,
            WC_YourQuotePage.MdlPerClaimDD
        };

        private static Dictionary<string, Element> CustomizeYourPlanDDs = new Dictionary<string, Element>
        {
            { "ELL - Each Accident / Total Policy / Each Employee", WC_YourQuotePage.MdlEachAccidentTotalDD},
            { "Deductible Per Claim", WC_YourQuotePage.MdlPerClaimDD}
        };

        private static List<string> StatesWithDeductibles = new List<string>
        {
            "AL",
            "GA",
            "MN",
            "SC",
            "TX",
        };

        private static Dictionary<string, int> WCPlans = new Dictionary<string, int>
        {
            {"Standard", 1},
            {"Plus", 2}
        };
    }
}