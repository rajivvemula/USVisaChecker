using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
namespace BiBerkLOB.Pages.WC
{
    [Binding]
    public class WCYourServicesObject
    {
        public WCYourServicesObject() { }

        public string QuestionText { get; set; } = "";
        public string QuestionID { get; set; } = "";
        public string QuestionAnswer { get; set; } = "";
        //if a summative sentence is used on the Summary page instead of question/answer display
        //it will be listed here, is pulled from the database
        public string QuestionSentence { get; set; } = "";
    }
}
