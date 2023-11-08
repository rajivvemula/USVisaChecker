using HitachiQA.Driver;

public class ReferPageFieldObject
{
    public string Name;
    public string QuestionLabelText;
    public Element QuestionElement;
    public Element InputField;

    public ReferPageFieldObject(string name, string questionLabelText, Element questionElement, Element inputField)
    {
        Name = name;
        QuestionLabelText = questionLabelText;
        QuestionElement = questionElement;
        InputField = inputField;
    }
}