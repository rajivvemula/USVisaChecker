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
using TechTalk.SpecFlow;

namespace ApolloQA.DataFiles
{
    public class Engine
    {
        private static readonly dynamic Factors = JsonConvert.DeserializeObject<JObject>(new StreamReader("DataFiles/Rating/Factors.json").ReadToEnd());
        private static readonly dynamic KnownFields =  JsonConvert.DeserializeObject<JObject>(new StreamReader("DataFiles/Rating/KnownFields.json").ReadToEnd());

        /// <summary>
        ///  Interpreter used to evaluate strings of code <br/>
        ///  This Interpreter will be used dynamically changing it's variables to accomodate current context. <br/>
        ///  for example, Vehile will be set multiple times depending on current vehicle under rating. <br/>
        /// </summary>
        public readonly Interpreter interpreter;

        //properties public in order to be mentioned in the json files
        public readonly Entity.Policy root;
        

        private readonly String CoverageCode;

        /// <summary>
        /// Rating Engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// constructed with a root object which in the future could be a Policy or Application. <br/><br/>
        /// <param name="CoverageCode"> To be removed in the future, (iteration through all policy coverages need to be implemented)</param>
        /// </summary>
        public Engine(Entity.Policy root, String CoverageCode)
        {
            this.root = root;
            this.CoverageCode = CoverageCode;

            this.interpreter = new Interpreter();
            interpreter.Reference(typeof(JObject));
            interpreter.SetVariable("root", this.root);
            interpreter.SetVariable("BaseRateFactors", this.BaseRateFactors);

        }

