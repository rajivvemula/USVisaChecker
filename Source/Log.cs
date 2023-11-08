using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BiBerkLOB.Source.Helpers;
using TechTalk.SpecFlow.Infrastructure;

namespace HitachiQA
{

    public static class Log
    {
        public static ThreadLocal<ScenarioLog> ThreadLocalLog = new();
        private static ScenarioLog ScenarioLog => ThreadLocalLog.Value;

        public static void Debug(object text) => Write(Severity.DEBUG, text);
        public static void Info(object text) => Write(Severity.INFO, text);
        public static void Warn(object text) => Write(Severity.WARN, text);
        public static void Error(object text) => Write(Severity.ERROR, text);
        public static void Critical(object text) => Write(Severity.CRITICAL, text);

        /// <summary>
        /// Will log text to the the given severity
        /// </summary>
        /// <remarks>
        /// Examples: <br/>
        /// Log.write(Severity.INFO, "informational message") <br/>
        /// OR <br/>
        /// Log.info("informational message") <br/>
        /// </remarks>
        /// 
        public static void Write(Severity severity, object text)
        {
            if (text == null)
            {
                return;
            }

            var currentSev = SeverityHelper.ParseOrDefault(Environment.GetEnvironmentVariable("CURRENT_SEVERITY_LEVEL"));

            if(currentSev == 0)
            {
                return;
            }
            else if (severity <= currentSev)
            {
                ScenarioLog.WriteLine($"[{severity.ToString()}] {text}");
            }
        }
        
        public static void Separator()
        {
            ScenarioLog.WriteLine("---------------------------------------------------------------------------------");
        }

        public static void Dump(string fileNameBase = "text_log")
        {
            ScenarioLog.DumpLogFile(fileNameBase);
        }
    }
}
