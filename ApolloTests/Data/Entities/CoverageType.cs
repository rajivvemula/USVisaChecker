using ApolloTests.Data.Entities;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ApolloTests.Data.Entity

{
    /// <summary>
    /// Represent coverage types in the system
    /// </summary>
    public class CoverageType:BaseEntity
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
            var result = Main.ObjectContainer.Resolve<SQL>().executeQuery(@$"SELECT *
                                            FROM [coverage].[CoverageType]
                                            WHERE {property} = @criteria
                                            ;", ("@criteria", criteria)
                             );
            if (result.Count == 0)
            {
                throw Functions.HandleFailure($"Property: {property} & criteria: {criteria} did not return any results. see CoverageType.Persisted to achieve consistent namning across coverages types");
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

        

        #region Commercial Auto
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

        public const string PERSONAL_INJURY_PROTECTION = "Personal Injury Protection";
        #endregion

        #region Business Owners

        public const string ADDITIONAL_INSURED_GRANTOR_OF_FRANCHISE = "Additional Insured - Grantor Of Franchise";
        public const string ADDITIONAL_INSURED_LESSOR_OF_LEASED_EQUIPMENT = "Additional Insured - Lessor of Leased Equipment";
        public const string OUTDOOR_SIGNS = "Outdoor Signs - Optional Coverage";
        public const string EMPLOYEE_DISHONESTY = "Employee Dishonesty";
        public const string BUSINESS_INCOME_OPTIONS = "Business Income Options";
        public const string FUNGI_WET_ROT_DRY_ROT_AND_BACTERIA = "Fungi, Wet Rot, Dry Rot & Bacteria (Mold)";
        public const string PERSONAL_PROPERTY_OFF_PREMISES = "Personal Property Off Premises";
        public const string BUSINESS_INCOME_FROM_DEPENDENT_PROPERTIES = "Business Income From Dependent Properties";
        public const string BUSINESS_PERSONAL_PROPERTY_COVERAGE = "Business Personal Property Coverage";
        public const string OUTDOOR_PROPERTY = "Outdoor Property";
        public const string WATER_BACKUP_AND_SUMP_OVERFLOW = "Water Back-up and Sump Overflow";
        public const string EQUIPMENT_BREAKDOWN_COVERAGE = "Equipment Breakdown Coverage (HSB)";
        public const string ADDITIONAL_INSURED_MANAGERS_OR_LESSORS_OF_PREMISES = "Additional Insured - Managers or Lessors of Premises";
        public const string DATA_COMPROMISE = "Data Compromise";
        public const string ADDITIONAL_INSURED_DESIGNATED_PERSON_OR_ORGANIZATION = "Additional Insured - Designated Person or Organization";
        public const string NON_OWNED_AUTOMOBILE = "Non-owned Automobile";
        public const string NON_OWNED_AUTOMOBILE_WITH_UNINSURED_MOTORISTS = "Non-owned Automobile with Uninsured Motorists";
        public const string CONTRACTORS_INSTALLATION_TOOLS_AND_EQUIPMENT_COVERAGE = "Contractors' Installation, Tools and Equipment Coverage";
        public const string BUILDING_COVERAGE = "Building Coverage";
        public const string BLANKET_BUILDING_COVERAGE = "Blanket Building Coverage";
        public const string DAMAGE_TO_PREMISES_RENTED_TO_YOU = "Damage To Premises Rented To You";
        public const string ADDITIONAL_INSURED_OWNERS_LESSEES_OR_CONTRACTORS_SCHEDULED_PERSON_OR_ORGANIZATION = "Additional Insured - Owners, Lessees or Contractors - Scheduled Person or Organization";
        public const string WAIVER_OF_TRANSFER_OF_RIGHTS_OF_RECOVERY_AGAINST_OTHERS_TO_US = "Waiver Of Transfer Of Rights Of Recovery Against Others To Us";
        public const string GARAGEKEEPERS = "Garagekeepers";
        public const string HIRED_AUTOMOBILE = "Hired Automobile";
        public const string HIRED_AUTOMOBILE_WITH_UNINSURED_MOTORISTS = "Hired Automobile with Uninsured Motorists";
        public const string PRIMARY_AND_NONCONTRIBUTORY_OTHER_INSURANCE_CONDITION = "Primary and Noncontributory - Other Insurance Condition";
        public const string TEXAS_ADDITIONAL_INSURED_OWNERS_LESSEES_OR_CONTRACTORS_SCHEDULED_PERSON_OR_ORGANIZATION = "Texas - Additional Insured - Owners, Lessees or Contractors - Scheduled Person or Organization";
        public const string PROFESSIONAL_OFFICES_DELUXE = "Professional Offices Deluxe";
        public const string SPOILAGE = "Spoilage";
        public const string AUTO_SERVICES = "Auto Services";
        public const string CLEANING_SERVICES = "Cleaning Services";
        public const string APARTMENT_BUILDINGS_COVERAGE = "Apartment Buildings Coverage";
        public const string RETAIL_STORES_COVERAGE = "Retail Stores Coverage";
        public const string RESTAURANT_LOSS_OR_DAMAGE_CUSTOMERS_AUTOS = "Restaurants - Loss or Damage to Customers Autos";
        public const string RESTAURANT_COVERAGE = "Restaurant Coverage";
        public const string AUTO_SERVICES_DELUXE = "Auto Services Deluxe (Defective Products and Faulty Work)";
        public const string DESIGNATED_CONSTRUCTION_PROJECT_GENERAL_AGGREGATE_LIMIT = "Designated Construction Project(s) General Aggregate Limit";
        public const string EMPLOYMENT_RELATED_PRACTICES_LIABILITY = "Employment-related Practices Liability";
        public const string LIQUOR_LIABILITY = "Liquor Liability";
        public const string EMPLOYEE_BENEFITS_LIABILITY = "Employee Benefits Liability";
        public const string RESTAURANT_DELUXE_COVERAGE = "Restaurant Deluxe Coverage";
        public const string RETAIL_STORES_DELUXE = "Retail Stores Deluxe";
        public const string ADDITIONAL_INSURED_OWNERS_LESSEES_CONTRACTORS_COMPLETED_OPERATIONS = "Additional Insured - Owners, Lessees or Contractors - Completed Operations";
        public const string CAR_WASH_DAMAGE_CUSTOMER_AUTOS = "Car Wash - Damage to Customer's Autos";
        public const string MONEY_AND_SECURITIES = "Money and Securities";
        public const string GENERAL_LIABILITY = "General Liability";
        public const string NEW_JERSEY_LEAD = "New Jersey Lead";
        public const string ADDITIONAL_INSURED_VENDORS = "Additional Insured - Vendors";
        public const string BLANKET_ADDITIONAL_INSURED_OWNERS_LESSEES_CONTRACTORS_ADDITIONAL_INSURED_REQUIREMENT_CONSTRUCTION_FRM0451 = "Blanket Additional Insured - Owners, Lessees or Contractors - With Additional Insured Requirement In Construction Contract - FRM0451";
        public const string BLANKET_ADDITIONAL_INSURED_OWNERS_LESSEES_CONTRACTORS_ADDITIONAL_INSURED_REQUIREMENT_CONSTRUCTION_FRM9917 = "Blanket Additional Insured - Owners, Lessees or Contractors - With Additional Insured Requirement In Construction Contract - FRM9917";
        public const string TEXAS_ADDITIONAL_INSURED_OWNERS_LESSEES_CONTRACTORS_COMPLETED_OPERATIONS = "Texas - Additional Insured - Owners, Lessees or Contractors - Completed Operations";
        public const string TEXAS_BLANKET_ADDITIONAL_INSURED_OWNERS_LESSEES_CONTRACTORS_ADDITIONAL_INSURED_REQUIREMENT_CONSTRUCTION = "Texas - Blanket Additional Insured - Owners, Lessees or Contractors - With Additional Insured Requirement In Construction Contract";
        public const string HOTELS_MOTELS_DELUXE = "Hotels/Motels Deluxe";
        public const string BUSINESS_INCOME_EXTRA_EXPENSE_COVERAGE = "Business Income & Extra Expense Coverage";
        public const string MINE_SUBSIDENCE = "Mine Subsidence";
        public const string LEAD_LIABILITY_COVERAGE = "Lead Liability Coverage";
        public const string AUTO_SERVICES_GARAGE_LIABILITY = "Auto Services - Garage Liability";
        public const string CONTRACTORS_HOME_REPAIR_REMODELING = "Contractors - Home Repair and Remodeling";
        public const string HOTELS_MOTELS_COVERAGE = "Hotels/Motels Coverage";
        public const string UTILITY_SERVICES_DIRECT_DAMAGE = "Utility Services - Direct Damage";
        public const string UTILITY_SERVICES_TIME_ELEMENT = "Utility Services - Time Element";
        public const string LOSS_OR_DAMAGE_TO_CUSTOMERS_AUTOS = "Loss or Damage to Customers Autos";
        public const string TEXAS_ADDITIONAL_INSURED_LESSOR_LEASED_EQUIPMENT = "Texas - Additional Insured - Lessor of Leased Equipment";
        public const string SINKHOLE = "Sinkhole";
        public const string PLAYGROUNDS_OR_AMUSEMENT_AREAS = "Playgrounds or Amusement Areas";
        public const string TENANTS_IMPROVEMENTS_AND_BETTERMENTS = "Tenants Improvements and Betterments";
        public const string AMOUNT_TO_BALANCE_MINIMUM_PREMIUM = "Amount to Balance Minimum Premium";
        public const string TERRORISM = "Terrorism";
        public const string ORDINANCE_OR_LAW_BROAD = "Ordinance or Law (Broad)";
        public const string ORDINANCE_OR_LAW = "Ordinance or Law";
        public const string CONDOMINIUMS_COOPS_ASSOCIATIONS_DIRECTORS_AND_OFFICERS_LIABILITY = "Condominiums, Co-ops, Associations - Directors and Officers Liability";
        public const string CONTRACTOR_SNOW_AND_ICE_REMOVAL_COVERAGE = "Contractor snow and ice removal coverage";
        public const string CERTIFIED_ACTS_OF_TERRORISM = "Certified Acts of Terrorism";
        #endregion

    }
}