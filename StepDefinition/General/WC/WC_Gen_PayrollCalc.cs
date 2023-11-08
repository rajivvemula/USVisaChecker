using System.Collections.Generic;
using BiBerkLOB.Pages.WC;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.WC;

[Binding]
public sealed class WC_Gen_PayrollCalc
{
    private int _jobDutyCounter;

    [Then(@"user verifies the Payroll Calculator page")]
    [Then(@"user verifies the Wage Calculator page")]
    public void ThenUserVerifiesCalcPage()
    {
        WC_PayrollCalculatorPage.LoadingRequirements.AssertInWC();
    }

    [When(@"the business (is|is not) seasonal")]
    public void WhenBusIsSeasonal(string isOrNot)
    {
        var yesNoMapping = new Dictionary<string, string>()
        {
            {"is", "yes"},
            {"is not", "no"}
        };

        WC_PayrollCalculatorPage.SeasonalBusInput.AssertAllElements(3);
        WC_PayrollCalculatorPage.SeasonalBusInput.EnterResponse(yesNoMapping[isOrNot]);
    }

    [Then(@"user fills out the Payroll Calculator with these values:")]
    [Then(@"user fills out the Wage Calculator with these values:")]
    public void ThenUserFillsOutCalc(Table table)
    {
        _jobDutyCounter = 1;
        foreach (TableRow rowy in table.Rows)
        {
            var avgWage = rowy["Average Employee Wage"];
            var numEmployees = rowy["Number of Employees"];
            var hoursPerWeek = rowy["Hours per Week"];
            
            FillOutStandardForm(avgWage, numEmployees, hoursPerWeek);

            if (rowy.ContainsKey("Weeks per Year"))
            {
                var weeksPerYear = rowy["Weeks per Year"];
                FillOutSeasonalSection(weeksPerYear);
            }

            _jobDutyCounter++;
        }
    }

    private void FillOutSeasonalSection(string weeksPerYear)
    {
        WC_PayrollCalculatorPage.NumWeeksOperatedInput(_jobDutyCounter).AssertAllElements(3);
        WC_PayrollCalculatorPage.NumWeeksOperatedInput(_jobDutyCounter).EnterResponse(weeksPerYear);
    }

    private void FillOutStandardForm(string avgWage, string numEmployees, string hoursPerWeek)
    {
        WC_PayrollCalculatorPage.AvgWagePerEmpInput(_jobDutyCounter).AssertAllElements(3);
        WC_PayrollCalculatorPage.AvgWagePerEmpNumber(_jobDutyCounter).SetTextSlow(avgWage);

        WC_PayrollCalculatorPage.NumEmployeesInput(_jobDutyCounter).AssertAllElements(3);
        WC_PayrollCalculatorPage.NumEmployeesInput(_jobDutyCounter).EnterResponse(numEmployees);

        WC_PayrollCalculatorPage.AvgHoursPerWeekInput(_jobDutyCounter).AssertAllElements(3);
        WC_PayrollCalculatorPage.AvgHoursPerWeekInput(_jobDutyCounter).EnterResponse(hoursPerWeek);
    }

    [Then(@"user clicks continue from the Payroll Calculator")]
    [Then(@"user clicks continue from the Wage Calculator")]
    public void ThenUserContinues()
    {
        WC_PayrollCalculatorPage.ContinueBtn.Click();
        AutomationHelper.WaitForWCLoading();
    }

    [Then(@"user clicks back and modify from the Payroll Calculator")]
    [Then(@"user clicks back and modify from the Wage Calculator")]
    public void ThenUserGoesBack()
    {
        WC_PayrollCalculatorPage.BackAndModify.Click();
        AutomationHelper.WaitForWCLoading();
    }

    [Then(@"user clicks save for later from the Payroll Calculator")]
    [Then(@"user clicks save for later from the Wage Calculator")]
    public void ThenUserSavesForLater()
    {
        WC_PayrollCalculatorPage.SaveForLater.Click();
        AutomationHelper.WaitForWCLoading();
    }
}