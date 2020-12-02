﻿using System;
using System.Collections.Generic;
using System.Text;

using BoDi;
using Microsoft.Azure.Cosmos;
using Dynamitey;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using ApolloQA.Source.Helpers;
using System.IO;
using System.Reflection;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ApolloQA.Source.Driver
{
    [Binding]
    public class Setup
    {
        private static IObjectContainer _objectContainer;
        public static IWebDriver driver;
        public static IWebDriver driverTemp;
        public static String SourceDir = Environment.GetEnvironmentVariable("SourceDir") ?? "../" ;
        public Setup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            invokeEnvironmentVariables(Environment.GetEnvironmentVariable("ENVIRONMENT_FILE") ?? "default.env.json");

            invokeNewDriver();
        }
        public static void invokeNewDriver()
        {
          
            string browser = Environment.GetEnvironmentVariable("BROWSER", EnvironmentVariableTarget.Process);
            switch (browser?.ToLower())
            {
                case "chrome":
                    var options = new ChromeOptions();
                    options.AddArgument("--window-size=1920,1080");
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new NotImplementedException($"Environment variable BROWSER value={browser} is not supported");
            }
            driver.Manage().Window.Maximize();
        }

        [BeforeScenario("newWindow", Order =1)]
        public static void pre_NewWindow()
        {
            driverTemp = driver;
            invokeNewDriver();
        }
        [AfterScenario("newWindow", Order=1)]
        public static void post_NewWindow()
        {
            driver.Quit();
            driver = driverTemp;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs(driver);

        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext _scenarioContext)
        {
            if (_scenarioContext.TestError != null)
            {
                ScreenShot.Error();
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Quit();
            Cosmos.client.Dispose();
        }

        private static void invokeEnvironmentVariables(string JsonEnvironmentFile_RelativePath )
        {

            Console.WriteLine(Path.Combine(SourceDir, JsonEnvironmentFile_RelativePath));
            JObject environmentVariables = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine(SourceDir, JsonEnvironmentFile_RelativePath)).ReadToEnd());

            
            foreach (var variable in environmentVariables)
            {
                if (Environment.GetEnvironmentVariable(variable.Key) == null)
                {
                    Environment.SetEnvironmentVariable(variable.Key, variable.Value.ToString());
                }
                else
                {
                    Log.Info($"Using {variable.Key} = {variable.Value}");
                }
            }
        }
    }
}
