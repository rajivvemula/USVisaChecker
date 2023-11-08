using System;
using System.Linq;
using ApolloQA.Source.Helpers;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class ApolloGateway
{
    public ApolloQuestionDefinition GetQuestionDefinitionFromText(string questionText)
    {
        var questionQuery = QuestionQuery(questionText, "QuestionText");
        var questionResult = SQL.ExecuteQuery(questionQuery).First();

        var answerQuery = AnswerQuery((long)questionResult["QuestionId"]);
        var answerResult = SQL.ExecuteQuery(answerQuery);
        
        return ApolloQuestionDefinition.FromResult(questionResult, answerResult);
    }

    public ApolloQuestionDefinition GetQuestionDefinitionFromAlias(string questionAlias)
    {
        var questionQuery = QuestionQuery(questionAlias, "Alias");
        var questionResult = SQL.ExecuteQuery(questionQuery).First();

        var answerQuery = AnswerQuery((long)questionResult["QuestionId"]);
        var answerResult = SQL.ExecuteQuery(answerQuery);

        return ApolloQuestionDefinition.FromResult(questionResult, answerResult);
    }

    public VehicleType GetVehicleTypeFromButtonLabel(string vehicleTypeLabel)
    {
        var query = @$"SELECT TOP 1
                        t.Code
                        FROM [risk].[BodySubCategoryType] t
                        WHERE t.StatusId = '0' 
                        AND t.Name LIKE '{vehicleTypeLabel}%'
                        ORDER BY t.Id DESC";
        var bodyTypes = SQL.ExecuteQuery(query);
        var firstBodyTypeValue = bodyTypes[0];
        string vehicleCode = firstBodyTypeValue["Code"];
        
        return new VehicleType(vehicleCode);
    }

    private static string QuestionQuery(string question, string columnToCheckBy)
    {
        var formattedQuestion = question.Replace("'", "''");
        return @$"Select top 1 Id as QuestionId, QuestionText, Alias as QuestionAlias, ExternalQuestionType as QuestionType
                FROM [question].[QuestionDefinition] with (nolock)
                where {columnToCheckBy} = '{formattedQuestion}'
                order by ROW_NUMBER() OVER(PARTITION BY QuestionText order by Id DESC)";
    }

    private static string AnswerQuery(long questionId)
    {
        return @$"SELECT Id as AnswerId, AnswerText, AnswerValue
                FROM [question].[QuestionAnswer]
                WHERE QuestionDefinitionId = {questionId}";
    }
}