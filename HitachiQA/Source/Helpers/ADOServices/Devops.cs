using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HitachiQA.Source.Helpers.ADOServices
{
    public class Devops
    {
        private HttpClient Client { get; }
        public Devops(IConfiguration config)
        {
           
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://dev.azure.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                           Convert.ToBase64String(
                               System.Text.ASCIIEncoding.ASCII.GetBytes(
                                   string.Format("{0}:{1}", "", config.GetVariable("PAT_TOKEN")))));
            client.DefaultRequestHeaders.Add("User-Agent", "Apollo Automation");
            client.Timeout = TimeSpan.FromMinutes(1);
            Client= client;
        }

        private HttpContent? PrepareContent(dynamic body, bool patchContentType=false)
        {
            if(body == null) {
                return null;
            }
            String bodyString;
            if (body is String)
            {
                bodyString = body;
            }
            else
            {
                bodyString = JsonConvert.SerializeObject(body);
            }

            HttpContent content = new StringContent(bodyString, Encoding.UTF8, patchContentType? "application/json-patch+json": "application/json");
            return content;
        }

        public HttpResponseMessage Send(HttpRequestMessage msg, dynamic body=null, bool patchContentType=false)
        {
            msg.Content = PrepareContent(body, patchContentType);
            var res = Client.Send(msg);
            try
            {
                res.EnsureSuccessStatusCode();
            }
            catch(Exception)
            {
                Log.Debug(msg.RequestUri.AbsoluteUri);
                Log.Debug(body!=null? Log.stringify(body):"null");
                Log.Debug(res.Content.ReadAsStringAsync());
                throw;
            }
            return res;
        }

        public string GetProjectId(string Org, string Proj)
        {
            var msg = new HttpRequestMessage(HttpMethod.Get, $"{Org}/_apis/Projects/{Proj}?api-version=7.0");
            var res = Send(msg);

            var jsonStr = res.Content.ReadAsStringAsync().Result;

            try
            {
                var resObj = JObject.Parse(jsonStr);
                return resObj.Value<string>("id");
            }
            catch (Exception ex)
            {
                throw new Exception($"error parsing res after creating new suite \n{jsonStr}\n", ex);
            }
        }



    }
}
