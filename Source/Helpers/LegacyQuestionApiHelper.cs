using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using BiBerkLOB.Source.Helpers.LegacyModels;
using HitachiQA.Helpers;
using IdentityModel.Client;
using RestSharp;

namespace BiBerkLOB.Source.Helpers;

public static class LegacyQuestionApiHelper
{
    private static readonly HttpClient _httpClient = new();
    private static SemaphoreSlim _feQuestionDefLock = new(1, 1);
    private static List<TFEQuestion> _feQuestions;

    private static SemaphoreSlim _plQuestionDefLock = new(1, 1);
    private static Dictionary<Tuple<string, string>, UwTestingQuestionDefinition> _questionTextToDefinitionPL;
    
    private static SemaphoreSlim _wcQuestionDefLock = new(1, 1);
    private static Dictionary<Tuple<string, string>, UwTestingQuestionDefinition> _questionTextToDefinitonWC;

    public static async Task<LegacyQuestionInfo> GetFEQuestionDefinitionByText(string questionText)
    {
        if (_feQuestions == null)
        {
            await _feQuestionDefLock.WaitAsync();

            if (_feQuestions == null)
            {
                _feQuestions = await GetAllFEQuestions();
            }

            _feQuestionDefLock.Release();
        }
        return LegacyQuestionInfo.FromFeQuestion(_feQuestions.FirstOrDefault(q => q.QuestionText.Equals(questionText, StringComparison.OrdinalIgnoreCase)));
    }

    public static async Task<LegacyQuestionInfo> GetPLQuestionDefinitionByText(string questionText, string quoteKeyword)
    {
        if (_questionTextToDefinitionPL == null)
        {
            await _plQuestionDefLock.WaitAsync();

            if (_questionTextToDefinitionPL == null)
            {
                _questionTextToDefinitionPL = await GetAllPLQuestionDefinitions();
            }

            _plQuestionDefLock.Release();
        }

        var dictionaryKey = Tuple.Create(questionText.Trim(), quoteKeyword);
        return _questionTextToDefinitionPL.ContainsKey(dictionaryKey)
            ? LegacyQuestionInfo.FromUnderwriting(_questionTextToDefinitionPL[dictionaryKey])
            : null;
    }

    public static async Task<LegacyQuestionInfo> GetWCQuestionDefinitionByText(string questionText, string quoteKeyword)
    {
        if (_questionTextToDefinitonWC == null)
        {
            await _wcQuestionDefLock.WaitAsync();

            if (_questionTextToDefinitonWC == null)
            {
                _questionTextToDefinitonWC = await GetAllWCQuestionDefinitions();
            }

            _wcQuestionDefLock.Release();
        }

        var dictionaryKey = Tuple.Create(questionText.Trim(), quoteKeyword);
        return _questionTextToDefinitonWC.ContainsKey(dictionaryKey)
            ? LegacyQuestionInfo.FromUnderwriting(_questionTextToDefinitonWC[dictionaryKey])
            : null;
    }

    private static async Task<List<TFEQuestion>> GetAllFEQuestions()
    {
        var baseUrl = AppSettings.PortalSvcBaseUrl;
        var endpoint = "FEQuestions/Read";
        var requestBody = new Dictionary<string, object>()
        {
            {"getQuestionsOnly", true}
        };

        var bearerToken = await LegacyApiAuthHelper.GetBearerToken();

        var request = new RestRequest(new Uri($"{baseUrl}/{endpoint}"), Method.Post);
        request.Resource = endpoint;
        request.RequestFormat = DataFormat.Json;
        request.AddJsonBody(requestBody);

        var restClient = new RestClient(_httpClient, new RestClientOptions
        {
            BaseUrl = new Uri(baseUrl)
        });

        restClient.AcceptedContentTypes = new[] { "application/json" };
        restClient.AddDefaultHeader("Authorization", bearerToken);

        var response = await restClient.PostAsync<FEApiResponse>(request);

        return response.TFEQuestions.ToList();
    }

    private static async Task<Dictionary<Tuple<string, string>, UwTestingQuestionDefinition>> GetAllPLQuestionDefinitions()
    {
        var baseUrl = AppSettings.PortalSvcBaseUrl;
        var endpoint = "QuestionsTest/QuestionDefinitionsPL";

        var bearerToken = await LegacyApiAuthHelper.GetBearerToken();
        
        var restClient = new RestClient(_httpClient, new RestClientOptions
        {
            BaseUrl = new Uri(baseUrl)
        });
        
        restClient.AcceptedContentTypes = new[] {"application/json"};
        restClient.AddDefaultHeader("Authorization", bearerToken);

        var questionDefinitions = await restClient.GetJsonAsync<List<UwTestingQuestionDefinition>>(endpoint);
        if (questionDefinitions == null) throw new Exception("Couldn't get PL question definitions");

        return ConvertListToDictionary(questionDefinitions);
    }

    private static async Task<Dictionary<Tuple<string, string>, UwTestingQuestionDefinition>> GetAllWCQuestionDefinitions()
    {
        var baseUrl = AppSettings.PortalSvcBaseUrl;
        var endpoint = "QuestionsTest/QuestionDefinitionsWC";

        var bearerToken = await LegacyApiAuthHelper.GetBearerToken();

        var restClient = new RestClient(_httpClient, new RestClientOptions
        {
            BaseUrl = new Uri(baseUrl)
        });

        restClient.AcceptedContentTypes = new[] { "application/json" };
        restClient.AddDefaultHeader("Authorization", bearerToken);

        var questionDefinitions = await restClient.GetJsonAsync<List<UwTestingQuestionDefinition>>(endpoint);
        if (questionDefinitions == null) throw new Exception("Couldn't get WC question definitions");
        return ConvertListToDictionary(questionDefinitions);
    }

    private static Dictionary<Tuple<string, string>, UwTestingQuestionDefinition> ConvertListToDictionary(List<UwTestingQuestionDefinition> questionDefinitions)
    {
        var questionDefinitionDictionary = new Dictionary<Tuple<string, string>, UwTestingQuestionDefinition>();
        foreach (var questionDefinition in questionDefinitions)
        {
            var dictionaryKey = Tuple.Create(questionDefinition.QuestionText.Trim(), questionDefinition.Keyword);

            if (!questionDefinitionDictionary.ContainsKey(dictionaryKey))
            {
                questionDefinitionDictionary.Add(dictionaryKey, questionDefinition);
            }
        }

        return questionDefinitionDictionary;
    }
}