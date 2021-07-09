using ApolloQA.Data.Entity.Question;
using System;
using System.Collections.Generic;
using ApolloQA.Pages;
using TechTalk.SpecFlow;
using ApolloQA.Source.Helpers;
using OpenQA.Selenium;
using ApolloQA.Source.Driver;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_Section_OperationsSteps
    {
        public IWebDriver driver;

        Quote_Section_OperationsSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        private string DOT = Functions.GetRandomInteger(100000).ToString();
        private string party = "bus or limousine services where alcohol is provided or expressly permitted?";

        [When(@"user verifies Operations questions")]
        public void WhenUserVerifiesOperationsQuestions()
        {
            switch (SharedSteps.BusinessKeyword)
            {
                case "Trucking: Local Hauling: less than 300 miles":
                    foreach (string entry in OpQuestionAliases.TruckingLocalHauling)
                    {
                        string questionText = new Question($"{entry}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?")
                        {
                            Shared.GetQuestionAnswer(questionText, "No").Click();
                        }
                        if(questionText == "Does your business have a USDOT Number?")
                        {
                            Shared.GetQuestionAnswer(questionText, "Yes").Click();
                        }
                        Shared.FindOperationQuestion(questionText).assertElementIsVisible();
                    }
                    break;
                case "Trucking: Long Distance Hauling: more than 300 miles":
                    foreach (string entry in OpQuestionAliases.TruckingLongDistance)
                    {
                        string questionText = new Question($"{entry}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?")
                        {
                            Shared.GetQuestionAnswer(questionText, "No").Click();
                        }
                        if (questionText == "Does your business have a USDOT Number?")
                        {
                            Shared.GetQuestionAnswer(questionText, "Yes").Click();
                        }
                        Shared.FindOperationQuestion(questionText).assertElementIsVisible();
                    }
                    break;
                case "Towing Services":
                    foreach (string entry in OpQuestionAliases.TowingServices)
                    {
                        string questionText = new Question($"{entry}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?")
                        {
                            Shared.GetQuestionAnswer(questionText, "No").Click();
                        }
                        if (questionText == "Does your business have a USDOT Number?")
                        {
                            Shared.GetQuestionAnswer(questionText, "Yes").Click();
                        }
                        Shared.FindOperationQuestion(questionText).assertElementIsVisible();
                    }
                    break;
                case "Limousine Company":
                    foreach (string entry in OpQuestionAliases.LimoCompany)
                    {
                        string questionText = new Question($"{entry}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?")
                        {
                            Shared.GetQuestionAnswer(questionText, "No").Click();
                        }
                        try { Shared.FindOperationQuestion(questionText).assertElementIsVisible(5); }
                        catch { Shared.FindOperationQuestion(party).assertElementIsVisible(3); }
                    }
                    break;
                case "Bus Company":
                    foreach (string entry in OpQuestionAliases.LimoCompany)
                    {
                        string questionText = new Question($"{entry}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?")
                        {
                            Shared.GetQuestionAnswer(questionText, "No").Click();
                        }
                        try { Shared.FindOperationQuestion(questionText).assertElementIsVisible(10); }
                        catch { Shared.FindOperationQuestion(party).assertElementIsVisible(5); }
                    }
                    break;
                case "Brine Hauling: Under 300 Miles":
                    foreach (string entry in OpQuestionAliases.BrineHaulingLess300)
                    {
                        string questionText = new Question($"{entry}").QuestionText;
                        if (questionText == "Do you rent, hire, or borrow any vehicles?")
                        {
                            Shared.GetQuestionAnswer(questionText, "No").Click();
                        }
                        if (questionText == "Does your business have a USDOT Number?")
                        {
                            Shared.GetQuestionAnswer(questionText, "Yes").Click();
                        }
                        Shared.FindOperationQuestion(questionText).assertElementIsVisible();
                    }
                    break;
                default: throw new Exception("Unknown Business Keyword");
            }
        }

        [When(@"user answers Operations questions")]
        public void WhenUserAnswersOperationsQuestions()
        {
            switch (SharedSteps.BusinessKeyword)
            {
                case "Towing Services":
                    foreach (KeyValuePair<string, string> entry in OpQuestion_answers.TowingServices)
                    {
                        string answer = entry.Value;
                        string questionText = new Question($"{entry.Key}").QuestionText;
                        try { Shared.GetQuestionAnswer(questionText, answer).Click(10); ; }
                        catch
                        {
                            if (questionText == "How many auto insurance claims did your business file in the last 3 years?")
                            {
                                Shared.ClaimsCount.setText(answer);
                            }
                            if (questionText == "Do you haul any of these? Check all that apply:")
                            {
                                Shared.GetDropdownField("Select").SelectMatDropdownOptionByText(answer);
                                Shared.OperationsListBox.sendKeysTab();
                            }
                            if (questionText == "Enter the USDOT number")
                            {
                                Shared.USDOTNumber.setText(DOT);
                            }
                        }
                    }
                    break;

                case "Trucking: Long Distance Hauling: more than 300 miles":
                    foreach (KeyValuePair<string, string> entry in OpQuestion_answers.TruckingLongDistance)
                    {
                        string answer = entry.Value;
                        string questionText = new Question($"{entry.Key}").QuestionText;
                        Shared.FindOperationQuestion(questionText).assertElementIsVisible();
                        try { Shared.GetQuestionAnswer(questionText, answer).Click(10); }
                        catch
                        {
                            if (questionText == "How many auto insurance claims did your business file in the last 3 years?")
                            {
                                Shared.ClaimsCount.setText(answer);
                            }
                            if (questionText == "Enter the USDOT number")
                            {
                                Shared.USDOTNumber.setText(DOT);
                            }
                            if (questionText == "Do you haul any of these? Check all that apply:")
                            {
                                Shared.GetDropdownField("Select").SelectMatDropdownOptionByText(answer);
                                Shared.OperationsListBox.sendKeysTab();
                            }
                        }
                    }
                    break;

                case "Limousine Company":
                    foreach (KeyValuePair<string, string> entry in OpQuestion_answers.LimoCompany)
                    {
                        string answer = entry.Value;
                        string questionText = new Question($"{entry.Key}").QuestionText;
                        try { Shared.GetQuestionAnswer(questionText, answer).Click(10); }
                        catch
                        {
                            if (questionText == "How many auto insurance claims did your business file in the last 3 years?")
                            {
                                Shared.ClaimsCount.setText(answer);
                            }

                            if (questionText == "Do you offer \"party\" bus or limousine services where alcohol is provided or expressly permitted?")
                            {
                                SpecialOperationsAnswer(answer).Click();
                            }
                        }
                    }
                    break;
                case "Bus Company":
                    foreach (KeyValuePair<string, string> entry in OpQuestion_answers.BusCompany)
                    {
                        string answer = entry.Value;
                        string questionText = new Question($"{entry.Key}").QuestionText;
                        try { Shared.GetQuestionAnswer(questionText, answer).Click(2); }
                        catch
                        {
                            if (questionText == "How many auto insurance claims did your business file in the last 3 years?")
                            {
                                Shared.ClaimsCount.setText(answer);
                            }
                            if (questionText == "Enter the USDOT number")
                            {
                                Shared.USDOTNumber.setText(DOT);
                            }
                            if (questionText == "Do you offer \"party\" bus or limousine services where alcohol is provided or expressly permitted?")
                            {
                                SpecialOperationsAnswer(answer).Click();
                            }
                        }
                    }
                    break;
                default: throw new Exception("Unknown Business Keyword");
            }
        }

        [When(@"user clicks Next Button to complete Operations")]
        public void WhenUserClicksNextButtonToCompleteOperations()
        {
            if(SharedSteps.BusinessKeyword != "Limousine Company")
            {
                String URL = driver.Url;
                Shared.GetButton("Next").Click();
                new SharedSteps().WhenUserWaitsForSpinnerToDissappearForSeconds(30);
                if (URL.EndsWith("section/9020"))
                {
                    do
                    {
                        var DOT2 = Functions.GetRandomInteger(100000).ToString();
                        Shared.USDOTNumber.setText("6" + $"{DOT2}");
                        Shared.GetButton("Next").Click();
                        new SharedSteps().WhenUserWaitsForSpinnerToDissappearForSeconds(30);
                    }
                    while (driver.Url.EndsWith("section/9020"));
                }
                Shared.GetToastContaining("Your Cab File request is complete.");
            }
            else { Shared.GetButton("Next").Click(); }
        }

        private Element SpecialOperationsAnswer(string OperationsAnswer)
        {
            return new Element($"//bh-question-boolean[descendant::*[contains(text(), 'bus or limousine services where alcohol is provided or expressly permitted?')]] //mat-radio-button[descendant::*[normalize-space(text())='{OperationsAnswer}']]");
        }
    }
}
