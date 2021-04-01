using ApolloQA.Source.Helpers;
using JsonDiffer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Rating
{
    [Binding]
    public class TablesSteps
    {
        public static List<Dictionary<String, String>> getTable(String state, String tableName)
        {
            return Functions.parseExcel(Path.Combine(Source.Driver.Setup.SourceDir, @$"Data\RatingManual\{state.ToUpper()}\{tableName}.xlsx")).ToList();
        }

        private string state;
        private string workdir => Path.Combine(Source.Driver.Setup.SourceDir, @$"Data\RatingManual\{state.ToUpper()}\");
        private string testResultDir => Path.Combine(Directory.GetCurrentDirectory(), @$"RatingTables\{state.ToUpper()}\");

        private JObject manual = new JObject();


        [Given(@"(.*) tables are parsed into json object")]
        public void GivenTablesAreParsedIntoJsonObject(string state)
        {
            this.state = state;
            DirectoryInfo dir = new DirectoryInfo(workdir);

            if(!Directory.Exists(testResultDir))
            {
                Directory.CreateDirectory(testResultDir);
            }

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                //ignoring any json files in the directory
                if (file.Name.Contains(".json"))
                {
                    continue;
                }
                var tableName = file.Name.Substring(0, file.Name.LastIndexOf('.'));

                manual.Add(tableName, new JArray());
              
                var persistedRows = (JArray)PersistedData?[state]?[tableName]?["rows"];
                var persistedColumns = (JObject)PersistedData?[state]?[tableName]?["columns"];

                var table = getTable(state, tableName);
                
             
                foreach (var row in table.Select((value, index) => (value, index)))
                {
                    string rowNumber = (row.index + 2).ToString();


                    if(persistedColumns != null)
                    {
                        foreach (var incorrectColumn in persistedColumns)
                        {
                            if (row.value.ContainsKey(incorrectColumn.Key))
                            {
                                row.value.Add(incorrectColumn.Value.ToString(), row.value[incorrectColumn.Key]);

                                row.value.Remove(incorrectColumn.Key);
                            }
                        }
                    }
                    
                  

                    if (persistedRows != null)
                    {
                        var persistedRow = persistedRows.FirstOrDefault(it => (String)it["Row"] == rowNumber);

                        if (persistedRow!=null)
                        {
                            if (persistedRow?["delete"] != null)
                            {
                                Log.Debug($"persist delete {state}, {tableName}");
                                continue;
                            }
                            else
                            {
                                Log.Debug($"persist replace {state}, {tableName}");

                                ((JArray)manual[tableName]).Add(persistedRow);
                                continue;
                            }
                        }
                    }
                    row.value.Add("Row", rowNumber);
                    ((JArray)manual[tableName]).Add(JObject.FromObject(row.value));
                }               

            }
            File.WriteAllText(testResultDir + "ParsedRatingTables.json", manual.ToString());
        }
        [Given(@"(.*) csv is parsed into json object")]
        public void GivenCsvIsParsedIntoJsonObject(string state)
        {
            this.state = state;

            var RatingTables = Functions.parseCSV(Path.Combine(Source.Driver.Setup.SourceDir, @$"Data\RatingManual\csv\{state}.csv"));

            manual = new JObject();

            foreach ((Dictionary<String, String> value, int index) row in RatingTables.Select((value, index) => (value, index)))
            {
                
                var algorithmName = row.value["SN"];
                var tableName = (algorithmName+"."+row.value["TN"]).Trim('.');
                string[] columnNames = row.value["CN"].Split("|");
                string[] columnValues = row.value["ST"].Split("|");

                if(columnNames.Length != columnValues.Length)
                {
                    Functions.handleFailure($"Incorrect Column/Value count in CSV for {state} at Row {row.index + 1}");
                }

                if (!manual.ContainsKey(tableName))
                {
                    manual.Add(tableName, new JArray());
                }

              

                JObject rowValues = new JObject();
                for (int i = 0; i < columnNames.Count(); i++)
                {
                    var column = columnNames[i];
                    var value = columnValues[i];
                    rowValues.Add(column, value);
                }
                rowValues.Add("Row", row.index + 1);

                ((JArray)manual[tableName]).Add(rowValues);

            }
            File.WriteAllText(testResultDir + "ParsedRatingTables.json", manual.ToString());

        }


        private JObject ActualManual = new JObject();
        [Given(@"tables are loaded from the system")]
        public void ThenTablesAreParsedIntoJsonFormat()
        {
            var tables = SQL.executeQuery($@"SELECT RatingTable.Id, RatingTable.[Name], StateProv.Code
                                FROM [rating].[ReferenceTable] RatingTable
                                LEFT JOIN [rating].[ReferenceTableStateProvince] RatingTableState on RatingTable.Id = RatingTableState.ReferenceTableId
                                LEFT JOIN [location].[StateProvince] StateProv on RatingTableState.StateProvinceId = StateProv.Id
                                WHERE LineId =7 AND CarrierPartyId = 4 and StateProv.Code = '{state.ToUpper()}'
                                GROUP BY  RatingTable.Id, RatingTable.[Name], StateProv.Code 
                                ;");
            
            //Task.Factory.StartNew(() => Parallel.ForEach(tables, table => ActualManual.Add(table["Name"], JArray.FromObject(GetTable((int)table["Id"]))))).Wait();

            foreach (var table in tables)
            {
                if(ActualManual.ContainsKey(table["Name"]))
                {
                    continue;
                }
                ActualManual.Add(table["Name"], JArray.FromObject(GetTable((long)table["Id"])));
            }

            File.WriteAllText(testResultDir + "SystemRatingTables.json", ActualManual.ToString());

        }

        private JObject errors = new JObject() { { "dataSize", new JArray() }, { "missingTable", new JArray() }, { "missingColumn", new JArray() }, { "incorrectValue", new JArray() } };


        [When(@"both manuals are compared")]
        public void WhenBothManualsAreCompared()
        {
            
            //loop through each table in the source of truth manual
            foreach(var table in manual)
            { 
                //description object to attach in case of any erros
                var description = new JObject() { { "tableName", table.Key }, { "row", new JObject()}, { "message", "" }, { "difference", new JArray()} };

                //check if the table exists in the system
                if(!ActualManual.ContainsKey(table.Key))
                {
                    description["message"]= $"the System is missing expected table {table.Key}";
                    ((JArray)errors["missingTable"]).Add(description);

                    continue;
                }

                //table in the system
                var actualTable = (JArray)ActualManual[table.Key];
                //table in the source of truth manual
                var expectedTable =(JArray) table.Value;

                //
                // We want to sort both tables to make sure we're comparing correctly
                //
                sortTablesIdentically(ref expectedTable, ref actualTable, table.Key);


                var expectedRowCount = expectedTable.Count();
                var actualRowCount = actualTable.Count();

                //Compare table size
                if (expectedRowCount != actualRowCount)
                {
                    //cleanup Row property from the source of t
                    foreach (JObject row in expectedTable)
                    {
                        row.Remove("Row");
                    }
                    
                    
                    var differences= JsonDifferentiator.Differentiate(actualTable, expectedTable);
                    description["difference"] = new JObject() { { "missing", new JArray() }, { "additional", new JArray() } };


                    //loop through the difference and identify missing or additional rows
                    foreach (JObject difference in differences)
                    {
                        if(difference.Properties().Where(it => it.Name.Contains('-')).Count()>1)
                        {
                            ((JArray)description["difference"]["additional"]).Add(difference);

                        }
                        if (difference.Properties().Where(it => it.Name.Contains('+')).Count() > 1)
                        {
                            ((JArray)description["difference"]["missing"]).Add(difference);

                        }
                    }
                    description["message"] = $"Expected row Count: {expectedTable.Count()}     Actual row Count: {actualTable.Count()}";

                    if(((JArray)description["difference"]["missing"]).Count >20 || ((JArray)description["difference"]["additional"]).Count > 20)
                    {
                        description["difference"]["missing"] = "Too Many Records";
                        description["difference"]["additional"] = "Too Many Records";

                    }
                    ((JArray) errors["dataSize"]).Add(description);
                    continue;
                }

                if(expectedTable.Select(row=> row.Count()).Min() != actualTable.Select(row => row.Count()).Min())
                {
                    foreach(var column in (JObject)expectedTable[0])
                    {
                        if(column.Key == "Row")
                        {
                            continue;
                        }
                        if(!((JObject)actualTable[0]).ContainsKey(column.Key))
                        {
                            description["message"] = $"the System is missing expected Column [{column.Key}] at table {table.Key}";
                            ((JArray)errors["missingColumn"]).Add(description.DeepClone());
                        }
                       
                    }
                    
                    continue;
                }

                //loop through each row in the table from the source of truth manual
                foreach ((JObject value, int index) expectedRow in expectedTable.Select((value,index) => (value, index)))
                {
                    //in every iteraiton, load the row content as part of description in case there's an error
                    description["row"]= expectedRow.value.DeepClone();
                    
                    //load the corresponding row from the system
                    var actualRow = (JObject)actualTable[expectedRow.index];


                    //iterate through each column on the row from the source of truth manual
                    foreach(var column in expectedRow.value)
                    {
                        //There is an additional row in the source of truth manual denoting the row number in the csv file.
                        //so we will ignore this row
                        if (column.Key == "Row")
                        {
                            continue;
                        }
                        
                        //check if the column exists in the system
                        if (!actualRow.ContainsKey(column.Key))
                        {
                            
                            description["message"] = $"the System is missing expected Column [{column.Key}] at row {expectedRow.value["Row"]} at table {table.Key}";
                            ((JArray)errors["missingColumn"]).Add(description.DeepClone());
                            continue;
                            
                        }

                        //get the column value from both manuals
                        var expectedValue = column.Value.ToString();
                        var actualValue = actualRow[column.Key];


                        //to be used if percentage was a decimal

                        /*if(expectedValue.Contains("%"))
                        {
                            Decimal expectedValueDec = Decimal.Parse(expectedValue.Replace("%", "").Trim())/100;

                            try
                            {
                                if (expectedValueDec != actualValue.ToObject<Decimal>())
                                {
                                    description["message"] = $" percent - the System is missing expected value {expectedValueDec} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                    ((JArray)errors["incorrectValue"]).Add(description);
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing actual percentage from the system: ${actualValue} percent - the System is missing expected value {expectedValueDec} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                                            
                                ((JArray)errors["incorrectValue"]).Add(description);
                            }
                        }*/

                        //to be used if percentage is a string
                        if (expectedValue.Contains("%"))
                        {
                            //sometimes percentages are entered as 25 % we will ignore the space in between
                            var actualValuePercent = actualValue.ToString().Replace(" %", "%");


                            if (expectedValue != actualValuePercent)
                            {
                                description["message"] = $" percentage - the System is missing expected value {expectedValue} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValuePercent ?? "NULL"}";
                                ((JArray)errors["incorrectValue"]).Add(description.DeepClone());
                            }
                        }
                        //compare if the value is integer type
                        else if (int.TryParse(expectedValue, out int expectedValueInt))
                        {
                            try
                            {
                                if (actualValue == null || expectedValueInt != actualValue?.ToObject<int>())
                                {
                                    description["message"] = $" int - the System is missing expected value {expectedValueInt} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue ?? "NULL"}";
                                    ((JArray)errors["incorrectValue"]).Add(description.DeepClone());
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing integer value from the system: {actualValue} the System is missing expected value {expectedValueInt} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key}";
                                ((JArray)errors["incorrectValue"]).Add(description);
                            }
                        }
                        //compare if the value is decimal type
                        else if (decimal.TryParse(expectedValue, out decimal expectedValueDec))
                        {
                            try
                            {
                                if (expectedValueDec != actualValue.ToObject<decimal>())
                                {
                                    description["message"] = $" decimal - the System is missing expected value {expectedValueDec} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue ?? "NULL"}";
                                    ((JArray)errors["incorrectValue"]).Add(description.DeepClone());
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing decimal value from the system: {actualValue} the System is missing expected value {expectedValueDec} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key}";
                                ((JArray)errors["incorrectValue"]).Add(description);
                            }
                        }
                        //compare if the value is currency type
                        /*else if (expectedValue.Contains('$'))
                        {
                            try
                            {
                                if (decimal.Parse(expectedValue.Replace("$", string.Empty)) != actualValue.ToObject<decimal>())
                                {
                                    description["message"] = $"money - the System is missing expected value {decimal.Parse(expectedValue.Replace("$", string.Empty))} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                    ((JArray)errors["incorrectValue"]).Add(description.DeepClone());
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing currency value from the system: {actualValue} - the System is missing expected value {decimal.Parse(expectedValue.Replace("$", string.Empty))} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                ((JArray)errors["incorrectValue"]).Add(description);
                            }
                        }*/
                        /*//compare if the value + or infinite 
                        else if(expectedValue =="+" )
                        {
                            try
                            {
                                if (int.MaxValue != actualValue.ToObject<int>())
                                {
                                    description["message"] = $" max value - the System is missing expected value {int.MaxValue} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing '+' value from the system: {actualValue} - the System is missing expected value {int.MaxValue}(int.MaxValue) at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                ((JArray)errors["incorrectValue"]).Add(description);
                            }
                        }*/
                        //general comparison - Compares plain strings
                        else if(expectedValue != actualValue.ToString())
                        {
                            
                            description["message"] = $" general - the System is missing expected value {expectedValue} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                            ((JArray)errors["incorrectValue"]).Add(description.DeepClone());
                        }
                     
                    }

                }
            }

        }
        [Then(@"there shouldn't be any differences")]
        public void ThenThereShouldnTBeAnyDifferences()
        {
            //since errors are stored by catogories. we have to check each category.
            //if any category contains errors. this test fails
            bool error = false;

            var count = new JObject();
            foreach (var category in errors)
            {
                var catCount = category.Value.Count();
                if (catCount > 0)
                {
                    count.Add(category.Key+ " - Type Errors Count", catCount);
                    error = true;
                    
                }
            }
            if (error)
            {
                errors.Add("count", count);
                File.WriteAllText(testResultDir + "errors.json", errors.ToString());
                //throw Functions.handleFailure(errors.ToString(), new Exception());
                throw new Exception($@"Please see errors at {testResultDir}errors.json");
            }
        }



        private IEnumerable<JObject> GetTable(long tableId)
        {
            var columns = SQL.executeQuery($@"SELECT AttributeName, AttributeColumn
                                              FROM [rating].ReferenceTableMap where ReferenceTableId={tableId};");

            var sortOrderColumnRow = columns.Find(it => ((String)it["AttributeName"]).Contains("SortOrder"));


            StringBuilder attrQuery = new StringBuilder();

            attrQuery.Append($@"SELECT *
                                FROM[rating].[ReferenceTableAttribute] TableAttributes
                                where TableAttributes.ReferenceTableId ={tableId} ");

            //attrQuery.Append(sortOrderColumnRow == null ? "" : $" ORDER BY {sortOrderColumnRow["AttributeColumn"]} ");
            attrQuery.Append(';');
            var attributes = SQL.executeQuery(attrQuery.ToString());

           
            foreach(var row in attributes)
            {
                var rowObj = new JObject();

                foreach (var column in columns)
                {
                    try
                    {
                        var columnValue = row[column["AttributeColumn"]];

                        //for corrupt duplicate columns
                        /*if(rowObj.ContainsKey((String)column["AttributeName"]))
                        {
                            column["AttributeName"] = column["AttributeName"] + " [DUPLICATE]";
                        }*/

                        rowObj.Add((String)column["AttributeName"], (columnValue is DBNull? "": columnValue) ?? "");
                    }
                    catch(Exception ex)
                    {
                        //for corrupt duplicate columns
/*                        var knownErrors = new List<string>()
                        {
                        
                        };
                        if(knownErrors.Contains(column["AttributeName"]))
                        {
                            continue;
                        }*/
                        Log.Debug("Row-> "+JObject.FromObject(row));
                        Log.Debug("column-> "+column["AttributeColumn"]);
                        Log.Debug($"table ID-> : {tableId} Att Name: {column["AttributeName"]} value:{row[column["AttributeColumn"]]} ");
                        throw ex;
                    }
                }

                yield return rowObj;

            }

        }

        private void sortTablesIdentically(ref JArray expectedTable, ref JArray actualTable, string tableKey)
        {
            //because we want to sort but leave data untouched,
            //we will make a copy of each table, this new copy will be formatted
            // for example any '+' will be converted to int.MaxInt
            // any non-special value in each table will be converted to string
            var expectedIndexedTable = FormatTable((JArray)expectedTable.DeepClone());
            var actualIndexedTable = FormatTable((JArray)actualTable.DeepClone());

            // out of both tables find the row with the least amount of columns
            int failSafeColCount = actualIndexedTable.Count == 0? 0: actualIndexedTable.Select(row => row.Count()).Min();
            List<string> columnsToOrderBy = ((JObject)actualIndexedTable[0]).Properties().Select(it => it.Name).OrderBy(self => self).ToList();



            //make sure our fail safe is in accordance to both tables
            if (expectedIndexedTable.Select(row => row.Count()).Min() is int count && count < failSafeColCount)
            {
                failSafeColCount = count;
                columnsToOrderBy = ((JObject)expectedIndexedTable[0]).Properties().Select(it => it.Name).OrderBy(self => self).ToList();

            }

            //remove Row & Index columns
            failSafeColCount -= columnsToOrderBy.RemoveAll(col => col == "Row" || col == "index");


            //Order each table by the first Col - In order to do this we also have to order each column by it's name
            IOrderedEnumerable<JToken> expectedTableOrdered = expectedIndexedTable.OrderBy(row => ((JObject)row)[columnsToOrderBy[0] ?? ""]);
            IOrderedEnumerable<JToken> actualTableOrdered = actualIndexedTable.OrderBy(row => ((JObject)row)[columnsToOrderBy[0]] ?? "");


            //keep ordering each table until we hit that failSafe count, this will ensure we only sort as many columns as possible without failure
            for (int i = 1; i < failSafeColCount; i++)
            {
                var loopIndex = i;
                actualTableOrdered = actualTableOrdered.ThenBy(row => ((JObject)row)[columnsToOrderBy[loopIndex]]?.ToString()?? "");
                var loopIndex2 = i;
                expectedTableOrdered = expectedTableOrdered.ThenBy(row => ((JObject)row)[columnsToOrderBy[loopIndex2]]?.ToString() ?? "");
            }

            
            actualIndexedTable = JArray.FromObject(actualTableOrdered.ToList());
            expectedIndexedTable = JArray.FromObject(expectedTableOrdered.ToList());


            //now that we have ordered the temporary tables
            //the index property added will tell us the new positions
            //this function will order by whatever the order of index provided is
            ReOrderTableUsingIndexOrder(ref actualTable, actualIndexedTable.Select(row => (int)row["index"]));
            ReOrderTableUsingIndexOrder(ref expectedTable, expectedIndexedTable.Select(row => (int)row["index"]));

            //
            //debugging purposes
            //
            Directory.CreateDirectory(testResultDir + $@"\Sorted\actualTable");
            Directory.CreateDirectory(testResultDir + $@"\Sorted\expectedTable");

            File.WriteAllText(testResultDir + $@"\Sorted\actualTable\{tableKey}.json", actualTable.ToString());
            File.WriteAllText(testResultDir + $@"\Sorted\expectedTable\{tableKey}.json", expectedTable.ToString());
        }


        private JArray FormatTable(JArray table)
        {
            int i = 0;
            foreach(JObject row in table)
            {
                foreach (var column in row)
                {
                    var value = column.Value.ToString();
                    if (value == "+")
                    {
                        row[column.Key] = int.MaxValue;
                    }
                    else if(value.Contains('$'))
                    {
                        decimal decVal= decimal.Parse(string.Join("", value.Where(c => Char.IsDigit(c))));
                        
                        var decString = decVal.ToString("0.00000000");
                        decString = decString.Remove(decString.Length - 6);

                        row[column.Key] = decString;
                    }
                    else if (decimal.TryParse(value, out decimal decVal))
                    {
                        var decString=  decVal.ToString("0.00000000");
                        decString = decString.Remove(decString.Length - 6);

                        row[column.Key] = decString;
                    }
                    else
                    {
                        row[column.Key] = column.Value.ToString();
                    }

                    if(row[column.Key] ==null)
                    {
                        throw new ArgumentNullException();
                    }
                }
                row.Add("index", i);
                i++;
            }
            return table;
        }

        private void ReOrderTableUsingIndexOrder(ref JArray table, IEnumerable<int> newIndexOrder)
        {
            if(table.Count != newIndexOrder.Count())
            {
                throw Functions.handleFailure($"Table and Index count were not identical table {table.Count()} index: {newIndexOrder.Count()}");
            }

            JArray resultingTable = new JArray();
            foreach (int index in newIndexOrder)
            {
                resultingTable.Add(table[index]);
            }
            table= resultingTable;
        }


        private static JObject PersistedData = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine($"{Source.Driver.Setup.SourceDir}", @"StepDefinition\Rating\persistedData.json")).ReadToEnd());
    }
}
