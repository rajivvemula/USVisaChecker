using HitachiQA;
using HitachiQA.Driver;
using System.ComponentModel;

namespace BiBerkLOB.Pages.Other
{
    [ResettableContextObject]
    public class PretestSettingsObject
    {
        [DefaultValue(true)] public bool QuestionInTableShouldAppear { get; set; } = true;
    }
}