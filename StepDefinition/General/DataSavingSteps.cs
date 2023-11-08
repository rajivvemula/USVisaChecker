using System;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General;

[Binding]
public sealed class DataSavingSteps
{
    private readonly PersistentQuoteIdObject _quoteIdObject;
    private readonly DataFileSaver _dataFileSaver;

    public DataSavingSteps(PersistentQuoteIdObject quoteIdObject, DataFileSaver dataFileSaver)
    {
        _quoteIdObject = quoteIdObject;
        _dataFileSaver = dataFileSaver;
    }

    [Then(@"output the saved quote ID")]
    public void SaveQuoteIdToFile()
    {
        _dataFileSaver.SaveDataFile($"QuoteIdsForTesting-{DateTime.Now:yyyy-MM-DD-HH-mm-ss}", _quoteIdObject);
    }
}