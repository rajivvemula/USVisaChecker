using ApolloTests.Data.Entities;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApolloTests.Data.Rating
{
    public class KnownField:BaseEntity
    {
        private static readonly dynamic KnownFields = JsonConvert.DeserializeObject<JObject>(new StreamReader($"Data/Rating/KnownFields.json").ReadToEnd()) ?? throw new NullReferenceException();
        
        public readonly string Name;
        public string Source;
        public string? TypeName;

        public KnownField(string name, string source, string? typeName = null)
        {
            this.Name = name;
            this.Source = source;
            this.TypeName = typeName;

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

        public dynamic? Resolve(Engine engine)
        {
            return GetResolvable(engine).Resolve();
        }

        public override string ToString()
        {
            return "KnownField: " + Name + " Source: " + Source;
        }
        public class Resolvable
        {
            public KnownField KnownField;
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
            public Type? Type { get; set; }
            public dynamic? Value { get; set; }
            public String? parsedValue { get; set; }
            public String TypeName => KnownField?.TypeName ?? Type?.Name ?? "Null";

            public Resolvable(Engine engine, KnownField knownField)
            {
                this.KnownField = knownField;
                this.Engine = engine;
            }

            public dynamic? Resolve()
            {

                var method = this.GetType().GetProperty(KnownField.Source, BindingFlags.NonPublic | BindingFlags.Instance);

                dynamic resolvedValue;
                if (method != null)
                {
                    resolvedValue = method.GetGetMethod(true)?.Invoke(this, null)??throw new NullReferenceException();

                }
                else
                {
                    try
                    {
                        resolvedValue = Engine.interpreter.Eval(KnownField.Source);
                        //Log.Debug($"{this.KnownField.Name } resolved to {resolvedValue}");
                    }
                    catch (Exception)
                    {
                        Log.Error("failed interpreting Field: " + KnownField);
                        throw;
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
                return ((JArray?)this.Engine.root["Risks"])?.ToObject<List<dynamic>>()?.Find(risk => risk["RiskId"] == riskId)?? throw new NullReferenceException();
            }

            private JObject GetCurrentVehicleRisk()
            {
                var riskId = ((Entity.Vehicle)this.Engine.interpreter.Eval("Vehicle"))?["RiskId"]??throw new NullReferenceException();

                var risk = GetRisk(riskId);
                
                return risk;
            }

            private decimal BaseRateFactors
            {
                get {
                    return decimal.Parse(this.Engine.getTable($"{this.Engine.interpreter.Eval("CoverageCode")}.BaseRateFactors")[0]["Base Rate Factor"]);
                }
            }
            private int VehicleClassCode
            {
                get
                {

                    var classCode = GetCurrentVehicleRisk()?["VehicleClassCode"]?.ToObject<int>() ?? 0;
                    return classCode;
                }
            }

            
            private int? Territory
            {
                get
                {
                    var risk = GetCurrentVehicleRisk();

                    var locationID = risk?["OutputMetaDataEntity"]?["VehicleDriverLocation"]?["LocationId"];
                    if (locationID == null)
                    {
                        //Log.Debug("Location ID null " + risk.ToString());
                        return null;
                    }
                    var zip = GetSQLService().executeQuery($"SELECT PostalCode FROM [location].[Address] where Id = {locationID}")[0]["PostalCode"];
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
                    throw new NotImplementedException();
                    //var org = this.Engine.root.Organization;
                    //int score = org.InsuranceScore ?? 998;


                    //int fleetSize = this.Engine.root.GetVehicles().Count;

                    //String type = org.TypeName;


                    //foreach (Dictionary<String, String> row in Engine.getTable("CT.2"))
                    //{

                    //    if (Functions.parseRatingFactorNumericalValues(row["Fleet Size Lower Bound"]) <= fleetSize &&
                    //        Functions.parseRatingFactorNumericalValues(row["Fleet Size Upper Bound"]) >= fleetSize &&
                    //        Functions.parseRatingFactorNumericalValues(row["Insurance Score Lower Bound"]) <= score &&
                    //        Functions.parseRatingFactorNumericalValues(row["Insurance Score Upper Bound"]) >= score &&
                    //        row["Organization Type"] == type
                    //        )
                    //    {
                    //        return row["Insurance Score Tier"];
                    //    }
                    //}
                    //throw new KeyNotFoundException($"No Score tier found for   Insurrance Score: [[{score}]  -  Org Type: [{type}]  -  Fleet Size: [{fleetSize}]");

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
            
            private decimal DriverRatingFactor
            {
                get
                {
                    return 1;
                }
            }
            private decimal FacultativeReInsuranceAdjustmentFactor
            {
                get
                {
                    return 1;
                }
            }
            private decimal ExperienceRatingFactor
            {
                get
                {
                    return 1;
                }
            }
            private decimal RenewalRateCapFactor
            {
                get
                {
                    return 1;
                }
            }
            private int DrivertoVehicleRatio
            {
                get
                {
                    
                    var VehicleCount = this.Engine.root.GetVehicles().Count; 
                    var DriverCount = this.Engine.root.GetDrivers().Count;

                    return GetRatio(DriverCount, VehicleCount);




                }
            }
            public static int GetRatio(int a, int b)
            {
                return b == 0 ? Math.Abs(a) : GetRatio(b, a % b);
            }

            private string State
            {
                get
                {
                    this.parsedValue = this.Engine.root.GoverningStateName;
                    return this.Engine.root.GoverningStateCode;
                }
            }


        }
    }   
    
}
