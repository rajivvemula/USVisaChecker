using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HitachiQA
{
    public enum Severity
    {
        OFF = 0,
        CRITICAL = 1,
        ERROR = 2,
        WARN = 3,
        INFO = 4,
        DEBUG = 5
    }

    public static class SeverityHelper
    {
        public const Severity DEFAULT_SEVERITY = Severity.INFO;
        public static Severity ParseOrDefault(string severityName)
        {
            Severity toReturn;
            try
            {
                toReturn = Enum.Parse<Severity>(severityName);
            }
            catch
            {
                toReturn = DEFAULT_SEVERITY;
            }

            return toReturn;
        }
    }
}
