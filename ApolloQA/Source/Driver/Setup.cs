using System;
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
           
            string browser = Environment.GetEnvironmentVariable("Browser", EnvironmentVariableTarget.Process);
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;


            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs(driver);

        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            //driver.Quit();
            Cosmos.client.Dispose();
        }
    }
}
