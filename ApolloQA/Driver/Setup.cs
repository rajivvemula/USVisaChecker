using ApolloQA.DataFiles;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ApolloQA.Driver
{
    [Binding]
    public class Setup
    {
        private static IObjectContainer _objectContainer;
        public static IWebDriver driver;
        public static State state;

        public Setup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            state = new State();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs(driver);
            _objectContainer.RegisterInstanceAs(state);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //driver.Quit();
        }
    }
}
