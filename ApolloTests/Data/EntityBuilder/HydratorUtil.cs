using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using DynamicExpresso;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApolloTests.Data.EntityBuilder.SectionBuilders;
using ApolloTests.Data.EntityBuilder.Models.Risks;

namespace ApolloTests.Data.EntityBuilder
{

    public class HydratorUtil
    {
        #region boilerplate props
        public Interpreter Interpreter { get; set; } = new();
        public Section CurrentSection { get; set; }
        public object? CurrentEntity { get; set; }
        public AnswersBase? CurrentAnswers { get; set; }
        private Entity.Quote? _quote = null;
        public Entity.Quote Quote { 
            get { return _quote ?? throw new NullReferenceException("Attempted to access quote before it was loaded"); } 
            set { this._quote = value; } 
        }
        #endregion
        public HydratorUtil()
        {
            #region interpreter references
            this.Interpreter.Reference(typeof(LocationRisk));
            this.Interpreter.Reference(typeof(Risk));
            this.Interpreter.Reference(typeof(BuildingRisk));
            this.Interpreter.Reference(typeof(AnswersBase));
            this.Interpreter.Reference(typeof(RiskAnswers));
            this.Interpreter.Reference(typeof(JObject));
            this.Interpreter.Reference(typeof(JArray));
            this.Interpreter.Reference(typeof(JToken));
            this.Interpreter.Reference(typeof(JValue));
            #endregion
        }

        /// <summary>
        /// This function traverses throguh the given object and it's properties and looks for the attribute [HydratorAtt] to load the property
        /// </summary>
        /// <param name="obj"></param>
        public void Hydrate(object? obj)
        {
            Hydrate(ref obj, null);
        }
       
