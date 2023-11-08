using BiBerkLOB.Source.Driver.Input;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Claims
{
    [Binding]
    public sealed class CA_ClaimsPage : ClaimsPageBase
    {
        //Report a Commercial Auto Claim
        public static Element CA_ClaimTitle => new Element(By.XPath("//h1[@data-qa='report-a-commercial-auto-claim-header']"));
        public static Element CA_ClaimParagraph => new Element(By.XPath("//p[@data-qa='report-claim-info-description']"));

        //Drivers Name
        public static Element DriverFirstNameQST => new Element(By.XPath("//span[@data-qa='driver-first-name-label']"));
        public static Element DriverFirstNameTxtbox => new Element(By.XPath("//md-input[@data-qa='driver-first-name-input']//input"));
        public static Element DriverLastNameQST => new Element(By.XPath("//span[@data-qa='driver-last-name-label']"));
        public static Element DriverLastNameTxtbox => new Element(By.XPath("//md-input[@data-qa='driver-last-name-input']//input"));

        //Drivers Address
        public static Element DriverAddressQST => new Element(By.XPath("//span[@data-qa='driver-address-label']"));
        public static Element DriverAddressTxtbox => new Element(By.XPath("//md-input[@data-qa='driver-address-input-1']//input"));
        public static Element DriverAddressApartmentTxtbox => new Element(By.XPath("//md-input[@data-qa='driver-address-input-2']//input"));
        public static Element DriverAddressZipCodeTxtbox => new Element(By.XPath("//md-input[@data-qa='driver-zip-code-input']//input"));
        public static Element DriverAddressCityDD => new Element(By.XPath("//select[@data-qa='driver-city']/..//input"));
        public static Element DriverCityModel(string city) => new Element(By.XPath($"//option[@model.bind='city' and text()='{city}']/ancestor::fieldset"));
        public static Element DriverCityOption(string city) => new Element(By.XPath($"//select[@data-qa='driver-city']/..//li/span[text()='{city}']"));
        public static Element DriverAddressStateTxtbox => new Element(By.XPath("//md-input[@data-qa='driver-state']/..//input"));

        //Drivers Phone Number
        public static Element DriverPhoneQST => new Element(By.XPath("//span[@data-qa='driver-phone-number-label']"));
        public static Element DriverPhoneTxtbox => new Element(By.XPath("//md-input[@data-qa='driver-phone-input']//input"));

        //Vehicle Year Make Model
        public static Element YearMakeModelQST => new Element(By.XPath("//span[@data-qa='year-make-model-label']"));
        public static Element VehicleYearTxtbox => new Element(By.XPath("//md-input[@data-qa='car-year-input']//input"));
        public static Element VehicleYearError => new Element(By.XPath("//span[@data-qa='car-year-input-validation-error']"));
        public static Element VehicleMakeDD => new Element(By.XPath("//select[@data-qa='car-make-input']/..//input"));
        public static Element VehicleMake(string make) => new Element(By.XPath($"//option[@model.bind='null' and text()='{make}']/ancestor::fieldset"));
        public static Element VehicleMakeOption(string make) => new Element(By.XPath($"//select[@data-qa='car-make-input']/..//li/span[text()='{make}']"));
        public static Element VehicleMakeError => new Element(By.XPath("//span[@data-qa='car-make-validation-error']"));
        public static Element VehicleModelDD => new Element(By.XPath("//select[@data-qa='car-model-input']/..//input"));

        //Vehicle VIN
        public static Element VehicleVIN_QST => new Element(By.XPath("//span[@data-qa='vin-number-label']"));
        public static Element VehicleVIN_Txtbox => new Element(By.XPath("//md-input[@data-qa='vin-number-input']//input"));

        //Description of Damage
        public static Element ShortDescrTextBelow => new Element(By.XPath("//p[@data-qa='claims-description-text']"));
        public static Element ShortDescrLink => new Element(By.XPath("//p[@data-qa='claims-description-text']//a"));
        public static Element ShortDescrError => new Element(By.XPath("//span[@data-qa='loss-summary-input-validation-error']"));

        //CA Submit Claim Button
        public static Element CASubmitClaimsButton => new Element(By.XPath("//button[@data-qa='ca-submit-claim-button']"));

        public static List<Element> CA_ClaimsPageElements => new List<Element>
        {
            CA_ClaimTitle,
            CA_ClaimParagraph,
            PolicyNumberHeader,
            PolicyNumberTextbox,
            BusinessNameQST,
            BusinessNameTextbox,
            FirstNameTextbox,
            LastNameTextbox,
            PhoneHeader,
            PhoneTextbox,
            HowToConnectQST,
            HowToConnectTextbox,
            DateOfLoss,
            DateOfLossDateField,
            DriverFirstNameQST,
            DriverFirstNameTxtbox,
            DriverLastNameQST,
            DriverLastNameTxtbox,
            DriverAddressQST,
            DriverAddressTxtbox,
            DriverAddressApartmentTxtbox,
            DriverAddressZipCodeTxtbox,
            DriverAddressCityDD,
            DriverAddressStateTxtbox,
            DriverPhoneQST,
            DriverPhoneTxtbox,
            LocationOfLoss,
            LocationOfLossTxtbox,
            YearMakeModelQST,
            VehicleYearTxtbox,
            VehicleMakeDD,
            VehicleModelDD,
            VehicleVIN_QST,
            VehicleVIN_Txtbox,
            ShortDescrip,
            ShortDescripTextbox,
            ShortDescrTextBelow,
            ShortDescrLink,
            QuestionsHeader,
            PhoneIcon,
            PhoneNumber,
            OfficeHours,
            FaxNumber,
            EmailIcon,
            ClaimsEmail,
            ClaimsContactAddress,
        };

        public static List<Element> CA_ClaimsPageErrorMessages = new()
        {
            BusinessNameError,
            FirstNameError,
            LastNameError,
            PhoneError,
            HowToConnectError,
            DateofLossError,
            LocationOfLossError,
            VehicleYearError,
            VehicleMakeError,
            ShortDescrError
        };
    }
}