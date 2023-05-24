using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitachiQA.Source.Helpers.ADOServices.Models
{
    public class TestSuite
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public SuiteTypes SuiteType { get; set; } = SuiteTypes.StaticTestSuite;

        [JsonProperty("suiteType")]
        public string SuiteTypeStr
        {
            get
            {
                return SuiteType.ToString();
            }
            set
            {
                SuiteType = Enum.Parse<SuiteTypes>(value);
            }
        }

        [JsonProperty("path")]
        public List<string> Path { get; set; }

        [JsonProperty("queryString")]
        public string QueryString { get; set; }

        [JsonProperty("queryTags")]
        public List<string> QueryTags { get; set; }

        [JsonProperty("configuration")]
        public string? Configuration { get; set; }

        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
        }
        public void HydrateFrom(JToken apiObj)
        {
            Id = apiObj.Value<int>("id");
            Name = apiObj.Value<string>("name");
            SuiteTypeStr = apiObj.Value<string>("suiteType");
            QueryString = apiObj.Value<string>("queryString");
        }
    }
    public enum SuiteTypes
    {
        DynamicTestSuite,
        StaticTestSuite,
        RequirementTestSuite
    }
}
