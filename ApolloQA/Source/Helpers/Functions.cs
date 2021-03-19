﻿using DocumentFormat.OpenXml.Packaging;
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
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using ApolloQA.Data.Rating;

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

        public static IEnumerable<Dictionary<String, String>> parseExcel(String filePath, int headerRow = 0)
        {
            var tasks = new List<Task<Dictionary<String, String>>>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = doc.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                Row[] sheetData = worksheetPart.Worksheet.Elements<SheetData>().First().Elements<Row>().ToArray<Row>();

                var header = sheetData[0].Elements<Cell>().Select(cell => extractCellText(workbookPart, cell)).ToArray<string>();

                for (int rowIndex = 1; rowIndex < sheetData.Length; rowIndex++)
                {
                    tasks.Add(parseRow(workbookPart, header, sheetData[rowIndex]));

                }



            }
            return tasks.Select(it => it.Result);



        }
        public static List<Dictionary<String, String>> parseCSV(String filePath, int headerRow = 0)
        {
            List<string> header = new List<String>();

            if( !File.Exists(filePath))
            {
                handleFailure($"File {filePath} does not exist");
            }
            filePath = Path.IsPathFullyQualified(filePath) ? filePath : Path.GetFullPath(filePath);

            Log.Debug(filePath);


            List<Dictionary<String, String>> result = new List<Dictionary<String, String>>();

            using (TextReader reader = new StreamReader(filePath))
            {
                var config = new CsvConfiguration(CultureInfo.CreateSpecificCulture("en-US"))
                {
                    MissingFieldFound = null,
                };
                using (var csvReader = new CsvReader(reader, config))
                {

                    // calculate number of columns
                    csvReader.Read();
                    int i = 0;

                    var columnName = csvReader.GetField(i);

                    while (!String.IsNullOrEmpty(columnName))
                    {
                      
                        header.Add(columnName);
                        i++;
                        columnName = csvReader.GetField(i);
                    }

                    while (csvReader.Read())
                    {
                        
                        Dictionary<String, String> row = new Dictionary<String, String>();
                        for(int col =0; col < header.Count; col++)
                        {
                            row.Add(header.ElementAt(col), csvReader.GetField(col));
                        }
                        result.Add( row);
                    }
                }
            }
            return result;
        }

        private static async Task<Dictionary<String, String>> parseRow(WorkbookPart workbookPart, string [] header, Row row)
        {
            var cells = row.Elements<Cell>().ToArray<Cell>();

            var dict = new Dictionary<String, String>();
            for (int i = 0; i < header.Length; i++)
            {
                Cell cell;
                try
                {
                     cell= cells[i];
                }
                catch(IndexOutOfRangeException)
                {
                    cell = new Cell();
                }
                dict.Add(header[i], extractCellText(workbookPart, cell));
            }
            return dict;
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
            string vin;
            try
            {
                vin = (string)RestAPI.GET("https://randomvin.com/getvin.php?type=real");
                if(string.IsNullOrWhiteSpace(vin))
                {
                    return GetRandomVIN();
                }
                return vin;
            }
            catch
            {
                return GetRandomVIN();
            }

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

        public static string getValidCreditCardNumber(string cardType="Visa")
        {
            switch (cardType)
            {
                case "AmericanExpress":
                    return "370000000000002";

                case "Discover":
                    return "6011000000000012";

                case "JCB":
                    return "3088000000000017";
           
                case "Visa":
                    return "4111111111111111";

                case "Visa1":
                    return "4012888818888";

                case "Visa2":
                    return "4007000000027";

                case "Mastercard":
                    return "5424000000000015";

                case "Mastercard1":
                    return "2223000010309703";

                case "Mastercard2":
                    return "2223000010309711";

                case "DinersClub/CarteBlanche":
                    return "38000000000006";

                default:
                    throw handleFailure($"Credit Card Type: {cardType} is not supported");
            }
        }

        public static int GetRandomInteger(int max=100)
        {
           return new Random().Next(max);
            
        }
        public static Data.Entity.Quote GetQuotedQuoteThroughAPI()
        {
            return GetQuotedQuoteThroughAPI(ClassCodeKeyword.GetUsingKeywordName("Accounting Services"));
        }
        public static Data.Entity.Quote GetQuotedQuoteThroughAPI(ClassCodeKeyword classCodeKeyword)
        {
            return GetQuotedQuoteThroughAPI(classCodeKeyword, new List<CoverageType> { classCodeKeyword.coverage ?? new CoverageType("BIPD") });
        }
        public static Data.Entity.Quote GetQuotedQuoteThroughAPI(ClassCodeKeyword classCodeKeyword, List<CoverageType> coverages)
        {
            var org = new Data.TestData.Organization(classCodeKeyword);
            var quote = new Data.TestData.Quote(org, coverages);



            /*Parallel.Invoke(
                () => quote.CreateVehicle(),
                () => quote.CreateDriver(),
                () => quote.AnswerOperationQuestions(),
                () => quote.AddPolicyCoverages()
            );
            Parallel.Invoke(
                () => quote.AddVehicleToQuote(),
                () => quote.AddDriverToQuote()
            );
            quote.AddVehicleCoverage();*/


            quote.CreateVehicle();
            quote.AddVehicleToQuote();
            quote.AddVehicleCoverage();

            quote.CreateDriver();
            quote.AddDriverToQuote();

            quote.AnswerOperationQuestions();

            quote.AddPolicyCoverages();


            var summary = quote.GetSummary();
            Log.Debug("Quote Id: " + quote.quoteEntity.Id);
            Log.Debug("Rating Group Id (rating worksheet): " + summary?["ratingGroupId"]??"null");
            if (summary["errors"].Count()>0 || summary?["ratingResponses"] == null )
            {
                Log.Critical(summary);
                throw Functions.handleFailure($"Premium generation was unsuccessful Quote: {quote.quoteEntity.Id} Premium: " + summary?["ratingResponses"]);
            }
            return quote.quoteEntity;
        }

        public static void MarkTestCasePassed(int testCaseId) 
        {
            if (!Setup.TestCaseOutcome.ContainsKey(testCaseId))
            {
                Setup.TestCaseOutcome.Add(testCaseId, Devops.OUTCOME_PASS);
            }
        }

        public static void MarkTestCaseFailed(int testCaseId)
        {
            if (!Setup.TestCaseOutcome.ContainsKey(testCaseId))
            {
                Setup.TestCaseOutcome.Add(testCaseId, Devops.OUTCOME_FAIL);

            }
        }        

    }
}
