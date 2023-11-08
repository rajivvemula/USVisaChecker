using BiBerkLOB.StepDefinition.General;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Assert = HitachiQA.Assert;

namespace BiBerkLOB.StepDefinition.MetaTestSteps;

[Binding]
public sealed class QuoteSavingTestStepDefinitions
{
    private readonly PersistentQuoteIdObject _quoteIdObject;

    public QuoteSavingTestStepDefinitions(PersistentQuoteIdObject quoteIdObject)
    {
        _quoteIdObject = quoteIdObject;
    }

    [Given(@"no quote ID is set")]
    public void GivenNoQuoteIDIsSet()
    {
        _quoteIdObject.QuoteId = "";
    }

    [Then(@"saved quote ID should persist")]
    public void ThenSavedQuoteIDShouldPersist()
    {
        Assert.AreNotEqual(_quoteIdObject.QuoteId, "");
        Assert.AreNotEqual(_quoteIdObject.LOB, "");
        Assert.AreNotEqual(_quoteIdObject.Industry, "");
        Assert.AreNotEqual(_quoteIdObject.State, "");
        StringAssert.IsMatch("^[0123456789]+$", _quoteIdObject.QuoteId);
    }

    [Then(@"saved quote ID should have a reason")]
    public void ThenSavedQuoteIDShouldHaveAReason()
    {
        Assert.IsFalse(string.IsNullOrEmpty(_quoteIdObject.SaveReason));
    }
    
    [Then(@"saved quote ID should not have a reason")]
    public void ThenSavedQuoteIDShouldNotHaveAReason()
    {
        Assert.IsTrue(string.IsNullOrEmpty(_quoteIdObject.SaveReason));
    }

}