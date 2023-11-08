using System.Collections.Generic;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General;

[ResettableContextObject]
public class ExpectedCoverageCards
{
    [Clearable] public List<CoverageType> Coverages { get; set; } = new List<CoverageType>();
}