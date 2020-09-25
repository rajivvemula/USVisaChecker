using DynamicExpresso;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ApolloQA.DataFiles
{
    class Rating
    {
        private static readonly dynamic Factors = JsonConvert.DeserializeObject<dynamic>(new StreamReader("DataFiles/Rating/Factors.json").ReadToEnd());
        private static readonly dynamic KnownFields =  JsonConvert.DeserializeObject<dynamic>(new StreamReader("DataFiles/Rating/KnownFields.json").ReadToEnd());

        private static readonly Interpreter Interpreter = new Interpreter();

        //properties public in order to be mentioned in the json files
        public readonly Entity.Policy root;
        public readonly Entity.Vehicle Vehicle; 



        private readonly dynamic CoverageCode;

        public Rating(dynamic root, String CoverageCode, Entity.Vehicle vehicle)
        {
            this.root = root;
            this.CoverageCode = CoverageCode;
            this.Vehicle = vehicle;

        }

        public Dictionary<String, dynamic> GetRatingFactor(String FactorName)
        {
            Dictionary<String, dynamic> values = new Dictionary<string, dynamic>();
            foreach(dynamic field in Factors[FactorName]["Fields"])
            {

                String source = KnownFields[field.Value].source.Value;

                String[] rootProperties = this.GetType().GetProperties().Select(propertyInfo => propertyInfo.Name).ToArray<String>();
                Console.WriteLine("DEBUG 1 ->>>>>>>>>>> " + rootProperties);
                Console.WriteLine("DEBUG 1 ->>>>>>>>>>> " + rootProperties[0]);

                source = string.Join("",source.Split(".").Select(prop => (prop.Contains("()") || rootProperties.Contains(prop) ) ? prop : $"['{prop}']").ToArray<String>());

                Console.WriteLine("DEBUG 2 ->>>>>>>>>>> " + source);

                values.Add(field.Value, Interpreter.Eval(source));
            }

            return values;
        }
    }
}
