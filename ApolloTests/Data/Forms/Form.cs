using ApolloTests.Data.Entities.Reference;
using ApolloTests.Data.Entities;

using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ApolloTests.Data.Forms
{
    public class Form:BaseEntity
    {       

        private string? _Name = null;
        public string name
        {
            get
            {
                try
                {
                    return _Name ??= SQL.executeQuery(@$"SELECT TOP(1) Name
                                                FROM [document].[GhostDraftTemplateForm] 
                                                where Code ='{code}' AND LineId = {Line.Id} order by Id desc; ")[0]["Name"];
                }
                catch
                {
                    Log.Error($"Error retrieving Name for form code: {code}");
                    throw;
                }
            }
        }
        public string code;
        public Condition condition;
        public string? displayTitle;
        private Line? _line = null;
        public Line Line {
            get{
                _line.NullGuard();
                return _line;
            } 
            set {
                this._line= value;
            }
        }
        public List<Recipient> Recipients { get
            {
                var res = Cosmos.GetQuery("FormsServiceRule", $"SELECT * FROM c where ARRAY_CONTAINS(c.Forms, {{GhostDraftTemplateFormCode:\"{this.code}\"}}, true)").Result;
                List<Recipient> result;
                if(res.Any())
                {
                    var obj = res[0];
                    var recipients = (JArray?)((JArray?)obj?["Forms"]??throw new Exception("recipient's form was null")).First(it => it.Value<string>("GhostDraftTemplateFormCode") == code)?["Recipients"];
                    result = recipients?.Select(it => it.ToObject<Recipient>() ?? throw new ArgumentNullException()).ToList()?? throw new Exception("Recipients were null");
                }
                else
                {
                    //if no recipients found, we default to insurred
                    result = new List<Recipient>() { new Recipient() { Id=0, DeliveryMethodIdsInternal="1,2", FormsServiceRuleFormEntityId=0, RecipientRoleTypeId=10006  } };
                }
                result.ForEach(it=> it.LoadOC(ObjectContainer));
                return result;
            } 
        }

        private long? _Id = null;
        public long Id
        {
            get
            {
                return _Id ??= (long)SQL.executeQuery($"SELECT Id FROM [document].[Form] WHERE code = {this.code}")[0]["Id"] ;

            }
        }

        private string? _Edition = null;
        public string Edition
        {
            get
            {
                try
                {
                    return _Edition ??= SQL.executeQuery(@$"SELECT TOP(1) Edition, EditionDate
                                                FROM [document].[GhostDraftTemplateForm] 
                                                where Code ='{code}' AND LineId = {Line.Id} order by Id desc; ")[0]["Edition"];
                }
                catch {
                    Log.Error($"Error retrieving edition for form code: {code}");
                    throw;
                }
            }
        }

        private DateTime? _EditionDate = null;

        public DateTime EditionDate 
        {
            get
            {
                try
                {
                     return _EditionDate ??= (DateTime)SQL.executeQuery(@$"SELECT TOP(1) Edition, EditionDate
                                                FROM [document].[GhostDraftTemplateForm] 
                                                where Code ='{code}' AND LineId = {Line.Id} order by Id desc; ")[0]["EditionDate"];
                }
                catch
                {
                    Log.Error($"Error retrieving edition date for form code: {code}");
                    throw;
                }
            }
        }   

    }
}
