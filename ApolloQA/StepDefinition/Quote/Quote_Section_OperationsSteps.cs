using ApolloQA.Data.Entity.Question;
using System;
using System.Collections.Generic;
using ApolloQA.Pages;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_Section_OperationsSteps
    {
        [When(@"user verifies Operations questions")]
        public void WhenUserVerifiesOperationsQuestions()
        {
            switch (SharedSteps.BusinessKeyword)
            {
                case "Trucking: Local Hauling: less than 300 miles":
                    foreach (KeyValuePair<string, string> entry in OperationsQuestions.TruckingLocalHauling)
                    {
                        string answer = entry.Value;
                        string questionText = new Question($"{entry.Key}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?" | questionText == "Does your business have a USDOT Number?")
                        {
                            Shared.GetQuestionAnswer(questionText, answer).Click();
                        }
                        Shared.FindOperationQuestion(questionText).assertElementIsVisible();
                    }
                    break;
                case "Towing Services":
                    foreach (KeyValuePair<string, string> entry in OperationsQuestions.TowingServices)
                    {
                        string answer = entry.Value;
                        string questionText = new Question($"{entry.Key}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?" | questionText == "Does your business have a USDOT Number?")
                        {
                            Shared.GetQuestionAnswer(questionText, answer).Click();
                        }
                        Shared.FindOperationQuestion(questionText).assertElementIsVisible();
                    }
                    break;
                case "Trucking: Long Distance Hauling: more than 300 miles":
                    foreach (KeyValuePair<string, string> entry in OperationsQuestions.TruckingLongDistance)
                    {
                        string answer = entry.Value;
                        string questionText = new Question($"{entry.Key}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?" | questionText == "Does your business have a USDOT Number?")
                        {
                            Shared.GetQuestionAnswer(questionText, answer).Click();
                        }
                        Shared.FindOperationQuestion(questionText).assertElementIsVisible();
                    }
                    break;
                case "Limousine Company":
                    string party = "";
                    foreach (KeyValuePair<string, string> entry in OperationsQuestions.LimoCompany)
                    {
                        string answer = entry.Value;
                        string questionText = new Question($"{entry.Key}").QuestionText;
                        if (questionText == "Do you offer \"party\" bus or limousine services where alcohol is provided or expressly permitted?")
                        {
                            party = "bus or limousine services where alcohol is provided or expressly permitted?";
                        }
                        if (questionText == "Do you rent, hire, or borrow any vehicles?")
                        {
                            Shared.GetQuestionAnswer(questionText, answer).Click();
                        }
                        try
                        {
                            Shared.FindOperationQuestion(party).assertElementIsVisible(3);
                        }
                        catch { Shared.FindOperationQuestion(questionText).assertElementIsVisible(); }
                    }
                    break;
                case "Brine Hauling: Under 300 Miles":
                    foreach (KeyValuePair<string, string> entry in OperationsQuestions.BrineHaulingLess300)
                    {
                        string answer = entry.Value;
                        string questionText = new Question($"{entry.Key}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?" | questionText == "Does your business have a USDOT Number?")
                        {
                            Shared.GetQuestionAnswer(questionText, answer).Click();
                        }
                        Shared.FindOperationQuestion(questionText).assertElementIsVisible();
                    }
                    break;
                default: throw new Exception("Unknown Business Keyword");
            }
        }
    }
}
