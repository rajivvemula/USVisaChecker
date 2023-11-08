using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.WC
{
    public class OwnerOfficerQuestionObject
    {
        public string QuestionText { get; set; }
        public string QuestionAnswer { get; set; }

        public OwnerOfficerQuestionObject(string questionText, string questionAnswer)
        {
            QuestionText = questionText;   
            QuestionAnswer = questionAnswer;
        }
    }
}
