using System;
using System.Text;
using OpenQA.Selenium;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApolloQA.Source.Helpers
{
    public class RestAPI
    {


        public static dynamic GET( String URL)
        {
            return GET(URL, new AuthenticationHeaderValue("Bearer", getAuthToken()));
        }
        public static dynamic GET(String URL, AuthenticationHeaderValue Authorization)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = Authorization;
            HttpResponseMessage response = client.GetAsync(processURL(URL)).Result;
            client.Dispose();
            return ConsumeResponse(response, URL);

        }
        public static dynamic POST(String URL, dynamic body)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(processURL(URL));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", getAuthToken());

            String bodyString;
            if (body is String)
            {
                bodyString = body;
            }
            else
            {
                bodyString = JsonConvert.SerializeObject(body);
            }

            HttpContent content = new StringContent(bodyString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(processURL(URL), content).Result;
            client.Dispose();
            return ConsumeResponse(response, URL, body);
        }


        public static dynamic PATCH(String URL, dynamic body)
        {
            return PATCH(URL, body, new AuthenticationHeaderValue("Bearer", getAuthToken()));
        }
        public static dynamic PATCH(String URL, dynamic body, AuthenticationHeaderValue Authorization)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(processURL(URL));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = Authorization;

            String bodyString;
            if (body is String)
            {
                bodyString = body;
            }
            else
            {
                bodyString = JsonConvert.SerializeObject(body);
            }

            HttpContent content = new StringContent(bodyString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PatchAsync(processURL(URL), content).Result;
            client.Dispose();
            return ConsumeResponse(response, URL,body);
        }
        private static String processURL(String URL)
        {
            if (!URL.StartsWith("http"))
            {
                if (!URL.StartsWith("/"))
                {
                    return Environment.GetEnvironmentVariable("SERVER_HOST") + "/"+URL;
                }
                return Environment.GetEnvironmentVariable("SERVER_HOST") + URL;
            }

            return URL;
        }

        private static dynamic ConsumeResponse(HttpResponseMessage response, string url, dynamic body=null)
        {
            if(!response.IsSuccessStatusCode)
            {
                Log.Critical(url);
                Log.Critical(body);

            }
            response.EnsureSuccessStatusCode();
            String dataObjects = response.Content.ReadAsStringAsync().Result;
            response.Dispose();

            try
            {
                return JsonConvert.DeserializeObject<dynamic>(dataObjects);
            }catch(JsonReaderException)
            {
                return dataObjects;
            }
        }

        private static String getAuthToken()
        {

            String currentUser= (String)((IJavaScriptExecutor)Driver.Setup.driver).ExecuteScript("return window.localStorage.getItem('currentUser')");
            return (String)JsonConvert.DeserializeObject<dynamic>(currentUser)["accessToken"];

        }
    }
}
