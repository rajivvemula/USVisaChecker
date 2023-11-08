using HitachiQA;
using System.ComponentModel;

namespace BiBerkLOB.StepDefinition.General.GenAutomation;

[ResettableContextObject]
public class RecommendationViewContext
{
    [DefaultValue(RecommendationView.Simple)]
    public RecommendationView RecommendationView { get; set; } = RecommendationView.Simple;
}