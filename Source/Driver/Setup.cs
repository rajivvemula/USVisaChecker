using System;
using System.Collections.Generic;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using HitachiQA.Helpers;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.Source.Helpers.RetryPolicy;

namespace HitachiQA.Driver
{
    [Binding]
    public class Setup
    {
        /// <summary>
        /// Stores a reference to the web driver used in each scenario's thread of execution.
        /// SpecFlow executes each parallel scenario run in a single thread.
        /// </summary>
        private static readonly ThreadLocal<IWebDriver> DriverLocal = new ();
        private static IObjectContainer _objectContainer;

        public static IWebDriver driver => DriverLocal.Value;
        public static string SourceDir = Environment.GetEnvironmentVariable("SourceDir") ?? "./";

        private readonly RetryTestRunnerWrapper _retryWrapper;
        private readonly ContextObjectResetter _resetter;
        private readonly QuoteIDRetriever _quoteID;

        public Setup(IObjectContainer objectContainer, RetryTestRunnerWrapper retry, ContextObjectResetter resetter, QuoteIDRetriever quoteID)
        {
            _objectContainer = objectContainer;
            _retryWrapper = retry;
            _resetter = resetter;
            _quoteID = quoteID;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            if (File.Exists("local.env.json"))
            {
                InvokeEnvironmentVariables("local.env.json");
            }
            InvokeEnvironmentVariables(Environment.GetEnvironmentVariable("ENVIRONMENT_FILE") ?? "default.env.json");
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioLog log, ScreenShotTaker screenShotTaker, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            Log.ThreadLocalLog.Value = log;
            ScreenShot.ScreenShotTakerLocal.Value = screenShotTaker;

            SetLogHeader(scenarioContext, featureContext);

            var hasNoSeleniumTag = scenarioContext.ScenarioInfo.Tags.Contains("NoSelenium");
            if (!hasNoSeleniumTag)
            {
                RegisterNewDriver();
            }

            RegisterRetryPolicy(hasNoSeleniumTag);
        }
        
        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            string fileNameBase = $"{featureContext.FeatureInfo.Title}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            if (scenarioContext.TestError != null)
            {
                TakeErrorScreenShot(fileNameBase);
                Log.Info(_quoteID.GetLOBQuoteID());
            }

            LogReasonIfRetryTriggered();
            driver?.Quit();
            Log.Dump(fileNameBase);
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            var step = scenarioContext.StepContext.StepInfo.StepInstance;
            Log.Info($"{step.Keyword}{step.Text}\n{step.TableArgument}");
        }

        [AfterStep(Order = 1)]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.CurrentScenarioBlock.ToString();
            var step = scenarioContext.StepContext.StepInfo.StepInstance;

            Log.Info($"Step status: {scenarioContext.ScenarioExecutionStatus.ToString()}");
            Log.Separator();

            var stepArgs = new StepRetryArgs()
            {
                Text = step.Text,
                MultilineTextArgument = step.MultilineTextArgument,
                TableArgument = step.TableArgument,
                Keyword = step.Keyword
            };

