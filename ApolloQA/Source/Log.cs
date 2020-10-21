using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloQA
{

    public static class Log
    {
  
        public static readonly Severity CurrentLogLevel = Severity.DEBUG;


        public static void Info(string text) => Write(Severity.INFO, text);
        public static void Debug(string text) => Write(Severity.DEBUG, text);
        public static void Warn(string text) => Write(Severity.WARN, text);
        public static void Error(string text) => Write(Severity.ERROR, text);
        public static void Critical(string text) => Write(Severity.CRITICAL, text);

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
        public static void Write(Severity severity, string text)
        {

            if (severity.Level <= CurrentLogLevel.Level)
            {
                Console.WriteLine($"[{severity.Name}] {text}");
            }
        }



    }

    public class Severity
    {
     
        public const int
         INT_OFF = 0,
         INT_CRITICAL = 1,
         INT_ERROR = 2,
         INT_WARN = 3,
         INT_DEBUG = 4,
         INT_INFO = 5;

        public static readonly Severity
          INFO = new Severity(INT_INFO),
          DEBUG = new Severity(INT_DEBUG),
          WARN = new Severity(INT_WARN),
          ERROR = new Severity(INT_ERROR),
          CRITICAL = new Severity(INT_CRITICAL);

        public static Dictionary<int, string> SEVERITIES = new Dictionary<int, string>()
        {
            {INT_OFF,     "OFF" },
            {INT_CRITICAL,"CRITICAL"},
            {INT_ERROR,   "ERROR"},
            {INT_WARN,    "WARN"},
            {INT_DEBUG,   "DEBUG"},
            {INT_INFO,    "INFO"},

        };

        public int Level { get; }
        public string Name { get { return SEVERITIES[Level]; } }
        public Severity(int level)
        {
            if (SEVERITIES.ContainsKey(level))
            {
                this.Level = level;
            }
            else
            {
                throw new ArgumentException($"Severity Level: [{level}] is not valid");
            }

        }


    }
}
