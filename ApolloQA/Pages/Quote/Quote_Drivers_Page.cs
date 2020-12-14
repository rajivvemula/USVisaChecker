using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages
{
    class Quote_Drivers_Page
    {
        public static Element ExpandAllButton => new Element("//button//*[contains(text(), ' Expand All ')]");
        public static Element ExpandedInfo => new Element("//*[@style='padding-left: 35px; flex-direction: row; box-sizing: border-box; display: flex;']");
        public static Element CollapseAllButton => new Element("//button//*[contains(text(), ' Collapse All ')]");
        public static Element DriverRecord => new Element("(//*[@class='datatable-row-center datatable-row-group ng-star-inserted'])");
        public static Element NewDriverButton => new Element("//button//*[contains(text(), ' Driver ')]");

        public static Element ExistingDriverDropdown => new Element("//mat-select[@name='resourceSelect']");
        public static Element ExistingDriver => new Element("//div[@class='address-info']");
        public static Element FirstNameInput => new Element("//input[@name='firstName']");
        public static Element LastName => new Element("//input[@name='lastName']");
        public static Element DateOfBirth => new Element("//input[@name='dateOfBirth']");
        public static Element DriverLicenseDropdown => new Element("//mat-select[@name='stateProvinceId']");
        public static Element DriverLicenseNumberInput => new Element("//input[@name='licenseNo']");
        public static Element DLExpirationDate => new Element("//input[@name='licenseExpirationDate']");
        public static Element DLStateExceptionsNo => new Element("(//mat-radio-button //*[@class='mat-radio-label-content' and contains(text(), 'No')])[1]");
        public static Element CdlDropdown => new Element("//mat-select[@name='cdl']");
        public static Element ActiveLicenseStatusButton => new Element("//mat-radio-button //*[@class='mat-radio-label-content' and contains(text(), ' Active ')]");
        public static Element InspectionCountInput => new Element("//input[@type='number']");
        public static Element ExcludeDriverNo => new Element($"(//mat-radio-button //*[@class='mat-radio-label-content' and contains(text(), 'No')])");
        public static Element SaveDriverButton => new Element("//button[*[contains(text(), 'Save Driver')]]");
        public static Element ToolTipError => new Element("(//mat-error[contains(text(), 'Required')])[1]");
    }
}
