using System;
using System.Collections.Generic;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Source.Driver;

public class YesNoGatedNumericQuestionBuilder
{
    private Element _yesOrNoQstTxt;
    private List<Element> _yesOrNoQuestionElements = new List<Element>();
    private Element _numQstTxt;
    private List<Element> _numQuestionElements = new List<Element>();
    
    private Func<int, bool> _numQuestionCondition = num => num > 0;
    private Action _postYesOrNoAction = () => { };
    private Action _postNumAction = () => { };
    private YesOrNoGroup _yesOrNoButtons;
    private Element _numQuestionTextBox;

    private InputSection _yesOrNoInputSection;
    private InputSection _numericInputSection;

    public YesNoGatedNumericQuestionBuilder(Element yesOrNoQstTxt, YesOrNoGroup yesOrNoButtons, Element numQstTxt, Element numQuestionTextBox)
    {
        _yesOrNoQstTxt = yesOrNoQstTxt;
        _yesOrNoButtons = yesOrNoButtons;
        _numQstTxt = numQstTxt;
        _numQuestionTextBox = numQuestionTextBox;
    }

    public YesNoGatedNumericQuestionBuilder(InputSection yesOrNoInputSection, InputSection numericInputSection)
    {
        _yesOrNoInputSection = yesOrNoInputSection;
        _numericInputSection = numericInputSection;
    }
    
    public YesNoGatedNumericQuestionBuilder WithYesOrNoElements(params Element[] yesOrNoElements)
    {
        _yesOrNoQuestionElements.AddRange(yesOrNoElements);
        return this;
    }

    public YesNoGatedNumericQuestionBuilder WithNumQuestionElements(params Element[] numQuestionElements)
    {
        _numQuestionElements.AddRange(numQuestionElements);
        return this;
    }

    public YesNoGatedNumericQuestionBuilder WithNumQuestionCondition(Func<int, bool> condition)
    {
        _numQuestionCondition = condition;
        return this;
    }

    public YesNoGatedNumericQuestionBuilder WithPostYesOrNoAction(Action action)
    {
        _postYesOrNoAction = action;
        return this;
    }

    public YesNoGatedNumericQuestionBuilder WithPostNumAction(Action action)
    {
        _postNumAction = action;
        return this;
    }

    public YesNoGatedNumericQuestion Build()
    {
        if (_yesOrNoInputSection != null)
        {
            var shortenedArgs = new YesNoGatedNumericQuestionArgs()
            {
                NumQuestionCondition = _numQuestionCondition,
                PostYesOrNoAction = _postYesOrNoAction,
                PostNumAction = _postNumAction,
            };
            return new YesNoGatedNumericQuestion(_yesOrNoInputSection, _numericInputSection, shortenedArgs);
        }

        var args = new YesNoGatedNumericQuestionArgs()
        {
            YesOrNoQstTxt = _yesOrNoQstTxt,
            YesOrNoButtons = _yesOrNoButtons,
            YesOrNoQuestionElements = _yesOrNoQuestionElements,
            NumericQstTxt = _numQstTxt,
            NumQuestionTextBox = _numQuestionTextBox,
            NumQuestionElements = _numQuestionElements, 
            NumQuestionCondition = _numQuestionCondition,
            PostYesOrNoAction = _postYesOrNoAction,
            PostNumAction = _postNumAction, 
        };
        return new YesNoGatedNumericQuestion(args);
    }
}