using ApolloQA.Source.Helpers;
using DynamicExpresso;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ApolloQA.Data.TestData
{
    //the purpose of this class is to parse Json objects
    //replacing any variables (e.g. "@VariableName") 
    public class Parser
    {
        public Interpreter interpreter = new Interpreter();



        public dynamic GetObject(string fileName)
        {
            String jsonString = new StreamReader(Path.Combine(
                                                      $"{Source.Driver.Setup.SourceDir}",
                                                      $"Data/TestData/objects/{(fileName.Contains(".json") ? fileName : fileName + ".json")}"
                                                      )).ReadToEnd();


            //loop through the json string as many times as there are @'s
            int count = jsonString.Count(it => it == '@');
            for (int i=0; i< count; i++)
            {
                //this is a post scenario
                //if the jsonString doens't contain any "@ then it's finished
                if(!jsonString.Contains("\"@"))
                {
                    break;
                }

                //store the start index of the "@ string
                int startIndex = jsonString.IndexOf("\"@") + 2;

                //from the start of the variable, to the next "
                //the count of characters will define our variable length
                int length = jsonString.Substring(startIndex).IndexOf("\"");

                //this here is extracting the actual variable name
                string variableName = jsonString.Substring(startIndex, length);

                //using the interpreter, get the variable's stored value
                object value = interpreter.Eval(variableName);

                //see interpreter here: https://github.com/davideicardi/DynamicExpresso

                //a null is unacceptable
                if (value == null)
                {
                    throw new ArgumentNullException($"parameter: {variableName} evaluated to a null");
                }
                //integers will be added as strings but
                //DeserializeObject will convert to integer if no quotes are around it
                else if (int.TryParse(value.ToString(), out int valueInt))
                {
                    jsonString = jsonString.Replace($"\"@{variableName}\"", (valueInt).ToString());
                }
                //in the scenario that we've got a \,
                //DeserializeObject blows up
                // we will replace \ by \\
                else if (value is string && new Regex(@"[^\\]\\[^\\]") is var regex && regex.Match((string)value).Success)
                {
                    //because we don't want to replace \\ by \\\
                    //the above regex returns the \ along with the two chars around it

                    //loop through each existing \ withing the value
                    foreach (var slash in ((string)value).Where(it => it == '\\'))
                    {

                        var match = regex.Match((string)value);

                        //extract the three characters matched by the regex
                        var stringToReplace = ((string)value).Substring(match.Index, 3);

                        //out of the 3 extracted characters
                        //1.) replace \ by \\
                        //2.) replace the three characters using the new \\ (e.g. A\B) by (e.g. A\\B)
                        value = ((string)value).Replace(stringToReplace, stringToReplace.Replace("\\", "\\\\"));
                    }


                    jsonString = jsonString.Replace($"\"@{variableName}\"", $"\"{(string)value}\"");

                }
                else
                {
                    //because we only want to replace whole strings
                    //we will add the quotes around them explicitly and replace it all together
                    //for example:
                    //from the two variables:
                    //"@Variable"
                    //"@VariableId"
                    //
                    //for varialbe Number two: replacing @Variable by 123 will result in "123Id"
                    //but replacing "@Variable" will make sure to match the entire word only
                    //
                    jsonString = jsonString.Replace($"\"@{variableName}\"", $"\"{(string)value}\"");
                }
            }

            try
            {
                //this will either return a JObject or JArray
                return JsonConvert.DeserializeObject<dynamic>(jsonString);
            }
            catch (Exception ex)
            {
                Log.Critical($"object: {jsonString}");
                    throw ex;
            }
        }
    }
}
