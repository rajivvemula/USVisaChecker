using System;
using System.Collections.Generic;
using System.Linq;
using BiBerkLOB.Pages;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HitachiQA.Helpers;

/*
 * This class should contain functions that can be used in different parts of automation regardless of where
 * Ex: validating a list of elements
 */

public static class AutomationHelper
{
    private const int DEFAULT_AUTOMATION_WAIT_SECONDS = UserActions.DEFAULT_WAIT_SECONDS;

    /// Asserts that every element in a list is visible
    public static void ValidateElements(IEnumerable<Element> elements, int waitSeconds = DEFAULT_AUTOMATION_WAIT_SECONDS)
    {
        var failedAsserts = new List<By>();
        foreach (var element in elements)
        {
            try
            {
                element.AssertElementIsVisible(waitSeconds);
            }
            catch
            {
                failedAsserts.Add(element.locator);
            }
        }

        if (failedAsserts.Count > 0)
        {
            var locators = failedAsserts.Select(by => by.ToString());
            NUnit.Framework.Assert.Fail("The following elements were not visible: " + string.Join(", ", locators));
        }
    }

    public static void ValidateElementsNotPresent(IEnumerable<Element> elements, int waitSeconds = DEFAULT_AUTOMATION_WAIT_SECONDS)
    {
        var failedAsserts = new List<By>();
        foreach (var element in elements)
        {
            try
            {
                element.AssertElementNotPresent(waitSeconds);
            }
            catch
            {
                failedAsserts.Add(element.locator);
            }
        }

        if (failedAsserts.Count > 0)
        {
            var locators = failedAsserts.Select(by => by.ToString());
            NUnit.Framework.Assert.Fail("The following elements were not visible: " + string.Join(", ", locators));
        }
    }

    //Wait for Apollo Grid Loading
    public static void WaitForGridLoading(int waitSeconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS)
    {
        var loadingElement = new Element(By.XPath("//div[@role='progressbar']"));
        loadingElement.WaitForElementToAppearThenDisappear(waitSeconds);
    }

    // Wait for the biberkloading Icon to disapear
    public static void LegacyWaitForLoading(int waitSeconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS)
    {
        var loadingElement = new Element(By.XPath("//img[@alt='Loading']"));
        loadingElement.WaitForElementToAppearThenDisappear(waitSeconds);
    }

    public static void WaitForLoading(int waitSeconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS)
    {
        var loadingElement = new Element(By.XPath("//div[@data-qa='bb-loading-spinner']"));
        loadingElement.WaitForElementToAppearThenDisappear(waitSeconds);
    }

    public static void WaitForWCLoading(int waitSeconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS)
    {
        var loadingElement = new Element(By.XPath("//div[@class='loader']"));
        loadingElement.WaitForElementToAppearThenDisappear(waitSeconds);
    }

    public static string GetElementXPath(Element element)
    {
        return Functions.GetElementXPath(element.locator);
    }

    public static void RetryUntilSucceeded(Action action, int waitSeconds = DEFAULT_AUTOMATION_WAIT_SECONDS)
    {
        var wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(waitSeconds));
        wait.Until(_ =>
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                Log.Warn($"Attempt at action failed: {ex.Message}");
                return false;
            }
        });
    }

    public static void RetryUntilSucceeded(Func<bool> predicate, int waitSeconds = DEFAULT_AUTOMATION_WAIT_SECONDS)
    {
        var wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(waitSeconds));
        wait.Until(_ =>
        {
            try
            {
                return predicate();
            }
            catch (Exception ex)
            {
                Log.Warn($"Attempt at action failed: {ex.Message}");
                return false;
            }
        });
    }

    public static void RetryUntilSucceeded(AutomationRetryInstructions automationToRetry, int waitSeconds = DEFAULT_AUTOMATION_WAIT_SECONDS)
    {
        var wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(waitSeconds));
        var actionName = automationToRetry.ToString();
        try
        {
            int i = 0;
            wait.Until(_ =>
            {
                Log.Debug($"Attempt {++i}...");
                try
                {
                    return automationToRetry.GetResultFromAutomation();
                }
                catch (Exception ex)
                {
                    Log.Warn($"Attempt at action '{actionName}' failed: {ex.Message}");
                    return false;
                }
            });
            Log.Debug($"Attempt succed on attempt {i}");
        }
        catch
        {
            Log.Debug("Attempt failed after allotted time");
            throw new AggregateException($"'{actionName}' timed out after {waitSeconds} seconds");
        }
    }

    public static decimal ParsePriceFromText(Element price)
    {
        string priceText = price.GetInnerText();
        return decimal.Parse(price.GetInnerText(), System.Globalization.NumberStyles.AllowCurrencySymbol | System.Globalization.NumberStyles.Number);
    }
}