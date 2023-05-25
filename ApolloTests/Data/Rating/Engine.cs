using DynamicExpresso;
using Newtonsoft.Json;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using ApolloTests.Data.Entities;
using ApolloTests.Data.Entities.Coverage;
using ApolloTests.Data.Entities.Reference;
using NUnit.Framework;

namespace ApolloTests.Data.Rating
{
    public class Engine: BaseEntity
    {
        private static readonly dynamic Factors = JsonConvert.DeserializeObject<JObject>(new StreamReader("Data/Rating/Factors.json").ReadToEnd())?? throw new NullReferenceException();
        private static readonly dynamic KnownFields =  JsonConvert.DeserializeObject<JObject>(new StreamReader( $"Data/Rating/KnownFields.json").ReadToEnd()) ?? throw new NullReferenceException();
        //private static JObject PersistedData = JsonConvert.DeserializeObject<JObject>(new StreamReader( @"StepDefinition\Rating\persistedData.json").ReadToEnd()) ?? throw new NullReferenceException();
        private static JObject CoverageAlgorithms = JsonConvert.DeserializeObject<JObject>(new StreamReader( @"Data/Rating/CoverageAlgorithms.json").ReadToEnd()) ?? throw new NullReferenceException();


        /// <summary>
        ///  Interpreter used to evaluate strings of code <br/>
        ///  This Interpreter will be used dynamically changing it's variables to accomodate current context. <br/>
        ///  for example, Vehile will be set multiple times depending on current vehicle under rating. <br/>
        /// </summary>
        public Interpreter interpreter { get; }
        public RatingManualService Manual { get; }
    
        //properties public in order to be mentioned in the json files
        public Quote root { get; set; }
        public string GoverningStateCode { get; set; }
        public DateTimeOffset EffectiveDate { get; set; }
        public Dictionary<Exception, string> factorErrors { get; set; }
        public RatingOutput LatestOutput { get; set; }

        /// <summary>
        /// Rating Engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// constructed with a root object which in the future could be a Policy or Quote. <br/><br/>
        /// <param name="CoverageCode"> To be removed in the future, (iteration through all policy coverages need to be implemented)</param>
        /// </summary>
        public Engine(ObjectContainer OC): base(OC)
        {
            this.interpreter = new Interpreter();
            Manual = OC.Resolve<RatingManualService>();
            interpreter.Reference(typeof(JObject));
            interpreter.Reference(typeof(AlgorithmAssignment));
            interpreter.Reference(typeof(Limit));
            interpreter.Reference(typeof(Quote));
            interpreter.Reference(typeof(BusinessInformation));
            interpreter.Reference(typeof(CoverageType));
            interpreter.Reference(typeof(Line));
            interpreter.Reference(typeof(SubLine));
            interpreter.Reference(typeof(Policy));
        }
       


        /// <summary>
        /// Run the engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// </summary>
        public RatingOutput Run(Quote quote)
        {
            this.root = quote;
            this.GoverningStateCode = quote.GoverningStateCode;
            this.EffectiveDate = quote.Tether.EffectiveDate;
            this.factorErrors = new Dictionary<Exception, string>();
            interpreter.SetVariable("root", quote);

            LatestOutput = new RatingOutput(ObjectContainer);
            var vehicles = root.GetVehicles();
            var limits = root.getLimits();
            foreach (var limit in limits)
            {
                if (limit.GetCoverageType().calculatedPerRisk)
                {
                    foreach (var vehicle in vehicles)
                    {
                        interpreter.SetVariable("Vehicle", vehicle.Vehicle);
                        interpreter.SetVariable("VehicleRisk", vehicle);

                        if (vehicle.Vehicle.IsNonPowered() && limit.GetCoverageType().IsNonPoweredVehicle_Unapplicable())
                        {
                            continue;
                        }
                        
                        var vehicleLimit = limit.GetCoverageType().isVehicleLevel ? limit.RiskCoverages?.Find(it => it.RiskId == vehicle.Vehicle.RiskId) : limit;
                        if(vehicleLimit!=null)
                        {
                            var rateResults = RunForLimit(vehicleLimit);
                            rateResults.Vehicle = vehicle.Vehicle;
                            LatestOutput.Results.Add(rateResults);
                        }                        
                    }
                }
                else
                {
                    interpreter.SetVariable("Vehicle", null);
                    var rateResults = RunForLimit(limit);
                    LatestOutput.Results.Add(rateResults);

                }


            }
            if(factorErrors.Any())
            {
               var errors = new List<string>();
                foreach(var err in factorErrors)
                {
                    //errors.Add($"Factor: {err.Value} \nerror: {err.Key.Message}\n {err.Key.InnerException.Message} \n {err.Key.StackTrace} \n {err.Key.InnerException.StackTrace}");
                    errors.Add($"Factor: {err.Value} \nerror: {err.Key}");

                }
                Log.Info(LatestOutput);
                LatestOutput.generateReport();
                throw new Exception(string.Join("\n\n", errors));
            }
            return LatestOutput;
        }
        /// <returns>
        /// Returns specified table from the Rating Manual
        /// </returns>
        public List<Dictionary<String, String>> getTable(String tableName)
        {
            if (!tableName.Contains('.'))
            {
                return Manual.GetAlorithm(tableName);
            }
            return Manual.GetTable(tableName, GoverningStateCode, this.EffectiveDate.ToString("d")).ToList();
        }

