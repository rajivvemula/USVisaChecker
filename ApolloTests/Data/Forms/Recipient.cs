using ApolloTests.Data.Entities;
using ApolloTests.Data.Entity;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ApolloTests.Data.Form
{
    public class Recipient:BaseEntity
    {

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("DeliveryMethodIdsInternal")]
        public string? DeliveryMethodIdsInternal { get; set; }

        [JsonProperty("FormsServiceRuleFormEntityId")]
        public int FormsServiceRuleFormEntityId { get; set; }

        [JsonProperty("RecipientRoleTypeId")]
        public int RecipientRoleTypeId { get; set; }

        public string RecipientTypeCode => RecipientRoleTypeId ==-1? "SYSTEM" : SQL.executeQuery($"SELECT * FROM [party].[RoleType] where Id={RecipientRoleTypeId}")[0]["Code"];

        public string RecipientTypeName=> RecipientRoleTypeId == -1 ? "SYSTEM" : SQL.executeQuery($"SELECT * FROM [party].[RoleType] where Id={RecipientRoleTypeId}")[0]["Name"];

    }
}
