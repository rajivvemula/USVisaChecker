using TechTalk.SpecFlow;

namespace BiBerkLOB.Source.Helpers.RetryPolicy;

public class StepRetryArgs
{
    public string? Text { get; set; }
    public string? MultilineTextArgument { get; set; }
    public Table? TableArgument { get; set; }
    public string? Keyword { get; set; }
}