        private RatingResult RunForLimit(Limit limit)
        {
            var coverageType = limit.GetCoverageType();
            Log.Debug($"Current Coverage: {coverageType.TypeName}");

            interpreter.SetVariable("Limit", limit);
            AlgorithmAssignment algorithmAssignment = getAlgorithmAssignment(limit.GetCoverageType(), KnownField.GetKnownField("Class Code").Resolve(this)?.ToString()??throw new NullReferenceException());
            interpreter.SetVariable("AlgorithmAssignment", algorithmAssignment);
            string? coverageCode = algorithmAssignment?.CoverageCode;
            /*                    if (string.IsNullOrWhiteSpace(coverageCode))
                                {
                                    continue;
                                }*/
            coverageCode.NullGuard();
            interpreter.SetVariable("CoverageCode", coverageCode);

            var factors = loadResolvedAlgorithmFactors(coverageCode);

            decimal premium = 0;

            List<Dictionary<string, string>> algorithmFormula = getTable(coverageCode);
            for (int i = 0; i < algorithmFormula.Count; i++)
            {
                
                var row = algorithmFormula[i];
                var prevRow = (i == 0) ? null : algorithmFormula[i - 1];
                var nextRow = (i >= algorithmFormula.Count - 1) ? null : algorithmFormula[i + 1];
                var nextnextRow = (i >= algorithmFormula.Count - 2) ? null : algorithmFormula[i + 2];

                string operation = row["Operation"];
                string factorName = row["Rating Factor"];

                if (string.IsNullOrWhiteSpace(operation) && string.IsNullOrWhiteSpace(factorName))
                {
                    continue;
                }

                if (operation == "Round [0]")
                {
                    premium = Math.Round(premium, 0);
                    continue;
                }
                else if (operation.Trim() == "=")
                {
                    var _factor = new Factor(factorName, new string[] { factorName }, new KnownField[0]);
                    _factor.LoadOC(ObjectContainer);
                    _factor.displayOnly = true;
                    var _resolvable = _factor.GetResolvable(this);
                    _resolvable.Value = premium;
                    _resolvable.parsedValue = premium.ToString("C0");
                    _resolvable.FullName = factorName;
                    _resolvable.IndexOnFormula = i;
                    factors.Add(_resolvable);    
                    continue;
                }

                Factor.Resolvable factor;
                try
                {
                    factor = factors.First(factor => factor.FullName == $"{coverageCode}.{factorName}" || factor.FullName == factorName);
                    factor.IndexOnFormula = i;

                }
                catch (Exception ex)
                {
                    Log.Critical($"Formula Row=> {JObject.FromObject(row)}");
                    throw new Exception($"couldn't find factor {factorName} in Factors.json", ex);

                }

                if( factor.Factor.Condition!=null && this.interpreter.Eval<bool>(factor.Factor.Condition)==false)
                {
                    Log.Info($"skipping factor {factor.FullName} because condition resolved to false {factor.Factor.Condition}");
                    continue;
                }
                if (factor.Error!=null)
                {
                    Log.Info($"skipping factor {factor.FullName} due to errors resolving it");
                    continue;
                }

                decimal factorValue = factor.Value??throw new NullReferenceException("Factor's value can't be null");

                if (string.IsNullOrWhiteSpace(operation) || operation=="+")
                {
                    premium += factorValue;
                }
                else if (operation.ToUpper() == "X" || operation=="*")
                {
                    premium = premium * factorValue;
                }
                else if (operation == "Maximum")
                {
                    //we're computing next row now
                    i++;
                    string factorNameNext = nextRow["Rating Factor"];
                    try
                    {
                        var factorNext = factors.First(factor => factor.FullName == $"{coverageCode}.{factorNameNext}" || factor.FullName == factorNameNext);
                        factorNext.IndexOnFormula = i;
                        premium += Math.Max(factorValue, factorNext.Value ?? throw new NullReferenceException());

                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error finding next row factor {factorNameNext} in the list of factors \n {Log.stringify(factors.Select(it => it.FullName))} \n formula: \n{Log.stringify(algorithmFormula)}", ex);
                    }
                }

                else
                {
                    throw new ArgumentException($"Operation: {operation} is not being handled in Data.Rating.Engine.Run()");
                }
                if(factorName== "Policy Term Factor")
                {
                    factor.parsedValue = $"TermFactorPremium: {premium:0}";
                }
                factor.CurrentPremium = premium;

            }
            var rateResults = new RatingResult() { CoverageCode = coverageCode, CoverageName = coverageType.TypeName };
            rateResults.Factors = factors;
            rateResults.TotalPremium = premium;
            rateResults.Factors = rateResults.Factors.OrderBy(it => it.IndexOnFormula).ToList();
            return rateResults;
        }

