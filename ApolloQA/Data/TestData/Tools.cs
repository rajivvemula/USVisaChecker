using ApolloQA.Source.Helpers;
using DynamicExpresso;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ApolloQA.Data.TestData
{
    public class Tools
    {
        public static Interpreter interpreter = new Interpreter();

        public static dynamic GetObject(string fileName)
        {
            String jsonString = new StreamReader(Path.Combine(
                                                      $"{Source.Driver.Setup.SourceDir}",
                                                      $"Data/TestData/{(fileName.Contains(".json") ? fileName : fileName + ".json")}"
                                                      )).ReadToEnd();

            int count = jsonString.Count(it => it == '@');
            for (int i=0; i< count; i++)
            {
                if(!jsonString.Contains("\"@"))
                {
                    continue;
                }
                int startIndex = jsonString.IndexOf("\"@") + 2;
                int length = jsonString.Substring(startIndex).IndexOf("\"");

                string variableName = jsonString.Substring(startIndex, length);

                object value = interpreter.Eval(variableName);

                if (int.TryParse(value.ToString(), out int valueInt))
                {
                    jsonString = jsonString.Replace($"\"@{variableName}\"", (valueInt).ToString());
                }
                else
                {
                    jsonString = jsonString.Replace($"@{variableName}", (string)value);
                }



            }
           
            return JsonConvert.DeserializeObject<dynamic>(jsonString);
        }
    }
}
