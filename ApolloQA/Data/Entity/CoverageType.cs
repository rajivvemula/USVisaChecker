using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json;

namespace ApolloQA.Data.Rating
{
    //this function is to represent coverage types in the system
    public class CoverageType
    {
        public string Name { get; private set; }
        public long Id { get; private set; }
        public bool isVehicleLevel { get; private set; }


        public CoverageType(int Id)
        {
            var coverage = Get("Id", Id);
            this.Id = coverage["Id"];
            this.Name = coverage["TypeName"];
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
               throw Functions.handleFailure($"Property: {property} & criteria:{criteria} did not return any results");
            }

            return result[0];
        }

        //List of vehicle level coverages
        //this list will be used to differentiate them
        private static readonly List<string> vehicleLevelCoverages = new List<string>
        {
            {"Collision"},
            {"Comprehensive"}
        };

        //Key = possible name in any source - Value= standard Name on Apollo System
        private static readonly Dictionary<string, string> Persisted = new Dictionary<string, string>()
        {
            {"BIPD", "Bodily Injury Property Damage (BIPD)" },
            {"OTC", "Comprehensive" },
            {"Other Than Collision", "Comprehensive" },

        };

    }
}
