using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow.Assist;
using ApolloQA.Source.Driver;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace ApolloQA.Source.Helpers
{
    class Functions
    {

        public static void ScrollToBottom()
        {
            UserActions.ScrollToBottom();

        }
        public static void ScrollToTop()
        {
            UserActions.ScrollToTop();
        }
        public static string GetCurrentURL()
        {
            return UserActions.GetCurrentURL();
        }
        public static string GetCurrentURLPath()
        {
            return new Uri(UserActions.GetCurrentURL()).PathAndQuery;
        }

        public static string ParseURL(string URL_OR_PATH, params (string key, string value)[] parameters)
        {
            foreach (var param in parameters)
            {
                URL_OR_PATH = URL_OR_PATH.Replace("{" + param.key + "}", param.value);
            }
            return ParseURL(URL_OR_PATH);
        }
        public static string ParseURL(string URL_OR_PATH)
        {

            if (URL_OR_PATH.StartsWith("http"))
            {
                return URL_OR_PATH;
            }
            else
            {
                return ParseURL(Environment.GetEnvironmentVariable("HOST"), URL_OR_PATH);
            }
        }
        public static string ParseURL(string Host, string Path)
        {
            
            return Host + (Path.StartsWith('/') ? Path : "/" + Path);
            
        }

        //
        //  Failure Handling
        //
        public static System.Exception handleFailure(string message, Exception ex = null, bool optional = false)
        {
            if (optional)
            { Log.Info(message); }
            else
            {
                Log.Error(message);
                if (ex != null)
                {
                    handleFailure(ex, optional);
                }
                else
                {
                    throw new Exception(message);
                }
            }
            return ex ?? new Exception(message);

        }
        public static System.Exception handleFailure(string message, Exception ex = null, bool optional = false, params (string key, dynamic value)[] parameters)
        {
            if (optional)
            { Log.Info(message, parameters); }
            else
            {
                Log.Error(message, parameters);
                if (ex != null)
                {
                    handleFailure(ex, optional);
                }
                else
                {
                    throw new Exception(message);
                }
            }
            return ex ?? new Exception(message);

        }
        public static System.Exception handleFailure(Exception ex, bool optional = false)
        {
            if (optional)
            {
                Log.Info(ex.Message);
            }
            else
            {
                Log.Error(ex.Message);
                throw ex;
            }
            return ex;

        }


        public static Dictionary<string, string> TableToDictionary(TechTalk.SpecFlow.Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static IEnumerable<Dictionary<String, String>> parseCSV(String filePath, int headerRow=0)
        {

            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = doc.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                Row[] sheetData = worksheetPart.Worksheet.Elements<SheetData>().First().Elements<Row>().ToArray<Row>();

                var header = sheetData[0].Elements<Cell>().Select(cell =>extractCellText(workbookPart, cell)).ToArray<string>();

                for (int rowIndex = 1; rowIndex < sheetData.Length; rowIndex++)
                {
                    
                    var cells = sheetData[rowIndex].Elements<Cell>().ToArray<Cell>();

                    var dict = new Dictionary<String, String>();
                    for (int i = 0; i < header.Length; i++)
                    {                        
                        
                        dict.Add(header[i], extractCellText(workbookPart, (Cell)cells[i]));
                    }
                    yield return dict;
                }
            }

           
        }

        private static String extractCellText(WorkbookPart workbookPart, Cell cell)
        {
            var cellValue = cell.CellValue;
            var text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable
                    .Elements<SharedStringItem>().ElementAt(
                        Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }
            return (text ?? string.Empty).Trim();
        }
        public static dynamic parseRatingFactorNumericalValues(String value)
        {
            if (value.Contains("+"))
            {
                return int.MaxValue;
            }
            else if(int.TryParse(value, out int intValue))
            {
                return intValue;
            }
            else
            {
                return null;
            }
        }
        public static int parseInt(string IntegerString)
        {
            try
            {
                return int.Parse(string.Join("", IntegerString.Where(Char.IsDigit)));
            }
            catch (Exception ex)
            {
                throw handleFailure($"String {IntegerString} Failed to parse into int", ex);
            }
        }

        public static string GetRandomVIN()
        {
            //grabs random vin via randomvin.com

            var vin = (string)RestAPI.GET("https://randomvin.com/getvin.php?type=real");

            return vin;
        }

        public static string GetValidIllinoisDriversLicenseNumber()
        {
            //not a great implementation but it works

            char[] chars =  "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Random r = new Random();

            string licenseNo = "" + chars[r.Next(chars.Length)];

            licenseNo += (r.Next(100, 1000).ToString()) + (r.Next(1000, 10000).ToString()) + (r.Next(1000, 10000).ToString());

            return licenseNo;
        }

    }
}