        /// <param name="obj">Current object</param>
        /// <param name="prop">Current object's property info</param>
        private void Hydrate(ref object? obj, PropertyInfo? prop=null)
        {
            //
            // Hydrating: to populate an object with data  
            // Deadend types: an object that shall not to be traversed, escentially if it doesn't have the HydratorAttr attribute, we ignore it
            // Interpreter: https://github.com/davideicardi/DynamicExpresso
            // Attribute: referring to HydratorAttr class above
            //
            // 1.)Only run if object is hydratable, has an Attribute or is not null
            //
            // 2.)if the object is a List<QuestionResponse> then we must use state change utility to hydrate it
            //
            // 3.)if the object is an IEnumerable(collection) then we iterate through the collection and hydrate each object in it
            //    3.1) if it's an collection and we have an Attribute, we expect the attribute to be a collection of Names to load
            //    3.2) Add the resolved variable to the current object
            //    3.3) if your collection type is not handled, please add it's Add method
            //
            // 4.)if the object is not a deadend, iterate through it's properties and hydrate them using recursion.
            //    4.1) Add the self variable to the interpreter so that we can use it as an attribute (E.g. [HydratorAttr(Name="self.Id")] would load the property with the Id member of the property's class)
            //    4.2) iterate through the properties in the current object's class
            //    4.3) check for ShouldSerialize: https://www.newtonsoft.com/json/help/html/conditionalproperties.htm, if false don't hydrate
            //    4.4) check for JsonIgnore attribute, if present don't hydrate
            //    4.5) get the property value and pass it to this funciton again by reference (means pass the memory location, not the value)
            //      note: step 4 will happen until the property is a deadend, then step 5 will be executed
            //    4.6) finally, check if there is a set method in the current property, if there is. Then we set it to the new value
            //      note: if there is a new value, if not it just sets it to whatever it was at first
            //
            // 5.)finally, if object is deadend, we grab the name provided to the attribute and interpret it using the interpreter
            //    5.1) check if this object has an Attribute (varAt)
            //    5.2) make sure Attribute's name is not null
            //    5.3) Interpret the Attribute's name
            //         note: see interpreter here: https://github.com/davideicardi/DynamicExpresso
            //    5.4) change the type returned by the Interpreter to the same as the current obj (prop.PropertyType)
            //    5.5) if the final value is null or whitespace then fail
            //    5.6) otherwise load the current object with the interpreted value, already casted
            //         note: because we passed by reference, whatever we set here will be reflected on step 4.5 above
            //    
            //
            //
            var isHydratable = !NonHydratables.Contains(obj?.GetType().Name ?? "");
            HydratorAttr? varAtt = prop?.GetCustomAttribute<HydratorAttr>();
            // 1.)Only run if object is hydratable, has an Attribute or is not null
            if (isHydratable && (obj != null || varAtt != null))
            {
                // 2.)if the object is a List<QuestionResponse> then we must use state change utility to hydrate it
                if (obj is List<QuestionResponse> questionAnswers)
                {
                    questionAnswers.Hydrate(this, prop);
                }
                // 3.)if the object is an IEnumerable(collection) then we iterate through the collection and hydrate each object in it
                else if (obj is IEnumerable enumerable && !isDeadEnd(obj))
                {

                    if (varAtt != null)
                    {
                        // 3.1) if it's an collection and we have an Attribute, we expect the attribute to be a collection of Names to load
                        varAtt.Names.NullGuard($"{prop?.PropertyType?.FullName?? "null"} for a Enumerable attribute a list of variables name is expected to resolve");

                        foreach (var name in varAtt.Names)
                        {
                            var interpretedVal = Interpreter.Eval(name);

                            // 3.2) Add the resolved variable to the current object
                            if (obj is JArray jarr)
                                jarr.Add(interpretedVal);
                            else if (obj is IList lis)
                                lis.Add(interpretedVal);

                            // 3.3) if your collection type is not handled, please add it's Add method
                            else
                                throw new InvalidOperationException();

                        }

                    }

                    foreach (var item in enumerable)
                    {
                        Hydrate(item);
                    }

                }

                // 4.)if the object is not a deadend, iterate through it's properties and hydrate them using recursion.
                else if (!isDeadEnd(obj))
                {
                    // 4.1) Add the self variable to the interpreter so that we can use it in the attribute (E.g. [HydratorAttr(Name="self.Id")] would load the property with the Id member of the property's class)
                    Interpreter.SetVariable("self", obj);

                    //    4.2) iterate through the properties in the current object's class
                    foreach (var property in obj?.GetType()?.GetProperties() ?? throw new InvalidCastException("object is not DeadEnd but is Null, please load it"))
                    {
                        //    4.3) check for ShouldSerialize: https://www.newtonsoft.com/json/help/html/conditionalproperties.htm, if false don't hydrate
                        var shouldSerialize = property.ShouldSerialize(obj);
                        //    4.4) check for JsonIgnore attribute, if present don't hydrate
                        var jsonIgnore = property?.GetCustomAttribute<JsonIgnoreAttribute>() != null;
                        if (!shouldSerialize || jsonIgnore)
                        {
                            continue;
                        }
                        property.NullGuard();
                        //    4.5) get the property value and pass it to this funciton again by reference (means pass the memory location, not the value)
                        //    note: step 4 will happen until the property is a deadend, then step 5 will be executed
                        var propValObj = property.GetValue(obj, null);
                        Hydrate(ref propValObj, property);


                        //    4.6) finally, check if there is a set method in the current property, if there is. Then we set it to the new value
                        //    note: if there is a new value, if not it just sets it to whatever it was at first
                        if (property.SetMethod != null)
                        {
                            property.SetValue(obj, propValObj);
                        }

                    }
                    Interpreter.SetVariable("self", null);
                }

                //5.) finally, if object is deadend, we grab the name provided to the attribute and interpret it using the interpreter
                //    5.1) check if this object has an Attribute (varAt)
                else if (varAtt != null)
                {
                    //    5.2) make sure Attribute's name is not null
                    varAtt.Name.NullGuard();
                    prop.NullGuard();

                    //    5.3) Interpret the Attribute's name
                    //         note: see interpreter here: https://github.com/davideicardi/DynamicExpresso
                    var interpretedVal = Interpreter.Eval(varAtt.Name);

                    //    5.4) change the type returned by the Interpreter to the same as the current obj (prop.PropertyType)
                    object castedValue;
                    try
                    {
                        if(interpretedVal is JToken token)
                        {
                            castedValue = token.ToObject(prop.PropertyType) ?? throw new NullReferenceException();
                        }
                        else
                        {
                            try
                            {
                                castedValue = Convert.ChangeType(interpretedVal, prop.PropertyType);
                            }
                            catch(Exception ex)
                            {
                                throw new Exception($"error converting {interpretedVal?.GetType()?.FullName??"null"} into {prop.PropertyType.GetType().FullName}", ex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error converting val: {interpretedVal} into {prop.PropertyType.Name} for prop: {prop.Name} from object: {prop.DeclaringType?.FullName}", ex);
                    }

                    //    5.5) if the final value is null or whitespace then fail
                    if (castedValue == null || (castedValue is string && string.IsNullOrWhiteSpace(castedValue.ToString())))
                    {
                        Log.Error($"{prop.Name} returned null for {varAtt.Name}");
                        throw new NullReferenceException();
                    }

                    //    5.6) otherwise load the current object with the interpreted value, already casted
                    obj = castedValue;
                }
                //old implementation used @ to identify variables, this is not obsolete
                else if (obj is string varName && (varName.StartsWith('@') || varName.StartsWith("JSON@")))
                {
                    throw new Exception("using @ is obsolete, please use HydratorAtt instead");
                    //// Cast the interpreset value into whatever the property type is
                    //var targetVar = varName.StartsWith('@') ? varName[1..] : varName[5..];
                    //prop.NullGuard("Attempted to interpret object without having PropertyInfo");
                    //var castedValue = Convert.ChangeType(Interpreter.Eval(targetVar), prop.PropertyType);

                    //if (castedValue == null || string.IsNullOrWhiteSpace(castedValue.ToString()))
                    //{
                    //    Log.Error($"{prop.Name} returned null for {targetVar}");

                    //    throw new NullReferenceException();
                    //}

                    //// Invoke the setter method with the casted value
                    //prop.SetValue(obj, castedValue);
                }

            }
        }
        /// <summary>
        /// returns true if it's a hydratable type, like a string or a DateTime object
        /// </summary>
        private bool isDeadEnd(object? obj) => obj==null? true:obj.GetType().IsPrimitive || DeadEndTypes.Contains(obj.GetType().Name);

        private static List<string> DeadEndTypes = new()
        {
            typeof(DateTime).Name,
            typeof(DateTimeOffset).Name,
            typeof(Decimal).Name,
            typeof(String).Name,
            typeof(JToken).Name,
            typeof(JArray).Name,
            typeof(JObject).Name,
            typeof(JProperty).Name,
            typeof(JValue).Name,

        };

        //types to be skipped from hydration
        private static List<string> NonHydratables = new()
        {
            typeof(QuoteBuilder).Name,
            typeof(Interpreter).Name,
            typeof(HydratorUtil).Name,
            typeof(Entity.Quote).Name,
        };

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
                int length = jsonString[startIndex..].IndexOf("\"");

                //this here is extracting the actual variable name
                string variableName = jsonString.Substring(startIndex, length);

                //variableName = variableName.Trim('\\');

                //using the interpreter, get the variable's stored value
                object value;
                try
                {
                    value = Interpreter.Eval(variableName);
                }
                catch (Exception)
                {
                    Log.Critical($"error evaluating Variable: {variableName}");
                    throw;
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
                if (value is string @string && new Regex(@"[^\\]\\[^\\]") is var regex && regex.Match(@string).Success)
                {
                    //because we don't want to replace \\ by \\\
                    //the above regex returns the \ along with the two chars around it

                    //loop through each existing \ withing the value
                    foreach (var slash in @string.Where(it => it == '\\'))
                    {
                        var match = regex.Match(@string);

                        //extract the three characters matched by the regex
                        var stringToReplace = @string.Substring(match.Index, 3);

                        //out of the 3 extracted characters
                        //1.) replace \ by \\
                        //2.) replace the three characters using the new \\ (e.g. A\B) by (e.g. A\\B)
                        value = @string.Replace(stringToReplace, stringToReplace.Replace("\\", "\\\\"));
                    }

                }

                //integers will be added as strings but
                //DeserializeObject will convert to integer if no quotes are around it
                if (int.TryParse(value.ToString(), out int valueInt))
                {
                    jsonString = jsonString.Replace($"\"@{variableName}\"", (valueInt).ToString());
                    continue;
                }
                else if (value is JToken token)
                {
                    jsonString = jsonString.Replace($"\"@{variableName}\"", $"{token.ToString(Formatting.None)}");
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
                return JsonConvert.DeserializeObject<dynamic>(jsonString) ?? throw new NullReferenceException(fileName);
            }
            catch (Exception)
            {
                Log.Critical($"object: {jsonString}");
                throw;
            }
        }

    }
    public class HydratorAttr : Attribute
    {
        public string? Name { get; set; }
        public string[]? Names { get; set; }
        public bool AsJsonStr { get; set; }
        public Type? TargetType { get; set; }


        public HydratorAttr(bool AsJsonStr) => this.AsJsonStr = AsJsonStr;
        public HydratorAttr(string variableName, bool AsJsonStr = false) : this(AsJsonStr) => Name = variableName;
        public HydratorAttr(string[] variableNames, bool AsJsonStr = false) : this(AsJsonStr) => Names = variableNames;
        public HydratorAttr(Type targetType, string attributeName, bool AsJsonStr = false) : this(attributeName, AsJsonStr) => TargetType = targetType;

    }
}
