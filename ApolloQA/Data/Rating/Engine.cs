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

        /// <returns>
        /// Returns specified table from the Rating Manual
        /// </returns>
        public static List<Dictionary<String, String>> getTable(String tableName, string stateCode = "IL")
        {
            Log.Debug("Using " + Path.Combine(Source.Driver.Setup.SourceDir, @$"Data\RatingManual\{stateCode}\{tableName}.xlsx"));
            return Functions.parseExcel(Path.Combine(Source.Driver.Setup.SourceDir, @$"Data\RatingManual\{stateCode}\{tableName}.xlsx")).ToList();
        }

        /// <summary>
        ///  Interpreter used to evaluate strings of code <br/>
        ///  This Interpreter will be used dynamically changing it's variables to accomodate current context. <br/>
        ///  for example, Vehile will be set multiple times depending on current vehicle under rating. <br/>
        /// </summary>
        public readonly Interpreter interpreter;

        //properties public in order to be mentioned in the json files
        public readonly Entity.Quote root;
        

        /// <summary>
        /// Rating Engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// constructed with a root object which in the future could be a Policy or Quote. <br/><br/>
        /// <param name="CoverageCode"> To be removed in the future, (iteration through all policy coverages need to be implemented)</param>
        /// </summary>
        public Engine(Entity.Quote root)
        {
            this.root = root;

            this.interpreter = new Interpreter();
            interpreter.Reference(typeof(JObject));
            interpreter.SetVariable("root", this.root);

        }

        /// <summary>
        /// Run the engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// </summary>
        public IEnumerable<JObject> Run()
        {

            foreach (var vehicle in root.GetVehicles())
            {
                //set Vehicle in context to the interpreter
                interpreter.SetVariable("Vehicle", vehicle);
                /*
                * This foreach finds coverage code depending on the coverages selected at the Quote before generating a policy
                */
                foreach (var coverageCode in root.getCoverageTypes(vehicle).Select(coverage => getAlgorithmCode(coverage, KnownField.GetKnownField("Class Code").Resolve(this).ToString())))
                {
                    if(string.IsNullOrWhiteSpace(coverageCode))
                    {
                        continue;
                    }
                    var baseRateFactor = getTable($"{coverageCode}.BaseRateFactors")[0]["Base Rate Factor"];
                    Log.Debug("Base rate Factor string "+ baseRateFactor);
                    Log.Debug("Base rate Factor decimal.parse " + decimal.Parse(baseRateFactor));

                    

                    interpreter.SetVariable("BaseRateFactors", decimal.Parse(getTable($"{coverageCode}.BaseRateFactors")[0]["Base Rate Factor"]));

                    var rateResults = new JObject();
                    LoadAlgorithmFactors(coverageCode, vehicle, ref rateResults);
                    decimal premium = 0;
                    foreach (var factor in (JObject)rateResults["Factors"])
                    {
                        if (factor.Key.Contains("BaseRateFactors"))
                        {
                            premium = (decimal)factor.Value["factor"];
                        }
                        else
                        {
                            premium = premium * (decimal)factor.Value["factor"];
                        }

                        ((JObject)factor.Value).Add("currentPremium", premium);


                    }
                    rateResults.Add("TotalPremium", premium);
                    rateResults.Add("Vehicle", JObject.FromObject(vehicle.GetProperties()));
                    yield return rateResults;
                } 
            }
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

            this.loadAlgorithmFactorParameters(CoverageCode, vehicle, ref RateResult);
            const string LOWERBOUND = "Lower Bound";
            const string UPPERBOUND = "Upper Bound";
            const string INTERPOLATIONUPPERMATCH = "Interpolation Upper Row Match";
            foreach (var factor in (JObject)RateResult["Factors"])
            {
                //factors that don't have corresponding rate table are expected to have only one known field containing it's factor
                if(bool.TryParse(factor.Value?["CustomCalculation"]?.ToString(), out bool customCalc) && customCalc)
                {

                    var factorDec = ((JArray)factor.Value["KnownFields"])[0]["Value"].ToObject<decimal>();
                    ((JObject)factor.Value).Add("factor", factorDec);
                    continue;
                }
                var factorTable = getTable(factor.Key);
                JArray parameters = (JArray)factor.Value["KnownFields"];
                for (int rowIndex = 0; rowIndex < factorTable.Count; rowIndex++)
                {
                    var row = factorTable[rowIndex];
                    Dictionary<string, bool> match = new Dictionary<string, bool>();
                    bool lowerBoundMatch = false;
                    bool upperBoundMatch = false;
                    for (int columnIndex = 0; columnIndex < row.Count; columnIndex++)
                    {
                        KeyValuePair<string, string> column = row.ElementAt(columnIndex);
                        var columnToMatch = column.Key;

                        if (columnToMatch.Contains(LOWERBOUND))
                        {
                            columnToMatch = column.Key.Replace(" " + LOWERBOUND, "");
                        }
                        else if (columnToMatch.Contains(UPPERBOUND))
                        {
                            columnToMatch = column.Key.Replace(" " + UPPERBOUND, "");
                        }

                        if (!column.Key.Contains("Factor"))
                        {
                            var knownField = parameters.FirstOrDefault(it=> it["Name"].ToString()==columnToMatch);

                            if (knownField == null)
                            {
                                throw new NullReferenceException($"The column [{columnToMatch}] was not matched to any field on DataFiled/Rating/KnownFields.json");
                            }
                            var param = knownField.ToObject<KnownField.Resolvable>();

                            if (param.TypeName == "Boolean")
                            {

                                param.parsedValue = ((bool)param.Value) ? "Yes" : "No";
                            }
                            if (column.Key.Contains(LOWERBOUND) && param.Type != null && (int)param.Value >= Functions.parseInt(column.Value))
                            {
                                lowerBoundMatch = true;
                            }
                            else if (column.Key.Contains(UPPERBOUND))
                            {
                                var columnValue = column.Value == "+" ? int.MaxValue : Functions.parseInt(column.Value);
                                var nextRowLowerBound = rowIndex == factorTable.Count-1 ? int.MinValue : Functions.parseInt(factorTable[rowIndex + 1][columnToMatch + $" {LOWERBOUND}"]);

                                if (param.Type != null && (int)param.Value <= columnValue)
                                {
                                    upperBoundMatch = true;
                                }
                                //check for interpolation US 12209
                                else if(columnValue != int.MaxValue && 
                                        columnValue+1 != nextRowLowerBound &&
                                        param.Type != null && (int)param.Value < nextRowLowerBound
                                       )
                                {

                                    match.Add(INTERPOLATIONUPPERMATCH, true);
                                    upperBoundMatch = true;
                                }
                            }
                           

                            if (lowerBoundMatch || upperBoundMatch)
                            {
                                match.Add(column.Key, true);

                                lowerBoundMatch = false;
                                upperBoundMatch = false;
                            }
                            else if (column.Value != null && (column.Value == param.Value?.ToString() || column.Value == param.parsedValue))
                            {
                                if(param.Name == "ClassCodeFactors")
                                {
                                    Log.Debug("ClassCodeFactors Matched  " + param.Value);

                                }
                                match.Add(column.Key, true);
                            }
                            else
                            {
                                match.Add(column.Key, false);
                            }
                            if (param?.Name == "ClassCodeFactors")
                            {
                                Log.Debug("ClassCodeFactors huh  " + param.Value);

                            }

                        }


                    }
                    if (!match.ContainsValue(false))
                    {
                        
                        string factorColName = row.Keys.ToList<string>().Find(column => column.Contains("Factor"));
                        if (match.ContainsKey(INTERPOLATIONUPPERMATCH))
                        {
                            var nextRow = factorTable[rowIndex + 1];


                            ((JObject)factor.Value)["matchedRow"]= JObject.FromObject(row);
                            ((JObject)factor.Value).Add("matchedNextRow", JObject.FromObject(nextRow));
                            ((JObject)factor.Value).Add("interpolated", true);

                            ((JObject)factor.Value).Add("factor", (decimal.Parse(row[factorColName])+ decimal.Parse(nextRow[factorColName]))/2);
                        }
                        else
                        {
                            ((JObject)factor.Value)["matchedRow"] = JObject.FromObject(row);
                            ((JObject)factor.Value).Add("factor", decimal.Parse(row[factorColName]));

                        }

                       
                        break;

                    }


                }

                if (!((JObject)factor.Value).ContainsKey("factor"))
                {
                    ((JObject)factor.Value).Add("factor", decimal.Parse("1"));
                }

            }
            RateResult.Add("CoverageCode", CoverageCode);
        }

        /// <summary>
        /// Finds all Known Field's values in the Apollo System
        /// </summary>
        private void loadAlgorithmFactorParameters(String CoverageCode, Entity.Vehicle vehicle, ref JObject rateResult)
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
                result.Add(factor, resolvable.Resolve());
 
            }

            rateResult.Add("Factors", result);
            
        }

        /// <summary>
        /// finds values for a singular Known Field's in the Apollo System
        /// </summary>
        private JObject GetFactorKnownFieldsValue(String FactorName)
        {
            JObject result = new JObject() { { "KnownFields", new JObject() } };

            var ratingFactor = Factors[FactorName];
            dynamic factorKnownFields = ratingFactor?.KnownFields;

            if (factorKnownFields == null) { throw new KeyNotFoundException($"Factor Name: [{FactorName}] was not found in DataFiles/Rating/Factors.json"); }

            foreach (dynamic field in factorKnownFields)
            {
                string fieldName = (string)field.Value;
                KnownField.Resolvable knownField = KnownField.GetKnownField(fieldName).GetResolvable(this);
                knownField.Resolve();

                result["KnownFields"][fieldName] = JToken.FromObject(knownField);
            }
            result.Merge(ratingFactor);

            return result;
        }

        /// <returns>
        ///  the corresponding algorithm code
        /// </returns>
        public static string getAlgorithmCode(Entity.CoverageType coverageType, string ClassCode)
        {            


            if (CoverageTypeCode.TryGetValue(coverageType.Name, out var coverageCode))
            {
                return coverageCode;
            }

            foreach(var row in getTable("AT.1"))
            {
                if(row["Class Code"] == ClassCode)
                {
                    if(row.TryGetValue(coverageType.Name, out var value))
                    {
                        return value;

                    }
                    else
                    {
                        foreach(var possibleName in Entity.CoverageType.Persisted)
                        {
                            if (possibleName.Value == coverageType.Name && row.TryGetValue(possibleName.Key, out value))
                            {
                                return value;

                            }
                        }
                    }
                   
                }
                
            }
            return "";
           // throw new KeyNotFoundException($"Coverage Type: [{coverageType.Name}] Class Code: [{ClassCode}] did not match any Algorithms");
        }

        private static Dictionary<String, String> CoverageTypeCode = new Dictionary<string, string>
        {

            {"Policy Level Uninsured Motorists Bodily Injury",      "UM00003" },
            {"Policy Level Underinsured Motorists Bodily Injury",   "UM00004" },
            {"Policy Level Uninsured Motorists Property Damage",    "UM00006" },
            {"Hired Car BIPD - Truckers",                           "OR00001" },
            {"Hired Car BIPD - All Other",                          "OR00002" },
            {"Hired Car Physical Damage",                           "OR00003" },
            {"Non-Owned BIPD",                                      "OR00004" },
            {"Trailer Interchange",                                 "OR00005" },
            {"Garagekeepers",                                       "OR00006" },
            {"Additional Insured - Named Entity",                   "OR00007" },
            {"Additional Insured - Blanket",                        "OR00008" },
            {"Waiver of Subrogation",                               "OR00009" },
            {"Drive Other Car BIPD",                                "OR00011" },
            {"Drive Other Car Collision",                           "OR00012" },
            {"Drive Other Car Other Than Collision",                "OR00013" },
            {"Drive Other Car Medical Payments",                    "OR00014" },
            {"Pollution",                                           "OR00019" },

        };

    }
}
