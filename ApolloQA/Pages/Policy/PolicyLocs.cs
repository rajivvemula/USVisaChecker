using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyLocs
    {

        //PolicyMain

        public static string
            locPolicySummary = "//div[@class='mat-list-item-content' and normalize-space(text())='Policy Summary']",
            locPolicyLocation = "//div[@class='mat-list-item-content' and normalize-space(text())='Locations']",
            locPolicyContacts = "//div[@class='mat-list-item-content' and normalize-space(text())='Contacts']",
            locPolicyVehicles = "//div[@class='mat-list-item-content' and normalize-space(text())='Vehicles']",
            locPolicyDrivers = "//div[@class='mat-list-item-content' and normalize-space(text())='Drivers']",
            locPolicyCoverages = "//div[@class='mat-list-item-content' and normalize-space(text())='Coverages']",
            locPolicyRates = "//div[@class='mat-list-item-content' and normalize-space(text())='Rate Calculation']",
            locPolicyDocuments = "//div[@class='mat-list-item-content' and normalize-space(text())='Documents']",
            locPolicyHistory = "//div[@class='mat-list-item-content' and normalize-space(text())='Policy History']";

        //PolicyCreation
        public static string
            locInputOrg = "mat-input-6",
            locInputAgency = "mat-input-7",
            locInputLOB = "mat-select-1",
            locInputBusType = "mat-select-2",
            locInputYears = "mat-input-4",
            locInputTaxIDType = "mat-select-3",
            locInputTaxID = "mat-input-5",
            locSubmitButton = "//button[@aria-label='Submit']";

    }
}
