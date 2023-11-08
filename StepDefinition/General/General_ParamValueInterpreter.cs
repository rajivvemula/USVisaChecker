using ApolloQA.Source.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BiBerkLOB.StepDefinition.General
{
    public sealed class General_ParamValueInterpreter
    {
        private static Random Rnd = new Random();

        // Defines how param values are derived:
        static Dictionary<string, dynamic> ParamValues = new Dictionary<string, dynamic>
        {
            {"blacklistedphonenumber", GetBlackListedPhoneNumber() },
            {"blacklistedemail", GetBlackListedEmailAddress() }
        };

        public string ExtractParamValue(string rawParam)
        {
            var param = "";
            var pattern = @"([^\[][A-z (),./&]*[^\]])";
            Regex rgx = new Regex(pattern);
            Match match = rgx.Match(rawParam);

            if (match.Success)
            {
                foreach (var entry in ParamValues)
                {
                    if (entry.Key == match.ToString().ToLower()) param = entry.Value.ToString();
                }
            }

            return param;
        }

        // BlackListed phone number and email methods:
        private static Dictionary<string, dynamic> GetRandomBlackListedEntry()
        {
            var entries = SQL.ConnectDB(@"select id, phone, email from BSP_HighRisk_Clients where riskcode = 'D'");

            return entries[(Rnd.Next(1, entries.Count - 1))];
        }

        static string GetBlackListedEmailAddress() 
        {
            return GetRandomBlackListedEntry()["email"]; 
        }

        static string GetBlackListedPhoneNumber()
        {
            var unformattedPhoneNum = GetRandomBlackListedEntry()["phone"];

            var pattern = @"(\d)+";
            Regex rgx = new Regex(pattern);
            Match match = rgx.Match(unformattedPhoneNum);
            var matches = new List<string>();

            while (match.Success)
            {
                matches.Add(match.ToString());
                match = match.NextMatch();
            }

            return matches[(Rnd.Next(0, matches.Count - 1))];
        }
    }
}
