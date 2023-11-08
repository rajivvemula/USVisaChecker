namespace BiBerkLOB.Source.Helpers.LegacyModels;

/// <summary>
/// partial FE question DTO from API
/// </summary>
public class TFEQuestion
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; }
    public string QuestionType { get; set; }
}