            _retryWrapper.AddStepAndArgumentsForPotentialRetry(stepType, stepArgs);
            _retryWrapper.CheckScenarioStatusAndRetryIfNecessary();
        }

        private void RegisterRetryPolicy(bool hasNoSeleniumTag)
        {
            _retryWrapper.ResetRetryTrackers();
            _retryWrapper.SetTestResetForRetry(() => TestReset(hasNoSeleniumTag));
        }

        private void TestReset(bool hasNoSeleniumTag)
        {
            if (!hasNoSeleniumTag)
            {
                RegisterNewDriver();
            }
            _resetter.ResetContextObjects();
        }

        private void TakeErrorScreenShot(string fileNameBase)
        {
            fileNameBase = Functions.ReplaceDisallowedFilenameCharacters(fileNameBase);
            try
            {
                ScreenShot.Error.Take(fileNameBase);
            }
            catch (Exception e)
            {
                Log.Critical(e.Message);
            }
        }

        private void LogReasonIfRetryTriggered()
        {
            if (_retryWrapper.ExceptionThatTriggeredRetry != null)
            {
                Log.Separator();
                var exceptionTrigger = _retryWrapper.ExceptionThatTriggeredRetry;
                Log.Warn("Test triggered a retry, first run threw following exception:");
                Log.Warn($"{exceptionTrigger.GetType().FullName} - {exceptionTrigger.Message}");
            }
        }

        private static void SetLogHeader(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            Log.Info($"Folder {featureContext.FeatureInfo.FolderPath}");
            Log.Info($"Feature: {featureContext.FeatureInfo.Title}");
            Log.Info($"Description: {featureContext.FeatureInfo.Description}");
            Log.Info($"Scenario: {scenarioContext.ScenarioInfo.Title}");
            Log.Separator();
        }

        private static void RegisterNewDriver()
        {
            driver?.Quit();

            string browser = Environment.GetEnvironmentVariable("BROWSER", EnvironmentVariableTarget.Process);
            switch (browser?.ToLower())
            {
                case "chrome":
                    DriverLocal.Value = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    OverrideTimezone();
                    break;
                case "chromeheadless":
                    ChromeOptions opts = new ChromeOptions();
                    opts.AddArgument("--headless");
                    opts.AddArgument("window-size=1920,1080");
                    DriverLocal.Value = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), opts);
                    OverrideTimezone();
                    break;
                case "firefox":
                    DriverLocal.Value = new FirefoxDriver();
                    break;
                default:
                    throw new NotImplementedException($"Environment variable BROWSER value={browser} is not supported");
            }

            DriverLocal.Value.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs(driver);
        }

        private static void OverrideTimezone()
        {
            var args = new Dictionary<string, object>();
            var timezoneId = Environment.GetEnvironmentVariable("TIMEZONE_OVERRIDE");
            args.Add("timezoneId", timezoneId);
            ((ChromeDriver)driver).ExecuteCdpCommand("Emulation.setTimezoneOverride", args);
        }

        private static void InvokeEnvironmentVariables(string jsonEnvironmentFileName)
        {
            JObject environmentVariables = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine(SourceDir, jsonEnvironmentFileName.ToLower())).ReadToEnd());
            //apollo keyvault
            var apolloKeyVault = KeyVault.CreateInstance(environmentVariables?["APOLLO_KEYVAULT_URI"]?.ToString(), "APOLLOSECRET");
            var apolloKeyVaultUserName = KeyVault.CreateInstance(environmentVariables?["APOLLO_USERCREDENTIALS_URI"]?.ToString(), "APOLLOUSERNAME");
            var apolloKeyVaultPassword = KeyVault.CreateInstance(environmentVariables?["APOLLO_USERCREDENTIALS_URI"]?.ToString(), "APOLLOPASSWORD");
            //BSP key credential key vault
            var bspKeyVault = KeyVault.CreateInstance(environmentVariables?["APP_BSP_KEYVAULT_URI"]?.ToString(), "BSPSECRET");
            
            //Loop through each variable, 
            //checks if the variable has already been set 
            //Only sets variables if they have not already been set
            
            //sets Secret and it's value as Environment Variables if provided
            //(only sets secret values if not on pipeline, pipeline sets secrets differently)
            foreach (var variable in environmentVariables)
            {
                if (Environment.GetEnvironmentVariable(variable.Key) == null)
                {
                    Environment.SetEnvironmentVariable(variable.Key, variable.Value.ToString());
                }
                
                //if the variable is a secret name we will load the secret
                //as an environment variable if it does not already exist
                apolloKeyVault?.StoreSecretFromJSONIfNecessary(variable);
                apolloKeyVaultUserName?.StoreSecretFromJSONIfNecessary(variable);
                apolloKeyVaultPassword?.StoreSecretFromJSONIfNecessary(variable);
                bspKeyVault?.StoreSecretFromJSONIfNecessary(variable);
            }
        }
    }
}
