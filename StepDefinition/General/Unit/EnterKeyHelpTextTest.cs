using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using HitachiQA;
using OpenQA.Selenium;
using HitachiQA.Driver;
using System.Text.RegularExpressions;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;

namespace BiBerkLOB.StepDefinition.General.Unit
{
    [Binding]
    public sealed class EnterKeyHelpTextTest
    {
        private readonly CASummaryObject _caSummaryObject;
        
        public EnterKeyHelpTextTest(CASummaryObject caSummaryObject)
        {
            _caSummaryObject = caSummaryObject;
        }

        [When(@"user presses enter after selecting each relevant field on the (.*)")]
        public void WhenUserPressesEnterAfterSelectingEachRelevantFieldOnThe(string page)
        {
            SetupPage(page);
            PressEnterAfterSelectingEachField(page);
        }

        [Then(@"user verifies that no help text messages are displayed")]
        public void ThenUserVerifiesThatNoHelpTextMessagesAreDisplayed()
        {
            var helptTextMessages = GetListOfElements(By.XPath("//div[contains(@class, 'bb-helptext')]"));

            Assert.IsNull(helptTextMessages);
        }


        public IList<IWebElement> GetListOfElements(By locator)
        {
            try
            {
                var elements = UserActions.FindElementsWaitUntilVisible(locator, 5);

                return elements;
            }
            catch
            {
                return null;
            }
        }

        public void SetupPage(string page)
        {
            switch (page)
            {
                case "Your Vehicles page":
                    ExpandVehicleTab();
                    break;
                case "Your Operations page":
                    AddOperationsPageHelpFields();
                    break;
            }
        }

        public void PressEnterAfterSelectingEachField(string page)
        {
            if (FieldsWithHelpText.ContainsKey(page))
            {
                foreach (var element in FieldsWithHelpText.GetValueOrDefault(page))
                {
                    element.Click();
                    UserActions.GetPressKeywordEnter();
                }
            }
        }

        public void ExpandVehicleTab()
        {
            CA_VehiclesPage.DisabledVehiclePanel.AssertElementIsPresent();
            CA_VehiclesPage.DisabledVehiclePanel.AssertElementNotPresent();
            CA_VehiclesPage.UnexpandedVehiclePanel.AssertElementIsVisible();
            CA_VehiclesPage.UnexpandedVehiclePanel.Click();
        }

        public void AddOperationsPageHelpFields()
        {
            var ListOfElementsWithHelpText = new List<Element>();

            foreach (var question in _caSummaryObject.OpQuestions) 
            {
                if (DoesElementHaveHelpText(question.QuestionText))
                {
                    ListOfElementsWithHelpText.Add(GetOperationsFieldWithHelpText(question));
                }
            }

            FieldsWithHelpText.Add("Your Operations page", ListOfElementsWithHelpText);
        }

        public string GetHelpTextIconElement(string questionText) 
        {
            Regex xpathRegex = new Regex("(?<=By.XPath: ).*");

            var question = questionText;
            var questionTextElementPath = CA_OperationsPage.GetQuestionText(question).locator.ToString();
            var questionHelpElementPath = xpathRegex.Match($"{questionTextElementPath}/../../..//button[contains(@data-qa, 'Help')]").ToString();

            IWebElement element = null;

            try
            {
                element = UserActions.FindElementWaitUntilVisible(By.XPath(questionHelpElementPath), 3);
            }
            catch
            {
                Log.Info($"No help icon found for question: {questionText} (Xpath = {questionHelpElementPath})");
            }

            if (element != null) 
            { 
                return questionHelpElementPath; 
            }
            return null;
        }

        public bool DoesElementHaveHelpText(string questionText) 
        {
            string element = GetHelpTextIconElement(questionText);

            return element != null;
        }

        public Element GetOperationsFieldWithHelpText(OperationsQuestionObject question)
        {
            var questionDefinition = question.QuestionDefinition;
            var questionAnswer = questionDefinition.GetAnswerFromText(question.QuestionAnswer);
            switch (questionDefinition.QuestionType)
            {
                case "singleselection-buttons":
                    return CA_OperationsPage.GetSSButton(questionDefinition.QuestionAlias, questionAnswer.AnswerValue);
                case "boolean":
                    //boolean question don't need an entry in answer table
                    return CA_OperationsPage.GetBooleanButton(questionDefinition.QuestionAlias, question.QuestionAnswer);
                case "multiselection":
                    return CA_OperationsPage.GetMultiSelection(questionDefinition.QuestionAlias, questionAnswer.AnswerValue);
                case "numeric":
                case "number-string":
                case "text":
                    return CA_OperationsPage.GetTextBox(questionDefinition.QuestionAlias);
                default:
                    return null;
            }
        }

        private Dictionary<string, List<Element>> FieldsWithHelpText = new Dictionary<string, List<Element>>
        {
            {"Start Your Quote page", new List<Element> { CA_PreIntroductionPage.AnotherNameYes, CA_PreIntroductionPage.PolicyStartTxtbox } },
            {"A Quick Introduction page", new List<Element> { CA_IntroductionPage.BusinessStartedTxtbox, CA_IntroductionPage.BusinessStructuredDD } },
            {"Your Vehicles page", new List<Element> { CA_VehiclesPage.WantToUseVINNo, CA_VehiclesPage.SoldVehicleTodayWorthTxtbox } },
            {"Your Drivers page", new List<Element> { CA_DriversPage.DriverHaveAccidentOrViolationNo(0) } },
            //NOTE: The Operations page entry is added by AddOperationsPageHelpFields()
        };
    }
}