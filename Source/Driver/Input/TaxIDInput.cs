using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Source.Driver.Input
{
    public class TaxIDInput : InputSection
    {
        private Element _textBox;
        private Element _choice;
        public TaxIDInput(Element choice, Element textBox)
        {
            _choice = choice;
            _textBox = textBox;
        }
        public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
        {
            _choice.AssertElementIsVisible(waitSeconds);
            _choice.Click();
            _textBox.AssertElementIsVisible(waitSeconds);
        }

        public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
        {
            _choice.Click();
            _textBox.SetText(answer.ToString(), waitSeconds);
        }

        public override bool IsResponseCurrentlyEqualTo(object answer)
        {
            return _textBox.GetTextFieldValue(1) == answer.ToString();
        }
    }
}