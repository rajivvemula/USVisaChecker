using ApolloQA.Data.Entity;
using ApolloQA.Source.Driver;
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
    public class Factor
    {
        private static readonly dynamic Factors = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine($"{Source.Driver.Setup.SourceDir}", "Data/Rating/Factors.json")).ReadToEnd());

        public string Name;
        public List<string> NameUI;
        public List<KnownField> KnownFields;
        public bool CustomCalculation;
        public readonly string? source;
        public string? TableName;
        public bool displayOnly = false;


        public Factor(string name, IEnumerable<string> nameUI, IEnumerable<KnownField> knownFields, bool? CustomCalculation=false, string? source =null, string? tableName=null)
        {
            this.Name = name;
            this.NameUI = nameUI.ToList();
            this.KnownFields = knownFields.ToList();
            this.CustomCalculation = CustomCalculation ?? false;
            this.source = source;
            this.TableName = tableName;
        }
        public static Factor GetFactor(string name)
        {
            var _factor = GetFactors().Find(it => it.Name == name);

            if (_factor == null) { throw new KeyNotFoundException($"Factor: {name} did not exist in  DataFiles/Rating/Factors.json"); }

            return _factor;


        }

        public static List<Factor> GetFactors()
        {
            var _factors = new List<Factor>();
                foreach (var factor in Factors)
                {
                    if (factor.Value.KnownFields == null) { throw new KeyNotFoundException($"Factor: \n{factor}\n did not have source property in DataFiles/Rating/Factors.json"); }

                    _factors.Add(new Factor(factor.Name, 
                                            factor.Value.nameUI.ToObject<IEnumerable<string>>(), 
                                            ((JArray)factor.Value.KnownFields).Select(it=>KnownField.GetKnownField(it.ToString())),
                                            (bool?)factor.Value.CustomCalculation,
                                            (string?)factor.Value.source,
                                            (string?)factor.Value?.tableName
                                            ));

                }
            
            return _factors;
           
        }

        public Resolvable GetResolvable(Engine engine)
        {
            return new Resolvable(engine, this);
        }

        public override string ToString()
        {
            return Name;
        }
        public class Resolvable
        {
            private readonly Factor Factor;
            private readonly Engine Engine;
            public List<KnownField.Resolvable> KnownFields;
            public Dictionary<string, string> matchedRow;
            public Dictionary<string, string> matchedNextRow;
            public bool interpolated = false;
            public bool displayOnly => Factor.displayOnly;
            public decimal Value { get; set; }
            public String parsedValue { get; set; }

            public string Name
            {
                get => Factor.Name;
                set
                {
                    if (Factor == null)
                    {
                        Factor.GetFactor(value);
                    }
                }
            }
            public IEnumerable<string> NameUI => Factor.NameUI;

            public bool CustomCalculation => Factor.CustomCalculation;

            public Resolvable(Engine engine, Factor factor)
            {
                this.Factor = factor;
                this.Engine = engine;
            }

            private const string LOWERBOUND = "Lower Bound";
            private const string UPPERBOUND = "Upper Bound";
            private const string INTERPOLATIONUPPERMATCH = "Interpolation Upper Row Match";
            public JObject Resolve()
            {

                loadResolvedKnownFields();

                if (CustomCalculation)
                {
                    var method = this.GetType().GetProperty(Factor.source, BindingFlags.NonPublic | BindingFlags.Instance);


                    if (method == null)
                    {
                        throw new KeyNotFoundException($"Expecting Factor: {Factor.Name} source: {Factor.source} member in this Data.Rating.Factor.cs");
                    }
                    else
                    {
                        this.Value = (decimal)method.GetGetMethod(true).Invoke(this, null);
                    }

                }
                else
                {
                    List<Dictionary<string, string>> factorTable = null;

                    if (this.Factor.TableName != null)
                    {

                        factorTable = this.Engine.getTable(this.Factor.TableName.Replace("@CoverageCode", this.GetAlgorithmAssignment().CoverageCode));
                    }
                    else
                    {
                        factorTable = this.Engine.getTable($"{GetAlgorithmAssignment().CoverageCode}.{Factor.Name}");
                    }

                    //will collect all limit columns to calculate limits that are larger than what's listed in the manual
                    Dictionary<string, List<int>> tableLimits = GetTableLimits(factorTable);

                    for (int rowIndex = 0; rowIndex < factorTable.Count; rowIndex++)
                    {
                        var row = factorTable[rowIndex];

                        Dictionary<string, bool> match = new Dictionary<string, bool>();
                        bool lowerBoundMatch = false;
                        bool upperBoundMatch = false;
                        for (int columnIndex = 0; columnIndex < row.Count; columnIndex++)
                        {
                            KeyValuePair<string, string> column = row.ElementAt(columnIndex);
                            var columnToMatch = column.Key;

                            if (columnToMatch.Contains(LOWERBOUND))
                            {
                                columnToMatch = column.Key.Replace(" " + LOWERBOUND, "");
                            }
                            else if (columnToMatch.Contains(UPPERBOUND))
                            {
                                columnToMatch = column.Key.Replace(" " + UPPERBOUND, "");
                            }

                            if (!column.Key.Contains("Factor"))
                            {
                                var knownField = this.KnownFields.FirstOrDefault(it => it.Name == columnToMatch);

                                if (knownField == null)
                                {
                                    throw new NullReferenceException($"The column [{columnToMatch}] was not matched to any field on Data/Rating/KnownFields.json");
                                }


                                if (knownField.TypeName == "Boolean")
                                {

                                    knownField.parsedValue = ((bool)knownField.Value) ? "Yes" : "No";
                                }
                                else if (knownField.TypeName == "Currency")
                                {
                                    knownField.parsedValue = ((int)knownField.Value).ToString("C0");
                                }
                                if (column.Key.Contains(LOWERBOUND) && knownField.Type != null && (int)knownField.Value >= Functions.parseInt(column.Value))
                                {
                                    lowerBoundMatch = true;
                                }
                                else if (column.Key.Contains(UPPERBOUND))
                                {
                                    var columnValue = column.Value == "+" ? int.MaxValue : Functions.parseInt(column.Value);
                                    var nextRowLowerBound = rowIndex == factorTable.Count - 1 ? int.MinValue : Functions.parseInt(factorTable[rowIndex + 1][columnToMatch + $" {LOWERBOUND}"]);

                                    if (knownField.Type != null && (int)knownField.Value <= columnValue)
                                    {
                                        upperBoundMatch = true;
                                    }
                                    //check for interpolation US 12209
                                    else if (columnValue != int.MaxValue &&
                                            columnValue + 1 != nextRowLowerBound &&
                                            knownField.Type != null && (int)knownField.Value < nextRowLowerBound
                                           )
                                    {

                                        match.Add(INTERPOLATIONUPPERMATCH, true);
                                        upperBoundMatch = true;
                                    }
                                }

                                var columnIsLimit = column.Key.ToLower().Contains("limit");

                               
                                if (lowerBoundMatch || upperBoundMatch)
                                {
                                    match.Add(column.Key, true);

                                    lowerBoundMatch = false;
                                    upperBoundMatch = false;
                                }
                                else if (column.Value != null && (column.Value == knownField.Value?.ToString() || column.Value == knownField.parsedValue))
                                {
                                    match.Add(column.Key, true);
                                }

                                //limits that exceed what's listed in the manual will count the highest limit possible as a match
                                else if (columnIsLimit && tableLimits[column.Key].Count > 0 && int.Parse(string.Join("", column.Value.Where(char.IsDigit))) == tableLimits[column.Key].Max() && ((int)knownField.Value)>tableLimits[column.Key].Max())
                                {
                                    match.Add(column.Key, true);
                                }
                                else
                                {
                                    match.Add(column.Key, false);
                                }

                            }




                        }
                        if (!match.ContainsValue(false))
                        {

                            string factorColName = row.Keys.ToList<string>().Find(column => column.Contains("Factor"));

                            if (factorColName == null)
                            {
                                throw new Exception($"Error finding Factor column in table {GetAlgorithmAssignment().CoverageCode}.{this.Name} \n columns: [{string.Join(", ", row.Keys)}]");
                            }

                            if (match.ContainsKey(INTERPOLATIONUPPERMATCH))
                            {
                                var nextRow = factorTable[rowIndex + 1];

                                this.matchedRow = row;
                                this.matchedNextRow = nextRow;
                                this.interpolated = true;

                                this.Value = (decimal.Parse(row[factorColName]) + decimal.Parse(nextRow[factorColName])) / 2;
                            }
                            else
                            {
                                this.matchedRow = row;
                                if (row[factorColName].Contains('$'))
                                {
                                    this.Value = decimal.Parse(string.Join("", row[factorColName].Where(it => char.IsDigit(it))));

                                }
                                else
                                {
                                    this.Value = decimal.Parse(row[factorColName]);
                                }


                            }


                            break;

                        }


                    }

                    if (this.Value == 0)
                    {
                        this.Value = 1;
                    }
                }

                return JObject.FromObject(this);

            }

            private Dictionary<string, List<int>> GetTableLimits(List<Dictionary<string, string>> factorTable)
            {
                var result = new Dictionary<string, List<int>>();
                var limitColumns = factorTable[0].Where(it => it.Key.ToLower().Contains("limit") && !it.Key.ToLower().Contains("factor")).Select(it => it.Key).ToList();

                if(limitColumns.Count==0)
                {
                    return result;
                }

                limitColumns.ForEach(it => result.Add(it, new List<int>()));

                foreach (var row in factorTable)
                {
                    foreach (var column in limitColumns)
                    {
                        var value = row[column];

                        int.TryParse(string.Join("", value.Where(char.IsDigit)), out int intVal);

                        if(intVal>0)
                        {
                            result[column].Add(intVal);
                        }
                    }

                }
                result = result.Select(it => new KeyValuePair<string, List<int>>(it.Key, it.Value.Distinct().ToList())).ToDictionary(kvp=> kvp.Key, kvp=> kvp.Value);

                return result;

            }

            private void loadResolvedKnownFields()
            {

                this.KnownFields = new List<KnownField.Resolvable>();
                if (this.Factor.KnownFields == null) { throw new KeyNotFoundException($"Factor Name: [{this.Factor}] did not have any known fields in DataFiles/Rating/Factors.json"); }

                foreach (var knownField in this.Factor.KnownFields)
                {
                    KnownField.Resolvable resolvable = knownField.GetResolvable(this.Engine);

                    try
                    {
                        resolvable.Resolve();
                    }
                    catch(Exception ex)
                    {
                        Log.Error($"Error Resolving KnownField {resolvable.Name}");
                        throw ex;
                    }

                    this.KnownFields.Add(resolvable);
                }
            }

            private Engine.AlgorithmAssignment GetAlgorithmAssignment()
            { 
               return (Engine.AlgorithmAssignment)this.Engine.interpreter.Eval("AlgorithmAssignment");
            }
            private decimal BaseRateFactor
            {
                get
                {
                    this.Factor.NameUI.Add($"{GetAlgorithmAssignment().CoverageCode} Base Rate Factor");
                    return decimal.Parse(this.Engine.getTable($"{this.Engine.interpreter.Eval("CoverageCode")}.BaseRateFactors")[0]["Base Rate Factor"]);
                }
            }
            private decimal MinimumRatingValueFactors
            {
                get
                {
                    this.Factor.NameUI.Add($"{GetAlgorithmAssignment().CoverageCode} Minimum Rating Value");
                    var value = this.Engine.getTable($"{this.Engine.interpreter.Eval("CoverageCode")}.MinimumRatingValueFactors")[0]["Minimum Rating Value Factor"];
                    return decimal.Parse(string.Join("", value.Where(it=> Char.IsDigit(it))));
                }
            }
            private decimal VehicleTypeMinimumRatingValueFactor
            {
                get
                {
                    var vehicleType  = (string)this.KnownFields.First(it=> it.Name== "Vehicle Type").Value;
                    
                    var algorithmTable = this.Engine.getTable($"{GetAlgorithmAssignment().CoverageCode}.VehicleType_MinimumRatingValueFactors");

                    var factor = algorithmTable.FirstOrDefault(it => it["Vehicle Type"] == vehicleType)["Minimum Rating Value Factor"];

                    //Log.Debug(factor.Where(char.IsDigit));
                    var minimumValue =  decimal.Parse(string.Join("", factor.Where(char.IsDigit)));

                    var vehicleValue = (decimal)this.KnownFields.First(it => it.Name == "Stated Value").Value;

                    return vehicleValue < minimumValue ? minimumValue : vehicleValue;


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
            private decimal AccidentPreventionFactor
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

                        bool defensiveDriving = driver.GetQuestionResponse(root, "IL-DefensiveDriving") == "true" ? true : false;
                        bool LastYearViolation = driver.GetQuestionResponse(root, "IL-LastYearViolation") == "true" ? true : false;
                        bool Last3YearsLicenseSuspended = driver.GetQuestionResponse(root, "IL-Last3YearsLicenseSuspended") == "true" ? true : false;


                        if (defensiveDriving && !LastYearViolation && !Last3YearsLicenseSuspended)
                        {
                            credit += 0.05M;
                        }

                    }
                    return 1 - (credit / drivers.Count());
                }
            }
            private decimal DriverRatingFactor
            {
                get
                {
                    this.Factor.NameUI.Add($"{this.GetAlgorithmAssignment().DriverRatingPlan} Driver Rating Plan");

                    if(this.GetAlgorithmAssignment().DriverRatingPlan == "For Hire Public")
                    {
                        this.Factor.NameUI.Add("For Hire Driver Rating Plan");
                    }

                    if (this.Engine.root.GetVehicles().Count>=11)
                    {
                        return 1;
                    }
                    else if(this.GetAlgorithmAssignment().DriverRatingPlan == "Unity")
                    {
                        return 1;
                    }

                    var driverFactors = new Dictionary<Driver, Factor.Resolvable>();
                    foreach (var driver in this.Engine.root.GetDrivers())
                    {
                        int points = driver.GetPoints(this.Engine.root, this.GetAlgorithmAssignment().DriverRatingPlan);
                        Log.Debug("Points: " + points);

                        this.Engine.interpreter.SetVariable("Driver", driver);

                        var factor = Factor.GetFactor("Individual Driver Rating Factor").GetResolvable(this.Engine);

                        factor.Resolve();

                        driverFactors.Add(driver, factor);

                    }

                    int powerUnitCount = this.Engine.root.GetVehicles().Count();

                    List<decimal> factors = driverFactors.Select(it => it.Value.Value).ToList<decimal>();

                    decimal aggregateFactor = 0;

                    if (driverFactors.Count()>= powerUnitCount)
                    {

                        for (int i=0; i < powerUnitCount; i++ )
                        {
                            aggregateFactor += factors[i];
                        }
                    }
                    else
                    {
                        aggregateFactor = factors.Sum();

                        int unassignedCount = powerUnitCount - driverFactors.Count();

                        var DT2 = this.Engine.getTable("DT.2");

                        var row = DT2.FirstOrDefault(it => it["Driver Rating Plan"] == this.GetAlgorithmAssignment().DriverRatingPlan);

                        aggregateFactor += decimal.Parse(row["Unassigned Driver Factor"]) * unassignedCount;
                    }

                   
                    if(this.GetAlgorithmAssignment().DriverRatingPlan == "Standard")
                    {
                        return Math.Round((aggregateFactor / Math.Max(powerUnitCount, driverFactors.Count())), 4);

                    }

                    return Math.Round((aggregateFactor / powerUnitCount), 4);
                }
            }
            private decimal FacultativeReInsuranceAdjustmentFactor
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
            private decimal ScheduleRatingFactor
            {
                get
                {
                    string[] CLASSIFICATION_NAMES = new string[] { "CLASSIFICATION", "CLASSIFICATION PECULIARITIES" };
                    string[] EMPLOYEES_NAMES = new string[] { "EMPLOYEES" };
                    string[] EQUIPMENT_NAMES = new string[] {  "EQUIPMENT" };
                    string[] MANAGEMENT_NAMES = new string[] { "MANAGEMENT" };
                    string[] SAFETYORGANIZATION_NAMES = new string[] { "SAFETYORGANIZATION", "SAFETY ORGANIZATION" };

                    List<string[]> categories = new List<string[]>() { CLASSIFICATION_NAMES, EMPLOYEES_NAMES, EQUIPMENT_NAMES, MANAGEMENT_NAMES, SAFETYORGANIZATION_NAMES };

                    var table = this.Engine.getTable("ST.1");
                    string credit = "Maximum Schedule Rating Credit";
                    string debit = "Maximum Schedule Rating Debit";

                    decimal total = 0;

                    foreach (string[] category in categories)
                    {
                        var categoryRow = table.FirstOrDefault(it => category.Contains(it["Schedule Rating Category"]));
                        var categoryBoundaries = new decimal[] { -decimal.Parse(categoryRow[credit].Trim('%').Trim()), decimal.Parse(categoryRow[debit].Trim('%').Trim()) };

                        var systemValue = (decimal)this.Engine.root[category[0]];

                        if (systemValue < categoryBoundaries[0])
                        {
                            total += categoryBoundaries[0];
                        }
                        else if (systemValue > categoryBoundaries[1])
                        {
                            total += categoryBoundaries[1];
                        }
                        else
                        {
                            total += systemValue;
                        }


                    }

                    var totalRow = table.FirstOrDefault(it => it["Schedule Rating Category"] == "TOTAL");

                    var totalBoundaries = new decimal[] { -decimal.Parse(totalRow[credit].Trim('%').Trim()), decimal.Parse(totalRow[debit].Trim('%').Trim()) };

                    if (total < totalBoundaries[0])
                    {
                        total = totalBoundaries[0];
                    }
                    else if (total > totalBoundaries[1])
                    {
                        total = totalBoundaries[1];
                    }



                    return 1+ (total/100);
                }
            }
            private decimal ExperienceRatingFactor
            {
                get
                {
                    var table = this.Engine.getTable("ST.2");
                    var lower = -decimal.Parse(table[0]["Maximum Experience Rating Credit"].Trim('%').Trim());
                    var upper = decimal.Parse(table[0]["Maximum Experience Rating Credit"].Trim('%').Trim());
                    var value = this.Engine.root.ExperienceModifier;
                    if (value < lower)
                    {
                        value = lower;
                    }
                    else if (value > upper)
                    {
                        value = upper;
                    }
                    return 1 + (value / 100);

                }

            }
            private decimal IncreasedLimitFactor
            {
                get
                {
                    var algorithmAssignment = GetAlgorithmAssignment();

                    var limit = (CoverageType.Limit)this.Engine.interpreter.Eval("Limit");
                    bool? isCombined = limit.selectedLimitName?.ToLower()?.Contains("combined");
                    int limitCount = limit.selectedLimits.Count;

                    if (limitCount == 0)
                    {
                        throw new Exception($"Coverage {limit.GetCoverageType().Name} had no limits selected");

                    }
                    if (isCombined == null)
                    {

                        if(limitCount==1)
                        {
                            isCombined = true;

                        }
                        else
                        {
                            isCombined = false;
                        }
                        
                    }

                    if(isCombined == true)
                    {
                        this.Factor.NameUI.Add("Increased Limit Factor (Combined Single Limit)");

                        var combinedKnownField = KnownField.GetKnownField("Combined Single Limit");

                        this.Factor.KnownFields.Add(combinedKnownField);


                        this.Factor.Name = "IncreasedCombinedSingleLimitFactors";
                        this.Factor.CustomCalculation = false;

                        this.Resolve();
                        return this.Value;
                    }
                    else
                    {
                        this.Factor.NameUI.Add("Increased Limit Factor (Split Limit)");

                        this.Factor.KnownFields.Add(KnownField.GetKnownField("Bodily Injury Limit Per Person"));
                        this.Factor.KnownFields.Add(KnownField.GetKnownField("Bodily Injury Limit Per Occurrence"));
                        this.Factor.KnownFields.Add(KnownField.GetKnownField("Property Damage Limit Per Occurrence"));

                        this.Factor.Name = "IncreasedSplitLimitFactors";
                        this.Factor.CustomCalculation = false;

                        this.Resolve();
                        return this.Value;
                    }

                }
            } 
            private decimal StatedValue
            {
                get
                {
                    var value = this.KnownFields[0].Resolve();
                    

                    return (decimal)(value ?? 0);
                }
            }
            private decimal ExcessLimitsRatingFactor
            {
                get
                {
                    this.Factor.TableName = "ExcessLimitsRatingFactors";
                    this.Factor.CustomCalculation = false;
                    this.Resolve();
                    return 1;
                }
            }

            private decimal UMExposureBase
            {
                get
                {
                    var coverageCodes = new string[] {
                                                    "VA00029",
                                                    "VA00030",
                                                    "VA00031",
                                                    "VA00032",
                                                    "VA00033",
                                                    "VA00034",
                                                    "VA00035",
                                                    "OR00001",
                                                    "OR00002",
                                                    "OR00004",
                                                    "VA00058",
                                                    "VA00059",
                                                    "VA00060",
                                                    "VA00061",
                                                    "VA00062",
                                                    "VA00063",
                                                    "VA00064"
                                                    };

                    var ratingAlgorithm = this.Engine.latestResults.Find(it => coverageCodes.Contains(it["CoverageCode"].ToString()));
                    try
                    {
                        return ratingAlgorithm["Factors"]["Manual Basic Limits Premium"]["Value"].ToObject<decimal>();

                    }
                    catch(Exception ex)
                    {
                        Log.Error($"Manual Basic Premium was not found in rating object: {ratingAlgorithm}");
                        throw ex;
                    }


                }
            }



        }
    }   
    
}
