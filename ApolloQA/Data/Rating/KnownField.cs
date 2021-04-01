﻿using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApolloQA.Data.Rating
{
    public class KnownField
    {
        private static readonly dynamic KnownFields = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine($"{Setup.SourceDir}", $"Data/Rating/KnownFields.json")).ReadToEnd());
        
        public readonly string Name;
        public readonly string Source;
        public string TypeName;

        public KnownField(string name, string source, string? typeName = null)
        {
            this.Name = name;
            this.Source = source;
            TypeName = typeName;

        }
        public static KnownField GetKnownField(string name)
        {
            var _knownField = GetKnownFields().Find(it => it.Name == name);

            if (_knownField == null) { throw new KeyNotFoundException($"Known field: {name} did not exist in  DataFiles/Rating/KnownFields.json"); }

            return _knownField;


        }

        private static List<KnownField> _knownfields = new List<KnownField>();
        public static List<KnownField> GetKnownFields()
        {
            if(_knownfields.Count == 0)
            {
                foreach (var field in KnownFields)
                {
                    if (field.Value.source == null) { throw new KeyNotFoundException($"Known field: \n{field}\n did not have source property in DataFiles/Rating/KnownFields.json"); }

                    _knownfields.Add(new KnownField(field.Name, field.Value.source.ToString(), field.Value?.type?.ToString()));

                }
            }
            return _knownfields;
           
        }

        public Resolvable GetResolvable(Engine engine)
        {
            return new Resolvable(engine, this);
        }

        public dynamic Resolve(Engine engine)
        {
            return GetResolvable(engine).Resolve();
        }

        public override string ToString()
        {
            return "KnownField: " + Name + " Source: " + Source;
        }
        public class Resolvable
        {
            private KnownField KnownField;
            private Engine Engine;
            public string Name
            {
                get => KnownField.Name;
                set
                {
                    if (KnownField == null)
                    {
                        KnownField = KnownField.GetKnownField(value);
                    }
                }
            }
            public string Source => KnownField.Source;
            public Type Type { get; set; }
            public dynamic Value { get; set; }
            public String parsedValue { get; set; }
            public String TypeName => Type?.Name ?? "Null";

            public Resolvable(Engine engine, KnownField knownField)
            {
                this.KnownField = knownField;
                this.Engine = engine;
            }

            public dynamic Resolve()
            {

                var method = this.GetType().GetProperty(KnownField.Source, BindingFlags.NonPublic | BindingFlags.Instance);

                dynamic resolvedValue;
                if (method != null)
                {
                    resolvedValue = method.GetGetMethod(true).Invoke(this, null);

                }
                else
                {
                    try
                    {
                        resolvedValue = Engine.interpreter.Eval(KnownField.Source);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Field: " + KnownField);
                        throw Functions.handleFailure(ex);
                    }
                }



                if (resolvedValue is String)
                {
                    Type = typeof(String);
                    Value = (String)resolvedValue;

                }
                //instead of float, we want to use decimals
                /*                else if (resolvedValue is float)
                                {
                                    result.Add("type", "float");
                                    result.Add("resolvedValue", (float)resolvedValue);

                                }*/
                else if (resolvedValue is decimal)
                {
                    Type = typeof(decimal);
                    Value = (decimal)resolvedValue;

                }
                else if (resolvedValue is int || resolvedValue is Int64)
                {
                    Type = typeof(int);
                    Value = (int)resolvedValue;


                }
                else if (resolvedValue is long)
                {
                    Type = typeof(long);
                    Value = (long)resolvedValue;


                }
                else if (resolvedValue is bool)
                {
                    Type = typeof(bool);
                    Value = (bool)resolvedValue;

                }
                else if (resolvedValue is null)
                {
                    Value = resolvedValue;

                }
                else
                {
                    throw new Exception($"returned resolvedValue: {resolvedValue} for source:{KnownField} is type {resolvedValue.GetType().Name} which is not being casted");
                }

                return Value;

            }

            private JObject GetRisk(long riskId)
            {
                return ((JArray)this.Engine.root["risks"]).ToObject<List<dynamic>>().Find(risk => risk["riskId"] == riskId);
            }

            private JObject GetCurrentVehicleRisk()
            {
                var riskId = ((Entity.Vehicle)this.Engine.interpreter.Eval("Vehicle"))["RiskId"];

                var risk = new JObject();

                //future implementation, root should be policy or quote
                if (this.Engine.root is Entity.Policy)
                {
                    //risk = ((JArray)this.root.GetQuote()["risks"]).ToObject<List<dynamic>>().Find(risk => risk["riskId"] == riskId);
                }
                else
                {
                    risk = GetRisk(riskId);
                }
                return risk;
            }
            private int VehicleClassCode
            {
                get
                {
                    var classCode = GetCurrentVehicleRisk()["vehicleClassCode"].ToObject<int>();
                    return classCode;
                }
            }

            private decimal ScheduleRating
            {
                get
                {
                    return 1;
                }
            }
            private decimal PolicyTermFactor
            {
                get
                {
                    var ratableObj = this.Engine.root.GetCurrentRatableObject();
                    var lifespan = ratableObj.TimeTo - ratableObj.TimeFrom;

                    this.parsedValue = $"{lifespan.TotalDays} / 365";


                    return decimal.Parse(lifespan.TotalDays.ToString()) / 365;
                }
            }
            private int? Territory
            {
                get
                {
                    var risk = GetCurrentVehicleRisk();

                    var locationID = risk["outputMetadata"]["VehicleDriverLocation"]?["locationId"];
                    if (locationID == null)
                    {
                        //Log.Debug("Location ID null " + risk.ToString());
                        return null;
                    }
                    var zip = SQL.executeQuery($"SELECT PostalCode FROM [location].[Address] where Id = {locationID}")[0]["PostalCode"];
                    var data = Engine.getTable("TT.1");

                    if (int.TryParse(data.Find(row => row["Zip Code"] == zip)?["Territory"], out int value))
                    { return value; }

                    //Log.Debug("No Match Null" + risk.ToString());
                    return null;

                }
            }

            private String InsuranceScoreTier
            {
                get
                {
                    var org = this.Engine.root.Organization;
                    int score = org.InsuranceScore ?? 998;


                    int fleetSize = this.Engine.root.GetVehicles().Count;

                    String type = org.TypeName;


                    foreach (Dictionary<String, String> row in Engine.getTable("CT.2"))
                    {

                        if (Functions.parseRatingFactorNumericalValues(row["Fleet Size Lower Bound"]) <= fleetSize &&
                            Functions.parseRatingFactorNumericalValues(row["Fleet Size Upper Bound"]) >= fleetSize &&
                            Functions.parseRatingFactorNumericalValues(row["Insurance Score Lower Bound"]) <= score &&
                            Functions.parseRatingFactorNumericalValues(row["Insurance Score Upper Bound"]) >= score &&
                            row["Organization Type"] == type
                            )
                        {
                            return row["Insurance Score Tier"];
                        }
                    }
                    throw new KeyNotFoundException($"No Score tier found for   Insurrance Score: [[{score}]  -  Org Type: [{type}]  -  Fleet Size: [{fleetSize}]");

                }
            }

            private decimal AccidentPrevention
            {
                get
                {
                    var root = this.Engine.root;

                    var drivers = root.GetDrivers();

                    decimal credit = 0;
                    foreach (var driver in drivers)
                    {
                        int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                        int dob = int.Parse(driver.DateOfBirth.ToString("yyyyMMdd"));
                        int age = (now - dob) / 10000;
                        if (age < 55)
                        {
                            continue;
                        }

                        bool defensiveDriving = driver.GetQuestionResponse(root, "IL-DefensiveDriving")?.ToObject<bool?>() ?? false;
                        bool LastYearViolation = driver.GetQuestionResponse(root, "IL-LastYearViolation")?.ToObject<bool?>() ?? false;
                        bool Last3YearsLicenseSuspended = driver.GetQuestionResponse(root, "IL-Last3YearsLicenseSuspended")?.ToObject<bool?>() ?? false;


                        if (defensiveDriving && !LastYearViolation && !Last3YearsLicenseSuspended)
                        {
                            credit += 0.05M;
                        }

                    }
                    return 1 - (credit / drivers.Count());
                }
            }
            private decimal DriverRatingPlan
            {
                get
                {
                    return 1;
                }
            }
            private decimal IncreasedLimitFactor
            {
                get
                {
                    return 1;
                }
            }
            private string BillingType{
                get
                {
                    return "Direct Bill";
                }

           }
            private string PaymentPlan
            {
                get
                {
                    return "Twelve Payment Plan";
                }

            }
            private bool IsEft
            {
                get
                {
                    return false;
                }

            }            
        }
    }   
    
}