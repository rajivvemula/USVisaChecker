using DynamicExpresso;
using Newtonsoft.Json;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using ApolloTests.Data.Entities;
using ApolloTests.Data.Entities.Coverage;
using ApolloTests.Data.Entities.Reference;

namespace ApolloTests.Data.Rating
{
    public class Engine: BaseEntity
    {
        private static readonly dynamic Factors = JsonConvert.DeserializeObject<JObject>(new StreamReader("Data/Rating/Factors.json").ReadToEnd())?? throw new NullReferenceException();
        private static readonly dynamic KnownFields =  JsonConvert.DeserializeObject<JObject>(new StreamReader( $"Data/Rating/KnownFields.json").ReadToEnd()) ?? throw new NullReferenceException();
        //private static JObject PersistedData = JsonConvert.DeserializeObject<JObject>(new StreamReader( @"StepDefinition\Rating\persistedData.json").ReadToEnd()) ?? throw new NullReferenceException();
        private static JObject CoverageAlgorithms = JsonConvert.DeserializeObject<JObject>(new StreamReader( @"Data/Rating/CoverageAlgorithms.json").ReadToEnd()) ?? throw new NullReferenceException();

        /// <returns>
        /// Returns specified table from the Rating Manual
        /// </returns>
        public static List<Dictionary<String, String>> GetAlorithm(String tableName)
        {
            
            var table = Functions.ParseExcel(@$"Data\RatingManual\Algorithms\{tableName}.xlsx").ToList();

            return table;
        }
        public static IEnumerable<Dictionary<String, String>> GetTable(String tableName, string stateCode, string? effectiveDate)
        {

            string whereClause;

            int lineId = 7;

            if(string.IsNullOrEmpty(effectiveDate))
            {

                whereClause = $@"WHERE LineId ={lineId} AND 
                                    CarrierPartyId = 4 AND 
                                    StateProv.Code = '{stateCode}' AND
                                    RatingTable.Name = '{tableName}' AND
									RatingTable.Id = (
										Select MAX(RatingTable.Id) 
										FROM [rating].[ReferenceTable] RatingTable
										LEFT JOIN [rating].[ReferenceTableStateProvince] RatingTableState on RatingTable.Id = RatingTableState.ReferenceTableId
                                        LEFT JOIN [location].[StateProvince] StateProv on RatingTableState.StateProvinceId = StateProv.Id
										WHERE LineId ={lineId} AND 
										CarrierPartyId = 4 AND 
										StateProv.Code = '{stateCode}' AND
                                        RatingTable.Name = '{tableName}'
									) ";
            }
            else
            {

                whereClause = $@"WHERE LineId =7 AND 
                                    CarrierPartyId = 4 AND 
                                    StateProv.Code = '{stateCode}' AND
                                    RatingTable.Name = '{tableName}' AND
                                    ('{effectiveDate}' BETWEEN RatingTable.TimeFrom AND RatingTable.TimeTo)";

            }

            var columns = GetSQLService().executeQuery($@"SELECT tableColumn.AttributeName, tableColumn.AttributeColumn
                                            FROM [rating].[ReferenceTable] RatingTable
                                            LEFT JOIN [rating].[ReferenceTableStateProvince] RatingTableState on RatingTable.Id = RatingTableState.ReferenceTableId
                                            LEFT JOIN [location].[StateProvince] StateProv on RatingTableState.StateProvinceId = StateProv.Id
                                            LEFT JOIN [rating].ReferenceTableMap tableColumn on RatingTable.Id = tableColumn.ReferenceTableId
                                            {whereClause} 
                                            ;");

            var sortOrderColumnRow = columns.Find(it => ((String)it["AttributeName"]).Contains("SortOrder"));

            
            var attributes = GetSQLService().executeQuery($@"SELECT TableAttributes.*
                                                FROM [rating].[ReferenceTable] RatingTable
                                                LEFT JOIN [rating].[ReferenceTableStateProvince] RatingTableState on RatingTable.Id = RatingTableState.ReferenceTableId
                                                LEFT JOIN [location].[StateProvince] StateProv on RatingTableState.StateProvinceId = StateProv.Id
                                                LEFT JOIN [rating].[ReferenceTableAttribute] TableAttributes on RatingTable.Id = TableAttributes.ReferenceTableId
                                                {whereClause} 
                                                ;");
            if(!columns.Any() || !attributes.Any())
            {
                throw new Exception("Table: "+ tableName + $" was not found for parameters: {whereClause}. ");
            }

            foreach (var row in attributes)
            {
                var rowDict = new Dictionary<string, string>();

                foreach (var column in columns)
                {
                    try
                    {
                        var columnValue = row[column["AttributeColumn"]];
                        var columnName = (String)column["AttributeName"];
                        if (columnName.ToLower().Contains("sortorder"))
                        {
                            continue;
                        }

                        rowDict.Add(columnName, (columnValue is DBNull ? "" : (columnValue is string ? columnValue : columnValue.ToString()) ) ?? "");
                    }
                    catch (Exception)
                    {

                        Log.Error("Row-> " + JObject.FromObject(row));
                        Log.Error("column-> " + column["AttributeColumn"]);
                        Log.Error($"table Name-> : {tableName} Att Name: {column["AttributeName"]} value:{row[column["AttributeColumn"]]} ");
                        throw;
                    }
                }

                yield return rowDict;

            }

        }
        public List<Dictionary<String, String>> getTable(String tableName)
        {
           if(!tableName.Contains('.'))
           {
                return GetAlorithm(tableName);
           }
           return GetTable(tableName, GoverningStateCode, this.EffectiveDate.ToString("d")).ToList();
        }

        /// <summary>
        ///  Interpreter used to evaluate strings of code <br/>
        ///  This Interpreter will be used dynamically changing it's variables to accomodate current context. <br/>
        ///  for example, Vehile will be set multiple times depending on current vehicle under rating. <br/>
        /// </summary>
        public readonly Interpreter interpreter;

        //properties public in order to be mentioned in the json files
        public readonly Quote root;

        public readonly string GoverningStateCode;
        public readonly DateTime EffectiveDate;

        /// <summary>
        /// Rating Engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// constructed with a root object which in the future could be a Policy or Quote. <br/><br/>
        /// <param name="CoverageCode"> To be removed in the future, (iteration through all policy coverages need to be implemented)</param>
        /// </summary>
        public Engine(Quote root): base(root.ContextCosmos)
        {
            this.root = root;
            this.GoverningStateCode = root.GoverningStateCode;
            this.EffectiveDate = root.RatableObject.TimeFrom;
            this.interpreter = new Interpreter();
            interpreter.Reference(typeof(JObject));
            interpreter.Reference(typeof(AlgorithmAssignment));
            interpreter.Reference(typeof(Limit));
            interpreter.Reference(typeof(Quote));
            interpreter.Reference(typeof(BusinessInformation));
            interpreter.Reference(typeof(CoverageType));
            interpreter.Reference(typeof(Line));
            interpreter.Reference(typeof(SubLine));
            interpreter.Reference(typeof(Policy));

            interpreter.SetVariable("root", this.root);

        }

        public List<JObject>? latestResults; 

        /// <summary>
        /// Run the engine to calculate premium using Known Field's values and mapping them to the Rating Manuals. <br/><br/>
        /// </summary>
        public List<JObject> Run()
        {
            latestResults = new List<JObject>();

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
                        vehicleLimit.NullGuard();
                        var rateResults = RunForLimit(vehicleLimit);
                        rateResults.Add("Vehicle", vehicle.Vehicle.ToJObject());
                        latestResults.Add(rateResults);
                    }
                }
                else
                {
                    interpreter.SetVariable("Vehicle", null);
                    var rateResults = RunForLimit(limit);
                    latestResults.Add(rateResults);

                }


            }

