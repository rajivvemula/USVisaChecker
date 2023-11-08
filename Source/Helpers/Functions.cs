using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HitachiQA.Driver;
using Table = TechTalk.SpecFlow.Table;

/*
 * This class should contain functions that hold boilerplate code applicable in many contexts
 * Ex: Parsing strings into specifics objects, formatting an object into a string
 */

namespace HitachiQA.Helpers
{
    public static class Functions
    {
        /// <summary>
        /// Parses a url or relative path string into a navigable URL
        /// </summary>
        /// <param name="urlOrPath">URL or relative path to navigate to</param>
        /// <param name="parameters">key/value pairs to replace in the urlOrPath param</param>
        /// <returns>the absolute URL to navigate to</returns>
        /// <remarks>
        /// If the urlOrPath arg does not begin with "http", then it will be treated as a relative path in the configured host URL<br/><br/>
        /// The urlOrParam arg can have dynamic params with the following format: "https://example.com/{page}"<br/>
        /// The parameters arg can then have an element to replace the page<br/>
        /// Ex: if {page} should be "contact" then pass [{"page", "contact"}] and the URL will be "https://example.com/contact"
        /// </remarks>
        public static string ParseURL(string urlOrPath, params (string key, string value)[] parameters)
        {
            foreach (var param in parameters)
            {
                urlOrPath = urlOrPath.Replace("{" + param.key + "}", param.value);
            }
            return ParseURL(urlOrPath);
        }

        /// <summary>
        /// Parses a url or relative path string into a navigable URL
        /// </summary>
        /// <param name="urlOrPath">URL or relative path to navigate to</param>
        /// <returns>the absolute URL to navigate to</returns>
        /// <remarks>
        /// If the urlOrPath arg does not begin with "http", then it will be treated as a relative path in the configured host URL<br/><br/>
        /// </remarks>
        public static string ParseURL(string urlOrPath)
        {

            if (urlOrPath.StartsWith("http"))
            {
                return urlOrPath;
            }
            else
            {
                return CombineURLPath(Environment.GetEnvironmentVariable("HOST"), urlOrPath);
            }
        }

        private static string CombineURLPath(string host, string path)
        {
            
            return host + (path.StartsWith('/') ? path : "/" + path);
            
        }

        //
        //  Failure Handling
        //
        public static void HandleFailure(string message, Exception ex = null, bool optional = false)
        {
            if (optional)
            {
                Log.Warn(message);
                Log.Warn(ex?.Message);
            }
            else
            {
                Log.Error(message);
                Log.Error(ex?.Message);
                throw new Exception(message, ex);
            }
        }

        public static void HandleFailure(Exception ex, bool optional = false)
        {
            if (optional)

            {
                Log.Warn(ex.Message);
            }
            else
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Enter random data for; name, last name, phone number, email and address!
        /// </summary>
        /// <param name="numberOfCharacters"></param>
        /// <param name="restriction"></param>
        /// <returns></returns>
        public static string GetRandomStringWithRestrictions(int numberOfCharacters, string restriction)
        {
            var chars = "";
            switch (restriction)
            {
                case "numeric":
                    chars = "0123456789";
                    break;
                case "alpha":
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    break;
                case "alphaNumeric":
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    break;
            }
            var stringChars = new char[numberOfCharacters];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new string(stringChars);
            return finalString;
        }

        /// <summary>
        /// Enter random number of employee
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int GetRandomInteger(int minValue, int maxValue)
        {
            int numberOfCharacters = -1;
            if (1 <= maxValue && maxValue < 10)
            {
                numberOfCharacters = 1;
            }

            else if (10 <= maxValue && maxValue < 100)
            {
                numberOfCharacters = 2;
            }

            else if (100 <= maxValue && maxValue < 1000)
            {
                numberOfCharacters = 3;
            }

            string str = "";
            int numValue = -1;

            do
            {
                str = GetRandomStringWithRestrictions(numberOfCharacters, "numeric");
                numValue = int.Parse(str);
            }
            while (numValue < minValue || numValue > maxValue);
            return numValue;
        }

        /*
         * Date Functions - ones that return a date value-----------------------------------------------------------
         */

        /// <summary>
        /// Return the next day date in the format requested.
        /// Sample format to pass in "MM/dd/yyyy"
        /// </summary>
        /// <param name="format"></param>
        /// <returns>type string of next day date in format requested</returns>
        public static string GetNextDay(string format)
        {
            DateTime utcNow = DateTime.UtcNow;
            var timezoneOverride = TimeZoneInfo.FindSystemTimeZoneById(Environment.GetEnvironmentVariable("TIMEZONE_OVERRIDE"));
            var timezonedNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, timezoneOverride);
            DateTime nextDay = timezonedNow.AddDays(1);
            return nextDay.ToString(format);
        }

