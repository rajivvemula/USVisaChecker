using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R050_UserPermissionsSteps
    {
        IWebDriver driver;

        public R050_UserPermissionsSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Then(@"validate policy permissions '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void ThenValidatePolicyPermissions(string p0, string p1, string p2, string p3)
        {

        }
    }
}
