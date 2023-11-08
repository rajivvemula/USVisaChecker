namespace BiBerkLOB.Source.Helpers.LegacyModels;

/// <summary>
/// partial response to FE Questions API
/// </summary>
public class FEApiResponse
{
    public object TOperationStatus { get; set; }
    public TFEQuestion[] TFEQuestions { get; set; }
}