using ApolloQA.Source.Helpers;
using DynamicExpresso;
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
                //ignoring any json or temps files in the directory
                if (file.Name.Contains(".json") || file.Name.Contains("~"))
                {
                    continue;
                }
                var tableName = file.Name.Substring(0, file.Name.LastIndexOf('.'));

                //ignoring algorithm tables
                if (tableName.IndexOf('.') == -1 )
                {
                    continue;
                }
                //ignoring deleted tables
                if (PersistedData["All"]["deleteTables"].ToObject<List<string>>().Contains(tableName))
                {
                    continue;
                }

                var tableNameNoAlgorithm = tableName.Split(".")[1];
                //ignoring deleted tables
                

                    manual.Add(tableName, new JArray());
              
                var persistedRows = (JArray)PersistedData?["All"]?["rows"]?[tableName];
               
                persistedRows?.Merge(PersistedData?[state]?[tableName]?["rows"] ?? new JArray());


                var persistedColumns = (JObject)PersistedData["All"]["columns"].DeepClone();

                //Log.Debug($"table name: {tableName}");
                persistedColumns.Merge((JObject)PersistedData?[state]?[tableName]?["columns"]);


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

                    var deleteConditions = (JArray)PersistedData?["All"]?["rows"]?["deleteConditions"]?[tableNameNoAlgorithm];
                    if (deleteConditions != null && TrueIfAnyCondition(tableName, row.value, deleteConditions))
                    {
                        //Log.Debug($"persist delete for a condition {state}, {tableName}");
                        continue;
                    }

                    if (persistedRows != null)
                    {
                        var persistedRow = persistedRows.FirstOrDefault(it => (String)it["Row"] == rowNumber);

                        if (persistedRow!=null)
                        {
                            if (persistedRow?["delete"]?.ToObject<bool>() ?? false)
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

                var additionalLimits = (JArray)PersistedData?["All"]?["limits"]?[tableNameNoAlgorithm]?["additionalLimits"];
                if(additionalLimits != null)
                {
                    var manualTable = (JArray)manual[tableName];

                    var resultingTable = (JArray)manualTable.DeepClone();

                    var limitNames = new string[3] {"Combined Single Limit", "Limit", "Property Damage Limit" };
/*                    Log.Debug(manualTable[0]);
                    Log.Debug(tableNameNoAlgorithm);
                    Log.Debug(tableName);*/
                    var limitName = manualTable[0].ToObject<Dictionary<string, string>>().Keys.First(key => limitNames.Contains(key));

                  


                    var firstLimitValue = ((JObject)manualTable[0])[limitName].ToString();

                    var valueSetsToGenerateFor = ((JArray)manualTable).Where(row => row[limitName].ToString() == firstLimitValue);

                    var columnsToGenerateFor = ((JObject)manualTable[0]).Properties().Select(prop => prop.Name);

                    columnsToGenerateFor = columnsToGenerateFor.Where(columnName => columnName != "Row" && !columnName.ToLower().Contains("factor") && columnName != limitName);

                    var currentLastRow = manualTable.Select(it => it["Row"].ToObject<int>()).Max();

                    var factorColumnName = ((JObject)manualTable[0]).Properties().First(it => it.Name.Contains("Factor")).Name;

                    var factor = PersistedData?["All"]["limits"][tableNameNoAlgorithm]?["factor"]?.ToString();

                   

                    foreach (JObject valueSet in valueSetsToGenerateFor)
                    {
                        foreach(var limitValue in additionalLimits)
                        {
                            generateRowForLimit(ref resultingTable, ref currentLastRow, valueSet, columnsToGenerateFor, limitName, limitValue.ToObject<int>(), factorColumnName, factor);
                        }

                    }
                    if(!valueSetsToGenerateFor.Any())
                    {
                        foreach (var limitValue in additionalLimits)
                        {
                            generateRowForLimit(ref resultingTable, ref currentLastRow, (JObject)manualTable[0], columnsToGenerateFor, limitName, limitValue.ToObject<int>(), factorColumnName, factor);
                        }
                    }
                    //Log.Debug($"addnl limits {tableName}");
                    manual[tableName] = resultingTable;
                }

            }

            File.WriteAllText(testResultDir + "ParsedRatingTables.json", manual.ToString());

        }
        private bool TrueIfAnyCondition(string tableName, Dictionary<string, string> row, JArray conditions)
        {
            Interpreter interpreter = new Interpreter();
            interpreter.SetVariable("row", row);
            interpreter.SetVariable("tableName", tableName);

            foreach (string condition in conditions)
            {
                try
                {
                    var result = (bool)interpreter.Eval(condition);
                    if (result)
                    {
                        return true;
                    }
                }
                catch(Exception ex)
                {
                    Log.Error(tableName);
                    Log.Error(row);
                    throw ex;
                }
               
            }
            return false;
        }
        private void generateRowForLimit(ref JArray table, ref int currentLastRow, JObject valueSetToGenerateFor, IEnumerable<string> columnsToGenerateFor, string limitName, int limitValue, string factorColumnName, string factor)
        {
            decimal parsedFactor = 1;
            if (factor.ToLower() == "max")
            {
                var valueSetToGenerateFor_NoExtraColumns = JObject.FromObject(valueSetToGenerateFor.ToObject<Dictionary<string, string>>().Where(it => columnsToGenerateFor.Contains(it.Key)).ToDictionary(x => x.Key, x => x.Value));

                List<JObject> rowsForValueSet = new List<JObject>();

                foreach (JObject row in table)
                {
                    var currentValueSet = JObject.FromObject(row.ToObject<Dictionary<string, string>>().Where(it => columnsToGenerateFor.Contains(it.Key)).ToDictionary(x => x.Key, x => x.Value));

                    if (JToken.DeepEquals(valueSetToGenerateFor_NoExtraColumns, currentValueSet))
                    {
                        rowsForValueSet.Add(row);
                    }
                }


                var maxLimit = 0;


                foreach (var row in rowsForValueSet)
                {
                    var rowLimit = int.Parse(string.Join("", row[limitName].ToString().Where(c => char.IsDigit(c))));
                    if(maxLimit < rowLimit)
                    {
                        maxLimit = rowLimit;
                        parsedFactor = row[factorColumnName].ToObject<decimal>();
                    }
                } 


            }

            var newlyGeneratedRow = (JObject)valueSetToGenerateFor.DeepClone();
            newlyGeneratedRow[limitName] = limitValue;
            newlyGeneratedRow[factorColumnName] = parsedFactor;
            newlyGeneratedRow["Row"] = currentLastRow;
            table.Add(newlyGeneratedRow);
            currentLastRow++;
        }

        [Given(@"(.*) csv is parsed into json object")]
        public void GivenCsvIsParsedIntoJsonObject(string state)
        {
            this.state = state;

            var RatingTables = Functions.parseCSV(Path.Combine(Source.Driver.Setup.SourceDir, @$"Data\RatingManual\csv\{state}.csv"));


            if (!Directory.Exists(testResultDir))
            {
                Directory.CreateDirectory(testResultDir);
            }

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
        [Given(@"tables are loaded from the system for date (.*)")]
        public void ThenTablesAreParsedIntoJsonFormat(string date)
        {
            var dateTime = DateTime.Parse(date);
            var tables = SQL.executeQuery($@"SELECT RatingTable.Id, RatingTable.[Name], StateProv.Code, RatingTable.TimeFrom, RatingTable.TimeTo
                                            FROM [rating].[ReferenceTable] RatingTable
                                            LEFT JOIN [rating].[ReferenceTableStateProvince] RatingTableState on RatingTable.Id = RatingTableState.ReferenceTableId
                                            LEFT JOIN [location].[StateProvince] StateProv on RatingTableState.StateProvinceId = StateProv.Id
                                            WHERE LineId =7 AND 
                                            CarrierPartyId = 4 AND 
                                            StateProv.Code = '{state}' AND
                                            ('{dateTime.ToShortDateString()}' BETWEEN RatingTable.TimeFrom AND RatingTable.TimeTo)
                                            GROUP BY  RatingTable.Id, RatingTable.[Name], StateProv.Code, RatingTable.TimeFrom,RatingTable.TimeTo
                                            ;");
            //Task.Factory.StartNew(() => Parallel.ForEach(tables, table => ActualManual.Add(table["Name"], JArray.FromObject(GetTable((int)table["Id"]))))).Wait();

            foreach (var table in tables)
            {
               /* //Richard taking care of this bug, there are Dupplicate DR01 & DT.2
                if (ActualManual.ContainsKey(table["Name"]) && (table["Name"]== "DR.2" || table["Name"] == "DT.2"))
                {
                    continue;
                }*/
                ActualManual.Add(table["Name"], JArray.FromObject(GetTable((long)table["Id"], table["Name"])));
            }


        }

        private JObject errors = new JObject() { { "dataSize", new JObject() }, { "missingTable", new JArray() }, { "missingColumn", new JObject() }, { "incorrectValue", new JObject() } };


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

                //check if the table has any content
                if (actualTable.Count()==0)
                {
                    description["message"] = $"the System is missing content in table: {table.Key}";
                    ((JArray)errors["missingTable"]).Add(description);

                    continue;
                }

                //
                // We want to sort both tables to make sure we're comparing correctly
                //
                sortTablesIdentically(ref expectedTable, ref actualTable, table.Key);

                /*                if (expectedTable.Select(row => row.Count()).Min() -1 != actualTable.Select(row => row.Count()).Min())
                                {
                */
                bool missingColumn = false;
                foreach (var column in (JObject)expectedTable[0])
                {
                    if (column.Key == "Row")
                    {
                        continue;
                    }
                    if (!((JObject)actualTable[0]).ContainsKey(column.Key))
                    {
                        description["message"] = $"the System is missing expected Column [{column.Key}] at table {table.Key}";
                        addError("missingColumn", table.Key, description.DeepClone());
                        missingColumn = true;
                    }

                }
                if(missingColumn)
                {
                    continue;
                }

                   /* continue;
                }*/

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



                    JArray differenc = this.IdentifyDifferences(expectedTable, actualTable , table.Key);
                    description["difference"] = new JObject() { { "missing", new JArray() }, { "additional", new JArray() } };

                    if(actualTable.Count()<expectedTable.Count())
                    {
                        description["difference"]["missing"] = differenc;

                    }
                    else
                    {
                        description["difference"]["additional"] = differenc;

                    }

                    /* var differences = JsonDifferentiator.Differentiate(actualTable, expectedTable);
                     //loop through the difference and identify missing or additional rows
                     foreach (JObject difference in differences)
                     {
                         if(difference.Properties().Where(it => it.Name.Contains('-')).Count() > 1)
                         {
                             ((JArray)description["difference"]["additional"]).Add(difference);

                         }
                         if (difference.Properties().Where(it => it.Name.Contains('+')).Count() > 1)
                         {
                             ((JArray)description["difference"]["missing"]).Add(difference);

                         }
                     }*/

                    description["message"] = $"Expected row Count: {expectedTable.Count()}     Actual row Count: {actualTable.Count()}";

                    if (differenc.Count > 100)
                    {
                        description["difference"]["missing"] = "Too Many Records";
                        description["difference"]["additional"] = "Too Many Records";

                    }
                    addError("dataSize", table.Key, description.DeepClone());

                    continue;
                }

               

                //loop through each row in the table from the source of truth manual
                foreach ((JObject value, int index) expectedRow in expectedTable.Select((value,index) => (value, index)))
                {
                    //in every iteraiton, load the row content as part of description in case there's an error
                    description["ExpectedRow"]= expectedRow.value.DeepClone();
                    
                    //load the corresponding row from the system
                    var actualRow = (JObject)actualTable[expectedRow.index];

                    description["ActualRow"] = actualRow.DeepClone();

                    //iterate through each column on the row from the source of truth manual
                    foreach (var column in expectedRow.value)
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
                            addError("missingColumn", table.Key, description.DeepClone());

                            continue;
                            
                        }

                        //get the column value from both manuals
                        var expectedValue = column.Value.ToString();
                        var actualValue = actualRow[column.Key];


                        //to be used if percentage was a decimal

                        if (expectedValue.Contains("%") && expectedValue.Where(ch=> Char.IsLetter(ch)).Count()==0 )
                        {
                            Decimal expectedValueDec = Decimal.Parse(expectedValue.Replace("%", "").Trim()) / 100;

                            try
                            {
                                if (expectedValueDec != actualValue.ToObject<Decimal>())
                                {
                                    description["message"] = $" percent - the System is missing expected value {expectedValueDec} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                    addError("incorrectValue", table.Key, description.DeepClone());
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing actual percentage from the system: ${actualValue} percent - the System is missing expected value {expectedValueDec} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";

                                addError("incorrectValue", table.Key, description.DeepClone());
                            }
                        }

                        //to be used if percentage is a string
                        /*if (expectedValue.Contains("%"))
                        {
                            //sometimes percentages are entered as 25 % we will ignore the space in between
                            var actualValuePercent = actualValue.ToString().Replace(" %", "%");


                            if (expectedValue != actualValuePercent)
                            {
                                description["message"] = $" percentage - the System is missing expected value {expectedValue} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValuePercent ?? "NULL"}";
                                addError("incorrectValue", table.Key, description.DeepClone());
                            }
                        }*/
                        //compare if the value is integer type
                        else if (int.TryParse(expectedValue, out int expectedValueInt))
                        {
                            try
                            {
                                if (actualValue == null || expectedValueInt != actualValue?.ToObject<int>())
                                {
                                    description["message"] = $" int - the System is missing expected value {expectedValueInt} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue ?? "NULL"}";
                                    addError("incorrectValue", table.Key, description.DeepClone());
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing integer value from the system: {actualValue} the System is missing expected value {expectedValueInt} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key}";
                                addError("incorrectValue", table.Key, description.DeepClone());
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
                                    addError("incorrectValue", table.Key, description.DeepClone());
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing decimal value from the system: {actualValue} the System is missing expected value {expectedValueDec} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key}";
                                addError("incorrectValue", table.Key, description.DeepClone());
                            }
                        }
                        //compare if the value is currency type
                        else if (expectedValue.Contains('$'))
                        {
                            try
                            {
                                if (decimal.Parse(expectedValue.Replace("$", string.Empty)) != actualValue.ToObject<decimal>())
                                {
                                    description["message"] = $"money - the System is missing expected value {decimal.Parse(expectedValue.Replace("$", string.Empty))} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                    addError("incorrectValue", table.Key, description.DeepClone());
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing currency value from the system: {actualValue} - the System is missing expected value {decimal.Parse(expectedValue.Replace("$", string.Empty))} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                addError("incorrectValue", table.Key, description.DeepClone());
                            }
                        }
                        //compare if the value + or infinite 
                        else if (expectedValue == "+")
                        {
                            try
                            {
                                List<string> correctMax = new List<string>() { "+", int.MaxValue.ToString(), "9999999", "9999998" };
                                if (!correctMax.Contains(actualValue.ToObject<string>()))
                                {
                                    description["message"] = $" max value - the System is missing expected value {int.MaxValue} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                }
                            }
                            catch
                            {
                                description["message"] = $@" error parsing '+' value from the system: {actualValue} - the System is missing expected value {int.MaxValue}(int.MaxValue) at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                addError("incorrectValue", table.Key, description.DeepClone());
                            }
                        }
                        else if (expectedValue.ToLower() == "yes" || expectedValue.ToLower() == "no")
                        {
                            var expectedYes = new List<string> { "Yes","yes", "true", "True" };
                            var expectedNo = new List<string> { "No", "no", "false", "False" };

                            if(expectedValue.ToLower() == "yes" && !expectedYes.Contains(actualValue.ToString()))
                            {
                                description["message"] = $" boolean - the System is one of  expected value {string.Join(", ", expectedYes)} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                addError("incorrectValue", table.Key, description.DeepClone());

                            }
                            if (expectedValue == "no" && !expectedNo.Contains(actualValue.ToString()))
                            {
                                description["message"] = $" boolean - the System is one of expected value {string.Join(", ", expectedNo)} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                                addError("incorrectValue", table.Key, description.DeepClone());

                            }

                        }
                        else if(string.IsNullOrEmpty(expectedValue))
                        {
                            if(actualValue.ToString() != "0")
                            {
                                description["message"] = $" empty - the System is missing expected value 0 at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";

                            }
                        }
                        //general comparison - Compares plain strings
                        else if(expectedValue != actualValue.ToString())
                        {
                            
                            description["message"] = $" general - the System is missing expected value {expectedValue} at Column {column.Key}  at row {expectedRow.value["Row"]} at table {table.Key} \n Actual Value: {actualValue}";
                            addError("incorrectValue", table.Key, description.DeepClone());
                        }
                     
                    }

                }
            }

        }

        private void addError(string type, string tableName, JToken description)
        {
           if(! ((JObject)errors[type]).ContainsKey(tableName))
           {
                ((JObject)errors[type]).Add(tableName, new JArray());
           }
           ((JArray)errors[type][tableName]).Add(description);
        }

        [Then(@"there shouldn't be any differences")]
        public void ThenThereShouldnTBeAnyDifferences()
        {
            File.WriteAllText(testResultDir + "SystemRatingTables.json", ActualManual.ToString());

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



        private IEnumerable<JObject> GetTable(long tableId, string tableName)
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
                        var columnName = (String)column["AttributeName"];
                        if (columnName.ToLower().Contains("sortorder"))
                        {
                            continue;
                        }

                        rowObj.Add(columnName, (columnValue is DBNull? "": columnValue) ?? "");
                    }
                    catch(Exception ex)
                    {

                        Log.Debug("Row-> "+JObject.FromObject(row));
                        Log.Debug("column-> "+column["AttributeColumn"]);
                        Log.Debug($"table ID-> : {tableId} Att Name: {column["AttributeName"]} value:{row[column["AttributeColumn"]]} ");
                        throw ex;
                    }
                }
                var deleteConditions = PersistedData["All"]["rows"]["deleteConditionsFromSystem"]?[tableName.Split('.')[1]];
                if (deleteConditions != null && TrueIfAnyCondition(tableName, rowObj.ToObject<Dictionary<string, string>>(), (JArray)deleteConditions))
                {
                    continue;
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
            List<string> columnsToOrderBy;

            try
            {
                columnsToOrderBy = ((JObject)actualIndexedTable[0]).Properties().Select(it => it.Name).OrderBy(self => self).ToList();
            }
            catch(Exception ex)
            {
                Log.Error($"{tableKey} failed to order content: {actualIndexedTable}");
                throw ex;
            }



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

            File.WriteAllText(testResultDir + $@"\Sorted\actualTable\{tableKey}.json", actualIndexedTable.ToString());
            File.WriteAllText(testResultDir + $@"\Sorted\expectedTable\{tableKey}.json", expectedIndexedTable.ToString());
        }


        private JArray FormatTable(JArray table)
        {
            int i = 0;
            foreach(JObject row in table)
            {
                foreach (var column in row)
                {
                    var value = column.Value.ToString();
                    if (value == "+" || value == "9999999" || value == "9999998")
                    {
                        row[column.Key] = int.MaxValue;
                    }
                    else if(value.Contains('$'))
                    {
                        int intVal= int.Parse(string.Join("", value.Where(c => Char.IsDigit(c))));

                        var intString = intVal.ToString();

                        row[column.Key] = intString;
                    }
                    else if (int.TryParse(value.Replace(",", ""), out int intVal))
                    {
                        row[column.Key] = intVal.ToString();
                    }
                    else if (decimal.TryParse(value, out decimal decVal))
                    {
                        var decString=  decVal.ToString("0.0000");
                        //decString = decString.Remove(decString.Length - 4);

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

        public JArray IdentifyDifferences(JArray expectedTable, JArray actualTable, string tableKey)
        {
           //sortTablesIdentically(ref expectedTable, ref actualTable, tableKey);


           var expectedIndexedTable = FormatTable((JArray)expectedTable.DeepClone());
           var actualIndexedTable = FormatTable((JArray)actualTable.DeepClone());

            // out of both tables find the row with the least amount of columns
            int failSafeColCount = actualIndexedTable.Count == 0 ? 0 : actualIndexedTable.Select(row => row.Count()).Min();
            List<string> columnNames;

            try
            {
                columnNames = ((JObject)actualIndexedTable[0]).Properties().Select(it => it.Name).OrderBy(self => self).ToList();
            }
            catch (Exception ex)
            {
                Log.Error($"{tableKey} failed to order content: {actualIndexedTable}");
                throw ex;
            }



            //make sure our fail safe is in accordance to both tables
            if (expectedIndexedTable.Select(row => row.Count()).Min() is int count && count < failSafeColCount)
            {
                failSafeColCount = count;
                columnNames = ((JObject)expectedIndexedTable[0]).Properties().Select(it => it.Name).OrderBy(self => self).ToList();

            }

            //remove Row & Index columns
            failSafeColCount -= columnNames.RemoveAll(col => col == "Row" || col == "index");



            JArray missingRows = new JArray();
            if (expectedIndexedTable.Count() > actualIndexedTable.Count())
            {
                foreach(var expectedRow in expectedIndexedTable)
                {
                    JObject matchingRow=null;
                    foreach(var actualRow in actualIndexedTable)
                    {
                        bool match = true;

                        int failSafeColumn = Math.Min(expectedRow.Count(), actualRow.Count());
                        for (int i = 0; i < failSafeColCount; i++ )
                        {
                            var columnName = columnNames[i];
                            var actualValue = actualRow[columnName].ToString();
                            try
                            {
                                if (expectedRow[columnName].ToString() != actualValue)
                                {
                                    match = false;
                                    break;
                                }
                            }
                            catch(Exception ex)
                            {
                                Log.Error($"{tableKey} - error comparing actual: \n{actualRow} \n--- expected: \n{expectedRow}");
                                throw ex;
                            }
                            
                        }
                        if(match)
                        {
                            matchingRow = (JObject)actualRow;
                            break;
                        }
                    }

                    if(matchingRow == null)
                    {
                        missingRows.Add(expectedRow);   
                    }
                   
                }

                return missingRows;
            }

            JArray additionalRows = new JArray();

            foreach (var actualRow in actualIndexedTable)
            {
                JObject matchingRow = null;
                foreach (var expectedRow in expectedIndexedTable)
                {
                    bool match = true;

                    int failSafeColumn = Math.Min(expectedRow.Count(), actualRow.Count());
                    for (int i = 0; i < failSafeColCount; i++)
                    {
                        var columnName = columnNames[i];
                        var expectedValue = expectedRow[columnName].ToString();
                        try
                        {
                            if (actualRow[columnName].ToString() != expectedValue)
                            {
                                match = false;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error($"{tableKey} - error comparing actual: \n{actualRow} \n--- expected: \n{expectedRow}");
                            throw ex;
                        }

                    }
                    if (match)
                    {
                        matchingRow = (JObject)actualRow;
                        break;
                    }
                }

                if (matchingRow == null)
                {
                    additionalRows.Add(actualRow);
                }

            }
            return additionalRows;
            
        }

        /**
         *   There are certain Data that differs from both ends, instead of manipulating the data itself every time there is a new load. We are doing it on runtime
         *   
         *   note: delete means deleted from the object at runtime for comparison purposes!
         *   
         *  0.) State first property of the object or All which applies country wide
         *      1.) deleteTables: tables to be deleted from the PDF(expected) manual during runtime
         *      2.) columns: Key= represents columns to be replaced; Value= represents correct column name
         *      3.) rows: to be applied to rows
         *            3.1.) deleteCondition: set of conditions that when meet for a row of the given table, is deleted form the PDF(expected) manual
         *                 3.1.1.) tableName: in which these conditions will be checked
         *            3.2.) deleteConditionsFromSystem: set of conditions that when meet for a row of the given table, is deleted form the actual Manual 
         *                 3.2.1.) tableName: in which these conditions will be checked
         *            3.3.) talbeName: name of the table in which the rows will be replaced 
         *                 3.3.1.) list of ros to be replaced, using the Row property to determine which position
         *                 
         *      4.) limits: limits to be added to the PDF(expected) manual during runtime
         *            4.1.) tableName: name of the table in which to add these limits
         *            4.2.) factor: factor to add to the Factor column for each of these limits (note: Max means add highest limit found in the table to each limit)
         *            4.3.) limitName: Name of the column that these will be added on (if there is more than one limit column)
         *            
         *
         *           
         */
        private static JObject PersistedData = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine($"{Source.Driver.Setup.SourceDir}", @"StepDefinition\Rating\persistedData.json")).ReadToEnd());
    }
}
