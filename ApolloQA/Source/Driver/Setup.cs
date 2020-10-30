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

namespace ApolloQA.Source.Driver
{
    [Binding]
    public class Setup
    {
        private static IObjectContainer _objectContainer;
        public static IWebDriver driver;

        public Setup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            invokeEnvironmentVariables(Environment.GetEnvironmentVariable("ENVIRONMENT_FILE") ?? "default.env.json"); 

            string browser = Environment.GetEnvironmentVariable("BROWSER", EnvironmentVariableTarget.Process);
            switch (browser?.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new NotImplementedException($"Environment variable BROWSER value={browser} is not supported");
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

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
            JObject environmentVariables;
            /*            try
                        {*/
            Console.WriteLine("current Directory: "+Directory.GetCurrentDirectory());
            Console.WriteLine("env directory: " + Environment.GetEnvironmentVariable("BuildDir"));
                environmentVariables = JsonConvert.DeserializeObject<JObject>(new StreamReader(Directory.GetCurrentDirectory().Contains("TestResults")?$"../{JsonEnvironmentFile_RelativePath}": JsonEnvironmentFile_RelativePath).ReadToEnd());
 /*           }
            catch(FileNotFoundException)
            {
               
                throw new NotFoundException($"missing [{JsonEnvironmentFile_RelativePath}] file, this is needed in order to run this framework");
            }*/

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