        /// <summary>
        /// Edit a date based on adding/subtracting either days, months, or years from current time (UTC).
        /// </summary>
        /// <param name="numToAddSub">Positive or negative integer to be used to manipulate the date.</param>
        /// <param name="timeUnitToEditBy">Edit by D,M, or Y (day, month, or year respectively).</param>
        /// <param name="format">How the returned date string will be formatted.</param>
        /// <returns>Newly created date in format requested in the environment's timezone override.</returns>
        /// <remarks>Returned value is NEVER in UTC</remarks>
        public static DateTime GetDifferentDateFromNow(int numToAddSub, string timeUnitToEditBy)
        {
            return GetDifferentDateFrom(DateTime.UtcNow, numToAddSub, timeUnitToEditBy);
        }

        /// <summary>
        /// Edit a date based on adding/subtracting either days, months, or years from specified DateTime structure
        /// </summary>
        /// <param name="originalDate">DateTime to start from</param>
        /// <param name="numToAddSub">Positive or negative integer to be used to manipulate the date.</param>
        /// <param name="timeUnitToEditBy">Edit by D,M, or Y (day, month, or year respectively).</param>
        /// <returns>Newly created date in format requested in the environment's timezone override.</returns>
        /// <exception cref="ArgumentException">if time unit is not either d, m, or y</exception>
        /// <remarks>Returned value is NEVER in UTC</remarks>
        public static DateTime GetDifferentDateFrom(DateTime originalDate, int numToAddSub, string timeUnitToEditBy)
        {
            Log.Debug($"Original Date: {originalDate:G}");
            Log.Debug($"Original Date Kind: {originalDate.Kind.ToString()}");
            var timezoneOverride = TimeZoneInfo.FindSystemTimeZoneById(Environment.GetEnvironmentVariable("TIMEZONE_OVERRIDE"));
            
            // Normalized because DateTime can either be from UTC or from local time
            var utcDate = NormalizeDateTimeStructure(originalDate);
            var timezonedDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezoneOverride);

            switch (timeUnitToEditBy.ToLower())
            {
                case "d":
                    return timezonedDate.AddDays(numToAddSub);
                case "m":
                    return timezonedDate.AddMonths(numToAddSub);
                case "y":
                    return timezonedDate.AddYears(numToAddSub);
                default:
                    throw new ArgumentException("Date unit to edit by is invalid");
            }
        }

        /// <summary>
        /// Reformat a date string to the desired format.
        /// Sample format to pass in "MM/dd/yyyy"
        /// </summary>
        /// <param name="dateToEdit">The date in string format to be reformatted</param>
        /// <param name="format">The way the date needs to be formatted</param>
        /// <returns>Newly created date in format requested.</returns>
        public static string ReformatDateString(string dateToEdit, string format)
        {
            return Convert.ToDateTime(dateToEdit).ToString(format);
        }

        /*
         * Date Functions - ones that return a bool value OR are void-----------------------------------------------------------
         */
        /// <summary>
        /// Check if the date (of type string) passed in is tommorrow's date.
        /// </summary>
        /// <param name="dateToCheck"></param>
        /// <returns>True if the date is next day</returns>
        public static bool IsDateNextDay(string dateToCheck)
        {
              var result = DateTime.Compare(Convert.ToDateTime(dateToCheck), Convert.ToDateTime(GetNextDay("MM/dd/yyyy")));

              if(result == 0) //meaning there is NO difference between the two dates
              {
                  return true;
              }
              else //could be positive or negative, meaning there IS a difference between the two dates
              { 
                  return false; 
              }
        }

        /// <summary>
        /// Compare two dates, stored as strings, in different formats.
        /// </summary>
        /// <param name="date1">Date in string format to compare.</param>
        /// <param name="date2">Different date in different string format to compare.</param>
        /// <returns>Nothing.</returns>
        public static void CompareTwoDateStringsDifferentFormats(string date1, string date2)
        {
            var result = DateTime.Compare(Convert.ToDateTime(date1), Convert.ToDateTime(date2));

            //if the result from the date compare is 0, the datetimes are the same
            Assert.IsTrue(result == 0);
        }

