using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public class PLYourServicesObject
    {
        public PLYourServicesObject() { }

        public string QuestionText { get; set; } = "";
        public string QuestionID { get; set; } = "";
        public string QuestionAnswer { get; set; } = "";
        //if a summative sentence is used on the Summary page instead of question/answer display
        //it will be listed here, is pulled from the database
        public string QuestionSentence { get; set; } = "";
    }
}