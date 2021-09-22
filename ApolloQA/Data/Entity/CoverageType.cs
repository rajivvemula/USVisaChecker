using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApolloQA.Data.Entity

{
    //this class is to represent coverage types in the system
    public class CoverageType
    {
        public string Name { get; private set; }
        public long Id { get; private set; }
        public bool isVehicleLevel { get; private set; }
        public int SortOrder { get; private set; }
        public string Description { get; private set; }
        

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
            if(vehicleLevelCoverages.Contains(Name))
            {
                isVehicleLevel = true;
            }

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
            if (vehicleLevelCoverages.Contains(Name))
            {
                isVehicleLevel = true;
            }
        }


        private static Dictionary<string,dynamic> Get(string property, object criteria)
        {
            var result = SQL.executeQuery(@$"SELECT * 
                                            FROM [coverage].[CoverageType] 
                                            WHERE {property} = @criteria
                                            ;", ("@criteria",criteria)
                             );
            if(result.Count == 0)
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


        //List of vehicle level coverages
        //this list will be used to differentiate them
        private static readonly List<string> vehicleLevelCoverages = new List<string>
        {
            {"Collision"},
            {"Comprehensive"}
        };


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

        //Key = possible name in any source - Value= standard Name on Apollo System
        public static readonly Dictionary<string, string> Persisted = new Dictionary<string, string>()
        {
            {"BIPD", "Bodily Injury Property Damage (BIPD)" },
            {"OTC", "Comprehensive" },
            {"Other Than Collision", "Comprehensive" },
            {"Med Pay", "Medical Payments" },
            {"UM BIPD", "Vehicle Uninsured Motorists" },
            {"UIM BIPD", "Vehicle Underinsured Motorists" }
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

            public Limit(CoverageType coverageType, 
                        string? selectedDeductibleName, 
                        List<int> selectedDeductibles, 
                        string? selectedLimitName,
                        List<int> selectedLimits,
                        JArray questionResponses
                        )
            {
                this.coverageType = coverageType;
                this.selectedDeductibleName = selectedDeductibleName;
                this.selectedDeductibles = selectedDeductibles;
                this.selectedLimitName = selectedLimitName;
                this.selectedLimits = selectedLimits;
                this.questionResponses = questionResponses;

            }

            public CoverageType GetCoverageType()
            {
                return this.coverageType;
            }
            public object? getQuestionResponse(string questionAlias)
            {
                var questionResponse = questionResponses?.FirstOrDefault(it => it["QuestionAlias"].ToString() == questionAlias);

                if(questionResponse==null)
                {
                    //Log.Debug("returned null");
                    return null;
                }
                else
                {
                   // Log.Debug($"returned {questionResponse?["Response"] ?? "response is null"}");
                    return ((JValue)questionResponse["Response"])?.Value;
                }
            }

        }

    }
}
