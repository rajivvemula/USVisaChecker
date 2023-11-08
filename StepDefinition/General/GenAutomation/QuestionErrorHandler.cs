using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages.Other;
using System;

namespace BiBerkLOB.StepDefinition.General.GenAutomation;

public class QuestionErrorHandler
{
    private readonly PretestSettingsObject _pretestSettingsObject;

    public QuestionErrorHandler(PretestSettingsObject pretestSettingsObject)
    {
        _pretestSettingsObject = pretestSettingsObject;
    }

    public void ThrowErrorIfQuestionShouldAppear(Exception ex)
    {
        if (_pretestSettingsObject.QuestionInTableShouldAppear)
        {
            throw new AggregateException(ex);
        }
    }

    public void IsErrorVisible()
    {
        if (CA_ReusableElements.OneOrMoreQuestionsTxt.AssertElementNotPresent())
        {
            CA_ReusableElements.FirstErrorMsg.AssertElementNotPresent(5);
        }
        else  CA_ReusableElements.FirstErrorMsg.AssertIsElementVisibleInViewport(); 
     }
 }