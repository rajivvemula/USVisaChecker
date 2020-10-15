using ApolloQA.DataFiles;
using ApolloQA.Pages.Shared;
using BoDi;
using Microsoft.Azure.Cosmos;
using Dynamitey;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using ApolloQA.Helpers;

namespace ApolloQA.Driver
{
    [Binding]
    public class Setup
    {
        private static IObjectContainer _objectContainer;
        public static IWebDriver driver;
        public static IWebDriver currentDriver;
        public static State state;
        public static CosmosClient client;
        public static Database database;
        public static FeatureContext _featureContext;
        public static RestAPI api;
        public static ScenarioContext _scenarioContext;

        public Setup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string browser = Environment.GetEnvironmentVariable("Browser", EnvironmentVariableTarget.Process);
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    Console.WriteLine("Chrome was selected");
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;

            }
            //driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            state = new State();
            client = new CosmosClient("https://zbibaoazcdb1qa2.documents.azure.com:443/", "p9fiijwywnNpP4gRROO0NNA2sDMPyyjZ0OfMzJGriSCZIEKUGNrIyzut20ICyyGnGtbVwRr5rmgT57TIBE0LvQ==");
            api = new RestAPI(driver);
            database = client.GetDatabase("apollo");
        }

        [BeforeFeature(Order = 1)]
        public static void BeforeFeature()
        {
            currentDriver = driver;
        }

        [BeforeFeature("newWindow", Order = 2)]
        public static void BeforeFeatureNewWindow()
        {
            currentDriver = new ChromeDriver();
            currentDriver.Manage().Window.Maximize();
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs(currentDriver);
            _objectContainer.RegisterInstanceAs(state);
            _objectContainer.RegisterInstanceAs(client);
            _objectContainer.RegisterInstanceAs(api);

        }

        [AfterFeature]
        public static void AfterFeature()
        {
            if(currentDriver != driver)
            {
                currentDriver.Quit();
                currentDriver = null;
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Quit();
            client.Dispose();
        }
    }
}