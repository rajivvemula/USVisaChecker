using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using HitachiQA.Driver;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.Other;
using HitachiQA;
using static HitachiQA.Driver.UserActions;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CACoverageDetailsAutomation
{
    private readonly CASummaryObject _caSummaryObject;

    public CACoverageDetailsAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public void VerifyPageHeader()
    {
        //Verify top part of page
        CA_CoverageDetailsPage.QuoteDetailsHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.QuoteStartTitle.AssertElementIsVisible();
        
        CA_CoverageDetailsPage.QuoteDetailsCopy.AssertElementIsVisible();
    }

    public void VerifyPolicyStartDateInTitle()
    {
        //Verify date of start is what was entered on Intro Page     
        //Quote Details page displays date like "MM/DD/YY"
        //Policy Start property displays date like "MM/DD/YYYY"
        CA_CoverageDetailsPage.QuoteStartTitle.AssertElementContainsText(Functions.ReformatDateString(_caSummaryObject.PolicyStart, "MM/dd/yy"));
    }

    public void LeaveThenReEnterDetails()
    {
        CA_CoverageDetailsPage.ReturnToQuoteCTA.Click();
        CA_QuoteSummaryPage.ViewCoverageDetailsCTA.Click();
    }

    public void VerifyCoverageSection()
    {
        CA_CoverageDetailsPage.QuoteDetailsHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.CoveragesHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.CoveragesSubHeader.AssertElementIsVisible();

        /*
         * Handles what appears in "Coverages"
         * "Specific events trigger coverage by this policy. Coverage applies even if your vehicle is used for personal activities."
         * Based on the coverages selected on the quote page (stored in summary object), verify that they appear
         */
        foreach (var coverage in _caSummaryObject.Coverages)
        {
            HandleCoverageDetailsSection(coverage.CoverageName, true);
        }
    }

    public void VerifyDriversSection()
    {
        CA_CoverageDetailsPage.DriversHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.DriverNameHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.DriverDOBHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.DriverLicenseStateHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.DriverLicenseNumberHeader.AssertElementIsVisible();

        VerifyDriverTable();
    }

    public void VerifyNotSelectedCoverages(Table table)
    {
        if (!table.Rows.Any(row => string.IsNullOrEmpty(row["Coverages Not Selected"])))
        {
            return;
        }
        CA_CoverageDetailsPage.CoveragesNotSelectedHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.CoveragesNotSelectedSubHeader.AssertElementIsVisible();

        //Iterate through values passed in via Table about what coverages not selected

        /*
         * Pulled from the table, verify that the values of the coverages not selected
         * appear as "Not selected" with the "cancel-icon" on the section further down on the page
         */
        foreach (TableRow rowy in table.Rows)
        {
            HandleCoverageDetailsSection(rowy["Coverages Not Selected"], false);
        }
    }

    public void VerifyRisksNotCovered()
    {
        CA_CoverageDetailsPage.NotCoveredHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.NotCoveredCopy.AssertElementIsVisible();
        CA_CoverageDetailsPage.PropertyDamageHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.PropertyDamageCopy.AssertElementIsVisible();
        CA_CoverageDetailsPage.WCInjuriesHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.WCInjuriesCopy.AssertElementIsVisible();
        CA_CoverageDetailsPage.NonOwnedVehiclesHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.NonOwnedVehiclesCopy.AssertElementIsVisible();
        CA_CoverageDetailsPage.MobileEquipmentHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.MobileEquipmentCopy.AssertElementIsVisible();
        CA_CoverageDetailsPage.RacingHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.RacingCopy.AssertElementIsVisible();
    }

    public void VerifyBenefits()
    {
        CA_CoverageDetailsPage.BenefitsHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.BenefitsSubHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.VehicleVINHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.VehicleYMMHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.CoverageHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.VehicleLimitHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.VehicleDeductibleHeader.AssertElementIsVisible();

        VerifyVehicleBenefitsTable();

        CA_CoverageDetailsPage.BenefitsCopy.AssertElementIsVisible();
        //The following depends on coverages that WERE selected so choose the copies appropriate here

        foreach (var coverage in _caSummaryObject.Coverages)
        {
            HandleBenefitsSectionCoverageAppearance(coverage.CoverageName);
        }
    }

    public void VerifyPremiums()
    {
        CA_CoverageDetailsPage.PremiumHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.PremiumCopy.AssertElementIsVisible();
        CA_CoverageDetailsPage.PremiumMonthlyCopy.AssertElementIsVisible();
        CA_CoverageDetailsPage.PremiumYearlyCopy.AssertElementIsVisible();

        //depending on what was chosen, verify either the monthly or yearly amount is listed in the appropriate copy
        if (_caSummaryObject.QuoteChooseYearlyOrMonthly.Equals("yearly"))
        {
            CA_CoverageDetailsPage.PremiumYearlyCopy.AssertElementContainsText(_caSummaryObject.AmountYouPayToday);
        }
        else
        {
            CA_CoverageDetailsPage.PremiumMonthlyCopy.AssertElementContainsText(_caSummaryObject.AmountYouPayToday);
        }
    }

    public void VerifyLegalStuff()
    {
        CA_CoverageDetailsPage.PartOfBHHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.PartOfBHCopy.AssertElementIsVisible();
        CA_CoverageDetailsPage.CancellationHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.CancellationCopy.AssertElementIsVisible();
        CA_CoverageDetailsPage.TACHeader.AssertElementIsVisible();
        CA_CoverageDetailsPage.TACCopyOne.AssertElementIsVisible();
        CA_CoverageDetailsPage.TACCopyTwo.AssertElementIsVisible();
    }

    public void TestFooterReturnButton()
    {
        CA_CoverageDetailsPage.FooterReturnToQuoteCTA.Click();
        CA_QuoteSummaryPage.ViewCoverageDetailsCTA.Click();
    }

    public void ClickContinue()
    {
        ScrollWithCount(3);
        CA_CoverageDetailsPage.GetPlanCTA.Click();
    }

    public void TestTermsAndConditionsInNewTab()
    {
        // check if clicking link opens a new tab
        var originalTabCount = UserActions.GetTabs().Count;
        CA_CoverageDetailsPage.TACLink.Click();
        var allTabs = UserActions.GetTabs();
        Assert.IsTrue(allTabs.Count == originalTabCount + 1);

        // ensure we're in new tab and verify we are on terms and conditions
        UserActions.SwitchToTab(allTabs[1]);
        TermsAndConditionsPage.HeaderLabel.AssertElementIsVisible();
    }

    private void HandleCoverageDetailsSection(string coverageAlias, bool isSelected)
    {
        var coverage = MapAliasToCoverageName(coverageAlias);
        var coverageDetails = MapAliasToExpectedDetails(coverageAlias);

        var coverageSection = isSelected
            ? CA_CoverageDetailsPage.GetAppliedCoverageSection(coverage, coverageDetails)
            : CA_CoverageDetailsPage.GetNotSelectedCoverageSection(coverage, coverageDetails);

        coverageSection.Assert();
    }

    private void VerifyDriverTable()
    {
        //Read from drivers objects and use the GetDriverInfo on the page file to check the presence of the values
        foreach (var driver in _caSummaryObject.DriversList)
        {
            var tableRowCells = GetDriverRow(driver);
            AutomationHelper.ValidateElements(tableRowCells, 1);
        }
    }

    private Element[] GetDriverRow(DriversObject driver)
    {
        //driver info that will be in the table
        var driverValues = new string[]
        {
            driver.DriverFullName, 
            driver.DateOfBirth, 
            driver.DriversLicenseState.Abbreviation, 
            driver.DriverLicenseNumber
        };

        //cells are mapped using the values entered for the driver
        return driverValues.Select(CA_CoverageDetailsPage.GetDriverInfo).ToArray();
    }

    private void VerifyVehicleBenefitsTable()
    {

        //Read from vehicles objects that are stored and verify the value is present here
        foreach (var vehicle in _caSummaryObject.VehiclesList)
        {
            //VIN, Year/Make/Model, Coverage, Limit, Deductible
            var tableRow = GetVehicleRow(vehicle);
            AutomationHelper.ValidateElements(tableRow, 1);
        }
    }

    private Element[] GetVehicleRow(VehiclesObject vehicle)
    {
        //driver info that will be in the table
        var vehicleValues = new string[]
        {
            vehicle.VIN,
            vehicle.VehicleYrMkMdl,
            vehicle.CoverageDetails,
            GetLimitLabel(vehicle),
            DeductibleFormattedDollarValue(vehicle)
        };

        //cells are mapped using the values entered for the driver
        return vehicleValues.Select(CA_CoverageDetailsPage.GetVehicleInfo).ToArray();
    }

    private static string GetLimitLabel(VehiclesObject vehicle)
    {
        if (vehicle.VehicleWorth == 0 && vehicle.TrailerWorth == 0)
        {
            return "Actual Cash Value";
        }
     
        return vehicle.IsTrailer ? vehicle.TrailerWorth.ToString("C0") : vehicle.VehicleWorth.ToString("C0");
    }

    // converts the vehicle coverage string into deductible dollar value (comma formatted)
    private string DeductibleFormattedDollarValue(VehiclesObject vehicle)
    {
        if (!vehicle.CoverageDetails.Contains("Deductible"))
        {
            return "N/A";
        }
        // start with coverage text
        var coverageText = vehicle.CoverageDetails;
        // remove "Comprehensive Deductible" 
        coverageText = coverageText.Replace("Comprehensive Deductible", "");
        // remove "Collision Deductible"
        coverageText = coverageText.Replace("Collision Deductible", "");
        // separate values
        var deductibleSplit = coverageText.Split("/");
        // convert to decimal
        var styleFlags = NumberStyles.AllowCurrencySymbol | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
        var deductibleValues = deductibleSplit.Select(s => decimal.Parse(s, styleFlags));
        // combine as comma separated currency strings with 2 trailing 0's
        var deductible= string.Join(" / ", deductibleValues.Select(d => d.ToString("C")));

        return deductible;
    }

    private string MapAliasToCoverageName(string tableValue)
    {
        switch (tableValue)
        {
            case "BIPD": 
                return "Auto Liability";
            case "UMBI":
            case "UIMBI":
            case "UMBIPD":
            case "VUM":
                return "Uninsured/Underinsured Motorist";
            case "Collision/Comprehensive":
            case "Rental":
                return "Vehicle Coverage";
            case "Medical": 
                return "Medical Payments";
            case "Cargo": 
                return "Cargo Liability";
            case "Trailer": 
            case "In-Tow": 
                return "Uncategorized";
        }
        throw new NotImplementedException($"'{tableValue}' is not a supported coverage in automation");
    }

    private string[] MapAliasToExpectedDetails(string tableValue)
    {
        var coverageDetails = new List<string>();
        switch (tableValue)
        {
            case "BIPD":
                coverageDetails.Add("Bodily Injury Property Damage (BIPD)");
                break;
            case "UMBI":
                coverageDetails.Add("Uninsured Motorists BI");
                break;
            case "UIMBI":
                coverageDetails.Add("Underinsured Motorists BI");
                break;
            case "UMBIPD":
                coverageDetails.Add("Uninsured BIPD");
                break;
            case "VUM":
                coverageDetails.Add("Vehicle Uninsured Motorist");
                break;
            case "Collision/Comprehensive":
                coverageDetails.Add("Collision");
                coverageDetails.Add("Comprehensive");
                break;
            case "Medical":
                coverageDetails.Add("Medical Payments");
                break;
            case "Rental":
                coverageDetails.Add("Rental Reimbursement");
                break;
            case "Cargo":
                coverageDetails.Add("Cargo Coverage");
                break;
            case "Trailer":
                coverageDetails.Add("Trailer Interchange");
                break;
            case "In-Tow":
                coverageDetails.Add("In-Tow");
                break;
            default:
                throw new NotImplementedException($"'{tableValue}' is not a supported coverage in automation");
        }

        return coverageDetails.ToArray();
    }
    
    /*
     * In the Benefits section, verify that the coverages selected are reflected here as well.
     * Based on the coverages selected on the quote page, verify that they appear
     */
    private void HandleBenefitsSectionCoverageAppearance(string selectedCovName)
    {
        var selectedCoverage = _caSummaryObject.Coverages.Single(cov => cov.CoverageName == selectedCovName);
        switch (selectedCovName)
        {
            case "BIPD":
                CA_CoverageDetailsPage.BenefitsBIPDHeader.AssertElementIsVisible();
                CA_CoverageDetailsPage.BenefitsBIPDCopy(selectedCoverage.CoverageDetails).AssertElementIsVisible();
                break;
            case "Uninsured":
                CA_CoverageDetailsPage.BenefitsUninsuredHeader.AssertElementIsVisible();
                CA_CoverageDetailsPage.BenefitsUninsuredCopy.AssertElementIsVisible();
                break;
            case "Underinsured":
                CA_CoverageDetailsPage.BenefitsUnderinsuredHeader.AssertElementIsVisible();
                CA_CoverageDetailsPage.BenefitsUnderinsuredCopy.AssertElementIsVisible();
                break;
            case "Medical":
                CA_CoverageDetailsPage.BenefitsMedicalPaymentsHeader.AssertElementIsVisible();
                CA_CoverageDetailsPage.GetBenefitsMedicalPaymentsCopy(selectedCoverage.CoverageDetails).AssertElementIsVisible();
                break;
            case "Rental":
                CA_CoverageDetailsPage.BenefitsRentalReinHeader.AssertElementIsVisible();
                CA_CoverageDetailsPage.GetBenefitsRentalReinCopy(selectedCoverage.CoverageDetails).AssertElementIsVisible();
                CA_CoverageDetailsPage.BenefitsRentalReinVehiclesIncluded.AssertElementIsVisible();
                //if model is not blank add it to part of the string to send to find the xpath
                foreach (var vehicle in _caSummaryObject.VehiclesList)
                {
                    //strip the Year and a Space from the value
                    var result = Regex.Replace(vehicle.VehicleYrMkMdl, "([0-9]{4} )", "");
                    //insert the resulting string here so it can be located
                    CA_CoverageDetailsPage.GetBenefitsRentalReinVehicle(result).AssertElementIsVisible();
                }

                break;
            case "Cargo":
                CA_CoverageDetailsPage.BenefitsCargoHeader.AssertElementIsVisible();
                CA_CoverageDetailsPage.GetBenefitsCargoCopy(selectedCoverage.CoverageDetails).AssertElementIsVisible();
                break;
            case "Trailer":
                CA_CoverageDetailsPage.TrailerInterchangeHeader.AssertElementIsVisible();
                CA_CoverageDetailsPage.GetTrailerInterchangeCopy(selectedCoverage.CoverageDetails).AssertElementIsVisible();
                break;
            default:
                break;
        }
    }
}