using HitachiQA.Driver;

namespace BiBerkLOB.Pages.PL
{
    public sealed class SummaryStatementObj
    {
        public SummaryStatementObj(string questionText, string answerText, Element questionElement, Element answerElement) 
        { 
            QuestionText = questionText;
            AnswerText = answerText;
            QuestionElement = questionElement;
            AnswerElement = answerElement;
        }

        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public Element QuestionElement { get; set; }
        public Element AnswerElement { get; set; }
    }
}
