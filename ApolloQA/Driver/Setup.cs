using ApolloQA.DataFiles;
using BoDi;
using Dynamitey;
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
        public static FeatureContext _featureContext;

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

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            _featureContext.Add("Application List", new List<ApplicationObject>());
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            //print current feature's Application List

            //add current Application to State's objects Application List

            //flush the Feature's Application List
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
