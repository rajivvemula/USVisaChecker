using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
namespace BiBerkLOB.Pages.WC
{
    [Binding]
    class WC_CustomizeYourPlanPage
    {
        // Employer Liablility Limits
        public static Element EmployerLiabilityLimitsHeader => new Element(By.XPath("//div[@data-qa='employer_liability_limits_2']"));
        public static Element EamployerLiablilityLimitsHelper => new Element(By.XPath("//bb-tooltip[@data-qa='employer_liability_limits_info2']"));
        public static Element EmployerLiablilityLimitsHelperText => new Element(By.XPath("//button[@data-qa='employer_liability_limits_info2']"));
        public static Element EachAccidentText = new Element(By.XPath("//div[@data-qa='multiple_limits_each_accident_2']"));
        public static Element EachAccidentPencilButton = new Element(By.XPath("//button[@data-qa='multiple_limits_each_accident_customize_button']"));
        public static Element EachAccidentAmountText = new Element(By.XPath("//div[@data-qa='multiple_limits_each_accident_amount_2']"));
        public static Element PolicyTotalPencilButton = new Element(By.XPath("//button[@data-qa='multiple_limits_customize_plan_button_2']"));
        public static Element PoliciyTotalText = new Element(By.XPath("//div[@data-qa='multiple_limits_policy_total_2']"));
        public static Element PolicyTotalAmountText = new Element(By.XPath("//div[@data-qa='multiple_limits_policy_amount_2']"));
        public static Element EachEmployeePencilButton = new Element(By.XPath("//button[@data-qa='multiple_limits_each_employee_customize_plan_button_2']"));
        public static Element EachEmployeeText = new Element(By.XPath("//div[@data-qa='multiple_limits_each_employee_2']"));
        public static Element EachEmployeeAmountText = new Element(By.XPath("//div[@data-qa='multiple_limits_each_employee_amount_2']"));
        /* ------ start popup --------- */
        public static Element CutomizeYourPlanHeader = new Element(By.XPath("//h3[@data-qa='wc_customize_your_plan_header']"));
        public static Element PopUpEmployerLiablilityLimitsText = new Element(By.XPath("//div[@data-qa='wc_customize_employer_liability_limits']"));
        public static Element PopUpEachAccidentText = new Element(By.XPath("//div[@data-qa='wc_customize_accident_policy_employee_label']"));
        public static Element PopUpEachAccident_Helper = new Element(By.XPath("//button[@data-qa='wc_customize_helptext_tooltip']"));
        public static Element PopUpEachAccident_HelperText = new Element(By.XPath("//bb-tooltip[@data-qa='wc_customize_helptext']"));
        public static Element CustomizePopUp_DD = new Element(By.XPath("//select[@data-qa='wc_customize_limits_dropdown']"));
        public static Element CustomizePopUpCancelButton = new Element(By.XPath("//a[@data-qa='wc_customize_cancel_button']"));
        public static Element CustomizePopUpUpdateButton = new Element(By.XPath("//button[@data-qa='wc_customize_update_button']"));
        public static Element CustomizePopUpXButton = new Element(By.XPath("//button[@data-qa='wc_customize_close_modal_button']"));
        /* ------ end popup --------- */
    }
}