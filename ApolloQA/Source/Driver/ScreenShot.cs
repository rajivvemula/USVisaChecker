using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace ApolloQA.Source.Driver
{
    public class Screenshot
    {
        public static void Info() => Take(Severity.INFO);
        public static void Debug() => Take(Severity.DEBUG);
        public static void Warn() => Take(Severity.WARN);
        public static void Error() => Take(Severity.ERROR);
        public static void Critical() => Take(Severity.CRITICAL);


        public static void Take(Severity severity)
        {

            if (severity.Level <= Defaults.CurrentSeverityLevel.Level)
            {

                string fileNameBase = string.Format($"{severity.Name}_{FeatureContext.Current.FeatureInfo.Title}_{ScenarioContext.Current.ScenarioInfo.Title}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}");

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");

                if (!Directory.Exists(artifactDirectory)) { Directory.CreateDirectory(artifactDirectory); }

                string pageSource = Setup.driver.PageSource;
                string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine($"\nPage Source: {new Uri(sourceFilePath)}\n");


                ITakesScreenshot takesScreenshot = Setup.driver as ITakesScreenshot;
                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

                    Console.WriteLine($"\nScreenshot: {new Uri(screenshotFilePath)}\n");
                }



            }
        }
    }
}
