using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

using System.Net.Http;
using System.Net.Http.Headers;

namespace ApolloQA.Helpers
{
    class RestAPI
    {
        private IWebDriver driver;

        private static String host= "https://bibaoqa-fd.azurefd.net/api";

        public RestAPI(IWebDriver driver)
        {
            this.driver = driver;
            
        }

        public Object GET( String URL)
        {
            if (!URL.StartsWith(host))
            {
                URL = host + URL; 
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", getAuthToken());

            HttpResponseMessage response  = client.GetAsync(URL).Result;
            return ConsumeResponse(response);

        }
        public Object POST(String URL, Object body)
        {
            if (!URL.StartsWith(host))
            {
                URL = host + URL;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", getAuthToken());

            String bodyString;
            if (body is String)
            {
                bodyString = (String)body;
            }
            else
            {
                bodyString = JsonSerializer.Serialize(body);
            }

            HttpContent content = new StringContent(bodyString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;
            return ConsumeResponse(response);
        }

        private Object ConsumeResponse(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var dataObjects = response.Content.ReadAsByteArrayAsync().Result;
            var utf8Reader = new Utf8JsonReader(dataObjects);

            return JsonSerializer.Deserialize<Object>(ref utf8Reader);
        }

        private String getAuthToken()
        {

            String currentUser= (String)((IJavaScriptExecutor)driver).ExecuteScript("return window.localStorage.getItem('currentUser')");
            return JsonSerializer.Deserialize<JsonElement>(currentUser).GetProperty("accessToken").GetString();

        }
    }
}
