using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Helpers
{
    static class Defaults
    {
        public const string
            ADMIN_USERNAME = "ApolloTestUserG311@biberk.com",
            DEFAULT_PASSWORD = "ApolloTest12",
            DEFAULT_PASSWORD2 = "ApolloTest12",
            SQLCONNECTIONSTRING = "Server=xbibaoazadb1qa2.database.windows.net;Database=bibapollodb;User Id=bbadmin;Password=Pqa2l2kr2ltjnaj4y!;";
        
        //QA URLs
        public static IDictionary<string, string> QA_URLS = new Dictionary<string, string>()
        {
            {"Home", "https://biberk-apollo-qa2.azurewebsites.net/home" },
            {"Policy", "https://biberk-apollo-qa2.azurewebsites.net/policy" },
            {"Organization", "https://biberk-apollo-qa2.azurewebsites.net/organization" },
            {"Organization Insert", "https://biberk-apollo-qa2.azurewebsites.net/organization/insert" },
            {"Underwriting", "https://biberk-apollo-qa2.azurewebsites.net/underwriting/dashboard" },
            {"Billing", "https://biberk-apollo-qa2.azurewebsites.net/billing-defaults" },
            {"Administration", "https://biberk-apollo-qa2.azurewebsites.net/administration" },
            {"Application", "https://biberk-apollo-qa2.azurewebsites.net/application" },
            {"Collections", "https://biberk-apollo-qa2.azurewebsites.net/collections/dashboard" },
            {"Claims", "https://biberk-apollo-qa2.azurewebsites.net/claims/fnol-dashboard" },
            {"Quote", "https://biberk-apollo-qa2.azurewebsites.net/quote/" },
            {"API",  "https://bibaoqa2-fd.azurefd.net/api/"},
        };

        public static IDictionary<string, List<string>> TabSets = new Dictionary<string, List<string>>()
        {
            { "waffleTabs" , new List<string>{ "Underwriting", "Billing", "Administration", "Collections Center", "Claims" } },
            { "organizationTabs" , new List<string>{ "Business Information", "Addresses", "Drivers", "Vehicles", "Trailers" }},
            { "applicationTabs" , new List<string>{  "Application Information", "Business Information", "Contacts", "UW Questions", 
                                "Additional Questions", "Policy Coverages", "Drivers", "Vehicles", "Additional Interests",
                                "Summary"}},
            { "policyTabs" , new List<string>{   "Business Information", "Contacts", "UW Questions",
                                "Policy Coverages", "Drivers", "Vehicles", "Trailers",
                                "Additional Questions", "Modifiers", "Additional Interests",
                                "Summary", "Rate Calculation Test", "Coverages List Test", "Documents", "Activities",
                                "Loss History","Policy History" }},
        };

        public static IDictionary<string, string> PageTitles = new Dictionary<string, string>()
        {
            {"orgInsert", "Insert Organization" },
            {"fnolInsert", "Insert First Notice of Loss" },
            {"appInsert", "Application" },
            {"orgVehicle", "Vehicles" },
            {"orgDrivers", "Apollo" }
        };

        public static IDictionary<string, string> Toasts = new Dictionary<string, string>()
        {
            {"OrgSave", "was saved." },
            {"Application", "https://biberk-apollo-qa2.azurewebsites.net/quote/" }
        };

        public static IDictionary<string, string> URLContains = new Dictionary<string, string>()
        {
            {"Application Information", "section/9001" },
            {"Business Information", "section/9000" },
            {"Contacts", "section/9002" },
            {"UW Questions", "section/9005" },          
            {"Additional Questions", "section/9020"},
            {"Policy Coverages", "section/9035" },
            {"Drivers", "section/9015"},               
            {"Vehicles", "section/9010"},              
            {"Additional Interests", "section/9030"},
            {"Summary", "section/9025"},
            {"Coverages List Test", "coverages"},   
            {"Rating Worksheet", "rating-worksheet"},      
            {"Documents", "document"},             
            {"Activities", "activities"},            
            {"Loss History", ""},          
            {"Policy History", "history"},
            {"Home", "home"}
        };



        public static readonly string[] adminRoles = {
            "Apollo Accounts Receivable",
            "Apollo Actuarial",
            "Apollo Admin",
            "Apollo Document Management",
            "Apollo Impersonator",
            "Apollo Policy Services",
            "Apollo Underwriter",
            "Apollo Users"
        };



    }
}
