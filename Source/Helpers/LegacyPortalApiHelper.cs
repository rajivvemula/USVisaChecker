using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Helpers.LegacyModels;
using RestSharp;

namespace BiBerkLOB.Source.Helpers;

public class LegacyPortalApiHelper
{
    private static readonly HttpClient _httpClient = new();

    /// <summary>
    /// Returns the state that contains the zip code
    /// </summary>
    /// <param name="zipCode"></param>
    /// <returns>State if zip code is valid, null otherwise</returns>
    public static async Task<State> GetStateFromZipCode(string zipCode)
    {
        var requestBody = new Dictionary<string, object>()
        {
            {"zipCode", zipCode}
        };

        var cityStateZip = await SearchPortalSvcForCityStateZip(requestBody);

        return cityStateZip.Any() ? State.FromAny(cityStateZip[0].State) : null;
    }

    private static async Task<CityStateZipModel[]> SearchPortalSvcForCityStateZip(Dictionary<string, object> requestBody)
    {
        var baseUrl = AppSettings.PortalSvcBaseUrl;
        var endpoint = $"CityStateZipCodeSearch/Read";

        var bearerToken = await LegacyApiAuthHelper.GetBearerToken();

        var request = new RestRequest(new Uri($"{baseUrl}/{endpoint}"), Method.Post);
        request.Resource = endpoint;
        request.RequestFormat = DataFormat.Json;
        request.AddHeader("content-type", "application/json");
        request.AddJsonBody(requestBody);

        var restClient = new RestClient(_httpClient, new RestClientOptions
        {
            BaseUrl = new Uri(baseUrl)
        });

        restClient.AcceptedContentTypes = new[] { "application/json" };
        restClient.AddDefaultHeader("Authorization", bearerToken);

        var response = await restClient.PostAsync<ZipCodeResponse>(request);
        var cityStateZip = response.TCityStateZipCodes;

        return cityStateZip;
    }
}