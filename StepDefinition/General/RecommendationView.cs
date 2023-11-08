using System.ComponentModel;
using System.Reflection;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General;

public enum RecommendationView
{
    [Description("get-a-quote")]
    Simple,
    [Description("get-a-quote/berkshire-hathaway-business-insurance")] 
    Pie
}

public static class RecommendationViewHelper
{
    public static void NavigateToLandingPage(this RecommendationView recommendationView)
    {
        var urlPath = GetDescriptionValue(recommendationView);

        UserActions.Navigate(urlPath);
    }

    private static string GetDescriptionValue(RecommendationView recommendationView)
    {
        return typeof(RecommendationView)
            .GetField(recommendationView.ToString())
            .GetCustomAttribute<DescriptionAttribute>(false)
            .Description;
    }
}