using IdentityModel.Client;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace BiBerkLOB.Source.Helpers;

public class LegacyApiAuthHelper
{
    private static readonly HttpClient _httpClient = new();

    public static async Task<string> GetBearerToken()
    {
        var authUrl = AppSettings.SecuritySvcUrl;
        var clientId = "PortalAPIClient";
        var clientSecret = "PortalAPISecretValue";
        var scope = "PortalSvc";

        var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = authUrl.TrimEnd('/') + "/connect/token",
            ClientId = clientId,
            ClientSecret = clientSecret,
            Scope = scope
        });

        if (tokenResponse.IsError) throw new Exception("Could not get new auth token from " + authUrl + " for PortalSvc");

        return "Bearer " + tokenResponse.AccessToken;
    }
}