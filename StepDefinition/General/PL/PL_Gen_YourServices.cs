using System.Linq;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.PL;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Source.Helpers;
using TechTalk.SpecFlow;
using System.Threading;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_YourServices
    {
        private PLYourServicesObject _localServicesObject = new PLYourServicesObject();
        
        private readonly MadLibsSummaryObject _madLibsSummaryObject;
        private readonly PLSummaryObject _plSummaryObject;
        private bool _optInToSoftCredit;


        public PL_Gen_YourServices(MadLibsSummaryObject madLibsSummaryObject, PLSummaryObject plSummaryObject)
        {
            _madLibsSummaryObject = madLibsSummaryObject;
            _plSummaryObject = plSummaryObject;
        }

        // FIXME: This needs to be either injected as a scenario-level container instance or

        //        used differently below to avoid possible multi-threaded issues

        [Then(@"user fills out the PL Your Services page")]
        public async Task UserFillsPLYourServices(Table table)
        {
            AutomationHelper.LegacyWaitForLoading();
            PL_YourServicesPage.YourServicesPageTitle.AssertElementIsVisible();
            PL_YourServicesPage.YourServicesSubTitle.AssertElementIsVisible();

            var tableRows = table.Rows;
            var questions = tableRows.Where(row => !row["Question"].StartsWith("Soft credit check info"));
            var softCreditInfo = tableRows.Where(row => row["Question"].StartsWith("Soft credit check info"));
            _optInToSoftCredit = false;

            foreach (TableRow rowy in questions)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                await HandlePLYourServicesPage(theQuestion, theAnswer);
            }

            if (_optInToSoftCredit)
            {
                PL_YourServicesPage.SoftCreditInfoHeader.AssertElementIsVisible();

                foreach (TableRow rowy in softCreditInfo)
                {
                    var infoField = rowy["Question"];
                    var theAnswer = rowy["Answer"];
                    HandleSoftCreditCheckDetail(infoField, theAnswer);
                }
            }

            PL_YourServicesPage.YourServiceCTABtn.Click();
        }

        private async Task HandlePLYourServicesPage(string theQuestion, string theAnswer)
        {
            var quoteKeyword = _madLibsSummaryObject.Keyword;
            var questionDefinition = await LegacyQuestionApiHelper.GetPLQuestionDefinitionByText(theQuestion, quoteKeyword);
            questionDefinition ??= await LegacyQuestionApiHelper.GetFEQuestionDefinitionByText(theQuestion);

            _localServicesObject.QuestionID = questionDefinition.DataQa.ToString();
            _localServicesObject.QuestionText = theQuestion;
            _localServicesObject.QuestionAnswer = theAnswer;
            _localServicesObject.QuestionSentence = questionDefinition.SentencesFormat ?? string.Empty;

            //verify the appearance of the question
            PL_YourServicesPage.YourServiceQST(_localServicesObject.QuestionID).AssertElementIsVisible();

            //get the type of question (pulled from DB), so we know how to interact with the answer
            var theQuestionType = questionDefinition.QuestionType;

            switch (theQuestionType)
            {
                case "R": //Yes/No button
                case "L": //single select weird button names/List options
                    var parsedAnswer = GetParsedListAnswer(_localServicesObject.QuestionID, theAnswer);
                    PL_YourServicesPage.YourServiceYNButtonAnswer(_localServicesObject.QuestionID, parsedAnswer).AssertElementIsVisible();
                    PL_YourServicesPage.YourServiceYNButtonAnswer(_localServicesObject.QuestionID, parsedAnswer).Click();
                     break;
                case "T":  //Textbox
                    PL_YourServicesPage.YourServiceTextboxAnswer(_localServicesObject.QuestionID).AssertElementIsVisible();
                    PL_YourServicesPage.YourServiceTextboxAnswer(_localServicesObject.QuestionID).SetText(theAnswer);
                    break;
                case "C":  //Checkboxes (multiselect)
                    //need to iterate through if there is more than one selected
                    ClickOnCheckBoxes(_localServicesObject.QuestionID, theAnswer); 
                    break;
                 default:
                     break;
            }

            if (questionDefinition.QuestionText == "Do you want to save up to 35% with a soft credit check?")
            {
                _optInToSoftCredit = Functions.ConvertYesOrNoStringToBool(theAnswer);
            }

            //add the object to the Summary List
            if (!questionDefinition.DataQa.StartsWith("fe_"))
            {
                _plSummaryObject.PLServicesObjectList.Add(_localServicesObject);
            }
            //clear out the object for re-use
            _localServicesObject = new PLYourServicesObject();
        }

        private static void HandleSoftCreditCheckDetail(string infoField, string theAnswer)
        {
            switch (infoField)
            {
                case "Soft credit check info name":
                    var nameParts = theAnswer.Split(' ');
                    PL_YourServicesPage.SoftCreditFirstName.EnterResponse(nameParts[0]);
                    PL_YourServicesPage.SoftCreditLastName.EnterResponse(nameParts[1]);
                    break;
                case "Soft credit check info address":
                    var addressParts = Functions.ParseSemicolonSeparatedList(theAnswer).ToArray();
                    PL_YourServicesPage.SoftCreditAddress.EnterResponse(addressParts[0]);
                    if (addressParts.Length > 1)
                    {
                        PL_YourServicesPage.SoftCreditAptNum.EnterResponse(addressParts[1]);
                    }

                    break;
                case "Soft credit check info zip":
                    PL_YourServicesPage.SoftCreditZipCode.EnterResponse(theAnswer);
                    break;
                case "Soft credit check info city":
                    PL_YourServicesPage.SoftCreditCity.EnterResponse(theAnswer);
                    break;
                case "Soft credit check info state":
                    PL_YourServicesPage.SoftCreditState.EnterResponse(State.FromAny(theAnswer));
                    break;
            }
        }

        //This is to handle reading in the string to check the boxes for the questions:
        //NOTE: it assumes that the list is separated by semicolons
        private static void ClickOnCheckBoxes(string questionId, string answerList)
        {
            string pattern = @"[A-z (),./&]*";
            Regex rgx = new Regex(pattern);
            Match match = rgx.Match(answerList);

            while (match.Success)
            {
                // click on match listed
                var singleAnswer = match.Value; //this is what is used to get the information returned from that match
                if (singleAnswer != "")
                {
                    PL_YourServicesPage.YourServiceCheckboxAnswer(questionId, singleAnswer).AssertElementIsVisible();
                    PL_YourServicesPage.YourServiceCheckboxAnswer(questionId, singleAnswer).Click();
                }
                match = match.NextMatch();
            }
        }

        private static string GetParsedListAnswer(string questionId, string answer) 
        {
            string value="";
            
            string pattern = @"[ \w]+";
            Regex rgx = new Regex(pattern);
            Match match = rgx.Match(answer);

            while (match.Success) 
            {
                value = $"{value}{match.Value}";

                match = match.NextMatch();
            }
            return value;
        }
    }
}