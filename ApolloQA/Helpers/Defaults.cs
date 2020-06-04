using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Helpers
{
    static class Defaults
    {
        public const string
            ADMIN_USERNAME = "ApolloTestUserG301@biberk.com",
            DEFAULT_PASSWORD = "HashTagApollo#24",
            QA_HOME_URL = "https://biberk-apollo-qa.azurewebsites.net/home",
            QA_POLICY_URL = "https://biberk-apollo-qa.azurewebsites.net/policy",
            QA_ORGANIZATION_URL = "https://biberk-apollo-qa.azurewebsites.net/organization";

        //QA URLs
        public static IDictionary<string, string> QA_URLS = new Dictionary<string, string>()
        {
            {"Home", "https://biberk-apollo-qa.azurewebsites.net/home" },
            {"Policy", "https://biberk-apollo-qa.azurewebsites.net/policy" },
            {"Organization", "https://biberk-apollo-qa.azurewebsites.net/organization" },
            {"Underwriting", "https://biberk-apollo-qa.azurewebsites.net/underwriting" },
            {"Billing", "https://biberk-apollo-qa.azurewebsites.net/billing" },
            {"Administration", "https://biberk-apollo-qa.azurewebsites.net/administration" }
        };

    }
}
