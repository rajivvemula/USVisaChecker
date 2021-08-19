using DynamicExpresso;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace ApolloQA.Data.Rating
{
    public class Engine
    {
        private static readonly dynamic Factors = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine($"{Source.Driver.Setup.SourceDir}","Data/Rating/Factors.json")).ReadToEnd());
        private static readonly dynamic KnownFields =  JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine($"{Source.Driver.Setup.SourceDir}", $"Data/Rating/KnownFields.json")).ReadToEnd());
        private static JObject PersistedData = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine($"{Source.Driver.Setup.SourceDir}", @"StepDefinition\Rating\persistedData.json")).ReadToEnd());
        private static JObject CoverageAlgorithms = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine($"{Source.Driver.Setup.SourceDir}", @"Data/Rating/CoverageAlgorithms.json")).ReadToEnd());

        /// <returns>
        /// Returns specified table from the Rating Manual
        /// </returns>
        public static List<Dictionary<String, String>> GetAlorithm(String tableName)
        {
            
            var table = Functions.parseExcel(Path.Combine(Source.Driver.Setup.SourceDir, @$"Data\RatingManual\Algorithms\{tableName}.xlsx")).ToList();

            return table;
        }
        public static IEnumerable<Dictionary<String, String>> GetTable(String tableName, string stateCode, string effectiveDate)
        {
            string whereClause = $@"WHERE LineId =7 AND 
                                    CarrierPartyId = 4 AND 
                                    StateProv.Code = '{stateCode}' AND
                                    ('{effectiveDate}' BETWEEN RatingTable.TimeFrom AND RatingTable.TimeTo) AND
                                    RatingTable.Name = '{tableName}'";

            var columns = SQL.executeQuery($@"SELECT tableColumn.AttributeName, tableColumn.AttributeColumn
                                            FROM [rating].[ReferenceTable] RatingTable
                                            LEFT JOIN [rating].[ReferenceTableStateProvince] RatingTableState on RatingTable.Id = RatingTableState.ReferenceTableId
                                            LEFT JOIN [location].[StateProvince] StateProv on RatingTableState.StateProvinceId = StateProv.Id
                                            LEFT JOIN [rating].ReferenceTableMap tableColumn on RatingTable.Id = tableColumn.ReferenceTableId
                                            {whereClause} 
                                            ;");

            var sortOrderColumnRow = columns.Find(it => ((String)it["AttributeName"]).Contains("SortOrder"));

            
            var attributes = SQL.executeQuery($@"SELECT TableAttributes.*
                                                FROM [rating].[ReferenceTable] RatingTable
                                                LEFT JOIN [rating].[ReferenceTableStateProvince] RatingTableState on RatingTable.Id = RatingTableState.ReferenceTableId
                                                LEFT JOIN [location].[StateProvince] StateProv on RatingTableState.StateProvinceId = StateProv.Id
                                                LEFT JOIN [rating].[ReferenceTableAttribute] TableAttributes on RatingTable.Id = TableAttributes.ReferenceTableId
                                                {whereClause} 
                                                ;");
            if(!columns.Any() || !attributes.Any())
            {
                throw new Exception("Table: "+ tableName + $" was not found for parameters: {whereClause}. ");
            }

            foreach (var row in attributes)
            {
                var rowDict = new Dictionary<string, string>();

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

                        rowDict.Add(columnName, (columnValue is DBNull ? "" : (columnValue is string ? columnValue : columnValue.ToString()) ) ?? "");
                    }
                    catch (Exception ex)
                    {

                        Log.Error("Row-> " + JObject.FromObject(row));
                        Log.Error("column-> " + column["AttributeColumn"]);
                        Log.Error($"table Name-> : {tableName} Att Name: {column["AttributeName"]} value:{row[column["AttributeColumn"]]} ");
                        throw ex;
                    }
                }

                yield return rowDict;

            }

        }
        public List<Dictionary<String, String>> getTable(String tableName)
        {
           if(!tableName.Contains('.'))
           {
                return GetAlorithm(tableName);
           }
           return GetTable(tableName, GoverningStateCode, this.EffectiveDate.ToString("d")).ToList();
        }

        /// <summary>
        ///  Interpreter used to evaluate strings of code <br/>
        ///  This Interpreter will be used dynamically changing it's variables to accomodate current context. <br/>
        ///  for example, Vehile will be set multiple times depending on current vehicle under rating. <br/>
        /// </summary>
        public readonly Interpreter interpreter;

        //properties public in order to be mentioned in the json files
        public readonly Entity.Quote root;

        public readonly string GoverningStateCode;
        public readonly DateTime EffectiveDate;

        /// <summary>
        /// Rating Engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// constructed with a root object which in the future could be a Policy or Quote. <br/><br/>
        /// <param name="CoverageCode"> To be removed in the future, (iteration through all policy coverages need to be implemented)</param>
        /// </summary>
        public Engine(Entity.Quote root)
        {
            this.root = root;
            this.GoverningStateCode = root.GoverningStateCode;
            this.EffectiveDate = root.GetCurrentRatableObject().TimeFrom;
            this.interpreter = new Interpreter();
            interpreter.Reference(typeof(JObject));
            interpreter.Reference(typeof(AlgorithmAssignment));
            interpreter.Reference(typeof(Entity.CoverageType.Limit));

            interpreter.SetVariable("root", this.root);

        }

        public List<JObject> latestResults; 

        /// <summary>
        /// Run the engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// </summary>
        public List<JObject> Run()
        {
            latestResults = new List<JObject>();

            foreach (var vehicle in root.GetVehicles())
            {
                //set Vehicle in context to the interpreter
                interpreter.SetVariable("Vehicle", vehicle);
                /*
                * This foreach finds coverage code depending on the coverages selected at the Quote before generating a policy
                */

                var limits = root.getLimits(vehicle);
                limits = limits.OrderBy(it => it.GetCoverageType().SortOrder);

                foreach (var limit in limits)
                {
                    var coverageType = limit.GetCoverageType();
                    Log.Debug($"Current Coverage: {coverageType.Name}"); 
                    
                    interpreter.SetVariable("Limit", limit);
                    AlgorithmAssignment algorithmAssignment = getAlgorithmAssignment(limit.GetCoverageType(), KnownField.GetKnownField("Class Code").Resolve(this).ToString());
                    interpreter.SetVariable("AlgorithmAssignment", algorithmAssignment);
                    string coverageCode = algorithmAssignment.CoverageCode;
/*                    if (string.IsNullOrWhiteSpace(coverageCode))
                    {
                        continue;
                    }*/

                    interpreter.SetVariable("CoverageCode", coverageCode);


                    var rateResults = new JObject() { { "CoverageCode", coverageCode }, { "CoverageName", coverageType.Name } };

                    loadResolvedAlgorithmFactors(coverageCode, vehicle, ref rateResults);
                    decimal premium = 0;

                    List<Dictionary<string,string>> algorithmFormula = getTable(coverageCode);
                    for (int i=0; i< algorithmFormula.Count(); i++)
                    {
                        var row = algorithmFormula[i];
                        string operation = row["Operation"];
                        string factorName = row["Rating Factor"];
                        JObject factor;

                        if (operation == "Round [0]")
                        {
                            premium = Math.Round(premium, 0);
                            continue;
                        }
                        else if (operation.Trim() == "=")
                        {
                            var _factor  = new Factor(factorName, new string[] { factorName }, new KnownField[0]);
                            _factor.displayOnly = true;
                            var _resolvable = _factor.GetResolvable(this);
                            _resolvable.Value = premium;
                            _resolvable.parsedValue = premium.ToString("C0");

                            if (((JObject)rateResults["Factors"]).ContainsKey(factorName))
                            {
                                ((JObject)rateResults["Factors"])[factorName] = JObject.FromObject(_resolvable);
                            }
                            else
                            {
                                ((JObject)rateResults["Factors"]).Add(factorName, JObject.FromObject(_resolvable));
                            }
                            continue;
                        }

                        try
                        {
                            if( ((JObject)rateResults["Factors"]).ContainsKey($"{coverageCode}.{factorName}"))
                            {
                                factor = (JObject)rateResults["Factors"][$"{coverageCode}.{factorName}"];

                            }
                            else
                            {
                                factor = (JObject)rateResults["Factors"][factorName];
                            }
                            if(factor == null)
                            {
                                throw new KeyNotFoundException($"Factor name: {factorName} was not found in {rateResults} ");
                            }

                        }
                        catch(Exception ex)
                        {
                            throw Functions.handleFailure($"couldn't find factor {factorName} in Factors.json");
                            
                        }

                        decimal factorValue;
                        try
                        {
                            factorValue = factor["Value"].ToObject<decimal>();
                        }
                        catch (Exception ex)
                        {
                            Log.Error($"Error parsing factor {factor?["Value"] ?? null} into decimal ");
                            throw ex;
                        }

                        if (string.IsNullOrWhiteSpace(operation))
                        {
                            premium += factorValue;
                        }
                        else if (operation.ToUpper() == "X")
                        {
                            premium = premium * factorValue;
                        }
                        else if (operation == "Maximum")
                        {
                            var rowNext = algorithmFormula[++i];
                            string factorNameNext = rowNext["Rating Factor"];
                            JObject factorNext;

                            try
                            {
                                if (((JObject)rateResults["Factors"]).ContainsKey($"{coverageCode}.{factorNameNext}"))
                                {
                                    factorNext = (JObject)rateResults["Factors"][$"{coverageCode}.{factorNameNext}"];

                                }
                                else
                                {
                                    factorNext = (JObject)rateResults["Factors"][factorNameNext];
                                }
                                if (factor == null)
                                {
                                    throw new KeyNotFoundException($"Factor name: {factorNameNext} was not found in {rateResults} ");
                                }

                                 
                            }
                            catch (Exception ex)
                            {
                                Log.Error($"couldn't find factor {factorNameNext} in rate results {rateResults}");
                                throw ex;
                            }
                            decimal factorValueNext;
                            try
                            {
                                factorValueNext = factorNext["Value"].ToObject<decimal>();
                            }
                            catch (Exception ex)
                            {
                                Log.Error($"Error parsing factor name: {factorNameNext} value: {factorNext?["Value"] ?? null} into decimal ");
                                throw ex;
                            }
                            premium += Math.Max(factorValue, factorValueNext);
                        }   
                       
                        else
                        {
                            throw new ArgumentException($"Operation: {operation} is not being handled in Data.Rating.Engine.Run()");
                        }

                        factor.Add("currentPremium", premium);

                    }

                    rateResults.Add("TotalPremium", premium);
                    rateResults.Add("Vehicle", JObject.FromObject(vehicle.GetProperties()));
                    latestResults.Add(rateResults);
                } 
            }

            return latestResults;
        }




        /// <summary>
        /// Uses the source in DataFiles/Factors/KnownFields.json to set the specified value <br/><br/>
        /// 
        /// Note: in special scenarios add member to the Known field called "setter" containing the <br/>
        ///        value keyword to be replaced with the value parameter of this function
        /// </summary>
        public void setKnownFieldValue(String KnownField, String value)
        {
            var field = ((JObject)KnownFields[KnownField]);
            if(field.ContainsKey("setter"))
            {
                this.interpreter.Eval(field["setter"].ToString().Replace("value",value));
            }
            else 
            { 
                if(field?["type"]?.ToObject<String>()== "string")
                {
                    this.interpreter.Eval($"{field["source"]} = {value}.ToString()");
                }
                else{
                    this.interpreter.Eval($"{field["source"]} = {value}");
                }
            }
        }

        /// <summary>
        /// Usign Known Field Values, finds the specific matching row in the rating manual
        /// </summary>
        private void LoadAlgorithmFactors(String CoverageCode, Entity.Vehicle vehicle, ref JObject RateResult)
        {

           
        }

        /// <summary>
        /// Finds all Known Field's values in the Apollo System
        /// </summary>
        private void loadResolvedAlgorithmFactors(String CoverageCode, Entity.Vehicle vehicle, ref JObject rateResult)
        {

            var algorithmPage = getTable(CoverageCode);


            var result = new JObject();
            
            //Iterate through every factor in the algorithm and get all of it's known KnownFields' value
            foreach (var row in algorithmPage)
            {
                var factor = row["Rating Factor"];

                Factor factorObj;
                //if the factor starts with the algorithm name, then remove it to match the Known Field name in KnownFields.json
                if (factor.StartsWith(CoverageCode + "."))
                {
                    factorObj = Factor.GetFactor(factor.Substring(factor.IndexOf(".") + 1));
                }
                //factor is a defined factor in our Factors.json file
                else if(Factors.ContainsKey(factor))
                {
                    factorObj = Factor.GetFactor(factor);
                }
                else
                {
                    continue;
                }

                var resolvable = factorObj.GetResolvable(this);
                try
                {
                    var resolvedObj = resolvable.Resolve();
                    result.Add(factor, resolvedObj);

                }
                catch(Exception)
                {

                    Log.Debug($"Error Resolving KnownFields for Factor: {resolvable.Name} for coverage code: {CoverageCode}");
                    throw;
                }

            }

            rateResult.Add("Factors", result);
            
        }


        public class AlgorithmAssignment
        {
            public string ClassCode { get; set; }
            public string RatingGroup { get; set; }
            public string DriverRatingPlan { get; set; }
            public string IncreasedLimitGroup { get; set; }
            public string CoverageCode { get; set; }

        }
        /// <returns>
        ///  the corresponding algorithm code
        /// </returns>
        public AlgorithmAssignment getAlgorithmAssignment(Entity.CoverageType coverageType, string ClassCode)
        {
            AlgorithmAssignment result = null;

            foreach(var row in getTable("AT.1"))
            {
                if(row["Class Code"] == ClassCode)
                {
                    result =  new AlgorithmAssignment()
                    {
                        ClassCode = row["Class Code"],
                        DriverRatingPlan = row["Driver Rating Plan"],
                        IncreasedLimitGroup = row["Increased Limit Group"],
                        RatingGroup = row["Rating Group"]
                    };

                    if (row.TryGetValue(coverageType.Name, out var value))
                    {
                        result.CoverageCode = value;

                    }
                    else
                    {
                        foreach(var possibleName in Entity.CoverageType.Persisted)
                        {
                            if (possibleName.Value == coverageType.Name && row.TryGetValue(possibleName.Key, out value))
                            {
                                result.CoverageCode = value;

                            }
                        }

                        if(string.IsNullOrEmpty(result.CoverageCode))
                        {
                            JToken coverageCode = null;
                            if (((JObject)CoverageAlgorithms[GoverningStateCode])?.TryGetValue(coverageType.Name, out coverageCode)??false)
                            {
                                result.CoverageCode = coverageCode?.ToString();
                            }
                            else
                            {
                                throw new Exception($"couldn't find algorithm Assignment for Coverage Type: {coverageType.Name} & Class Code: [{ClassCode}] on state {GoverningStateCode}\n please check Data/Rating/CoverageAlgorithms.json");
                            }
                        }
                    }
                   
                }
                
            }
            if(string.IsNullOrWhiteSpace(result.CoverageCode))
            {
                throw new KeyNotFoundException($"Coverage Type: [{coverageType.Name}] Class Code: [{ClassCode}] did not match any Algorithms");

            }
            return result;
        }

    }
}
