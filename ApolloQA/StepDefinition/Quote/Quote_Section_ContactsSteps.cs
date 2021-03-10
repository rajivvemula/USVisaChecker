using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_Section_ContactsSteps
    {
        [When(@"user adds a new Contact with the following relevant values")]
        public void WhenUserAddsANewContactWithTheFollowingRelevantValues(Table table)
        {
           
            foreach (var column in table.Rows[0])
            {
                var fieldName = column.Key;
                if (!string.IsNullOrWhiteSpace(column.Value))
                {
                    var fieldType = fieldTypes[fieldName];

                    if (fieldType.ToLower() == "input")
                    {
                        Pages.Shared.GetField(fieldName, fieldType).setText(column.Value);
                    }
                    else if(fieldType.ToLower() == "checkbox")
                    {
                        Pages.Shared.GetField(column.Value, fieldType).Click();

                    }


                }
            }
            
        }


        public static Dictionary<string, string> fieldTypes = new Dictionary<string, string>()
        {
            {"First Name",      "input" },
            {"Last Name",       "input" },
            {"Middle Name",     "input" },
            {"Suffix",          "input" },
            {"Title",           "input" },
            {"Primary Phone",   "input" },
            {"Secondary Phone", "input" },
            {"Email",           "input" },
            {"Roles",           "checkbox" },
            {"Notes",           "input" },
         
        };

    }
}
