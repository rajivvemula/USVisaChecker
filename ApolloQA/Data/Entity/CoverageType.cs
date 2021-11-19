using ApolloQA.Source.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ApolloQA.Data.Entity

{
    /// <summary>
    /// Represent coverage types in the system
    /// </summary>
    public class CoverageType
    {
        public readonly string Name;

        public readonly long Id;

        public bool isVehicleLevel => _vehicleLevelCoverages.Find(it=> it==Name) != null;

        public bool calculatedPerRisk => _CalculatedOncePerPolicy.Find(it => it == Name) == null;

        public readonly int SortOrder;

        public readonly string Description;

        public override string ToString()
        {
            return this.Name;
        }

        public CoverageType(int Id)
        {
            var coverage = Get("Id", Id);
            this.Id = coverage["Id"];
            this.Name = coverage["TypeName"];
            this.SortOrder = coverage["SortOrder"];
            this.Description = coverage["Description"];
        }

        public CoverageType(string CoverageTypeName)
        {
            //this constructor is expecting Coverage Type Name from the Rating manuals
            //and these coverages' name varies across state
            //we will use a persisted object to identify these and retrieve they're standard name in Apollo System
            if (Persisted.ContainsKey(CoverageTypeName))
            {
                CoverageTypeName = Persisted[CoverageTypeName];
            }

            var coverage = Get("TypeName", CoverageTypeName);
            this.Id = coverage["Id"];
            this.Name = coverage["TypeName"];
            this.SortOrder = coverage["SortOrder"];
            this.Description = coverage["Description"];
        }

        private static Dictionary<string, dynamic> Get(string property, object criteria)
        {
            var result = SQL.executeQuery(@$"SELECT *
                                            FROM [coverage].[CoverageType]
                                            WHERE {property} = @criteria
                                            ;", ("@criteria", criteria)
                             );
            if (result.Count == 0)
            {
                throw Functions.handleFailure($"Property: {property} & criteria: {criteria} did not return any results. see CoverageType.Persisted to achieve consistent namning across coverages types");
            }

            return result[0];
        }

       
        public bool IsNonPoweredVehicle_Unapplicable()
        {
            return DONT_APPLY_TO_NON_POWERED_VEHICLES.Contains(this.Name);
        }

        private static readonly List<string> DONT_APPLY_TO_NON_POWERED_VEHICLES = new List<string>
        {
            {UNINSURED_MOTORIST},
            {UNDERINSURED_MOTORIST},

            {UNINSURED_MOTORIST_BI},
            {UNDERINSURED_MOTORIST_BI},

            {UNINSURED_MOTORIST_PD},
            {UNDERINSURED_MOTORIST_PD},

            {UNINSURED_UNDERINSURED_BIPD},
            {UNINSURED_BIPD},
            {UNINSURED_UNDERINSURED_BI},
            
        };


         /// <summary>
        /// List of vehicle level coverages <br/>
        /// This list will be used to differentiate them
        /// </summary>
        private static readonly List<string> _vehicleLevelCoverages = new List<string>
        {
            {COLLISION},
            {COMPREHENSIVE}
        };

        private static readonly List<string> _CalculatedOncePerPolicy = new List<string>
        {
            { TRAILER_INTERCHANGE }
        };


        // Key = possible name in any source
        // Value = standard Name on Apollo System
        public const string BIPD = "Bodily Injury Property Damage (BIPD)";

        public const string COLLISION = "Collision";

        public const string COMPREHENSIVE = "Comprehensive";

        public const string MEDICAL_PAYMENTS = "Medical Payments";

        public const string UNINSURED_MOTORIST = "Vehicle Uninsured Motorists";
        public const string UNDERINSURED_MOTORIST = "Vehicle Underinsured Motorists";

        public const string UNINSURED_MOTORIST_BI = "Uninsured Motorists BI";
        public const string UNDERINSURED_MOTORIST_BI = "Underinsured Motorists BI";


        public const string UNINSURED_MOTORIST_PD = "Uninsured Motorists PD";
        public const string UNDERINSURED_MOTORIST_PD = "Underinsured Motorists PD";

        public const string UNINSURED_UNDERINSURED_BIPD = "Uninsured / Underinsured Motorists BIPD";

        public const string UNINSURED_BIPD = "Uninsured Motorists BIPD";

        public const string UNINSURED_UNDERINSURED_BI = "Uninsured / Underinsured Motorists BI";

        public const string CARGO = "Cargo Coverage";

        public const string RENTAL_REIMBURSEMENT = "Rental Reimbursement";

        public const string IN_TOW = "In-Tow";

        public const string TRAILER_INTERCHANGE = "Trailer Interchange";

        //Key = possible name in any source - Value= standard Name on Apollo System
        public static readonly Dictionary<string, string> Persisted = new Dictionary<string, string>()
        {
            {"BIPD",  BIPD},
            {"OTC", COMPREHENSIVE },
            {"Other Than Collision", COMPREHENSIVE },
            {"Med Pay", MEDICAL_PAYMENTS },
            {"UM BIPD", UNINSURED_MOTORIST},
            {"UIM BIPD", UNDERINSURED_MOTORIST }
        };

        public class Limit
        {
            public string? selectedDeductibleName;

            public List<int> selectedDeductibles;

            public string? selectedLimitName;

            public List<int> selectedLimits;

            private CoverageType coverageType;

            public long coverageTypeId => coverageType.Id;

            public JArray questionResponses;

            public long riskId;

            public List<Limit> riskCoverages;

            public Limit(CoverageType coverageType,
                        string? selectedDeductibleName,
                        List<int> selectedDeductibles,
                        string? selectedLimitName,
                        List<int> selectedLimits,
                        JArray questionResponses,
                        long? riskId = null,
                        List<Limit> riskCoverages = null
                        )
            {
                this.coverageType = coverageType;
                this.selectedDeductibleName = selectedDeductibleName;
                this.selectedDeductibles = selectedDeductibles;
                this.selectedLimitName = selectedLimitName;
                this.selectedLimits = selectedLimits;
                this.questionResponses = questionResponses;
                this.riskId = riskId??0;
                this.riskCoverages = riskCoverages;
            }

            [JsonConstructor]
            public Limit(int coverageTypeId,
                        string? selectedDeductibleName,
                        List<int> selectedDeductibles,
                        string? selectedLimitName,
                        List<int> selectedLimits,
                        JArray questionResponses,
                        long? riskId = null,
                        List<Limit> riskCoverages = null
                        )
            {
                this.coverageType = new CoverageType(coverageTypeId);
                this.selectedDeductibleName = selectedDeductibleName;
                this.selectedDeductibles = selectedDeductibles;
                this.selectedLimitName = selectedLimitName;
                this.selectedLimits = selectedLimits;
                this.questionResponses = questionResponses;
                this.riskId = riskId??0;
                this.riskCoverages = riskCoverages;

            }

            public CoverageType GetCoverageType()
            {
                return this.coverageType;
            }

            public object? getQuestionResponse(string questionAlias)
            {
                var questionResponse = questionResponses?.FirstOrDefault(it => it["QuestionAlias"].ToString() == questionAlias);

                if (questionResponse == null)
                {
                    Log.Debug($"{questionAlias}returned null");
                    return null;
                }
                else
                {
                    Log.Debug($"{questionAlias} returned {questionResponse?["Response"] ?? "response is null"}");
                    return ((JValue)questionResponse["Response"])?.Value;
                }
            }

            public override string ToString()
            {
                return JObject.FromObject(this).ToString();
            }
        }
    }
}