        /// <summary>
        /// The Following Factors will not be calculated, they are entered by the engine as it runs
        /// </summary>
        private List<string> non_factors = new List<string>()
        {
            "Manual Basic Limits Premium",
            "Manual Premium",
            "Full Term Premium",
            "Written Premium",
            "Rating Stated Value",
            "First Party Benefits premium"
        };
        /// <summary>
        /// Any factor in this dictionary will only be calculated once and will be reused across the whole policy
        /// </summary>
        private readonly Dictionary<string, Factor.Resolvable?> CrossPolicyFactors = new Dictionary<string, Factor.Resolvable?>() { { "Driver Rating", null } }; 
        /// <summary>
        /// Finds all Known Field's values in the Apollo System
        /// </summary>
        private List<Factor.Resolvable> loadResolvedAlgorithmFactors(String CoverageCode)
        {

            var algorithmPage = getTable(CoverageCode);


            var factors = new List<Factor.Resolvable>();
            //Iterate through every factor in the algorithm and get all of it's known KnownFields' value
            foreach (var row in algorithmPage)
            {
                
                var factor = row["Rating Factor"];
                if (string.IsNullOrWhiteSpace(factor) || non_factors.Contains(factor))
                {
                    continue;
                }
                Factor factorObj= Factor.GetFactor(factor, ObjectContainer);
                

                
                //if factor exists in the CrossPolicyFactors dictionary, load it into resolvableObj and if it's not null (meaning it was loaded), it'll be used
                if (CrossPolicyFactors.ContainsKey(factor) &&  CrossPolicyFactors[factor] is var resolvableObj && resolvableObj != null)
                {
                    resolvableObj.FullName= factor;
                    factors.Add(resolvableObj);
                    continue;
                }

                var resolvable = factorObj.GetResolvable(this);

                if (factorObj.Condition != null)
                {
                    factorObj.ConditionResolution = this.interpreter.Eval<bool>(factorObj.Condition);

                    if (!factorObj.ConditionResolution ?? true)
                    {
                        resolvable.FullName = factor;
                        factors.Add(resolvable);
                        continue;


                    }
                    Log.Info($"skipping factor {factor} because condition resolved to false {factorObj.Condition}");
                }

                try
                {
                    resolvable.Resolve();
                    if(CrossPolicyFactors.ContainsKey(factor))
                    {
                        CrossPolicyFactors[factor] = resolvable;
                    }

                }
                catch(Exception ex)
                {

                    Log.Debug($"Error Resolving KnownFields for Factor: {resolvable.FullName} for coverage code: {CoverageCode}");
                    factorErrors.Add(ex, resolvable.FullName);
                    resolvable.Error = ex;
                }
                finally
                {
                    //whether it failed or not, we add it to the factors
                    resolvable.FullName = factor;
                    factors.Add(resolvable);
                }

            }

            foreach(var factor in factors)
            {
                if(factor.KnownFields!=null && factor.KnownFields.Any() && factor.Factor?.ConditionResolution != false && factor .Value==null)
                {
                    var ex = new Exception("The factor didn't resolve\n", factor.Error);
                    factorErrors.Add(ex, factor.Name);
                    factor.Error = ex;
                }
            }

            return factors;
            
        }


