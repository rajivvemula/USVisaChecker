using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    public class OperationMappingObject
    {
        public OperationMappingObject() { }

        public OperationMappingObject(string a, string b, string c)
        {
            QuestionText = a;
            QuestionAttribute = b;
            AnswerAttribute = c;
        }

        public string QuestionText { get; set; } 
        public string QuestionAttribute { get; set; } 
        public string AnswerAttribute { get; set; } 
    }
}
