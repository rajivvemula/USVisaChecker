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
    public  class Setup
    {
        private static IObjectContainer _objectContainer;
        public static IWebDriver Driver;

        public Setup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();

        }


        [BeforeScenario]
        public  void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs(Driver);
        }


        [AfterTestRun]
        public static void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
