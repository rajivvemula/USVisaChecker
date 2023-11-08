using BiBerkLOB.Pages.CommAuto;
using System.Linq;
using BiBerkLOB.Pages;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CAOperationsAutomation
{
    private const int QUESTION_APPEARANCE_WAIT = 5;

    private readonly CASummaryObject _caSummaryObject;
    private readonly ApolloGateway _apolloGateway;
    private bool isAmazonDeliveryService = false;

    public CAOperationsAutomation(CASummaryObject caSummaryObject, ApolloGateway apolloGateway)
    {
        _caSummaryObject = caSummaryObject;
        _apolloGateway = apolloGateway;
    }

    public virtual void AnswerSingleSelectButton(string questionAlias, string answer)
    {
        if (questionAlias.Equals("VehicleRadius")) _caSummaryObject.VehicleRadiusAnswer = answer;
        var input = CA_OperationsPage.GetSingleSelectInput(questionAlias);
        input.AssertAllElements(QUESTION_APPEARANCE_WAIT);
        input.EnterResponse(answer, QUESTION_APPEARANCE_WAIT);
    }

    public virtual void AnswerSingleSelectDropdown(string questionAlias, string answer)
    {
        var input = CA_OperationsPage.GetSingleSelectDropdownInput(questionAlias);
        input.AssertAllElements(QUESTION_APPEARANCE_WAIT);
        input.EnterResponse(answer, QUESTION_APPEARANCE_WAIT);
    }

    public virtual void AnswerYesNoButton(string questionAlias, string yesOrNo)
    {
        var input = CA_OperationsPage.GetBooleanInput(questionAlias);
        input.AssertAllElements(QUESTION_APPEARANCE_WAIT);
        input.EnterResponse(yesOrNo, QUESTION_APPEARANCE_WAIT);
    }

    public virtual void ClickOnCheckBoxes(string questionAlias, string answerList)
    {
        var input = CA_OperationsPage.GetMultiSelectInput(questionAlias);
        input.AssertAllElements(QUESTION_APPEARANCE_WAIT);
        input.EnterResponse(answerList, QUESTION_APPEARANCE_WAIT);
    }

    public virtual void AnswerTextBox(string questionAlias, string answer)
    {
        var input = CA_OperationsPage.GetTextBoxInput(questionAlias);
        input.AssertAllElements(QUESTION_APPEARANCE_WAIT);
        input.EnterResponse(answer, QUESTION_APPEARANCE_WAIT);
    }

    public virtual void ClickSoloCheckbox(string questionAlias, string trueOrFalse)
    {
        var input = CA_OperationsPage.GetSoloCheckboxInput(questionAlias);
        input.AssertAllElements(QUESTION_APPEARANCE_WAIT);
        input.EnterResponse(trueOrFalse);
        AutomationHelper.RetryUntilSucceeded(() => input.EnterResponse(trueOrFalse, QUESTION_APPEARANCE_WAIT), 4);
    }

    public void SaveOperationsQuestion(OperationsQuestionObject operationsQuestionObject)
    {
        _caSummaryObject.OpQuestions.Add(operationsQuestionObject);
    }

    public void VerifyFMCSADefaultAnswer(string theQuestion, string theAnswer, string questionAlias) // US-96615
    {
        if (theQuestion.Equals("Do you participate in a delivery service on behalf of Amazon.com, Inc.?") && theAnswer.Equals("Yes")) isAmazonDeliveryService = true;

        if (theQuestion.Equals("Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?")
            && (_caSummaryObject.VehicleRadiusAnswer.Equals("301 to 500 miles") || _caSummaryObject.VehicleRadiusAnswer.Equals("501 miles or more") || isAmazonDeliveryService))
            CA_OperationsPage.GetBooleanButton(questionAlias, "yes").AssertIsSelectedAngular();
    }

public void ValidateStepper()
{
    AutomationHelper.ValidateElementsNotPresent(new[]
    {
            Reusable_PurchasePath.CAStepper_1Coverage_Current,
            Reusable_PurchasePath.CAStepper_2Operations_Before,
            Reusable_PurchasePath.CAStepper_2Operations_Past,
            Reusable_PurchasePath.CAStepper_3AboutYou_Current,
            Reusable_PurchasePath.CAStepper_3AboutYou_Past,
            Reusable_PurchasePath.CAStepper_4Summary_Current
        }, 2);

    AutomationHelper.ValidateElements(new[]
    {
            Reusable_PurchasePath.CAStepper_1Coverage_Past,
            Reusable_PurchasePath.CAStepper_2Operations_Current,
            Reusable_PurchasePath.CAStepper_3AboutYou_Before,
            Reusable_PurchasePath.CAStepper_4Summary_Before,
            Reusable_PurchasePath.CAStepper_5Quote_Before,
            Reusable_PurchasePath.CAStepper_6Purchase_Before
        }, 2);
}

// GETTING QUESTIONS FROM APOLLO 
public ApolloQuestionDefinition GetQuestionDefinitionFromText(string theQuestion)
{
    if (QuestionAsksProvideClaimsHistory(theQuestion))
    {
        return GetQuestionDefinitionForClaimsHistory();
    }
    if (QuestionAsksNumAutoInsuranceClaims(theQuestion))
    {
        return GetQuestionDefinitionForAutoInsuranceClaims();
    }
    return _apolloGateway.GetQuestionDefinitionFromText(theQuestion);
}

public ApolloQuestionDefinition GetQuestionDefinitionFromAlias(string questionAlias)
{
    return _apolloGateway.GetQuestionDefinitionFromAlias(questionAlias);
}

private ApolloQuestionDefinition GetQuestionDefinitionForAutoInsuranceClaims()
{
    return _apolloGateway.GetQuestionDefinitionFromText("How many auto insurance claims did your business file {{ root.YearsInBusiness < 3 ? \"since it started?\" : \"in the last 3 years?\" }}");
}
private ApolloQuestionDefinition GetQuestionDefinitionForClaimsHistory()
{
    return _apolloGateway.GetQuestionDefinitionFromText("I agree to provide a claims history (also known as a \"loss run\") that matches the information in this application {{ root.YearsInBusiness < 3 ? \"dating back to when I started my company\" : \"for the last 3 years\" }} within 30 days of {{ root.EffectiveDate.Value.ToString(\"MM/dd/yyyy\") }}.");
}

private static bool QuestionAsksNumAutoInsuranceClaims(string theQuestion)
{
    var possibleWordings = new string[]
    {
            "How many auto insurance claims did your business file since it started?",
            "How many auto insurance claims did your business file in the last 3 years?"
    };
    return possibleWordings.Contains(theQuestion);
}
private static bool QuestionAsksProvideClaimsHistory(string theQuestion)
{
    var possibleWordings = new string[]
    {
            "I agree to provide a claims history (also known as a \"loss run\") that matches the information in this application dating back to when I started my company within 30 days of {effective date}.",
            "I agree to provide a claims history (also known as a \"loss run\") that matches the information in this application for the last 3 years within 30 days of {effective date}."
    };
    return possibleWordings.Contains(theQuestion);
}
}