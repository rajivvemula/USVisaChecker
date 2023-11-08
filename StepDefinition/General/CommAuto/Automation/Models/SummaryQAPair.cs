using HitachiQA;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

public class SummaryQAPair
{
    private const int QA_PAIR_WAIT_SECONDS = 1;

    private readonly Element _question;
    private readonly Element _answer;

    public SummaryQAPair(Element question, Element answer)
    {
        _question = question;
        _answer = answer;
    }

    public void AssertAnswerVisible(int waitSeconds = QA_PAIR_WAIT_SECONDS)
    {
        _answer.AssertElementIsVisible(waitSeconds);
    }

    public void AssertAnsweredExactly(string answerText, int waitSeconds = QA_PAIR_WAIT_SECONDS)
    {
        AssertAnswerVisible(waitSeconds);
        _answer.AssertElementInnerTextEquals(answerText);
    }

    public void AssertAnsweredContains(string answerText, int waitSeconds = QA_PAIR_WAIT_SECONDS)
    {
        AssertAnswerVisible(waitSeconds);
        Assert.IsTrue(_answer.GetInnerText().Contains(answerText));
    }

    public void AssertQuestionVisible(int waitSeconds = QA_PAIR_WAIT_SECONDS)
    {
        _question.AssertElementIsVisible(waitSeconds);
    }

    public void AssertPairExactAnswer(string answerText, int waitSeconds = QA_PAIR_WAIT_SECONDS)
    {
        AssertQuestionVisible(waitSeconds);
        AssertAnsweredExactly(answerText);
    }

    public void AssertPairAnswerContains(string answerText, int waitSeconds = QA_PAIR_WAIT_SECONDS)
    {
        AssertQuestionVisible(waitSeconds);
        AssertAnsweredContains(answerText);
    }
}