using DynamicExpresso;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ApolloTests.Data.TestData
{
    /// <summary>
    /// The purpose of this class is to parse Json objects
    /// replacing any variables (e.g. "@VariableName")
    /// </summary>
    public class Parser
    {
        public Interpreter interpreter = new Interpreter();

        public T Hydrate<T>(object obj, List<string> nestedTypes = null)
        {
            nestedTypes ??= new List<string>();

            if (obj != null)
            {
                nestedTypes.AddRange(obj.GetType().GetNestedTypes().Select(it => it.Name));

                //// Loop through each property in the provided object
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (nestedTypes.Contains(prop.PropertyType.Name))
                    {
                        var nestedObject = prop.GetGetMethod().Invoke(obj, null);
                        Hydrate<dynamic>(nestedObject, nestedTypes);
                    }

                    // Invoke each property to get the value
                    try
                    {
                        var value = prop.GetGetMethod().Invoke(obj, null);

                        // If the value starts with @ then it means it's a variable
                        if (value is string && ((string)value).StartsWith('@'))
                        {
                            // Cast the interpreset value into whatever the property type is
                            var castedValue = Convert.ChangeType(interpreter.Eval(((string)value)[1..]), prop.PropertyType);

                            if (castedValue == null || string.IsNullOrWhiteSpace(castedValue.ToString()))
                            {
                                Log.Error($"{prop.Name} returned null for {((string)value)[1..]}");

                                throw new NullReferenceException();
                            }

                            // Invoke the setter method with the casted value
                            prop.SetValue(obj, castedValue);
                        }
                    }
                    catch (Exception)
                    {
                        Log.Error(prop.Name);
                        throw;
                    }
                }
            }

            // Finally, return the hydrated object
            return (T)obj;
        }

        public dynamic GetObject(string fileName)
        {
            String jsonString = new StreamReader($"Data/TestData/objects/{(fileName.Contains(".json") ? fileName : fileName + ".json")}").ReadToEnd();

            //loop through the json string as many times as there are @'s
            int count = jsonString.Count(it => it == '@');
            for (int i = 0; i < count; i++)
            {
                //this is a post scenario
                //if the jsonString doens't contain any "@ then it's finished
                if (!jsonString.Contains("\"@"))
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

                //variableName = variableName.Trim('\\');

                //using the interpreter, get the variable's stored value
                object value;
                try
                {
                    value = interpreter.Eval(variableName);
                }
                catch (Exception ex)
                {
                    Log.Critical($"error evaluating Variable: {variableName}");
                    throw ex;
                }

                //see interpreter here: https://github.com/davideicardi/DynamicExpresso

                //a null is unacceptable
                if (value == null)
                {
                    throw new ArgumentNullException($"parameter: {variableName} evaluated to a null");
                }

                //in the scenario that we've got a \,
                //DeserializeObject blows up
                // we will replace \ by \\
                if (value is string && new Regex(@"[^\\]\\[^\\]") is var regex && regex.Match((string)value).Success)
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

                }

                //integers will be added as strings but
                //DeserializeObject will convert to integer if no quotes are around it
                if (int.TryParse(value.ToString(), out int valueInt))
                {
                    jsonString = jsonString.Replace($"\"@{variableName}\"", (valueInt).ToString());
                    continue;
                }
                else if(value is JToken)
                {
                    jsonString = jsonString.Replace($"\"@{variableName}\"", $"{((JToken)value).ToString(Formatting.None)}");
                    continue;
                }
                
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

            try
            {
                //this will either return a JObject or JArray
                return JsonConvert.DeserializeObject<dynamic>(jsonString);
            }
            catch (Exception)
            {
                Log.Critical($"object: {jsonString}");
                throw;
            }
        }
    }
}