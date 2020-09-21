using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Helpers
{
    static class Defaults
    {
        public const string
            ADMIN_USERNAME = "ApolloTestUserG301@biberk.com",
            DEFAULT_PASSWORD = "HashTagApollo#24";
        
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
            {"Quote", "https://biberk-apollo-qa2.azurewebsites.net/quote/" }
        };

        public static IDictionary<string, List<string>> TabSets = new Dictionary<string, List<string>>()
        {
            { "waffleTabs" , new List<string>{ "Underwriting", "Billing", "Administration", "Collections Center", "Claims" } },
            { "organizationTabs" , new List<string>{ "Business Information", "Addresses", "Drivers", "Vehicles", "Trailers" }},
            { "applicationTabs" , new List<string>{   "Application Information","Business Information", "Contacts", "UW Questions",
                                "Policy Coverages", "Drivers", "Vehicles", "Additional Questions",
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
            {"appInsert", "Application" }
        };

        public static IDictionary<string, string> Toasts = new Dictionary<string, string>()
        {
            {"OrgSave", "was saved." },
            {"Application", "https://biberk-apollo-qa2.azurewebsites.net/quote/" }
        };

        public static IDictionary<string, string> URLContains = new Dictionary<string, string>()
        {
            {"Business Information", "section/9000" },
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

        public static readonly string[] insertPolicyLabels =
        {
            "Insured organization",
            "Agency",
            "Line of Business",
            "Effective date",
            "Expiration date",
            "Issue date",
            "Business Type",
            "Years in business",
            "Tax ID Type",
            "Tax ID"
        };

    }
}
