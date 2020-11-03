using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class BusinessInformation
    {
        public static Element BusinessNameField => new Element("//input[@name='orgName']");
        //public static Element businessCategoryDropdown => new Element("//mat-select[@role='combobox' and @formcontrolname='organizationTypeId']");
        public static Element businessDBAField => new Element("//input[@name='DBA']");
        public static Element organizationTypeDropdown => new Element("//mat-select[@role='combobox' and @formcontrolname='businessTypeEntityId']");
        public static Element taxIdTypeDropdown => new Element("//*[@id='mat-select-value-7']");
        public static Element taxIdNumberField => new Element("//input[@name='taxId']");
        public static Element businessphoneNumberField => new Element("//input[@name='businessPhone']");
        public static Element businessEmailAddressField => new Element("//input[@name='orgEmailAddress']");
        public static Element businessWebsiteField => new Element("//input[@name='orgWebsite']");
        public static Element descriptionOfOperationsField => new Element("//*[@name='orgDescription']");
        public static Element businessKeywordField => new Element("//input[@type='text' and @id='mat-input-11']");
        public static Element KeywordOption => new Element("//mat-option[@role='option' and @class='mat-option mat-focus-indicator provided ng-star-inserted mat-active']");
        public static Element businessClassTaxonomyField => new Element("//input[@formcontrolname='industryClassTaxonomyClassName']");
        public static Element businessYearStartedField => new Element("//input[@name='orgYrBussStarted']");
        public static Element businessYearOwnershipField => new Element("//input[@name='yearOwnershipStarted']");
        public static Element businessSaveButton => new Element("//button[@aria-label='Save']");
        public static Element businessCancelButton => new Element("//button[@aria-label='Cancel']");
        public static Element toastrMessage => new Element("");

    }
}
