using DynamicExpresso;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ApolloQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloQA.DataFiles
{
    class Engine
    {
        private static readonly dynamic Factors = JsonConvert.DeserializeObject<JObject>(new StreamReader("DataFiles/Rating/Factors.json").ReadToEnd());
        private static readonly dynamic KnownFields =  JsonConvert.DeserializeObject<JObject>(new StreamReader("DataFiles/Rating/KnownFields.json").ReadToEnd());


        private readonly Interpreter interpreter;

        //properties public in order to be mentioned in the json files
        public readonly Entity.Policy root;
        public readonly Entity.Vehicle Vehicle;
        

        private readonly String CoverageCode;

        public Engine(dynamic root, String CoverageCode, Entity.Vehicle vehicle)
        {
            this.root = root;
            this.CoverageCode = CoverageCode;
            this.Vehicle = vehicle;

            this.interpreter = new Interpreter();
            interpreter.Reference(typeof(JObject));
            interpreter.SetVariable("root", this.root);
            interpreter.SetVariable("Vehicle", this.Vehicle);
            interpreter.SetVariable("BaseRateFactors", this.BaseRateFactors);
            interpreter.SetVariable("Territory", this.Territory);

        }

        public static List<Dictionary<String, String>> getTable(String tableName)
        {
            return Functions.parseCSV(@"lib\RatingManual\" + tableName+ ".xlsx").ToList();

        }

        public JObject GetRatingFactor(String FactorName)
        {
            JObject values = new JObject();

            dynamic factorFields = Factors[FactorName]?.Fields;

            if(factorFields == null) { throw new KeyNotFoundException($"Factor Name: [{FactorName}] was not found in DataFiles/Rating/Factors.json");  }

            foreach (dynamic field in factorFields)
            {
                String source = KnownFields[field.Value]?.source?.Value;

                if (source == null) { throw new KeyNotFoundException($"Factor {FactorName}'s Field Name: [{field.Value}] source  was not found in DataFiles/Rating/KnownFields.json"); }


                dynamic factor = interpreter.Eval(source);
                var factorField = new JObject();
                if (factor is String)
                {
                    factorField.Add("type", "string");
                    factorField.Add("value", (String)factor);

                    values[field.Value] = factorField;
                }
                else if (factor is float)
                {
                    factorField.Add("type", "float");
                    factorField.Add("value", (float)factor);

                    values[field.Value] = factorField;
                }
                else if (factor is int || factor is Int64)
                {
                    factorField.Add("type", "int");
                    factorField.Add("value", (int)factor);

                    values[field.Value] = factorField;
                }
                else if(factor is bool)
                {
                    factorField.Add("type", "bool");
                    factorField.Add("value", (bool)factor);
                    values[field.Value] = factorField;
                }
                else if(factor is null)
                {
                    factorField.Add("type", "null");
                    factorField.Add("value", factor);
                    values[field.Value] = factorField;
                }
                else
                {
                    throw new Exception($"returned value: {factor} for source:{source} is type {factor.GetType().Name} which is not being casted");
                }

               
                
            }

            return values;
        }

        public JObject getAlgorithmFactorParameters()
        {
            var algorithmPage = getTable(this.CoverageCode);
            

            var result = new JObject();
            
            var temp = new Dictionary<String, String>();
            foreach (var row in algorithmPage)
            {
                var factor = row["Rating Factor"];
                if (factor.StartsWith(this.CoverageCode + "."))
                {
                    result.Add(factor, this.GetRatingFactor(factor.Substring(factor.IndexOf(".")+1)));
                }
                else if(Factors.ContainsKey(factor))
                {
                    result.Add(factor, this.GetRatingFactor(factor));
                }
 
            }

            return result;
            
        }
        public JObject getAlgorithmFactors()
        {
            var factors = this.getAlgorithmFactorParameters();
            const string LOWERBOUND = "Lower Bound";
            const string UPPERBOUND = "Upper Bound";

            foreach (var factor in factors)
            {
                var factorTable = getTable(factor.Key);
                JObject parameters = (JObject)factor.Value;
                float value = 1;
                foreach(var row in factorTable)
                {
                   Dictionary<string, bool> match = new Dictionary<string, bool>();
                   bool lowerBoundMatch = false;
                   bool upperBoundMatch = false;
                   foreach(var column in row)
                    {
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
                            var param = parameters[columnToMatch];
                            if(param == null)
                            {
                                throw new NullReferenceException($"The column [{columnToMatch}] was not matched to any field on DataFiled/Rating/KnownFields.json");
                            }
                            if (param["type"]?.ToString() == "bool")
                            {
                                
                                param["parsedValue"] = ((bool)param["value"]) ? "Yes" : "No";
                            }
                            
                            if (column.Key.Contains(LOWERBOUND) && param["value"].ToObject<int>()>=int.Parse(column.Value) )
                            {
                                lowerBoundMatch = true;   
                            }
                            else if(column.Key.Contains(UPPERBOUND) && param["value"].ToObject<int>() <= (column.Value == "+" ? int.MaxValue : int.Parse(column.Value)))
                            {
                                upperBoundMatch = true;
                            }

                            if(lowerBoundMatch && upperBoundMatch)
                            {
                                match.Add(column.Key,true);
                            }
                            else if (column.Value != null && column.Value == param["value"]?.ToString() || column.Value == param["parsedValue"]?.ToString())
                            {
                                match.Add(column.Key, true);
                            }
                            else
                            {
                                match.Add(column.Key, false);
                            }

                        }
                        
                        
                    }
                   if(!match.ContainsValue(false))
                    {
                        string factorColName = row.Keys.ToList<string>().Find(column => column.Contains("Factor"));
                        Console.WriteLine(factorColName);
                        ((JObject)factor.Value).Add("matchedRow", JObject.FromObject(row));
                        ((JObject)factor.Value).Add("factor", float.Parse(row[factorColName]));
                        break;

                    }
                  

                }

                if (!((JObject)factor.Value).ContainsKey("factor") )
                {
                    ((JObject)factor.Value).Add("factor", float.Parse("1"));
                }

            }

            return factors;
        }

        public float BaseRateFactors
        {
            get { return float.Parse(getTable($"{CoverageCode}.BaseRateFactors")[0]["Base Rate Factor"]); }
        }
        public int? Territory
        {
            get
            {

                var riskId = this.Vehicle["RiskId"];
                var risk = ((JArray)this.root.GetApplication()["risks"]).ToObject<List<dynamic>>().Find(risk => risk["riskId"] == riskId);

                var locationID = risk["VehicleDriverLocation"]?["locationId"];
                if(locationID == null)
                {
                    return null;
                }
                var zip = SQL.executeQuery($"SELECT PostalCode FROM [location].[Address] where Id = {locationID}")[0]["PostalCode"];
                var data = Engine.getTable("TT.1");

                if (int.TryParse(data.Find(row => row["Zip Code"] == zip)?["Territory"], out int value))
                { return value; }

                return null;

            }
        }

    }
}
