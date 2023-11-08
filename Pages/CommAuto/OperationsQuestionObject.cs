using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;

namespace BiBerkLOB.Pages.CommAuto
{
    public class OperationsQuestionObject
    {
        public OperationsQuestionObject(string questionText, string questionAnswer, ApolloQuestionDefinition questionDefinition) 
        {
            QuestionText = questionText;
            QuestionAnswer = questionAnswer;
            QuestionDefinition = questionDefinition;
        }

        public string QuestionText { get; set; }
        public string QuestionAnswer { get; set; }
        public ApolloQuestionDefinition QuestionDefinition { get; set; }
    }
}