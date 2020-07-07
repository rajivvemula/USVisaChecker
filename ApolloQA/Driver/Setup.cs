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

        public Setup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArgument("no-sandbox");

            //driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(20));
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

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
        }
    }
}