        public static Func<string, Element> CreateSingleArgSelector<T1>(Func<T1, string, Element> twoArgSelector, T1 firstArg)
        {
            return secondArg => twoArgSelector(firstArg, secondArg);
        }

        public static string GetElementXPath(By locator) 
        {
            var regex = new Regex("(?<=By.XPath: ).*");

            return regex.Match(locator.ToString()).ToString();
        }

        /// <summary>
        /// Convert the string to boolean value
        /// </summary>
        /// <remarks>Case insensitive (ie: "yes" = "Yes" = "YES")</remarks>
        /// <param name="yesOrNo">"yes" or "no"</param>
        /// <returns>
        /// true if "yes"; false if "no"
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool ConvertYesOrNoStringToBool(string yesOrNo)
        {
            if (yesOrNo?.ToLower() != "yes" && yesOrNo?.ToLower() != "no")
            {
                throw new ArgumentException($"Cannot convert to bool because '{yesOrNo}' is not a 'yes' or 'no' response");
            }

            return yesOrNo.ToLower() == "yes";
        }

        /// <summary>
        /// Convert the bool to yes/no
        /// </summary>
        /// <remarks>Returns with first letter capitalized</remarks>
        /// <param name="yesOrNo">"Yes" or "No"</param>
        /// <returns>
        /// yes if true, no if alse
        /// </returns>
        public static string ConvertBoolToYesNoString(bool value)
        {
            return value ? "Yes" : "No";
        }

        /// <summary>
        /// Converts a string into list using semicolon as a separator
        /// </summary>
        /// <param name="semicolonList">Semicolon separated list</param>
        /// <returns>
        /// Separated collection of strings from input string
        /// </returns>
        public static IEnumerable<string> ParseSemicolonSeparatedList(string semicolonList)
        {
            string pattern = @"[A-z (),./&]+";
            Regex rgx = new Regex(pattern);
            Match match = rgx.Match(semicolonList);
            while (match.Success)
            {
                yield return match.Value;
                match = match.NextMatch();
            }
        }

        public static string ReplaceDisallowedFilenameCharacters(string fileNameBase)
        {
            return Regex.Replace(fileNameBase, "[<>:\"/\\\\\\|?*\\.]", "_");
        }

        public static List<string> GetTableRowsAsAStringList(Table table) 
        {
            var stringList = new List<string>();

            foreach (var row in table.Rows)
            {
                foreach (var value in row.Values)
                {
                    stringList.Add(value);
                }
            }

            return stringList;
        }

        public static Action SetMethodForRetry<T>(Action<T> method, T param)
        {
            return () => method(param);
        }

        public static Action SetMethodForRetry<T1, T2>(Action<T1, T2> method, T1 param1, T2 param2)
        {
            return () => method(param1, param2);
        }

        public static Func<bool> SetMethodForRetry<T>(Func<T, bool> method, T param)
        {
            return () => method(param);
        }

        public static Func<bool> SetMethodForRetry<T1, T2>(Func<T1, T2, bool> method, T1 param1, T2 param2)
        {
            return () => method(param1, param2);
        }

        public static Func<bool> SetMethodForRetry<T1, T2, T3>(Func<T1, T2, T3, bool> method, T1 param1, T2 param2, T3 param3)
        {
            return () => method(param1, param2, param3);
        }

        public static List<T> EnumerateIntoList<T>(Func<int, T> indexer, int min, int max)
        {
            var list = new List<T>();
            for (int i = min; i <= max; i++)
            {
                list.Add(indexer(i));
            }
            return list;
        }

        /// <summary>
        /// Ensures DateTime structure is set to UTC timezone and is marked as UTC
        /// </summary>
        /// <param name="originalDate"></param>
        /// <returns>DateTime converted as UTC</returns>
        private static DateTime NormalizeDateTimeStructure(DateTime originalDate)
        {
            var timezoneOverride = TimeZoneInfo.FindSystemTimeZoneById(Environment.GetEnvironmentVariable("TIMEZONE_OVERRIDE"));

            DateTime utcDate = new DateTime();

            switch (originalDate.Kind)
            {
                case DateTimeKind.Utc:
                    utcDate = originalDate;
                    break;
                case DateTimeKind.Local:
                    utcDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(originalDate, TimeZoneInfo.Utc.Id);
                    break;
                case DateTimeKind.Unspecified:
                    utcDate = TimeZoneInfo.ConvertTimeToUtc(originalDate, timezoneOverride);
                    break;
                default:
                    throw new Exception("New DateTimeKind was added by Microsoft and is unaccounted for");
            }

            return utcDate;
        }
    }
}