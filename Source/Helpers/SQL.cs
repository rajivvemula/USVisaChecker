using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections;
using HitachiQA;
using HitachiQA.Driver;
using HitachiQA.Helpers;

namespace ApolloQA.Source.Helpers
{
    class SQL
    {
        //Connect to GigInsData on the testing server
        public static List<Dictionary<string, dynamic>> ConnectDB(string command)
        {
            const string connectionString = "server=tbibazsql1.biberk.com;Initial Catalog=giginsdata;Persist Security Info=False;User ID=tCYBPRODUser;Password=Vx##882tdNmc!!jdh;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;Application Name=ASC;";

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(command, conn))
                {
                    conn.Open();
                    SqlDataReader reader = null;
                    try
                    {
                        reader = cmd.ExecuteReader();
                    }
                    catch (Exception)
                    {
                        Log.Error($"Query: \n{command}\n");
                        throw;
                    }
                    try
                    {
                        List<Dictionary<string, dynamic>> results = new List<Dictionary<string, dynamic>>();
                        while (reader.Read())
                        {
                            results.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(keyIndex => reader.GetName(keyIndex), valueIndex => reader.GetValue(valueIndex)));
                        }
                        return results;
                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                    }
                }
            }
        }   

        public static List<Dictionary<string, dynamic>> ExecuteQuery(string query)
        {
            return ExecuteQuery(query, ("", ""));
        }

        public static List<Dictionary<string, dynamic>> ExecuteQuery(string query, params (string key, dynamic value)[] parameters)
        {
            IEnumerable<(string key, dynamic value)> listParams = parameters.ToList().FindAll(param => !(param.value is string) && param.value is IEnumerable);
            if (listParams.Any())
            {
                foreach (var listParam in listParams)
                {
                    var str = new StringBuilder();
                    int i = 0;
                    foreach (var item in listParam.value)
                    {
                        str.Append(listParam.key + i + ", ");
                        parameters = parameters.Append((listParam.key + i, item)).ToArray();
                        i++;
                    }
                    var paramKeys = str.ToString().Trim().Trim(',');
                    query = query.Replace(listParam.key, paramKeys);
                }
            }
            using (SqlConnection connection = new SqlConnection(KeyVault.GetStoredEnvironmentSecret("SQL_CONNECTIONSTRING_APOLLOSECRET")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                foreach (var parameter in parameters)
                {
                    if (!(parameter.value is IEnumerable<object>))
                    {
                        command.Parameters.AddWithValue(parameter.key, parameter.value);
                    }
                }
                connection.Open();
                SqlDataReader reader = null;
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception)
                {
                    Log.Error($"Query: \n{query}\n");
                    throw;
                }
                try
                {
                    List<Dictionary<string, dynamic>> results = new List<Dictionary<string, dynamic>>();
                    while (reader.Read())
                    {
                        results.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(keyIndex => reader.GetName(keyIndex), valueIndex => reader.GetValue(valueIndex)));
                    }
                    return results;
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }
    }
}