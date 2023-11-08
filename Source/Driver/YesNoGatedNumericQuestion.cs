using System;
using System.Collections.Generic;
using System.IO;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Source.Driver;

/// <summary>
/// Represents UX where you are asked a yes/no then asked to provide a number associated<br/>
/// with the question (ex: "Do you have any employees?" -> "How many employees?"
/// </summary>
public class YesNoGatedNumericQuestion
{
    private const int DEFAULT_WAIT_SECONDS = UserActions.DEFAULT_WAIT_SECONDS;

    private Func<int, bool> _numQuestionCondition;
    private Action _postYesOrNoAction;
    private Action _postNumAction;

    private InputSection _yesOrNoQuestion;
    private InputSection _numericQuestion;

    public YesNoGatedNumericQuestion(YesNoGatedNumericQuestionArgs args)
    {
        _numQuestionCondition = args.NumQuestionCondition;
        _postYesOrNoAction = args.PostYesOrNoAction;
        _postNumAction = args.PostNumAction;

        _yesOrNoQuestion = new YesOrNoInput(args.YesOrNoButtons)
            .WithExtraText(args.YesOrNoQuestionElements.ToArray());
        _numericQuestion = new TextBoxInput(args.NumQuestionTextBox)
            .WithExtraText(args.NumQuestionElements.ToArray());
    }

    public YesNoGatedNumericQuestion(InputSection yesOrNoQuestion, InputSection numericQuestion, YesNoGatedNumericQuestionArgs args)
    {
        _numQuestionCondition = args.NumQuestionCondition;
        _postYesOrNoAction = args.PostYesOrNoAction;
        _postNumAction = args.PostNumAction;

        _yesOrNoQuestion = yesOrNoQuestion;
        _numericQuestion = numericQuestion;
    }

    public void AnswerForNumericResponse(int numberResponse, int waitSeconds = DEFAULT_WAIT_SECONDS)
    {
        var numConditionMet = _numQuestionCondition(numberResponse);
        AnswerYesOrNoSection(numConditionMet, waitSeconds);

        if (numConditionMet)
        {
            AnswerNumericSection(numberResponse, waitSeconds);
        }
    }

    private void AnswerNumericSection(int numberResponse, int waitSeconds)
    {
        _numericQuestion.AssertAllElements(waitSeconds);
        _numericQuestion.EnterResponse(numberResponse, waitSeconds);
        _postNumAction();
    }

    private void AnswerYesOrNoSection(bool yesOrNoResponse, int waitSeconds)
    {
        _yesOrNoQuestion.AssertAllElements(waitSeconds);
        _yesOrNoQuestion.EnterResponse(yesOrNoResponse, waitSeconds);
        _postYesOrNoAction();
    }
}

public class YesNoGatedNumericQuestionArgs
{
    public List<Element> YesOrNoQuestionElements { get; set; }
    public List<Element> NumQuestionElements { get; set; }
    public Func<int, bool> NumQuestionCondition { get; set; }
    public Action PostYesOrNoAction { get; set; }
    public Action PostNumAction { get; set; }
    public YesOrNoGroup YesOrNoButtons { get; set; }
    public Element NumQuestionTextBox { get; set; }
    public Element YesOrNoQstTxt { get; set; }
    public Element NumericQstTxt { get; set; }
}