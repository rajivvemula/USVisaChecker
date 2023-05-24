using ApolloTests.Data.Entities;
using ApolloTests.Data.Entities.Coverage;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ApolloTests.Data.Rating
{
    public class Factor:BaseEntity
    {
        private static readonly JObject Factors = JsonConvert.DeserializeObject<JObject>(new StreamReader("Data/Rating/Factors.json").ReadToEnd()) ?? throw new NullReferenceException();

        public string Name { get; set; }
        public List<string> NameUI;
        public List<KnownField> KnownFields { get; set; }
        public bool CustomCalculation{ get; set; }
        public string? source{ get; set; }
        public string? TableName{ get; set; }
        public bool displayOnly{ get; set; }
        public string? FactorColumnIdentifier { get; set; } = "Factor";
        public string? Condition { get; set; }
        public bool? ConditionResolution { get; set; }

        [JsonConstructor]
        public Factor(JArray knownFields)
        {
            KnownFields = knownFields ==null? new List<KnownField>() : knownFields.Select(it => KnownField.GetKnownField(it.Value<string>())).ToList();
        }
        public Factor(string name, IEnumerable<string> nameUI, IEnumerable<KnownField>? knownFields, bool? CustomCalculation = false, string? source = null, string? tableName = null, bool? displayOnly = false, string FactorColumnIdentifier = null)
        {
            this.Name = name;
            this.NameUI = nameUI.ToList();
            this.KnownFields = (knownFields??new List<KnownField>()).ToList();
            this.CustomCalculation = CustomCalculation ?? false;
            this.source = source;
            this.TableName = tableName;
            this.displayOnly = displayOnly??false;
            if(name=="Rate per vehicle")
            {
                Log.Info(FactorColumnIdentifier);
            }
            this.FactorColumnIdentifier = FactorColumnIdentifier ?? "Factor";
        }

        public static Factor GetFactor(string name, IObjectContainer OC)
        {
            var factors = GetFactors();

            Factor? _factor = factors.FirstOrDefault(it => it.Name == name);

            if(_factor==null)
            {
                _factor = factors.FirstOrDefault(it=> it.Name == name.Substring(name.IndexOf('.') + 1));
            }

            if (_factor == null) { 
                if(name.Contains('.'))
                {
                    Log.Critical($"FactorName: {name.Substring(name.IndexOf('.') + 1)} ");
                }
                throw new KeyNotFoundException($"Factor: {name} did not exist in  DataFiles/Rating/Factors.json"); 
            }

            _factor.LoadOC(OC);
            return _factor;


        }

        public static List<Factor> GetFactors()
        {
            var _factors = new List<Factor>();
            foreach (var factor in (JObject)Factors.DeepClone())
            {
                if (factor.Value.Value<JArray?>("KnownFields") == null && factor.Value.Value<bool?>("CustomCalculation") != true ) 
                { throw new KeyNotFoundException($"Factor: \n{factor}\n contains incorrectly named properties in DataFiles/Rating/Factors.json"); }

                factor.Value["Name"] = factor.Key;
                _factors.Add((factor.Value as JObject).ToObject<Factor>());

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
        public class Resolvable : BaseEntity
        {

            [JsonIgnore]
            public Factor Factor { get; private set; }
            private readonly Engine Engine;
            public List<KnownField.Resolvable>? KnownFields;
            public Dictionary<string, string>? matchedRow;
            public Dictionary<string, string>? matchedNextRow;
            public bool interpolated = false;
            public bool displayOnly => Factor.displayOnly;
            public decimal? Value { get; set; }
            public String? parsedValue { get; set; }
            public Exception? Error { get; set; } = null;
            public int? IndexOnFormula { get; set; }
            public string FullName { get; set; }
            public decimal? CurrentPremium { get; set; }
            public string? testError { get; set; }
            public string? Warning { get; set; }
            public string Condition => Factor.Condition;
            public bool Skipped => Factor.ConditionResolution == false;

            public string Name
            {
                get => Factor.Name;
                set
                {
                    if (Factor == null)
                    {
                        Factor = Factor.GetFactor(value, ObjectContainer);
                    }
                }
            }
            public IEnumerable<string> NameUI => Factor.NameUI;

            public bool CustomCalculation => Factor.CustomCalculation;

            public Resolvable(Engine engine, Factor factor)
            {
                this.Factor = factor;
                this.Engine = engine;
                LoadOC(factor.ObjectContainer);
            }
            //space in the front is important
            private string LOWERBOUND = " Lower Bound";
            private string UPPERBOUND = " Upper Bound";
            private const string INTERPOLATIONUPPERMATCH = "Interpolation Upper Row Match";
            public JObject Resolve(bool loadKnownFields = true)
            {
                if(loadKnownFields)
                {
                    loadResolvedKnownFields();
                }

                if (CustomCalculation)
                {
                    var method = this.GetType().GetProperty(Factor.source ?? throw new NullReferenceException(), BindingFlags.NonPublic | BindingFlags.Instance);


                    if (method == null)
                    {
                        throw new KeyNotFoundException($"Expecting Factor: {Factor.Name} source: {Factor.source} member in this Data.Rating.Factor.cs");
                    }
                    else
                    {
                        this.Value = (decimal?)method.GetGetMethod(true)?.Invoke(this, null);
                    }

                }
                else
                {
                    List<Dictionary<string, string>>? factorTable = null;

                    if (this.Factor.TableName != null)
                    {
                        factorTable = this.Engine.getTable(this.Factor.TableName.Replace("@CoverageCode", this.GetAlgorithmAssignment().CoverageCode));
                    }
                    else if (this.Factor.Name.Contains('.'))
                    {
                        factorTable = this.Engine.getTable(this.Factor.Name);
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
                        if (Factor.Name == "ExtraordinaryMedical")
                        {
                            UPPERBOUND = "Upper";
                            LOWERBOUND = "Lower";
                        }
                        for (int columnIndex = 0; columnIndex < row.Count; columnIndex++)
                        {
                            KeyValuePair<string, string> column = row.ElementAt(columnIndex);
                            var knownFieldName = column.Key;
                            if (knownFieldName.EndsWith("ID"))
                            {
                                continue;
                            }
                            if (knownFieldName.Contains(LOWERBOUND))
                            {
                                knownFieldName = column.Key.Replace(LOWERBOUND, "");
                            }
                            else if (knownFieldName.Contains(UPPERBOUND))
                            {
                                knownFieldName = column.Key.Replace(UPPERBOUND, "");
                            }

                            if (column.Key != Factor.FactorColumnIdentifier && !column.Key.Contains("Factor"))
                            {
                                var knownField = this.KnownFields?.FirstOrDefault(it => it.Name == knownFieldName);

                                if (knownField == null)
                                {
                                    throw new NullReferenceException($"The column [{knownFieldName}] for factor {Factor.Name} was not matched to any field on Data/Rating/KnownFields.json");
                                }
                                else if (KnownFields.Any(knownField => knownField.Name == "FirstRow"))
                                {
                                    match.Add(column.Key, true);
                                    continue;
                                }


                                if (knownField.TypeName == "Currency")
                                {
                                    //knownField.parsedValue = ((int)knownField.Value).ToString("C0");
                                    knownField.parsedValue.Add(((int)knownField.Value).ToString("0.0000000000"));

                                }
                                if (column.Key.Contains(LOWERBOUND) && knownField.Type != null && (decimal)knownField.Value >= decimal.Parse(column.Value))
                                {
                                    lowerBoundMatch = true;
                                }
                                else if (column.Key.Contains(UPPERBOUND))
                                {
                                    var columnValue = column.Value == "9999999" ? decimal.MaxValue : decimal.Parse(column.Value);

                                    Dictionary<string, string>? nextLogicalRow = columnValue != decimal.MaxValue ? factorTable.FirstOrDefault(it => decimal.Parse(it[knownFieldName + $"{LOWERBOUND}"]) == columnValue + 1) : null;

                                    var nextRowLowerBound = nextLogicalRow == null ? 0 : decimal.Parse(nextLogicalRow[knownFieldName + $"{LOWERBOUND}"]);

                                    if (knownField.Type != null && (decimal)knownField.Value <= columnValue)
                                    {
                                        upperBoundMatch = true;
                                    }
                                    //check for interpolation US 12209
                                    else if (columnValue != decimal.MaxValue &&
                                            columnValue + 1 != nextRowLowerBound &&
                                            knownField.Type != null && (decimal)knownField.Value < nextRowLowerBound
                                           )
                                    {

                                        match.Add(INTERPOLATIONUPPERMATCH, true);
                                        upperBoundMatch = true;
                                    }
                                }

                                var columnIsLimit = column.Key.ToLower().Contains("limit");



                                /* if (knownField.TypeName == "Currency")
                                 {
                                     Log.Debug($"column value: {column.Key}={column.Value}");
                                     Log.Debug($"Knownfield value: {column.Key}={knownField.Value?.ToString()}");
                                     Log.Debug($"Knownfield parsed: {column.Key}={knownField.parsedValue}");


                                 }
 */
                                if (lowerBoundMatch || upperBoundMatch)
                                {
                                    match.Add(column.Key, true);

                                    lowerBoundMatch = false;
                                    upperBoundMatch = false;
                                }
                                else if (column.Value != null && (column.Value?.ToLower() == knownField.Value?.ToString()?.ToLower() || knownField.parsedValue.Any(it => column.Value.Equals(it, StringComparison.InvariantCultureIgnoreCase))))
                                {
                                    match.Add(column.Key, true);
                                }

                                //limits that exceed what's listed in the manual will count the highest limit possible as a match
                                else if (columnIsLimit && tableLimits[column.Key].Count > 0 && int.Parse(string.Join("", column.Value?.Where(char.IsDigit) ?? throw new NullReferenceException())) == tableLimits[column.Key].Max() && ((int)knownField.Value) > tableLimits[column.Key].Max())
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
                            string? factorColName = row.Keys.ToList<string>().Find(column => column == Factor.FactorColumnIdentifier);
                            if (factorColName == null)
                            {
                                factorColName = row.Keys.ToList<string>().Find(column => column.Contains(Factor.FactorColumnIdentifier));
                            }
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

                return this.ToJObject();

            }

            public JObject ToJObject()
            {
                return JObject.FromObject(this);
            }
            private Dictionary<string, List<int>> GetTableLimits(List<Dictionary<string, string>> factorTable)
            {
                var result = new Dictionary<string, List<int>>();
                var limitColumns = factorTable[0].Where(it => it.Key.ToLower().Contains("limit") && !it.Key.ToLower().Contains("factor")).Select(it => it.Key).ToList();

                if (limitColumns.Count == 0)
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

                        if (intVal > 0)
                        {
                            result[column].Add(intVal);
                        }
                    }

                }
                result = result.Select(it => new KeyValuePair<string, List<int>>(it.Key, it.Value.Distinct().ToList())).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

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
                    catch (Exception ex)
                    {
                        throw new Exception($"Error Resolving KnownField {resolvable.Name}", ex);
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
                    var table = Engine.getTable($"{this.Engine.interpreter.Eval("CoverageCode")}.BaseRateFactors");
                    if(table.Count== 0)
                    {
                        return decimal.Parse(table[0]["Base Rate Factor"]);
                    }
                    else
                    {
                        this.Factor.KnownFields = table[0].Keys.Where(it=>it!="Base Rate Factor").Select(it => KnownField.GetKnownField(it)).ToList();
                        this.Factor.CustomCalculation = false;
                        this.Resolve();
                        return this.Value??throw new Exception($"value returned null for BaseRateFactor of {this.Engine.interpreter.Eval("CoverageCode")}");
                    }
                }
            }
            private decimal BaseRateFactorPIP
            {
                get
                {
                    try
                    {

                        var table = this.Engine.getTable($"{this.Engine.interpreter.Eval("CoverageCode")}.BaseRateFactor");
                        this.Factor.NameUI.Add($"{GetAlgorithmAssignment().CoverageCode} Base Rate Factor");
                        if (new[] { "NJ", "MI" }.Contains(this.Engine.GoverningStateCode))
                        {
                            string finalTypeConsidered;
                            int category = KnownFields.Find(it => it.Name == "BodyCategoryTypeId").Value;
                            int subCategory = KnownFields.Find(it => it.Name == "BodySubCategoryTypeId").Value;
                            decimal GVW = KnownFields.Find(it => it.Name == "GVW/GCW").Value;

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
                            Log.Info($"BaseRateFactorPIP.finalTypeConsidered: {finalTypeConsidered}");
                            var factor = table.Find(it => it["Vehicle Type"] == finalTypeConsidered)["Factor"];
                            return decimal.Parse(factor);

                        }
                        else
                        {
                            return decimal.Parse(table[0]["Base Rate Factor"]);
                        }
                    }
                    catch (Exception e)
                    {
                        var message = "error getting Base Factor for PIP";
                        message += $"\nTableName: {this.Engine.interpreter.Eval("CoverageCode")}.BaseRateFactor";
                        message += Log.stringify(this.Engine.getTable($"{this.Engine.interpreter.Eval("CoverageCode")}.BaseRateFactor"));
                        message += "\n\n" + Log.stringify(this);
                        throw new Exception(message, e);


                    }
                }
            }
            private decimal BaseRateFactorPPI => decimal.Parse(this.Engine.getTable($"{Factor.TableName}")[0]["Base Rate Factor"]);

            private decimal MinimumRatingValueFactors
            {
                get
                {
                    this.Factor.NameUI.Add($"{GetAlgorithmAssignment().CoverageCode} Minimum Rating Value");
                    var value = this.Engine.getTable($"{this.Engine.interpreter.Eval("CoverageCode")}.MinimumRatingValueFactors")[0]["Minimum Rating Value Factor"];
                    return decimal.Parse(value);
                }
            }
            private decimal? VehicleTypeMinimumRatingValueFactor
            {
                get
                {
                    var vehicleType = (string?)this.KnownFields?.First(it => it.Name == "Vehicle Type").Value;
                    vehicleType.NullGuard();
                    var algorithmTable = this.Engine.getTable($"{GetAlgorithmAssignment().CoverageCode}.VehicleType_MinimumRatingValueFactors");

                    var factor = algorithmTable.FirstOrDefault(it => it["Vehicle Type"] == vehicleType)?["Minimum Rating Value Factor"];
                    factor.NullGuard();
                    //Log.Debug(factor.Where(char.IsDigit));
                    var minimumValue = decimal.Parse(factor);

                    var vehicleValue = (decimal)this.KnownFields?.First(it => it.Name == "Stated Value").Value;
                    vehicleType.NullGuard();
                    this.Value = vehicleValue < minimumValue ? minimumValue : vehicleValue;
                    return this.Value;


                }
            }
            private decimal PolicyTermFactor
            {
                get
                {
                    var tether = this.Engine.root.Tether;
                    var lifespan = tether.ExpirationDate - tether.EffectiveDate;
                    var totalDaysYear = DateTime.IsLeapYear(tether.ExpirationDate.Year) && tether.ExpirationDate.Month > 2 ? 366 : 365;
                    this.parsedValue = $"{lifespan.TotalDays} / {totalDaysYear}";


                    return decimal.Parse(lifespan.TotalDays.ToString()) / totalDaysYear;
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
                        int dob = int.Parse(driver.Driver.DateOfBirth.ToString("yyyyMMdd"));
                        int age = (now - dob) / 10000;
                        if (age < 55)
                        {
                            continue;
                        }

                        bool defensiveDriving = driver.OutputMetadata.GetQuestionResponse("IL-DefensiveDriving") == "true" ? true : false;
                        bool LastYearViolation = driver.OutputMetadata.GetQuestionResponse("IL-LastYearViolation") == "true" ? true : false;
                        bool Last3YearsLicenseSuspended = driver.OutputMetadata.GetQuestionResponse("IL-Last3YearsLicenseSuspended") == "true" ? true : false;


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

                    if (this.GetAlgorithmAssignment().DriverRatingPlan == "For Hire Public")
                    {
                        this.Factor.NameUI.Add("For Hire Driver Rating Plan");
                    }

                    if (this.Engine.root.GetVehicles().Count >= 11)
                    {
                        return 1;
                    }
                    else if (this.GetAlgorithmAssignment().DriverRatingPlan == "Unity")
                    {
                        return 1;
                    }

                    var driverFactors = new Dictionary<Entities.Risk.Driver, Factor.Resolvable>();
                    foreach (var driver in this.Engine.root.GetDrivers())
                    {
                        if (bool.Parse(driver.OutputMetadata.GetQuestionResponse("ExcludeDriver")) == false)
                        {
                            int points = driver.GetPoints(this.Engine.root, this.GetAlgorithmAssignment().DriverRatingPlan ?? throw new NullReferenceException());
                            Log.Debug("Points: " + points);

                            this.Engine.interpreter.SetVariable("DriverRisk", driver);

                            var factor = Factor.GetFactor("Individual Driver Rating Factor", ObjectContainer).GetResolvable(this.Engine);

                            factor.Resolve();
                            Log.Debug($"Driver: {driver.Driver.LicenseNo} {factor.Value}");
                            driverFactors.Add(driver.Driver, factor);

                        }
                    }

                    int powerUnitCount = this.Engine.root.GetVehicles().Where(it => !it.Vehicle.IsNonPowered()).Count();

                    List<decimal> factors = driverFactors.Select(it => it.Value.Value ?? throw new NullReferenceException()).ToList();

                    decimal aggregateFactor = 0;

                    if (driverFactors.Count() >= powerUnitCount)
                    {

                        for (int i = 0; i < powerUnitCount; i++)
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

                        aggregateFactor += decimal.Parse(row?["Unassigned Driver Factor"] ?? throw new NullReferenceException()) * unassignedCount;
                    }


                    if (this.GetAlgorithmAssignment().DriverRatingPlan == "Standard")
                    {
                        return Math.Round((aggregateFactor / Math.Max(powerUnitCount, driverFactors.Count())), 4);

                    }

                    try
                    {
                        return Math.Round((aggregateFactor / powerUnitCount), 4);
                    }
                    catch (Exception)
                    {
                        Log.Error($"Error dividing {aggregateFactor}/{powerUnitCount}");
                        Log.Error($"Vehicles returned {string.Join(", ", this.Engine.root.GetVehicles())}");
                        throw;
                    }
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
                    string[] CLASSIFICATION_NAMES = new string[] { "CLASSIFICATION", "Classification", "CLASSIFICATION PECULIARITIES" };
                    string[] EMPLOYEES_NAMES = new string[] { "EMPLOYEES", "Employees" };
                    string[] EQUIPMENT_NAMES = new string[] { "EQUIPMENT", "Equipment" };
                    string[] MANAGEMENT_NAMES = new string[] { "MANAGEMENT", "Management" };
                    string[] SAFETYORGANIZATION_NAMES = new string[] { "SAFETYORGANIZATION", "Safety Organization", "SAFETY ORGANIZATION" };

                    List<string[]> categories = new List<string[]>() { CLASSIFICATION_NAMES, EMPLOYEES_NAMES, EQUIPMENT_NAMES, MANAGEMENT_NAMES, SAFETYORGANIZATION_NAMES };

                    var table = SQL.executeQuery($@"SELECT 
                                                    [ModifierType].[Name] as 'Schedule Rating Category', 
                                                    Modifier.MaximumPercentRatingCredit as 'Maximum Schedule Rating Credit', 
                                                    Modifier.MaximumPercentRatingDebit as 'Maximum Schedule Rating Debit'
                                                    FROM [rating].[RatingModifier] Modifier
                                                    LEFT JOIN [location].[StateProvince] StateProv on Modifier.StateProvinceId = StateProv.Id
                                                    LEFT JOIN [rating].RatingModifierCategorySubtype ModifierType on ModifierType.Id = Modifier.RatingModifierCategorySubtypeId
                                                    WHERE LineId =7 AND 
                                                    StateProv.Code = '{this.Engine.GoverningStateCode}' AND
                                                    ('{this.Engine.EffectiveDate.ToString("d")}' BETWEEN Modifier.TimeFrom AND Modifier.TimeTo)
                                                    ;");

                    string credit = "Maximum Schedule Rating Credit";
                    string debit = "Maximum Schedule Rating Debit";

                    decimal total = 0;

                    foreach (string[] category in categories)
                    {
                        //Log.Debug(JToken.FromObject(table));
                        var categoryRow = table.First(it => category.Contains((string)it["Schedule Rating Category"]));
                        var categoryBoundaries = new decimal[] { -categoryRow?[credit], categoryRow?[debit] };

                        var systemValue = (decimal)this.Engine.root[category[0]];

                        //Log.Debug($"{category[0]} -> {systemValue}");

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

                    var totalRow = table.First(it => it["Schedule Rating Category"] == "Maximum Percentage Allowed");

                    var totalBoundaries = new decimal[] { -totalRow[credit], totalRow[debit] };

                    if (total < totalBoundaries[0])
                    {
                        total = totalBoundaries[0];
                    }
                    else if (total > totalBoundaries[1])
                    {
                        total = totalBoundaries[1];
                    }



                    return 1 + (total / 100);
                }
            }
            private decimal ExperienceRatingFactor
            {
                get
                {
                    var table = SQL.executeQuery($@"SELECT 
                                                    [ModifierType].[Name] as 'Schedule Rating Category', 
                                                    Modifier.MaximumPercentRatingCredit as 'Maximum Schedule Rating Credit', 
                                                    Modifier.MaximumPercentRatingDebit as 'Maximum Schedule Rating Debit'
                                                    FROM [rating].[RatingModifier] Modifier
                                                    LEFT JOIN [location].[StateProvince] StateProv on Modifier.StateProvinceId = StateProv.Id
                                                    LEFT JOIN [rating].RatingModifierCategorySubtype ModifierType on ModifierType.Id = Modifier.RatingModifierCategorySubtypeId
                                                    WHERE LineId =7 AND 
                                                    StateProv.Code = '{this.Engine.GoverningStateCode}' AND
                                                    ('{this.Engine.EffectiveDate.ToString("d")}' BETWEEN Modifier.TimeFrom AND Modifier.TimeTo) AND
                                                    [ModifierType].[Name] = 'Experience Rating'
                                                    ;");

                    var lower = -table[0]["Maximum Schedule Rating Credit"];
                    var upper = table[0]["Maximum Schedule Rating Debit"];
                    var value = this.Engine.root.ExperienceModifier;
                    //Log.Debug($"experience -> {value}");
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
            private decimal? IncreasedLimitFactor
            {
                get
                {
                    var algorithmAssignment = GetAlgorithmAssignment();

                    var limit = (Limit)this.Engine.interpreter.Eval("Limit");
                    bool? isCombined = limit.SelectedLimitName?.ToLower()?.Contains("combined");
                    int limitCount = limit.SelectedLimits.Count;

                    if (limitCount == 0)
                    {
                        throw new Exception($"Coverage {limit.GetCoverageType().TypeName} had no limits selected");

                    }
                    if (isCombined == null)
                    {

                        if (limitCount == 1)
                        {
                            isCombined = true;

                        }
                        else
                        {
                            isCombined = false;
                        }

                    }

                    if (isCombined == true)
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
                    this.KnownFields.NullGuard();
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

                    this.Engine.LatestOutput.NullGuard();
                    var ratingAlgorithm = this.Engine.LatestOutput.Results.Find(it => coverageCodes.Contains(it.CoverageCode));

                    try
                    {
                        return ratingAlgorithm.FindFactor("Manual Basic Limits Premium").Value ?? throw new NullReferenceException();

                    }
                    catch (Exception)
                    {
                        Log.Error($"Manual Basic Premium was not found in rating object: {ratingAlgorithm}");
                        throw;
                    }


                }
            }
            private decimal TrailerInterchangeExposureBase
            {
                get
                {
                    int pullingUnitCount = 0;
                    int semiTrailerCount = 0;
                    var vehicles = this.Engine.root.GetVehicles();
                    foreach (var vehicle in vehicles)
                    {
                        int GVW = int.Parse(vehicle.Vehicle.GrossVehicleWeight);
                        if (vehicle.Vehicle.BodyCategoryTypeId == 5 && Engine.root.getLimits(vehicle.Vehicle).FirstOrDefault(it => it.GetCoverageType().TypeName == "Collision" || it.GetCoverageType().TypeName == "Comprehensive") != null)
                        {
                            semiTrailerCount++;
                            continue;
                        }
                        else if (vehicle.Vehicle.BodySubCategoryTypeId == 23 || GVW >= 20001)
                        {
                            pullingUnitCount++;
                        }

                    }

                    return Math.Max(1, Math.Max(0, pullingUnitCount - semiTrailerCount) + 0.10m * Math.Min(pullingUnitCount, semiTrailerCount));

                }
            }
            private decimal Limit
            {
                get
                {
                    return this.KnownFields?.Find(it => it.Name == "Limit")?.Value ?? throw new NullReferenceException();
                }
            }
            private decimal BIPDPremium
            {
                get
                {
                    var ratingAlgorithm = this.Engine.LatestOutput.Results.Find(it => it.CoverageName == CoverageType.BIPD);

                    try
                    {
                        return ratingAlgorithm.FindFactor("Manual Basic Limits Premium").Value ?? throw new NullReferenceException();
                    }
                    catch (Exception)
                    {
                        Log.Error($"BIPD Manual Basic�Limits Premium was not found in rating object: {ratingAlgorithm}");
                        throw;
                    }

                }
            }
            private decimal PIP_BIPDIncreasedLimit
            {
                get
                {
                    var ratingAlgorithm = this.Engine.LatestOutput.Results.Find(it => it.CoverageName == CoverageType.BIPD);

                    try
                    {
                        return 1 / ratingAlgorithm.FindFactor("Increased Limit Factor").Value ?? throw new NullReferenceException();
                    }
                    catch (Exception)
                    {
                        Log.Error($"error retrieving BIPD Increased Limit Factor in rating object: {ratingAlgorithm}");
                        throw;
                    }
                }
            }
            private decimal HalfDriverRating
            {
                get
                {
                    var ratingAlgorithm = this.Engine.LatestOutput.Results.Find(it => it.CoverageName == CoverageType.BIPD);

                    try
                    {
                        var DrivingRating = ratingAlgorithm.FindFactor("Driver Rating").Value ?? throw new NullReferenceException();
                        return 1 + ((DrivingRating - 1) * 0.5M);
                    }
                    catch (Exception)
                    {
                        Log.Error($"error retrieving BIPD Driver Rating Factor in rating object: {ratingAlgorithm}");
                        throw;
                    }
                }
            }

            private decimal CargoHauledFactor
            {
                get
                {
                    var cargoHauled = this.KnownFields?[0];
                    cargoHauled.NullGuard();
                    string[] selections = JsonConvert.DeserializeObject<string[]>(cargoHauled.Value);

                    var table = this.Engine.getTable(this.Factor.Name);
                    var relevantRows = table.Where(row => selections.Contains(row["Cargo that is Hauled"]));

                    return relevantRows.Select(row => decimal.Parse(row["Factor"])).Max();

                }
            }

            private decimal CargoTruckFactor
            {
                get
                {
                    var GVW = this.KnownFields?.First(it => it.Name == "GVW/GCW");
                    GVW.NullGuard();
                    var BodySubCategoryTypeId = this.KnownFields?.First(it => it.Name == "BodySubCategoryTypeId");
                    BodySubCategoryTypeId.NullGuard();
                    var table = this.Engine.getTable(this.Factor.Name);

                    Dictionary<string, string>? row;
                    switch ((decimal)GVW.Value)
                    {
                        //Truck Tractor
                        case decimal n when n <= 45000 && BodySubCategoryTypeId.Value == 23:
                            row = table.First(it => it["Truck Type"] == "Heavy Truck-Tractor: 0 - 45k");
                            return decimal.Parse(row["Factor"]);
                        case decimal n when n > 45000 && BodySubCategoryTypeId.Value == 23:
                            row = table.First(it => it["Truck Type"] == "Extra Heavy Truck-Tractor: 45k+");
                            return decimal.Parse(row["Factor"]);


                        case decimal n when n <= 10000:
                            row = table.First(it => it["Truck Type"] == "Light Truck or PPT: 0 - 10k");
                            return decimal.Parse(row["Factor"]);

                        case decimal n when n <= 20000:
                            row = table.First(it => it["Truck Type"] == "Medium Truck: 10,001 - 20k");
                            return decimal.Parse(row["Factor"]);

                        case decimal n when n <= 45000:
                            row = table.First(it => it["Truck Type"] == "Heavy Truck: 20,001 - 45k");
                            return decimal.Parse(row["Factor"]);

                        case decimal n when n > 45000:
                            row = table.First(it => it["Truck Type"] == "Extra-Heavy Truck: 45k+");
                            return decimal.Parse(row["Factor"]);

                        default:
                            throw new Exception($"Incorrect decimal provided for GVW: {GVW.Value}");

                    }
                    throw new Exception($"Incorrect decimal provided for GVW: {GVW.Value}");

                }
            }

            private decimal CargoRadiusFactor
            {
                get
                {
                    var radius = (int)(this.KnownFields?[0]?.Value ?? throw new NullReferenceException());
                    var table = this.Engine.getTable(this.Factor.Name);

                    foreach (var row in table)
                    {
                        var upper = int.Parse(row["Radius Higher (Inclusive)"]);
                        var lower = int.Parse(row["Radius Lower"]);

                        if (radius > lower && radius <= upper)
                        {
                            this.matchedRow = row;
                            return decimal.Parse(row["Factor"]);
                        }
                    }
                    throw new Exception($"Radius: {radius} did not match any row in table \n {string.Join(",\n", table.Select(dict => dict.Select(it => $"{it.Key}:{it.Value}, ")))}");
                }
            }

            private decimal DrivertoVehicleRatio
            {
                get
                {
                    var ratio = (int)(this.KnownFields?[0]?.Value ?? throw new NullReferenceException());
                    var table = this.Engine.getTable(this.Factor.Name);
                    foreach (var row in table)
                    {
                        var upper = int.Parse(row["Driver to Vehicle Ratio Upper Bound"]);
                        var lower = int.Parse(row["Driver to Vehicle Ratio Lower Bound"]);

                        if (ratio >= lower && ratio < upper)
                        {
                            this.matchedRow = row;
                            return decimal.Parse(row["Factor"]);
                        }
                    }
                    throw new Exception($"Radius: {ratio} did not match any row in table \n {string.Join(",\n", table.Select(dict => dict.Select(it => $"{it.Key}:{it.Value}, ")))}");

                }
            }

            private decimal BaseRateFactorRR1
            {
                get
                {
                    string DAILYLIMIT = "Daily $ limit";
                    string NUMBEROFDAYS = "Number of Days";
                    string SELECTED = "Selected";
                    string TOTAL = "Total";
                    string DOWNTIME = "Downtime";

                    var table = this.Engine.getTable(this.Factor.Name);



                    var Limit = this.Engine.interpreter.Eval<Limit>("Limit");

                    var dailyLimit = Limit.SelectedLimits[0];
                    var numberOfDays = Limit.SelectedLimits[1];
                    var total = Limit.SelectedLimits[2];
                    var downtime = (string?)KnownFields?[0].Value ?? throw new NullReferenceException();



                    foreach (var row in table)
                    {

                        if (int.Parse(row[DAILYLIMIT]) == dailyLimit
                            && int.Parse(row[NUMBEROFDAYS]) == numberOfDays
                            && int.Parse(row[TOTAL]) == total
                            && row[DOWNTIME].ToLower() == downtime.ToLower())
                        {
                            return decimal.Parse(row[SELECTED]);
                        }
                    }
                    Log.Critical("Table->" + JArray.FromObject(table).ToString());
                    throw new Exception($" dailyLimit: {dailyLimit}, numberOfDays: {numberOfDays}, total: {total}, downtime: {downtime} did not match any row in table");


                }
            }

            private decimal BaseRateFactorFPB
            {
                get
                {
                    var rate = decimal.Parse(this.Engine.getTable(this.Factor.TableName)[0]["Rate"]);
                    return rate;

                }
            }
            private decimal PoweredVehicleCount
            {
                get
                {
                    var poweredVehicleCount = this.Engine.root.GetVehicles().Count(risk => !risk.Vehicle.IsNonPowered());
                    if (poweredVehicleCount == 0)
                    {
                        throw new Exception("powered Vehicle count can't be 0");
                    }
                    return poweredVehicleCount;

                }
            }
            private decimal IncreasedLimitFactors_FPB
            {
                get
                {
                    var isCombined= this.KnownFields.Find(it=> it.Name== "Combination").Value=="Y";
                    if (!isCombined)
                    {
                        foreach(var knownField in KnownFields)
                        {
                            if(knownField.Name!= "MedBenefitLimit" && knownField.Type == typeof(int))
                            {
                                knownField.Value = 0;
                            }
                        }
                    }
                    Factor.CustomCalculation = false;
                    this.Resolve(false);
                    return Value??throw new NullReferenceException("IncreasedLimitFactors_FPB returned NULL as value");
                }
            }

            private decimal ExtraordinaryMedical
            {
                get
                {
                    var applies = this.KnownFields.Find(it => it.Name == "CoverageAmount").Value >100000;
                    if(!applies)
                    {
                        return 0;
                    }
                    Factor.CustomCalculation= false;
                    this.Resolve();
                    return Value ?? throw new NullReferenceException("ExtraordinaryMedical returned null as value");
                }
            }



        }
    }   
    
}
