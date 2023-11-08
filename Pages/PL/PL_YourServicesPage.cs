using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Source.Driver.Input;
using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public sealed class PL_YourServicesPage : Reusable_PurchasePath
    {
        // Page Title
        public static Element YourServicesPageTitle => new Element(By.XPath("//h1[@data-qa='your-services-header']"));
        public static Element YourServicesSubTitle => new Element(By.XPath("//h6[@data-qa='your-services-subheader']"));

        // General XPath Mappers:
        public static Element YourServiceQST(string QstId) => new Element(By.XPath($"//span[@data-qa='question-{QstId}-label']"));
        public static Element YourServiceYNButtonAnswer(string QstId, string answer) => new Element(By.XPath($"//label[@data-qa=\"{QstId}{answer}\"]"));
        public static Element YourServiceTextboxAnswer(string QstId) => new Element(By.XPath($"//md-input[@data-qa='{QstId}']/div/input"));
        public static Element YourServiceCheckboxAnswer(string QstId, string answer) => new Element(By.XPath($"//md-checkbox[@data-qa=\"question-{QstId}-checkbox_{answer}\"]"));
        public static Element YourServiceHelper(string QstId) => new Element(By.XPath($"//i[@data-qa='question-{QstId}-help-icon']"));
        public static Element YourServiceHelperText(string QstId) => new Element(By.XPath($"//div[@data-qa='question-{QstId}-help-text']"));
        public static Element YourServiceHelperX(string QstId) => new Element(By.XPath($"//i[@data-qa='question-{QstId}-help-text-close-icon']"));
        public static Element YourServiceError(string QstId) => new Element(By.XPath($"//span[@data-qa='{QstId}-button-validation-error']"));

        // Soft credit check info
        public static Element SoftCreditInfoHeader => new Element(By.XPath("//h6[@data-qa='credit-check-info-header']"));

        private static Element SoftCreditFirstNameTxtBox => new Element(By.XPath("//md-input[@data-qa='credit-firstname-input']//input"));
        public static InputSection SoftCreditFirstName => new TextBoxInput(SoftCreditFirstNameTxtBox);

        private static Element SoftCreditLastNameTxtBox => new Element(By.XPath("//md-input[@data-qa='credit-lastname-input']//input"));
        public static InputSection SoftCreditLastName => new TextBoxInput(SoftCreditLastNameTxtBox);

        private static Element SoftCreditAddressTxtBox => new Element(By.XPath("//md-input[@data-qa='creditcheck-address-input']//input"));
        public static InputSection SoftCreditAddress => new TextBoxInput(SoftCreditAddressTxtBox);

        private static Element SoftCreditAptNumTxtBox => new Element(By.XPath("//md-input[@data-qa='aptn-num-input']//input"));
        public static InputSection SoftCreditAptNum => new TextBoxInput(SoftCreditAptNumTxtBox);

        private static Element SoftCreditZipCodeTextBox => new Element(By.XPath("//md-input[@data-qa='creditzip-input']//input"));
        public static InputSection SoftCreditZipCode => new TextBoxInput(SoftCreditZipCodeTextBox);

        private static Element SoftCreditCityDropdown => new Element(By.XPath("//select[@data-qa='credit-city-input']//preceding-sibling::input"));
        public static InputSection SoftCreditCity => new PLDropdownInput(SoftCreditCityDropdown);

        private static Element SoftCreditStateTxtBox => new Element(By.XPath("//md-input[@data-qa='creditstate-input']//input"));
        public static InputSection SoftCreditState => new TextBoxInput(SoftCreditStateTxtBox).TakesAStateAsInput(StateInputStrategy.Abbreviation);

        // Continue
        public static Element YourServiceCTABtn => new Element(By.XPath("//button[@data-qa='services-continue-button']"));
    }
}
