using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System;
using TechTalk.SpecFlow.Infrastructure;

namespace HitachiQA;

public class ScreenShotTaker
{
    private ISpecFlowOutputHelper _outputHelper;
    private Severity _severity;

    public ScreenShotTaker(ISpecFlowOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _severity = SeverityHelper.DEFAULT_SEVERITY;
    }

    /// <summary>
    /// Captures a screen shot and page source at the time of calling<br/>
    /// and then attaches the files to the test case
    /// </summary>
    /// <param name="fileNameBase">
    /// The file name before prefix and suffix is applied.
    /// </param>
    /// <remarks>
    /// The prefix will be the severity level of the screen shot and the suffix<br/>
    /// will be "_screenshot" and "_source" for the .png and .html files respectively
    /// </remarks>
    public void Take(string fileNameBase)
    {
        var currentSev = SeverityHelper.ParseOrDefault(Environment.GetEnvironmentVariable("CURRENT_SEVERITY_LEVEL"));

        if (currentSev != 0 && _severity <= currentSev)
        {
            fileNameBase = $"{_severity.ToString()}_{fileNameBase}";
            fileNameBase = ReplaceDisallowedFilenameCharacters(fileNameBase);

            var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");

            if (!Directory.Exists(artifactDirectory)) { Directory.CreateDirectory(artifactDirectory); }

            SaveAndAttachHtml(fileNameBase, artifactDirectory);

            if (Setup.driver is ITakesScreenshot)
            {
                SaveAndAttachScreenShotImage(artifactDirectory, fileNameBase);
            }
        }
    }

    public ScreenShotTaker Debug()
    {
        _severity = Severity.DEBUG;
        return this;
    }

    public ScreenShotTaker Info()
    {
        _severity = Severity.INFO;
        return this;
    }

    public ScreenShotTaker Warn()
    {
        _severity = Severity.WARN;
        return this;
    }

    public ScreenShotTaker Error()
    {
        _severity = Severity.ERROR;
        return this;
    }

    public ScreenShotTaker Critical()
    {
        _severity = Severity.CRITICAL;
        return this;
    }

    private void SaveAndAttachScreenShotImage(string artifactDirectory, string fileNameBase)
    {
        var driverScreenshot = Setup.driver as ITakesScreenshot;
        var screenshot = driverScreenshot.GetScreenshot();
        var screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

        screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

        var screenshotBitMap = (Bitmap)Image.FromFile(screenshotFilePath);

        var resultBitMap = new Bitmap(screenshotBitMap.Width, screenshotBitMap.Height + 30);

        using (Graphics g = Graphics.FromImage(resultBitMap))
        {
            g.DrawString(Setup.driver.Url, new Font("Arial", 20), Brushes.Red, new PointF(0, 0));
            g.DrawImageUnscaled(screenshotBitMap, 0, 30);
        }

        screenshotBitMap.Dispose();
        File.Delete(screenshotFilePath);

        resultBitMap.Save(screenshotFilePath, ImageFormat.Png);
        resultBitMap.Dispose();

        _outputHelper.AddAttachment(screenshotFilePath);
        Log.Write(_severity, $"SCREENSHOT[ {screenshotFilePath} ]SCREENSHOT");
    }

    private void SaveAndAttachHtml(string fileName, string artifactDirectory)
    {
        string pageSource = Setup.driver.PageSource;
        string sourceFilePath = Path.Combine(artifactDirectory, fileName + "_source.html");
        File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);

        _outputHelper.AddAttachment(sourceFilePath);
    }

    private static string ReplaceDisallowedFilenameCharacters(string fileNameBase)
    {
        return Regex.Replace(fileNameBase, "[<>:\"/\\\\\\|?*]", "_");
    }
}