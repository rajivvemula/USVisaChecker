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
            {"Underwriting", "https://biberk-apollo-qa2.azurewebsites.net/underwriting" },
            {"Billing", "https://biberk-apollo-qa2.azurewebsites.net/billing" },
            {"Administration", "https://biberk-apollo-qa2.azurewebsites.net/administration" },
            {"Application", "https://biberk-apollo-qa2.azurewebsites.net/application" }
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
