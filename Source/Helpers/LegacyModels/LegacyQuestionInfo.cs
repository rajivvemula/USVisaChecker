namespace BiBerkLOB.Source.Helpers.LegacyModels;

/// <summary>
/// Model for legacy question info needed for automation
/// </summary>
public class LegacyQuestionInfo
{
    public string DataQa { get; set; }
    public string QuestionText { get; set; }
    public string SentencesFormat { get; set; }
    public string QuestionType { get; set; }

    public static LegacyQuestionInfo FromUnderwriting(UwTestingQuestionDefinition question)
    {
        if (question == null)
        {
            return null;
        }

        return new LegacyQuestionInfo()
        {
            QuestionText = question.QuestionText,
            QuestionType = question.QuestionType,
            DataQa = question.QuestionId.ToString(),
            SentencesFormat = question.SentencesFormat,
        };
    }

    public static LegacyQuestionInfo FromFeQuestion(TFEQuestion question)
    {
        if (question == null)
        {
            return null;
        }

        return new LegacyQuestionInfo()
        {
            QuestionText = question.QuestionText,
            QuestionType = question.QuestionType,
            DataQa = "fe_" + question.QuestionId
        };
    }
}