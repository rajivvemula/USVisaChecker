using System.Collections.Generic;
using System.IO;
using System.Text;
using HitachiQA.Helpers;
using TechTalk.SpecFlow.Infrastructure;

namespace BiBerkLOB.Source.Helpers;

public class ScenarioLog
{
    private ISpecFlowOutputHelper _outputHelper;
    private List<string> _logList;

    public ScenarioLog(ISpecFlowOutputHelper outputHelper)
    {
        _logList = new List<string>();
        _outputHelper = outputHelper;
    }

    public void WriteLine(object text)
    {
        _logList.Add(text.ToString());
    }

    public void DumpLogFile(string logFileNameBase = "test_log")
    {
        var safeFileName = Functions.ReplaceDisallowedFilenameCharacters(logFileNameBase);
        var log = new StringBuilder();
        foreach (var logMessage in _logList)
        {
            log.AppendLine(logMessage);
        }

        var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
        if (!Directory.Exists(artifactDirectory))
        {
            Directory.CreateDirectory(artifactDirectory);
        }

        string logFilePath = Path.Combine(artifactDirectory, safeFileName + ".txt");
        File.WriteAllText(logFilePath, log.ToString(), Encoding.UTF8);
        _outputHelper.AddAttachment(logFilePath);

#if DEBUG
        _outputHelper.WriteLine("Test Log:\n" + log.ToString());
#endif

        _logList.Clear();
    }

    
}