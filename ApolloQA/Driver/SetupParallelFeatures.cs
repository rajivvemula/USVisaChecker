﻿//using ApolloQA.DataFiles;
//using ApolloQA.Pages.Shared;
//using BoDi;
//using Microsoft.Azure.Cosmos;
//using Dynamitey;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using TechTalk.SpecFlow;
//using ApolloQA.Pages.Login;
//using ApolloQA.Pages;
//using ApolloQA.Helpers;


//namespace ApolloQA.Driver
//{
//    [Binding]
//    public class SetupParallelFeatures
//    {
//        //private static IObjectContainer _objectContainer;
//        //public static IWebDriver driver;
//        public static State state;
//        public static CosmosClient client;
//        public static Database database;
//        public static FeatureContext _featureContext;

//        //public Setup(IObjectContainer objectContainer)
//        //{
//        //    _objectContainer = objectContainer;
//        //}

//        [BeforeTestRun]
//        public static void BeforeTestRun()
//        {
//            //string browser = Environment.GetEnvironmentVariable("Browser", EnvironmentVariableTarget.Process);
//            //switch (browser)
//            //{
//            //    case "chrome":
//            //        driver = new ChromeDriver();
//            //        Console.WriteLine("Chrome was selected");
//            //        break;
//            //    case "firefox":
//            //        driver = new FirefoxDriver();
//            //        break;
//            //    default:
//            //        driver = new ChromeDriver();
//            //        break;

//            //}
//            //driver = new ChromeDriver();
//            //driver.Manage().Window.Maximize();
//            //state = new State();
//            //client = new CosmosClient("https://zbibaoazcdb1qa2.documents.azure.com:443/", "p9fiijwywnNpP4gRROO0NNA2sDMPyyjZ0OfMzJGriSCZIEKUGNrIyzut20ICyyGnGtbVwRr5rmgT57TIBE0LvQ==");
//            // database = client.GetDatabase("apollo");
//        }

//        [BeforeFeature]
//        public static void BeforeFeature(IObjectContainer objectContainer)
//        {
//            IObjectContainer _objectContainer = objectContainer;

//            IWebDriver driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();

//            _objectContainer.RegisterInstanceAs(driver);


//        }

//        //[BeforeFeature]
//        //public static void BeforeFeature(FeatureContext featureContext)
//        //{
//        //    _featureContext = featureContext;
//        //    _featureContext.Add("Application List", new List<ApplicationObject>());
//        //}

//        //[AfterFeature]
//        //public static void AfterFeature(FeatureContext featureContext)
//        //{
//        //    //print current feature's Application List

//        //    //add current Application to State's objects Application List

//        //    //flush the Feature's Application List
//        //}


//        [BeforeScenario]
//        public void BeforeScenario()
//        {
//            //_objectContainer.RegisterInstanceAs(driver);
//            //_objectContainer.RegisterInstanceAs(state);
//            //_objectContainer.RegisterInstanceAs(client);
//        }

//        [AfterTestRun]
//        public static void AfterTestRun()
//        {
//            //driver.Quit();
//        }
//    }
//}