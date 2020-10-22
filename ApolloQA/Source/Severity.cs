using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA
{
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



        public static readonly Dictionary<int, string> SEVERITIES = new Dictionary<int, string>()
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
            if (level>=0 || level<=5)
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
