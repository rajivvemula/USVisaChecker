using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using ApolloTests.Data.Entities.Reference;
using ApolloTests.Data.Entities.Coverage;
using ApolloTests.Data.Entities.Enums;
using ApolloTests.Data.Entities;
using CovType = ApolloTests.Data.Entities.Coverage.CoverageType;
namespace ApolloTests.Data.Rating
{
    //this is a object made up to retrieve the relationship between a class code and a keyword
    public class KeywordMappingUtil:BaseEntity
    {


        public LineEnum Line { get; }
        public string? ClassCode { get; private set; }
        public int KeywordId { get; private set; }
        public string? KeywordName { get; private set; }
        public int? IndustryClassTaxonomyId { get; private set; }
        public string? TaxonomyName { get; private set; }
        public BuildingGroupEnum BuildingGroup { get; set; }

        //optiona, will only be loaded when constructed using the GetUsingAlgorithmCode function
        public string? CoverageType { get; private set; }

        //set of different invokers to this class
        public static KeywordMappingUtil GetUsingClassCode(LineEnum line, string classCode, String? OptionalCoverage = null) => Get(line, "reference.RiskClassType.Code", classCode, OptionalCoverage);
        public static KeywordMappingUtil GetUsingClassCodes(LineEnum line, List<string> classCodes, String? OptionalCoverage = null) => Get(line, "reference.RiskClassType.Code", classCodes, OptionalCoverage);
        public static KeywordMappingUtil GetUsingKeywordId(LineEnum line, string keywordId) => Get(line, "Keyword.Id", keywordId);
        public static KeywordMappingUtil GetUsingKeywordName(LineEnum line, string Keyword) => Get(line, "[Keyword].[Name]", Keyword);

        //uses an algorithm code to find a valid corresponding ClassCode and Keyword
        public static KeywordMappingUtil GetUsingAlgorithmCode(LineEnum line, string AlgorithmCode, string stateCode)
        {
            //AT.1 table describes what algorithm is used depending on class code & coverage
            //AT.1 table varies by state
            var AT1 = Engine.GetTable("AT.1", stateCode, null);

            //local variable to store the related coverage
            String? coverage = null;

            //because we only support a limited amount of class codes, 
            //this list will store all valid ones for the related algorithm code
            var classCodeCandidates = new List<string>();

            foreach(var row in AT1)
            {
                //because algorithms start at the 4th index of each row of AT.1, our loop starts there
                for (int i=0; i<row.Count; i++)
                {
                    var column = row.ElementAt(i);

                    //check to see if we've got a matching column value
                    if(column.Value == AlgorithmCode)
                    {
                        //since all possible matching columns will be part of the same coverage (algorithm codes only related to single coverage)
                        //since not worth to make a condition will just restore the coverage every time 
                        coverage = column.Key;
                        //add the class code candidate to the list
                        classCodeCandidates.Add((string)row["Class Code"]);
                    }
                }
            }
            //if we find that there was at least 1 candidate, then we got a match
            if(classCodeCandidates.Count>1)
            {
                Log.Debug("coverage:" + coverage);
                if(CovType.Persisted.ContainsKey(coverage))
                {
                    coverage= CovType.Persisted[coverage];
                    Log.Debug("translated coverage:" + coverage);

                }
                return GetUsingClassCodes(line,classCodeCandidates, coverage);
            }

            //if we didn't get a match then an exception is to be thrown, this is not expected
            throw new KeyNotFoundException($"Algorithm Code: {AlgorithmCode} not found in State: {stateCode} AT.1 table");
        }
        //since this is some sort of constructor, we just need the coverage to load it into the actual object
        //this function is flexible enough to search for any valid property and criteria
        private static KeywordMappingUtil Get(LineEnum line, string property, object criteria, String? coverage = null)
        {
            var result = GetSQLService().executeQuery(@$"SELECT reference.RiskClassType.Code as ClassCode,reference.Keyword.Id as KeywordId,reference.Keyword.Name as KeywordName,reference.KeywordDefault.IndustryClassTaxonomyId,reference.IndustryClassTaxonomy.Name as TaxonomyName
                                FROM  reference.RiskClassType
                                LEFT JOIN reference.KeywordDefault ON reference.KeywordDefault.RiskClassTypeId = reference.RiskClassType.Id
                                LEFT JOIN reference.IndustryClassTaxonomy ON reference.IndustryClassTaxonomy.Id = reference.KeywordDefault.IndustryClassTaxonomyId
                                LEFT JOIN reference.Keyword ON reference.keyword.Id = reference.KeywordDefault.KeywordId
                                WHERE {property} = @criteria
                                AND reference.KeywordDefault.IsLineEligible=1
                                AND reference.KeywordDefault.SubLineId={(int)line}
                                ;", ("@criteria",criteria)
                             );

            //a match is crucial here
            if(result.Count == 0)
            {
               throw Functions.HandleFailure($"Property: {property} & criteria:{criteria} did not return any results");
            }

            //we only care about the first match
            var group = result[0];
            return new KeywordMappingUtil()
            {
                ClassCode = group["ClassCode"],
                IndustryClassTaxonomyId = group["IndustryClassTaxonomyId"] is DBNull ? null : group["IndustryClassTaxonomyId"],
                KeywordId = group["KeywordId"],
                KeywordName = group["KeywordName"],
                TaxonomyName = group["TaxonomyName"] is DBNull ? null : group["TaxonomyName"],
                //default to office until we implement correct mapping
                BuildingGroup = BuildingGroupEnum.Office,
                CoverageType = coverage

            };


        }

