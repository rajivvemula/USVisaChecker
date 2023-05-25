using ApolloTests.Data.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Rating
{
    public class RatingManualService: BaseEntity
    {
        public RatingManualService(IObjectContainer OC) : base(OC)
        {
            
        }

        public IEnumerable<Dictionary<String, String>> GetTable(String tableName, string stateCode, string? effectiveDate)
        {

            string whereClause;

            int lineId = 7;

            if (string.IsNullOrEmpty(effectiveDate))
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

            var columns = SQL.executeQuery($@"SELECT tableColumn.AttributeName, tableColumn.AttributeColumn
                                            FROM [rating].[ReferenceTable] RatingTable
                                            LEFT JOIN [rating].[ReferenceTableStateProvince] RatingTableState on RatingTable.Id = RatingTableState.ReferenceTableId
                                            LEFT JOIN [location].[StateProvince] StateProv on RatingTableState.StateProvinceId = StateProv.Id
                                            LEFT JOIN [rating].ReferenceTableMap tableColumn on RatingTable.Id = tableColumn.ReferenceTableId
                                            {whereClause} 
                                            ;");

            var sortOrderColumnRow = columns.Find(it => ((String)it["AttributeName"]).Contains("SortOrder"));


            var attributes = SQL.executeQuery($@"SELECT TableAttributes.*
                                                FROM [rating].[ReferenceTable] RatingTable
                                                LEFT JOIN [rating].[ReferenceTableStateProvince] RatingTableState on RatingTable.Id = RatingTableState.ReferenceTableId
                                                LEFT JOIN [location].[StateProvince] StateProv on RatingTableState.StateProvinceId = StateProv.Id
                                                LEFT JOIN [rating].[ReferenceTableAttribute] TableAttributes on RatingTable.Id = TableAttributes.ReferenceTableId
                                                {whereClause} 
                                                ;");
            if (!columns.Any() || !attributes.Any())
            {
                throw new Exception("Table: " + tableName + $" was not found for parameters: {whereClause}. ");
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

                        rowDict.Add(columnName, (columnValue is DBNull ? "" : (columnValue is string ? columnValue : columnValue.ToString())) ?? "");
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

        public List<Dictionary<String, String>> GetAlorithm(String tableName)
        {

            var table = HitachiQA.Helpers.Functions.ParseExcel(@$"Data\RatingManual\Algorithms\{tableName}.xlsx").ToList();

            return table;
        }
    }
}
