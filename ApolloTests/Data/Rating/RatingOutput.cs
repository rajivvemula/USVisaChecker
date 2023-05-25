using ApolloTests.Data.Entities.Risk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApolloTests.Data.Rating
{
    public class RatingOutput
    {
        [JsonIgnore]
        String fileName;

        public RatingOutput(IObjectContainer OC)
        {
            var featurectx = OC.Resolve<FeatureContext>();
            var scenarioctx = OC.Resolve<ScenarioContext>();
            var testctx = OC.Resolve<TestContext>();
            fileName = string.Format($"ReportTemplates/{featurectx.FeatureInfo.Title}_{scenarioctx.ScenarioInfo.Title}").Replace(" ", "_");
            if(scenarioctx.ScenarioInfo.Arguments.Count>0)
            {
                fileName += "_"+scenarioctx.ScenarioInfo.Arguments[0].ToString();
            }
            fileName += ".html";
            testctx.AddResultFile(fileName);

        }
        public List<RatingResult> Results { get; set; } = new();
        public List<string> Errors { get; set; } = new();
        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
        }
        public string generateReport()
        {
            var template = "./ReportTemplates/report.html";
            fileName ??= template; 
            var report = File.ReadAllTextAsync(template).Result;
            report = report.Replace("@RATING_OUTPUT_RAW_ESCAPED_JSON", HttpUtility.JavaScriptStringEncode(this.ToString()));
            File.WriteAllText(fileName, report);
            Log.Info(Path.Combine($"file://", $"{Path.GetFullPath(fileName)}"));
            return fileName;
        }
    }
    public class RatingResult
    {
        public Factor.Resolvable FindFactor(string name)=> Factors.First(it=> it.FullName == name || it.Name==name);
        public List<Factor.Resolvable> Factors { get; set; }

        [JsonProperty("CoverageCode")]
        public string CoverageCode { get; set; }

        [JsonProperty("CoverageName")]
        public string CoverageName { get; set; }

        [JsonProperty("TotalPremium")]
        public decimal TotalPremium { get; set; }

        [JsonProperty("Vehicle")]
        public Vehicle Vehicle { get; set; }
    }
}
