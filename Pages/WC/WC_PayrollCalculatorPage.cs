using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.WC;

public class WC_PayrollCalculatorPage
{
    // Title
    public static Element WageCalcTitle => new Element(By.XPath($"//h1[@data-qa='WC_payrollCalc_title']"));
    public static Element WageCalcSubTitle => new Element(By.XPath($"//p[@data-qa='WC_payrollCalc_subTitle']"));
    public static LoadingRequirements LoadingRequirements => new LoadingRequirements(WageCalcTitle, WageCalcSubTitle);

    // Is this a seasonal business?
    private static Element SeasonalBusQst => new Element(By.XPath("//span[@data-qa='seasonal_business_label']"));
    private static Element SeasonalBusAnswer(string yesOrNo) => new Element(By.XPath($"//bb-options[@data-qa='WC_payrollCalc_seasonalBtn']//button[text()='{yesOrNo.ToLower()}']"));
    public static InputSection SeasonalBusInput => new YesOrNoInput(SeasonalBusAnswer("yes"), SeasonalBusAnswer("no"))
        .AsAQuestion(SeasonalBusQst);

    // JOB DUTY ================================================================================
    public static Element JobDutySectionHeader => new Element(By.XPath($"//span[starts-with(@data-qa, 'WC_payrollCalc_jobDuty')]"));

    // Estimated Average Wage per Employee
    private static Element AvgWagePerEmpQst(int index) => new Element(By.XPath($"(//span[starts-with(@data-qa, 'WC_payrollCalc_avgWage_text')])[{index}]"));
    public static Element AvgWagePerEmpNumber(int index) => new Element(By.XPath($"(//payroll-calc-number[starts-with(@data-qa, 'payrollcalcdetail_avgWagEE_input')]//input)[{index}]"));
    private static Element AvgWagePerEmpHint(int index) => new Element(By.XPath($"(//span[starts-with(@data-qa, 'WC_payrollCalc_avgWage_infoText')])[{index}]"));
    public static InputSection AvgWagePerEmpInput(int index) => new TextBoxInput(AvgWagePerEmpNumber(index))
        .AsAQuestion(AvgWagePerEmpQst(index))
        .WithExtraText(AvgWagePerEmpHint(index));

    // Number of Employees
    private static Element NumEmployeesQst(int index) => new Element(By.XPath($"(//span[starts-with(@data-qa, 'WC_payrollCalc_numEE_text')])[{index}]"));
    private static Element NumEmployeesNumber(int index) => new Element(By.XPath($"(//payroll-calc-number[starts-with(@data-qa, 'WC_payrollCalcDetail_NumOfEE_input')]//input)[{index}]"));
    private static Element NumEmployeesHint(int index) => new Element(By.XPath($"(//span[starts-with(@data-qa, 'WC_payrollCalc_numEE_infoText')])[{index}]"));
    public static InputSection NumEmployeesInput(int index) => new TextBoxInput(NumEmployeesNumber(index))
        .AsAQuestion(NumEmployeesQst(index))
        .WithExtraText(NumEmployeesHint(index));

    // Estimated Average Hours Worked per Week
    private static Element AvgHoursPerWeekQst(int index) => new Element(By.XPath($"(//span[starts-with(@data-qa, 'WC_payrollCalc_avgHour_text')])[{index}]"));
    private static Element AvgHoursPerWeekNumber(int index) => new Element(By.XPath($"(//payroll-calc-number[starts-with(@data-qa, 'WC_payrollCalcDetail_avgHour_input')]//input)[{index}]"));
    private static Element AvgHoursPerWeekHint(int index) => new Element(By.XPath($"(//span[starts-with(@data-qa, 'WC_payrollCalc_avgHour_infoText')])[{index}]"));
    public static InputSection AvgHoursPerWeekInput(int index) => new TextBoxInput(AvgHoursPerWeekNumber(index))
        .AsAQuestion(AvgHoursPerWeekQst(index))
        .WithExtraText(AvgHoursPerWeekHint(index));

    // Estimated Number of Weeks Operated per Year
    private static Element NumWeeksOperatedQst(int index) => new Element(By.XPath($"(//span[starts-with(@data-qa, 'WC_payrollCalc_operatedPerYear')])[{index}]"));
    private static Element NumWeeksOperatedNumber(int index) => new Element(By.XPath($"(//payroll-calc-number[starts-with(@data-qa, 'WC_payrollCalcDetail_operatedPerYear')]//input)[{index}]"));
    public static InputSection NumWeeksOperatedInput(int index) => new TextBoxInput(NumWeeksOperatedNumber(index))
        .AsAQuestion(NumWeeksOperatedQst(index));

    // END ================================================================
    public static Element ContinueBtn => new Element(By.XPath("//button[@data-qa='WC_payrollCalc_continue_button']"));

    public static Element SaveForLater => new Element(By.XPath("//a[@data-qa='save_for_later_Save for Later']"));
    public static Element BackAndModify => new Element(By.XPath("//a[@data-qa='wc_payrollCalc_modify_button']"));
}