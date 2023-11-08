using System.Collections.Generic;
using System.Linq;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class ApolloQuestionDefinition
{
    public long QuestionId { get; private set; }
    public string QuestionText { get; private set; }
    public string QuestionAlias { get; private set; }
    public string QuestionType { get; private set; }
    public ApolloQuestionAnswer[] Answers { get; private set; }
    
    public ApolloQuestionAnswer GetAnswerFromText(string answerText)
    {
        return Answers?.SingleOrDefault(a => a.AnswerText == answerText);
    }

    public static ApolloQuestionDefinition FromResult(Dictionary<string, dynamic> questionResult, List<Dictionary<string, dynamic>> answerResult)
    {
        var questionDefinition = new ApolloQuestionDefinition()
        {
            QuestionId = questionResult["QuestionId"],
            QuestionText = questionResult["QuestionText"],
            QuestionAlias = questionResult["QuestionAlias"],
            QuestionType = questionResult["QuestionType"],
        };
        if (answerResult.Any())
        {
            questionDefinition.Answers = answerResult.Select(row => 
                new ApolloQuestionAnswer()
                {
                    AnswerId = row["AnswerId"],
                    AnswerText = row["AnswerText"],
                    AnswerValue = row["AnswerValue"]
                }
            ).ToArray();
        }

        return questionDefinition;
    }
}

public class ApolloQuestionAnswer
{
    public long AnswerId { get; init; }
    public string AnswerText { get; init; }
    public string AnswerValue { get; init; }
}