            return latestResults;
        }

        private JObject RunForLimit(Limit limit)
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


            var rateResults = new JObject() { { "CoverageCode", coverageCode }, { "CoverageName", coverageType.TypeName } };

            loadResolvedAlgorithmFactors(coverageCode, ref rateResults);
            JObject factors = (JObject)(rateResults["Factors"] ?? throw new NullReferenceException());

            decimal premium = 0;

            List<Dictionary<string, string>> algorithmFormula = getTable(coverageCode);
            for (int i = 0; i < algorithmFormula.Count(); i++)
            {
                
                var row = algorithmFormula[i];
                string operation = row["Operation"];
                string factorName = row["Rating Factor"];

                if (string.IsNullOrWhiteSpace(operation) && string.IsNullOrWhiteSpace(factorName))
                {
                    continue;
                }
                JObject factor;

                if (operation == "Round [0]")
                {
                    premium = Math.Round(premium, 0);
                    continue;
                }
                else if (operation.Trim() == "=")
                {
                    var _factor = new Factor(factorName, new string[] { factorName }, new KnownField[0]);
                    _factor.displayOnly = true;
                    var _resolvable = _factor.GetResolvable(this);
                    _resolvable.Value = premium;
                    _resolvable.parsedValue = premium.ToString("C0");
                    if (factors.ContainsKey(factorName))
                    {
                        factors[factorName] = JObject.FromObject(_resolvable);
                    }
                    else
                    {
                        factors.Add(factorName, JObject.FromObject(_resolvable));
                    }
                    continue;
                }

                try
                {
                    if (factors.ContainsKey($"{coverageCode}.{factorName}"))
                    {
                        factor = (JObject?)factors[$"{coverageCode}.{factorName}"]??throw new NullReferenceException();

                    }
                    else
                    {
                        factor = (JObject?)factors[factorName] ?? throw new NullReferenceException(); 
                    }
                    if (factor == null)
                    {
                        throw new KeyNotFoundException($"Factor name: {factorName} was not found in {rateResults} ");
                    }

                }
                catch (Exception)
                {
                    Log.Critical($"Row=> {JObject.FromObject(row)}");
                    throw Functions.HandleFailure($"couldn't find factor {factorName} in Factors.json");

                }

                decimal factorValue;
                try
                {
                    factorValue = factor["Value"]?.ToObject<decimal?>()?? throw new NullReferenceException();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error parsing factor's value {factor} into decimal \n", ex);
                }

                if (string.IsNullOrWhiteSpace(operation))
                {
                    premium += factorValue;
                }
                else if (operation.ToUpper() == "X")
                {
                    premium = premium * factorValue;
                }
                else if (operation == "Maximum")
                {
                    var rowNext = algorithmFormula[++i];
                    string factorNameNext = rowNext["Rating Factor"];
                    JObject factorNext;

                    try
                    {
                        if (factors.ContainsKey($"{coverageCode}.{factorNameNext}"))
                        {
                            factorNext = (JObject?)factors[$"{coverageCode}.{factorNameNext}"] ?? throw new NullReferenceException();

                        }
                        else
                        {
                            factorNext = (JObject?)factors[factorNameNext] ?? throw new NullReferenceException();
                        }
                        if (factor == null)
                        {
                            throw new KeyNotFoundException($"Factor name: {factorNameNext} was not found in {rateResults} ");
                        }


                    }
                    catch (Exception)
                    {
                        Log.Error($"couldn't find factor {factorNameNext} in rate results {rateResults}");
                        throw;
                    }
                    decimal factorValueNext;
                    try
                    {
                        factorValueNext = factorNext["Value"]?.ToObject<decimal>()?? throw new NullReferenceException();
                    }
                    catch (Exception)
                    {
                        Log.Error($"Error parsing factor name: {factorNameNext} value: {factorNext?["Value"] ?? null} into decimal ");
                        throw;
                    }
                    premium += Math.Max(factorValue, factorValueNext);
                }

                else
                {
                    throw new ArgumentException($"Operation: {operation} is not being handled in Data.Rating.Engine.Run()");
                }
                if(factorName== "Policy Term Factor")
                {
                    factor["parsedValue"] = $"TermFactorPremium: {premium:0}";
                }
                factor.Add("currentPremium", premium);

            }
            rateResults.Add("TotalPremium", premium);

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
            "Rating Stated Value"
        };
        /// <summary>
        /// Any factor in this dictionary will only be calculated once and will be reused across the whole policy
        /// </summary>
        private readonly Dictionary<string, Factor.Resolvable?> CrossPolicyFactors = new Dictionary<string, Factor.Resolvable?>() { { "Driver Rating", null } }; 
        /// <summary>
        /// Finds all Known Field's values in the Apollo System
        /// </summary>
        private void loadResolvedAlgorithmFactors(String CoverageCode, ref JObject rateResult)
        {

            var algorithmPage = getTable(CoverageCode);


            var result = new JObject();
            
            //Iterate through every factor in the algorithm and get all of it's known KnownFields' value
            foreach (var row in algorithmPage)
            {
                
                var factor = row["Rating Factor"];
                if (string.IsNullOrWhiteSpace(factor) || non_factors.Contains(factor))
                {
                    continue;
                }
                Factor factorObj= Factor.GetFactor(factor);
               
                //if factor exists in the CrossPolicyFactors dictionary, load it into resolvableObj and if it's not null (meaning it was loaded), it'll be used
                if(CrossPolicyFactors.ContainsKey(factor) &&  CrossPolicyFactors[factor] is var resolvableObj && resolvableObj != null)
                {
                    result.Add(factor, resolvableObj.ToJObject());
                    continue;
                }

                var resolvable = factorObj.GetResolvable(this);
                try
                {
                    var resolvedObj = resolvable.Resolve();
                    result.Add(factor, resolvedObj);
                    if(CrossPolicyFactors.ContainsKey(factor))
                    {
                        CrossPolicyFactors[factor] = resolvable;
                    }

                }
                catch(Exception)
                {

                    Log.Debug($"Error Resolving KnownFields for Factor: {resolvable.Name} for coverage code: {CoverageCode}");
                    throw;
                }

            }
            var errors = result.Values().Where(it => it["KnownFields"].Any() && it.Value<decimal?>("Value")==null);
            if (errors.Any())
            {
                throw new Exception("The following factors didn't resolve\n" + Log.stringify(errors));
            }
           
            rateResult.Add("Factors", result);
            
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

        private string? getDefaultCoverageCode(CoverageType coverageType)
        {
            var DefaultCoverageAlgorithms = (JObject?)CoverageAlgorithms["All"]?.DeepClone()?? throw new NullReferenceException();
            DefaultCoverageAlgorithms.Merge(CoverageAlgorithms?[GoverningStateCode]?? throw new NullReferenceException());

            JToken? coverageCode = null;
            if (DefaultCoverageAlgorithms?.TryGetValue(coverageType.TypeName, out coverageCode) ?? false)
            {
                return coverageCode?.ToString();
            }
            
            throw new Exception($"couldn't find algorithm Assignment for Coverage Type: {coverageType.TypeName} on state {GoverningStateCode}\n please check Data/Rating/CoverageAlgorithms.json");
            
        }

        public class AlgorithmAssignment
        {
            public string? ClassCode { get; set; }
            public string? RatingGroup { get; set; }
            public string? DriverRatingPlan { get; set; }
            public string? IncreasedLimitGroup { get; set; }
            public string? CoverageCode { get; set; }

        }
        /// <returns>
        ///  the corresponding algorithm code
        /// </returns>
        /// 

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
    }
}
