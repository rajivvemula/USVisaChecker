using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.BOP
{
    public sealed class BOP_BusinessDetailsPage
    {
        //Title elements
        public static Element Title => new Element(By.XPath("//h1[@data-qa='Business Information-label']"));
        public static Element TitleSubLabel => new Element(By.XPath("//h6[@data-qa='Business Information-sub-label']"));

        //What percentage of revenue is from cremation services?
        // These are the available options to choose:
        // 0%
        // 1-25%
        // 26-50%
        // 51-75%
        // 76-100%
        public static Element CremationRevenueQST => new Element(By.XPath(""));
        public static Element GetCremationRevenueOption(string choiceValue) => new Element($"(//button[@data-qa='_apollo_CremationRevenue-8010-{choiceValue}-button']");
        public static ChoiceGroup GetCremationRevenueChoices => new ChoiceGroup(GetCremationRevenueOption);
        public static InputSection GetCremationRevenueInput => new SingleChoiceGroupInput(GetCremationRevenueChoices)
            .AsAQuestion(CremationRevenueQST)
            .IsDynamicallyRendered(BOP_ResusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Do you do any direct physical work such as construction, landscaping, or farming?
        public static Element PhysicalWorkQST => new Element(By.XPath("//label[@data-qa='_apollo_PhysicalWork-label']"));
        public static Element PhysicalWorkYes => new Element(By.XPath("//button[@data-qa='_apollo_PhysicalWork-8010-yes-button']"));
        public static Element PhysicalWorkNo => new Element(By.XPath("//button[@data-qa='_apollo_PhysicalWork-8010-no-button']"));
        public static InputSection PhysicalWorkInput => new YesOrNoInput(PhysicalWorkYes, PhysicalWorkNo)
            .AsAQuestion(PhysicalWorkQST);

        //What percentage of sales is from tires?
        public static Element SalesFromTiresQST => new Element(By.XPath("//label[@data-qa='_apollo_TireSales1-label']"));
        public static Element SalesFromTiresTextBox => new Element(By.XPath("//input[@data-qa='_apollo_TireSales1']"));
        public static InputSection SalesFromTiresInput => new TextBoxInput(SalesFromTiresTextBox)
            .AsAQuestion(SalesFromTiresQST);

        //What is the estimated W-2 employee payroll for these operations over the next 12 months?
        public static Element EstimatedW2QST => new Element(By.XPath("//label[@data-qa='_apollo_FollowupEmpPayroll1-label']"));
        public static Element EstimatedW2TxtBox => new Element(By.XPath("//input[@data-qa='_apollo_FollowupEmpPayroll1']"));
        public static Element EstimatedW2Helper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_FollowupEmpPayroll1']"));
        public static Element EstimatedW2HelperTxt => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_FollowupEmpPayroll1-label']"));
        public static Element EstimatedW2HelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_FollowupEmpPayroll1']"));
        public static InputSection EstimatedW2Input => new TextBoxInput(EstimatedW2TxtBox)
            .AsAQuestion(EstimatedW2QST)
            .WithHelpText(EstimatedW2Helper, EstimatedW2HelperTxt, EstimatedW2HelperX);

        //Do you do any delivery or installation of products?
        public static Element AnyDeliveryOrInstalQST => new Element(By.XPath("//label[@data-qa='_apollo_DeliverInstallProducts-label']"));
        public static Element AnyDeliveryOrInstalYes => new Element(By.XPath("//button[@data-qa='_apollo_DeliverInstallProducts-8010-yes-button']"));
        public static Element AnyDeliveryOrInstalNo => new Element(By.XPath("//button[@data-qa='_apollo_DeliverInstallProducts-8010-no-button']"));
        public static Element AnyDeliveryOrInstalHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_DeliverInstallProducts']"));
        public static Element AnyDeliveryOrInstalHelperTxt => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_DeliverInstallProducts-label']"));
        public static Element AnyDeliveryOrInstalHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_DeliverInstallProducts']"));
        public static InputSection AnyDeliveryOrInstalInput => new YesOrNoInput(AnyDeliveryOrInstalYes, AnyDeliveryOrInstalNo)
            .AsAQuestion(AnyDeliveryOrInstalQST)
            .WithHelpText(AnyDeliveryOrInstalHelper, AnyDeliveryOrInstalHelperTxt, AnyDeliveryOrInstalHelperX);

        //What percentage of your revenue comes from excavation-related work such as tree removal?
        // These are the available options to choose:
        //0%
        //1-25%
        //26-50%
        //51-75%
        //76-100%
        public static Element ExcavationRevenueQST => new Element(By.XPath("//label[@data-qa='_apollo_ExcavationSales-label']"));
        public static Element GetExcavationRevenueOption(string choiceValue) => new Element($"(//button[@data-qa='_apollo_ExcavationSales-8010-{choiceValue}-button'])");
        public static ChoiceGroup GetExcavationRevenueChoices => new ChoiceGroup(GetCremationRevenueOption);
        public static InputSection GetExcavationRevenueInput => new SingleChoiceGroupInput(GetExcavationRevenueChoices)
            .AsAQuestion(ExcavationRevenueQST)
            .IsDynamicallyRendered(BOP_ResusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Do you do any installation including computers, telecommunications, wiring, equipment, etc?
        public static Element DoYouDoInstallQST => new Element(By.XPath("//label[@data-qa='_apollo_ComputerInstall-label']"));
        public static Element DoYouDoInstallYes => new Element(By.XPath("//button[@data-qa='_apollo_ComputerInstall-8010-yes-button']"));
        public static Element DoYouDoInstallNo => new Element(By.XPath("//button[@data-qa='_apollo_ComputerInstall-8010-no-button']"));
        public static InputSection DoYouDoInstallInput => new YesOrNoInput(DoYouDoInstallYes, DoYouDoInstallNo)
            .AsAQuestion(DoYouDoInstallQST);

        //Have any owners, employees, or subcontractors had any claims, allegations, or charges of abuse, molestation, or sexual misconduct in the past 3 years?
        public static Element AnyMisconductQST => new Element(By.XPath("//label[@data-qa='_apollo_Misconduct-label']"));
        public static Element AnyMisconductYes => new Element(By.XPath("//button[@data-qa='_apollo_Misconduct-8010-yes-button']"));
        public static Element AnyMisconductNo => new Element(By.XPath("//button[@data-qa='_apollo_Misconduct-8010-no-button']"));
        public static InputSection AnyMisconductInput => new YesOrNoInput(AnyMisconductYes, AnyMisconductNo)
            .AsAQuestion(AnyMisconductQST);

        //Do you have any employees under the age of 18?
        public static Element EmployeesUnderAge18QST => new Element(By.XPath("//label[@data-qa='_apollo_MinorEmployees-label']"));
        public static Element EmployeesUnderAge18Yes => new Element(By.XPath("//button[@data-qa='_apollo_MinorEmployees-8010-yes-button']"));
        public static Element EmployeesUnderAge18No => new Element(By.XPath("//button[@data-qa='_apollo_MinorEmployees-8010-no-button']"));
        public static InputSection EmployeesUnderAge18Input => new YesOrNoInput(EmployeesUnderAge18Yes, EmployeesUnderAge18No)
            .AsAQuestion(EmployeesUnderAge18QST);

        //What is your estimated gross annual revenue?
        public static Element GrossRevenueQST => new Element(By.XPath("//label[@data-qa='_apollo_GrossRevenue-label']"));
        public static Element GrossRevenueTxtBox => new Element(By.XPath("//input[@data-qa='_apollo_GrossRevenue']"));
        public static Element GrossRevenueHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_GrossRevenue']"));
        public static Element GrossRevenueHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_GrossRevenue-label']"));
        public static Element GrossRevenueHelperTextX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_GrossRevenue']"));
        public static InputSection GrossRevenueInput => new TextBoxInput(GrossRevenueTxtBox)
            .AsAQuestion(GrossRevenueQST)
            .WithHelpText(GrossRevenueHelper, GrossRevenueHelperText, GrossRevenueHelperTextX);
    }
}
