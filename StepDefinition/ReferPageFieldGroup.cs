using HitachiQA;
using System.Collections.Generic;

namespace BiBerkLOB.StepDefinition
{
    public sealed class ReferPageFieldGroup
    {
        private List<ReferPageFieldObject> _referFieldObjects = new();

        public ReferPageFieldGroup(List<ReferPageFieldObject> referFieldObjects) 
        {
            _referFieldObjects = referFieldObjects;
        }

        public void FillReferField(string field, string value)
        {
            foreach (var referField in _referFieldObjects)
            {
                if (referField.Name == field)
                {
                    referField.QuestionElement.AssertElementIsVisible();
                    var QuestionText = referField.QuestionElement.GetInnerText().ToLower();
                    Assert.AreEqual(QuestionText, referField.QuestionLabelText.ToLower());
                    referField.InputField.SetText(value);
                }
            }
        }
    }
}