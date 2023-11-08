using BiBerkLOB.Source.Driver.Input;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.WC
{
    internal class WC_YourServicesPage
    {
        //Your Services
        public static Element YourServices => new Element(By.XPath("//h2[@data-qa='wc_your_services_header']"));

        //General Mapping
        public static Element ServiceQST(string QstID) => new Element(By.XPath($"//label[@data-qa='question_{QstID}']"));
        public static Element ServicePercentAnswer(string QstId) => new Element(By.XPath($"//bb-percent[@data-qa='percent_{QstId}']//input"));
        public static Element ServiceDropDown(string QstId) => new Element(By.XPath($"//bb-select[@data-qa='select_{QstId}']//select"));
        public static Element ServiceDropDownAnswer(string QstID, string answer) => new Element(By.XPath($"//bb-select[@data-qa='select_{QstID}']//select/{answer}"));
        public static Element ServiceYNAnswer(string responseID, string answer) => new Element(By.XPath($"//bb-options[@data-qa='response_{responseID}']//button[text()='{answer}']"));
        public static Element ServiceSelectAnswer(string responseID, string answer) => new Element(By.XPath($"//bb-select[@data-qa='response_{responseID}']//option[text()='{answer}']"));
        public static Element ServiceNumberTextboxAnswer(string inputID) => new Element(By.XPath($"//bb-number[@data-qa='number_input_{inputID}']//input"));
        public static Element ServiceTextboxAnswer(string inputID) => new Element(By.XPath($"//label[@data-qa='question_{inputID}']/..//input"));
        public static InputSection FEINTextBox => new TaxIDInput(FEINQST, FEINTxtBox);
        public static InputSection SSNTextBox => new TaxIDInput(SSNQST, SSNTxtBox);
        public static Element FramingOrConstruction => new Element(By.XPath("//label[@data-qa='question_119']"));
        public static Element WhatPercentageInvolvesBankruptcy => new Element(By.XPath("//bb-percent[@data-qa='percent_224']//input"));
        //Construction
        public static Element FramingOrConstructionAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='response_119']//button[text()='{answer}']"));
        //Mechanized or Automated
        public static Element ReviewMVRForEmployeesAnswer => new Element(By.XPath($"//bb-select[@data-qa='select_265']//select"));
        //Transportation
        public static Element PrimaryBusinessVehicle => new Element(By.XPath($"//bb-select[@data-qa='select_284']//select"));
        public static Element AmazonDeliveryServiceParticipationQST => new Element(By.XPath($"//label[@data-qa='question_693']"));
        public static Element AmazonDeliveryYears => new Element(By.XPath($"//label[@data-qa='question_808']"));
        public static Element AmazonDeliveryInput => new Element(By.XPath($"//bb-number[@data-qa='number_input_808']//input"));
        public static Element AmazonDeliveryServiceParticipationAnswer(string answer) => new Element(By.XPath($"//bb-options[@data-qa='response_693']//button[text()=\"{answer}\"]"));
        public static YesOrNoGroup AmazonDeliveryServiceParticipationGroup => new YesOrNoGroup(AmazonDeliveryServiceParticipationAnswer("yes"), AmazonDeliveryServiceParticipationAnswer("no"));
        public static InputSection MaintenanceRepairOrServiceVehiclesInput => new YesOrNoInput(AmazonDeliveryServiceParticipationGroup)
            .AsAQuestion(AmazonDeliveryServiceParticipationQST);

        // Enter the value for experience modification factor:
        public static Element EnterXModFactorQST => new Element(By.XPath("//label[@data-qa='XMOD_value_label']"));
        public static Element EnterXModFactorAnswer => new Element(By.XPath("//bb-number[@data-qa='manual_XMOD_input_number']//input"));
        public static InputSection EnterXModFactorInput => new TextBoxInput(EnterXModFactorAnswer)
            .AsAQuestion(EnterXModFactorQST);

        //Federal Employer Identification Number (FEIN)
        public static Element FEINQST => new Element(By.XPath("//label[@data-qa='Federal Employer Identification Number (FEIN)_label']"));
        public static Element FEINTxtBox => new Element(By.XPath("//bb-fein[@data-qa='bb_fein']//input"));

        //Social Security Number (SSN)
        public static Element SSNQST => new Element(By.XPath("//label[@data-qa='Social Security Number (SSN)_label']"));
        public static Element SSNTxtBox => new Element(By.XPath("//bb-ssn[@data-qa='bb_ssn']//input"));
        public static Element ContinueButton => new Element(By.XPath("//button[@data-qa='wc_your_services_continue_button']"));
    }
}