        /// <summary>
        /// Run the engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// </summary>
        public IEnumerable<JObject> Run()
        {
            //for each vehicle in the Policy/Application find it's algorithm factors
            foreach (var vehicle in root.GetVehicles())
            {
                var factors = GetAlgorithmFactors(this.CoverageCode, vehicle);
                float premium = 0;
                foreach (var factor in factors)
                {
                    if(factor.Key == "CoverageCode")
                    {
                        continue;
                    }
                    if (factor.Key.Contains("BaseRateFactors"))
                    {
                        premium = (float)factor.Value["factor"];
                    }
                    else
                    {
                        premium = premium * (float)factor.Value["factor"];
                    }

                    ((JObject)factor.Value).Add("currentPremium", premium);


                }
                factors.Add("TotalPremium", premium);
                factors.Add("Vehicle", JObject.FromObject(vehicle.GetProperties()));
                yield return factors;
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
        private JObject GetAlgorithmFactors(String CoverageCode, Entity.Vehicle vehicle)
        {

            var factors = this.getAlgorithmFactorParameters(CoverageCode, vehicle);
            const string LOWERBOUND = "Lower Bound";
            const string UPPERBOUND = "Upper Bound";
            const string INTERPOLATIONUPPERMATCH = "Interpolation Upper Row Match";
            foreach (var factor in factors)
            {
                var factorTable = getTable(factor.Key);
                JObject parameters = (JObject)factor.Value;
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
                            var param = parameters[columnToMatch];
                            if (param == null)
                            {
                                throw new NullReferenceException($"The column [{columnToMatch}] was not matched to any field on DataFiled/Rating/KnownFields.json");
                            }
                            if (param["type"]?.ToString() == "bool")
                            {

                                param["parsedValue"] = ((bool)param["value"]) ? "Yes" : "No";
                            }
                            if (column.Key.Contains(LOWERBOUND) && param["value"].ToObject<int>() >= int.Parse(column.Value))
                            {
                                lowerBoundMatch = true;
                            }
                            else if (column.Key.Contains(UPPERBOUND))
                            {
                                var columnValue = column.Value == "+" ? int.MaxValue : int.Parse(column.Value);
                                var nextRowLowerBound = rowIndex == factorTable.Count-1 ? null :factorTable[rowIndex + 1][columnToMatch + $" {LOWERBOUND}"];
                                if (param["value"].ToObject<int>() <= columnValue)
                                {
                                    upperBoundMatch = true;
                                }
                                //check for interpolation US 12209
                                else if(columnValue != int.MaxValue && 
                                        columnValue+1 != int.Parse(nextRowLowerBound) &&
                                        param["value"].ToObject<int>() < int.Parse(nextRowLowerBound)
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
                                lowerBoundMatch = false;
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
                    if (!match.ContainsValue(false))
                    {
                        
                        string factorColName = row.Keys.ToList<string>().Find(column => column.Contains("Factor"));
                        if (match.ContainsKey(INTERPOLATIONUPPERMATCH))
                        {
                            var nextRow = factorTable[rowIndex + 1];


                            ((JObject)factor.Value).Add("matchedRow", JObject.FromObject(row));
                            ((JObject)factor.Value).Add("matchedNextRow", JObject.FromObject(nextRow));
                            ((JObject)factor.Value).Add("interpolated", true);

                            ((JObject)factor.Value).Add("factor", (float.Parse(row[factorColName])+ float.Parse(nextRow[factorColName]))/2);
                        }
                        else
                        {
                            ((JObject)factor.Value).Add("matchedRow", JObject.FromObject(row));
                            ((JObject)factor.Value).Add("factor", float.Parse(row[factorColName]));

                        }

                       
                        break;

                    }


                }

                if (!((JObject)factor.Value).ContainsKey("factor"))
                {
                    ((JObject)factor.Value).Add("factor", float.Parse("1"));
                }

            }
            factors.Add("CoverageCode", CoverageCode);
            return factors;
        }

        /// <summary>
        /// Finds all Known Field's values in the Apollo System
        /// </summary>
        private JObject getAlgorithmFactorParameters(String CoverageCode, Entity.Vehicle vehicle)
        {

            //In Every call to this function, the interpreter will be set fresh variables in order to stay in sync with the GetKnownFieldValue() function
            interpreter.SetVariable("Vehicle", vehicle);
            interpreter.SetVariable("Territory", this.Territory);


            var algorithmPage = getTable(this.CoverageCode);
            

            var result = new JObject();
            
            //Iterate through every factor in the algorithm and get all of it's known field value
            foreach (var row in algorithmPage)
            {
                var factor = row["Rating Factor"];

                //if the factor starts with the algorithm name, then remove it to match the Known Field name in KnownFields.json
                if (factor.StartsWith(this.CoverageCode + "."))
                {
                    result.Add(factor, this.GetKnownFieldValue(factor.Substring(factor.IndexOf(".")+1)));
                }
                else if(Factors.ContainsKey(factor))
                {
                    result.Add(factor, this.GetKnownFieldValue(factor));
                }
 
            }

            return result;
            
        }

        /// <summary>
        /// finds values for a singular Known Field's in the Apollo System
        /// </summary>
        private JObject GetKnownFieldValue(String KnownField)
        {
            JObject values = new JObject();

            dynamic factorFields = Factors[KnownField]?.Fields;

            if (factorFields == null) { throw new KeyNotFoundException($"Factor Name: [{KnownField}] was not found in DataFiles/Rating/Factors.json"); }

            foreach (dynamic field in factorFields)
            {
                String source = KnownFields[field.Value]?.source?.Value;

                if (source == null) { throw new KeyNotFoundException($"Factor {KnownField}'s Field Name: [{field.Value}] source  was not found in DataFiles/Rating/KnownFields.json"); }


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
                else if (factor is bool)
                {
                    factorField.Add("type", "bool");
                    factorField.Add("value", (bool)factor);
                    values[field.Value] = factorField;
                }
                else if (factor is null)
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

       

        /// <returns>
        /// Returns specified table from the Rating Manual
        /// </returns>
        public static List<Dictionary<String, String>> getTable(String tableName)
        {
            return Functions.parseCSV(@"lib\RatingManual\" + tableName + ".xlsx").ToList();
        }
        public float BaseRateFactors
        {
            get { return float.Parse(getTable($"{CoverageCode}.BaseRateFactors")[0]["Base Rate Factor"]); }
        }
        public int? Territory
        {
            get
            {
                var riskId = ((Entity.Vehicle)this.interpreter.Eval("Vehicle"))["RiskId"];

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
