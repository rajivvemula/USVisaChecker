using System;
using HitachiQA.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BiBerkLOB.StepDefinition.General
{
    public class General_SiteWide
    {
        public static void AssertEnvironmentURL()
        {
            String Host = Environment.GetEnvironmentVariable("HOST");
            var URL = UserActions.GetCurrentURL();
            try
            {
                URL.Contains(Host);
            }
            catch
            {
                throw new Exception("A different environment has been detected.");
            }
        }

        public static void AssertUrlSegmentWithCorrectHost(string segment, int waitTimeSeconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS)
        {
            AssertEnvironmentURL();

            try
            {
                new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(waitTimeSeconds)).Until(ExpectedConditions.UrlContains(segment));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Url segment '{segment}' was not found in the browser URL of '{UserActions.GetCurrentURL()}'");
            }
        }
    }
}