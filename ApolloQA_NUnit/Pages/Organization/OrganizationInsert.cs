using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ApolloQA.Pages.Organization
{
    class OrganizationInsert
    {


        private IWebDriver Driver;
        Functions functions;

        public OrganizationInsert(IWebDriver driver)
        {
            Driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement inputName=> functions.FindElementWait(10, By.XPath("//input[@formcontrolname='name']"));
        public IWebElement inputDBA=> functions.FindElementWait(10, By.XPath("//input[@formcontrolname='dba']"));
        public IWebElement inputTaxID => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='taxId']"));
        public IWebElement inputBusPhone => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='businessPhone']"));
        public IWebElement inputBusEmail => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='businessEmail']"));
        public IWebElement inputBusWeb => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='businessWebsite']"));
        public IWebElement inputDesc => functions.FindElementWait(10, By.XPath("//textarea[@formcontrolname='description']"));
        public IWebElement inputYearStarted => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='yearBusinessStarted']"));
        public IWebElement inputYearOwnsership => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='yearOwnershipStarted']"));
        public IWebElement selectOrgType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='businessTypeEntityId']"));
        public IWebElement selectTaxType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='taxTypeId']"));
        public IWebElement selectIndustryType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='industryTypeId']"));
        public IWebElement selectSubType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='subIndustryTypeId']"));
        public IWebElement selectClass => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='classTypeId']"));
        public IWebElement keywordCode => functions.FindElementWait(60, By.XPath("//bh-input-autocomplete[@formcontrolname='keywordId']/input"));

        public IWebElement cancelButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement saveButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));


        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "name": return inputName;
                case "dba": return inputDBA;
                case "taxid": return inputTaxID;
                case "businessphone": return inputBusPhone ;
                case "businessemail": return inputBusEmail;
                case "businesswebsite": return inputBusWeb;
                case "description": return inputDesc;
                case "yearstarted": return inputYearStarted;
                case "yearownership": return inputYearOwnsership;
                case "orgtype": return selectOrgType;
                case "taxtype": return selectTaxType;
                case "industrytype": return selectIndustryType;
                case "subtype": return selectSubType;
                case "class": return selectClass;
                case "keyword": return keywordCode;
                default: return null;

            }
        }

        public readonly string[] driverLabels =
        {
            "Business Name",
            "Business Category",
            "DBA",
            "Organization Type",
            "Tax ID Type",
            "Tax ID No.",
            "Business Phone No.",
            "Business Email Address",
            "Business Website",
            "Description Of Operations",
            "Industry Type",
            "Sub-Industry Type",
            "Class",
            "Year Business Started",
            "Year Ownsership Started"

        };

        public readonly IDictionary<string, string[]> dropValues = new Dictionary<string, string[]>()
        {
            {"orgtype", new []{
                "Church/Religious Organization",
                "Corporation",
                "Government Entity: County/Township/Parish",
                "Government Entity: District/Precinct",
                "Government Entity: Federal",
                "Government Entity: Indian Tribe",
                "Government Entity: Municipality",
                "Government Entity: School",
                "Government Entity: State",
                "Individual",
                "Limited Liability Corporation",
                "Non-Profit",
                "Partnership",
                "Schools"
            } },
            {"taxtype", new []{"FEIN", "SSN"} },
            {"industrytype", new []{
                "Auto Services",
                "Aviation",
                "Contractor and Specialty Trade",
                "Education and Public Works",
                "Entertainment",
                "Farming",
                "For-Hire Trucking",
                "Healthcare",
                "Hospitality",
                "Manufacturing",
                "Oil and Gas",
                "Property Management",
                "Publics",
                "Retailers and Wholesalers",
                "Service - Blue Collar",
                "Service - White Collar"
            } },
            {"subtype", new []{
                "All",
                "All Other",
                "Camps",
                "Carpentry",
                "Delivery to Consumer - Mail",
                "Delivery to Consumer - Newspaper",
                "Delivery to Consumer - Not Mail",
                "Dump Truck - Sand and Gravel",
                "Education",
                "Food and Beverage",
                "Freight Forwarder",
                "Hospitals",
                "Hotels",
                "Liquid/Gas Trucker",
                "Moving Company",
                "No Amusement Devices",
                "Non-Traveling Medical Offices",
                "Other Buses",
                "Other than For-Hire Trucking",
                "Public Works",
                "Religious",
                "Restaurants",   
                "Retail",
                "Site Preparation",
                "Specialty Trade",
                "Taxicabs and Limousines",
                "Towing",
                "Traveling Amusement Devices",
                "Traveling Offices",
                "Trucker NOC",
                "Wholesalers - All Other",
                "Wholesalers - Food and Beverage"
            } },
            {"class", new []{
                "Airport Shuttle",
                "All",
                "All Other",
                "Auto Salvage",
                "Building Materials",
                "Canneries and Packing Plants",
                "Charter Bus",
                "Commercial",
                "Demolition",
                "Emergency Responders",
                "Excavating",
                "Extra-Curricular",
                "Fish and Seafood",
                "Food Trucks",
                "Frozen Food",
                "Fruit and Vegetable",
                "Garbage, Trash, Recycling Pickup",
                "Highway, Street, and Bridge Construction",
                "Junk Dealers",
                "Local Bus",
                "Meat or Poultry",
                "Paratransit",
                "Residential",
                "Sales",
                "School",
                "Service/Repair",
                "Sightseeing Bus",
                "Social Service Agency"
            } },

        };


        public void EnterInput(string locator, string value)
        {
            getElementFromFieldname(locator).SendKeys(value);
        }

        public void ClickSelect(string locator)
        {
            getElementFromFieldname(locator).Click();
        }
        public string GetRequired(string locator)
        {
            return getElementFromFieldname(locator).GetAttribute("aria-required");
        }
        public string GetValue(string locator)
        {
            return getElementFromFieldname(locator).GetAttribute("value");
        }
        public bool CheckDropDownValue(string value)
        {
            bool verify = functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Displayed;

            return verify;
        }
        public string GetSelectRequired(string locator)
        {
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + dropValues[locator][1] + "']")).Click();
            string aria = getElementFromFieldname(locator).GetAttribute("aria-required");
            return aria;
        }

        public void EnterSelect(string locator, string value)
        {
            getElementFromFieldname(locator).Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Click();
        }

        public void ClickSubmitButton()
        {
            saveButton.Click();
        }
    }
}
