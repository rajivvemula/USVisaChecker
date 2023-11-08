using System.Collections.Generic;
using BiBerkLOB.StepDefinition.General;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.Industries;

public class CoverageCardMap
{
    public static Dictionary<CoverageType, CoverageCard> LobCards => new Dictionary<CoverageType, CoverageCard>()
    {
        { CoverageType.WC, new CoverageCard(CoverageType.WC, "workers-compensation") },
        { CoverageType.GL, new CoverageCard(CoverageType.GL, "general-liability") },
        { CoverageType.BOP, new CoverageCard(CoverageType.BOP, "business-owners-policy") },
        { CoverageType.PL, new CoverageCard(CoverageType.PL, "professional-liability") },
        { CoverageType.CA, new CoverageCard(CoverageType.CA, "commercial-auto") },
        { CoverageType.Cyber, new CoverageCard(CoverageType.Cyber, "cyber") },
        { CoverageType.Umbrella, new CoverageCard(CoverageType.Umbrella, "umbrella") },
        { CoverageType.MM, new CoverageCard(CoverageType.MM, "medical-malpractice") },
    };
}