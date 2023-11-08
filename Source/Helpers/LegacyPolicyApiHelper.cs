using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BiBerkLOB.Source.Helpers.LegacyModels;
using RestSharp;

namespace BiBerkLOB.Source.Helpers;

public class LegacyPolicyApiHelper
{
    private static readonly HttpClient _httpClient = new();

    private static SemaphoreSlim _repoLock = new(1, 1);
    private static Dictionary<string, PolicyRepository> _currentEqualsTotalDue = new Dictionary<string, PolicyRepository>();
    private static Dictionary<string, PolicyRepository> _currentAndPastDueExist = new Dictionary<string, PolicyRepository>();
    private static Dictionary<string, PolicyRepository> _readyForRenewal = new Dictionary<string, PolicyRepository>();
    private static PolicyRepository _wcAbleToEnterAuditPath = new PolicyRepository();

    /// <summary>
    /// Gets a policy where Current Due = Total Due
    /// </summary>
    /// <param name="lob">Two-letter LOB abbreviation</param>
    /// <param name="peekOnly">flag to peek instead of commit to changing policy</param>
    /// <returns>Some policy</returns>
    /// <remarks>
    /// "Peeking" doesn't remove tracking of the policy, "committing"
    /// treats the policy as no longer viable and moves on to a different policy
    /// </remarks>
    public static async Task<LegacyPolicy> GetPolicyCurrentEqualsTotalDue(string lob, bool peekOnly = false)
    {
        await EnsureLobRepositoryExists(_currentEqualsTotalDue, lob);
        await EnsureRepositoryInitialized(_currentEqualsTotalDue[lob], "CurrentEqualsTotalDue", lob);
        return await (peekOnly ? _currentEqualsTotalDue[lob].Peek() : _currentEqualsTotalDue[lob].Pop());
    }

    /// <summary>
    /// Gets a policy that has bot Current Due and Past Due amounts
    /// </summary>
    /// <param name="lob">Two-letter LOB abbreviation</param>
    /// <param name="peekOnly">flag to peek instead of commit to changing policy</param>
    /// <returns>Some policy</returns>
    /// <remarks>
    /// "Peeking" doesn't remove tracking of the policy, "committing"
    /// treats the policy as no longer viable and moves on to a different policy
    /// </remarks>
    public static async Task<LegacyPolicy> GetPolicyCurrentAndPastDueExist(string lob, bool peekOnly = false)
    {
        await EnsureLobRepositoryExists(_currentAndPastDueExist, lob);
        await EnsureRepositoryInitialized(_currentAndPastDueExist[lob], "CurrentAndPastDueExists", lob);
        return await (peekOnly ? _currentAndPastDueExist[lob].Peek() : _currentAndPastDueExist[lob].Pop());
    }

    /// <summary>
    /// Gets a policy that is eligible for renewal
    /// </summary>
    /// <param name="lob">Two-letter LOB abbreviation</param>
    /// <param name="peekOnly">flag to peek instead of commit to changing policy</param>
    /// <returns>Some policy</returns>
    /// <remarks>
    /// "Peeking" doesn't remove tracking of the policy, "committing"
    /// treats the policy as no longer viable and moves on to a different policy
    /// </remarks>
    public static async Task<LegacyPolicy> GetPolicyReadyForRenewal(string lob, bool peekOnly = false)
    {
        await EnsureLobRepositoryExists(_readyForRenewal, lob);
        await EnsureRepositoryInitialized(_readyForRenewal[lob], "ReadyForRenewal", lob);
        return await (peekOnly ? _readyForRenewal[lob].Peek() : _readyForRenewal[lob].Pop());
    }

    /// <summary>
    /// Gets a WC policy that can enter the audit path
    /// </summary>
    /// <param name="peekOnly">flag to peek instead of commit to changing policy</param>
    /// <returns>Some policy</returns>
    /// <remarks>
    /// "Peeking" doesn't remove tracking of the policy, "committing"
    /// treats the policy as no longer viable and moves on to a different policy
    /// </remarks>
    public static async Task<LegacyPolicy> GetPolicyAbleToEnterAuditPath(bool peekOnly = false)
    {
        await EnsureRepositoryInitialized(_wcAbleToEnterAuditPath, "WC/AbleToEnterAuditPath");
        return await (peekOnly ? _wcAbleToEnterAuditPath.Peek() : _wcAbleToEnterAuditPath.Pop());
    }

    private static async Task EnsureLobRepositoryExists(Dictionary<string, PolicyRepository> lobRepos, string lob)
    {
        await _repoLock.WaitAsync();
        if (!lobRepos.ContainsKey(lob))
        {
            lobRepos[lob] = new PolicyRepository();
        }
        _repoLock.Release();
    }

    private static async Task EnsureRepositoryInitialized(PolicyRepository repository, string actionEndpoint, string lob)
    {
        if (!repository.IsInitialized())
        {
            var policies = await GetPolicies(actionEndpoint, lob);
            await repository.Init(policies);
        }
    }

    private static async Task EnsureRepositoryInitialized(PolicyRepository repository, string actionEndpoint)
    {
        if (!repository.IsInitialized())
        {
            var policies = await GetPolicies(actionEndpoint);
            await repository.Init(policies);
        }
    }

    private static async Task<List<LegacyPolicy>> GetPolicies(string actionEndpoint, string lob = null)
    {
        var baseUrl = AppSettings.PortalSvcBaseUrl;
        var endpoint = $"PolicyTests/{actionEndpoint}";

        var requestBody = new Dictionary<string, object>()
        {
            {"lob", lob}
        };

        var bearerToken = await LegacyApiAuthHelper.GetBearerToken();

        var request = new RestRequest(new Uri($"{baseUrl}/{endpoint}"), Method.Post);
        request.Resource = endpoint;
        request.RequestFormat = DataFormat.Json;
        request.AddHeader("content-type", "application/json");
        if (lob != null)
        {
            request.AddJsonBody(requestBody);
        }

        var restClient = new RestClient(_httpClient, new RestClientOptions
        {
            BaseUrl = new Uri(baseUrl)
        });

        restClient.AcceptedContentTypes = new[] { "application/json" };
        restClient.AddDefaultHeader("Authorization", bearerToken);

        var response = await restClient.PostAsync<PolicyApiResponse>(request);

        return response.Policies.ToList();
    }

    private class PolicyApiResponse
    {
        public object TOperationStatus { get; set; }
        public LegacyPolicy[] Policies { get; set; }
    }
}



public class PolicyRepository
{
    private static SemaphoreSlim _lock;

    private bool _initialized;
    private List<LegacyPolicy> _policies;
    private int _counter;

    public PolicyRepository()
    {
        _lock = new(1, 1);
        _initialized = false;
        _policies = new List<LegacyPolicy>();
        _counter = 0;
    }

    public bool IsInitialized()
    {
        return _initialized;
    }

    public async Task Init(List<LegacyPolicy> policies)
    {
        await _lock.WaitAsync();
        _policies = policies;
        _initialized = true;
        _lock.Release();
    }

    public async Task<LegacyPolicy> Pop()
    {
        await _lock.WaitAsync();
        try
        {
            if (_counter >= _policies.Count)
            {
                throw new Exception("No more policies to pop");
            }

            return _policies[_counter++];
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<LegacyPolicy> Peek()
    {
        await _lock.WaitAsync();
        try
        {
            if (_counter >= _policies.Count)
            {
                throw new Exception("No more policies to peek");
            }

            return _policies[_counter];
        }
        finally
        {
            _lock.Release();
        }
    }
}