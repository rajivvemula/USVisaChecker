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
        public float BaseRateFactors
        { 
            get {return float.Parse(getTable($"{CoverageCode}.BaseRateFactors")[0]["Base Rate Factor"]);} 
        }


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

                if (factor is String)
                {
                    values[field.Value] = (String)factor;
                }
                else if (factor is float)
                {
                    values[field.Value] = (float)factor;
                }
                else if (factor is int)
                {
                    values[field.Value] = (int)factor;
                }
                else if (factor is Int64)
                {
                    values[field.Value] = (Int64)factor;
                }
                else if(factor is bool)
                {
                    values[field.Value] = (bool)factor;
                }
                else if(factor is null)
                {
                    values[field.Value] = null;
                }
                else
                {
                    throw new Exception($"returned value: {factor} for source:{source} is type {factor.GetType().Name} which is not being casted");
                }

               
                
            }

            return values;
        }

        public JObject getAlgorithmFactors()
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

        
    }
}