        public AlgorithmAssignment getAlgorithmAssignment(CoverageType coverageType, string ClassCode)
        {
            AlgorithmAssignment? result = null;

            if(string.IsNullOrWhiteSpace(ClassCode) || ClassCode == "0")
            {
                return new AlgorithmAssignment() { CoverageCode = getDefaultCoverageCode(coverageType) };
            }
            foreach(var row in getTable("AT.1"))
            {
                if(row["Class Code"] == ClassCode)
                {
                    result =  new AlgorithmAssignment()
                    {
                        ClassCode = row["Class Code"],
                        DriverRatingPlan = row["Driver Rating Plan"],
                        IncreasedLimitGroup = row["Increased Limit Group"],
                        RatingGroup = row["Rating Group"]
                    };

                    if (row.TryGetValue(coverageType.TypeName, out var value))
                    {
                        result.CoverageCode = value;

                    }
                    else
                    {
                        foreach(var possibleName in CoverageType.Persisted)
                        {
                            if (possibleName.Value == coverageType.TypeName && row.TryGetValue(possibleName.Key, out value))
                            {
                                result.CoverageCode = value;

                            }
                        }

                        if(string.IsNullOrEmpty(result.CoverageCode))
                        {
                            result.CoverageCode = getDefaultCoverageCode(coverageType);
                        }
                    }
                   
                }
                
            }

            
            if(string.IsNullOrWhiteSpace(result?.CoverageCode))
            {
                throw new KeyNotFoundException($"Coverage Type: [{coverageType.TypeName}] Class Code: [{ClassCode}] did not match any Algorithms");

            }
            return result;
        }

        /// <returns>
        ///  the corresponding algorithm code
        /// </returns>
        /// 
        private string? getDefaultCoverageCode(CoverageType coverageType)
        {
            var DefaultCoverageAlgorithms = (JObject?)CoverageAlgorithms["All"]?.DeepClone()?? throw new NullReferenceException();
            DefaultCoverageAlgorithms.Merge(CoverageAlgorithms?[GoverningStateCode]?? throw new NullReferenceException($"Couldn't find entry in Data/Rating/CoverageAlgorithms.json for {GoverningStateCode}"));

            JToken? coverageCode = null;
            if (DefaultCoverageAlgorithms?.TryGetValue(coverageType.TypeName, out coverageCode) ?? false)
            {
                return coverageCode?.ToString();
            }
            
            throw new Exception($"couldn't find algorithm Assignment for Coverage Type: {coverageType.TypeName} on state {GoverningStateCode}\n please check Data/Rating/CoverageAlgorithms.json");
            
        }
        public static int? parseRatingFactorNumericalValues(String value)
        {
            if (value.Contains("+"))
            {
                return int.MaxValue;
            }
            else if (int.TryParse(value, out int intValue))
            {
                return intValue;
            }
            else
            {
                return null;
            }
        }

        public class AlgorithmAssignment
        {
            public string? ClassCode { get; set; }
            public string? RatingGroup { get; set; }
            public string? DriverRatingPlan { get; set; }
            public string? IncreasedLimitGroup { get; set; }
            public string? CoverageCode { get; set; }

        }



    }
}
