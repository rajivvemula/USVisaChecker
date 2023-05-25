using ApolloTests.Data.Entities;
using ApolloTests.Data.Entities.Coverage;
using ApolloTests.Data.Entities.Risk;
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
            engine.LoadOC(engine.ObjectContainer);
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
            public List<string>? parsedValue { get; set; } = new();
            public String TypeName => KnownField?.TypeName ?? Type?.Name ?? "Null";
            public Exception? Error { get; set; }

            public Resolvable(Engine engine, KnownField knownField)
            {
                this.KnownField = knownField;
                this.Engine = engine;
            }

            public dynamic? Resolve()
            {
                try
                {
                    var method = this.GetType().GetProperty(KnownField.Source, BindingFlags.NonPublic | BindingFlags.Instance);

                    dynamic resolvedValue;
                    if (method != null)
                    {
                        resolvedValue = method.GetGetMethod(true)?.Invoke(this, null) ?? throw new NullReferenceException();

                    }
                    else
                    {
                        try
                        {
                            resolvedValue = Engine.interpreter.Eval(KnownField.Source);
                            //Log.Debug($"{this.KnownField.Name } resolved to {resolvedValue}");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"failed interpreting Field: {KnownField}\n", ex);
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

                    if (TypeName == "Boolean")
                    {
                        if (Value is string)
                        {
                            if (Value == "Yes" | Value == "T")
                            {
                                parsedValue.Add("True");
                                parsedValue.Add("T");
                                parsedValue.Add("Yes");
                                parsedValue.Add("Y");

                            }
                            else if (Value == "No" | Value == "F")
                            {
                                parsedValue.Add("False");
                                parsedValue.Add("F");
                                parsedValue.Add("No");
                                parsedValue.Add("N");



                            }
                            else if (Boolean.TryParse(Value, out bool val))
                            {
                                parsedValue.Add(val ? "Yes" : "No");
                                parsedValue.Add(val ? "T" : "F");
                                parsedValue.Add(val ? "True" : "False");
                                parsedValue.Add(val ? "Y" : "N");

                            }

                        }
                        else
                        {
                            parsedValue.Add(((bool)Value) ? "Yes" : "No");
                            parsedValue.Add(((bool)Value) ? "T" : "F");
                            parsedValue.Add(((bool)Value) ? "True" : "False");
                            parsedValue.Add(((bool)Value) ? "Y" : "N");


                        }
                    }

                    return Value;
                }
                catch(Exception ex)
                {
                    this.Error = ex;
                    throw;
                }
            }

            private VehicleRisk GetCurrentVehicleRisk()
            {
                return this.Engine.interpreter.Eval<VehicleRisk>("VehicleRisk"); 
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

                    var classCode = GetCurrentVehicleRisk().ClassCode?.ToObject<int>() ?? 0;
                    return classCode;
                }
            }

            
            private int Territory
            {
                get
                {
                    var risk = GetCurrentVehicleRisk();
                    var locationID = (risk.OutputMetadata as OutputMetadataVehicle).VehicleDriverLocation.LocationId??throw new NullReferenceException($"Vehicle Risk: {risk.Id}\n LocationId returned null\n");
                    var address = this.Engine.GetContextSQL().Address.Find(locationID);

                    var zip = address.PostalCode;
                    var data = Engine.getTable("TT.1");

                    var row = data.Find(row => row["Zip Code"] == zip);
                    return int.Parse(row["Territory"]);
                   
                }
            }

            private String InsuranceScoreTier
            {
                get
                {
                    int score = this.Engine.root.InsuranceScore;


                    int fleetSize = this.Engine.root.GetVehicles().Count;

                    String type = this.Engine.root.BusinessInformation.BusinessTypeName;


                    foreach (Dictionary<String, String> row in Engine.getTable("CT.2"))
                    {

                        if (Engine.parseRatingFactorNumericalValues(row["Fleet Size Lower Bound"]) <= fleetSize &&
                            Engine.parseRatingFactorNumericalValues(row["Fleet Size Upper Bound"]) >= fleetSize &&
                            Engine.parseRatingFactorNumericalValues(row["Insurance Score Lower Bound"]) <= score &&
                            Engine.parseRatingFactorNumericalValues(row["Insurance Score Upper Bound"]) >= score &&
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
                        int dob = int.Parse(driver.Driver.DateOfBirth.ToString("yyyyMMdd"));
                        int age = (now - dob) / 10000;
                        if (age < 55)
                        {
                            continue;
                        }

                        bool defensiveDriving = driver.OutputMetadata.GetQuestionResponse("IL-DefensiveDriving")?.ToObject<bool?>() ?? false;
                        bool LastYearViolation = driver.OutputMetadata.GetQuestionResponse( "IL-LastYearViolation")?.ToObject<bool?>() ?? false;
                        bool Last3YearsLicenseSuspended = driver.OutputMetadata.GetQuestionResponse( "IL-Last3YearsLicenseSuspended")?.ToObject<bool?>() ?? false;


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
                    this.parsedValue.Add(this.Engine.root.GoverningStateName);
                    return this.Engine.root.GoverningStateCode;
                }
            }

            private string MotorCarrierFilingType
            {
                get
                {
                    if(bool.TryParse(Engine.root.GetQuestionResponse("FmscaOperating"), out var fmsca))
                    {
                        if(fmsca && bool.Parse(Engine.root.GetQuestionResponse("USDOT")))
                        {
                            return "Multi-State or Federal (ICC/FHWA)";
                        }
                        
                    }
                    
                    var singleStateTriggers = new List<string>() { "IL-Authority", "SC-Authority", "TXAuth", "CaliOperatingAuth", "PUC" };
                    foreach (var alias in singleStateTriggers)
                    {
                        if (bool.TryParse(alias, out var answer))
                        {
                            if (answer)
                                return "Single State";

                        }
                    }
                    return "None";
                    
                }
            }

            private int[] GetWorkLossBenefitLimit()
            {
                var limit = this.Engine.interpreter.Eval<Limit>("Limit");
                if (IsFPBCombined())
                {
                    return new int[] { 0, 0 };
                }
                else
                {
                    var displayName = limit.GetLimitValueDisplayName(1);

                    return displayName.Split('/').Select(it => int.Parse(it)).ToArray();
                }
            }
            private bool IsFPBCombined()
            {
                var limit = this.Engine.interpreter.Eval<Limit>("Limit");
                return limit.SelectedLimitName.Contains("Combined");
            }
            private int CombinationAmount
            {
                get
                {
                    var limit = this.Engine.interpreter.Eval<Limit>("Limit");
                    if (IsFPBCombined())
                    {
                        return limit.SelectedLimits[0];
                    }
                    else
                    {
                        return 0;
                    }

                }
            }

            private int WorkLossBenefitMonthly => GetWorkLossBenefitLimit()[0];

            private int WorkLossBenefitTotal => GetWorkLossBenefitLimit()[1];

            private string VehicleType
            {
                get
                {
                    string finalTypeConsidered;
                    var vehicle = this.GetCurrentVehicleRisk().Vehicle;

                    int category = vehicle.BodyCategoryTypeId;
                    int subCategory = vehicle.BodySubCategoryTypeId;
                    decimal GVW = decimal.Parse(vehicle.GrossVehicleWeight);

                    if (
                        (category == (int)VehicleTypeEnum.Car && subCategory != (int)BodySubCategoryTypeEnum.CSSTLI)
                        || (((int)BodySubCategoryTypeEnum.CPSPick == subCategory || (int)BodySubCategoryTypeEnum.TRKPick == subCategory) && GVW <= 10000)
                       )
                    {
                        finalTypeConsidered = "PPT";
                    }
                    else
                    {
                        finalTypeConsidered = "TTT";
                    }
                    return finalTypeConsidered;
                }
            }
            private string CoverageUM_UIM
            {
                get
                {
                    var limit = this.Engine.interpreter.Eval<Limit>("Limit");
                    if(limit.CoverageType.TypeName.Contains("uninsured", StringComparison.InvariantCultureIgnoreCase)) {
                        return "UM";
                    }
                    if (limit.CoverageType.TypeName.Contains("underinsured", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return "UIM";
                    }
                    else throw new NotImplementedException(limit.CoverageType.TypeName);
                }
            }
        }
    }   
    
}
