using BiBerkLOB.Pages.PL;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Driver;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using BiBerkLOB.Source.Helpers;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_QuoteDetails
    {
        private readonly PLSummaryObject _plSummaryObject;

        public PL_Gen_QuoteDetails(PLSummaryObject plSummaryObject)
        {
            _plSummaryObject = plSummaryObject;
        }

        [Then(@"user verifies that the following coverages are displayed in the details of their PL (.*) Quote: (.*)")]
        public void ThenUserVerifiesThatTheFollowingCoveragesAreDisplayedInTheDetailsOfThirPL_Quote(string standardPlus, string coveragesString)
        {
            AutomationHelper.LegacyWaitForLoading(120);

            // Select the view coverage details link associated with the desired plan type
            StandardOrPlusCoverageDetails(standardPlus);

            // Title, text, top return to quote options button, get plan button and bottom return to quote options button
            ValidateBaseElements();

            //Create the lists of coverages to validate:
            var expectedCoverages = CreateListOfCoverages(coveragesString);

            // Validate Coverages by passing in the CoverageElementsDictionary Dictionary:
            ValidateCoverages(expectedCoverages, CoverageElements);

            // Risks Not Covered by Professional Liability
            ValidateRisksNotCoveredElements();

            // Deductible
            ValidateDeductibleElements();

            // Limits
            ValidateLimitsElements();

            // Premium
            ValidatePremiumElements();

            //Part of Berkshire Hathaway
            ValidatePartOfBerkshireHathawayElements();

            PL_QuoteDetails_CoverageDetails.ReturnToQuoteOptionsCTA.Click();
        }

        //
        // Logic Methods
        //

        void StandardOrPlusCoverageDetails(string p1)
        {
            if (p1.Equals("Standard"))
            {
                PL_Quote_Summary.StandardViewCoverageCTA.Click();
            }
            else if (p1.Equals("Plus"))
            {
                PL_Quote_Summary.PlusViewCoverageCTA.Click();
            }
        }

        //
        // Parsing methods:
        //

        public List<string> CreateListOfCoverages(string covString)
        {
            List<string> listOfCoverages = new List<string>();
            Regex rgx = new Regex(@"\b[^,(.*)]+");
            var result = rgx.Match(covString);

            while (result.Success)
            {
                listOfCoverages.Add(result.Value);
                result = result.NextMatch();
            }
            return listOfCoverages;
        }

        public void ValidateCoverages(List<string> expectedCovs, Dictionary<string, List<Element>> covsDictionary)
        {
            foreach (var expectedCov in expectedCovs)
            {
                foreach (KeyValuePair<string, List<Element>> coverage in covsDictionary)
                    if (expectedCov == coverage.Key)
                    {
                        foreach (var element in coverage.Value)
                        {
                            element.AssertElementIsVisible();
                        }
                    }
            }
        }

        //
        //Element assert methods:
        //
        public void ValidateBaseElements()
        {
            PL_QuoteDetails_CoverageDetails.DetailsStandardPlanTitle.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.DetailsPlusPlanTitle.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.OneYearCoverage_Copy.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.DownloadCOI_Copy.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.ReturnToQuoteOptionsCTA.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.GetPlusPlanCTA.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.BottomReturnToQuoteOptionsCTA.AssertElementIsVisible();
        }

        public void ValidateRisksNotCoveredElements()
        {
            PL_QuoteDetails_CoverageDetails.RisksNotCoveredTitle.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCoveredCopy.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCovered_EmpInjuries.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCoveredCopy_EmpInjuries.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCovered_BusPropDmg.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCoveredCopy_BusPropDmg.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCovered_BusVehicles.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCoveredCopy_BusVehicles.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCovered_CustPropDmg.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCoveredCopy_CustPropDmg.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCovered_IllegalActs.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCoveredCopy_IllegalActs.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCovered_EmpDiscrimination.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.RisksNotCoveredCopy_EmpDiscrimination.AssertElementIsVisible();
        }

        public void ValidateDeductibleElements()
        {
            PL_QuoteDetails_CoverageDetails.DeductibleTitle.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.DeductibleCopy.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.DeductiblePerOccurence.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.Deductible1k.AssertElementIsVisible();
        }

        public void ValidateLimitsElements()
        {
            PL_QuoteDetails_CoverageDetails.LimitsTitle.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.LimitsCopy_WhatIsPerOccur.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.LimitsCopy_PerOccur.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.LimitsCopy_PerOccur1Mil.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.LimitsCopy_WhatIsAggLimit.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.LimitsCopy_Agg.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.LimitsCopy_Agg1Mil.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.LimitsCopy_NotMTNY.AssertElementIsVisible();
        }

        public void ValidatePremiumElements()
        {
            PL_QuoteDetails_CoverageDetails.PremiumTitle.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.PremiumCopy_DefinePremium.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.PremiumCopy_Monthly.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.PremiumCopy_MonthlyCost.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.PremiumCopy_Yearly.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.PremiumCopy_YearlyCost.AssertElementIsVisible();
        }

        public void ValidatePartOfBerkshireHathawayElements()
        {
            PL_QuoteDetails_CoverageDetails.PartBerkshireHathawayTitle.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.PartBerkshireHathawayCopy.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.CancellationTitle.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.CancellationCopy.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.CancellationPhoneNumber.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.TermsCondTitle.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.TermsCondCopy_YouAreEntitled.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.TermsCondPhoneNumber.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.TermsCondCopy_ForFullTerms.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.TermsCondHyperlink.AssertElementIsVisible();
            PL_QuoteDetails_CoverageDetails.GetPlanCTA.AssertElementIsVisible();
        }

        //
        //Element lists:
        //

        public static List<Element> PLElements = new List<Element>
        {
            // Coverages
            PL_QuoteDetails_CoverageDetails.CoveragesTitle,
            PL_QuoteDetails_CoverageDetails.CoveragesCopy,
            PL_QuoteDetails_CoverageDetails.CovPLEOTitle,
            PL_QuoteDetails_CoverageDetails.CovPLEOChkbox,
            PL_QuoteDetails_CoverageDetails.CovPLEO_PLCoversLawsuits_Copy,
            PL_QuoteDetails_CoverageDetails.CovPLEO_MistakesOrAlleged_Copy,
            PL_QuoteDetails_CoverageDetails.CovPLEO_FailureOrAlleged_Copy,
            PL_QuoteDetails_CoverageDetails.CovPLEO_CommonClaims_Copy,
            PL_QuoteDetails_CoverageDetails.CovPLEO_Negligence_Copy,
            PL_QuoteDetails_CoverageDetails.CovPLEO_Violation_Copy,
            PL_QuoteDetails_CoverageDetails.CovPLEO_Wrong_Copy,
            PL_QuoteDetails_CoverageDetails.CovPLEO_Privacy_Copy,
            PL_QuoteDetails_CoverageDetails.CovPLEO_PolicyCov_Copy,
            PL_QuoteDetails_CoverageDetails.CovPLEO_LawsuitGroundless_Copy,

            // Benefits
            PL_QuoteDetails_CoverageDetails.BenefitsTitle,
            PL_QuoteDetails_CoverageDetails.BenefitsCopy,
            PL_QuoteDetails_CoverageDetails.BenePLTitle,
            PL_QuoteDetails_CoverageDetails.BenePLChkbox,
            PL_QuoteDetails_CoverageDetails.BenePLCopy_EOLawsuit,
            PL_QuoteDetails_CoverageDetails.BenePLCopy_Discliplinary,
            PL_QuoteDetails_CoverageDetails.BenePLCopy_SuedDisciplined
        };

        public static List<Element> EOElements = new List<Element>
        {
            // Coverages
            PL_QuoteDetails_CoverageDetails.CoveragesTitle,
            PL_QuoteDetails_CoverageDetails.CoveragesCopy,
            PL_QuoteDetails_CoverageDetails.CovEOTitle,
            PL_QuoteDetails_CoverageDetails.CovEOChkbox,
            PL_QuoteDetails_CoverageDetails.CovEOParagraph,
            PL_QuoteDetails_CoverageDetails.CovEOCopy_Mistakes,
            PL_QuoteDetails_CoverageDetails.CovEOCopy_Failure,
            PL_QuoteDetails_CoverageDetails.CovEOCopy_Common,
            PL_QuoteDetails_CoverageDetails.CovEOCopy_Negligence,
            PL_QuoteDetails_CoverageDetails.CovEOCopy_Violation,
            PL_QuoteDetails_CoverageDetails.CovEOCopy_Wrong,
            PL_QuoteDetails_CoverageDetails.CovEOCopy_Privacy,
            PL_QuoteDetails_CoverageDetails.CovEOCopy_Policy,
            PL_QuoteDetails_CoverageDetails.CovEOCopy_Errors,

            // Benefits
            PL_QuoteDetails_CoverageDetails.BenefitsTitle,
            PL_QuoteDetails_CoverageDetails.BenefitsCopy,
            PL_QuoteDetails_CoverageDetails.BeneEOTitle,
            PL_QuoteDetails_CoverageDetails.BeneEOChkbox,
            PL_QuoteDetails_CoverageDetails.BeneEOCopy_Lawsuit,
            PL_QuoteDetails_CoverageDetails.BeneEOCopy_Disciplinary,
            PL_QuoteDetails_CoverageDetails.BeneEOCopy_Appearance
        };

        public static List<Element> CopyElements = new List<Element>
        {
            // Coverages
            PL_QuoteDetails_CoverageDetails.CovCopyTitle,
            PL_QuoteDetails_CoverageDetails.CovCopyChkbox,
            PL_QuoteDetails_CoverageDetails.CovCopy_CoversLawsuits,
            PL_QuoteDetails_CoverageDetails.CovCopy_Reproducing,
            PL_QuoteDetails_CoverageDetails.CovCopy_UsingAnother,
            PL_QuoteDetails_CoverageDetails.CovCopy_IncludesActs,

            // Benefits
            PL_QuoteDetails_CoverageDetails.BeneCopyrightTitle,
            PL_QuoteDetails_CoverageDetails.BeneCopyrightChkbox,
            PL_QuoteDetails_CoverageDetails.BeneCopyrightCopy
        };

        public static List<Element> CopyPlusElements = new List<Element>
        {
            // Coverages
            PL_QuoteDetails_CoverageDetails.CovCopyPLUSTitle,
            PL_QuoteDetails_CoverageDetails.CovCopyPLUSChkbox,
            PL_QuoteDetails_CoverageDetails.CovCopyPLUS_CoversLawsuits,
            PL_QuoteDetails_CoverageDetails.CovCopyPLUS_Reproducing,
            PL_QuoteDetails_CoverageDetails.CovCopyPLUS_UsingAnother,
            PL_QuoteDetails_CoverageDetails.CovCopyPLUS_IncludesActs,

            // Benefits
            PL_QuoteDetails_CoverageDetails.BeneCopyrightPLUSTitle,
            PL_QuoteDetails_CoverageDetails.BeneCopyrightPLUSChkbox,
            PL_QuoteDetails_CoverageDetails.BeneCopyrightPLUSCopy
        };

        public static List<Element> PollutionElements = new List<Element>
        {
            //Coverages
            PL_QuoteDetails_CoverageDetails.CovPollutionTitle,
            PL_QuoteDetails_CoverageDetails.CovPollutionChkbox,
            PL_QuoteDetails_CoverageDetails.CovPollutionCopy,

            // Benefits
            PL_QuoteDetails_CoverageDetails.BenePollutionTitle,
            PL_QuoteDetails_CoverageDetails.BenePollutionChkbox,
            PL_QuoteDetails_CoverageDetails.BenePollutionCopy
        };

        public static List<Element> CyberElements = new List<Element>
        {
            // Coverages
            PL_QuoteDetails_CoverageDetails.CovCyberTitle,
            PL_QuoteDetails_CoverageDetails.CovCyberChkbox,
            PL_QuoteDetails_CoverageDetails.CovCyberCopy,
            PL_QuoteDetails_CoverageDetails.CovCyberCopy_DataBreach,
            PL_QuoteDetails_CoverageDetails.CovCyberCopy_RequireInCourt,
            PL_QuoteDetails_CoverageDetails.CovCyberCopy_Retro,

            // Benefits
            PL_QuoteDetails_CoverageDetails.BeneCyberTitle,
            PL_QuoteDetails_CoverageDetails.BeneCyberChkbox,
            PL_QuoteDetails_CoverageDetails.BeneCyberCopy_DataBreach,
            PL_QuoteDetails_CoverageDetails.BeneCyberCopy_RegulatoryAction
        };

        public static List<Element> RealEstElements = new List<Element>
        {
            // Coverages
            PL_QuoteDetails_CoverageDetails.CovRealEstateTitle,
            PL_QuoteDetails_CoverageDetails.CovRealEstateChkbox,
            PL_QuoteDetails_CoverageDetails.CovRealEstateCopy,
            PL_QuoteDetails_CoverageDetails.CovRealEstateCopy_DamageDuringOpenHouse,
            PL_QuoteDetails_CoverageDetails.CovRealEstateCopy_DisclosePollutant,
            PL_QuoteDetails_CoverageDetails.CovRealEstateCopy_FairHousingAct,
            PL_QuoteDetails_CoverageDetails.CovRealEstate_Retro,

            //Benefits
            PL_QuoteDetails_CoverageDetails.BeneRealEstateTitle,
            PL_QuoteDetails_CoverageDetails.BeneRealEstateChxbox,
            PL_QuoteDetails_CoverageDetails.BeneRealEstateCopy_PropDamage,
            PL_QuoteDetails_CoverageDetails.BeneRealEstateCopy_DisclosePollutant,
            PL_QuoteDetails_CoverageDetails.BeneRealEstateCopy_FairHousingAct
        };

        public static List<Element> PLBeneSAbuseElements = new List<Element>
        {
            PL_QuoteDetails_CoverageDetails.BeneSAbuseTitle,
            PL_QuoteDetails_CoverageDetails.BeneSAbuseChkbox,
            PL_QuoteDetails_CoverageDetails.BeneSAbuseCopy,
        };

        public static Dictionary<string, List<Element>> CoverageElements = new Dictionary<string, List<Element>>
        {
                { "PL", PLElements},
                { "E&O", EOElements},
                { "Copyright", CopyElements},
                { "Copyright Plus", CopyPlusElements},
                { "Pollution", PollutionElements},
                { "Cyber", CyberElements},
                { "Real Estate", RealEstElements},
                { "Sexual Abuse", PLBeneSAbuseElements}
        };
    }
}