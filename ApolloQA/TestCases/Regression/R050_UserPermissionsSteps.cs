using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R050_UserPermissionsSteps
    {
        [Then(@"validate policy permissions '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void ThenValidatePolicyPermissions(string p0, string p1, string p2, string p3)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