        //same function as above but plural
        private static KeywordMappingUtil Get(LineEnum line, string property, List<string> criterias, String? coverage = null)
        {
            //to store the valid matching Record


            var results = GetSQLService().executeQuery(@$"SELECT reference.RiskClassType.Code as ClassCode,reference.Keyword.Id as KeywordId,reference.Keyword.Name as KeywordName,reference.KeywordDefault.IndustryClassTaxonomyId,reference.IndustryClassTaxonomy.Name as TaxonomyName
                                FROM  reference.RiskClassType
                                LEFT JOIN reference.KeywordDefault ON reference.KeywordDefault.RiskClassTypeId = reference.RiskClassType.Id
                                LEFT JOIN reference.IndustryClassTaxonomy ON reference.IndustryClassTaxonomy.Id = reference.KeywordDefault.IndustryClassTaxonomyId
                                LEFT JOIN reference.Keyword ON reference.keyword.Id = reference.KeywordDefault.KeywordId
                                WHERE {property} in (@criteria)
                                AND reference.Keyword.Id IS NOT NULL
                                AND reference.KeywordDefault.IsLineEligible=1
                                AND reference.KeywordDefault.SubLineId={(int)line}
                                ;", ("@criteria", criterias)
                             );
            //a match is crucial here
            if (results.Count == 0)
            {
                throw Functions.HandleFailure($"Property: {property} & criteria: @criterias did not return any results", null, false, ("@criterias", criterias));
            }
            //we only care about the first match
            var group = results.Find(result=>   !BrokenTaxonomies.Contains((int)result["IndustryClassTaxonomyId"]) &&
                                                !BrokenClassCodes.Contains((string)result["ClassCode"]) &&
                                                !BrokenKeywords.Contains((int)result["KeywordId"])
            );

            return new KeywordMappingUtil()
            {
                ClassCode = group?["ClassCode"]?? throw new NullReferenceException("ClassCode was null"),
                IndustryClassTaxonomyId = group["IndustryClassTaxonomyId"],
                KeywordId = group["KeywordId"],
                KeywordName = group["KeywordName"],
                TaxonomyName = group["TaxonomyName"],
                CoverageType = coverage

            };


        }

        private static List<int> BrokenTaxonomies = new List<int>()
        {
            //BUG 34607
            162
        };
        private static List<string> BrokenClassCodes = new List<string>()
        {
/*            //BUG 33884
            "505",
            "429"*/
        };
        private static List<int> BrokenKeywords = new List<int>()
        {
/*            //BUG 33884
            1576, //Transportation - Livestock, Equine, or Animals
            2011, //Hazardous Spill Cleanup Services
            1563, //Oil Spill Cleanup
            1485, //Mail Sorting Services
            1484, //Direct Mail Advertising Services
            1537, //Orchestra
            1539, //Cinema
            1542  //Movie Film Studio
*/




        };
    }
}
