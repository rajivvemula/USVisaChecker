using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Driver;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_Refer
    {
        Dictionary<string, Element> ReferReasonDict = new Dictionary<string, Element>()
        {
            {"MoreThan1Claim",CA_ReferPage.MoreThanOneClaimReferReason },
            {"HowManyAutoClaims", CA_ReferPage.HowManyAutoClaimsReferReason },
            {"6orMore", CA_ReferPage.SixOrMorePowerUnitsReferReason },
            {"NumOfDriversVehicles", CA_ReferPage.NumberOfDriversVehiclesReferReason },
            {"DriverGovState", CA_ReferPage.DriverGoverningStateReferReason },
            {"NoCDL", CA_ReferPage.NoCDLHeavyTruckReferReason },
            {"UsdotInactive", CA_ReferPage.USDOTNumberInactiveReferReason },
            {"StatedAmount", CA_ReferPage.VehicleStatedAmountReferReason },
            {"ScheduleBlank", CA_ReferPage.VehicleScheduleBlankReferReason },
            {"HigherRadius", CA_ReferPage.HigherActualRadiusReferReason },
            {"InconsistentUsdot", CA_ReferPage.InconsistenciesUSDOTReportedInfoReferReason },
            {"PreferredTrucking", CA_ReferPage.PreferredTruckingClassReferReason }
        };

        [Then(@"user verifies the auth appearance of the Refer page")]
        public void ThenUserVerifiesAuthRefer(Table table)
        {
            var row = table.Rows[0];

            CA_ReferPage.YourQuoteIsNearlyReadyTitle.AssertElementIsVisible();
            CA_ReferPage.EagerToProvideQuoteNeedInfo.AssertElementIsVisible();
            CA_ReferPage.ReferralReasonsTitle.AssertElementIsVisible();

            //add looping logic with regex to parse using ; between types
            var reasonForRefer = row["Reason"];
            string pattern = @"[A-z (),./&]*";
            Regex rgx = new Regex(pattern);
            Match match = rgx.Match(reasonForRefer);

            while (match.Success)
            {
                // click on match listed
                var nextMatchFound = match.Value; //this is what is used to get the information returned from that match
                if (nextMatchFound != "")
                {
                    ReferReasonDict[nextMatchFound].AssertElementIsVisible();
                }
                match = match.NextMatch();
            }            

            CA_ReferPage.DetailsForUWTxtbox.AssertElementIsVisible();
            var detailsForUW = row["UW Details"];
            CA_ReferPage.DetailsForUWTxtbox.SetText(detailsForUW);
            CA_ReferPage.SubmitToUw.AssertElementIsVisible();
            CA_ReferPage.SubmitToUw.Click();
        }
    }
}
